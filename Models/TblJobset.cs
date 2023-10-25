using System;
using System.Collections.Generic;

namespace DbFirstCIS2.Models;  

public partial class TblJobset
{
    public int TblJobsetId { get; set; }

    public string JobsetName { get; set; } = null!;

    public string TestDataDropLocation { get; set; } = null!;

    public string TestAutomatDropLocation { get; set; } = null!;

    public bool? EnableRestore { get; set; }

    public string Cdfolder { get; set; } = null!;

    public int? TestMethod { get; set; }

    public string LocalTempPath { get; set; } = null!;

    public string InstallLogPath { get; set; } = null!;

    public bool? EnableRestart { get; set; }

    public bool? SdrLp { get; set; }

    public bool? TiaLp { get; set; }

    public int? DeploymentTypeSelection { get; set; }

    public string SuppliesType { get; set; } = null!;

    public string TriggerFile { get; set; } = null!;

    public virtual ICollection<TblComputerDriveSetting> TblComputerDriveSettings { get; set; } = new List<TblComputerDriveSetting>();
}
