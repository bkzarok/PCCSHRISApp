using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace HRISApplication.Models;

public partial class Child
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;
   
    [DataType(DataType.Date)]
    public DateTime DateOfBirth { get; set; }

    public string Occupation { get; set; } = null!;

    public string MilitaryNo { get; set; } = null!;
    [ValidateNever]
    [JsonIgnore]

    public virtual PersonalDetail MilitaryNoNavigation { get; set; } = null!;
}
