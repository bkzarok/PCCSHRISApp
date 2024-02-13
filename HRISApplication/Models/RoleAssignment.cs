using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace HRISApplication.Models
{
    public class RoleAssignment
    {
        [ValidateNever]
        public string? RoleId { get; set; }
        [ValidateNever]
        public string? Name { get; set; }
        [ValidateNever]
        public string? Id { get; set; }
        [ValidateNever]
        public string? UserName { get; set; }
    }
}
