namespace DoctorAppointmentApi.Models
{
    public class DoctorAppointment
    {
        public int Id { get; set; }
        public string PatientName { get; set; }
        public string DoctorName { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string Details { get; set; }  
    }
}