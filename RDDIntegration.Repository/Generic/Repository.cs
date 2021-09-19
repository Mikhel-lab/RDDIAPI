using Microsoft.EntityFrameworkCore;
using RDDIntegration.Repository.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDDIntegration.Repository.Generic
{
	public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
	{
		public DbSet<TEntity> DbEntities { set; get; }
		public readonly AppDbContext _context;
		public IQueryable<TEntity> Table => Entities;
		public Repository(AppDbContext context)
		{
			_context = context;
		}
		public TEntity Add(TEntity entity)
		{
			if (entity == null)
				throw new ArgumentNullException("entity");
			Entities.Add(entity);
			return entity;
		}

		public async Task<IEnumerable<TEntity>> GetAllAsync()
		{
			return await _context.Set<TEntity>().ToListAsync();
		}

		public async Task<TEntity> GetAsync(object id)
		{
			return await Entities.FindAsync(id);
		}

		private DbSet<TEntity> Entities
		{
			get
			{
				if (DbEntities == null)
				{
					DbEntities = _context.Set<TEntity>();
				}
				return DbEntities;
			}
		}
	}
}
