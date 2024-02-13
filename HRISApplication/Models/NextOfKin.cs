using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;

namespace HRISApplication.Models;

public partial class NextOfKin
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Occupation { get; set; } = null!;

    public string TelephoneNo { get; set; } = null!;

    public string MilitaryNo { get; set; } = null!;
    [ValidateNever]
    public virtual PersonalDetail MilitaryNoNavigation { get; set; } = null!;
}
