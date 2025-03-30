using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SixChickenFilm.Models;

public partial class MovieDbContext : DbContext
{
    public MovieDbContext()
    {
    }

    public MovieDbContext(DbContextOptions<MovieDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<Affiliate> Affiliates { get; set; }

    public virtual DbSet<Auditorium> Auditoriums { get; set; }

    public virtual DbSet<Booking> Bookings { get; set; }

    public virtual DbSet<BookingAffiliate> BookingAffiliates { get; set; }

    public virtual DbSet<BookingSeat> BookingSeats { get; set; }

    public virtual DbSet<Comment> Comments { get; set; }

    public virtual DbSet<CommissionPayment> CommissionPayments { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<FilmManager> FilmManagers { get; set; }

    public virtual DbSet<Movie> Movies { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<Promotion> Promotions { get; set; }

    public virtual DbSet<Seat> Seats { get; set; }

    public virtual DbSet<Showtime> Showtimes { get; set; }

    public virtual DbSet<Theater> Theaters { get; set; }

    public virtual DbSet<Transaction> Transactions { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=THAIIHA;Database=MovieDB;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Admin>(entity =>
        {
            entity.HasKey(e => e.AdminId).HasName("PK__Admin__43AA41412AC08482");

            entity.ToTable("Admin");

            entity.HasIndex(e => e.UserId, "UQ__Admin__B9BE370E2E172EFF").IsUnique();

            entity.Property(e => e.AdminId).HasColumnName("admin_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithOne(p => p.Admin)
                .HasForeignKey<Admin>(d => d.UserId)
                .HasConstraintName("FK__Admin__user_id__06CD04F7");
        });

        modelBuilder.Entity<Affiliate>(entity =>
        {
            entity.HasKey(e => e.AffiliateId).HasName("PK__Affiliat__270ACAE3361F9E65");

            entity.HasIndex(e => e.AffiliateLink, "UQ__Affiliat__B9BAC6D2A7A5AD19").IsUnique();

            entity.HasIndex(e => e.UserId, "UQ__Affiliat__B9BE370E2A68C336").IsUnique();

            entity.Property(e => e.AffiliateId).HasColumnName("affiliate_id");
            entity.Property(e => e.AffiliateLink)
                .HasMaxLength(500)
                .HasColumnName("affiliate_link");
            entity.Property(e => e.CommissionRate)
                .HasDefaultValue(0.00m)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("commission_rate");
            entity.Property(e => e.FullName)
                .HasMaxLength(255)
                .HasColumnName("full_name");
            entity.Property(e => e.Reputation)
                .HasDefaultValue(0)
                .HasColumnName("reputation");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithOne(p => p.Affiliate)
                .HasForeignKey<Affiliate>(d => d.UserId)
                .HasConstraintName("FK__Affiliate__user___60A75C0F");
        });

        modelBuilder.Entity<Auditorium>(entity =>
        {
            entity.HasKey(e => e.AuditoriumId).HasName("PK__Auditori__B78BBE8807C8EB98");

            entity.Property(e => e.AuditoriumId).HasColumnName("auditorium_id");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.TheaterId).HasColumnName("theater_id");
            entity.Property(e => e.TotalSeats).HasColumnName("total_seats");

            entity.HasOne(d => d.Theater).WithMany(p => p.Auditoria)
                .HasForeignKey(d => d.TheaterId)
                .HasConstraintName("FK__Auditoriu__theat__09A971A2");
        });

        modelBuilder.Entity<Booking>(entity =>
        {
            entity.HasKey(e => e.BookingId).HasName("PK__Bookings__5DE3A5B15F10583B");

            entity.Property(e => e.BookingId).HasColumnName("booking_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CustomerId).HasColumnName("customer_id");
            entity.Property(e => e.ShowtimeId).HasColumnName("showtime_id");

            entity.HasOne(d => d.Customer).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK__Bookings__custom__2645B050");

            entity.HasOne(d => d.Showtime).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.ShowtimeId)
                .HasConstraintName("FK__Bookings__showti__2739D489");
        });

        modelBuilder.Entity<BookingAffiliate>(entity =>
        {
            entity.HasKey(e => e.BookingAffiliateId).HasName("PK__Booking___CE3287CFA6D6896A");

            entity.ToTable("Booking_Affiliate");

            entity.Property(e => e.BookingAffiliateId).HasColumnName("booking_affiliate_id");
            entity.Property(e => e.AffiliateId).HasColumnName("affiliate_id");
            entity.Property(e => e.BookingId).HasColumnName("booking_id");
            entity.Property(e => e.CommissionAmount)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("commission_amount");
            entity.Property(e => e.TransactionStatus)
                .HasMaxLength(50)
                .HasColumnName("transaction_status");

            entity.HasOne(d => d.Affiliate).WithMany(p => p.BookingAffiliates)
                .HasForeignKey(d => d.AffiliateId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK__Booking_A__affil__2FCF1A8A");

            entity.HasOne(d => d.Booking).WithMany(p => p.BookingAffiliates)
                .HasForeignKey(d => d.BookingId)
                .HasConstraintName("FK__Booking_A__booki__2EDAF651");
        });

        modelBuilder.Entity<BookingSeat>(entity =>
        {
            entity.HasKey(e => e.BookingSeatId).HasName("PK__Booking___C073D47DD704C3B5");

            entity.ToTable("Booking_Seats");

            entity.Property(e => e.BookingSeatId).HasColumnName("booking_seat_id");
            entity.Property(e => e.BookingId).HasColumnName("booking_id");
            entity.Property(e => e.SeatId).HasColumnName("seat_id");

            entity.HasOne(d => d.Booking).WithMany(p => p.BookingSeats)
                .HasForeignKey(d => d.BookingId)
                .HasConstraintName("FK__Booking_S__booki__2A164134");

            entity.HasOne(d => d.Seat).WithMany(p => p.BookingSeats)
                .HasForeignKey(d => d.SeatId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Booking_S__seat___2B0A656D");
        });

        modelBuilder.Entity<Comment>(entity =>
        {
            entity.HasKey(e => e.CommentId).HasName("PK__Comments__E7957687CC631E78");

            entity.Property(e => e.CommentId).HasColumnName("comment_id");
            entity.Property(e => e.Content).HasColumnName("content");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CustomerId).HasColumnName("customer_id");
            entity.Property(e => e.MovieId).HasColumnName("movie_id");

            entity.HasOne(d => d.Customer).WithMany(p => p.Comments)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK__Comments__custom__489AC854");

            entity.HasOne(d => d.Movie).WithMany(p => p.Comments)
                .HasForeignKey(d => d.MovieId)
                .HasConstraintName("FK__Comments__movie___498EEC8D");
        });

        modelBuilder.Entity<CommissionPayment>(entity =>
        {
            entity.HasKey(e => e.CommissionId).HasName("PK__Commissi__D19D7CC941448245");

            entity.ToTable("Commission_Payments");

            entity.Property(e => e.CommissionId).HasColumnName("commission_id");
            entity.Property(e => e.Amount)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("amount");
            entity.Property(e => e.BookingId).HasColumnName("booking_id");
            entity.Property(e => e.CommissionType)
                .HasMaxLength(50)
                .HasColumnName("commission_type");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasColumnName("status");
            entity.Property(e => e.TheaterId).HasColumnName("theater_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Booking).WithMany(p => p.CommissionPayments)
                .HasForeignKey(d => d.BookingId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK__Commissio__booki__7A3223E8");

            entity.HasOne(d => d.Theater).WithMany(p => p.CommissionPayments)
                .HasForeignKey(d => d.TheaterId)
                .HasConstraintName("FK__Commissio__theat__7B264821");

            entity.HasOne(d => d.User).WithMany(p => p.CommissionPayments)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Commissio__user___793DFFAF");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__Customer__CD65CB8552269BC7");

            entity.HasIndex(e => e.UserId, "UQ__Customer__B9BE370ECB4DB5B9").IsUnique();

            entity.Property(e => e.CustomerId).HasColumnName("customer_id");
            entity.Property(e => e.FullName)
                .HasMaxLength(255)
                .HasColumnName("full_name");
            entity.Property(e => e.MembershipTier)
                .HasMaxLength(50)
                .HasColumnName("membership_tier");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithOne(p => p.Customer)
                .HasForeignKey<Customer>(d => d.UserId)
                .HasConstraintName("FK__Customers__user___778AC167");
        });

        modelBuilder.Entity<FilmManager>(entity =>
        {
            entity.HasKey(e => e.FilmManagerId).HasName("PK__FilmMana__41374EE2D331F228");

            entity.HasIndex(e => e.UserId, "UQ__FilmMana__B9BE370E1CF5D646").IsUnique();

            entity.Property(e => e.FilmManagerId).HasColumnName("film_manager_id");
            entity.Property(e => e.TheaterId).HasColumnName("theater_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Theater).WithMany(p => p.FilmManagers)
                .HasForeignKey(d => d.TheaterId)
                .HasConstraintName("FK__FilmManag__theat__14270015");

            entity.HasOne(d => d.User).WithOne(p => p.FilmManager)
                .HasForeignKey<FilmManager>(d => d.UserId)
                .HasConstraintName("FK__FilmManag__user___1332DBDC");
        });

        modelBuilder.Entity<Movie>(entity =>
        {
            entity.HasKey(e => e.MovieId).HasName("PK__Movies__83CDF74984BFAB9F");

            entity.Property(e => e.MovieId).HasColumnName("movie_id");
            entity.Property(e => e.Cast).HasColumnName("cast");
            entity.Property(e => e.Country)
                .HasMaxLength(100)
                .HasColumnName("country");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Director)
                .HasMaxLength(255)
                .HasColumnName("director");
            entity.Property(e => e.Duration).HasColumnName("duration");
            entity.Property(e => e.Genre)
                .HasMaxLength(255)
                .HasColumnName("genre");
            entity.Property(e => e.ReleaseDate).HasColumnName("release_date");
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .HasColumnName("title");
            entity.Property(e => e.TrailerUrl)
                .HasMaxLength(500)
                .HasColumnName("trailer_url");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.PaymentId).HasName("PK__Payments__ED1FC9EAAEB180E1");

            entity.HasIndex(e => e.TransactionId, "UQ__Payments__85C600AE0B74F2DA").IsUnique();

            entity.Property(e => e.PaymentId).HasColumnName("payment_id");
            entity.Property(e => e.Amount)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("amount");
            entity.Property(e => e.BookingId).HasColumnName("booking_id");
            entity.Property(e => e.PaymentMethod)
                .HasMaxLength(50)
                .HasColumnName("payment_method");
            entity.Property(e => e.PaymentStatus)
                .HasMaxLength(50)
                .HasColumnName("payment_status");
            entity.Property(e => e.TransactionDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("transaction_date");
            entity.Property(e => e.TransactionId)
                .HasMaxLength(255)
                .HasColumnName("transaction_id");

            entity.HasOne(d => d.Booking).WithMany(p => p.Payments)
                .HasForeignKey(d => d.BookingId)
                .HasConstraintName("FK__Payments__bookin__3587F3E0");
        });

        modelBuilder.Entity<Promotion>(entity =>
        {
            entity.HasKey(e => e.PromotionId).HasName("PK__Promotio__2CB9556B027A3936");

            entity.HasIndex(e => e.Code, "UQ__Promotio__357D4CF9537F81A6").IsUnique();

            entity.Property(e => e.PromotionId).HasColumnName("promotion_id");
            entity.Property(e => e.Code)
                .HasMaxLength(50)
                .HasColumnName("code");
            entity.Property(e => e.Discount)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("discount");
            entity.Property(e => e.EndDate).HasColumnName("end_date");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("is_active");
            entity.Property(e => e.MaxUsage).HasColumnName("max_usage");
            entity.Property(e => e.MinOrderValue)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("min_order_value");
            entity.Property(e => e.StartDate).HasColumnName("start_date");
            entity.Property(e => e.TheaterId).HasColumnName("theater_id");
            entity.Property(e => e.UsedCount)
                .HasDefaultValue(0)
                .HasColumnName("used_count");

            entity.HasOne(d => d.Theater).WithMany(p => p.Promotions)
                .HasForeignKey(d => d.TheaterId)
                .HasConstraintName("FK__Promotion__theat__44CA3770");
        });

        modelBuilder.Entity<Seat>(entity =>
        {
            entity.HasKey(e => e.SeatId).HasName("PK__Seats__906DED9C53DC73D8");

            entity.HasIndex(e => new { e.AuditoriumId, e.SeatNumber }, "unique_seat_per_auditorium").IsUnique();

            entity.Property(e => e.SeatId).HasColumnName("seat_id");
            entity.Property(e => e.AuditoriumId).HasColumnName("auditorium_id");
            entity.Property(e => e.IsAvailable)
                .HasDefaultValue(true)
                .HasColumnName("is_available");
            entity.Property(e => e.SeatNumber)
                .HasMaxLength(10)
                .HasColumnName("seat_number");
            entity.Property(e => e.SeatType)
                .HasMaxLength(50)
                .HasColumnName("seat_type");

            entity.HasOne(d => d.Auditorium).WithMany(p => p.Seats)
                .HasForeignKey(d => d.AuditoriumId)
                .HasConstraintName("FK__Seats__auditoriu__0F624AF8");
        });

        modelBuilder.Entity<Showtime>(entity =>
        {
            entity.HasKey(e => e.ShowtimeId).HasName("PK__Showtime__A406B518869F8974");

            entity.Property(e => e.ShowtimeId).HasColumnName("showtime_id");
            entity.Property(e => e.AuditoriumId).HasColumnName("auditorium_id");
            entity.Property(e => e.Format)
                .HasMaxLength(10)
                .HasColumnName("format");
            entity.Property(e => e.Language)
                .HasMaxLength(10)
                .HasColumnName("language");
            entity.Property(e => e.MovieId).HasColumnName("movie_id");
            entity.Property(e => e.ShowDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("show_date");
            entity.Property(e => e.ShowTime).HasColumnName("show_time");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasColumnName("status");

            entity.HasOne(d => d.Auditorium).WithMany(p => p.Showtimes)
                .HasForeignKey(d => d.AuditoriumId)
                .HasConstraintName("FK__Showtimes__audit__1F98B2C1");

            entity.HasOne(d => d.Movie).WithMany(p => p.Showtimes)
                .HasForeignKey(d => d.MovieId)
                .HasConstraintName("FK__Showtimes__movie__1EA48E88");
        });

        modelBuilder.Entity<Theater>(entity =>
        {
            entity.HasKey(e => e.TheaterId).HasName("PK__Theaters__B53C958FD01D089E");

            entity.Property(e => e.TheaterId).HasColumnName("theater_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Location).HasColumnName("location");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.TotalSeats).HasColumnName("total_seats");
        });

        modelBuilder.Entity<Transaction>(entity =>
        {
            entity.HasKey(e => e.TransactionId).HasName("PK__Transact__85C600AF525E6858");

            entity.Property(e => e.TransactionId).HasColumnName("transaction_id");
            entity.Property(e => e.CommissionId).HasColumnName("commission_id");
            entity.Property(e => e.PaymentAmount)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("payment_amount");
            entity.Property(e => e.PaymentDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("payment_date");
            entity.Property(e => e.PaymentStatus)
                .HasMaxLength(50)
                .HasColumnName("payment_status");

            entity.HasOne(d => d.Commission).WithMany(p => p.Transactions)
                .HasForeignKey(d => d.CommissionId)
                .HasConstraintName("FK__Transacti__commi__00DF2177");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__B9BE370F30F86560");

            entity.HasIndex(e => e.Email, "UQ__Users__AB6E616427998A38").IsUnique();

            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .HasColumnName("password");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(15)
                .HasColumnName("phone_number");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
