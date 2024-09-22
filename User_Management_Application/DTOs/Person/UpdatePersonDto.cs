using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User_Management_Application.DTOs.Common;

namespace User_Management_Application.DTOs.Person
{
	public class UpdatePersonDto : BaseDto  
	{
       
        public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Address { get; set; }
		public int Salary { get; set; }
	}
}
