using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
namespace HRISApplication.Models;

public partial class Assignment
{
    public int Id { get; set; }

    public string Unit { get; set; } = null!;
    [DataType(DataType.Date)]
    public DateTime PeriodFrom { get; set; }
    [DataType(DataType.Date)]
    public DateTime PeriodTo { get; set; }

    public string PositionHeld { get; set; } = null!;

    public string MilitaryNo { get; set; } = null!;
    [ValidateNever]
    [JsonIgnore]

    public virtual PersonalDetail MilitaryNoNavigation { get; set; } = null!;
}
