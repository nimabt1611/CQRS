﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User_Management_Application.DTOs.Auth.Login
{
	public class LoginRequestDto
	{
		[Required]
		[DataType(DataType.EmailAddress)]
		public string Username { get; set; }
		[Required]
		[DataType(DataType.Password)]
		public string Password { get; set; }
	}
}
