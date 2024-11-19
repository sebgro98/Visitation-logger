// utils.js
export const formatDate = (date) => {
  if (!date) return "";
  const d = new Date(date);
  const year = d.getFullYear();
  const month = String(d.getMonth() + 1).padStart(2, "0"); // Lägg till 1 eftersom månaderna är 0-indexerade
  const day = String(d.getDate()).padStart(2, "0");
  return `${year}-${month}-${day}`;
};

// Funktion för att extrahera värden från nested objekt
export const extractValueFromRow = (row, header) => {
  switch (header) {
    case "node":
      return row.node?.nodeName || "";
    case "name":
      return row.visitor?.fullName || "";
    case "startDate":
      return formatDate(row.startDate);
    case "endDate":
      return formatDate(row.endDate);
    default:
      return row[header] || "";
  }
};
