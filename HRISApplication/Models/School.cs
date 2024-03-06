using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace HRISApplication.Models;

public partial class School
{
    public int Id { get; set; }

    public string SchoolLevel { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Place { get; set; } = null!;
    [DataType(DataType.Date)]
    public DateTime PeriodFrom { get; set; }
    [DataType(DataType.Date)]
    public DateTime PeriodTo { get; set; }

    public string FieldOfTraining { get; set; } = null!;

    public string CertificateAcquired { get; set; } = null!;

    public string MilitaryNo { get; set; } = null!;
    [JsonIgnore]
    [ValidateNever]
    public virtual PersonalDetail MilitaryNoNavigation { get; set; } = null!;
}
