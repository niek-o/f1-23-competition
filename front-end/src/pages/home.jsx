import { useState, useEffect, useRef } from "react";
import YourTableComponent from "../components/YourTableComponent.jsx";
import { Link } from "react-router-dom";

export default function ParentComponent() {
    const [isLoading, setIsLoading] = useState(false);

    const [eventData, setEventData] = useState([]);
    const [trackData, setTrackData] = useState([]);
    const fetchData = async () => {
        // Assuming you have an endpoint to fetch additional data with pagination
        const res = await fetch(`http://localhost:5058/currentevent/results`);
        const newData = await res.json();

        // Assuming you have an endpoint to fetch additional data with pagination
        const resTrack = await fetch(`http://localhost:5058/track/${newData.event.trackId}`);
        const newTrackData = await resTrack.text();

        console.log(newData.event.eventName);

        setEventData(newData.event.eventName);
        setTrackData(newTrackData);
    };


    useEffect(() => {
        setInterval(() => {
            fetchData();
        }, 10000);
    }, []); // Fetch initial data on component mount

    return (
        <div className="bg-gray-900 dark h-auto">
            <div className="ml-10">
                <button type="button"
                        className="right-6 bottom-6 fixed text-white bg-blue-700 hover:bg-blue-800 focus:ring-4 focus:ring-blue-300 font-medium rounded-lg text-sm px-5 py-2.5 me-2 mb-2 dark:bg-blue-600 dark:hover:bg-blue-700 focus:outline-none dark:focus:ring-blue-800">
                    <Link className={"text-5xl text-white pt-10"} to={"/user"}>ADD USER</Link>
                </button>
                <h1 className="text-5xl text-white pt-10">Haagse Hogeschool Racesim Leaderboard</h1>
                <h1 className="text-5xl text-white pt-10">Current event: {eventData}</h1>
                <h1 className="text-white text-3xl pt-20 pb-10">Current track: {trackData}</h1>

                {isLoading ? (
                    <p>Loading...</p>
                ) : (
                    <YourTableComponent />
                )}
            </div>
        </div>
    );
}
