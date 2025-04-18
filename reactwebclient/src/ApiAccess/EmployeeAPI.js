import axios from "axios";

const api = axios.create({
    baseURL: "https://localhost:7244/api/Employee"
});

export const getEmployees = async () => {
    try {
        const response = await api.get("/");
        return response.data;

    } catch (e) {
        console.log("Error getting Employees", e);
        return [];
    }
}

export const getEmployee = async (id) => {
    try {
        console.log(id+" API ID VALUE");
        const response = await api.get(`/${id}`);
        return response.data;

    } catch (e) {
        console.log("Error getting Employee", e);
        return null;
    }
}
export const UpdateEmployeeTrainingDocument = async (id, filter) => {
    try {
        const response = await api.put(`/updateETD/${id}`, filter);
        return response.status === 200
    } catch (e) {
        console.log("Error", e);
        return null;
    }
}

export default {
    getEmployees,
    getEmployee,
    UpdateEmployeeTrainingDocument
}