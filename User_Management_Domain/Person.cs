using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User_Management_Domain.Common;

namespace User_Management_Domain
{
	public class Person : BaseEntity
	{
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public int Salary { get; set; }
    }
}
