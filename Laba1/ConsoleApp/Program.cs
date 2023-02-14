using Model;
using static Model.Person;

namespace ConsoleApp
{
    /// <summary>
    /// Class Program.
    /// </summary>
    public static class Program
    {
        private static void Main()
        {
            // Create two lists
            PersonList listGryffindor = new PersonList();
            PersonList listSlytherin = new PersonList();

            // Create 6 people to fill the lists
            Person potter = new Person
                ("Harry", "Potter", 12, GenderType.Male);
            Person granger = new Person
                ("Hermione", "Granger", 12, GenderType.Female);
            Person weasley = new Person
                ("Ron", "Weasley", 12, GenderType.Male);

            Person snape = new Person
                ("Severus", "Snape", 32, GenderType.Male);
            Person riddle = new Person
                ("Tom", "Riddle", 12, GenderType.Male);
            Person malfoy = new Person
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
            Person mcgonagall = new Person
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
            var ggwp = InputPersonByConsole();
            Console.WriteLine(ggwp.ToString());

            var ggwp2 = GetRandomPerson();
            Console.WriteLine(ggwp2.ToString());

        }

        /// <summary>
        /// Fuction which allows to print a certain list of people.
        /// </summary>
        /// <param name="personList">An instance of class PersonList.</param>
        private static void PrintList(PersonList personList)
        {
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

            Console.Write("Enter student surname: ");
            var tmpSurname = Console.ReadLine();

            Console.Write("Enter student age: ");
            int tmpAge;
            var inputAge = Console.ReadLine();
            bool result = int.TryParse(inputAge, out var resultAge);
            if (result)
            {
                tmpAge = resultAge;
            }
            else
            {
                throw new ArgumentException("Please, filling student" +
                    " age enter only numbers.");
            }

            Console.Write("Enter student gender (1 - Male, 2 - Female): ");
            GenderType tmpGender;
            var tmpNumber = Convert.ToInt32(Console.ReadLine());
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
                        throw new ArgumentException("Please, enter 1 or 2");
                    }
            }

            return new Person(tmpName, tmpSurname, tmpAge, tmpGender);
        }
    }
}
