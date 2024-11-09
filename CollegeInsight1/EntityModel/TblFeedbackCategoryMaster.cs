using System;
using System.Collections.Generic;

namespace CollegeInsight1.EntityModel;

public partial class TblFeedbackCategoryMaster
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public virtual ICollection<TblFeedbackMaster> TblFeedbackMasters { get; set; } = new List<TblFeedbackMaster>();
}
