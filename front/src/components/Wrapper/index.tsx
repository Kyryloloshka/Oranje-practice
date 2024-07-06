import { UserProvider } from "@/hooks/useAuth";
import StoreProvider from "@/StoreProvider";
import React from "react";

const Wrapper = ({ children }: { children: React.ReactNode }) => {
  return (
    <UserProvider>
      <StoreProvider>
        <div className="wrapper">{children}</div>
      </StoreProvider>
    </UserProvider>
  );
};

export default Wrapper;
