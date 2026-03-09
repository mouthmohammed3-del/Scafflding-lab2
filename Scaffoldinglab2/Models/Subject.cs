using System;
using System.Collections.Generic;

namespace Scaffoldinglab2.Models;

public partial class Subject
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int? TeacherId { get; set; }

    public bool? IsActive { get; set; }

    public virtual Teacher? Teacher { get; set; }
}
