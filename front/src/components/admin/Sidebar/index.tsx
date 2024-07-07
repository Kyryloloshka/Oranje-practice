import Link from "next/link";
import React from "react";

const links = [
  { title: "Dashboard", href: "/admin" },
  { title: "Products", href: "/admin/products" },
  { title: "Users", href: "/admin/users" },
];

const Sidebar = () => {
  return (
    <aside className="bg-light-2 w-64 h-screen top-0 left-0">
      <h1 className="p-4 pt-8 text-xl font-bold text-dark-6">Admin Panel</h1>
      <nav className="p-2">
        <ul className="flex flex-col gap-3">
          {links.map((link) => (
            <li key={link.href} className="flex">
              <Link
                className="w-full bg-light-4 hover:bg-light-6 transition p-2 rounded-[8px] flex-auto"
                href={link.href}
              >
                {link.title}
              </Link>
            </li>
          ))}
        </ul>
      </nav>
    </aside>
  );
};

export default Sidebar;
