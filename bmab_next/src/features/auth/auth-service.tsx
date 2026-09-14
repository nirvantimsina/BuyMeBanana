import { apiClient } from "../../services/api-client";
import { LoginRequest, UserAuthData } from "@/src/features/auth/auth-models";

export const authService = {
  login: async (payload: LoginRequest): Promise<UserAuthData> => {
    return await apiClient.post<LoginRequest, UserAuthData>("/Auth/Login", payload);
  }
};