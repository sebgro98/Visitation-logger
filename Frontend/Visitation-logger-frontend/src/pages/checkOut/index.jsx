import { useEffect, useState } from "react";
import VisitorForm from "../visitorForm";
import { useNavigate } from "react-router-dom";
import jwt_decode from "jwt-decode";
import Popup from "../../components/popup";
import {
  createCheckOutStatus,
  getCheckInStatus,
  getStatusById,
  getVisitorAccountById,
} from "../../services/apiClient";
import LoadingCircle from "../../components/loadingCircle";

const CheckOut = () => {
  const [hasVisitorId, setHasVisitorId] = useState(false);
  const [hasCheckedInToday, setHasCheckedInToday] = useState(false);
  const [statusId, setStatusId] = useState("");
  const [isAllreadyCheckedOut, setIsAllreadyCheckedOut] = useState(false);
  const navigate = useNavigate();
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    const fetchData = async () => {
      const storedToken = localStorage.getItem("token");
      const decryptedToken = jwt_decode(storedToken);
      const id = decryptedToken.nameid;

      const fetchVisotorAccountById = async () => {
        try {
          const visitorAccount = await getVisitorAccountById(id);
          console.log("Visitor account:", visitorAccount);

          setHasVisitorId(visitorAccount.visitor.id ? true : false);
        } catch (error) {
          console.error("Error fetching visitor account:", error);
        }
      };

      const fetchCeckInStatus = async () => {
        try {
          const checkInStatus = await getCheckInStatus(id);
          setHasCheckedInToday(checkInStatus.checkedInToday);
          const checkInStatusId = checkInStatus.statusId;
          setStatusId(checkInStatusId);
          const status = await getStatusById(checkInStatusId);
          setIsAllreadyCheckedOut(status.checkOutTime !== null);
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

  console;
  const createStatus = () => {
    const status = {
      checkOutTime: new Date(),
      checkOutSign: "test",
      lastExportDate: new Date(),
      isExport: false,
    };

    return status;
  };

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
      {!hasCheckedInToday ? (
        <Popup
          message="Användare har inte checkat in idag!"
          onClose={() => {
            navigate("/dashboard");
          }}
        />
      ) : isAllreadyCheckedOut ? (
        <Popup
          message="Användare har redan checkats ut idag!"
          onClose={async () => navigate("/dashboard")}
        />
      ) : (
        <Popup
          message="Användare har checkats ut!"
          onClose={async () => {
            const status = createStatus();
            console.log("statusID:", statusId);
            const respone = await createCheckOutStatus(statusId, status);
            console.log("Response:", respone);
            navigate("/dashboard");
          }}
        />
      )}
    </>
  );
};

export default CheckOut;
