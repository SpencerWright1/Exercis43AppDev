#nullable disable
using System;
using System.Collections.Generic;

namespace RenoSystem.Models;

public partial class Labour
{
    public int LabourId { get; set; }

    public int JobId { get; set; }

    public string Description { get; set; }

    public double Hours { get; set; }

    public decimal LabourCost { get; set; }

    public DateTime ScheduleDate { get; set; }

    public virtual Job Job { get; set; }
}