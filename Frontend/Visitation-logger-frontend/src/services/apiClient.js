import { API_URL } from "./constants";

async function login(username, password, isAdmin) {
  return await post("Login", { username, password, isAdmin }, false);
}

async function getAllVisitorAccounts() {
  return await get("VisitorAccount");
}

async function getStatusByPage(filter) {
  return await get("filter", filter);
}

async function getAllAdminAccounts() {
  return await get("Admin");
}

async function getAdminsByPage(pageNumber, pageSize) {
  return await get("Admin/byPage", { pageNumber, pageSize });
}

async function getVisitorAccountByPage(pageNumber, pageSize) {
  return await get("VisitorAccount/byPage", { pageNumber, pageSize });
}

async function getAllNodes() {
  return await get("Node");
}

async function getAllAccountTypes() {
  return await get("AccountType");
}

async function getAllPurposeTypes() {
  return await get("PurposeType");
}

async function createAdminAccount(account) {
  return await post("Admin", account);
}

async function createVisitorAccount(account) {
  return await post("VisitorAccount", account);
}

async function getVisitorAccountById(id) {
  return await get(`VisitorAccount/${id}`);
}

async function updateVisitorAccount(id, account) {
  return await put(`VisitorAccount/${id}`, account);
}

async function getAdminAccountById(id) {
  return await get(`Admin/${id}`);
}

async function updateAdminAccount(id, account) {
  return await put(`Admin/${id}`, account);
}

async function post(endpoint, data, auth = true) {
  return await request("POST", endpoint, data, auth);
}

async function get(endpoint, params = {}, auth = true) {
  return await request("GET", endpoint, params, auth);
}

async function put(endpoint, data, auth = true) {
  return await request("PUT", endpoint, data, auth);
}

async function request(method, endpoint, data, auth = true) {
  if (method.toUpperCase() === "GET" && data) {
    const queryParams = new URLSearchParams(data).toString();
    endpoint = `${endpoint}?${queryParams}`;
  }
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

  return response.json();
}

export {
  login,
  getAllVisitorAccounts,
  getStatusByPage,
  getAllAdminAccounts,
  getAdminsByPage,
  getVisitorAccountByPage,
  getAllNodes,
  getAllAccountTypes,
  createAdminAccount,
  getAllPurposeTypes,
  createVisitorAccount,
  getVisitorAccountById,
  updateVisitorAccount,
  getAdminAccountById,
  updateAdminAccount,
};
