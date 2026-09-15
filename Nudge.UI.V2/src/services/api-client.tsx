import { ApiResponse } from "@/src/features/auth/auth-models";

const API_BASE_URL = "http://localhost:5043/api";

// Custom error class to carry the server status code cleanly
export class ApiServerError extends Error {
  statusCode: string;
  
  constructor(statusCode: string, serverMessage: string) {
    super(serverMessage);
    this.name = "ApiServerError";
    this.statusCode = statusCode;
  }
}

export const apiClient = {
  async post<TRequest, TResponse>(endpoint: string, payload: TRequest): Promise<TResponse> {
    const headers: Record<string, string> = { "Content-Type": "application/json" };
    
    const token = typeof window !== "undefined" ? localStorage.getItem("token") : null;
    if (token) headers["Authorization"] = `Bearer ${token}`;

    const response = await fetch(`${API_BASE_URL}${endpoint}`, {
      method: "POST",
      headers,
      body: JSON.stringify(payload),
    });

    if (!response.ok) {
      throw new Error(`HTTP Error: ${response.status}`);
    }

    const envelope: ApiResponse<TResponse> = await response.json();
    
    // 🛑 CRITICAL CHANGE: If status is not "0", it's an error!
    if (envelope.status !== "0") {
      throw new ApiServerError(envelope.status, envelope.msg);
    }

    return envelope.data;
  }
};
