using CondoLounge.Data.Entities;
using CondoLounge.Data.Interfaces;

namespace CondoLounge.Data.Repositories
{
    public class BuildingRepository : CondoLoungeGenericGenericRepository<Building>, IBuildingRepository
    {
        public BuildingRepository(ApplicationDbContext db, ILogger<CondoLoungeGenericGenericRepository<Building>> logger) : base(db, logger)
        {
        }

        public ICollection<Condo> GetAllCondos(int buildingId)
        {
            return _dbSet
                .Where(b => b.Id == buildingId)
                .SelectMany(b => b.Condos)
                .ToList();
        }

        public ICollection<ApplicationUser> GetAllUsers(int buildingId)
        {
            return _dbSet
                .Where(b => b.Id == buildingId)
                .SelectMany(b => b.Condos)
                .SelectMany(c => c.Users)
                .ToList();
        }
    }
}
