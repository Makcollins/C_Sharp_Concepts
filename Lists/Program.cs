using System;
using System.Collections.Generic;
using Lists;

namespace MyList;
class Program
{
    static void Main(string[] args)
    {
        Person lloyd = new Person()
        {
            FirstName = "Lloyd",
            LastName = "Katila",
            Age = 14,
            Gender = Gender.Male,
            Weight = 51
        };

        Person stephen = new Person()
        {
            FirstName = "Stephen",
            LastName = "Otieno",
            Age = 35,
            Gender = Gender.Male,
            Weight = 87
        };

        Person stephanie = new Person()
        {
            FirstName = "Stephanie",
            LastName = "Achieng'",
            Age = 19,
            Gender = Gender.Female,
            Weight = 64
        };

        Person ronny = new Person()
        {
            FirstName = "Ronny",
            LastName = "Ochieng",
            Age = 23,
            Gender = Gender.Male,
            Weight = 62
        };

        Person samwel = new Person()
        {
            FirstName = "Samwel",
            LastName = "Gideon",
            Age = 17,
            Gender = Gender.Male,
            Weight = 72
        };
        //douglas
        Person douglas = new Person()
        {
            FirstName = "Stephen",
            LastName = "Onyil",
            Age = 28,
            Gender = Gender.Male,
            Weight = 66
        };


        // Declaring a list
        List<Person> people = new List<Person>();

        //Adding list members
        people.Add(lloyd);
        people.Add(stephen);
        people.Add(stephanie);
        people.Add(ronny);
        people.Add(samwel);

        //Insert member

        people.Insert(1, douglas);
        //Remove member
        people.Remove(lloyd);

        //Sort members  OrderBy || OrderByDescending || ThenBy
        people = people.OrderByDescending(x => x.FirstName).ThenByDescending(x => x.LastName).ToList();


        //Filtering || WHERE
        List<Person> adults = people.Where(x => x.Age > 18).ToList();



        // count
        int count = people.Count(x => x.Age < 18);


        //Printing list items
        foreach (var item in people)
        {
            // Console.WriteLine($"Name: {item.FirstName} {item.LastName}\nAge: {item.Age}\nGender: {item.Gender}\nWeight: {item.Weight}\n");
            Console.WriteLine($"{item.FirstName} {item.LastName} {item.Age}");
        }



        Console.WriteLine();
        Console.WriteLine("Filtered List");
        foreach (var item in adults)
        {
            // Console.WriteLine($"Name: {item.FirstName} {item.LastName}\nAge: {item.Age}\nGender: {item.Gender}\nWeight: {item.Weight}\n");
            Console.WriteLine($"{item.FirstName} {item.LastName} {item.Age}");
        }
        
        System.Console.WriteLine(count);


    }
}