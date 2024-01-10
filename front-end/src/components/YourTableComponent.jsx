// YourTableComponent.jsx
import { Table } from 'flowbite-react';

export default function YourTableComponent() {
  const leaderboardData = {
    "event": {
      "id": 4,
      "eventName": "TestGP",
      "trackId": 28,
      "startDate": "2024-01-08T13:20:03.883",
      "endDate": "2024-01-11T13:20:03.883"
    },
    "leaderBoard": [
      {
        "user": {
          "id": 3,
          "firstName": "Niek",
          "lastName": "Otten",
          "email": "blabla"
        },
        "lap": {
          "id": 26,
          "userId": 3,
          "lapTime": "1:11.068",
          "lapTimeInMS": 71068,
          "timeSet": "2024-01-09T15:00:29.14418",
          "trackId": 28,
          "eventId": 4
        }
      },
      // ... (other leaderboard entries)
    ]
  };

  return (
    <div className="overflow-x-auto">
      <Table>
        <Table.Head>
          <Table.HeadCell>Lap time</Table.HeadCell>
          <Table.HeadCell>First name</Table.HeadCell>
          <Table.HeadCell>Last name</Table.HeadCell>
          <Table.HeadCell>
            <span className="sr-only">Edit</span>
          </Table.HeadCell>
        </Table.Head>
        <Table.Body className="divide-y">
          {leaderboardData.leaderBoard.map(entry => (
            <Table.Row key={entry.lap.id} className="bg-white dark:border-gray-700 dark:bg-gray-800">
              <Table.Cell className="whitespace-nowrap font-medium text-gray-900 dark:text-white">
                {entry.lap.lapTime}
              </Table.Cell>
              <Table.Cell>{entry.user.firstName}</Table.Cell>
              <Table.Cell>{entry.user.lastName}</Table.Cell>
              <Table.Cell>
                {/* Add any additional content for the "Edit" column if needed */}
              </Table.Cell>
            </Table.Row>
          ))}
        </Table.Body>
      </Table>
    </div>
  );
}
