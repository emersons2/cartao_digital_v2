using System;
using System.Linq;

public class CreditCardGenerator
{
    private static Random random = new Random();

    public static string GenerateCVV()
    {
        return random.Next(100, 1000).ToString();
    }

    public static string GenerateCardNumber(string prefix, int length)
    {
        string cardNumber = prefix;

        while (cardNumber.Length < length - 1)
        {
            cardNumber += random.Next(0, 10).ToString();
        }

        cardNumber += CalculateLuhnChecksum(cardNumber);

        return cardNumber;
    }

    private static int CalculateLuhnChecksum(string cardNumber)
    {
        int sum = 0;
        bool alternate = true;

        for (int i = cardNumber.Length - 1; i >= 0; i--)
        {
            int digit = int.Parse(cardNumber[i].ToString());

            if (alternate)
            {
                digit *= 2;
                if (digit > 9)
                {
                    digit -= 9;
                }
            }

            sum += digit;
            alternate = !alternate;
        }

        int checksum = (10 - (sum % 10)) % 10;
        return checksum;
    }
}