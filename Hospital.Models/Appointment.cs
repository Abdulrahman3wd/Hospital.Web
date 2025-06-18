namespace Hospital.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public string Number { get; set; } = null!;
        public string Type { get; set; } = null!;
        public DateTime CreatedDate { get; set; }
        public string Descreption { get; set; } = null!;
        public ApplicationUser Doctor { get; set; } = null!;
        public ApplicationUser Patient { get; set; } = null!;
    }
}