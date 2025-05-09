namespace TrainInfoSystem.Models
{
    public class Train
    {
        public int TrainId { get; set; }
        public string TrainName { get; set; }
        public string TrainNumber { get; set; }
        public List<TrainClass> TrainClasses { get; set; }
    }
}
