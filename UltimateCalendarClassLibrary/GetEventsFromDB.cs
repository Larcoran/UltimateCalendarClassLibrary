﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace UltimateCalendarClassLibrary
{
    class GetEventsFromDB : DBQuery
    {
        public GetEventsFromDB(string connectionString):base(connectionString)
        {

        }

        MySqlDataReader reader = null;
        EventBuilder builder = new EventBuilder();
        int userId;
        DateTime date;

        List<Event> eventsToReturn = new List<Event>();

        public List<Event> Get(DateTime date,int userId)
        {
            eventsToReturn.Clear();
            this.date = date;
            this.userId = userId;
            Execute();
            return eventsToReturn;
        }

        public override void ExecuteCommand()
        {
            command.CommandText = "SELECT * FROM events WHERE date = @date AND userId = @userId ;";
            command.Parameters.AddWithValue("@date", date);
            command.Parameters.AddWithValue("@userId", userId);
            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while(reader.Read())
                {
                    eventsToReturn.Add(builder.BuildEvent(reader));
                }
            }
        }
    }
}
