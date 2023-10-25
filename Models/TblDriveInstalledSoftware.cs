using System;
using System.Collections.Generic;

namespace DbFirstCIS2.Models;

public partial class TblDriveInstalledSoftware
{
    public int TblComputerDriveId { get; set; }

    public int TblInstalledSoftwareId { get; set; }

    public virtual TblDrive TblComputerDrive { get; set; } = null!;

    public virtual TblInstalledSoftware TblInstalledSoftware { get; set; } = null!;
}
