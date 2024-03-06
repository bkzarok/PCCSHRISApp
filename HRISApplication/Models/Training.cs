using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace HRISApplication.Models;

public partial class Training
{
    public int Id { get; set; }

    public string TrainingType { get; set; } = null!;

    public string TrainingCenter { get; set; } = null!;

    public string Place { get; set; } = null!;
    [DataType(DataType.Date)]
    public DateTime PeriodFrom { get; set; }
    [DataType(DataType.Date)]
    public DateTime PeriodTo { get; set; }

    public string MilitaryNo { get; set; } = null!;
    [ValidateNever]
    [JsonIgnore]
    public virtual PersonalDetail MilitaryNoNavigation { get; set; } = null!;
}
