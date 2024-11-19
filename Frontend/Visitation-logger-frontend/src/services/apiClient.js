import { API_URL } from "./constants";

async function login(username, password, isAdmin) {
  return await post("Login", { username, password, isAdmin }, false);
}

async function getAllVisitorAccounts() {
  return await get("VisitorAccount");
}

async function getAllAdminAccounts() {
  return await get("Admin");
}

async function post(endpoint, data, auth = true) {
  return await request("POST", endpoint, data, auth);
}

async function get(endpoint, auth = true) {
  return await request("GET", endpoint, null, auth);
}

async function request(method, endpoint, data, auth = true) {
  const opts = {
    headers: {
      "Content-Type": "application/json",
    },
    method,
  };

  if (method.toUpperCase() !== "GET") {
    opts.body = JSON.stringify(data);
  }

  if (auth) {
    opts.headers["Authorization"] = `Bearer ${localStorage.getItem("token")}`;
  }

  const response = await fetch(`${API_URL}/${endpoint}`, opts);

  if (!response.ok) {
    throw new Error(`HTTP error! status: ${response.status}`);
  }

  return response.json();
}

export { login, getAllVisitorAccounts, getAllAdminAccounts };
