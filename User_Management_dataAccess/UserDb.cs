using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User_Management_Domain;

namespace User_Management_dataAccess
{
	public class UserDb : IdentityDbContext
	{
		public UserDb(DbContextOptions<UserDb> options) : base(options)
		{
		}

        public DbSet<Person> People { get; set; }
        public DbSet<Resume> Resumes { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			

			var ReaderRoleId = "b3dcb28e-96a3-4062-ad95-10c0a8ce07bd";
			var WriterRoleId = "f9ff3bf3-cd24-4232-931f-1dc6f460085d";

			var roles = new List<IdentityRole>{

				new IdentityRole
				{
					Id = ReaderRoleId,
					ConcurrencyStamp = ReaderRoleId,
					Name = "Reader",
					NormalizedName = "Reader".ToUpper()
				},
				new IdentityRole
				{
					Id = WriterRoleId,
					ConcurrencyStamp = WriterRoleId,
					Name="Writer",
					NormalizedName ="Writer".ToUpper()
				}



			};
			modelBuilder.Entity<IdentityRole>().HasData(roles);

		}
	}
}
