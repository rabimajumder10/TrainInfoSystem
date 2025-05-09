namespace TrainInfoSystem.Models
{
    public class PNR
    {
        public int PNRId { get; set; }
        public string PNRNumber { get; set; }
        public string Coach { get; set; }
        public string BerthNumber { get; set; }
        public string Status { get; set; }
        public int BookingId { get; set; }
        public Booking Booking { get; set; }
    }
}
