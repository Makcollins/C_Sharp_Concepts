using System;

namespace OnlineHospital;

public class ListManager
{
    public List<DoctorDetails> DoctorsList()
    {
        List<DoctorDetails> doctors = new()
        {
            new DoctorDetails{Name ="John",FatherName = "Joe",Gender = Gender.Male, Phone = "89877", Age = 33, Experience = 20, Specialization = "General", Fees = 200},
            new DoctorDetails{Name ="Saravanan",FatherName = "Mani",Gender = Gender.Male, Phone = "98776", Age = 39, Experience = 30, Specialization = "Heart", Fees = 500},
            new DoctorDetails{Name ="Kavi",FatherName = "Karthi",Gender = Gender.Male, Phone = "77886", Age = 34, Experience = 50, Specialization = "Ortho", Fees = 100}
        };
        return doctors;
    }

    public List<SlotDetails> DoctorsSlots()
    {
        List<SlotDetails> slots = new()
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
        return slots;
    }

    public List<PatientDetails> PatientsList()
    {
        List<PatientDetails> patients = new()
        {
            new PatientDetails{Name ="Arun", FatherName ="Mani", Phone = "75757", Age=45,Gender = Gender.Male, _walletBalance =1000},
             new PatientDetails{Name ="Kumar", FatherName ="Suresh", Phone = "57755", Age=50,Gender = Gender.Male, _walletBalance =500},
              new PatientDetails{Name ="Malar", FatherName ="Ganesh", Phone = "58855", Age=30,Gender = Gender.Female, _walletBalance =100},
               new PatientDetails{Name ="Selvi", FatherName ="Pandi", Phone = "58858", Age=20,Gender = Gender.Female, _walletBalance =50}
        };
        return patients;
    }

    public List<AppointmentDetails> AppointmentsList()
    {
        List<AppointmentDetails> appointments = new()
        {
            new AppointmentDetails{PatientID = "PID1001", DoctorID = "DID301",AppointmentDate = Convert.ToDateTime("27/10/2025"),AppointmentSlot = "SL101",Status = Status.Booked,Fees = 200},
            new AppointmentDetails{PatientID = "PID1002", DoctorID = "DID302",AppointmentDate = Convert.ToDateTime("27/04/2022"),AppointmentSlot = "SL102",Status = Status.Booked,Fees = 500},
            new AppointmentDetails{PatientID = "PID1003", DoctorID = "DID303",AppointmentDate = Convert.ToDateTime("27/04/2022"),AppointmentSlot = "SL104",Status = Status.Booked,Fees = 200},
            new AppointmentDetails{PatientID = "PID1001", DoctorID = "DID303",AppointmentDate = Convert.ToDateTime("27/10/2025"),AppointmentSlot = "SL106",Status = Status.Booked,Fees = 200},
        };
        return appointments;
    }
    public void DisplayList(List<AppointmentDetails> appointments)
    {
        Console.WriteLine($"\n{new String('-', 90)}\n{"AppointmentID",-16} {"PatientID",-10} {"DoctorID",-10} {"AppointmentDate",-16} {"AppointmentSlot",-16} {"Status",-10} {"Fees",-10}\n{new String('-', 90)}");
        appointments.ForEach(item => Console.WriteLine($"{item.AppointmentID,-16} {item.PatientID,-10} {item.DoctorID,-10} {item.AppointmentDate.ToShortDateString(),-16} {item.AppointmentSlot,-16} {item.Status,-10} {item.Fees,-10}"));
        Console.WriteLine(new String('-', 90) + "\n");
    }

    public void DisplayList(List<DoctorDetails> doctors)
    {
        Console.WriteLine($"\n{new String('-', 100)}\n{"DoctorID",-10} {"Name",-10} {"FatherName",-10} {"Gender",-10} {"Phone",-10} {"Age",-10} {"Experience",-11} {"Specialization",-15} {"Fees",-10}\n{new String('-', 100)}");
        doctors.ForEach(item => Console.WriteLine($"{item.DoctorID,-10} {item.Name,-10} {item.FatherName,-10}  {item.Gender,-10} {item.Phone,-10} {item.Age,-10} {item.Experience,-11} {item.Specialization,-15} {item.Fees,-10}"));
        Console.WriteLine(new String('-', 100) + "\n");
    }

    public void DisplayList(List<PatientDetails> patients)
    {
        Console.WriteLine($"\n{new String('-', 70)}\n{"PatientID",-10} {"Name",-10} {"FatherName",-10} {"Age",-10} {"Gender",-10} {"WalletBalance",-13}\n{new String('-', 70)}");
        patients.ForEach(item => Console.WriteLine($"{item.PatientID,-10} {item.Name,-10} {item.FatherName,-10} {item.Age,-10} {item.Gender,-10} {item.WalletBalance,-13}"));
        Console.WriteLine(new String('-', 70) + "\n");
    }
    public void DisplayList(List<SlotDetails> availableSlots)
    {
        Console.WriteLine($"\n{new String('-', 35)}\n{"DoctorID",-10} {"SlotID",-10} {"SlotTime",-10}\n{new String('-', 35)}");
        availableSlots.ForEach(item => Console.WriteLine($"{item.DoctorID,-10} {item.SlotID,-10} {item.SlotTime,-10}"));
        Console.WriteLine(new String('-', 35) + "\n");
    }
}
