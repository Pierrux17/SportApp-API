namespace SportAPI.Models
{
    public class TrainingLog
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int Id_person { get; set; }
        public int Id_training { get; set; }
    }
}
