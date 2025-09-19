using System;
using System.Text.RegularExpressions;

namespace OnlineHospital;

public class AuthenticationManager
{
    // static ListManager listManager = new();
    AppointmentManager appointment = new ();
    List<PatientDetails> patientsList = ListManager.ReadPatientsFromCSV();
    public void Registration()
    {
        bool correct = true;
        //input name
        Console.Write("Enter user name: ");
        string patientName = Console.ReadLine()!;

        //input father name
        Console.Write("Enter Father name: ");
        string fatherName = Console.ReadLine()!;

        Gender gender = Gender.Transgender;
        string phoneNumber;
        string mail;
        int age;

        //input gender
        do
        {
            correct = true;
            Console.Write("Enter Gender: ");
            try
            {
                gender = Enum.Parse<Gender>(Console.ReadLine()!);
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid Syntax\n");
                correct = false;
            }
        } while (!correct);

        //vaalidate phone number
        Regex mobileFormat = new Regex("^\\+?\\d{1,4}?[-.\\s]?\\(?\\d{1,3}?\\)?[-.\\s]?\\d{1,4}[-.\\s]?\\d{1,4}$");
        do
        {
            correct = true;
            Console.Write("Enter mobile number: ");
            phoneNumber = Console.ReadLine()!;
            if (!mobileFormat.IsMatch(phoneNumber))
            {
                Console.WriteLine("Invalid mobile number!\n");
                correct = false;
            }
        } while (!correct);

        //validate mail
        Regex mailFormat = new Regex("^[a-zA-Z0-9._%+-]+@[a\\a-zA-Z._]+\\.[a-z]{2,}\\.?[a-z]*$");
        do
        {
            correct = true;
            Console.Write("Enter Mail ID: ");
            mail = Console.ReadLine()!;
            if (!mailFormat.IsMatch(mail))
            {
                Console.WriteLine("Invalid Mail ID!\n");
                correct = false;
            }
        } while (!correct);

        //input Age
        do
        {
            Console.Write("Enter Age: ");
            correct = int.TryParse(Console.ReadLine(), out age);
            if (!correct || age < 1)
            {
                Console.WriteLine("Invalid Entry!\n");
            }
        } while (!correct || age < 1);


        decimal initialBalance;
        //input initial balance
        do
        {
            Console.Write("Enter Wallet Balance: ");
            correct = decimal.TryParse(Console.ReadLine(), out initialBalance);
            if (!correct || initialBalance < 1)
            {
                Console.WriteLine("Invalid Entry!\n");
            }
        } while (!correct || initialBalance < 1);

        //add new user object to list
        patientsList.Add(new PatientDetails { Name = patientName, FatherName = fatherName, Phone = phoneNumber, Age = age, Gender = gender, _walletBalance = initialBalance });
        Console.WriteLine("User registered successfullly, UserID is {0}", patientsList.Last().PatientID);
        // listManager.DisplayList(patientsList);

    }

    public void UserLogin()
    {
        Console.WriteLine("Welcome to Login page!\n\nEnter PatientID to proceed.");
        bool validID;

        do
        {
            Console.Write("PatienID: ");

            string userInput = Console.ReadLine()!.ToUpper();

            var loggedPatient = patientsList.Find(loggedIn => loggedIn.PatientID == userInput);

            if (loggedPatient == null)
            {
                Console.WriteLine("\nInvalid Patient ID. Please enter a valid one : ");
                validID = false;
            }
            else
            {
                validID = true;
                Console.WriteLine($"\nWelcome {loggedPatient.Name}! Please choose an option to continue.");
                LoginMenu(loggedPatient);
            }
        } while (!validID);
    }

    public void LoginMenu(PatientDetails patient)
    {

        do
        {
            Console.WriteLine("\n{0}\nSUB MENU\n{0}\n1. Book Appointment\n2. Appointment History\n3. Cancel Appointment\n4. Wallet Recharge\n5. Show Balance\n6.Exit",new String('*',60));
            switch (Console.ReadLine()!.Trim())
            {
                case "1":
                    appointment.BookAppointment(patient);
                    break;
                case "2":
                    appointment.AppoitmentHistory(patient);
                    break;
                case "3":
                    appointment.CancelAppointments(patient);
                    break;
                case "4":
                    appointment.WalletRecharge(patient);
                    break;
                case "5":
                    Console.WriteLine($"Balance is : {patient.WalletBalance}");
                    break;
                case "6":
                    return;
                default:
                    Console.WriteLine("Invalid option");
                    break;
            }

        } while (true);
    }
}
