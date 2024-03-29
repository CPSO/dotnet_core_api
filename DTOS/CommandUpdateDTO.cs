using System.ComponentModel.DataAnnotations;

namespace coreapi.DTOS
{
    public class CommandUpdateDTO
    {
        [Required]
        [MaxLength(250)]
        public string HowTo { get; set; }

        [Required]
        public string Line { get; set; }

        [Required]
        public string Platform { get; set; }

    }

}