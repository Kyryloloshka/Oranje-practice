"use client";
import React from "react";
import { Button } from "../ui/button";
import { useAuth } from "@/hooks/useAuth";
import { usePathname, useRouter } from "next/navigation";
import { noHeaderPaths } from "@/lib/utils/consts";

const Header = () => {
  const { logout, isLoggedIn } = useAuth();
  const router = useRouter();
  const pathname = usePathname();
  const handleLogout = () => {
    logout();
    router.push("/login");
  };
  const handleLogin = () => {
    router.push("/login");
  };
  return (
    !noHeaderPaths.includes(pathname) && (
      <header className="bg-gray-100">
        <div className="header__container flex justify-between items-center min-h-[60px] gap-12">
          <div className="font-bold text-xl text-primary">Oranje</div>
          <ul className="flex gap-12">
            <li>Home</li>
            <li>Products</li>
            <li>About</li>
            <li>Contact</li>
          </ul>
          {isLoggedIn() ? (
            <Button onClick={handleLogout}>Log out</Button>
          ) : (
            <>
              <Button onClick={handleLogin}>Log in</Button>
            </>
          )}
        </div>
      </header>
    )
  );
};

export default Header;
