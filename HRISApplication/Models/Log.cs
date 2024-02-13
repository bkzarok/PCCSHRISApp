using System;
using System.Collections.Generic;

namespace HRISApplication.Models;

public partial class Log
{
    public int Id { get; set; }

    public string Action { get; set; } = null!;

    public string UserName { get; set; } = null!;

    public DateTime CreatedOn { get; set; }
}
