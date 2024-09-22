using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User_Management_Application.Persistance.Contract.Common
{
	public interface IBaseRepository <T> where T : class
	{
		Task<List<T>> GetAll();
		Task<T> Get(int Id);
		Task<T> Create(T entity);
		Task<T> Update(int id , T entity);
		Task<T> Delete(int id , T entity);
		
    }
}
