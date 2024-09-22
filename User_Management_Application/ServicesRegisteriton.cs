using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace User_Management_Application
{
	public class ServicesRegisteriton
	{
		public ServicesRegisteriton( IServiceCollection services )
		{
			services.AddAutoMapper(Assembly.GetExecutingAssembly());
		}
	}
}
