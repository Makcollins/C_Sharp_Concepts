using System;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;

namespace OnlineHospital;

public class AppointmentManager
{
    // static ListManager ListManager = new();
    List<DoctorDetails> doctors = ListManager.ReadDoctorsFromCSV();
    List<SlotDetails> availableSlots = ListManager.ReadSLotsFromCSV();
    List<AppointmentDetails> appointments =ListManager.ReadAppointmentsFromCSV();
    public void BookAppointment(PatientDetails patient)
    {
        ListManager.DisplayList(doctors);
        DoctorDetails selectedDoctor;
        DateTime enteredDate;

        Console.Write("Enter the DoctorID : ");

        do
        {
            string userInput = Console.ReadLine()!.ToUpper().Trim();
            selectedDoctor = doctors.Find(selected => selected.DoctorID == userInput)!;
            if (selectedDoctor == null)
            {
                Console.Write("\nInvalid Doctor ID. Please enter a correct DoctorID : ");
            }

        } while (selectedDoctor == null);

        bool validDate;

        Console.Write($"\nEnter AppointmentDate (Format : {DateTime.Now.ToShortDateString()}) : ");
        do
        {
            validDate = DateTime.TryParse(Console.ReadLine()!.Trim(), out enteredDate);
            if (!validDate)
            {
                Console.Write("\nInvalid Format! Enter a valid date : ");
            }
        } while (!validDate);

        var doctorSlots = availableSlots.FindAll(slots => slots.DoctorID == selectedDoctor!.DoctorID).ToList();
        ListManager.DisplayList(doctorSlots);

        Console.Write("\nEnter SlotID : ");
        SlotDetails pickedSlot;

        do
        {
            string slotInput = Console.ReadLine()!.ToUpper().Trim();

            pickedSlot = doctorSlots.Find(slot => slot.SlotID == slotInput)!;
            if (pickedSlot == null)
            {
                Console.WriteLine("Invalid Slot ID. Please input a SlotID that is availble in the List above : ");
            }
        } while (pickedSlot == null);

        var doctorAvailable = appointments.Where(x => x.DoctorID == selectedDoctor.DoctorID).Any(x => x.AppointmentDate == enteredDate && x.AppointmentSlot == pickedSlot.SlotID && x.Status == Status.Booked);


        if (!doctorAvailable && enteredDate >= DateTime.Now)
        {
            var eligible = selectedDoctor.Fees <= patient.WalletBalance ? true : false;
            if (eligible)
            {
                patient.DeductBalance(selectedDoctor.Fees);
                AppointmentDetails newAppointment = new()
                {
                    PatientID = patient.PatientID,
                    DoctorID = selectedDoctor.DoctorID,
                    AppointmentDate = enteredDate,
                    AppointmentSlot = pickedSlot.SlotID,
                    Status = Status.Booked,
                    Fees = selectedDoctor.Fees
                };

                appointments.Add(newAppointment);
                Console.WriteLine($"Your appoitment is booked and Appointment ID is : {newAppointment.AppointmentID}\n");
            }
            else { Console.WriteLine("Sorry, you have Insufficient balance! "); }
        }
        else if (doctorAvailable) { Console.WriteLine($"Dr. {selectedDoctor.Name} is not available on {enteredDate.ToShortDateString()} from {pickedSlot.SlotTime}\n"); }
        else { Console.WriteLine("Appointment not successful!\n"); }
    }

    public void AppoitmentHistory(PatientDetails patient)
    {
        if (appointments.Any(history => history.PatientID == patient.PatientID))
            ListManager.DisplayList(appointments.FindAll(history => history.PatientID == patient.PatientID));
        else
            Console.WriteLine("There is no appointments");
    }

    public void CancelAppointments(PatientDetails patient)
    {
        var bookedAppointments = appointments.FindAll(history => history.PatientID == patient.PatientID && history.Status == Status.Booked && history.AppointmentDate > DateTime.Now);
        if (!bookedAppointments.Any(x => x.PatientID == patient.PatientID))
        {
            Console.WriteLine("There is no appointments");
        }
        else
        {
            ListManager.DisplayList(bookedAppointments);
            Console.WriteLine("Enter AppointmentID to cancel : ");
            string userInput = Console.ReadLine()!.ToUpper().Trim();

            var pickedAppointment = bookedAppointments.Find(picked => picked.AppointmentID == userInput);
            if (pickedAppointment == null)
            {
                Console.WriteLine("Invalid appointment ID");
            }
            else
            {
                pickedAppointment.Status = Status.Cancelled;
                patient.Recharge(pickedAppointment.Fees);
                Console.WriteLine($"AppointmentID {pickedAppointment.AppointmentID} is cancelled");
            }
        }
    }

    public void WalletRecharge(PatientDetails patient)
    {
        Console.WriteLine("Enter recharge amount: ");
        decimal amount;
        if (!decimal.TryParse(Console.ReadLine(), out amount) || amount < 1)
        {
            Console.WriteLine("Invalid Entry!");
        }
        else
        {
            patient.Recharge(amount);
            Console.WriteLine($"Successfully recharged {amount}, Balance is : {patient.WalletBalance}");
        }
    }

}
