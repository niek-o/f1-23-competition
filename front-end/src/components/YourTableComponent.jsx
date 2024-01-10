"use client";
import { Table } from "flowbite-react";

const res = await fetch("http://localhost:5058/currentevent/results");

const data = await res.json();

console.log("BLEEE");
console.log(data);

export default function YourTableComponent() {
    return (
        <div className="overflow-x-auto">
            <Table>
                <Table.Head>
                    <Table.HeadCell>Lap time</Table.HeadCell>
                    <Table.HeadCell>First name</Table.HeadCell>
                    <Table.HeadCell>Last name</Table.HeadCell>
                </Table.Head>
                <Table.Body className="divide-y">
                    {data.leaderBoard.map(entry => (
                        <Table.Row key={entry.lap.id} className="bg-white dark:border-gray-700 dark:bg-gray-800">
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
    );
}
