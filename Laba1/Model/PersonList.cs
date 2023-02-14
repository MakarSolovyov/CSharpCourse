namespace Model
{
    /// <summary>
    /// Class which describes a certain list of people.
    /// </summary>
    public class PersonList
    {
        /// <summary>
        /// A certain list of the people.
        /// </summary>
        private Person[] _listOfPeople = new Person[0];

        /// <summary>
        /// Function which allows to add a person to the end of the list.
        /// </summary>
        /// <param name="person">An instance of class Person.</param>
        public void AddPerson(Person person)
        {
            var indexOfNewPerson = _listOfPeople.Length;

            Array.Resize(ref _listOfPeople, _listOfPeople.Length + 1);
            _listOfPeople[indexOfNewPerson] = person;
        }

        /// <summary>
        /// Function which allows to delete a person from the list.
        /// </summary>
        /// <param name="person">An instance of class Person.</param>
        /// <exception cref="InvalidOperationException">
        /// Array is empty.</exception>
        public void DeletePerson(Person person)
        {
            if (_listOfPeople.Length != 0)
            {
                var tmpListOfPeople = new Person[0];
                var CountyOfPeople = 0;

                foreach (Person man in _listOfPeople)
                {
                    if (person == man)
                    {
                        CountyOfPeople++;
                        continue;
                    }
                    var indexOfNewPerson = tmpListOfPeople.Length;

                    Array.Resize(ref tmpListOfPeople,
                        tmpListOfPeople.Length + 1);
                    tmpListOfPeople[indexOfNewPerson] = man;
                }

                Array.Resize(ref _listOfPeople,
                    _listOfPeople.Length - CountyOfPeople);
                _listOfPeople = tmpListOfPeople;
            }
            else
            {
                throw new InvalidOperationException("Array is empty.");
            }
        }

        /// <summary>
        /// Function which allows to delete a person from the list by index.
        /// </summary>
        /// <param name="index">Index of the person in list.</param>
        public void DeletePersonByIndex(int index)
        {
            IndexInArray(index);

            for (int i = 0; i < _listOfPeople.Length; i++)
            {
                if (i == index)
                {
                    Array.Reverse(_listOfPeople, i,
                        _listOfPeople.Length - 1);
                    Array.Resize(ref _listOfPeople,
                        _listOfPeople.Length - 1);
                    Array.Reverse(_listOfPeople, i,
                        _listOfPeople.Length - 1);
                }
            }
        }

        /// <summary>
        /// Function which allows to find a person in the list by index.
        /// </summary>
        /// <param name="index">Index of the person in list.</param>
        /// <returns>Person from the list.</returns>
        public Person FindPersonByIndex(int index)
        {
            IndexInArray(index);

            return _listOfPeople[index];
        }

        /// <summary>
        /// Function which allows to find an index of the certain person.
        /// </summary>
        /// <param name="person">An instance of class Person.</param>
        /// <returns>Index of the person.</returns>
        public Array FindIndexOfPerson(Person person)
        {
            int[] tmpArray = new int[0];

            for (int i = 0; i < _listOfPeople.Length; i++)
            {
                if (_listOfPeople[i] == person)
                {
                    Array.Resize(ref tmpArray, tmpArray.Length + 1);
                    tmpArray[tmpArray.Length] = i;
                }
            }

            return tmpArray;
        }

        /// <summary>
        /// Function which allows to clear the list.
        /// </summary>
        public void ClearList()
        {
            Array.Resize(ref _listOfPeople, 0);
        }

        /// <summary>
        /// Function which allows to get the number of people in the list.
        /// </summary>
        public int NumberOfPeople => _listOfPeople.Length;

        /// <summary>
        /// Function which allows to check index in the list.
        /// </summary>
        /// <param name="index">Index of the person.</param>
        /// <exception cref="IndexOutOfRangeException">Index is out
        /// of the bounds.</exception>
        private void IndexInArray(int index)
        {
            if (index < 0 || index >= _listOfPeople.Length)
            {
                throw new IndexOutOfRangeException
                    ("Index is out of the bounds.");
            }
        }
    }
}
