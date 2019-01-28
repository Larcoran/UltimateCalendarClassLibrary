using MySql.Data.MySqlClient;
using System;

namespace UltimateCalendarClassLibrary
{
    class EventBuilder
    {
        public Event BuildEvent(MySqlDataReader reader)
        {
            return new Event
            {
                Id = (int)reader["eventId"],
                Description = (string)reader["description"],
                UserId = (int)reader["userId"],
                Date = (DateTime)reader["date"],
                Time = (DateTime)reader["time"],
                Type = (string)reader["type"]
            };
        }
    }
}
