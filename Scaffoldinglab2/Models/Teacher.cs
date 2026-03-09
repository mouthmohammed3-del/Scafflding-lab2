using System;
using System.Collections.Generic;

namespace Scaffoldinglab2.Models;

public partial class Teacher
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public decimal? Salary { get; set; }

    public string? Details { get; set; }

    public bool? IsActive { get; set; }

    public virtual ICollection<Subject> Subjects { get; } = new List<Subject>();
}
