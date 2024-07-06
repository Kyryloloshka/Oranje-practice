import type { Metadata } from "next";

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
  return children;
}
