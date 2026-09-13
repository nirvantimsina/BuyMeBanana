"use client";

import React, { useState } from "react";
import Link from "next/link";
import { Eye, EyeOff, Loader2, AlertCircle } from "lucide-react";
import { useAuth } from "@/src/hooks/use-auth";

export default function LoginPage() {
  // Input Bindings
  const [userName, setUserName] = useState("");
  const [password, setPassword] = useState("");
  
  // UI Presentation State
  const [isPasswordVisible, setIsPasswordVisible] = useState(false);

  // Consume our architecture's specialized hook
  const { login, isLoading, error } = useAuth();

  const handleLogin = async (e: React.SubmitEvent) => {
    e.preventDefault();
    login({ userName, password });
  };

  return (
    <div className="flex justify-center items-center min-h-screen bg-neutral-50 px-4 select-none">
      <div className="w-full max-w-[400px] bg-white p-8 rounded-3xl shadow-xl shadow-neutral-200/50 border border-neutral-100">
        
        {/* Branding Token Area */}
        <div className="text-center mb-8">
          <div className="inline-flex items-center justify-center w-14 h-14 bg-amber-100 text-amber-600 rounded-2xl font-black text-2xl mb-3 shadow-inner">
            ☕
          </div>
          <h1 className="text-2xl font-bold text-neutral-900 tracking-tight">Welcome Back</h1>
          <p className="text-sm text-neutral-500 mt-1">Log in to manage your creator dashboard</p>
        </div>

        {/* Dynamic Contextual Error Block */}
        {error && (
          <div className="mb-6 p-4 text-sm text-amber-900 bg-amber-50/70 rounded-2xl border border-amber-200 flex items-start gap-3 animate-in fade-in slide-in-from-top-1 duration-200" role="alert">
            <AlertCircle className="shrink-0 text-amber-600 mt-0.5" size={18} />
            <span className="font-medium">{error}</span>
          </div>
        )}

        <form onSubmit={handleLogin} className="space-y-5">
          {/* Username Block */}
          <div>
            <label className="block text-xs font-semibold text-neutral-600 uppercase tracking-wider mb-2">
              Username or Email
            </label>
            <input
              type="text"
              required
              value={userName}
              onChange={(e) => setUserName(e.target.value)}
              className="w-full px-4 py-3 rounded-2xl bg-neutral-50 border border-neutral-200 text-neutral-900 placeholder-neutral-400 focus:bg-white focus:border-amber-500 focus:ring-4 focus:ring-amber-500/10 focus:outline-none transition-all duration-200 text-sm"
              placeholder="Enter your username"
            />
          </div>

          {/* Password Block */}
          <div>
            <label className="block text-xs font-semibold text-neutral-600 uppercase tracking-wider mb-2">
              Password
            </label>
            <div className="relative">
              <input
                type={isPasswordVisible ? "text" : "password"}
                required
                value={password}
                onChange={(e) => setPassword(e.target.value)}
                className="w-full px-4 py-3 rounded-2xl bg-neutral-50 border border-neutral-200 text-neutral-900 focus:bg-white focus:border-amber-500 focus:ring-4 focus:ring-amber-500/10 focus:outline-none transition-all duration-200 text-sm pr-12"
                placeholder="••••••••"
              />
              <button
                type="button"
                onClick={() => setIsPasswordVisible(!isPasswordVisible)}
                className="absolute inset-y-0 right-0 pr-4 flex items-center text-neutral-400 hover:text-neutral-600 focus:outline-none transition-colors"
                aria-label={isPasswordVisible ? "Hide password" : "Show password"}
              >
                {isPasswordVisible ? <EyeOff size={18} /> : <Eye size={18} />}
              </button>
            </div>
          </div>

          {/* Action Trigger Button */}
          <button
            type="submit"
            disabled={isLoading}
            className="w-full mt-2 bg-amber-500 hover:bg-amber-600 text-white font-bold py-3.5 px-4 rounded-full shadow-lg shadow-amber-500/20 active:scale-[0.98] focus:ring-4 focus:ring-amber-500/20 transition-all duration-200 flex items-center justify-center disabled:bg-neutral-100 disabled:text-neutral-400 disabled:shadow-none disabled:scale-100 disabled:cursor-not-allowed text-sm tracking-wide"
          >
            {isLoading ? (
              <>
                <Loader2 className="animate-spin mr-2" size={18} />
                Verifying Credentials...
              </>
            ) : (
              "Continue to Dashboard"
            )}
          </button>

          {/* Alternate Redirection Route Link */}
          <p className="text-center text-sm text-neutral-500 pt-3">
            New to the platform?{" "}
            <Link href="/signup" className="text-amber-600 font-semibold hover:text-amber-700 hover:underline transition-colors">
              Create an account
            </Link>
          </p>
        </form>
      </div>
    </div>
  );
}
