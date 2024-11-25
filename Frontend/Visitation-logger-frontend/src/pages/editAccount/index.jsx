import { useEffect, useState, useMemo } from "react";
import PropTypes from "prop-types";
import HandleAccount from "../../components/handleAccount";
import {
  getAdminAccountById,
  getVisitorAccountById,
  updateAdminAccount,
  updateVisitorAccount,
} from "../../services/apiClient";
import { useParams } from "react-router-dom";
import LoadingCircle from "../../components/loadingCircle";
import { formatDate } from "../../utils/utils";

const EditAccount = ({ isEditVisitorMode }) => {
  const [fields, setFields] = useState({});
  const { id } = useParams();
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    const fetchData = async () => {
      try {
        if (isEditVisitorMode) {
          const visitorAccount = await getVisitorAccountById(id);
          setFields({
            username: visitorAccount.username,
            startDate: formatDate(visitorAccount.startDate),
            endDate: formatDate(visitorAccount.endDate),
            purposeTypeId: visitorAccount.purposeType.id,
            nodeId: visitorAccount.node.id,
          });
        } else {
          const adminAccount = await getAdminAccountById(id);
          setFields({
            username: adminAccount.username,
            fullName: adminAccount.fullName,
            accountTypeId: adminAccount.accountType.id,
            nodeId: adminAccount.node.id,
          });
        }
      } catch (error) {
        console.error("Error fetching account data:", error);
      } finally {
        setLoading(false);
      }
    };

    fetchData();
  }, [isEditVisitorMode, id]);

  const memoizedFields = useMemo(() => fields, [fields]);

  if (loading) {
    return <LoadingCircle />;
  }

  return (
    <HandleAccount
      accountType={isEditVisitorMode ? "visitor" : "admin"}
      handleAccountAction={
        isEditVisitorMode ? updateVisitorAccount : updateAdminAccount
      }
      fields={memoizedFields}
      isEditMode={true}
    />
  );
};

EditAccount.propTypes = {
  isEditVisitorMode: PropTypes.bool.isRequired,
};

export default EditAccount;
