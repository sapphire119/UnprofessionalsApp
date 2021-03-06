using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UnprofessionalsApp.Common;
using UnprofessionalsApp.DataServices.Contracts;
using UnprofessionalsApp.ViewInputModels.InputModels.Categories;
using UnprofessionalsApp.ViewInputModels.InputModels.Firms;

namespace UnprofessionalsApp.Web.Pages.TestPage
{
    public class IndexModel : PageModel
    {
		private readonly ICategoriesService categoriesService;

		public IndexModel(ICategoriesService categoriesService)
		{
			this.categoriesService = categoriesService;
		}

		[BindProperty]
		public CreateCategoryInputModel InputModel { get; set; }

		public void OnGet()
        {
        }

		public async Task<IActionResult> OnPostAsync()
		{
			if (!ModelState.IsValid)
			{
				var errors = 
					this.ModelState.SelectMany(t => t.Value.Errors.Select(e => e.ErrorMessage));

				foreach (var error in errors)
				{
					this.ModelState.AddModelError(string.Empty, error);
				}
			}

			var statusResult = await this.categoriesService.CreateCategory(this.InputModel);

			if (statusResult < GlobalConstants.SuccessfullySavedIntoDbContextStatusCode)
			{
				this.ModelState.AddModelError(string.Empty, GlobalConstants.DefaultNotSavedIntoDbContextMessage);

				return this.Page();
			}
			
			return this.Redirect("/categories/index");
		}
    }
}