import { useState, useEffect } from 'react';
import YourTableComponent from './components/YourTableComponent';

export default function ParentComponent() {
  const [isLoading, setIsLoading] = useState(false);

  // Assuming NewData is the data you want to pass to YourTableComponent
  const NewData = {
    event: {
      id: 4,
      eventName: 'TestGP',
      trackId: 'Zandvoort',
      startDate: '2024-01-08T13:20:03.883',
      endDate: '2024-01-11T13:20:03.883',
    },
    leaderBoard: [
      {
        user: {
          id: 3,
          firstName: 'Niek',
          lastName: 'Otten',
          email: 'blabla',
        },
        lap: {
          id: 26,
          userId: 3,
          lapTime: '1:11.069',
          lapTimeInMS: 71068,
          timeSet: '2024-01-09T15:00:29.14418',
          trackId: 28,
          eventId: 4,
        },
      },
      
      // Add more leaderboard entries as needed
    ],
  };

  useEffect(() => {
    // Simulate loading delay for demonstration
    const timeout = setTimeout(() => {
      setIsLoading(false);
    }, 2000);

    return () => clearTimeout(timeout);
  }, []);

  return (
    <div className="bg-gray-900 dark h-auto">
      <div className="ml-10">
        <h1 className='text-5xl text-white pt-10'>Haagse Hogeschool Racesim Leaderboard</h1>
        <h1 className="text-white text-3xl pt-20 pb-10">Current track {NewData.event.trackId}</h1>

        {isLoading ? (
          <p>Loading...</p>
        ) : (
          <YourTableComponent data={NewData} />
        )}
      </div>
    </div>
  );
}
