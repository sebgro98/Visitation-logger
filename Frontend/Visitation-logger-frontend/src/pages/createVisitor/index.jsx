import CreateAccount from "../../components/createAccount";
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
    <CreateAccount
      accountType="visitor"
      createAccount={createVisitorAccount}
      fields={fields}
    />
  );
};

export default CreateVisitor;
