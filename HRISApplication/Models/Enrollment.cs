using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HRISApplication.Models;

public partial class Enrollment
{
    public int Id { get; set; }
    [DataType(DataType.Date)]
    public DateTime DateOfEnrollment { get; set; }

    public string PlaceOfEnrollment { get; set; } = null!;

    public bool ServiceOutsideSspdf { get; set; }
    [DataType(DataType.Date)]
    public DateTime PeriodFrom { get; set; }

    [DataType(DataType.Date)]
    public DateTime PeriodTo { get; set; }

    public string MilitaryNo { get; set; } = null!;
    [ValidateNever]
    public virtual PersonalDetail MilitaryNoNavigation { get; set; } = null!;
}
