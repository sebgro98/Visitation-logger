import HandleAccount from "../../components/handleAccount";
import { createVisitorAccount } from "../../services/apiClient";

const CreateVisitor = () => {
  const fields = {
    username: "",
    password: "",
    startDate: "",
    endDate: "",
    purposeTypeId: "",
    nodeId: "",
  };

  return (
    <HandleAccount
      accountType="visitor"
      handleAccountAction={createVisitorAccount}
      fields={fields}
    />
  );
};

export default CreateVisitor;
