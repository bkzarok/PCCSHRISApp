using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HRISApplication.Models;

public partial class Promotion
{
    public int Id { get; set; }

    public string SoldierRank { get; set; } = null!;
    [DataType(DataType.Date)]
    public DateTime DateOfPromotion { get; set; }

    public string MilitaryNo { get; set; } = null!;
    [ValidateNever]
    public virtual PersonalDetail MilitaryNoNavigation { get; set; } = null!;
}
