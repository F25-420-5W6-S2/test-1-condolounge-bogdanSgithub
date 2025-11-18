namespace CondoLounge.Data.Entities
{
    public class Building
    {
        public int Id { get; set; }
        public ICollection<Condo> Condos { get; set; }
    }
}
