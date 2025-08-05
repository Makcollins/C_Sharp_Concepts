using System;
using System.Diagnostics;

namespace OnlineCourses;

public partial class UserOperations
{
    UserDetails currentUser = null!;
    static string username = string.Empty;
    static int age;
    static Gender gender;
    static string qualification = string.Empty;
    static string mobileNumber = string.Empty;
    static string mailID = string.Empty;

    bool correct = true;
    //REGISTER METHOD
    public void Register(int counter)
    {
        correct = true;
        Console.Write("User Name: ");
        username = Console.ReadLine()!;
        do
        {
            try
            {
                Console.Write("Age: ");
                age = int.Parse(Console.ReadLine()!);
                correct = true;
            }
            catch (Exception)
            {
                Console.WriteLine("Age must be a number.");
                correct = false;
            }
        } while (!correct);

        do
        {
            try
            {
                Console.Write("Gender (Male/Female): ");
                gender = (Gender)Enum.Parse(typeof(Gender), Console.ReadLine()!);
                correct = true;

            }
            catch (Exception)
            {
                Console.WriteLine("Spelling/case didn't match.");
                correct = false;
            }
        } while (!correct);

        Console.Write("Qualification: ");
        qualification = Console.ReadLine()!;

        do
        {
            Console.Write("Mobile Number: ");
            mobileNumber = Console.ReadLine()!;
            
            if (mobileNumber.Length == 10)
            {
                correct = true;
                foreach (char ch in mobileNumber)
                {
                    if (!Char.IsDigit(ch))
                    {  
                        Console.WriteLine("Incorrect format!");
                        correct = false;
                    }
                }
            }
            else
            {
                Console.WriteLine("Incorrect format!");
                correct = false;
            }
        } while (!correct);
        

        Console.Write("Mail ID: ");
        mailID = Console.ReadLine()!;

        currentUser = new UserDetails()
        {
            RegistrationID = "SYNC"+counter,
            UserName = username,
            Age = age,
            Gen = gender,
            Qualification = qualification,
            MobileNumber = mobileNumber,
            MailID = mailID
        };
        // counter++;
        users.Add(currentUser);

        Console.WriteLine("----------------------------------------------");
        Console.WriteLine("NEW USER ID: " + currentUser.RegistrationID);
        Console.WriteLine("----------------------------------------------");
    }
    
}

