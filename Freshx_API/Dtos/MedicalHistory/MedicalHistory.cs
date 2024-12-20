namespace Freshx_API.Dtos.MedicalHistory
{
    public class MedicalHistoryDto
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public string Condition { get; set; }
        public string Treatment { get; set; }
        public DateTime Date { get; set; }
    }
}
