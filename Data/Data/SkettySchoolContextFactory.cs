using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SkettySchool.Data
{
    public class SkettySchoolContextFactory : IDesignTimeDbContextFactory<SkettySchoolContext>
    {
        public SkettySchoolContext CreateDbContext(string[] args)
        {
            var config = new ConfigurationBuilder()
              .SetBasePath(Directory.GetCurrentDirectory())
              .AddJsonFile("appsettings.json")
              .Build();

            return new SkettySchoolContext(new DbContextOptionsBuilder<SkettySchoolContext>().Options, config);
        }


    }
}
