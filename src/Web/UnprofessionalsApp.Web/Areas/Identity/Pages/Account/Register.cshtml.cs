﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using UnprofessionalsApp.Common;
using UnprofessionalsApp.CustomAttributes;
using UnprofessionalsApp.DataServices.Contracts;
using UnprofessionalsApp.Models;
using UnprofessionalsApp.Web.Extensions;

namespace UnprofessionalsApp.Web.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<UnprofessionalsAppUser> signInManager;
		private readonly UserManager<UnprofessionalsAppUser> userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;
		private readonly IImagesService imageService;
		private readonly IFilesService filesService;

		public RegisterModel(
            UserManager<UnprofessionalsAppUser> userManager,
            SignInManager<UnprofessionalsAppUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender,
			IImagesService imageService,
			IFilesService filesService)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
			this.imageService = imageService;
			this.filesService = filesService;
		}

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public class InputModel
        {
			[Required]
			[StringLength(15, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 1)]
			[Display(Name = "Username")]
			public string Username { get; set; }


			[Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }

			
			[CustomFileExtension(".jpg, .png, .jpeg, .gif", ErrorMessage = "Accepted file formats are: {0}")]
			public IFormFile ImageFile { get; set; }
		}

		
        public void OnGet(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");

			if (this.User.Identity.IsAuthenticated)
			{
				_logger.LogInformation("You are already logged in.");
				return LocalRedirect(returnUrl);
			}

			if (ModelState.IsValid)
            {
				var user = new UnprofessionalsAppUser { UserName = Input.Username, Email = Input.Email };

				if (Input.ImageFile != null)
				{
					var filePath = await this.filesService.ReadFile(Input.ImageFile);

					var uploadResult = 
						await this.imageService.UploadImageFromFilePath(filePath);

					var imageUrl = this.imageService.GetUrlPath(uploadResult);

					var image = await this.imageService.CreateImage(imageUrl);

					user.Image = image;
				}
				else
				{
					user.ImageId = GlobalConstants.DefaultUserImageId;
				}
				

                var result = await this.userManager.CreateAsync(user, Input.Password);
				
                if (result.Succeeded)
                {
					_logger.LogInformation("User created a new account with password.");


					//var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
					//var callbackUrl = Url.Page(
					//    "/Account/ConfirmEmail",
					//    pageHandler: null,
					//    values: new { userId = user.Id, code = code },
					//    protocol: Request.Scheme);

					//await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
					//    $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

					await this.userManager.AddToRoleAsync(user, GlobalConstants.UserRole);

					await signInManager.SignInAsync(user, isPersistent: false);

                    return LocalRedirect(returnUrl);
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
