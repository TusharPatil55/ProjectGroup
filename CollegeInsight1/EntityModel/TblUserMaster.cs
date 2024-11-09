using System;
using System.Collections.Generic;

namespace CollegeInsight1.EntityModel;

public partial class TblUserMaster
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public DateOnly EnrollmentDate { get; set; }

    public string Department { get; set; } = null!;

    public int UserTypeId { get; set; }

    public virtual ICollection<TblFeedbackMaster> TblFeedbackMasters { get; set; } = new List<TblFeedbackMaster>();

    public virtual TblUserType UserType { get; set; } = null!;
}
