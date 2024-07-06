"use client";
import ProductCard from "@/components/ProductCard";
import useProducts from "@/hooks/useProducts";
import { useState } from "react";

export default function Home() {
  const [searchQuery, setSearchQuery] = useState("");
  const [selectedCategory, setSelectedCategory] =
    useState<string>("All categories");
  const [currentPage, setCurrentPage] = useState(1);
  const { products, totalPages } = useProducts(
    selectedCategory,
    searchQuery,
    currentPage
  );
  return (
    <main className="pt-6">
      <div className="home-page__container">
        <div className="home-page__hero">
          <div className="home-page__hero__text">
            <h1 className="text-4xl">Welcome to Oranje</h1>
            <p className="text-xl">The best store in the world</p>
          </div>
        </div>
        <div className="home-page__products">
          <div className="home-page__products__title">
            <h2 className="text-2xl">All products</h2>
          </div>
          <div className="product-list">
            {products?.map((product) => (
              <ProductCard key={product.id} product={product} />
            ))}
          </div>
        </div>
      </div>
    </main>
  );
}
