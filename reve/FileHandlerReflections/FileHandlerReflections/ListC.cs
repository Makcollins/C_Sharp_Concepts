
namespace FileHanlderReflections
{
    public partial class CustomList<Type>
    {
        public void Insert(int index, Type value)
        {
            Type[] temp = new Type[_capacity * 2];
            for (int i = 0; i < _count; i++)
            {
                if (i < index)
                {
                    temp[i] = _array[i];
                }
                else if (i >= index)
                {
                    temp[i + 1] = _array[i];
                }

            }
            temp[index] = value;
            _array = temp;
            _count += 1;
        }
        public void Remove(Type value)
        {
            Type[] temp = new Type[_capacity * 2];
            int j = 0;
            for (int i = 0; i < _count; i++)
            {
                if (value.Equals(_array[i]))
                {
                    i++;
                }
                temp[j] = _array[i];
                j++;
            }
            _array = temp;
            _count--;
        }
        public void RemoveAt(int index)
        {
            Type[] temp = new Type[_capacity * 2];
            int j = 0;
            for (int i = 0; i < _count; i++)
            {
                if (i == index)
                {
                    i++;
                }
                temp[j] = _array[i];
                j++;
            }
            _array = temp;
            _count--;
        }
    }
}