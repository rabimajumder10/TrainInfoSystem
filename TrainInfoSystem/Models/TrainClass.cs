namespace TrainInfoSystem.Models
{
    public class TrainClass
    {
        public int TrainId { get; set; }
        public int ClassId { get; set; }
        public Train Train { get; set; }
        public Class Class { get; set; }
    }
}
