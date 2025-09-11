using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace FileHanlderReflections
{
    public class FileHandling<Type>
    {
        static string folderName;
        public static void CreateFolder()
        {
            folderName = new Program().GetType().Namespace;//Create folder name for application using namespace name
            //Check folder already exit
            if (!Directory.Exists(folderName))
            {
                System.Console.WriteLine("Creating folder");
                Directory.CreateDirectory(folderName);
            }
        }

        public static void CreateFile(string fileName)
        {
            //Check already file exist
            if (!File.Exists($"{folderName}/{fileName}"))
            {
                System.Console.WriteLine($"Creating File {fileName}...");
                File.Create($"{folderName}/{fileName}").Close();
            }
        }

        public static void ReadFromCSV(CustomList<Type> list)
        {
            CreateFolder();
            //File name
            string fileName = $"{folderName}/{typeof(Type).Name}.csv";
            CreateFile(fileName);
            //Get all properties
            PropertyInfo[] properties = typeof(Type).GetProperties();
            //Read data from file
            string[] contents = File.ReadAllLines(fileName);
            foreach (string content in contents)
            {
                //Get single line
                string[] values = content.Split(",");
                //create object
                Type newObject = Activator.CreateInstance<Type>();
                for (int i = 0; i < values.Length; i++)// loop values
                {
                    //set the values to object's properies based on data type
                    if (properties[i].PropertyType == typeof(DateTime))
                    {
                        properties[i].SetValue(newObject, DateTime.ParseExact(values[i], "dd/MM/yyyy", null));
                    }
                    else if (properties[i].PropertyType.IsEnum)
                    {
                        Enum.TryParse(properties[i].PropertyType, values[i], true, out object data);
                        properties[i].SetValue(newObject, data);
                    }
                    else // All other types 
                    {
                        object data = Convert.ChangeType((object)values[i], properties[i].PropertyType);
                        properties[i].SetValue(newObject, data);
                    }
                }
                list.Add(newObject);
            }
        }

        public static void WriteToCSV(CustomList<Type> list)
        {
            CreateFolder();
            //File name
            string fileName = $"{folderName}/{typeof(Type).Name}.csv";
            CreateFile(fileName);
            List<string> contentList = new List<string>();// rowList
            //Properties
            PropertyInfo[] properties = typeof(Type).GetProperties();

            foreach (Type data in list)// fetch once object
            {
                List<string> columnList = new();//store property values in list
                foreach (PropertyInfo property in properties)// Loop through properties
                {
                    if (property.CanRead)
                    {
                        if (property.PropertyType == typeof(DateTime))// For datetime format
                        {
                            columnList.Add(((DateTime)property.GetValue(data)).ToString("dd/MM/yyyy", null));
                        }
                        else// for all other types
                        {
                            columnList.Add(property.GetValue(data).ToString() ?? "");
                        }
                    }
                }
                contentList.Add(string.Join(",", columnList));
            }
            //Write the content to file
            File.WriteAllLines(fileName,contentList);
        }
    }
}