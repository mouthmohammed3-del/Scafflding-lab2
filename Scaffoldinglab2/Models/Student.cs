using System;
using System.Collections.Generic;

namespace Scaffoldinglab2.Models;

public partial class Student
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int Age { get; set; }

    public bool? IsActive { get; set; }
}
