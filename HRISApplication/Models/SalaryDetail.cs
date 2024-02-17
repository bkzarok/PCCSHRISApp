using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace HRISApplication.Models;

public partial class SalaryDetail
{
    public int Id { get; set; }

    public int Grade { get; set; }

    [DataType(DataType.Currency)]
    public decimal BasicPay { get; set; }
    [DataType(DataType.Currency)]
    public decimal Cola { get; set; }
    [DataType(DataType.Currency)]
    public decimal ResponsibiltyAllowance { get; set; }
    [DataType(DataType.Currency)]
    public decimal RepresentationAllowance { get; set; }

    [DataType(DataType.Currency)]
    public decimal HouseAllowance { get; set; }
    [DataType(DataType.Currency)]
    public decimal GrossTotal { get; set; }
    [DataType(DataType.Currency)]
    public decimal Pit { get; set; }
    [DataType(DataType.Currency)]
    public decimal Pension { get; set; }
    [DataType(DataType.Currency)]
    public decimal TotalDeduction { get; set; }
    [DataType(DataType.Currency)]
    public decimal NetPay { get; set; }

    public string MilitaryNo { get; set; } = null!;

    [JsonIgnore]
    [ValidateNever]
    public virtual PersonalDetail MilitaryNoNavigation { get; set; } = null!;
}
