using System.CodeDom;

namespace birthday_greetings_kata
{
    public class BirthdayGreetingsGenerator
    {
        private IDateTimeProvider _dateTimeProvider;
        private IMessageSender _messageSender;
        private IFinder _filteredFriendsFinder;

        public BirthdayGreetingsGenerator(IDateTimeProvider dateTime, IMessageSender messageSender,
            IFinder filteredFriendsFinder)
        {
            _dateTimeProvider = dateTime;
            _messageSender = messageSender;
            _filteredFriendsFinder = filteredFriendsFinder;
        }
        
        public void SendMessages() => 
            throw new System.NotImplementedException();
    }
}