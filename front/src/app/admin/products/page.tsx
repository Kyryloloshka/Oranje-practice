"use client";
import ProductCard from "@/components/ProductCard";
import { useAuth } from "@/hooks/useAuth";
import { api } from "@/services/AuthService";
import { Product } from "@/types/models/Product";
import { useRouter } from "next/navigation";
import React, { useEffect, useState } from "react";

const Products = () => {
  const [products, setProducts] = useState<Product[]>([]);
  const [loading, setLoading] = useState(true);
  const { user } = useAuth();
  const router = useRouter();

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
  if (loading) {
    return <div>Loading...</div>;
  }
  return (
    <div className="px-8 py-4 w-full">
      <h2 className="text-2xl font-semibold text-dark-5">All products</h2>
      <div className="product-list">
        {products?.map((product) => (
          <ProductCard key={product.id} product={product} />
        ))}
      </div>
    </div>
  );
};

export default Products;
