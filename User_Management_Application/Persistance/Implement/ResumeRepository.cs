using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User_Management_Application.Persistance.Contract;
using User_Management_Application.Persistance.Contract.Common;
using User_Management_dataAccess;
using User_Management_Domain;

namespace User_Management_Application.Persistance.Implement
{
	public class ResumeRepository : IResumeRepository
	{
		private readonly UserDb db;

		public ResumeRepository(UserDb db)
		{
			this.db = db;
		}

		public async Task<Resume> Create(Resume entity)
		{
			await db.Resumes.AddAsync(entity);
			await db.SaveChangesAsync();
			return entity;
		}

		public async Task<Resume> Delete(int id, Resume entity)
		{
			var existresume = await db.Resumes.FirstOrDefaultAsync(c => c.Id == id);
			if (existresume == null)
			{
				return null;
			}
			db.Resumes.Remove(existresume);
			await db.SaveChangesAsync();
			return existresume;
		}

		public async Task<Resume> Get(int Id)
		{
			return await db.Resumes.FirstOrDefaultAsync(c => c.Id == Id);
		}

		public async Task<List<Resume>> GetAll()
		{
			return await db.Resumes.ToListAsync();
		}

		public async Task<Resume> Update(int id, Resume entity)
		{
			var existresume = await db.Resumes.FirstOrDefaultAsync(c => c.Id == id);
			if (existresume == null)
			{
				return null;
			}

			existresume.LastSalary = entity.LastSalary;
			existresume.LastJob = entity.LastJob;
		



			await db.SaveChangesAsync();

			return existresume;
		}
	}
}
