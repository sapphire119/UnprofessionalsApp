﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using UnprofessionalsApp.CustomAttributes;

namespace UnprofessionalsApp.ViewInputModels.InputModels.Posts
{
	public class PostCreateInputModel
	{
		[Required]
		[StringLength(20, MinimumLength = 2, ErrorMessage = "Title must be between {0} and {1} characters")]
		public string Title { get; set; }

		[Required]
		[DataType(DataType.MultilineText)]
		public string Description { get; set; }
		
		[CustomFileExtension(".jpg, .png, .jpeg, .gif", ErrorMessage = "Accepted file formats are: {0}")]
		public IFormFile ImageFile { get; set; }
		
		[Display(Name = "Category")]
		public int CategoryId { get; set; }

		[RegularExpression(@"^\d{9}$")]
		public string FirmUniqueId { get; set; }

		[Required]
		[RegularExpression(@"^[^'%@&*^!]+$", ErrorMessage = "Invalid tags format")]
		public string Tags { get; set; }


										   //[Required]
										   //[StringLength(15, MinimumLength = 3)]
										   //[RegularExpression(@"^\w+[.\-_]*\w*$")]
										   //public string Username { get; set; }

		//public int CategoryId { get; set; }

		//[Required]
		//[RegularExpression(@"^\w+[.\-_]*\w*$")]
		//public string Username { get; set; }

	}
}
