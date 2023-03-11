using System;

namespace Model
{
    /// <summary>
    /// Class wgich describes a certain child.
    /// </summary>
    public class Child : PersonBase
    {
        /// <summary>
        /// A child's farther.
        /// </summary>
        private Adult _father;

        /// <summary>
        /// A child's mother.
        /// </summary>
        private Adult _mother;

        /// <summary>
        /// A child's place pf study.
        /// </summary>
        private string _school;

        /// <summary>
        /// Maximum age of a child.
        /// </summary>
        private const int ChildMaxAge = 16;

        /// <summary>
        /// Enter the information about child's father.
        /// </summary>
        public Adult Father
        {
            get => _father;
            set
            {
                CheckParentGender(value, GenderType.Female);
                _father = value;
            }
        }

        /// <summary>
        /// Enter the information about child's mother.
        /// </summary>
        public Adult Mother
        {
            get => _mother;
            set
            {
                CheckParentGender(value, GenderType.Male);
                _mother = value;
            }
        }

        /// <summary>
        /// Enter the information about child's school.
        /// </summary>
        public string School
        {
            get => _school;
            set
            {
                _school = value;
            }
        }

        /// <summary>
        /// Create an instance of class Child.
        /// </summary>
        /// <param name="name">Name of the person.</param>
        /// <param name="surname">Surname of the person.</param>
        /// <param name="age">Age of the person.</param>
        /// <param name="gender">Gender of the person.</param>
        /// <param name="father">Child's father.</param>
        /// <param name="mother">Child's mother</param>
        /// <param name="school">Child's school.</param>
        public Child(string name, string surname, int age,
            GenderType gender, Adult father, Adult mother,
            string school) : base (name, surname, age, gender)
        {
            Father = father;
            Mother = mother;
            School = school;
        }

        /// <summary>
        /// Create an instance of class Child without parameters.
        /// </summary>
        public Child() : this("Unknown", "Unknown", 11,
            GenderType.Male, null, null, null)
        { }

        /// <summary>
        /// Converts class field values to string format.
        /// </summary>
        /// <returns>Information about child.</returns>
        public override string GetInfo()
        {
            var fatherStatus = "Father: no parent";
            var motherStatus = "Mother: no parent";

            if (Father != null)
            {
                fatherStatus = $"Father: {Father.GetPersonNameSurname}";
            }
            else if (Mother != null)
            {
                motherStatus = $"Mother: {Mother.GetPersonNameSurname}";
            }

            var schoolStatus = "Not studying";
            if (!string.IsNullOrEmpty(School))
            {
                schoolStatus = $"Studying at: {School}";
            }

            return $"{GetPersonInfo}; {fatherStatus}; {motherStatus};" +
                $" {schoolStatus}";
        }

        /// <summary>
        /// Method which allows to enter a random child.
        /// </summary>
        /// <returns>Information about a child.</returns>
        public static Child GetRandomPerson()
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

            string[] schools =
            {
                "Hogwarts", "Mahoutokoro", "Beauxbatons Academy of Magic",
                "Durmstrang Institute", "Uagadou", "Castelobruxo",
                "Ilvermorny", "Koldovstoretz"
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

            var tmpAge = random.Next(MinAge, ChildMaxAge);

            Adult tmpSpouse = null;
            var spouseStatus = random.Next(1, 3);
            if (spouseStatus == 1)
            {
                tmpSpouse = new Adult();

                tmpSpouse.Gender = tmpGender == GenderType.Male
                    ? GenderType.Female
                    : GenderType.Male;

                tmpSpouse.Name = tmpGender == GenderType.Male
                    ? maleNames[random.Next(maleNames.Length)]
                    : femaleNames[random.Next(femaleNames.Length)];

                tmpSpouse.Surname = surnames[random.Next(surnames.Length)];
            }

            var tmpParent = new Adult();
            var randomParent = new Action<int>((int property) =>
            {
                tmpParent.Gender = property == 1
                    ? GenderType.Male
                    : GenderType.Female;

                tmpParent.Name = tmpParent.Gender == GenderType.Male
                    ? maleNames[random.Next(maleNames.Length)]
                    : femaleNames[random.Next(femaleNames.Length)];

                tmpParent.Surname = surnames[random.Next(surnames.Length)];
            });
            Adult tmpFather = null;
            Adult tmpMother = null;
            var fatherStatus = random.Next(1, 3);
            if (fatherStatus == 1)
            {
                randomParent.Invoke(fatherStatus);
                tmpFather = tmpParent;
            }
            var motherStatus = random.Next(1, 3);
            if (motherStatus == 2)
            {
                randomParent.Invoke(motherStatus);
                tmpMother = tmpParent;
            }

            var schoolStatus = random.Next(1, 3);
            string? tmpSchool = schoolStatus == 1
                ? schools[random.Next(schools.Length)]
                : null;

            return new Child(tmpName, tmpSurname, tmpAge, tmpGender,
                tmpFather, tmpMother, tmpSchool);
        }

        /// <summary>
        /// Check child's age.
        /// </summary>
        /// <param name="age">Child's age.</param>
        /// <exception cref="IndexOutOfRangeException">Age must be in a
        /// certain range.</exception>
        protected override void CheckAge(int age)
        {
            if (age is < MinAge or > ChildMaxAge)
            {
                throw new IndexOutOfRangeException($"Child's age must be" +
                    $" in range [{MinAge}...{ChildMaxAge}].");
            }
        }

        /// <summary>
        /// Check parent's gender's.
        /// </summary>
        /// <param name="parent">A certain adult parent.</param>
        /// <param name="gender">Gender of the parent.</param>
        /// <exception cref="ArgumentException">Parent's gender's must
        /// differ from each other.</exception>
        private static void CheckParentGender
            (Adult parent, GenderType gender)
        {
            if (parent != null && parent.Gender == gender)
            {
                throw new ArgumentException
                    ("Parent gender must be another");
            }
        }

        /// <summary>
        /// Method which shows the preferred for wizard Hogwarts house.
        /// </summary>
        /// <returns>The chosen house.</returns>
        public string GetRandomHouse()
        {
            var rnd = new Random();

            string[] houses =
            {
                "Gryffindor", "Slytherin", "Ravenclaw", "Hufflepuff"
            };

            var preferredHouse = houses[rnd.Next(houses.Length)];

            return $"The preferred Hoqwarts house for this wizard" +
                $" is {preferredHouse}";
        }
    }
}
