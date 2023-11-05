using System.ComponentModel.DataAnnotations;

namespace PamwL3.Models
{
    public class HotelBooking
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="Room number is necessary")]
        [Range(1, 1000, ErrorMessage = "Room number must be between 1 and 1000")]
        public int RoomNumber { get; set; }

        [Required(ErrorMessage = "Guest name is necessary")]
        [StringLength(50, ErrorMessage = "Guest name must be between 1 and 50 characters")]
        public string GuestName { get; set; }
    }
}
