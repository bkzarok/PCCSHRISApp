using HRISApplication.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace HRISApplication.Models;

public partial class PersonalFile
{
    [ValidateNever]
    public int Id { get; set; }

    [ValidateNever]
    public string? Name { get; set; }

    [ValidateNever]
    public string Location { get; set; } = null!;

    [ValidateNever]
    [NotMapped]
    public IFormFile FormFile { get; set; } = null!;

    [ValidateNever]
    public string CreateBy { get; set; } = null!;


    [ValidateNever]
    public DateTime CreatedOn { get; set; }

    public string MilitaryNo { get; set; } = null!;

    [JsonIgnore]
    [ValidateNever]
    public virtual PersonalDetail MilitaryNoNavigation { get; set; } = null!;
}
