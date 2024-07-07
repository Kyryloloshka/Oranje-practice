import Sidebar from "@/components/admin/Sidebar";
import { Metadata } from "next";
import React from "react";

export const metadata: Metadata = {
  title: "Admin",
  description:
    "Admin page for the Oranje store. Here you can manage products, users, and more.",
};

const Admin = ({
  children,
}: Readonly<{
  children: React.ReactNode;
}>) => {
  return (
    <main className="flex">
      <Sidebar />
      {children}
    </main>
  );
};

export default Admin;
