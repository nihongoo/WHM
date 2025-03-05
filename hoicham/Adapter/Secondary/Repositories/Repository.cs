using hoicham.Core.Ports.Output.Repositories;
using hoicham.Infrastructure.AppDbContext;
using Microsoft.EntityFrameworkCore;

namespace hoicham.Adapter.Secondary.Repositories
{
	public class Repository<T> : IRepository<T> where T : class
	{
		protected readonly AppDbContext _dbContext;

		public Repository(AppDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task<T> GetByIdAsync(Guid id)
		{
			return await _dbContext.Set<T>().FindAsync(id);
		}

		public async Task<IEnumerable<T>> GetAllAsync()
		{
			return await _dbContext.Set<T>().ToListAsync();
		}

		public async Task<T> AddAsync(T entity)
		{
			await _dbContext.Set<T>().AddAsync(entity);
			return entity;
		}

		public async Task UpdateAsync(T entity)
		{
			_dbContext.Entry(entity).State = EntityState.Modified;
			await Task.CompletedTask;
		}

		public async Task DeleteAsync(Guid id)
		{
			var entity = await GetByIdAsync(id);
			if (entity != null)
			{
				_dbContext.Set<T>().Remove(entity);
			}
		}
	}
}
