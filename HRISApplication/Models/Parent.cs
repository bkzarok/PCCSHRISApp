using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace HRISApplication.Models;

public partial class Parent
{
    public int Id { get; set; }

    public string Parent1 { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Occupation { get; set; } = null!;

    public bool Dependency { get; set; }

    public string HelpProvided { get; set; } = null!;

    public string MilitaryNo { get; set; } = null!;
    [JsonIgnore]
    [ValidateNever]
    public virtual PersonalDetail MilitaryNoNavigation { get; set; } = null!;
}
