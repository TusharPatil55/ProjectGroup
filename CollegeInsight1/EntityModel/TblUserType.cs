using System;
using System.Collections.Generic;

namespace CollegeInsight1.EntityModel;

public partial class TblUserType
{
    public int Id { get; set; }

    public string UserType { get; set; } = null!;

    public virtual ICollection<TblUserMaster> TblUserMasters { get; set; } = new List<TblUserMaster>();
}
