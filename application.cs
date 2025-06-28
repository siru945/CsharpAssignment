using System;

namespace PreferencesConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("===== User Preferences Converter =====");
            
            // Dark Mode Preference (bool)
            bool darkMode = GetBoolPreference("Enable Dark Mode (true/false)");
            
            // Font Size (int)
            int fontSize = GetIntPreference("Enter preferred font size (8-72)", 8, 72);
            
            // Notification Volume (double)
            double notificationVolume = GetDoublePreference("Enter notification volume (0.0-1.0)", 0.0, 1.0);
            
            // Auto-Save Interval (TimeSpan)
            TimeSpan autoSaveInterval = GetTimeSpanPreference("Enter auto-save interval (hh:mm:ss)");
            
            // Theme Color (ConsoleColor enum)
            ConsoleColor themeColor = GetEnumPreference<ConsoleColor>("Choose theme color (type a color name from list below)");
            
            // Display all collected preferences
            Console.WriteLine("\n===== Your Preferences =====");
            Console.WriteLine($"Dark Mode: {darkMode}");
            Console.WriteLine($"Font Size: {fontSize}pt");
            Console.WriteLine($"Notification Volume: {notificationVolume:P0}");
            Console.WriteLine($"Auto-Save Interval: {autoSaveInterval}");
            Console.WriteLine($"Theme Color: {themeColor}");
            
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }

        static bool GetBoolPreference(string prompt)
        {
            Console.WriteLine($"{prompt}:");
            while (true)
            {
                string input = Console.ReadLine();
                if (bool.TryParse(input, out bool result))
                {
                    return result;
                }
                Console.WriteLine("Invalid input. Please enter 'true' or 'false':");
            }
        }

        static int GetIntPreference(string prompt, int minValue, int maxValue)
        {
            Console.WriteLine($"{prompt}:");
            while (true)
            {
                string input = Console.ReadLine();
                if (int.TryParse(input, out int result) && result >= minValue && result <= maxValue)
                {
                    return result;
                }
                Console.WriteLine($"Invalid input. Please enter a number between {minValue} and {maxValue}:");
            }
        }

        static double GetDoublePreference(string prompt, double minValue, double maxValue)
        {
            Console.WriteLine($"{prompt}:");
            while (true)
            {
                string input = Console.ReadLine();
                if (double.TryParse(input, out double result) && result >= minValue && result <= maxValue)
                {
                    return result;
                }
                Console.WriteLine($"Invalid input. Please enter a number between {minValue} and {maxValue}:");
            }
        }

        static TimeSpan GetTimeSpanPreference(string prompt)
        {
            Console.WriteLine($"{prompt}:");
            while (true)
            {
                string input = Console.ReadLine();
                if (TimeSpan.TryParse(input, out TimeSpan result))
                {
                    return result;
                }
                Console.WriteLine("Invalid format. Please enter time in hh:mm:ss format:");
            }
        }

        static T GetEnumPreference<T>(string prompt) where T : struct, Enum
        {
            Console.WriteLine(prompt);
            Console.WriteLine($"Available options: {string.Join(", ", Enum.GetNames(typeof(T)))}");
            
            while (true)
            {
                string input = Console.ReadLine();
                if (Enum.TryParse<T>(input, true, out T result))
                {
                    return result;
                }
                Console.WriteLine($"Invalid option. Please enter one of: {string.Join(", ", Enum.GetNames(typeof(T)))}");
            }
        }
    }
}
