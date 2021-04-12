using Autofac;
using IdeVerseContracts.Services;
using IdeVerseContracts.UserManager;
using RBCAcademyCore.Services;
using RBCAcademyDb;

namespace RBCAcademyCore
{
	public class CoreModuleLibrary : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			base.Load(builder);
			builder.Register<UserManager>((context) =>
			{
				var dataContext = context.Resolve<MainContext>();
				var idProvider = context.Resolve<IUserIdProvider>();
				return   UserManager.Create(idProvider, dataContext);
			});
			builder.RegisterType<UserRoleService>().As<IUserRoleService>();
			builder.RegisterType<UserService>().As<IUserService>();
			builder.RegisterType<SubjectService>().As<ISubjectService>();
			builder.RegisterType<SubjectTaskService>().As<ISubjectTaskService>();
			builder.RegisterType<ScheduleService>().As<IScheduleService>();
			builder.RegisterType<UserRightService>().As<IUserRightService>();
		}
	}
}
