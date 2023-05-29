using System;
using System.Configuration;
using Moq;
using NUnit.Framework;

namespace birthday_greetings_kata.tests
{
    [TestFixture]
    public class BirthdayGreetingsTest
    {
        // last_name, first_name, date_of_birth, email
        // Doe, John, 1982/05/16, john.doe@foobar.com
        // Ann, Mary, 1975/09/11, mary.ann@foobar.com
        // Subject: Happy birthday!
        [Test]
        public void ShouldGenerateBirthdayGreetingWithFirstName()
        {
            //Arrange
            var dateTimeStub = new Mock<IDateTimeProvider>();
            var filteredFriendsProviderStub = new Mock<IFinder>();
            var messageSenderMock = new Mock<IMessageSender>();
            
            dateTimeStub
                .Setup(x => x.Now())
                .Returns(new DateTime(1982 ,05 ,16));

            filteredFriendsProviderStub
                .Setup(x => x.FindFriendsWithBirthday(It.IsAny<DateTime>()))
                .Returns("John");
            
            var birthdayGreetingsGenerator = new BirthdayGreetingsGenerator(dateTimeStub.Object, messageSenderMock.Object, filteredFriendsProviderStub.Object);

            // Act
            birthdayGreetingsGenerator.SendMessages();
            
            // Assert
            messageSenderMock.Verify(x => x.Send(
                It.Is<string>(subject => subject == "happy birthday"),
                It.Is<string>(body => body == "Happy birthday, dear John")), 
                Times.Once);
        }
    }
}