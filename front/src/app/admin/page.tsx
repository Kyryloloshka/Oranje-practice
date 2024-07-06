"use client";
import { useEffect, useState } from "react";
import { Product } from "@/types/models/Product";
import { useRouter } from "next/navigation";
import { api } from "@/services/AuthService";
import { useAuth } from "@/hooks/useAuth";

const AdminPage = () => {
  const [products, setProducts] = useState<Product[]>([]);
  const [loading, setLoading] = useState(true);
  const router = useRouter();
  const { user } = useAuth();

  useEffect(() => {
    const fetchProducts = async () => {
      try {
        const response = await fetch(`${api}/product`);
        const data = await response.json();
        setProducts(data);
        setLoading(false);
      } catch (error) {
        console.error("Error fetching products:", error);
      }
    };

    fetchProducts();
  }, [user, router]);

  if (!user?.roles?.includes("Admin")) {
    return (
      <main className="flex items-center justify-center flex-col">
        <h1 className="text-3xl font-bold text-dark-6">You are not ADMIN</h1>
        <p className="text-xl font-medium text-dark-6">
          You do not have permission to view this page
        </p>
      </main>
    );
  } else if (loading) {
    return <div>Loading...</div>;
  }
  return (
    <main className="pt-3">
      <div className="admin__container">
        <h1 className="text-3xl font-bold text-dark-6">Admin Panel</h1>
        <ul>
          {products.map((product) => (
            <li key={product.id}>{product.name}</li>
          ))}
        </ul>
      </div>
    </main>
  );
};

export default AdminPage;
