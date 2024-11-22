import HandleAccount from "../../components/handleAccount";
import { createVisitorAccount } from "../../services/apiClient";

const CreateVisitor = () => {
  const fields = {
    username: "hasse",
    password: "",
    startDate: "",
    endDate: "",
    purposeTypeId: "",
    nodeId: "",
  };

  return (
    <HandleAccount
      accountType="visitor"
      createAcchandleAccountAction
      ount={createVisitorAccount}
      fields={fields}
    />
  );
};

export default CreateVisitor;
