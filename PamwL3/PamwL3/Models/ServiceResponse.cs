namespace PamwL3.Models
{
    public class ServiceResponse
    {
        public HotelBooking Data { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
        public List<string> Errors { get; set; }
    }
}
