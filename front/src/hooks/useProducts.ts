"use client";
import { useState, useEffect } from "react";
import axios from "axios";
import { ITEMS_PER_PAGE } from "@/lib/utils/consts";
import { Product } from "@/types/models/Product";
import { api } from "@/services/AuthService";

const useProducts = (
  selectedCategory: string,
  searchQuery: string,
  currentPage: number
) => {
  const [products, setProducts] = useState<Product[]>([]);
  const [totalPages, setTotalPages] = useState(0);

  useEffect(() => {
    const fetchProducts = async () => {
      try {
        const response = await axios.get(`${api}/product`);
        setProducts(response.data);
        setTotalPages(1);
      } catch (error) {
        console.error("Error fetching products:", error);
      }
    };

    fetchProducts();
  }, [currentPage, searchQuery, selectedCategory]);

  return { products, totalPages } as const;
};

export default useProducts;
