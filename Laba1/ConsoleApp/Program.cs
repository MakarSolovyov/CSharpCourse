using Model;

namespace ConsoleApp
{
    /// <summary>
    /// Class Program.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// Class Main.
        /// </summary>
        private static void Main()
        {
            // Create two lists
            var listGryffindor = new PersonList();
            var listSlytherin = new PersonList();

            // Create 6 people to fill the lists
            var potter = new Person
                ("Harry", "Potter", 12, GenderType.Male);
            var granger = new Person
                ("Hermione", "Granger", 12, GenderType.Female);
            var weasley = new Person
                ("Ron", "Weasley", 12, GenderType.Male);

            var snape = new Person
                ("Severus", "Snape", 32, GenderType.Male);
            var riddle = new Person
                ("Tom", "Riddle", 12, GenderType.Male);
            var malfoy = new Person
                ("Draco", "Malfoy", 12, GenderType.Male);

            // Add people to the lists
            listGryffindor.AddPerson(potter);
            listGryffindor.AddPerson(granger);
            listGryffindor.AddPerson(weasley);

            listSlytherin.AddPerson(snape);
            listSlytherin.AddPerson(riddle);
            listSlytherin.AddPerson(malfoy);

            // Print the lists
            _ = Console.ReadKey();
            Console.WriteLine("List of Gryffindor students:");
            PrintList(listGryffindor);

            Console.WriteLine("List of Slytherin students:");
            PrintList(listSlytherin);

            // Add a new person to the first list
            _ = Console.ReadKey();
            var mcgonagall = new Person
                ("Minerva", "Mcgonagall", 55, GenderType.Female);
            listGryffindor.AddPerson(mcgonagall);

            // Copy the second person from the first list to the end of
            // the second one
            _ = Console.ReadKey();
            listSlytherin.AddPerson(listGryffindor.FindPersonByIndex(1));

            // Print the lists
            Console.WriteLine("List of Gryffindor students:");
            PrintList(listGryffindor);

            Console.WriteLine("List of Slytherin students:");
            PrintList(listSlytherin);

            // Delete the second person from the first list
            _ = Console.ReadKey();
            listGryffindor.DeletePersonByIndex(1);

            // Print the lists
            Console.WriteLine("List of Gryffindor students:");
            PrintList(listGryffindor);

            Console.WriteLine("List of Slytherin students:");
            PrintList(listSlytherin);

            // Clear the second list
            _ = Console.ReadKey();
            listSlytherin.ClearList();

            // Print the lists
            Console.WriteLine("List of Gryffindor students:");
            PrintList(listGryffindor);

            Console.WriteLine("List of Slytherin students:");
            PrintList(listSlytherin);

            // Check other methods
            _ = Console.ReadKey();
            var inputPerson = InputPersonByConsole();
            Console.WriteLine(inputPerson.ToString());

            var randomPerson = Person.GetRandomPerson();
            Console.WriteLine(randomPerson.ToString());
        }

        /// <summary>
        /// Function which allows to print a certain list of people.
        /// </summary>
        /// <param name="personList">An instance of class PersonList.</param>
        private static void PrintList(PersonList personList)
        {
            if (personList == null)
            {
                throw new NullReferenceException("Null reference list.");
            }

            if (personList.NumberOfPeople != 0)
            {
                for (int i = 0; i < personList.NumberOfPeople; i++)
                {
                    var tmpPerson = personList.FindPersonByIndex(i);
                    Console.WriteLine(tmpPerson.ToString());
                }
            }
            else
            {
                Console.WriteLine("List is empty.");
            }
        }

        /// <summary>
        /// Method which allows to enter information by console.
        /// </summary>
        /// <returns>An instance of class Person.</returns>
        /// <exception cref="ArgumentException">Only numbers.</exception>
        public static Person InputPersonByConsole()
        {

            Console.Write("Enter student name: ");
            var tmpName = Console.ReadLine();
            while (string.IsNullOrEmpty(tmpName))
            {
                Console.WriteLine("Incorrect name. Please, enter the" +
                    " name again.");
                Console.Write("Enter student name: ");
                tmpName = Console.ReadLine();
            }

            Console.Write("Enter student surname: ");
            var tmpSurname = Console.ReadLine();
            while (string.IsNullOrEmpty(tmpSurname))
            {
                Console.WriteLine("Incorrect surname. Please, enter the" +
                    " surname again.");
                Console.Write("Enter student surname: ");
                tmpSurname = Console.ReadLine();
            }

            Console.Write("Enter student age: ");
            int tmpAge;
            while (!int.TryParse(Console.ReadLine(), out tmpAge))
            {
                Console.WriteLine("Incorrect surname. Please, enter the" +
                    " surname again.");
                Console.Write("Enter student age: ");
            }

            Console.Write("Enter student gender (1 - Male, 2 - Female): ");
            GenderType tmpGender = GenderType.Female;
            int tmpNumber;

            while (!int.TryParse(Console.ReadLine(), out tmpNumber) ||
                (tmpNumber != 1 & tmpNumber != 2))
            {
                Console.WriteLine("Incorrect value. Please, enter the" +
                    " value again.");
                Console.Write("Enter student gender " +
                    "(1 - Male, 2 - Female): ");
            }

            switch (tmpNumber)
            {
                case 1:
                    {
                        tmpGender = GenderType.Male;
                        break;
                    }

                case 2:
                    {
                        tmpGender = GenderType.Female;
                        break;
                    }

                default:
                    {
                        Console.WriteLine("Incorrect value. Please, enter" +
                            " the value again.");
                        break;
                    }
            }

            return new Person(tmpName, tmpSurname, tmpAge, tmpGender);
        }
    }
}
