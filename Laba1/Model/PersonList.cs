using System;

namespace Model
{
    /// <summary>
    /// Class which describes a certain array of people.
    /// </summary>
    public class PersonList
    {
        /// <summary>
        /// A certain array of the people.
        /// </summary>
        private Person[] _arrayOfPeople = new Person[0];

        /// <summary>
        /// Function which allows to add a person to the end of the array.
        /// </summary>
        /// <param name="person">An instance of class Person.</param>
        public void AddPerson(Person person)
        {
            var indexOfNewPerson = _arrayOfPeople.Length;

            Array.Resize(ref _arrayOfPeople, _arrayOfPeople.Length + 1);
            _arrayOfPeople[indexOfNewPerson] = person;
        }

        /// <summary>
        /// Function which allows to delete a person from the array.
        /// </summary>
        /// <param name="person">An instance of class Person.</param>
        /// <exception cref="InvalidOperationException">
        /// Array is empty.</exception>
        public void DeletePerson(Person person)
        {
            if (_arrayOfPeople.Length != 0)
            {
                int[] indexesToDelete = FindIndexOfPerson(person);

                for (int i = 0; i < indexesToDelete.Length; i++)
                {
                    DeletePersonByIndex(indexesToDelete[i]);
                }
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
            IsIndexInArray(index);

            for (int i = index; i < _arrayOfPeople.Length - 1; i++)
            {
                _arrayOfPeople[i] = _arrayOfPeople[i + 1];
            }

            Array.Resize(ref _arrayOfPeople,
                    _arrayOfPeople.Length - 1);
        }

        /// <summary>
        /// Function which allows to find a person in the list by index.
        /// </summary>
        /// <param name="index">Index of the person in list.</param>
        /// <returns>Person from the list.</returns>
        public Person FindPersonByIndex(int index)
        {
            IsIndexInArray(index);

            return _arrayOfPeople[index];
        }

        /// <summary>
        /// Function which allows to find an index of the certain person.
        /// </summary>
        /// <param name="person">An instance of class Person.</param>
        /// <returns>Index of the person.</returns>
        public int[] FindIndexOfPerson(Person person)
        {
            int[] tmpArray = new int[0];

            for (int i = 0; i < _arrayOfPeople.Length; i++)
            {
                if (_arrayOfPeople[i] == person)
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
            Array.Resize(ref _arrayOfPeople, 0);
        }

        /// <summary>
        /// Function which allows to get the number of people in the list.
        /// </summary>
        public int NumberOfPeople => _arrayOfPeople.Length;

        /// <summary>
        /// Function which allows to check index in the list.
        /// </summary>
        /// <param name="index">Index of the person.</param>
        /// <exception cref="IndexOutOfRangeException">Index is out
        /// of the bounds.</exception>
        private void IsIndexInArray(int index)
        {
            if (index < 0 || index >= _arrayOfPeople.Length)
            {
                throw new IndexOutOfRangeException
                    ("Index is out of the bounds.");
            }
        }
    }
}
