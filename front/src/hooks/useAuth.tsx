"use client";
import { createContext, useEffect, useState, ReactNode } from "react";
import { toast } from "react-toastify";
import React from "react";
import axios from "axios";
import { useRouter } from "next/navigation";
import { loginAPI, registerAPI } from "@/services/AuthService";
import { UserProfile } from "@/types/models/User";

type UserContextType = {
  user: UserProfile | null;
  token: string | null;
  registerUser: (email: string, username: string, password: string) => void;
  loginUser: (username: string, password: string) => void;
  logout: () => void;
  isLoggedIn: () => boolean;
};

type Props = { children: ReactNode };

const UserContext = createContext<UserContextType>({} as UserContextType);

export const UserProvider = ({ children }: Props) => {
  const router = useRouter();
  const [token, setToken] = useState<string | null>(null);
  const [user, setUser] = useState<UserProfile | null>(null);
  const [isReady, setIsReady] = useState(false);

  useEffect(() => {
    const user = localStorage.getItem("user");
    const token = localStorage.getItem("token");
    if (user && token) {
      setUser(JSON.parse(user));
      setToken(token);
      axios.defaults.headers.common["Authorization"] = "Bearer " + token;
    }
    setIsReady(true);
  }, []);

  const registerUser = async (
    email: string,
    username: string,
    password: string
  ) => {
    await registerAPI(email, username, password)
      .then((res) => {
        if (res) {
          localStorage.setItem("token", res?.data.token);
          console.log(res?.data);
          const userObj = {
            username: res?.data.userName,
            email: res?.data.email,
            roles: res?.data.roles,
          };
          localStorage.setItem("user", JSON.stringify(userObj));
          setToken(res?.data.token);
          setUser(userObj);
          toast.success("Login Success!");
          router.push("/");
        }
      })
      .catch((e) => toast.warning("Server error occurred"));
  };

  const loginUser = async (username: string, password: string) => {
    await loginAPI(username, password)
      .then((res) => {
        if (res) {
          localStorage.setItem("token", res?.data.token);
          const userObj = {
            username: res?.data.userName,
            email: res?.data.email,
            roles: res?.data.roles,
          };
          console.log(userObj);
          localStorage.setItem("user", JSON.stringify(userObj));
          setToken(res?.data.token);
          setUser(userObj);
          toast.success("Login Success!");
          router.push("/");
        }
      })
      .catch((e) => toast.warning("Server error occurred"));
  };

  const isLoggedIn = () => {
    return !!user;
  };

  const logout = () => {
    localStorage.removeItem("token");
    localStorage.removeItem("user");
    setUser(null);
    setToken("");
    router.push("/");
  };

  return (
    <UserContext.Provider
      value={{ loginUser, user, token, logout, isLoggedIn, registerUser }}
    >
      {isReady ? children : null}
    </UserContext.Provider>
  );
};

export const useAuth = () => React.useContext(UserContext);
