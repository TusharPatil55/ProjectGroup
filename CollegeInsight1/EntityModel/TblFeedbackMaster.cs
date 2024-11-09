using System;
using System.Collections.Generic;

namespace CollegeInsight1.EntityModel;

public partial class TblFeedbackMaster
{
    public int Id { get; set; }

    public string FeedbackSubject { get; set; } = null!;

    public string FeedbackText { get; set; } = null!;

    public DateTime Date { get; set; }

    public string Photo { get; set; } = null!;

    public int UserId { get; set; }

    public int CatagoryId { get; set; }

    public virtual TblFeedbackCategoryMaster Catagory { get; set; } = null!;

    public virtual TblUserMaster User { get; set; } = null!;
}
