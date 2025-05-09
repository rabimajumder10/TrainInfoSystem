namespace TrainInfoSystem.Models
{
    public class Fare
    {
        public int FareId { get; set; }
        public int TrainId { get; set; }
        public int ClassId { get; set; }
        public decimal FareAmount { get; set; }
        public Train Train { get; set; }
        public Class Class { get; set; }
    }
}
