using System;
using System.Collections.Generic;

namespace DbFirstCIS2.Models;

public partial class TblDrive
{
    public int TblDriveId { get; set; }

    public int TblComputerId { get; set; }

    public int TblDriveFunctionId { get; set; }

    public string DriveLetter { get; set; } = null!;

    public string DriveName { get; set; } = null!;

    public virtual TblComputer TblComputer { get; set; } = null!;

    public virtual ICollection<TblComputerDriveSetting> TblComputerDriveSettings { get; set; } = new List<TblComputerDriveSetting>();

    public virtual TblDriveFunction TblDriveFunction { get; set; } = null!;
}
