using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Zamastrov.DataObjects
{
    public partial class za_masterov_devContext : DbContext
    {
        public za_masterov_devContext()
        {
            
        }

        public za_masterov_devContext(DbContextOptions<za_masterov_devContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CityRef> CityRef { get; set; }
        public virtual DbSet<CitySourceConn> CitySourceConn { get; set; }
        public virtual DbSet<CommentImages> CommentImages { get; set; }
        public virtual DbSet<Comments> Comments { get; set; }
        public virtual DbSet<CommentsImagesConn> CommentsImagesConn { get; set; }
        public virtual DbSet<Master> Master { get; set; }
        public virtual DbSet<OrgProfConn> OrgProfConn { get; set; }
        public virtual DbSet<OrgServConn> OrgServConn { get; set; }
        public virtual DbSet<Organization> Organization { get; set; }
        public virtual DbSet<ProfessionRef> ProfessionRef { get; set; }
        public virtual DbSet<ServiceRef> ServiceRef { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySQL("server=127.0.0.1;port=3306;username=root;password=root;database=za_masterov_dev");
                
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CityRef>(entity =>
            {
                entity.ToTable("city_ref");

                entity.HasComment("справочник городов");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasComment("id города");

                entity.Property(e => e.CityName)
                    .IsRequired()
                    .HasColumnName("city_name")
                    .HasMaxLength(127)
                    .HasComment("название города");
            });

            modelBuilder.Entity<CitySourceConn>(entity =>
            {
                entity.ToTable("city_source_conn");

                entity.HasComment("таблица соединающая город и сущность в этом городе");

                entity.HasIndex(e => e.IdCity)
                    .HasName("i_city_source_conn_city");

                entity.HasIndex(e => e.SourceId)
                    .HasName("i_c_org_conn_sr_id");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasComment("id записи");

                entity.Property(e => e.IdCity)
                    .HasColumnName("id_city")
                    .HasComment("id города");

                entity.Property(e => e.SourceId)
                    .HasColumnName("source_id")
                    .HasComment("id сущности");

                entity.Property(e => e.SourceType)
                    .HasColumnName("source_type")
                    .HasComment("тип источника 0 - организация 1 - мастер");

                entity.HasOne(d => d.IdCityNavigation)
                    .WithMany(p => p.CitySourceConn)
                    .HasForeignKey(d => d.IdCity)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("city_source_conn_ibfk_3");

                entity.HasOne(d => d.Source)
                    .WithMany(p => p.CitySourceConn)
                    .HasForeignKey(d => d.SourceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("city_source_conn_ibfk_2");

                entity.HasOne(d => d.SourceNavigation)
                    .WithMany(p => p.CitySourceConn)
                    .HasForeignKey(d => d.SourceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("city_source_conn_ibfk_1");
            });

            modelBuilder.Entity<CommentImages>(entity =>
            {
                entity.ToTable("comment_images");

                entity.HasComment("таблица хранящая таблицу названй картинок");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasComment("id записи");

                entity.Property(e => e.ImagesName)
                    .IsRequired()
                    .HasColumnName("images_name")
                    .HasComment("название картинки");
            });

            modelBuilder.Entity<Comments>(entity =>
            {
                entity.ToTable("comments");

                entity.HasComment("комментарии");

                entity.HasIndex(e => e.CommentAnswerId)
                    .HasName("i_comments_answer_id");

                entity.HasIndex(e => e.SourceId)
                    .HasName("i_comments_source_id");

                entity.HasIndex(e => e.UserId)
                    .HasName("i_comments_user_id");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasComment("id коментария");

                entity.Property(e => e.CommentAnswerId)
                    .HasColumnName("comment_answer_id")
                    .HasComment("id комментария родителя");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("date")
                    .HasComment("дата создания записи");

                entity.Property(e => e.Score)
                    .HasColumnName("score")
                    .HasComment("оценка");

                entity.Property(e => e.SourceId)
                    .HasColumnName("source_id")
                    .HasComment("id ресурса");

                entity.Property(e => e.SourceType)
                    .HasColumnName("source_type")
                    .HasComment("тип источника 0 - организация 1 - мастер");

                entity.Property(e => e.Text)
                    .IsRequired()
                    .HasColumnName("text")
                    .HasComment("текст комментария");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasComment("id пользователя");

                entity.HasOne(d => d.Source)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.SourceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("comments_ibfk_1");

                entity.HasOne(d => d.SourceNavigation)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.SourceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("comments_ibfk_2");
            });

            modelBuilder.Entity<CommentsImagesConn>(entity =>
            {
                entity.ToTable("comments_images_conn");

                entity.HasComment("связывание коментариев и картинок");

                entity.HasIndex(e => e.IdComments)
                    .HasName("i_comm_img_conn_comm");

                entity.HasIndex(e => e.IdImg)
                    .HasName("i_comm_img_conn_img");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasComment("id записи");

                entity.Property(e => e.IdComments)
                    .HasColumnName("id_comments")
                    .HasComment("id комментария");

                entity.Property(e => e.IdImg)
                    .HasColumnName("id_img")
                    .HasComment("id картинки");

                entity.HasOne(d => d.IdCommentsNavigation)
                    .WithMany(p => p.CommentsImagesConn)
                    .HasForeignKey(d => d.IdComments)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("comments_images_conn_ibfk_2");

                entity.HasOne(d => d.IdImgNavigation)
                    .WithMany(p => p.CommentsImagesConn)
                    .HasForeignKey(d => d.IdImg)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("comments_images_conn_ibfk_1");
            });

            modelBuilder.Entity<Master>(entity =>
            {
                entity.ToTable("master");

                entity.HasComment("список мастеров");

                entity.HasIndex(e => e.OrganizationId)
                    .HasName("i_master_organization_id");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasComment("id записи");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasComment("описание мастера");

                entity.Property(e => e.Experience)
                    .HasColumnName("experience")
                    .HasComment("стаж");

                entity.Property(e => e.MiddleName)
                    .IsRequired()
                    .HasColumnName("middle_name")
                    .HasComment("отчество");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasComment("имя");

                entity.Property(e => e.OrganizationId)
                    .HasColumnName("organization_id")
                    .HasComment("id организации");

                entity.Property(e => e.Picture)
                    .IsRequired()
                    .HasColumnName("picture")
                    .HasComment("изображение");

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasColumnName("surname")
                    .HasComment("фамилия");
            });

            modelBuilder.Entity<OrgProfConn>(entity =>
            {
                entity.HasKey(e => new { e.OrgId, e.ProfId })
                    .HasName("PRIMARY");

                entity.ToTable("org_prof_conn");

                entity.HasComment("таблица для связки организации и профессий");

                entity.HasIndex(e => e.ProfId)
                    .HasName("prof_id");

                entity.Property(e => e.OrgId)
                    .HasColumnName("org_id")
                    .HasComment("id организации");

                entity.Property(e => e.ProfId)
                    .HasColumnName("prof_id")
                    .HasComment("id  профессии");

                entity.HasOne(d => d.Org)
                    .WithMany(p => p.OrgProfConn)
                    .HasForeignKey(d => d.OrgId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("org_prof_conn_ibfk_1");

                entity.HasOne(d => d.Prof)
                    .WithMany(p => p.OrgProfConn)
                    .HasForeignKey(d => d.ProfId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("org_prof_conn_ibfk_2");
            });

            modelBuilder.Entity<OrgServConn>(entity =>
            {
                entity.HasKey(e => new { e.OrgId, e.ServId })
                    .HasName("PRIMARY");

                entity.ToTable("org_serv_conn");

                entity.HasComment("таблица для связи организации и услуг");

                entity.HasIndex(e => e.ServId)
                    .HasName("serv_id");

                entity.Property(e => e.OrgId)
                    .HasColumnName("org_id")
                    .HasComment("id организации");

                entity.Property(e => e.ServId)
                    .HasColumnName("serv_id")
                    .HasComment("id услуги");

                entity.HasOne(d => d.Org)
                    .WithMany(p => p.OrgServConn)
                    .HasForeignKey(d => d.OrgId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("org_serv_conn_ibfk_2");

                entity.HasOne(d => d.Serv)
                    .WithMany(p => p.OrgServConn)
                    .HasForeignKey(d => d.ServId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("org_serv_conn_ibfk_1");
            });

            modelBuilder.Entity<Organization>(entity =>
            {
                entity.ToTable("organization");

                entity.HasComment("организации");

                entity.HasIndex(e => e.UserId)
                    .HasName("i_organization_user_id");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasComment("id организации");

                entity.Property(e => e.CreateFrom)
                    .HasColumnName("create_from")
                    .HasColumnType("date")
                    .HasComment("дата создания записи");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasComment("описание");

                entity.Property(e => e.Inn)
                    .IsRequired()
                    .HasColumnName("inn")
                    .HasComment("инн");

                entity.Property(e => e.Mail)
                    .IsRequired()
                    .HasColumnName("mail")
                    .HasComment("почта");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasComment("имя");

                entity.Property(e => e.Ogrn)
                    .HasColumnName("ogrn")
                    .HasComment("огрн");

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasColumnName("phone")
                    .HasComment("телефон");

                entity.Property(e => e.Picture)
                    .IsRequired()
                    .HasColumnName("picture")
                    .HasComment("картинка");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasComment("id пользователя");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Organization)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("organization_ibfk_1");
            });

            modelBuilder.Entity<ProfessionRef>(entity =>
            {
                entity.ToTable("profession_ref");

                entity.HasComment("справочник профессий");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasComment("код профессии");

                entity.Property(e => e.ProfessionName)
                    .IsRequired()
                    .HasColumnName("profession_name")
                    .HasComment("имя профессии");
            });

            modelBuilder.Entity<ServiceRef>(entity =>
            {
                entity.ToTable("service_ref");

                entity.HasComment("справочник услуг");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ServiceName)
                    .IsRequired()
                    .HasColumnName("service_name");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user");

                entity.HasComment("таблица пользователей");

                entity.HasIndex(e => e.CityId)
                    .HasName("city_id_fk_ind");

                entity.HasIndex(e => e.Mail)
                    .HasName("mail_uq_ind")
                    .IsUnique();

                entity.HasIndex(e => e.Nikname)
                    .HasName("nikname_uq_ind")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasComment("id пользователя");

                entity.Property(e => e.CityId)
                    .HasColumnName("city_id")
                    .HasComment("id города");

                entity.Property(e => e.Mail)
                    .IsRequired()
                    .HasColumnName("mail")
                    .HasColumnType("text")
                    .HasComment("почта");

                entity.Property(e => e.Nikname)
                    .IsRequired()
                    .HasColumnName("nikname")
                    .HasColumnType("text")
                    .HasComment("имя пользователя");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasComment("пароль");

                entity.Property(e => e.Picture)
                    .IsRequired()
                    .HasColumnName("picture")
                    .HasComment("картинка");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("user_ibfk_1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
