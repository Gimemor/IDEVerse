﻿using System;
using System.Collections.Generic;
using System.Text;

namespace IdeVerseContracts.Dto
{
	public class UserRightDto
	{
		public Guid Id { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public string Mnemo { get; set; }
	}
}
