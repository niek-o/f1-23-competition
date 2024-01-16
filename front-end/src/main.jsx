import React from "react";
import ReactDOM from "react-dom/client";
import Home from "./pages/home.jsx";
import User from "./pages/user.jsx";
import "./index.css";
import { createBrowserRouter, Link, RouterProvider } from "react-router-dom";

const router = createBrowserRouter([
    {
        path: "/",
        element: <Home />
    },
    {
        path: "/user",
        element: <User />
    }
]);


ReactDOM.createRoot(document.getElementById("root")).render(
    <React.StrictMode>
        <RouterProvider router={router} />
    </React.StrictMode>
);
