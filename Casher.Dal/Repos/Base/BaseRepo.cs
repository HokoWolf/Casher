using Casher.Dal.EfStructures;
using Casher.Models.Entities.Base;
using Microsoft.EntityFrameworkCore;

namespace Casher.Dal.Repos.Base
{
	public abstract class BaseRepo<T> : IRepo<T> where T : BaseEntity, new()
	{
		private bool _disposedValue;
		public AppDbContext Context { get; }
		public DbSet<T> Table { get; }


		protected BaseRepo(AppDbContext context)
		{
			Context = context;
			Table = Context.Set<T>();
			_disposedValue = false;
		}

		protected BaseRepo(DbContextOptions<AppDbContext> options)
			: this(new AppDbContext(options))
		{
			_disposedValue = true;
		}


		public virtual T? Find(int? id) => Table.Find(id);

		public virtual IEnumerable<T> GetAll() => Table;


		public virtual int Add(T entity, bool persist = true)
		{
			Table.Add(entity);
			return persist ? SaveChanges() : 0;
		}

        public virtual async Task<int> AddAsync(T entity, bool persist = true)
        {
            await Table.AddAsync(entity);
            return persist ? await SaveChangesAsync() : 0;
        }

        public virtual int Update(T entity, bool persist = true)
		{
			Table.Update(entity);
			return persist ? SaveChanges() : 0;
		}

		public int Delete(int id, byte[] timeStamp, bool persist = true)
		{
			var entity = new T { Id = id, TimeStamp = timeStamp };
			Context.Entry(entity).State = EntityState.Deleted;
			return persist ? SaveChanges() : 0;
		}

		public virtual int Delete(T entity, bool persist = true)
		{
			Table.Remove(entity);
			return persist ? SaveChanges() : 0;
		}


		public void ExecuteQuery(string sql, object[] sqlParametersObjects)
			=> Context.Database.ExecuteSqlRaw(sql, sqlParametersObjects);


		public int SaveChanges() => Context.SaveChanges();

		public async Task<int> SaveChangesAsync() => await Context.SaveChangesAsync();


        // IDisposable implementation
        protected virtual void Dispose(bool disposing)
		{
			if (!_disposedValue)
			{
				if (disposing)
				{
					Context.Dispose();
				}

				_disposedValue = true;
			}
		}

		~BaseRepo()
		{
			Dispose(disposing: false);
		}

		public void Dispose()
		{
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}
	}
}
