namespace CondoLounge.Data.Entities
{
    public class Condo
    {   
        // the uniq id is Id
        public int Id { get; set; }
        // 101, 102, ...
        public int CondoNumber { get; set; }
        public string Location { get; set; }
        public ICollection<ApplicationUser> Users { get; set; }
        public int BuildingId { get; set; }
        public Building Building { get; set; }
    }
}
