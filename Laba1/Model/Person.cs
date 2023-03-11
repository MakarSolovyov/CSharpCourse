using System.Globalization;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace Model
{
    /// <summary>
    /// Class which describes a certain person.
    /// </summary>
    public abstract class PersonBase
    {
        /// <summary>
        /// Name of the person.
        /// </summary>
        private string _name;

        /// <summary>
        /// Surname of the person.
        /// </summary>
        private string _surname;

        /// <summary>
        /// Age of the person.
        /// </summary>
        private int _age;

        /// <summary>
        /// Gender of the person.
        /// </summary>
        private GenderType _gender;

        /// <summary>
        /// Maximum age value
        /// </summary>
        private const int MaxAge = 150;

        /// <summary>
        /// Minimum age value
        /// </summary>
        private const int MinAge = 11;

        /// <summary>
        /// Enter the name of the person.
        /// </summary>
        public string Name
        {
            get => _name;
            set
            {
                _name = EditRegister(value);

                if (_name != null)
                {
                    CheckNameSurname();
                }
            }
        }

        /// <summary>
        /// Enter the surname of the person.
        /// </summary>
        public string Surname
        {
            get => _surname;
            set
            {
                _surname = EditRegister(value);

                if (_name != null)
                {
                    CheckNameSurname();
                }
            }
        }

        /// <summary>
        /// Enter the age of the person.
        /// </summary>
        public int Age
        {
            get => _age;
            set
            {
                if (value < MinAge || value > MaxAge)
                {
                    throw new IndexOutOfRangeException("Age value must" +
                          $" be in range [{MinAge}:{MaxAge}].");
                }
                else
                { 
                    _age = value; 
                }
            }
        }

        /// <summary>
        /// Enter the gender of the person.
        /// </summary>
        public GenderType Gender
        {
            get => _gender;
            set => _gender = value;
        }

        /// <summary>
        /// Create an instance of class Person.
        /// </summary>
        /// <param name="name">Name of the person.</param>
        /// <param name="surname">Surname of the person.</param>
        /// <param name="age">Age of the person.</param>
        /// <param name="gender">Gender of the person.</param>
        public PersonBase(string name, string surname, int age,
            GenderType gender)
        {
            Name = name;
            Surname = surname;
            Age = age;
            Gender = gender;
        }

        /// <summary>
        /// Create an instance of class Person without parameters.
        /// </summary>
        public PersonBase() : this 
            ("Unknown", "Unknown", 11, GenderType.Male)
        { }

        /// <summary>
        /// Converts class field values to string format.
        /// </summary>
        /// <returns>Information about person.</returns>
        public string GetPersonInfo()
        {
            return $"{Name} {Surname}; Age - {Age}; Gender - {Gender}";
        }

        /// <summary>
        /// Converts certain class field values to string format.
        /// </summary>
        /// <returns>Person's name and surname.</returns>
        public string GetPersonNameSurname()
        {
            return $"{Name} {Surname}";
        }

        /// <summary>
        /// Method which allows to enter a random person.
        /// </summary>
        /// <returns>Random person.</returns>
        public static PersonBase GetRandomPerson()
        {
            string[] maleNames =
            {
                "Neville", "Dean", "Seamus", "Cormac", "Albus",
                "Remus", "Sirius", "Colin", "Lucius", "Marcus"
            };

            string[] femaleNames =
            {
                "Dolores", "Leta", "Pansy", "Millicent", "Tracey",
                "Parvati", "Katie", "Lily", "Romilda", "Alicia"
            };

            string[] surnames =
            {
                "Black", "Potter", "Weasley", "Longbottom", "Hagrid",
                "Lestrange", "Malfoy", "Carrow", "Goyle", "Finnigan"
            };

            var random = new Random();
            var tmpNumber = random.Next(1, 3);

            GenderType tmpGender = tmpNumber == 1
                ? GenderType.Male
                : GenderType.Female;

            string tmpName = tmpGender == GenderType.Male
                ? maleNames[random.Next(maleNames.Length)]
                : femaleNames[random.Next(femaleNames.Length)];

            var tmpSurname = surnames[random.Next(surnames.Length)];
            var tmpAge = random.Next(MinAge, MaxAge);

            return new PersonBase(tmpName, tmpSurname, tmpAge, tmpGender);
        }

        /// <summary>
        /// Check language of the string.
        /// </summary>
        /// <param name="name">String.</param>
        private static LanguageType CheckStringLanguage(string name)
        {
            var latinLanguage = new Regex
                (@"^[A-z]+(-[A-z])?[A-z]*$");
            var cyrillicLanguage = new Regex
                (@"^[А-я]+(-[А-я])?[А-я]*$");
            
            if (string.IsNullOrEmpty(name) == false)
            {
                if (latinLanguage.IsMatch(name))
                {
                    return LanguageType.Latin;
                }
                else if (cyrillicLanguage.IsMatch(name))
                {
                    return LanguageType.Cyrillic;
                }
                else
                {
                    throw new ArgumentException("Incorrect input." +
                        " Please, try again!");
                }
            }

            return LanguageType.Unknown;
        }

        /// <summary>
        /// Compare languages of the person's surname and name.
        /// </summary>
        /// <exception cref="FormatException">Only one
        /// language.</exception>
        private void CheckNameSurname()
        {
            if ((string.IsNullOrEmpty(Name) == false)
                && (string.IsNullOrEmpty(Surname) == false))
            {
                var nameLanguage = CheckStringLanguage(Name);
                var surnameLanguage = CheckStringLanguage(Surname);

                if (nameLanguage != surnameLanguage)
                {
                    throw new FormatException("Name and Surname must" +
                            " be only in one language.");
                }
            }
        }

        /// <summary>
        /// Case conversion: first letter capital, other capitals.
        /// </summary>
        /// <param name="word">Name or surname of the person.</param>
        /// <returns>Edited name or surname of the person.</returns>
        private static string EditRegister(string word)
        {
            return CultureInfo.CurrentCulture.TextInfo.
                ToTitleCase(word.ToLower());
        }

        /// <summary>
        /// Get the information about a person.
        /// </summary>
        /// <returns></returns>
        public abstract string GetInfo();
    }
}