using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRISApplication.Models;

public partial class PersonalDetail
{
    public string MilitaryNo { get; set; } = null!;

    [ValidateNever]
    public byte[] ProfilePicture { get; set; } = null!;


    [ValidateNever]
    [NotMapped]
    
    public IFormFile FormFile { get; set; } = null!;

    public string SoldierRank { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string MiddleName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    [DataType(DataType.Date)]
    public DateTime DateOfBirth { get; set; }

    public string BloodGroup { get; set; } = null!;

    public string Ethnicity { get; set; } = null!;

    public int ShieldNo { get; set; }

    public bool Gender { get; set; }

    public string MaritalStatus { get; set; } = null!;

    public virtual ICollection<Assignment> Assignments { get; set; } = new List<Assignment>();

    public virtual ICollection<Battle> Battles { get; set; } = new List<Battle>();

    public virtual ICollection<Child> Children { get; set; } = new List<Child>();

    public virtual ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();

    public virtual ICollection<HealthCondition> HealthConditions { get; set; } = new List<HealthCondition>();

    public virtual ICollection<Imprisonment> Imprisonments { get; set; } = new List<Imprisonment>();

    public virtual ICollection<Language> Languages { get; set; } = new List<Language>();

    public virtual ICollection<NextOfKin> NextOfKins { get; set; } = new List<NextOfKin>();

    public virtual ICollection<Parent> Parents { get; set; } = new List<Parent>();

    public virtual ICollection<Promotion> Promotions { get; set; } = new List<Promotion>();

    public virtual ICollection<School> Schools { get; set; } = new List<School>();

    public virtual ICollection<Spouse> Spouses { get; set; } = new List<Spouse>();

    public virtual ICollection<Training> Training { get; set; } = new List<Training>();
    public virtual ICollection<Address> Address { get; set; } = new List<Address>();

    public virtual ICollection<SalaryDetail> SalaryDetail { get; set; } = new List<SalaryDetail>();


}
