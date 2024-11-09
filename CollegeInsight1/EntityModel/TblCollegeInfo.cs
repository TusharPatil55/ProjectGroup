using System;
using System.Collections.Generic;

namespace CollegeInsight1.EntityModel;

public partial class TblCollegeInfo
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public DateOnly? Year { get; set; }
}
