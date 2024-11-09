
using CollegeInsight1.EntityModel;
using System.ComponentModel;
namespace CollegeInsight1.Models
{
	public class userRegVM
	{


		public int Id { get; set; }

		[DisplayName("Enter Name")]
		public string FirstName { get; set; } = null!;

        [DisplayName("Enter Surname")]
        public string LastName { get; set; } = null!;

		public string Email { get; set; } = null!;

		public string Password { get; set; } = null!;

        [DisplayName("Confirm Password")]
        public string C_Password { get; set; } = null!;

        public DateOnly EnrollmentDate { get; set; }

		public string Department { get; set; } = null!;

        [DisplayName("Select User Role")]
        public int UserTypeId { get; set; }

		//public virtual ICollection<TblFeedbackMaster> TblFeedbackMasters { get; set; } = new List<TblFeedbackMaster>();

		//public virtual TblUserType UserType { get; set; } = null!;
	}
}
