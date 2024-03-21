namespace Lab01Shvets.Tools
{
    static class DateHandler
    {
        private static readonly string[] _chinese = { "Monkey", "Rooster", "Dog", "Pig", "Rat", "Ox",
            "Tiger", "Rabbit", "Dragon", "Snake", "Horse", "Goat" };

        private static readonly string[] _western = {"Aquarius", "Pisces", "Aries", "Taurus", "Gemini",
        "Cancer", "Leo", "Virgo", "Libra", "Scorpio", "Sagittarius",  "Capricorn" };

        private static readonly int[] _westernStartDay = { 21, 20, 21, 21, 22, 22, 24, 24, 24, 24, 23, 22 };

        public static string ChineseZodiac(int year)
        {
            return _chinese[year % 12];
        }

        public static string WesternZodiac(int day, int month)
        {
            if (day >= _westernStartDay[month - 1])
                return _western[month - 1];
            else if (month > 1)
                return _western[month - 2];
            return "Capricorn";
        }

        public static int Age(this DateTime date)
        {
            var today = DateTime.Today;
            return today.Year - date.Year - 1 +
                (today.Month > date.Month ||
                (today.Month == date.Month && today.Day >= date.Day) ? 1 : 0);
        }

        public static bool BirthdayIsToday(this DateTime date)
        {
            return DateTime.Today.Day == date.Day
                && DateTime.Today.Month == date.Month;
        }

        public static bool IsIncorrect(this DateTime date)
        {
            return date == DateTime.Today;
        }

        public static bool NotBorn(this DateTime date)
        {
            return date >= DateTime.Today;
        }
        public static bool TooOld(this DateTime date)
        {
            return Age(date) > 135;
        }
    }
}
