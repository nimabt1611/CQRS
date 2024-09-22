using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User_Management_Application.Persistance.Contract;
using User_Management_dataAccess;
using User_Management_Domain;

namespace User_Management_Application.Persistance.Implement
{
	public class PersonRepository : IPersonRepository
	{
		private readonly UserDb db;

		public PersonRepository(UserDb db)
		{
			this.db = db;
		}

		public async Task<Person> Create(Person entity)
		{
			await db.People.AddAsync(entity);
			await db.SaveChangesAsync();
			return entity;
		}

		public async Task<Person> Delete( int id , Person entity)
		{

			var existperson = await db.People.FirstOrDefaultAsync(c => c.Id == id);
			if (existperson == null)
			{
				return null;
			}
			db.People.Remove(existperson);
			await db.SaveChangesAsync();
			return existperson;
		}

		public async Task<Person> Get(int Id)
		{
			return await db.People.FirstOrDefaultAsync(c => c.Id == Id);
			
		}

		public async Task<List<Person>> GetAll()
		{
			return await db.People.ToListAsync();
			
		}

		public async Task<Person> Update(int id , Person entity)
		{
			var existperson = await db.People.FirstOrDefaultAsync(c => c.Id == id);
			if (existperson == null)
			{
				return null;
			}

			existperson.FirstName = entity.FirstName;
			existperson.LastName = entity.LastName;
			existperson.Salary = entity.Salary;
			existperson.Address = entity.Address;
			
			

			await db.SaveChangesAsync();

			return existperson;
		}
	}
}
