using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SkettySchool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkettySchool.Data
{
    public class SkettySchoolContext : DbContext
    {
        private readonly IConfiguration _config;

        public SkettySchoolContext(DbContextOptions options, IConfiguration config) : base(options)
        {
            _config = config;
        }

        public DbSet<TeacherModel> Teachers { get; set; }
        public DbSet<PupilModel> Pupils { get; set; }
        public DbSet<ClassModel> Classes { get; set; }

        public IEnumerable<object> Teacher { get; internal set; }
        public IEnumerable<object> Pupil { get; internal set; }
        public IEnumerable<object> Class { get; internal set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_config.GetConnectionString("SkettySchool"));
        }

        protected override void OnModelCreating(ModelBuilder bldr)
        {
            bldr.Entity<TeacherModel>()
              .HasData(new
              {
                  TeacherId = 1,
                  FirstName = "Alan",
                  LastName = "Grant",
                  UserType = "Teacher",
                
              },
              new
              {
                  TeacherId = 2,
                  FirstName = "Ellie",
                  LastName = "Sattler",
                  UserType = "Teacher",
                 
              },
              new
              {

                  TeacherId = 3,
                  FirstName = "Ian",
                  LastName = "Malcom",
                  UserType = "Teacher",
                  

              },
              new
              {
                  TeacherId = 4,
                  FirstName = "Owen",
                  LastName = "Grady",
                  UserType = "Teacher",
                  

              });


            bldr.Entity<PupilModel>()
              .HasData(new
              {
                  PupilId = 1,
                  FirstName = "Claire",
                  LastName = "Dearing",
                  DateOfBirth = new DateTime(2000, 03, 02),
                  SchoolYear = 7,
                  UserType = "Pupil",


              }, new
              {
                  PupilId = 2,
                  FirstName = "Tim",
                  LastName = "Murphey",
                  DateOfBirth = new DateTime(1999, 10, 02),
                  SchoolYear = 8,
                  UserType = "Pupil",


              }, new
              {
                  PupilId = 3,
                  FirstName = "Lex",
                  LastName = "Murphey",
                  DateOfBirth = new DateTime(1999, 08, 02),
                  SchoolYear = 9,
                  UserType = "Pupil",

              });

            bldr.Entity<ClassModel>()
              .HasData(new
              {
                  ClassId = 1,
                  ClassName = "I.T",
                  ClassDescription = "I.T Class One"


              }, new
              {
                  ClassId = 2,
                  ClassName = "History",
                  ClassDescription = "History Class One"

              });
        }
    }
}
