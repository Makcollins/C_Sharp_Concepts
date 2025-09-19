using System;

namespace OnlineHospital;

public class AppointmentDetails
{
    public string? AppointmentID { get; set; }
    public string? PatientID { get; set; }
    public string? DoctorID { get; set; }
    public DateTime AppointmentDate { get; set; }
    public string? AppointmentSlot { get; set; }
    public Status Status { get; set; }
    public decimal Fees { get; set; }
    static int counter = 501;

    public AppointmentDetails() { AppointmentID = $"AID{counter++}"; }
}
public enum Status {Booked,Cancelled}