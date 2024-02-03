import { useState, useEffect, useRef } from "react";
import { Table } from "flowbite-react";
import PropTypes from "prop-types";

const YourTableComponent = ({ data }) => {
    const [tableData, setTableData] = useState([]);
    const [containerHeight, setContainerHeight] = useState(0);
    const [pageNumber, setPageNumber] = useState(1);
    const containerRef = useRef();

    const fetchData = async () => {
        // Assuming you have an endpoint to fetch additional data with pagination
        const res = await fetch(`http://localhost:5058/currentevent/results`);
        const newData = await res.json();

        if (newData.leaderBoard.length > 0) {
            setTableData(newData.leaderBoard)
        }
    };

    const calculateContainerHeight = () => {
        const windowHeight = window.innerHeight;
        const headerHeight = 64; // Adjust this value based on your header height
        const containerHeight = windowHeight - headerHeight;
        setContainerHeight(containerHeight);
    };

    const handleScroll = () => {
        const container = containerRef.current;
        if (container.scrollTop + container.clientHeight >= container.scrollHeight) {
            fetchData();
        }
    };

    useEffect(() => {
        calculateContainerHeight();
        window.addEventListener("resize", calculateContainerHeight);

        return () => {
            window.removeEventListener("resize", calculateContainerHeight);
        };
    }, []);

    useEffect(() => {
        fetchData();

        setInterval(() => {
            fetchData();
        }, 10000);
    }, []); // Fetch initial data on component mount

    return (
        <div
            ref={containerRef}
            onScroll={handleScroll}
            className="overflow-x-auto h-screen"
            style={{ overflowY: "auto" }}
        >
            <div
                className="table-container"
                style={{
                    width: "80%",
                    paddingLeft: "10px",
                    paddingRight: "10px",
                    maxHeight: containerHeight
                }}
            >
                <Table>
                    <Table.Head>
                        <Table.HeadCell className="text-xl">Position</Table.HeadCell>
                        <Table.HeadCell className="text-xl">Lap time</Table.HeadCell>
                        <Table.HeadCell className="text-xl">First name</Table.HeadCell>
                        <Table.HeadCell className="text-xl">Last name</Table.HeadCell>
                    </Table.Head>
                    <Table.Body className="divide-y">
                        {tableData.map((entry, i) => (
                            <Table.Row
                                key={entry.lap.id}
                                className="bg-white dark:border-gray-700 dark:bg-gray-800"
                            >
                                <Table.Cell className="whitespace-nowrap font-medium text-gray-900 dark:text-white">
                                    {i+1}
                                </Table.Cell>
                                <Table.Cell className="whitespace-nowrap font-medium text-gray-900 dark:text-white">
                                    {entry.lap.lapTime}
                                </Table.Cell>
                                <Table.Cell className={"capitalize"}>{entry.user.firstName}</Table.Cell>
                                <Table.Cell className={"capitalize"}>{entry.user.lastName}</Table.Cell>
                            </Table.Row>
                        ))}
                    </Table.Body>
                </Table>
            </div>
        </div>
    );
};

YourTableComponent.propTypes = {
    data: PropTypes.object
};

export default YourTableComponent;
