using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace HRISApplication.Models;

public partial class Address
{
    public int Id { get; set; }

    public string Country { get; set; } = null!;

    public string State { get; set; } = null!;

    public string Counuty { get; set; } = null!;

    public string Payam { get; set; } = null!;

    public string Boma { get; set; } = null!;

    public string MilitaryNo { get; set; } = null!;
    [ValidateNever]
    [JsonIgnore]
    public virtual PersonalDetail MilitaryNoNavigation { get; set; } = null!;
}
