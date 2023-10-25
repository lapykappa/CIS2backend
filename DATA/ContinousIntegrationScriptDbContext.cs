using System;
using System.Collections.Generic;
using DbFirstCIS2.Models;
using Microsoft.EntityFrameworkCore;

namespace DbFirstCIS2.DATA
{
    public partial class ContinousIntegrationScriptDbContext : DbContext
    {
        public ContinousIntegrationScriptDbContext()
        {
        }

        public ContinousIntegrationScriptDbContext(DbContextOptions<ContinousIntegrationScriptDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblComputer> TblComputers { get; set; }
        public virtual DbSet<TblComputerDriveSetting> TblComputerDriveSettings { get; set; }
        public virtual DbSet<TblComputerFunctionality> TblComputerFunctionalities { get; set; }
        public virtual DbSet<TblComputerType> TblComputerTypes { get; set; }
        public virtual DbSet<TblComputerUser> TblComputerUsers { get; set; }
        public virtual DbSet<TblDrive> TblDrives { get; set; }
        public virtual DbSet<TblDriveFunction> TblDriveFunctions { get; set; }
        public virtual DbSet<TblDriveInstalledSoftware> TblDriveInstalledSoftwares { get; set; }
        public virtual DbSet<TblInstalledSoftware> TblInstalledSoftwares { get; set; }
        public virtual DbSet<TblInterface> TblInterfaces { get; set; }
        public virtual DbSet<TblInterfaceName> TblInterfaceNames { get; set; }
        public virtual DbSet<TblJobset> TblJobsets { get; set; }
        public virtual DbSet<TblJobsetTiaExtension> TblJobsetTiaExtensions { get; set; }
        public virtual DbSet<TblQlausTask> TblQlausTasks { get; set; }
        public virtual DbSet<TblRole> TblRoles { get; set; }
        public virtual DbSet<TblTeam> TblTeams { get; set; }
        public virtual DbSet<TblTiaExtension> TblTiaExtensions { get; set; }
        public virtual DbSet<TblUser> TblUsers { get; set; }
        public virtual DbSet<TblUserRole> TblUserRoles { get; set; }
        public virtual DbSet<TblUserTeam> TblUserTeams { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblComputer>(entity =>
            {
                entity.HasKey(e => e.TblComputerId).HasName("PK__tblCompu__1B7A739890DB345F");

                entity.ToTable("tblComputers");

                entity.Property(e => e.TblComputerId)
                    .HasColumnName("tblComputerID")
                    .ValueGeneratedOnAdd(); // This will auto-generate the ID

                entity.Property(e => e.TblComputerFunctionalityId).HasColumnName("tblComputerFuncionalityID");
                entity.Property(e => e.TblComputerTypeId).HasColumnName("tblComputerTypeID");

                entity.HasOne(d => d.TblComputerFunctionality).WithMany(p => p.TblComputers)
                    .HasForeignKey(d => d.TblComputerFunctionalityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblComputers_tblComputerFunctionalities");

                entity.HasOne(d => d.TblComputerType).WithMany(p => p.TblComputers)
                    .HasForeignKey(d => d.TblComputerTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblComputers_tblComputerTypes");
            });

            modelBuilder.Entity<TblComputerDriveSetting>(entity =>
        {
            entity.HasKey(e => e.TblComputerDriveSettingId).HasName("PK__tblCompu__AF17A55686F906B0");

            entity.ToTable("tblComputerDriveSettings");

            entity.Property(e => e.TblComputerDriveSettingId).HasColumnName("tblComputerDriveSettingID");
            entity.Property(e => e.TblComputerDriveId).HasColumnName("tblComputerDriveID");
            entity.Property(e => e.TblJobsetId).HasColumnName("tblJobsetID");
            entity.Property(e => e.TblQlausTaskId).HasColumnName("tblQlausTaskID");

            entity.HasOne(d => d.TblComputerDrive).WithMany(p => p.TblComputerDriveSettings)
                .HasForeignKey(d => d.TblComputerDriveId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblComputerDriveSettings_tblDrives");

            entity.HasOne(d => d.TblJobset).WithMany(p => p.TblComputerDriveSettings)
                .HasForeignKey(d => d.TblJobsetId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblComputerDriveSettings_tblJobsets");

            entity.HasOne(d => d.TblQlausTask).WithMany(p => p.TblComputerDriveSettings)
                .HasForeignKey(d => d.TblQlausTaskId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblComputerDriveSettings_tblQlausTasks");
        });

            modelBuilder.Entity<TblComputerFunctionality>(entity =>
            {
                entity.HasKey(e => e.TblComputerFuncionalityId).HasName("PK__tblCompu__43917DB29EC9852D");

                entity.ToTable("tblComputerFunctionalities");

                entity.Property(e => e.TblComputerFuncionalityId).HasColumnName("tblComputerFuncionalityID");
            });

            modelBuilder.Entity<TblComputerType>(entity =>
            {
                entity.HasKey(e => e.TblComputerTypeId).HasName("PK__tblCompu__34C645AB11DD1F0A");

                entity.ToTable("tblComputerTypes");

                entity.Property(e => e.TblComputerTypeId).HasColumnName("tblComputerTypeID");
            });

            modelBuilder.Entity<TblComputerUser>(entity =>
            {
                entity
                    .HasNoKey()
                    .ToTable("tblComputerUsers");

                entity.Property(e => e.TblComputerId).HasColumnName("tblComputerID");
                entity.Property(e => e.TblUserId).HasColumnName("tblUserID");

                entity.HasOne(d => d.TblComputer).WithMany()
                    .HasForeignKey(d => d.TblComputerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblComputerUsers_tblComputers");

                entity.HasOne(d => d.TblUser).WithMany()
                    .HasForeignKey(d => d.TblUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblComputerUsers_tblUsers");
            });

            modelBuilder.Entity<TblDrive>(entity =>
            {
                entity.HasKey(e => e.TblDriveId).HasName("PK__tblDrive__22F285198953E4AF");

                entity.ToTable("tblDrives");

                entity.Property(e => e.TblDriveId).HasColumnName("tblDriveID");
                entity.Property(e => e.TblComputerId).HasColumnName("tblComputerID");
                entity.Property(e => e.TblDriveFunctionId).HasColumnName("tblDriveFunctionID");

                entity.HasOne(d => d.TblComputer).WithMany(p => p.TblDrives)
                    .HasForeignKey(d => d.TblComputerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblDrives_tblComputers");

                entity.HasOne(d => d.TblDriveFunction).WithMany(p => p.TblDrives)
                    .HasForeignKey(d => d.TblDriveFunctionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblDrives_tblDriveFunctions");
            });

            modelBuilder.Entity<TblDriveFunction>(entity =>
            {
                entity.HasKey(e => e.TblDriveFunctionId).HasName("PK__tblDrive__7721A6596876B085");

                entity.ToTable("tblDriveFunctions");

                entity.Property(e => e.TblDriveFunctionId).HasColumnName("tblDriveFunctionID");
            });

            modelBuilder.Entity<TblDriveInstalledSoftware>(entity =>
            {
                entity
                    .HasNoKey()
                    .ToTable("tblDriveInstalledSoftwares");

                entity.Property(e => e.TblComputerDriveId).HasColumnName("tblComputerDriveID");
                entity.Property(e => e.TblInstalledSoftwareId).HasColumnName("tblInstalledSoftwareID");

                entity.HasOne(d => d.TblComputerDrive).WithMany()
                    .HasForeignKey(d => d.TblComputerDriveId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblDriveInstalledSoftwares_tblDrives");

                entity.HasOne(d => d.TblInstalledSoftware).WithMany()
                    .HasForeignKey(d => d.TblInstalledSoftwareId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblDriveInstalledSoftwares_tblInstalledSoftwares");
            });

            modelBuilder.Entity<TblInstalledSoftware>(entity =>
            {
                entity.HasKey(e => e.TblInstalledSoftwareId).HasName("PK__tblInsta__D0BC9E167283580E");

                entity.ToTable("tblInstalledSoftwares");

                entity.Property(e => e.TblInstalledSoftwareId).HasColumnName("tblInstalledSoftwareID");
            });

            modelBuilder.Entity<TblInterface>(entity =>
            {
                entity.HasKey(e => e.TblInterfacesId).HasName("PK__tblInter__DD05B55EA675D3F0");

                entity.ToTable("tblInterfaces");

                entity.Property(e => e.TblInterfacesId).HasColumnName("tblInterfacesID");
                entity.Property(e => e.TblComputerId).HasColumnName("tblComputerID");
                entity.Property(e => e.TblInterfaceNameId).HasColumnName("tblInterfaceNameID");

                entity.HasOne(d => d.TblComputer).WithMany(p => p.TblInterfaces)
                    .HasForeignKey(d => d.TblComputerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblInterfaces_tblComputers");

                entity.HasOne(d => d.TblInterfaceName).WithMany(p => p.TblInterfaces)
                    .HasForeignKey(d => d.TblInterfaceNameId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblInterfaces_tblInterfaceNames");
            });

            modelBuilder.Entity<TblInterfaceName>(entity =>
            {
                entity.HasKey(e => e.TblInterfaceNameId).HasName("PK__tblInter__7971E2A630ECFE50");

                entity.ToTable("tblInterfaceNames");

                entity.Property(e => e.TblInterfaceNameId).HasColumnName("tblInterfaceNameID");
            });

            modelBuilder.Entity<TblJobset>(entity =>
            {
                entity.HasKey(e => e.TblJobsetId).HasName("PK__tblJobse__D5FFDAD1359C0218");

                entity.ToTable("tblJobsets");

                entity.Property(e => e.TblJobsetId).HasColumnName("tblJobsetID");
                entity.Property(e => e.Cdfolder).HasColumnName("CDFolder");
            });

            modelBuilder.Entity<TblJobsetTiaExtension>(entity =>
            {
                entity
                    .HasNoKey()
                    .ToTable("tblJobsetTiaExtensions");

                entity.Property(e => e.TblJobsetId).HasColumnName("tblJobsetID");
                entity.Property(e => e.TblTiaExtensionId).HasColumnName("tblTiaExtensionID");

                entity.HasOne(d => d.TblJobset).WithMany()
                    .HasForeignKey(d => d.TblJobsetId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblJobsetTiaExtensions_tblJobsets");

                entity.HasOne(d => d.TblTiaExtension).WithMany()
                    .HasForeignKey(d => d.TblTiaExtensionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblJobsetTiaExtensions_tblTiaExtensions");
            });

            modelBuilder.Entity<TblQlausTask>(entity =>
            {
                entity.HasKey(e => e.TblQlausTaskId).HasName("PK__tblQlaus__468CE9CFF909CBE5");

                entity.ToTable("tblQlausTasks");

                entity.Property(e => e.TblQlausTaskId).HasColumnName("tblQlausTaskID");
            });

            modelBuilder.Entity<TblRole>(entity =>
            {
                entity.HasKey(e => e.TblRoleId).HasName("PK__tblRoles__C02E199766D797C0");

                entity.ToTable("tblRoles");

                entity.Property(e => e.TblRoleId).HasColumnName("tblRoleID");
            });

            modelBuilder.Entity<TblTeam>(entity =>
            {
                entity.HasKey(e => e.TblTeamId).HasName("PK__tblTeams__5F1EB47761CD94BB");

                entity.ToTable("tblTeams");

                entity.Property(e => e.TblTeamId).HasColumnName("tblTeamID");
            });

            modelBuilder.Entity<TblTiaExtension>(entity =>
            {
                entity.HasKey(e => e.TblTiaExtensionId).HasName("PK__tblTiaEx__5A11C1C16704D1A9");

                entity.ToTable("tblTiaExtensions");

                entity.Property(e => e.TblTiaExtensionId).HasColumnName("tblTiaExtensionID");
            });

            modelBuilder.Entity<TblUser>(entity =>
            {
                entity.HasKey(e => e.TblUserId).HasName("PK__tblUsers__8161CA9F8AB5EAFF");

                entity.ToTable("tblUsers");

                entity.Property(e => e.TblUserId).HasColumnName("tblUserID");
            });

            modelBuilder.Entity<TblUserRole>(entity =>
            {
                entity
                    .HasNoKey()
                    .ToTable("tblUserRoles");

                entity.Property(e => e.TblRoleId).HasColumnName("tblRoleID");
                entity.Property(e => e.TblUserId).HasColumnName("tblUserID");

                entity.HasOne(d => d.TblRole).WithMany()
                    .HasForeignKey(d => d.TblRoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblUserRoles_tblRoles");

                entity.HasOne(d => d.TblUser).WithMany()
                    .HasForeignKey(d => d.TblUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblUserRoles_tblUsers");
            });

            modelBuilder.Entity<TblUserTeam>(entity =>
            {
                entity
                    .HasNoKey()
                    .ToTable("tblUserTeams");

                entity.Property(e => e.TblTeamId).HasColumnName("tblTeamID");
                entity.Property(e => e.TblUserId).HasColumnName("tblUserID");

                entity.HasOne(d => d.TblTeam).WithMany()
                    .HasForeignKey(d => d.TblTeamId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblUserTeams_tblTeams");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
