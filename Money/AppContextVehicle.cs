using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace Money
{
    internal class AppContextVehicle : DbContext
    {
        private static AppContextVehicle _context;

        public static AppContextVehicle GetContext()
        {
            if(_context == null)
            {
                _context = new AppContextVehicle();
            }

            return _context;
        }
        public DbSet<Vehicle> Vehicles { get; set; }

        public AppContextVehicle() : base("DefaultConnection2") { }
    }
}