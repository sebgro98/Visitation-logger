import { useEffect, useState } from "react";
import VisitorForm from "../visitorForm";
import { useNavigate } from "react-router-dom";
import jwt_decode from "jwt-decode";
import Popup from "../../components/popup";
import {
  createCheckInStatus,
  getCheckInStatus,
  getVisitorAccountById,
} from "../../services/apiClient";
import LoadingCircle from "../../components/loadingCircle";

const CheckIn = () => {
  const [hasVisitorId, setHasVisitorId] = useState(false);
  const [hasCheckedInToday, setHasCheckedInToday] = useState(false);
  const [accountId, setAccountId] = useState("");
  const [nodeId, setNodeId] = useState("");
  const navigate = useNavigate();
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    const fetchData = async () => {
      const storedToken = localStorage.getItem("token");
      const decryptedToken = jwt_decode(storedToken);
      const id = decryptedToken.nameid;
      setAccountId(id);

      const fetchVisotorAccountById = async () => {
        try {
          const visitorAccount = await getVisitorAccountById(id);
          console.log("Visitor account:", visitorAccount);
          setNodeId(visitorAccount.node.id);

          if (visitorAccount.visitor) {
            setHasVisitorId(visitorAccount.visitor.id ? true : false);
          }
        } catch (error) {
          console.error("Error fetching visitor account:", error);
        }
      };

      const fetchCeckInStatus = async () => {
        try {
          const checkInStatus = await getCheckInStatus(id);
          setHasCheckedInToday(checkInStatus.checkedInToday);
          console.log("statusId:", checkInStatus.statusId);
        } catch (error) {
          console.error("Error fetching visitor account:", error);
        }
      };

      await fetchCeckInStatus();
      await fetchVisotorAccountById();
      setLoading(false);
    };

    fetchData();
  }, []);

  const createStatus = () => {
    const status = {
      visitorAccountId: accountId,
      nodeId: nodeId,
      checkInTime: new Date(),
      checkInSign: "test",
    };

    return status;
  };

  console.log("Check in status:", hasCheckedInToday);
  if (loading) {
    return <LoadingCircle />;
  }

  if (!hasVisitorId) {
    return (
      <>
        <VisitorForm />
      </>
    );
  }

  return (
    <>
      {hasCheckedInToday ? (
        <Popup
          message="Användare har redan checkats in idag!"
          onClose={() => {
            navigate("/dashboard");
          }}
        />
      ) : (
        <Popup
          message="Användare har checkats in!"
          onClose={async () => {
            const status = createStatus();
            const respone = await createCheckInStatus(status);
            console.log("Response:", respone);
            navigate("/dashboard");
          }}
        />
      )}
    </>
  );
};

export default CheckIn;
