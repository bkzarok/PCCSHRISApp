using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;

namespace HRISApplication.Models;

public partial class Imprisonment
{
    public int Id { get; set; }

    public bool Imprisoned { get; set; }

    public string Place { get; set; } = null!;

    public string ForHowLong { get; set; } = null!;

    public bool Conviction { get; set; }

    public string ExplainTheReason { get; set; } = null!;

    public string MilitaryNo { get; set; } = null!;
    [ValidateNever]
    public virtual PersonalDetail MilitaryNoNavigation { get; set; } = null!;
}
