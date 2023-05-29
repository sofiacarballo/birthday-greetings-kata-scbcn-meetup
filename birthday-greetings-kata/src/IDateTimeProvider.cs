using System;

namespace birthday_greetings_kata
{
    public interface IDateTimeProvider
    {
        DateTime Now();
    }
}