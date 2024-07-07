"use client";
import { useEffect, useState } from "react";
import { Product } from "@/types/models/Product";
import { useRouter } from "next/navigation";
import { api } from "@/services/AuthService";
import { useAuth } from "@/hooks/useAuth";
import { Tabs, TabsContent, TabsList, TabsTrigger } from "@/components/ui/tabs";

const AdminPage = () => {
  const router = useRouter();
  const { user } = useAuth();

  

  if (!user?.roles?.includes("Admin")) {
    return (
      <main className="flex items-center justify-center flex-col">
        <h1 className="text-3xl font-bold text-dark-6">You are not ADMIN</h1>
        <p className="text-xl font-medium text-dark-6">
          You do not have permission to view this page
        </p>
      </main>
    );
  }
  return <div className="">safdfasdfasd</div>;
};

export default AdminPage;
