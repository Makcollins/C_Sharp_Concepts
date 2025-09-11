using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace FileHanlderReflections
{
    public partial class CustomList<Type>
    {
        public int BinarySearch(string searchElement, string propertyName,out Type element)
        {
            element = default(Type);
            int left = 0;  int right = _count - 1;
            while(left <= right)
            {
                int mid = left+ (right - left)/2;
                object data = typeof(Type).GetProperty(propertyName).GetValue(_array[mid]);
                int value= data.ToString().CompareTo(searchElement);
                if(value == 0)
                {
                    element = _array[mid];
                    return mid;
                }
                else if (value < 0)
                {
                    right = mid+1;
                }
                else 
                {
                    left = mid-1;
                }
            }
            return -1;
        }
    }
}