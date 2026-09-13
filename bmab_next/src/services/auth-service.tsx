import { apiClient } from "./api-client";
import { LoginRequest, UserAuthData } from "@/src/types/auth";

export const authService = {
  login: async (payload: LoginRequest): Promise<UserAuthData> => {
    return await apiClient.post<LoginRequest, UserAuthData>("/Auth/Login", payload);
  }
};
