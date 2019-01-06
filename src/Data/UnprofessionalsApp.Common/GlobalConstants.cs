﻿using System;
using System.Collections.Generic;
using System.Text;

namespace UnprofessionalsApp.Common
{
	public static class GlobalConstants
	{
		public static readonly string[] ApprovedRoles = { "Admin", "Manager", "User" };

		public const string AdminRole = "Admin";

		public const string ManagerRole = "Manager";

		public const string UserRole = "User";

		public const string CannotCreateDbMessage = @"An error occurred creating the DB.";

		public const string DefaultNoDescriptionMessage = @"User has not put in any description details";

		public const string DefaultNoPhoneNumberMessage = @"User has not put in any phone number";

		public const string DefaultNoEmailMessage = @"User has not put in any email address";

		public const string PostDetailsDateOfCreationFormat = @"{0} at {1}";

		public const int AllowedCharactersToRenderForPostDescription = 97;

		public const int AllowedCharactersToRenderForPostDetailsDescription = 25;

		public const string DescriptionExtensionStrings = "...";

		public const string DefaultImageUrl = @"https://upload.wikimedia.org/wikipedia/commons/thumb/6/6c/No_image_3x4.svg/1024px-No_image_3x4.svg.png";

		public const string NoDescriptionForUser = @"User has not put in any description about himself";

		public const string NoEmailForUser = @"User has not put in any email";

		public const string NoPhoneNumberForUser = @"User has not put in phone number";

		public const int TagsToRenderLimit = 8;

		public const int EntitiesPerPageLimit = 8;
	}
}
