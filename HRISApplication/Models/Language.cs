using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;

namespace HRISApplication.Models;

public partial class Language
{
    public int Id { get; set; }

    public string Type { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string FluencyLevel { get; set; } = null!;

    public string MilitaryNo { get; set; } = null!;
    [ValidateNever]
    public virtual PersonalDetail MilitaryNoNavigation { get; set; } = null!;
}
