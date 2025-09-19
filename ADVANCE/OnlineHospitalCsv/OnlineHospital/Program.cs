using System;
using System.Threading.Tasks;

namespace OnlineHospital
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create CSVfiles directory
            ListManager.CreateDirectory();
            ListManager.CreateCSVFiles();
            // await ListManager.AppendNamesToCsv();

            // await ListManager.ReadFromDoctorsCSV();

            // await ListManager.WriteNamesToCsv();
            // ListManager.DeleteFiles();
            // ListManager.WriteWithCSVHelper();

            // ListManager.AppendDoctorsToCSV();

            List<DoctorDetails> doctors = ListManager.ReadDoctorsFromCSV();
            ListManager.DisplayList(doctors);
            // ListManager.AppendSlotsToCsv();
            // ListManager.AppendAppointmentsToCSV();
            // ListManager.AppendPatientsToCSV();

            // AuthenticationManager authentication = new();

            //  Console.WriteLine("\n{0}\nONLINE HOSPITAL MANAGEMENT\n{0}\n", new String('*', 60));
            // do
            // {
            //     Console.WriteLine("\n{0}\nMAIN MENU\n{0}", new String('.', 60));
            //     Console.WriteLine("\n1. Patient Registration\n2. User Login\n3. Exit");

            //     int.TryParse(Console.ReadLine()!.Trim(), out int choice);

            //     switch (choice)
            //     {
            //         case 1:
            //             authentication.Registration();
            //             break;
            //         case 2:
            //             authentication.UserLogin();
            //             break;
            //         case 3:
            //             return;

            //         default:
            //             Console.WriteLine("invalid choice");
            //             break;
            //     }
            // } while (true);
        }
    }
}