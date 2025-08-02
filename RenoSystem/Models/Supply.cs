#nullable disable
using System;
using System.Collections.Generic;

namespace RenoSystem.Models;

public partial class Supply
{
    public int SupplyId { get; set; }

    public int JobId { get; set; }

    public string Material { get; set; }

    public int Quantity { get; set; }

    public decimal MaterialCost { get; set; }

    public virtual Job Job { get; set; }
}