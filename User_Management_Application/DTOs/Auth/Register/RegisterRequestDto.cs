using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User_Management_Application.DTOs.Auth.Register
{
	public class RegisterRequestDto
	{
		
		[DataType(DataType.EmailAddress)]
		public string Username { get; set; }
		
		public string Password { get; set; }
		public string[] Roles { get; set; }
	}
}
