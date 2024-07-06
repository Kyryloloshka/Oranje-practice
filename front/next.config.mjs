/** @type {import('next').NextConfig} */
const nextConfig = {
  images: {
    remotePatterns: [
      {
        protocol: "https",
        hostname: "static7.depositphotos.com",
        port: "",
        pathname: "/**",
      },
    ],
  },
};

export default nextConfig;
