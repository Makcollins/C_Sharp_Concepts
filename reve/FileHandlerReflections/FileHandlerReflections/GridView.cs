using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace FileHanlderReflections
{
    public class GridView<Type>
    {
        public void ShowTable(CustomList<Type> list)
        {
            try
            {
                if (list != null && list.Count > 0)
                {
                    //Get properties
                    PropertyInfo[] properties = typeof(Type).GetProperties();
                    //Generate line
                    Console.WriteLine(new string('-', properties.Length * 18));
                    foreach (PropertyInfo property in properties)
                    {
                        if (property.CanRead)
                        {
                            Console.Write($"| {property.Name,-15} ");
                        }
                    }
                    //generate line
                    Console.Write(" |\n");
                    System.Console.WriteLine(new string('-', properties.Length * 18));

                    //Display Data
                    foreach (Type data in list)
                    {
                        foreach (PropertyInfo property in properties)
                        {
                            if (property.CanRead)
                            {
                                if (property.PropertyType == typeof(DateTime))
                                {
                                    var value = ((DateTime)property.GetValue(data)).ToString("dd/MM/yyyy", null);
                                    Console.Write($"| {value,-15} ");
                                }
                                else
                                {
                                    var value = property.GetValue(data);
                                    Console.Write($"| {value,-15} ");
                                }
                            }
                        }
                        //move to next line
                        Console.WriteLine("|");
                    }
                    //Generate line
                    Console.WriteLine(new string('-', properties.Length * 18));
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }

        }
    }
}