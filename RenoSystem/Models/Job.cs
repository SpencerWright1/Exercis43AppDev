#nullable disable
using System;
using System.Collections.Generic;

namespace RenoSystem.Models;

public partial class Job
{
    public int JobId { get; set; }

    public int ClientId { get; set; }

    public string Description { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime CompletionDate { get; set; }

    public string PlanId { get; set; }

    public virtual Client Client { get; set; }

    public virtual ICollection<Labour> Labours { get; set; } = new List<Labour>();

    public virtual ICollection<Supply> Supplies { get; set; } = new List<Supply>();
}