using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace api.Data
{
    public class ApplicationDBContext : IdentityDbContext
    {
        public ApplicationDBContext(DbContextOptions dbContextOptions)
        : base(dbContextOptions)
        {

        }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            List<IdentityRole> roles = new List<IdentityRole>
            {
                //Create Roles
                new IdentityRole
                {
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole
                {
                    Name = "User",
                    NormalizedName = "USER"
                },
            };
            builder.Entity<IdentityRole>().HasData(roles);
        }

        //Create tables in Db
        public DbSet<Card> Cards {get; set; }
        public DbSet<CardOrder> CardOrders {get; set; }
        public DbSet<DegreeCode> DegreeCodes {get; set; }
        public DbSet<StudentGroup> Groups { get; set; }
        public DbSet<Professor> Professors {get; set; }
        public DbSet<Project> Projects {get; set; }
        public DbSet<ProjectGroup> ProjectGroups {get; set; }
        public DbSet<ProjectGroupProject> ProjectGroupProjects {get; set; }
        public DbSet<ProjectRoleCode> ProjectRoleCodes {get; set; }
        public DbSet<Repo> Repositories {get; set; }
        public DbSet<RoleCode> RoleCodes {get; set; }
        public DbSet<Sprint> Sprints {get; set; }
        public DbSet<SprintCard> SprintCards {get; set; }
        public DbSet<Status> Statuses {get; set; }
        public DbSet<StatusOrder> StatusOrders {get; set; }
        public DbSet<Student> Students {get; set; }
        public DbSet<User> Users {get; set; }
        public DbSet<UserProject> UserProjects {get; set; }

        
    }
}