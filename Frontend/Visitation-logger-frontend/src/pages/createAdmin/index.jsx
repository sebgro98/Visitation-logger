import HandleAccount from "../../components/handleAccount";
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
    <HandleAccount
      accountType="admin"
      handleAccountAction={createAdminAccount}
      fields={fields}
    />
  );
};

export default CreateAdmin;
