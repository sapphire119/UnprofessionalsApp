﻿using System.Collections.Generic;
using UnprofessionalsApp.Common;

namespace UnprofessionalsApp.Models
{
	public class Tag : BaseModel<int>
	{
		public string Name { get; set; }

		public bool IsDeleted { get; set; } = false;

		public virtual ICollection<TagPost> Posts { get; set; } = new HashSet<TagPost>();
	}
}
