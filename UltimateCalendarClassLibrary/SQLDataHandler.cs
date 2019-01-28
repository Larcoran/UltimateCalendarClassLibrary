using System;
using System.Collections.Generic;

namespace UltimateCalendarClassLibrary
{
    public class SQLDataHandler : IDataHandler
    {
        PasswordEncrypter encrypter = new PasswordEncrypter();
        PasswordDecrypter decrypter = new PasswordDecrypter();
        string connectionString;

        public SQLDataHandler(string connectionString)
        {
            this.connectionString = connectionString;
            
        }

        public void AddEvent(Event @event)
        {
            AddNewEventToDB addNewEvent = new AddNewEventToDB(connectionString);
            addNewEvent.Add(@event);
        }

        public bool CredentialsCheck(string email, string password, out User loggedInUser)
        {
            GetUserFromDB getUser = new GetUserFromDB(connectionString);
            loggedInUser = getUser.GetUser(encrypter.encryptPassword(password), email);
            if(email!=loggedInUser.Email)
            {
                return false;
            }
            if(encrypter.encryptPassword(password)!=loggedInUser.Password)
            {
                return false;
            }
            return true;
        }

        public List<Event> GetEvents(DateTime dateForEvents, User userForEvents)
        {
            GetEventsFromDB getEvents = new GetEventsFromDB(connectionString);
            return getEvents.Get(dateForEvents, userForEvents.UserID);
        }

        public string RegisterUser(User user)
        {
            RegisterUserInDb register = new RegisterUserInDb();
            return register.RegisterUserInDB(user.Name, user.Surname, user.DateOfBirth, user.Email, encrypter.encryptPassword(user.Password),connectionString);
        }
    }
}
