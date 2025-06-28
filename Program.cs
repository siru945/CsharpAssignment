using System;

namespace CurrencyConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("===== Currency Converter =====");
            Console.WriteLine("Enter the amount to convert:");
            
            // Get and validate the input amount
            decimal amount;
            while (!decimal.TryParse(Console.ReadLine(), out amount))
            {
                Console.WriteLine("Invalid input. Please enter a numeric value:");
            }

            Console.WriteLine("\nSelect the original currency:");
            Console.WriteLine("1. USD (US Dollar)");
            Console.WriteLine("2. EUR (Euro)");
            Console.WriteLine("3. GBP (British Pound)");
            Console.WriteLine("4. JPY (Japanese Yen)");
            Console.WriteLine("5. CAD (Canadian Dollar)");
            
            int fromCurrencyChoice;
            while (!int.TryParse(Console.ReadLine(), out fromCurrencyChoice) || fromCurrencyChoice < 1 || fromCurrencyChoice > 5)
            {
                Console.WriteLine("Invalid choice. Please enter a number between 1 and 5:");
            }

            string fromCurrency = "";
            decimal usdEquivalent = 0m;
            
            // Set exchange rates (as of common values - for illustration)
            switch (fromCurrencyChoice)
            {
                case 1: // USD
                    fromCurrency = "USD";
                    usdEquivalent = amount;
                    break;
                case 2: // EUR
                    fromCurrency = "EUR";
                    usdEquivalent = amount * 1.08m; // 1 EUR = 1.08 USD
                    break;
                case 3: // GBP
                    fromCurrency = "GBP";
                    usdEquivalent = amount * 1.25m; // 1 GBP = 1.25 USD
                    break;
                case 4: // JPY
                    fromCurrency = "JPY";
                    usdEquivalent = amount * 0.0075m; // 1 JPY = 0.0075 USD
                    break;
                case 5: // CAD
                    fromCurrency = "CAD";
                    usdEquivalent = amount * 0.74m; // 1 CAD = 0.74 USD
                    break;
            }

            Console.WriteLine("\nSelect the target currency:");
            Console.WriteLine("1. USD (US Dollar)");
            Console.WriteLine("2. EUR (Euro)");
            Console.WriteLine("3. GBP (British Pound)");
            Console.WriteLine("4. JPY (Japanese Yen)");
            Console.WriteLine("5. CAD (Canadian Dollar)");
            
            int toCurrencyChoice;
            while (!int.TryParse(Console.ReadLine(), out toCurrencyChoice) || toCurrencyChoice < 1 || toCurrencyChoice > 5)
            {
                Console.WriteLine("Invalid choice. Please enter a number between 1 and 5:");
            }

            string toCurrency = "";
            decimal convertedAmount = 0m;
            
            switch (toCurrencyChoice)
            {
                case 1: // USD
                    toCurrency = "USD";
                    convertedAmount = usdEquivalent;
                    break;
                case 2: // EUR
                    toCurrency = "EUR";
                    convertedAmount = usdEquivalent / 1.08m;
                    break;
                case 3: // GBP
                    toCurrency = "GBP";
                    convertedAmount = usdEquivalent / 1.25m;
                    break;
                case 4: // JPY
                    toCurrency = "JPY";
                    convertedAmount = usdEquivalent / 0.0075m;
                    break;
                case 5: // CAD
                    toCurrency = "CAD";
                    convertedAmount = usdEquivalent / 0.74m;
                    break;
            }

            Console.WriteLine("\nConversion Result:");
            Console.WriteLine($"{amount} {fromCurrency} = {convertedAmount:F2} {toCurrency}");
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}

