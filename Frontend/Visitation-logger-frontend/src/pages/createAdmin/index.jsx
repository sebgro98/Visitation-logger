import CreateAccount from "../../components/createAccount";
import { createAdminAccount } from "../../services/apiClient";

const CreateAdmin = () => {
  const fields = {
    username: "",
    password: "",
    fullName: "",
    accountTypeId: "",
    nodeId: "",
  };

  return (
    <CreateAccount
      accountType="admin"
      createAccount={createAdminAccount}
      fields={fields}
    />
  );
};

export default CreateAdmin;
