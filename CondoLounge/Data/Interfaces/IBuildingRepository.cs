using CondoLounge.Data.Entities;

namespace CondoLounge.Data.Interfaces
{
    public interface IBuildingRepository : ICondoLoungeGenericRepository<Building>
    {
        public ICollection<ApplicationUser> GetAllUsers(int buildingId);
        public ICollection<Condo> GetAllCondos(int buildingId);
    }
}
