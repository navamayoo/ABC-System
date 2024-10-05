using System.ComponentModel.DataAnnotations;

namespace Booking.DTO.Country
{
    public class UpdateCountryDTO
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [MaxLength(5)]
        public string ShortName { get; set; }
        [Required]
        [MaxLength(3)]
        public string CountryCode { get; set; }
    }
}
