namespace Hospital.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public int HospitalInfoId { get; set; }
        public HospitalInfo Hospital { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;
    }
}