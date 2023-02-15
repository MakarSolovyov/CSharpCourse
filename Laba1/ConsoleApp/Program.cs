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
            //TODO: try-catch
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
            var person = new Person();

            var actionList = new List<(Action, string)>
            {
                (new Action(() =>
                {
                    Console.Write($"Enter student name: ");
                    person.Name = Console.ReadLine();
                }), "name"),
                new Action(() =>
                {
                    Console.Write($"Enter student surname: ");
                    person.Surname = Console.ReadLine();
                }),
                new Action(() =>
                {
                    Console.Write($"Enter student age: ");
                    int.TryParse(Console.ReadLine(), out int tmpAge);
                    person.Age = tmpAge;
                }),
                new Action(() =>
                {
                    Console.Write($"Enter student gender (1 - Male or 2 - Female): ");
                    int.TryParse(Console.ReadLine(), out int tmpGender);
                    if (tmpGender < 1 || tmpGender > 2)
                    {
                        throw new OutOfRangeException();
                    }
                    var realGender = tmpGender == 1
                        ? GenderType.Male
                        : GenderType.Female;
                    person.Gender = realGender;
                })
            };

            foreach(var action in actionList)
            {
                ActionHandler(action.Item1, action.Item2);
            }

            return person;
        }

        private static void ActionHandler(Action action, string propertyName)
        {
            while (true)
            {
                try
                {
                    action.Invoke();
                    break;
                }
                catch (Exception exception)
                {
                    Console.WriteLine($"Incorrect {propertyName}. Error: {exception.Message}." +
                        $"Please, enter the name again.");
                }
            }
        }
    }
}
