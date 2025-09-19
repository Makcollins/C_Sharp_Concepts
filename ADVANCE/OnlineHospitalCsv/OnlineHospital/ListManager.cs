using System;
using System.Globalization;
using System.Runtime.Intrinsics.Arm;
using System.Threading.Tasks;
using System.Windows.Markup;
using CsvHelper;

namespace OnlineHospital;

public class ListManager
{
    //files paths
    static string _doctorsCSV = "CSVFiles/doctors.csv";
    static string _slotsCSV = "CSVFiles/doctors_slots.csv";
    static string _patientsCSV = "CSVFiles/patients.csv";
    static string _appointmentsCSV = "CSVFiles/appointments.csv";

    //Create CSVfiles directory
    public static void CreateDirectory()
    {
        if (!Directory.Exists("CSVFiles"))
        {
            Directory.CreateDirectory("CSVFiles");
        }
    }

    public static void CreateCSVFiles()
    {
        if(!File.Exists(_appointmentsCSV))
        File.Create(_appointmentsCSV);
        if(!File.Exists("CSVFiles/doctors.csv"))
        File.Create("CSVFiles/doctors.csv");
        if(!File.Exists(_patientsCSV))
        File.Create(_patientsCSV);
        if(!File.Exists(_slotsCSV))
        File.Create(_slotsCSV);
    }

    // static List<string> names = ["Collins", "Antony", "Felix"];

    // public static async Task AppendNamesToCsv()
    // {
    //     // string name = String.Join("", names);
    //     await File.AppendAllLinesAsync(_doctorsCSV, names);

    // }
    // public static async Task WriteNamesToCsv()
    // {
    //    await File.WriteAllTextAsync(_doctorsCSV, "Douglas");
    // }


    // public static async Task ReadFromDoctorsCSV()
    // {
    //     // string doctorsList = File.ReadAllText(_doctorsCSV);

    //     Console.WriteLine(await File.ReadAllTextAsync(_doctorsCSV));
    // }

    public static void DeleteFiles()
    {
        if (File.Exists(_doctorsCSV))
            File.Delete(_doctorsCSV);
        File.Delete(_appointmentsCSV);
        File.Delete(_slotsCSV);
        File.Delete(_patientsCSV);

        System.Console.WriteLine("records deleted successfully!");
    }

    //PRINT LISTS
    public static void DisplayList(List<AppointmentDetails> appointments)
    {
        Console.WriteLine($"\n{new String('-', 90)}\n{"AppointmentID",-16} {"PatientID",-10} {"DoctorID",-10} {"AppointmentDate",-16} {"AppointmentSlot",-16} {"Status",-10} {"Fees",-10}\n{new String('-', 90)}");
        appointments.ForEach(item => Console.WriteLine($"{item.AppointmentID,-16} {item.PatientID,-10} {item.DoctorID,-10} {item.AppointmentDate.ToShortDateString(),-16} {item.AppointmentSlot,-16} {item.Status,-10} {item.Fees,-10}"));
        Console.WriteLine(new String('-', 90) + "\n");
    }

    public static void DisplayList(List<DoctorDetails> doctors)
    {
        Console.WriteLine($"\n{new String('-', 100)}\n{"DoctorID",-10} {"Name",-10} {"FatherName",-10} {"Gender",-10} {"Phone",-10} {"Age",-10} {"Experience",-11} {"Specialization",-15} {"Fees",-10}\n{new String('-', 100)}");
        doctors.ForEach(item => Console.WriteLine($"{item.DoctorID,-10} {item.Name,-10} {item.FatherName,-10}  {item.Gender,-10} {item.Phone,-10} {item.Age,-10} {item.Experience,-11} {item.Specialization,-15} {item.Fees,-10}"));
        Console.WriteLine(new String('-', 100) + "\n");
    }

