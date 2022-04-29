using System.ComponentModel.DataAnnotations;

namespace Birthday_Card_generator.Models
{
    public class BirthdayCard
    {
        [Required(ErrorMessage = "Please enter From")]
        public string From { get; set; }

        [Required(ErrorMessage = "Please enter To")]
        public string To { get; set; }

        [Required(ErrorMessage = "Please enter Messsage")]
        public string Message { get; set; }
    }
}
