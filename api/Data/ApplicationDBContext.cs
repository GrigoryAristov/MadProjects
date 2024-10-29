using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace api.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions dbContextOptions)
        : base(dbContextOptions)
        {

        }
        
        //Create tables in Db
        public DbSet<Card> Cards {get; set; }
        public DbSet<CardOrder> CardOrders {get; set; }
        public DbSet<DegreeCode> DegreeCodes {get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Professor> Professors {get; set; }
        public DbSet<Project> Projects {get; set; }
        public DbSet<ProjectGroup> ProjectGroups {get; set; }
        public DbSet<ProjectGroupProject> ProjectGroupProjects {get; set; }
        public DbSet<ProjectRoleCode> ProjectRoleCodes {get; set; }
        public DbSet<Repository> Repositories {get; set; }
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