    public static void DisplayList(List<PatientDetails> patients)
    {
        Console.WriteLine($"\n{new String('-', 70)}\n{"PatientID",-10} {"Name",-10} {"FatherName",-10} {"Age",-10} {"Gender",-10} {"WalletBalance",-13}\n{new String('-', 70)}");
        patients.ForEach(item => Console.WriteLine($"{item.PatientID,-10} {item.Name,-10} {item.FatherName,-10} {item.Age,-10} {item.Gender,-10} {item.WalletBalance,-13}"));
        Console.WriteLine(new String('-', 70) + "\n");
    }
    public static void DisplayList(List<SlotDetails> availableSlots)
    {
        Console.WriteLine($"\n{new String('-', 35)}\n{"DoctorID",-10} {"SlotID",-10} {"SlotTime",-10}\n{new String('-', 35)}");
        availableSlots.ForEach(item => Console.WriteLine($"{item.DoctorID,-10} {item.SlotID,-10} {item.SlotTime,-10}"));
        Console.WriteLine(new String('-', 35) + "\n");
    }

    //Initial records

    static List<DoctorDetails> doctors = new()
        {
            new DoctorDetails{Name ="John",FatherName = "Joe",Gender = Gender.Male, Phone = "89877", Age = 33, Experience = 20, Specialization = "General", Fees = 200},
            new DoctorDetails{Name ="Saravanan",FatherName = "Mani",Gender = Gender.Male, Phone = "98776", Age = 39, Experience = 30, Specialization = "Heart", Fees = 500},
            new DoctorDetails{Name ="Kavi",FatherName = "Karthi",Gender = Gender.Male, Phone = "77886", Age = 34, Experience = 50, Specialization = "Ortho", Fees = 100}
        };

    //Add initial doctors list to _doctorsCSV
    public static void AppendDoctorsToCSV()
        => doctors.ForEach(doctor => File.AppendAllText(_doctorsCSV, $"{doctor.DoctorID},{doctor.Name},{doctor.FatherName},{doctor.Gender},{doctor.Phone},{doctor.Age},{doctor.Experience},{doctor.Specialization},{doctor.Fees}\n"));

    public static List<DoctorDetails> ReadDoctorsFromCSV()
    {
        List<DoctorDetails> doctors = new();
        string[] lines = File.ReadAllLines(_doctorsCSV);

        foreach (var line in lines)
        {
            string[] items = line.Split(',');
            doctors.Add(new DoctorDetails { DoctorID = items[0], Name = items[1], FatherName = items[2], Gender = Enum.Parse<Gender>(items[3]), Phone = items[4], Age = int.Parse(items[5]), Experience = int.Parse(items[6]), Specialization = items[7], Fees = Decimal.Parse(items[8]) });
        }
        return doctors;
    }
    static List<SlotDetails> slots = new()
        {
            new SlotDetails{DoctorID = "DID301", SlotID ="SL101", SlotTime = "6.00-6.30"},
            new SlotDetails{DoctorID = "DID301", SlotID ="SL102", SlotTime = "6.30-7.00"},
            new SlotDetails{DoctorID = "DID301", SlotID ="SL103", SlotTime = "7.00-7.30"},
            new SlotDetails{DoctorID = "DID301", SlotID ="SL104", SlotTime = "7.30-8.00"},
            new SlotDetails{DoctorID = "DID301", SlotID ="SL105", SlotTime = "8.00-8.30"},
            new SlotDetails{DoctorID = "DID301", SlotID ="SL106", SlotTime = "8.30-9.00"},
            new SlotDetails{DoctorID = "DID302", SlotID ="SL101", SlotTime = "6.00-6.30"},
            new SlotDetails{DoctorID = "DID302", SlotID ="SL102", SlotTime = "6.30-7.00"},
            new SlotDetails{DoctorID = "DID302", SlotID ="SL103", SlotTime = "7.00-7.30"},
            new SlotDetails{DoctorID = "DID302", SlotID ="SL104", SlotTime = "7.30-8.00"},
            new SlotDetails{DoctorID = "DID303", SlotID ="SL104", SlotTime = "7.30-8.00"},
            new SlotDetails{DoctorID = "DID303", SlotID ="SL105", SlotTime = "8.00-8.30"},
            new SlotDetails{DoctorID = "DID303", SlotID ="SL106", SlotTime = "8.30-9.00"}
        };

