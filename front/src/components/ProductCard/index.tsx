import Image from "next/image";
import React from "react";
import "./styles.scss";
import Link from "next/link";
import { Button } from "../ui/button";
import { Product } from "@/types/models/Product";
import Rating from "../Rating";
import { ShoppingBasketIcon } from "lucide-react";

const ProductCard = ({ product }: { product: Product }) => {
  return (
    <div
      data-testid="product-card"
      className="hover:scale-[1.02] border-card rounded-xl hover:bg-light-1 transition p-5 flex flex-col relative duration-300 ease-in-out group hover:shadow-3xl"
    >
      <Link
        className="flex aspect-square border-none outline-none ring-none scale-100 overflow-hidden items-center justify-center group-hover:scale-105 pb-2 transition-transform duration-300 ease-in-out cursor-pointer relative"
        href={`/product/${product.id}`}
      >
        <Image
          className="border-none outline-none ring-none"
          style={{ objectFit: "contain" }}
          fill
          sizes="300px"
          src={
            "https://static7.depositphotos.com/1002351/792/i/450/depositphotos_7926477-stock-photo-new-potato.jpg"
          }
          alt={product.name}
          priority={true}
        />
      </Link>
      <Link href={`/product/${product.id}`}>
        <h3 className="text-xl tracking-wider">{product.name}</h3>
      </Link>
      <div className="mb-1">
        <Rating rating={4.5} />
      </div>
      <p className="absolute text-right top-0 right-0 max-w-full m-2 bg-light-2 bg-opacity-65 rounded-md px-3 py-1 text-sm font-semibold text-dark-6 ">
        Category
      </p>
      {/* <p className="pb-3 flex-auto">
        {product.brand && <>Brand: {product.brand}</>}
      </p> */}
      <div className="flex justify-between items-end">
        {/* {product.discountPercentage > 0 ? (
          <div>
            <p className="font-bold tracking-wider crossed-out leading-[1.05em]">
              ${product.price}
            </p>
            <p className="font-bold tracking-wider text-lg leading-[1.05em]">
              ${countDiscountedPrice(product.price, product.discountPercentage)}
            </p>
          </div>
        ) : ( */}
        <p className="font-bold tracking-wider text-lg leading-[1.05em]">
          ${product.price}
        </p>
        {/* )} */}
        <Button className="text-light-4 text-2xl bg-primary-500 hover:bg-primary-600 hover:text-light-2 hover:shadow-xl transition duration-300 rounded-[5px]">
          <ShoppingBasketIcon className="w-6 h-6" />
        </Button>
      </div>
    </div>
  );
};

export default ProductCard;
