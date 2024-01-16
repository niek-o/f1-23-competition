import { useState, useEffect, useRef } from "react";
import YourTableComponent from "../components/YourTableComponent.jsx";
import { Button, Label, TextInput } from "flowbite-react";
import * as PropTypes from "prop-types";
import { useNavigate } from "react-router-dom";

export default function ParentComponent() {
    const navigate = useNavigate();

    function handleSubmit(e) {
        // Prevent the browser from reloading the page
        e.preventDefault();

        // Read the form data
        const form = e.target;
        const formData = new FormData(form);

        // Or you can work with it as a plain object:
        const formJson = Object.fromEntries(formData.entries());

        fetchData(formJson);


        navigate("/");
    }

    const fetchData = async (body) => {
        // Assuming you have an endpoint to fetch additional data with pagination
        const res = await fetch(`http://localhost:5058/user`, {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify(body)
        });
        const newData = await res.json();

        fetch(`http://localhost:5058/activeuser/${newData.id}`, { method: "PUT" });
    };

    return (<div className="bg-gray-900 dark w-screen h-screen flex justify-center place-items-center">
            <form className="max-w-sm w-full mx-auto" method="post" onSubmit={handleSubmit}>

                <div className="mb-5">
                    <label htmlFor="email"
                           className="block mb-2 text-sm font-medium text-gray-900 dark:text-white">Voornaam</label>
                    <input type="text" id="voornaam"
                           className="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500"
                           placeholder="Pietje" required
                           name="firstName" />
                </div>

                <div className="mb-5">
                    <label htmlFor="email"
                           className="block mb-2 text-sm font-medium text-gray-900 dark:text-white">Achternaam</label>
                    <input type="text" id="achternaam"
                           className="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500"
                           placeholder="Puk" required
                           name="lastName" />
                </div>

                <div className="mb-5">
                    <label htmlFor="email"
                           className="block mb-2 text-sm font-medium text-gray-900 dark:text-white">Email</label>
                    <input type="email" id="email"
                           className="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500"
                           placeholder="pietjepuk@example.com" required
                           name="email" />
                </div>

                <button type="submit"
                        className="text-white bg-blue-700 hover:bg-blue-800 focus:ring-4 focus:outline-none focus:ring-blue-300 font-medium rounded-lg text-sm w-full sm:w-auto px-5 py-2.5 text-center dark:bg-blue-600 dark:hover:bg-blue-700 dark:focus:ring-blue-800">Submit
                </button>
            </form>
        </div>
    );
}
