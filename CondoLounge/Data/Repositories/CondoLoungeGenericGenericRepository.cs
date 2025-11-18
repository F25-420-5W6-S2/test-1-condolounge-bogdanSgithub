using CondoLounge.Data.Interfaces;
using CondoLounge.Data;
using Microsoft.EntityFrameworkCore;

namespace CondoLounge.Data.Repositories
{
    public class CondoLoungeGenericGenericRepository<T> : ICondoLoungeGenericRepository<T> where T : class
    {
        internal readonly ILogger<CondoLoungeGenericGenericRepository<T>> _logger;
        internal readonly ApplicationDbContext _context;
        internal readonly DbSet<T> _dbSet;

        public CondoLoungeGenericGenericRepository(ApplicationDbContext db, ILogger<CondoLoungeGenericGenericRepository<T>> logger) 
        {
            _logger = logger;
            _context = db;
            _dbSet = _context.Set<T>();
        }
        public void Add(T item)
        {
            try
            {
                _logger.LogInformation("Add was called...");
                _dbSet.Add(item);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to add item: {ex}");
            }
        }

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll()
        {
            try
            {
                _logger.LogInformation("GetAll was called...");

                return _dbSet.ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get: {ex}");
                return null;
            }
        }

        public T GetById(object id)
        {
            try
            {
                _logger.LogInformation("GetById was called...");
                T item = _dbSet.Find(id);
                if (item == null)
                {
                    _logger.LogWarning($"Item with id {id} could not be found");
                    return null;
                }
                return item;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get item by id {id}: {ex}");
                return null;
            }
        }

        public void SaveAll()
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
