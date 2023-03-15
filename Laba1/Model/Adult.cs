using static System.Net.Mime.MediaTypeNames;

namespace Model
{
    /// <summary>
    /// Class which describes a certain adult.
    /// </summary>
    public class Adult : PersonBase
    {
        /// <summary>
        /// Number of adult's passport.
        /// </summary>
        private int _passportNumber;

        /// <summary>
        /// Adult's employer.
        /// </summary>
        private string _employer;

        /// <summary>
        /// Husband or wife.
        /// </summary>
        private Adult _spouse;

        /// <summary>
        /// Minimum age of an adult.
        /// </summary>
        private const int AdultMinAge = 17;

        /// <summary>
        /// Low bound of passport number range.
        /// </summary>
        private const int PassportLowBound = 100000;

        /// <summary>
        /// High bound of passport number range.
        /// </summary>
        private const int PassportHighBound = 999999;

        /// <summary>
        /// Enter the adult's passport number.
        /// </summary>
        public int PassportNumber
        {
            get => _passportNumber;
            set
            {
                CheckPassportNumber(value);
                _passportNumber = value;
            }
        }

        /// <summary>
        /// Enter the adult's employer.
        /// </summary>
        public string Employer
        {
            get => _employer;
            set
            {
                _employer = value;
            }
        }

        /// <summary>
        /// Enter the adult's spouse.
        /// </summary>
        public Adult Spouse
        {
            get => _spouse;
            set
            {
                CheckSpouseGender(value);
                _spouse = value;
            }
        }

        /// <summary>
        /// Create an instance of class Adult.
        /// </summary>
        /// <param name="name">Name of the person.</param>
        /// <param name="surname">Surname of the person.</param>
        /// <param name="age">Age of the person.</param>
        /// <param name="gender">Gender of the person.</param>
        /// <param name="passportNumber">Adult's passport number.</param>
        /// <param name="spouse">Adult's spouse.</param>
        /// <param name="employer">Adult's employer.</param>
        public Adult(string name, string surname, int age,
            GenderType gender, int passportNumber, Adult spouse,
            string employer) : base(name, surname, age, gender)
        {
            PassportNumber = passportNumber;
            Employer = employer;
            Spouse = spouse;
        }

        /// <summary>
        /// Create an instance of class Adult without parameters.
        /// </summary>
        public Adult() : this("Unknown", "Unknown", 17,
            GenderType.Male, 222222, null, null)
        { }

        /// <summary>
        /// Converts class field values to string format.
        /// </summary>
        /// <returns>Information about adult.</returns>
        public override string GetInfo()
        {
            var marrigaeStatus = "Not married";
            if (Spouse != null)
            {
                marrigaeStatus = $"Married to:" +
                    $" {Spouse.GetPersonNameSurname()}";
            }

            var employerStatus = "Unemployed";
            if (!string.IsNullOrEmpty(Employer))
            {
                employerStatus = $"Current job: {Employer}";
            }

            return $"{GetPersonInfo()};\n " +
                $"Passport number: {PassportNumber};" +
                $" {marrigaeStatus}; {employerStatus}\n ";
        }

        /// <summary>
        /// Method which allows to enter a random adult.
        /// </summary>
        /// <returns>Information about an adult.</returns>
        public static Adult GetRandomPerson
            (GenderType tmpGender = GenderType.Unknown)
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

            string[] employers =
            {
                "Hogwarts", "Ministry of Magic",
                "Beauxbatons Academy of Magic", "Durmstrang Institute",
                "Order of the Phoenix", "Death Eaters",
                "National Quidditch team",
                "International Confederation of Wizards",
                "Daily Prophet", "Romanian Dragon Sanctuary"
            };

            var random = new Random();

            if (tmpGender == GenderType.Unknown)
            {
                var tmpNumber = random.Next(1, 3);
                tmpGender = tmpNumber == 1
                    ? GenderType.Male
                    : GenderType.Female;
            }

            string tmpName = tmpGender == GenderType.Male
                ? maleNames[random.Next(maleNames.Length)]
                : femaleNames[random.Next(femaleNames.Length)];

            var tmpSurname = surnames[random.Next(surnames.Length)];

            var tmpAge = random.Next(AdultMinAge, MaxAge);

            var tmpPassportNumber = random.Next
                (PassportLowBound, PassportHighBound);

            Adult tmpSpouse = null;
            var spouseStatus = random.Next(1, 3);
            if (spouseStatus == 1)
            {
                tmpSpouse = new Adult();

                tmpSpouse.Gender = tmpGender == GenderType.Male
                    ? GenderType.Male
                    : GenderType.Female;

                tmpSpouse.Name = tmpGender == GenderType.Male
                    ? maleNames[random.Next(maleNames.Length)]
                    : femaleNames[random.Next(femaleNames.Length)];

                tmpSpouse.Surname = surnames[random.Next(surnames.Length)];
            }

            var employerStatus = random.Next(1, 3);
            string? tmpEmployer = employerStatus == 1
                ? employers[random.Next(employers.Length)]
                : null;

            return new Adult(tmpName, tmpSurname, tmpAge, tmpGender,
                tmpPassportNumber, tmpSpouse, tmpEmployer);
        }

        /// <summary>
        /// Check adult's age.
        /// </summary>
        /// <param name="age">Adult's age.</param>
        /// <exception cref="IndexOutOfRangeException">Age must be in a
        /// certain range.</exception>
        protected override void CheckAge(int age)
        {
            if (age is < AdultMinAge or > MaxAge)
            {
                throw new IndexOutOfRangeException($"Adult age value must" +
                    $" be in range [{AdultMinAge}...{MaxAge}].");
            }
        }

        /// <summary>
        /// Check adult's passport number.
        /// </summary>
        /// <param name="passportNumber">Adult's passport number.</param>
        /// <exception cref="IndexOutOfRangeException">Passport number must
        /// be in a certain range.</exception>
        private static void CheckPassportNumber(int passportNumber)
        {
            if (passportNumber is < PassportLowBound or > PassportHighBound)
            {
                throw new IndexOutOfRangeException($"Passport number must" +
                    $" be in range [{PassportLowBound}:" +
                    $" {PassportHighBound}]");
            }
        }

        /// <summary>
        /// Check gender of an adult's spouse.
        /// </summary>
        /// <param name="spouse">Gender of an adult's spouse.</param>
        /// <exception cref="ArgumentException">Gender of adult's spouse
        /// must differ from the adult.</exception>
        private void CheckSpouseGender(Adult spouse)
        {
            if (spouse != null && spouse.Gender != Gender)
            {
                throw new ArgumentException
                    ($"Spouse gender must be another");
            }
        }

        /// <summary>
        /// Method which shows the chosen side in Second Wizarding War.
        /// </summary>
        /// <returns>The chosen side.</returns>
        public string GetSide()
        {
            var rnd = new Random();

            string[] warSides =
            {
                "Albus Dumbledore", "Lord Voldemort", "No one"
            };

            var chosenSide = warSides[rnd.Next(warSides.Length)];

            return $"The side of {chosenSide} is chosen during" +
                $" Second Wizarding War";
        }
    }
}
