using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HRISApplication.Models;

public partial class HealthCondition
{
    public int Id { get; set; }

    public bool HaveAhealthCondition { get; set; }

    public string IfYesExplain { get; set; } = null!;

    public string DegreeOfHealthProblem { get; set; } = null!;
    [DataType(DataType.Date)]
    public DateTime WhenStarted { get; set; }

    public string MilitaryNo { get; set; } = null!;
    [ValidateNever]
    public virtual PersonalDetail MilitaryNoNavigation { get; set; } = null!;
}
