using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HRISApplication.Models;

public partial class Battle
{
    public int Id { get; set; }
    [DataType(DataType.Date)]
    public DateTime DateOfBattle { get; set; }

    public string PlaceOfBattle { get; set; } = null!;

    public bool InjurySustained { get; set; }

    public string TypeOfInjury { get; set; } = null!;

    public string MilitaryNo { get; set; } = null!;
    [ValidateNever]
    public virtual PersonalDetail MilitaryNoNavigation { get; set; } = null!;
}
