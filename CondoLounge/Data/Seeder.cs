using CondoLounge.Data.Entities;
using Microsoft.AspNetCore.Identity;
using System.Text.Json;

namespace CondoLounge.Data
{
    public class Seeder
    {
        private readonly ApplicationDbContext _db;
        private readonly IWebHostEnvironment _hosting;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole<int>> _roleManager;

        public Seeder(ApplicationDbContext context, 
                IWebHostEnvironment hosting, 
                UserManager<ApplicationUser> userManager, 
                RoleManager<IdentityRole<int>> roleManager)
        {
            _db = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task Seed()
        {
            //Verify that the database exists. Hover over the method and read the documentation. 
            _db.Database.EnsureCreated();
                        
            if (!_roleManager.Roles.Any()) {
                await _roleManager.CreateAsync(new IdentityRole<int>("Admin"));
                await _roleManager.CreateAsync(new IdentityRole<int>("Default"));
            }

            if (!_userManager.Users.Any())
            {
                // if there are no users then we must create first building then condo and then admin who is linked to that building and condo
                Building building = new Building() { };
                _db.Add(building);

                // not most efficient but we need the building created before we can create the condo
                _db.SaveChanges();

                Condo condo = new Condo() { CondoNumber = 100, Location = "Montreal", BuildingId = building.Id };
                _db.Add(condo);

                // not most efficient but we need the condo created before we can create the user
                _db.SaveChanges();

                var user = new ApplicationUser() { UserName = "admin@email.com", Email = "admin@email.com", CondoId = condo.Id};                
                await _userManager.CreateAsync(user, "VerySecureAdmin45%");  
                await _userManager.AddToRoleAsync(user, "Admin");
            }

            _db.SaveChanges();  
        }
    }
}
