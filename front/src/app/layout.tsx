import type { Metadata } from "next";
import { Roboto } from "next/font/google";
import "./globals.scss";
import "react-toastify/dist/ReactToastify.css";
import { ToastContainer } from "react-toastify";
import Wrapper from "@/components/Wrapper";
import Header from "@/components/Header";
import StoreProvider from "@/StoreProvider";

const roboto = Roboto({ subsets: ["latin"], weight: ["400", "500"] });

export const metadata: Metadata = {
  title: "Oranje",
  description:
    "Oranje is a internet store, where you can buy anything you want. We have a lot of products, from electronics to clothes. We have the best prices and the best quality. Come and check it out!",
};

export default function RootLayout({
  children,
}: Readonly<{
  children: React.ReactNode;
}>) {
  return (
    <html lang="en">
      <body className={roboto.className}>
          <Wrapper>
            <Header />
            {children}
          </Wrapper>
          <ToastContainer />
      </body>
    </html>
  );
}
