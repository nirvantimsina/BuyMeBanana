using System.ComponentModel.DataAnnotations;

namespace Nudge.Application.Models.Card.Request
{
    public class AssignCardRequestModel
    {
        public string? Flag { get; set; }
        [Required]
        public int UserId { get; set; }
    }
}




