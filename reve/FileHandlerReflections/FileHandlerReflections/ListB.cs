using System.Collections;
namespace FileHanlderReflections
{
    public partial class CustomList<Type> : IEnumerable, IEnumerator
    {
        int i;
        public IEnumerator GetEnumerator()
        {
            i = -1;              // or i=0;
            return (IEnumerator)this;
        }
        public bool MoveNext()
        {
            if (i < _count - 1)
            {
                ++i;  
                return true;
            }
            Reset(); // Reset Position value if no element in list
            return false;
        }
        public void Reset()  // Resets i for next turn
        {   i = -1;       }
        public object Current  //Returns the current _array position value
        {  get { return _array[i];  }   }

    }
}