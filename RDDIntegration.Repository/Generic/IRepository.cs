using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RDDIntegration.Repository.Generic
{
	public interface IRepository<TEntity> where TEntity : class
	{
		TEntity Add(TEntity entity);
		Task<TEntity> GetAsync(object id);
		Task<IEnumerable<TEntity>> GetAllAsync();
	}
}
