using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace dded.db.Linkage
{
    public partial class DataContext : DbContext
    {
        public DataContext()
        {
        }

        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblDepartment> TblDepartment { get; set; }
        public virtual DbSet<TblLevel> TblLevel { get; set; }
        public virtual DbSet<TblLog> TblLog { get; set; }
        public virtual DbSet<TblMainMenu> TblMainMenu { get; set; }
        public virtual DbSet<TblMapColumn> TblMapColumn { get; set; }
        public virtual DbSet<TblMapMenu> TblMapMenu { get; set; }
        public virtual DbSet<TblMapPermission> TblMapPermission { get; set; }
        public virtual DbSet<TblOfficer> TblOfficer { get; set; }
        public virtual DbSet<TblSubmenu> TblSubmenu { get; set; }
        public virtual DbSet<TblToken> TblToken { get; set; }
        public virtual DbSet<ViewMainMenu> ViewMainMenu { get; set; }
        public virtual DbSet<ViewMainMenuCurrent> ViewMainMenuCurrent { get; set; }
        public virtual DbSet<ViewSubMenu> ViewSubMenu { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=52.139.231.26;Database=Linkage;User=sa;Password=Admindded2016!;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblDepartment>(entity =>
            {
                entity.Property(e => e.DepartmentId).ValueGeneratedNever();
            });

            modelBuilder.Entity<TblLevel>(entity =>
            {
                entity.Property(e => e.LevelId).ValueGeneratedNever();
            });

            modelBuilder.Entity<TblLog>(entity =>
            {
                entity.Property(e => e.LogId).ValueGeneratedNever();

                entity.HasOne(d => d.Mapmenu)
                    .WithMany(p => p.TblLog)
                    .HasForeignKey(d => d.MapmenuId)
                    .HasConstraintName("FK_TBL_LOG_TBL_MapMenu");
            });

            modelBuilder.Entity<TblMainMenu>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<TblMapColumn>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.SubMenu)
                    .WithMany(p => p.TblMapColumn)
                    .HasForeignKey(d => d.SubMenuId)
                    .HasConstraintName("FK_TBL_MapColumn_TBL_Submenu");
            });

            modelBuilder.Entity<TblMapMenu>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.MainMenu)
                    .WithMany(p => p.TblMapMenu)
                    .HasForeignKey(d => d.MainMenuId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TBL_MapMenu_TBL_MainMenu");

                entity.HasOne(d => d.SubMenu)
                    .WithMany(p => p.TblMapMenu)
                    .HasForeignKey(d => d.SubMenuId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TBL_MapMenu_TBL_Submenu");
            });

            modelBuilder.Entity<TblMapPermission>(entity =>
            {
                entity.Property(e => e.PermissionId).ValueGeneratedNever();

                entity.HasOne(d => d.MapMenu)
                    .WithMany(p => p.TblMapPermission)
                    .HasForeignKey(d => d.MapMenuId)
                    .HasConstraintName("FK_TBL_MAP_PERMISSION_TBL_MapMenu");

                entity.HasOne(d => d.Officer)
                    .WithMany(p => p.TblMapPermission)
                    .HasForeignKey(d => d.OfficerId)
                    .HasConstraintName("FK_TBL_MAP_PERMISSION_TBL_OFFICER");
            });

            modelBuilder.Entity<TblOfficer>(entity =>
            {
                entity.Property(e => e.OfficerId).ValueGeneratedNever();

                entity.Property(e => e.PinCode).IsFixedLength();

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.TblOfficer)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("FK_TBL_OFFICER_TBL_DEPARTMENT");

                entity.HasOne(d => d.Level)
                    .WithMany(p => p.TblOfficer)
                    .HasForeignKey(d => d.LevelId)
                    .HasConstraintName("FK_TBL_OFFICER_TBL_LEVEL");
            });

            modelBuilder.Entity<TblSubmenu>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<TblToken>(entity =>
            {
                entity.HasNoKey();
            });

            modelBuilder.Entity<ViewMainMenu>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View_MainMenu");
            });

            modelBuilder.Entity<ViewMainMenuCurrent>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View_MainMenuCurrent");
            });

            modelBuilder.Entity<ViewSubMenu>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View_SubMenu");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
