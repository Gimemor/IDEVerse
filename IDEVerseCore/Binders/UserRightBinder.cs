using IdeVerseContracts.Dto;
using RBCAcademyDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RBCAcademyCore.Binders
{
	public class UserRightBinder
	{
		public static UserRightDto BindFrom(UserRight userRight, UserRightDto userRightDto)
		{
			userRightDto.Id = userRight.Id;
			userRightDto.Mnemo = userRight.Mnemo;
			userRightDto.Title = userRight.Title;
			userRightDto.Description = userRight.Description;
			return userRightDto;
		}

		public static UserRight BindTo(UserRight userRight, UserRightDto userRightDto)
		{
			userRight.Mnemo = userRightDto.Mnemo;
			userRight.Title = userRightDto.Title;
			userRight.Description = userRightDto.Description;
			return userRight;
		}
	}
}
