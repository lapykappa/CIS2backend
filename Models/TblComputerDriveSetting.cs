using System;
using System.Collections.Generic;

namespace DbFirstCIS2.Models;
public partial class TblComputerDriveSetting
{
    public int TblComputerDriveSettingId { get; set; }

    public int TblComputerDriveId { get; set; }

    public int TblJobsetId { get; set; }

    public int TblQlausTaskId { get; set; }

    public string ExtensionPackages { get; set; } = null!;

    public string PreBatch { get; set; } = null!;

    public string PostBatch { get; set; } = null!;

    public string TestCaseFile { get; set; } = null!;

    public virtual TblDrive TblComputerDrive { get; set; } = null!;

    public virtual TblJobset TblJobset { get; set; } = null!;

    public virtual TblQlausTask TblQlausTask { get; set; } = null!;
}
