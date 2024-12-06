﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using api.Data;

#nullable disable

namespace api.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    [Migration("20241205153330_first")]
    partial class first
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "979c5b7e-03a1-4f8d-a6d3-7bb552ae7b9d",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = "225cc507-219f-4c3d-b729-9c13cfc3398f",
                            Name = "User",
                            NormalizedName = "USER"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("character varying(13)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasDiscriminator().HasValue("IdentityUser");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("text");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .HasColumnType("text");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("api.Models.Card", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("StatusFkeyId")
                        .HasColumnType("integer");

                    b.Property<string>("UserFkeyId")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("StatusFkeyId");

                    b.HasIndex("UserFkeyId");

                    b.ToTable("Cards");
                });

            modelBuilder.Entity("api.Models.CardOrder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("CardFkeyId")
                        .HasColumnType("integer");

                    b.Property<string>("Order")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("SprintFkeyId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CardFkeyId");

                    b.HasIndex("SprintFkeyId");

                    b.ToTable("CardOrders");
                });

            modelBuilder.Entity("api.Models.DegreeCode", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Degree")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("DegreeCodes");
                });

            modelBuilder.Entity("api.Models.Professor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("DegreeCodeId")
                        .HasColumnType("integer");

                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("DegreeCodeId");

                    b.HasIndex("UserId");

                    b.ToTable("Professors");
                });

            modelBuilder.Entity("api.Models.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("Approved")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Grade")
                        .HasColumnType("integer");

                    b.Property<string>("InviteCode")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("NumParticipants")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("api.Models.ProjectGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("ProfessorFkeyId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ProfessorFkeyId");

                    b.ToTable("ProjectGroups");
                });

            modelBuilder.Entity("api.Models.ProjectGroupProject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("GroupFkeyId")
                        .HasColumnType("integer");

                    b.Property<int?>("GroupId")
                        .HasColumnType("integer");

                    b.Property<int?>("ProjectId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("GroupFkeyId");

                    b.HasIndex("ProjectId");

                    b.ToTable("ProjectGroupProjects");
                });

            modelBuilder.Entity("api.Models.ProjectRoleCode", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ProjectRole")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("ProjectRoleCodes");
                });

            modelBuilder.Entity("api.Models.Repo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("ProjectId")
                        .HasColumnType("integer");

                    b.Property<string>("URL")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.ToTable("Repositories");
                });

            modelBuilder.Entity("api.Models.RoleCode", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("RoleCodes");
                });

            modelBuilder.Entity("api.Models.Sprint", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DateExpect")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DateStart")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Order")
                        .HasColumnType("integer");

                    b.Property<int?>("ProjectFkeyId")
                        .HasColumnType("integer");

                    b.Property<string>("UserFkeyId")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ProjectFkeyId");

                    b.HasIndex("UserFkeyId");

                    b.ToTable("Sprints");
                });

            modelBuilder.Entity("api.Models.SprintCard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("CardFkeyId")
                        .HasColumnType("integer");

                    b.Property<int?>("SprintFkeyId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CardFkeyId");

                    b.HasIndex("SprintFkeyId");

                    b.ToTable("SprintCards");
                });

            modelBuilder.Entity("api.Models.Status", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("SprintFkeyId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("SprintFkeyId");

                    b.ToTable("Statuses");
                });

            modelBuilder.Entity("api.Models.StatusOrder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Order")
                        .HasColumnType("integer");

                    b.Property<int?>("SprintFkeyId")
                        .HasColumnType("integer");

                    b.Property<int?>("StatusFkeyId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("SprintFkeyId");

                    b.HasIndex("StatusFkeyId");

                    b.ToTable("StatusOrders");
                });

            modelBuilder.Entity("api.Models.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("GitHub")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("StudentGroupId")
                        .HasColumnType("integer");

                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("StudentGroupId");

                    b.HasIndex("UserId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("api.Models.StudentGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("api.Models.UserProject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("ProjectId")
                        .HasColumnType("integer");

                    b.Property<int?>("ProjectRoleCodeFkeyId")
                        .HasColumnType("integer");

                    b.Property<int?>("ProjectRoleId")
                        .HasColumnType("integer");

                    b.Property<string>("UserFkeyId")
                        .HasColumnType("text");

                    b.Property<int?>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.HasIndex("ProjectRoleCodeFkeyId");

                    b.HasIndex("UserFkeyId");

                    b.ToTable("UserProjects");
                });

            modelBuilder.Entity("api.Models.User", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");

                    b.Property<int?>("RoleCodeId")
                        .HasColumnType("integer");

                    b.HasIndex("RoleCodeId");

                    b.HasDiscriminator().HasValue("User");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("api.Models.Card", b =>
                {
                    b.HasOne("api.Models.Status", "StatusFkey")
                        .WithMany("Cards")
                        .HasForeignKey("StatusFkeyId");

                    b.HasOne("api.Models.User", "UserFkey")
                        .WithMany("Cards")
                        .HasForeignKey("UserFkeyId");

                    b.Navigation("StatusFkey");

                    b.Navigation("UserFkey");
                });

            modelBuilder.Entity("api.Models.CardOrder", b =>
                {
                    b.HasOne("api.Models.Card", "CardFkey")
                        .WithMany("CardOrders")
                        .HasForeignKey("CardFkeyId");

                    b.HasOne("api.Models.Sprint", "SprintFkey")
                        .WithMany("CardOrders")
                        .HasForeignKey("SprintFkeyId");

                    b.Navigation("CardFkey");

                    b.Navigation("SprintFkey");
                });

            modelBuilder.Entity("api.Models.Professor", b =>
                {
                    b.HasOne("api.Models.DegreeCode", "DegreeCode")
                        .WithMany("Professors")
                        .HasForeignKey("DegreeCodeId");

                    b.HasOne("api.Models.User", "User")
                        .WithMany("Professors")
                        .HasForeignKey("UserId");

                    b.Navigation("DegreeCode");

                    b.Navigation("User");
                });

            modelBuilder.Entity("api.Models.ProjectGroup", b =>
                {
                    b.HasOne("api.Models.Professor", "ProfessorFkey")
                        .WithMany("ProjectGroups")
                        .HasForeignKey("ProfessorFkeyId");

                    b.Navigation("ProfessorFkey");
                });

            modelBuilder.Entity("api.Models.ProjectGroupProject", b =>
                {
                    b.HasOne("api.Models.ProjectGroup", "GroupFkey")
                        .WithMany("ProjectGroupProjects")
                        .HasForeignKey("GroupFkeyId");

                    b.HasOne("api.Models.Project", "ProjectFkey")
                        .WithMany("ProjectGroupProjects")
                        .HasForeignKey("ProjectId");

                    b.Navigation("GroupFkey");

                    b.Navigation("ProjectFkey");
                });

            modelBuilder.Entity("api.Models.Repo", b =>
                {
                    b.HasOne("api.Models.Project", "Project")
                        .WithMany("Repositories")
                        .HasForeignKey("ProjectId");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("api.Models.Sprint", b =>
                {
                    b.HasOne("api.Models.Project", "ProjectFkey")
                        .WithMany("Sprints")
                        .HasForeignKey("ProjectFkeyId");

                    b.HasOne("api.Models.User", "UserFkey")
                        .WithMany("Sprints")
                        .HasForeignKey("UserFkeyId");

                    b.Navigation("ProjectFkey");

                    b.Navigation("UserFkey");
                });

            modelBuilder.Entity("api.Models.SprintCard", b =>
                {
                    b.HasOne("api.Models.Card", "CardFkey")
                        .WithMany("SprintCards")
                        .HasForeignKey("CardFkeyId");

                    b.HasOne("api.Models.Sprint", "SprintFkey")
                        .WithMany("SprintCards")
                        .HasForeignKey("SprintFkeyId");

                    b.Navigation("CardFkey");

                    b.Navigation("SprintFkey");
                });

            modelBuilder.Entity("api.Models.Status", b =>
                {
                    b.HasOne("api.Models.Sprint", "SprintFkey")
                        .WithMany("Statuses")
                        .HasForeignKey("SprintFkeyId");

                    b.Navigation("SprintFkey");
                });

            modelBuilder.Entity("api.Models.StatusOrder", b =>
                {
                    b.HasOne("api.Models.Sprint", "SprintFkey")
                        .WithMany("StatusOrders")
                        .HasForeignKey("SprintFkeyId");

                    b.HasOne("api.Models.Status", "StatusFkey")
                        .WithMany("StatusOrders")
                        .HasForeignKey("StatusFkeyId");

                    b.Navigation("SprintFkey");

                    b.Navigation("StatusFkey");
                });

            modelBuilder.Entity("api.Models.Student", b =>
                {
                    b.HasOne("api.Models.StudentGroup", "StudentGroup")
                        .WithMany("Students")
                        .HasForeignKey("StudentGroupId");

                    b.HasOne("api.Models.User", "User")
                        .WithMany("Students")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("StudentGroup");

                    b.Navigation("User");
                });

            modelBuilder.Entity("api.Models.UserProject", b =>
                {
                    b.HasOne("api.Models.Project", "ProjectFkey")
                        .WithMany("UserProjects")
                        .HasForeignKey("ProjectId");

                    b.HasOne("api.Models.ProjectRoleCode", "ProjectRoleCodeFkey")
                        .WithMany("UserProjects")
                        .HasForeignKey("ProjectRoleCodeFkeyId");

                    b.HasOne("api.Models.User", "UserFkey")
                        .WithMany("UserProjects")
                        .HasForeignKey("UserFkeyId");

                    b.Navigation("ProjectFkey");

                    b.Navigation("ProjectRoleCodeFkey");

                    b.Navigation("UserFkey");
                });

            modelBuilder.Entity("api.Models.User", b =>
                {
                    b.HasOne("api.Models.RoleCode", "RoleCodeFkey")
                        .WithMany("Users")
                        .HasForeignKey("RoleCodeId");

                    b.Navigation("RoleCodeFkey");
                });

            modelBuilder.Entity("api.Models.Card", b =>
                {
                    b.Navigation("CardOrders");

                    b.Navigation("SprintCards");
                });

            modelBuilder.Entity("api.Models.DegreeCode", b =>
                {
                    b.Navigation("Professors");
                });

            modelBuilder.Entity("api.Models.Professor", b =>
                {
                    b.Navigation("ProjectGroups");
                });

            modelBuilder.Entity("api.Models.Project", b =>
                {
                    b.Navigation("ProjectGroupProjects");

                    b.Navigation("Repositories");

                    b.Navigation("Sprints");

                    b.Navigation("UserProjects");
                });

            modelBuilder.Entity("api.Models.ProjectGroup", b =>
                {
                    b.Navigation("ProjectGroupProjects");
                });

            modelBuilder.Entity("api.Models.ProjectRoleCode", b =>
                {
                    b.Navigation("UserProjects");
                });

            modelBuilder.Entity("api.Models.RoleCode", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("api.Models.Sprint", b =>
                {
                    b.Navigation("CardOrders");

                    b.Navigation("SprintCards");

                    b.Navigation("StatusOrders");

                    b.Navigation("Statuses");
                });

            modelBuilder.Entity("api.Models.Status", b =>
                {
                    b.Navigation("Cards");

                    b.Navigation("StatusOrders");
                });

            modelBuilder.Entity("api.Models.StudentGroup", b =>
                {
                    b.Navigation("Students");
                });

            modelBuilder.Entity("api.Models.User", b =>
                {
                    b.Navigation("Cards");

                    b.Navigation("Professors");

                    b.Navigation("Sprints");

                    b.Navigation("Students");

                    b.Navigation("UserProjects");
                });
#pragma warning restore 612, 618
        }
    }
}