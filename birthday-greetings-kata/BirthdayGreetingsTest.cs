using Moq;
using NUnit.Framework;

namespace birthday_greetings_kata
{
    [TestFixture]
    public class BirthdayGreetingsTest
    {
        // last_name, first_name, date_of_birth, email
        //     Doe, John, 1982/05/16, john.doe@foobar.com
        // Ann, Mary, 1975/09/11, mary.ann@foobar.com
        // Subject: Happy birthday!

        [Test]
        public void ShouldGenerateBirthdayGreetingWithFirstName()
        {
            //Arrange
            var dateTimeStub = when(IDateTime.now()).ThenReturn(1982/05/16);
            var messageSenderMock= when(IMesssageSender);
            var filteredFriendsProviderStub = when(IFriendsFinder.birthdablePeople(any)).ThenReturn("John");
            var birthdayGreetingsGenerator = BirthdayGreetingsGenerator(dateTimeStub, messageSenderMock, filteredFriendsProviderStub);

            // Act
            birthdayGreetingsGenerator.sendMessages();
            
            // Assert
            (IMessageSender.send).hasBeenCalledOnce()
                .With("subject: happy birthday", "body: Happy birthday, dear John");
        }
    }
}