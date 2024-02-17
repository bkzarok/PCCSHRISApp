using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace HRISApplication.Models;

public partial class Spouse
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Type { get; set; } = null!;

    public string State { get; set; } = null!;

    public string County { get; set; } = null!;

    public string Occupation { get; set; } = null!;

    public int TelephoneNo { get; set; }

    public string MilitaryNo { get; set; } = null!;
    [JsonIgnore]
    [ValidateNever]
    public virtual PersonalDetail MilitaryNoNavigation { get; set; } = null!;
}
