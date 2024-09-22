using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User_Management_Domain.Common;

namespace User_Management_Domain
{
    public class Resume : BaseEntity
    {
        public string LastJob { get; set; }
        public int LastSalary { get; set; }
        public Person person { get; set; }
        public int personId { get; set; }
    }
}
