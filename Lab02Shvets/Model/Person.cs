using Lab01Shvets.Tools;
using Lab02Shvets.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Lab02Shvets.Model
{
    internal class Person
    {
        private readonly string _firstName;
        private readonly string _lastName;
        private readonly string _email;
        private readonly DateTime _birthDate;
        private int _age;
        private string _sunSign = "";
        private string _chineseSign = "";
        private bool _isAdult;
        private bool _isBirthday;

        internal Person(string firstName, string lastName, string email, DateTime birthday)
        {
            if (isWrongName(firstName) || isWrongName(lastName))
                throw new WrongNameException("Only Latin letters in names!");
            if (isWrongEmail(email))
                throw new WrongEmailException("Wrong email!");
            if (birthday.NotBorn())
                throw new NotBornException("Person did not born!");
            if (birthday.TooOld())
                throw new OldDateException("Person is too old to be alive!");
            _firstName = firstName.Trim();
            _lastName = lastName.Trim();
            _email = email.Trim();
            _birthDate = birthday;
            SetFields();
        }

        Person(string firstName, string lastName, DateTime birthday)
            : this(firstName, lastName, "no_email", birthday) { }

        Person(string firstName, string lastName, string email)
            : this(firstName, lastName, email, DateTime.Today) { }

        public void SetFields()
        {
            _sunSign = DateHandler.WesternZodiac(_birthDate.Day, _birthDate.Month);
            _chineseSign = DateHandler.ChineseZodiac(_birthDate.Year);
            _age = _birthDate.Age();
            _isAdult = _age >= 18;
            _isBirthday = _birthDate.BirthdayIsToday();
        }

        public string Info()
        {
            StringBuilder sb = new($"{FirstName} {LastName}\n");
            sb.AppendLine($"Email: {Email}");
            sb.AppendLine($"{Age} years old");
            sb.AppendLine($"Born on {BirthDate.ToString("dd.MM.yyyy")}");
            sb.AppendLine($"Western zodiac sign is {SunSign}");
            sb.AppendLine($"Chinese zodiac sign is {ChineseSign}");
            sb.AppendLine($"Is adult: {IsAdult}");
            sb.AppendLine($"Has birthday today: {IsBirthday}\n");
            return sb.ToString();
        }

        private bool isWrongName(string name)
        {
            return !Regex.IsMatch(name, @"^[a-zA-Z]+$");
        }

        private bool isWrongEmail(string email)
        {
            return !Regex.IsMatch(email, @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");
        }

        public string FirstName { get { return _firstName; } }
        public string LastName { get { return _lastName; } }
        public string Email { get { return _email; } }
        public DateTime BirthDate { get { return _birthDate; } }
        public int Age { get { return _age; } }
        public string SunSign { get { return _sunSign; } }
        public string ChineseSign { get { return _chineseSign; } }
        public bool IsAdult { get { return _isAdult; } }
        public bool IsBirthday { get { return _isBirthday; } }

    }
}
