using System;
using System.Collections.Generic;

namespace DbFirstCIS2.Models;

public partial class TblQlausTask
{
    public int TblQlausTaskId { get; set; }

    public int? QlausTaskId { get; set; }

    public string? QlausTaskName { get; set; }

    public string? FilterName { get; set; }

    public virtual ICollection<TblComputerDriveSetting> TblComputerDriveSettings { get; set; } = new List<TblComputerDriveSetting>();
}
