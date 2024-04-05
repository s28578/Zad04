using System;

namespace LegacyApp;

public class UserValidation
{
    public static bool CheckIfNamesNull(string firstName, string lastName)
    {
        if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName))
        {
            return true;
        }

        return false;
    }

    public static bool CheckIfEmailCorrect(string email)
    {
        if (!email.Contains("@") && !email.Contains("."))
        {
            return false;
        }

        return true;
    }

    public static bool CheckIfAdult(DateTime dateOfBirth)
    {
        var now = DateTime.Now;
        int age = now.Year - dateOfBirth.Year;
        if (now.Month < dateOfBirth.Month || (now.Month == dateOfBirth.Month && now.Day < dateOfBirth.Day)) age--;

        if (age < 21)
        {
            return false;
        }

        return true;
    }

    public static bool CheckIfEnoughCreditLimit(User user, int limit)
    {
        if (user.HasCreditLimit && user.CreditLimit < limit)
        {
            return false;
        }

        return true;
    }
}