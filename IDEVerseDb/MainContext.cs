using Microsoft.EntityFrameworkCore;

namespace RBCAcademyDb
{
	public class MainContext : DbContext
	{
		public DbSet<UserRole> Roles { get; set; }
		public DbSet<User> Users { get; set; }
		public DbSet<Subject> Subjects { get; set; }
		public DbSet<SubjectAssignment> SubjectAssignments { get; set; }
		public DbSet<SubjectTask> Tasks { get; set; }
		public DbSet<ScheduleEntry> ScheduleEntries { get; set; }
		public DbSet<UserRight> Rights { get; set; }

		public MainContext(DbContextOptions options) : base(options)
		{

		}

		/// <summary>
		/// Сюда записываем кастомные правила, чтобы обойти соглашения EF
		/// </summary>
		protected override void OnModelCreating(ModelBuilder modelBuilder) {
			base.OnModelCreating(modelBuilder);
			Map(modelBuilder);
		}


		public static void Map(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new UserRole.Map());
			modelBuilder.ApplyConfiguration(new User.Map());
			modelBuilder.ApplyConfiguration(new Subject.Map());
			modelBuilder.ApplyConfiguration(new SubjectAssignment.Map());
			modelBuilder.ApplyConfiguration(new ScheduleEntry.Map());
			modelBuilder.ApplyConfiguration(new SubjectTask.Map());
			modelBuilder.ApplyConfiguration(new TaskGrade.Map());
			modelBuilder.ApplyConfiguration(new ScheduleEntry.Map());
			modelBuilder.ApplyConfiguration(new ScheduleAttendance.Map());
			modelBuilder.ApplyConfiguration(new UserRight.Map());
			modelBuilder.ApplyConfiguration(new RightToRole.Map());
		}
	}
}
 