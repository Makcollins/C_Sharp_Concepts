using System;

namespace FileHanlderReflections
{
    public partial class CustomList<Type>
    {
        public Type[] _array;
        private int _count;
        private int _capacity;
        public int Count { get { return _count; } }
        public int Capacity { get { return _capacity; } }
        public Type this[int i] // Indexer
        {
            get { return _array[i]; }
            set { _array[i] = value; }
        }

        //creating a constructor of the class that initializes the values  
        public CustomList()
        {
            _count = 0;
            _capacity = 4;
            _array = new Type[_capacity];
        }
        public CustomList(int size)
        {
            _count = 0;
            _capacity = size;
            _array = new Type[_capacity];
        }
        //creating a function that appends an element at the end of the _array  
        public void Add(Type data)
        {
            //compares if the number of elements is equal to the size of the _array or not  
            if (_count == _capacity)
            {
                //invoking the growSize() method that creates an _array of double size      
                GrowSize();
            }
            //appends an element at the end of the _array   
            _array[_count] = data;
            _count++;
        }
        //function that creates an _array of double size  
        public void GrowSize()
        {
            _capacity = _capacity * 2;
            //declares a temp[] _array      
            Type[] temp = new Type[_capacity];
            //initialize a double size _array of _array    
            for (int i = 0; i < _count; i++)
            {
                //copies all the elements of the old _array  
                temp[i] = _array[i];
            }
            _array = temp;
        }
        //the method removes the unused space  
        public void ShrinkSize()
        {
            //declares a temp[] _array      
            Type[] temp = null;
            if (_count > 0)
            {
                //creates an _array of the size equal to the _count i.e. number of elements the _array have  
                temp = new Type[_count];
                for (int i = 0; i < _count; i++)
                {
                    //copies all the elements of the old _array  
                    temp[i] = _array[i];
                }
                _capacity = _count;
                _array = temp;
            }
        }
        //creating a function that removes the last elements for the _array  
        public void RemoveLastElement()
        {
            if (_count > 0)
            {
                _array[_count - 1] = default(Type);
                _count--;
            }
            ShrinkSize();
        }
        //creating a function that delets an element from the specified index  
        public void RemoveElementAt(int index)
        {
            if (_count > 0)
            {
                for (int i = index; i < _count - 1; i++)
                {
                    //shifting all the elements to the left from the specified index  
                    _array[i] = _array[i + 1];
                }
                _array[_count - 1] = default(Type);
                _count--;
            }
            ShrinkSize();
        }
        public void DisplayArray()
        {
            Console.WriteLine(string.Join(" ", _array));
        }


    }


}