using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DbFirstCIS2.Models;

public partial class TblComputer
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int TblComputerId { get; set; }

    public string ComputerName { get; set; } = null!;

    public int TblComputerTypeId { get; set; }

    public int TblComputerFunctionalityId { get; set; }

    public string SerialNr { get; set; } = null!;

    public string Inventory { get; set; } = null!;

    public string Comment { get; set; } = null!;

    public virtual TblComputerFunctionality TblComputerFunctionality { get; set; } = null!;

    public virtual TblComputerType TblComputerType { get; set; } = null!;

    public virtual ICollection<TblDrive> TblDrives { get; set; } = new List<TblDrive>();

    public virtual ICollection<TblInterface> TblInterfaces { get; set; } = new List<TblInterface>();
}
