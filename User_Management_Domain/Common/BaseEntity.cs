using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User_Management_Domain.Common
{
	public abstract class BaseEntity
	{
        public DateTime? EnterTime { get; set; }
        public DateTime? ExitTime { get; set; }
        public int Id { get; set; }
    }
}