    //add initial slots list to _doctorsCSV 
    public static void AppendSlotsToCsv()
     => slots.ForEach(s => File.AppendAllText(_slotsCSV, $"{s.SlotID},{s.DoctorID},{s.SlotID},{s.SlotTime}\n"));

    public static List<SlotDetails> ReadSLotsFromCSV()
    {
        var csvreader = new CsvReader(new StreamReader(_slotsCSV), CultureInfo.InvariantCulture);
        return csvreader.GetRecords<SlotDetails>().ToList();
    }
    static List<PatientDetails> patients = new()
        {
            new PatientDetails{Name ="Arun", FatherName ="Mani", Phone = "75757", Age=45,Gender = Gender.Male, _walletBalance =1000},
             new PatientDetails{Name ="Kumar", FatherName ="Suresh", Phone = "57755", Age=50,Gender = Gender.Male, _walletBalance =500},
              new PatientDetails{Name ="Malar", FatherName ="Ganesh", Phone = "58855", Age=30,Gender = Gender.Female, _walletBalance =100},
               new PatientDetails{Name ="Selvi", FatherName ="Pandi", Phone = "58858", Age=20,Gender = Gender.Female, _walletBalance =50}
        };
    //add initial patients list to _patientsCSV
    public static void AppendPatientsToCSV()
        => patients.ForEach(p => File.AppendAllText(_patientsCSV, $"{p.PatientID},{p.Name},{p.FatherName},{p.Phone},{p.Age},{p.Gender},{p.WalletBalance}\n"));

    public static List<PatientDetails> ReadPatientsFromCSV()
    {
        var csvreader = new CsvReader(new StreamReader(_patientsCSV), CultureInfo.InvariantCulture);
        return csvreader.GetRecords<PatientDetails>().ToList();
    }

    static List<AppointmentDetails> appointments = new()
        {
            new AppointmentDetails { PatientID = "PID1001", DoctorID = "DID301", AppointmentDate = Convert.ToDateTime("27/10/2025"), AppointmentSlot = "SL101", Status = Status.Booked, Fees = 200 },
            new AppointmentDetails { PatientID = "PID1002", DoctorID = "DID302", AppointmentDate = Convert.ToDateTime("27/04/2022"), AppointmentSlot = "SL102", Status = Status.Booked, Fees = 500 },
            new AppointmentDetails { PatientID = "PID1003", DoctorID = "DID303", AppointmentDate = Convert.ToDateTime("27/04/2022"), AppointmentSlot = "SL104", Status = Status.Booked, Fees = 200 },
            new AppointmentDetails { PatientID = "PID1001", DoctorID = "DID303", AppointmentDate = Convert.ToDateTime("27/10/2025"), AppointmentSlot = "SL106", Status = Status.Booked, Fees = 200 },
        };

    //add initial appointments list to _appointmentsCSV
    public static void AppendAppointmentsToCSV()
        => appointments.ForEach(a => File.AppendAllText(_appointmentsCSV, $"{a.AppointmentID},{a.PatientID},{a.DoctorID},{a.AppointmentDate.ToShortDateString()},{a.AppointmentSlot},{a.Status},{a.Fees}\n"));

    public static List<AppointmentDetails> ReadAppointmentsFromCSV()
    {
        var csvreader = new CsvReader(new StreamReader(_appointmentsCSV), CultureInfo.InvariantCulture);
        return csvreader.GetRecords<AppointmentDetails>().ToList();
    }

    public static void WriteWithCSVHelper()
    {
         var csvwriter = new CsvWriter(new StreamWriter(_doctorsCSV), CultureInfo.InvariantCulture);

            csvwriter.WriteRecords(doctors);

            csvwriter.Dispose();
        
    }
}
