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
            Console.WriteLine("Let's create a list and add 7 people.");
            Console.WriteLine();
            var listOfPeople = new PersonList();
            var rnd = new Random();

            for (var i = 0; i < 8; i++)
            {
                PersonBase rndPerson = rnd.Next(2) == 0
                    ? Adult.GetRandomPerson()
                    : Child.GetRandomPerson();
                listOfPeople.AddPerson(rndPerson);
            }

            _ = Console.ReadKey();

            Console.WriteLine("Let's print all people from the list.");
            Console.WriteLine();
            PrintList(listOfPeople);

            _ = Console.ReadKey();

            Console.WriteLine
                ("Let's find out type of the forth person from the list.");
            Console.WriteLine();
            var person = listOfPeople.FindPersonByIndex(3);

            switch (person)
            {
                case Adult personAdult:
                    Console.WriteLine(personAdult.GetSide());
                    break;
                case Child personChild:
                    Console.WriteLine(personChild.GetRandomHouse());
                    break;
                default:
                    break;
            }

            _ = Console.ReadKey();
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
                    Console.WriteLine(tmpPerson.GetInfo());
                }
            }
            else
            {
                Console.WriteLine("List is empty.");
            }
        }
    }
}
