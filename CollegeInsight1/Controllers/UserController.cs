using CollegeInsight1.EntityModel;
using CollegeInsight1.Models;
using Microsoft.AspNetCore.Mvc;

namespace CollegeInsight1.Controllers
{
	public class UserController : Controller
	{
		[HttpGet]
		public IActionResult Create()
		{

			return View();
		}


		[HttpPost]
		public IActionResult Create(userRegVM userVM)
		{
			TblUserMaster userMaster = new TblUserMaster();	
			//userMaster.Id=userVM.Id;
			userMaster.FirstName=userVM.FirstName;
			userMaster.LastName=userVM.LastName;
			userMaster.Email=userVM.Email;	
			userMaster.Password=userVM.Password;
			userMaster.EnrollmentDate=userVM.EnrollmentDate;
			userMaster.Department=userVM.Department;
			userMaster.UserTypeId=userVM.UserTypeId;


			using (CollegeInsightContext ctx=new CollegeInsightContext())
			{



				ctx.TblUserMasters.Add(userMaster);
				ctx.SaveChanges();
				ViewBag.message = "Saved Succesfully..!";

			}

			return View();
		}
	}
}
