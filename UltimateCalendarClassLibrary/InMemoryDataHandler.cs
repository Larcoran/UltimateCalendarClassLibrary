using System;
using System.Collections.Generic;

namespace UltimateCalendarClassLibrary
{
    public class InMemoryDataHandler : IDataHandler
    {
        List<Event> events = new List<Event>();

        public InMemoryDataHandler()
        {
            //WebClient wc = new WebClient();
            //string message = wc.DownloadString("http://localhost:51821/api/values");

            //wc.UploadString()
            //MessageBox.Show(message);
            
        }

        public void AddEvent(Event @event)
        {
            events.Add(@event);
        }

        public bool CredentialsCheck(string email, string password, out User loggedInUser)
        {
            loggedInUser = new User(7,"a","b",DateTime.Now,"a","a");
            return true;
        }

        public List<Event> GetEvents(DateTime dateForEvents, User userForEvents)
        {
            return events;
        }

        public string RegisterUser(User user)
        {
            return "test";
        }
    }
}
