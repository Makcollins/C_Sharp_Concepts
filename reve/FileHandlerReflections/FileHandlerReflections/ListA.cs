using System;
using System.Collections;
using System.Collections.Generic;
namespace FileHanlderReflections
{
    public partial class CustomList<Type>
    {
        public void Bubble()
        {
             Type temp;
             for (int j = 0; j < _count - 1; j++) 
             {
                for (int i = 0; i < _count -1; i++)
                {
                    if (IsGreater(_array[i],_array[i+1])) 
                    {
                        temp= _array[i + 1];
                        _array[i + 1] = _array[i];
                        _array[i] = temp;
                     }
                }
             }
        }
        public bool IsGreater(Type value1,Type value2) 
        {
            var result = Comparer<Type>.Default.Compare(value1,value2);
             // value 1 is less result =-1; greater result=1; equal result=0;
              if ( result >= 0 ) { return true; }// if first value is greater then false
            else { return false; }
        }
      
    }
}