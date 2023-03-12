using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TheaterNyreack.Models
{
    public partial class TheaterNyreckContext : DbContext
    {
        public static TheaterNyreckContext DbContext { get; private set; }  = new TheaterNyreckContext();

        public TheaterNyreckContext()
        {
        }

        public TheaterNyreckContext(DbContextOptions<TheaterNyreckContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Contract> Contracts { get; set; } = null!;
        public virtual DbSet<Contractstatus> Contractstatuses { get; set; } = null!;
        public virtual DbSet<Reward> Rewards { get; set; } = null!;
        public virtual DbSet<Roleuser> Roleusers { get; set; } = null!;
        public virtual DbSet<Show> Shows { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=localhost;user=root;password=12345;database=theaternyreck", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.30-mysql")).UseLazyLoadingProxies();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<Contract>(entity =>
            {
                entity.ToTable("contract");

                entity.HasIndex(e => e.ContractActorId, "ContractActorId");

                entity.HasIndex(e => e.ContractDirectorId, "ContractDirectorId");

                entity.HasIndex(e => e.ContractShowId, "ContractShowId");

                entity.HasIndex(e => e.ContractStatusId, "ContractStatusId");

                entity.HasOne(d => d.ContractActor)
                    .WithMany(p => p.ContractContractActors)
                    .HasForeignKey(d => d.ContractActorId)
                    .HasConstraintName("contract_ibfk_1");

                entity.HasOne(d => d.ContractDirector)
                    .WithMany(p => p.ContractContractDirectors)
                    .HasForeignKey(d => d.ContractDirectorId)
                    .HasConstraintName("contract_ibfk_2");

                entity.HasOne(d => d.ContractShow)
                    .WithMany(p => p.Contracts)
                    .HasForeignKey(d => d.ContractShowId)
                    .HasConstraintName("contract_ibfk_3");

                entity.HasOne(d => d.ContractStatus)
                    .WithMany(p => p.Contracts)
                    .HasForeignKey(d => d.ContractStatusId)
                    .HasConstraintName("contract_ibfk_4");
            });

            modelBuilder.Entity<Contractstatus>(entity =>
            {
                entity.ToTable("contractstatus");

                entity.Property(e => e.ContractStatusName).HasMaxLength(150);
            });

            modelBuilder.Entity<Reward>(entity =>
            {
                entity.HasKey(e => e.RewardsId)
                    .HasName("PRIMARY");

                entity.ToTable("rewards");

                entity.HasIndex(e => e.RewardUserId, "RewardUserId");

                entity.Property(e => e.RewardName).HasMaxLength(150);

                entity.HasOne(d => d.RewardUser)
                    .WithMany(p => p.Rewards)
                    .HasForeignKey(d => d.RewardUserId)
                    .HasConstraintName("rewards_ibfk_1");
            });

            modelBuilder.Entity<Roleuser>(entity =>
            {
                entity.ToTable("roleuser");

                entity.Property(e => e.RoleUserName).HasMaxLength(150);
            });

            modelBuilder.Entity<Show>(entity =>
            {
                entity.ToTable("shows");

                entity.Property(e => e.ShowData).HasColumnType("datetime");

                entity.Property(e => e.ShowDescription).HasMaxLength(250);

                entity.Property(e => e.ShowName).HasMaxLength(150);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");

                entity.HasIndex(e => e.UserRoleId, "UserRoleId");

                entity.Property(e => e.UserLogin).HasMaxLength(150);

                entity.Property(e => e.UserName).HasMaxLength(150);

                entity.Property(e => e.UserPassword).HasMaxLength(150);

                entity.Property(e => e.UserPatronimyc).HasMaxLength(150);

                entity.Property(e => e.UserSurname).HasMaxLength(150);

                entity.HasOne(d => d.UserRole)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.UserRoleId)
                    .HasConstraintName("users_ibfk_1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
