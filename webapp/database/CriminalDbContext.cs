using criminal.reporting.models;
using System.Data.Entity;

namespace criminal.reporting.database
{
    public  class CriminalDbContext :DbContext
    {
        public CriminalDbContext() : base()
        {

        }
        public DbSet<Station> Stations { get; set; }
        public DbSet<CrimeCase> CrimeCases{ get; set; }
    }
}
