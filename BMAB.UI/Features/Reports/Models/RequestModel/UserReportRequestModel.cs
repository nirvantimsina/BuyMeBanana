using BMAB.UI.Shared.Security;
using System.ComponentModel.DataAnnotations;

namespace BMAB.UI.Features.Reports.Models.RequestModel
{
    public class UserReportRequestModel
    {
        [Required(ErrorMessage = "User ID is required.")]
        public int? UserId { get; set; }
    }
}








