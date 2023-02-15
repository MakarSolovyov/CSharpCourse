using System.Globalization;
using System.Text.RegularExpressions;

namespace Model
{
    /// <summary>
    /// Class which describes a certain person.
    /// </summary>
    public class Person
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
        /// Enter the name of the person.
        /// </summary>
        public string Name
        {
            get => _name;
            set
            {
                CheckNameLanguage(value);
                _name = EditRegister(value);
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
                CheckSurnameLanguage(value);
                _surname = EditRegister(value);
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
                //TODO: ставить скобочки
                //TODO: duplication
                if (value < 11 || value > 150)
                {
                    throw new IndexOutOfRangeException("Age value must" +
                          " be in range [11:150].");
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
        public Person(string name, string surname, int age,
            GenderType gender)
        {
            Name = name;
            Surname = surname;
            Age = age;
            Gender = gender;
        }

        public Person()
        {        }

        /// <summary>
        /// Converts class field value to string format.
        /// </summary>
        /// <returns>Information about person.</returns>
        public override string ToString()
        {
            return $"{Name} {Surname}; Age - {Age}; Gender - {Gender}";
        }

        /// <summary>
        /// Method which allows to enter a random person.
        /// </summary>
        /// <returns>Random person.</returns>
        public static Person GetRandomPerson()
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

            //TODO: как вариант
            GenderType tmpGender = tmpNumber == 1
                ? GenderType.Male
                : GenderType.Female;

            string tmpName = "Default";

            switch (tmpNumber)
            {
                case 1:
                    {
                        tmpGender = GenderType.Male;
                        tmpName = maleNames[random.Next
                            (maleNames.Length)];
                        break;
                    }
                
                case 2:
                    {
                        tmpGender = GenderType.Female;
                        tmpName = femaleNames[random.Next
                            (femaleNames.Length)];
                        break;
                    }
            }

            var tmpSurname = surnames[random.Next(surnames.Length)];
            //TODO: duplication
            var tmpAge = random.Next(11, 150);

            return new Person(tmpName, tmpSurname, tmpAge, tmpGender);
        }

        //TODO: naming
        /// <summary>
        /// Check language of the person's name.
        /// </summary>
        /// <param name="name">Name of the person.</param>
        /// <exception cref="FormatException">Only Cyrillic or Latin
        /// characters.</exception>
        private static void CheckNameLanguage(string name)
        {
            //TODO: поправить порядок задания имени и фамилии
            if (string.IsNullOrEmpty(name))
            {
                throw new FormatException("Name can't be null or empty.");
            }

            //TODO: duplication
            var nameLanguage = new Regex(@"(^[A-z]+(-[A-z])?[A-z]*$)|
                (^[А-я]+(-[А-я])?[А-я]*$)");

            if (nameLanguage.IsMatch(name) == false)
            {
                throw new FormatException("Name must consist only " +
                    "Cyrillic or Latin characters.");
            }
        }

        /// <summary>
        /// Check language of the person's surname according
        /// to the name's language.
        /// </summary>
        /// <param name="surname">Surname of the person.</param>
        /// <exception cref="FormatException">Only necessary
        /// characters.</exception>
        private void CheckSurnameLanguage(string surname)
        {
            //TODO: duplication
            var latinLanguage = new Regex
                (@"^[A-z]+(-[A-z])?[A-z]*$");
            var cyrillicLanguage = new Regex
                (@"^[А-я]+(-[А-я])?[А-я]*$");

            CheckNameLanguage(surname);

            if (latinLanguage.IsMatch(Name))
            {
                if (latinLanguage.IsMatch(surname) == false)
                {
                    throw new FormatException("Name and Surname must" +
                        " consist only Latin characters.");
                }
            }

            if (cyrillicLanguage.IsMatch(Name))
            {
                if (cyrillicLanguage.IsMatch(surname) == false)
                {
                    throw new FormatException("Name and Surname must" +
                        " consist only Cyrillic characters.");
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
            //TODO: проверить, работает ли для двойной фамилии
            return CultureInfo.CurrentCulture.TextInfo.
                ToTitleCase(word.ToLower());
        }
    }
}