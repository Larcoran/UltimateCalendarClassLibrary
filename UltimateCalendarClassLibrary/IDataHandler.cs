using System;
using System.Collections.Generic;

namespace UltimateCalendarClassLibrary
{
    public interface IDataHandler
    {
        List<Event> GetEvents(DateTime dateForEvents, User userForEvents);

        void AddEvent(Event @event);

        string RegisterUser(User user);

        bool CredentialsCheck(string email, string password,out User loggedInUser);
    }
}
