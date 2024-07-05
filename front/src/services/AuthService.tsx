import { handleError } from "@/lib/helpers/ErrorHandler";
import { UserProfileToken } from "@/types/models/User";
import axios from "axios";

const api = "http://localhost:5286/api";

export const loginAPI = async (email: string, password: string) => {
  try {
    const data = await axios.post<UserProfileToken>(`${api}/user/login`, {
      email: email,
      password: password,
    });
    return data;
  } catch (error) {
    handleError(error);
  }
};

export const registerAPI = async (email: string, username: string, password: string) => {
  try {
    const data = await axios.post<UserProfileToken>(`${api}/user/register`, {
      email: email,
      username: username,
      password: password,
    });
    return data;
  } catch (error) {
    handleError(error);
  }
};
