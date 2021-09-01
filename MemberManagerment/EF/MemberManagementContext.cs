using System;
using MemberManagerment.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace MemberManagerment.Data.EF
{
    public partial class MemberManagementContext : DbContext
    {
        public MemberManagementContext()
        {
        }

        public MemberManagementContext(DbContextOptions<MemberManagementContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<AddressMember> AddressMembers { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<ContactMember> ContactMembers { get; set; }
        public virtual DbSet<Family> Families { get; set; }
        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<Image> Images { get; set; }
        public virtual DbSet<Member> Members { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<RoleMember> RoleMembers { get; set; }

  

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Address>(entity =>
            {
                entity.ToTable("Address");

                entity.Property(e => e.Id)
                    .HasMaxLength(450)
                    .IsUnicode(false);

                entity.Property(e => e.District)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Nationality)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.ParentId)
                    .HasMaxLength(450)
                    .IsUnicode(false);

                entity.Property(e => e.Province)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.StayingAddress).IsRequired();

                entity.Property(e => e.Ward)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<AddressMember>(entity =>
            {
                entity.HasKey(e => new { e.MemberId, e.AddressId })
                    .HasName("PK__Address___AC6189B7AAB3D2FE");

                entity.ToTable("Address_Member");

                entity.Property(e => e.MemberId)
                    .HasMaxLength(450)
                    .IsUnicode(false);

                entity.Property(e => e.AddressId)
                    .HasMaxLength(450)
                    .IsUnicode(false);

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.AddressMembers)
                    .HasForeignKey(d => d.AddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Address_M__Addre__398D8EEE");

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.AddressMembers)
                    .HasForeignKey(d => d.MemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Address_M__Membe__38996AB5");
            });

            modelBuilder.Entity<Contact>(entity =>
            {
                entity.ToTable("Contact");

                entity.Property(e => e.Id)
                    .HasMaxLength(450)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(450)
                    .IsUnicode(false);

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.Nickname).HasMaxLength(254);

                entity.Property(e => e.Notes)
                    .HasMaxLength(450)
                    .IsUnicode(false)
                    .HasColumnName("notes");

                entity.Property(e => e.PersonalTtles)
                    .HasMaxLength(450)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Word)
                    .HasMaxLength(450)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ContactMember>(entity =>
            {
                entity.HasKey(e => new { e.MemberId, e.ContactId })
                    .HasName("PK__Contact___A936294187E06C1D");

                entity.ToTable("Contact_Member");

                entity.Property(e => e.MemberId)
                    .HasMaxLength(450)
                    .IsUnicode(false);

                entity.Property(e => e.ContactId)
                    .HasMaxLength(450)
                    .IsUnicode(false);

                entity.HasOne(d => d.Contact)
                    .WithMany(p => p.ContactMembers)
                    .HasForeignKey(d => d.ContactId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Contact_M__Conta__35BCFE0A");

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.ContactMembers)
                    .HasForeignKey(d => d.MemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Contact_M__Membe__34C8D9D1");
            });

            modelBuilder.Entity<Family>(entity =>
            {
                entity.ToTable("Family");

                entity.Property(e => e.Id)
                    .HasMaxLength(450)
                    .IsUnicode(false);

                entity.Property(e => e.HousldRepre)
                    .IsRequired()
                    .HasMaxLength(254);

                entity.Property(e => e.IdMember)
                    .HasMaxLength(450)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Group>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasMaxLength(450)
                    .IsUnicode(false);

                entity.Property(e => e.IdMember)
                    .HasMaxLength(450)
                    .IsUnicode(false)
                    .HasColumnName("idMember");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Region)
                    .IsRequired()
                    .HasMaxLength(450);
            });

            modelBuilder.Entity<Image>(entity =>
            {
                entity.ToTable("Image");

                entity.Property(e => e.Id)
                    .HasMaxLength(450)
                    .IsUnicode(false);

                entity.Property(e => e.ImagePath).HasMaxLength(2000);

                entity.Property(e => e.MemberId)
                    .IsRequired()
                    .HasMaxLength(450)
                    .IsUnicode(false);

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.Images)
                    .HasForeignKey(d => d.MemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Image__MemberId__31EC6D26");
            });

            modelBuilder.Entity<Member>(entity =>
            {
                entity.ToTable("Member");

                entity.Property(e => e.Id)
                    .HasMaxLength(450)
                    .IsUnicode(false);

                entity.Property(e => e.FamilyId)
                    .IsRequired()
                    .HasMaxLength(450)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.GroupId)
                    .IsRequired()
                    .HasMaxLength(450)
                    .IsUnicode(false);

                entity.Property(e => e.Idcard)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("IDCard");

                entity.Property(e => e.ImageId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.Notes).HasColumnName("notes");

                entity.HasOne(d => d.Family)
                    .WithMany(p => p.Members)
                    .HasForeignKey(d => d.FamilyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Member__FamilyId__2E1BDC42");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.Members)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Member__GroupId__2F10007B");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasMaxLength(450)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RoleMember>(entity =>
            {
                entity.HasKey(e => new { e.MemberId, e.RoleId })
                    .HasName("PK__Role_Mem__B45FE7F9AB73EF6D");

                entity.ToTable("Role_Member");

                entity.Property(e => e.MemberId)
                    .HasMaxLength(450)
                    .IsUnicode(false);

                entity.Property(e => e.RoleId)
                    .HasMaxLength(450)
                    .IsUnicode(false);

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.RoleMembers)
                    .HasForeignKey(d => d.MemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Role_Memb__Membe__3C69FB99");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.RoleMembers)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Role_Memb__RoleI__3D5E1FD2");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
