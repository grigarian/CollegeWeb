using College.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace College.DataAccess.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Specialization> Specializations { get; set; }
        public DbSet<Teacher> Teachers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Teacher>().HasData(
                new Teacher 
                { 
                    Id = 1,
                    Name = "Александрова Наталья Васильевна", 
                    Post = "Преподаватель", 
                    Education = "Высшее. Автомеханика и управление в технических системах",
                    Qualification = "Инженер системотехник. Категория первая",
                    WorkExperience = 31,
                    ImageUrl =""
                    
                },
                new Teacher
                {
                    Id = 2,
                    Name = "Бондаренко Любовь Петровна",
                    Post = "Преподаватель",
                    Education = "Высшее. Математика, информатика и вычислительная техника",
                    Qualification = "Учитель математики информатики и вычислительной техники. Категория первая",
                    WorkExperience = 31,
                    ImageUrl = ""

                },
                new Teacher
                {
                    Id = 3,
                    Name = "Дударев Виталий Петрович",
                    Post = "Преподаватель",
                    Education = "Высшее, Управление и информатика в технических системах",
                    Qualification = "Инженер-системотехник",
                    WorkExperience = 42,
                    ImageUrl = ""

                }
            );
        }
    }
}
