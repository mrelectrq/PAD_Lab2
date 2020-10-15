using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BusinessLayer.DBModels
{
    public partial class PADLaboratoriesContext : DbContext
    {
        public PADLaboratoriesContext()
        {
        }

        public PADLaboratoriesContext(DbContextOptions<PADLaboratoriesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Accounts> Accounts { get; set; }
        public virtual DbSet<Currency> Currency { get; set; }
        public virtual DbSet<Transactions> Transactions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=localhost;Database=PADLaboratories;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Accounts>(entity =>
            {
                entity.HasKey(e => e.AccountId);

                entity.Property(e => e.AccountId).HasColumnName("AccountID");

                entity.Property(e => e.Credits)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.DateRegistered).HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Currency>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Eur).HasColumnName("EUR");

                entity.Property(e => e.Ron).HasColumnName("RON");

                entity.Property(e => e.Rub).HasColumnName("RUB");

                entity.Property(e => e.TimeCurrency)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnName("TYPE")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Uah).HasColumnName("UAH");

                entity.Property(e => e.Usd).HasColumnName("USD");
            });

            modelBuilder.Entity<Transactions>(entity =>
            {
                entity.HasKey(e => e.TransactionId);

                entity.Property(e => e.TransactionId)
                    .HasColumnName("TransactionID")
                    .ValueGeneratedNever();

                entity.Property(e => e.AccountOwnerId).HasColumnName("AccountOwnerID");

                entity.Property(e => e.AccountReceiverId).HasColumnName("AccountReceiverID");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.HasOne(d => d.AccountOwner)
                    .WithMany(p => p.TransactionsAccountOwner)
                    .HasForeignKey(d => d.AccountOwnerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Transactions_Accounts");

                entity.HasOne(d => d.AccountReceiver)
                    .WithMany(p => p.TransactionsAccountReceiver)
                    .HasForeignKey(d => d.AccountReceiverId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Transactions_Accounts1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
