using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User_Management_Application.Persistance.Contract.Common;
using User_Management_Domain;

namespace User_Management_Application.Persistance.Contract
{
	public interface IPersonRepository : IBaseRepository<Person>
	{
	}
}
