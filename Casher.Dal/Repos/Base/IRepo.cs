namespace Casher.Dal.Repos.Base
{
	public interface IRepo<T> : IDisposable
	{
		int Add(T entity, bool persist = true);

		int Update(T entity, bool persist = true);

		int Delete(int id, byte[] timeStamp, bool persist = true);

		int Delete(T entity, bool persist = true);

		T? Find(int? id);

		IEnumerable<T> GetAll();

		void ExecuteQuery(string sql, object[] sqlParametersObjects);

		int SaveChanges();
	}
}
