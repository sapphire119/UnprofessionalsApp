﻿using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Xml.Linq;
using UnprofessionalsApp.Common;
using UnprofessionalsApp.Data;
using UnprofessionalsApp.Models;

namespace UnprofessionalsApp.Web.Extensions
{
	public static class DbInitializer
	{
		public static void Initialize(UnprofessionalsDbContext context, IServiceProvider services)
		{
			SeedImages(context);
			SeedFirms(context);
			SeedCategories(context);
			SeedRolesAndUsers(services, context).GetAwaiter().GetResult();
			SeedPosts(context);
			SeedTags(context);
			SeedTagsToPosts(context);
			SeedComments(context);
			SeedReplies(context);
		}

		private static void SeedImages(UnprofessionalsDbContext context)
		{
			if (context.Images.Any())
			{
				return;
			}

			var image = new Image
			{
				Url = WebUtility.UrlEncode(@"https://res.cloudinary.com/drljwifz6/image/upload/v1546913580/c2lqsd9grh81isygwfpk.jpg"),
			};

			var image1 = new Image
			{
				Url = WebUtility.UrlEncode(@"https://res.cloudinary.com/drljwifz6/image/upload/v1546913577/bx7fifjy9r8vr9axlzjl.jpg"),
			};

			var image2 = new Image
			{
				Url = WebUtility.UrlEncode(@"https://res.cloudinary.com/drljwifz6/image/upload/v1546913578/x8e7lozv0e1hwfdkyf7h.jpg"),
			};

			var image3 = new Image
			{
				Url = WebUtility.UrlEncode(@"https://res.cloudinary.com/drljwifz6/image/upload/v1546913525/sample.jpg"),
			};

			var defaultImage = new Image
			{
				Url = WebUtility.UrlEncode(@"https://res.cloudinary.com/drljwifz6/image/upload/v1546913578/i3dqehgyyvuwlicprzug.png")
			};

			var defaultImageUserProfile = new Image
			{
				Url = WebUtility.UrlEncode(@"https://res.cloudinary.com/drljwifz6/image/upload/v1546915744/pbxfokgqlc1alavasjqh.jpg")
			};

			var images = new List<Image>
			{
				defaultImage,
				image,
				image1,
				image2,
				image3,
				defaultImageUserProfile
			};

			context.Images.AddRange(images);

			context.SaveChanges();
		}

		private static void SeedReplies(UnprofessionalsDbContext context)
		{
			if (context.Replies.Any())
			{
				return;
			}

			var reply = new Reply
			{
				CommentId = 1,
				Description = "This is the first reply",
				UserId = 1
			};

			var reply1 = new Reply
			{
				CommentId = 2,
				Description = "This is the second reply",
				UserId = 1
			};

			var reply2 = new Reply
			{
				CommentId = 1,
				Description = "This is the third reply",
				UserId = 1
			};

			var reply3 = new Reply
			{
				CommentId = 1,
				Description = "This is the forth reply",
				UserId = 1
			};

			var reply4 = new Reply
			{
				CommentId = 1,
				Description = "Tsetsedsday",
				UserId = 1
			};

			var reply5 = new Reply
			{
				CommentId = 1,
				Description = "testy",
				UserId = 1
			};

			var reply6 = new Reply
			{
				CommentId = 1,
				Description = "Tasdasdgasjdply",
				UserId = 1
			};

			var replies = new List<Reply>
			{
				reply,
				reply1,
				reply2,
				reply3,
				reply4,
				reply5,
				reply6,
			};

			context.Replies.AddRange(replies);

			context.SaveChanges();
		}

		private static void SeedComments(UnprofessionalsDbContext context)
		{
			if (context.Comments.Any())
			{
				return;
			}

			var comment = new Comment
			{
				Description = "test my new awesome comment",
				PostId = 1,
				UserId = 1
			};

			var comment1 = new Comment
			{
				Description = "awesome comment is awesome",
				PostId = 1,
				UserId = 1
			};

			var comment2 = new Comment
			{
				Description = "test test test test test",
				PostId = 1,
				UserId = 1
			};

			var comment3 = new Comment
			{
				Description = "test my new awesome comment",
				PostId = 1,
				UserId = 1
			};

			var comment4 = new Comment
			{
				Description = "test my new awesome comment",
				PostId = 1,
				UserId = 1
			};

			var comment5 = new Comment
			{
				Description = "test my new awesome comment",
				PostId = 1,
				UserId = 1
			};

			var comment6 = new Comment
			{
				Description = "test my new awesome comment",
				PostId = 1,
				UserId = 1
			};

			var comments = new List<Comment>
			{
				comment,
				comment1,
				comment2,
				comment3,
				comment4,
				comment5,
				comment6,
			};

			context.Comments.AddRange(comments);

			context.SaveChanges();
		}

		private static void SeedTagsToPosts(UnprofessionalsDbContext context)
		{
			if (context.TagsPosts.Any()) return;

			var tagPost = new TagPost { PostId = 1, TagId = 1 };
			var tagPost1 = new TagPost { PostId = 1, TagId = 2 };
			var tagPost2 = new TagPost { PostId = 1, TagId = 3 };
			var tagPost3 = new TagPost { PostId = 1, TagId = 4 };
			var tagPost4 = new TagPost { PostId = 1, TagId = 5 };
			var tagPost5 = new TagPost { PostId = 1, TagId = 6 };
			var tagPost6 = new TagPost { PostId = 1, TagId = 7 };
			var tagPost7 = new TagPost { PostId = 2, TagId = 1 };
			var tagPost8 = new TagPost { PostId = 2, TagId = 2 };
			var tagPost9 = new TagPost { PostId = 2, TagId = 3 };
			var tagPost10 = new TagPost { PostId = 2, TagId = 4 };
			var tagPost11 = new TagPost { PostId = 2, TagId = 5 };
			var tagPost12 = new TagPost { PostId = 2, TagId = 6 };
			var tagPost13 = new TagPost { PostId = 2, TagId = 7 };


			var tagPost14 = new TagPost { PostId = 4, TagId = 3 };
			var tagPost15 = new TagPost { PostId = 5, TagId = 4 };
			var tagPost16 = new TagPost { PostId = 3, TagId = 5 };
			var tagPost17 = new TagPost { PostId = 3, TagId = 6 };
			var tagPost18 = new TagPost { PostId = 5, TagId = 7 };


			var tagsPosts = new List<TagPost>
			{
				tagPost,
				tagPost1,
				tagPost2,
				tagPost3,
				tagPost4,
				tagPost5,
				tagPost6,
				tagPost7,
				tagPost8,
				tagPost9,
				tagPost10,
				tagPost11,
				tagPost12,
				tagPost13,
				tagPost14,
				tagPost15,
				tagPost16,
				tagPost17,
				tagPost18
			};

			context.TagsPosts.AddRange(tagsPosts);

			context.SaveChanges();
		}

		private static void SeedTags(UnprofessionalsDbContext context)
		{
			if (context.Tags.Any()) return;

			var tag = new Tag { Name = "Softuni" };
			var tag1 = new Tag { Name = "Exam" };
			var tag2 = new Tag { Name = "Culture" };
			var tag3 = new Tag { Name = "Fun" };
			var tag4 = new Tag { Name = "Finance" };
			var tag5 = new Tag { Name = "Money" };
			var tag6 = new Tag { Name = "Entertainment" };
			var tag7 = new Tag { Name = "Gaming" };
			var tag8 = new Tag { Name = "Dancing" };
			var tag9 = new Tag { Name = "Shooting" };
			var tag10 = new Tag { Name = "Industry" };
			var tag11 = new Tag { Name = "IT" };
			var tag12 = new Tag { Name = "Services" };
			var tag13 = new Tag { Name = "Manufacturing" };
			var tag14 = new Tag { Name = "Fishing" };
			var tag15 = new Tag { Name = "Sports" };
			var tag16 = new Tag { Name = "Trading" };
			var tag17 = new Tag { Name = "Software" };
			var tag18 = new Tag { Name = "Development" };
			var tag19 = new Tag { Name = "Specialized" };
			var tag20 = new Tag { Name = "Boats" };
			var tag21 = new Tag { Name = "Airplanes" };
			var tag22 = new Tag { Name = "Food" };
			var tag23 = new Tag { Name = "Restaurants" };
			var tag24 = new Tag { Name = "Relax" };
			var tag25 = new Tag { Name = "Flying" };

			var tagsToAdd = new List<Tag>
			{
				tag,
				tag1,
				tag2,
				tag3,
				tag4,
				tag5,
				tag6,
				tag7,
				tag8,
				tag9,
				tag10,
				tag11,
				tag12,
				tag13,
				tag14,
				tag15,
				tag16,
				tag17,
				tag18,
				tag19,
				tag20,
				tag21,
				tag22,
				tag23,
				tag24,
				tag25,
			};

			context.Tags.AddRange(tagsToAdd);

			context.SaveChanges();
		}

		private static void SeedPosts(UnprofessionalsDbContext context)
		{
			if (context.Posts.Any()) return;

			var post = new Post
			{
				CategoryId = 1,
				UserId = 1,
				Description = "orem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop p",
				Title = "Lorem ipsum",
				ImageId = 1
			};

			var post1 = new Post
			{
				CategoryId = 2,
				UserId = 2,
				Description = "orem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop p",
				Title = "Ipsum Lorem",
				ImageId = 2,
			};
			var post2 = new Post
			{
				CategoryId = 4,
				UserId = 3,
				Description = "orem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop p",
				Title = "Ipsum Lorem",
				ImageId = 3,
			};

			var post3 = new Post
			{
				CategoryId = 7,
				UserId = 4,
				Description = "orem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop p",
				Title = "Ipsum Lorem",
				ImageId = 4,
			};

			var post4 = new Post
			{
				CategoryId = 6,
				UserId = 1,
				DateOfCreation = DateTime.UtcNow.AddDays(-10),
				Description = "Test Post for date time",
				Title = "Test Date TIme",
				ImageId = 5,
			};

			var post5 = new Post
			{
				CategoryId = 3,
				UserId = 1,
				DateOfCreation = DateTime.UtcNow.AddDays(-15),
				Description = "Test Post for no image",
				Title = "Test for no image",
				ImageId = 1,
			};

			var post6 = new Post
			{
				CategoryId = 1,
				UserId = 1,
				DateOfCreation = DateTime.UtcNow.AddDays(-9),
				Description = "Test Postsss",
				Title = "No image",
				ImageId = 1,
			};

			var post7 = new Post
			{
				CategoryId = 1,
				UserId = 2,
				DateOfCreation = DateTime.UtcNow.AddDays(-9),
				Description = "Test",
				Title = "Yes image",
				ImageId = 1,
			};

			var post8 = new Post
			{
				CategoryId = 1,
				UserId = 4,
				DateOfCreation = DateTime.UtcNow.AddDays(-7),
				Description = "Test Postsss",
				Title = "All Hail",
				ImageId = 1,
			};

			var post9 = new Post
			{
				CategoryId = 1,
				UserId = 4,
				FirmId = Guid.Parse("BE1D0710-8CC7-4A30-95D0-0052F11ABBAF"),
				DateOfCreation = DateTime.UtcNow.AddDays(-16),
				Description = "Firm post",
				Title = "Firm post",
				ImageId = 1,
			};

			var post10 = new Post
			{
				CategoryId = 1,
				UserId = 4,
				FirmId = Guid.Parse("BE1D0710-8CC7-4A30-95D0-0052F11ABBAF"),
				DateOfCreation = DateTime.UtcNow.AddDays(-5),
				Description = "Firm postttt",
				Title = "Firm posttt",
				ImageId = 1,
			};

			var post11 = new Post
			{
				CategoryId = 2,
				UserId = 1,
				FirmId = Guid.Parse("BE1D0710-8CC7-4A30-95D0-0052F11ABBAF"),
				DateOfCreation = DateTime.UtcNow.AddDays(-50),
				Description = "Firm posttttahjskd",
				Title = "Firm posttthaskjdsad",
				ImageId = 1,
			};

			var post12 = new Post
			{
				CategoryId = 3,
				UserId = 1,
				FirmId = Guid.Parse("BE1D0710-8CC7-4A30-95D0-0052F11ABBAF"),
				DateOfCreation = DateTime.UtcNow.AddDays(-3),
				Description = "asdhaskjdkd",
				Title = "Fiasdasdkjdsad",
				ImageId = 2,
			};

			var post13 = new Post
			{
				CategoryId = 5,
				UserId = 1,
				FirmId = Guid.Parse("BE1D0710-8CC7-4A30-95D0-0052F11ABBAF"),
				DateOfCreation = DateTime.UtcNow.AddDays(-13),
				Description = "Firm post is firm post",
				Title = "Coke",
				ImageId = 3,
			};

			var post14 = new Post
			{
				CategoryId = 2,
				UserId = 1,
				FirmId = Guid.Parse("BE1D0710-8CC7-4A30-95D0-0052F11ABBAF"),
				DateOfCreation = DateTime.UtcNow.AddDays(-14),
				Description = "Mr.Random",
				Title = "Random is Random",
				ImageId = 4,
			};

			var post15 = new Post
			{
				CategoryId = 1,
				UserId = 1,
				FirmId = Guid.Parse("BE1D0710-8CC7-4A30-95D0-0052F11ABBAF"),
				DateOfCreation = DateTime.UtcNow.AddDays(-17),
				Description = "Firm Firm Firm Firm Firm Firm",
				Title = "Firm's Firm",
				ImageId = 5,
			};

			var post16 = new Post
			{
				CategoryId = 6,
				UserId = 1,
				FirmId = Guid.Parse("BE1D0710-8CC7-4A30-95D0-0052F11ABBAF"),
				DateOfCreation = DateTime.UtcNow.AddDays(-14),
				Description = "IBM",
				Title = "CIA FBI BAI IVAN",
				ImageId = 3,
			};

			var post17 = new Post
			{
				CategoryId = 4,
				UserId = 1,
				FirmId = Guid.Parse("BE1D0710-8CC7-4A30-95D0-0052F11ABBAF"),
				DateOfCreation = DateTime.UtcNow.AddDays(-12),
				Description = "Dim4o",
				Title = "Vizitka",
				ImageId = 1,
			};

			var post18 = new Post
			{
				CategoryId = 9,
				UserId = 1,
				FirmId = Guid.Parse("BE1D0710-8CC7-4A30-95D0-0052F11ABBAF"),
				DateOfCreation = DateTime.UtcNow.AddDays(-18),
				Description = "Million Million Million",
				Title = "VZEMI TOZI SHHHHHHH",
				ImageId = 1,
			};

			var posts = new List<Post>()
			{
				post,
				post1,
				post2,
				post3,
				post4,
				post5,
				post6,
				post7,
				post8,
				post9,
				post10,
				post11,
				post12,
				post13,
				post14,
				post15,
				post16,
				post17,
				post18,
			};

			context.Posts.AddRange(posts);

			context.SaveChanges();
		}

		private static void SeedCategories(UnprofessionalsDbContext context)
		{
			if (context.Categories.Any()) return;


			var category = new Category { Name = "Machinery" };
			var category1 = new Category { Name = "Finance" };
			var category2 = new Category { Name = "Education" };
			var category3 = new Category { Name = "Services" };
			var category4 = new Category { Name = "Foods" };
			var category5 = new Category { Name = "Hotels" };
			var category6 = new Category { Name = "Restaurants" };
			var category7 = new Category { Name = "Industrial" };
			var category8 = new Category { Name = "Economy" };
			var category9 = new Category { Name = "Culture" };
			var category10 = new Category { Name = "Art" };
			var category11 = new Category { Name = "Entertainment" };
			var category12 = new Category { Name = "Inforamtion" };
			var category13 = new Category { Name = "IT" };
			var category14 = new Category { Name = "Specialized services" };

			var categories = new List<Category>
			{
				category,
				category1,
				category2,
				category3,
				category4,
				category5,
				category6,
				category7,
				category8,
				category9,
				category10,
				category11,
				category12,
				category13,
				category14,
			};

			context.Categories.AddRange(categories);

			context.SaveChanges();
		}

		private static void SeedFirms(UnprofessionalsDbContext context)
		{
			if (context.Firms.Any()) return;
			

			// get the location we want to get the sitemaps from 
			string dirLoc = @"D:\TR\";

			var isDbSeeded = false;
			// get all teh sitemaps 
			List<string> sitemaps = GetFileList("*", dirLoc).ToList();

			if (!sitemaps.All(map => map.EndsWith(".xml")))
			{
				var unsupportedFiles = sitemaps.Where(map => !map.EndsWith(".xml")).ToArray();

				throw new Exception($"Folder contains files in unsupported format: " +
					$"{string.Join(Environment.NewLine, unsupportedFiles)}");
			}


			var currentFirms = new List<Firm>();

			// loop through each file 
			foreach (string sitemap in sitemaps)
			{
				if (isDbSeeded)
				{
					break;
				}

				var xmlString = File.ReadAllText(sitemap);


				// new xdoc instance 
				XDocument xDoc = XDocument.Parse(xmlString);

				var root = xDoc.Root.Elements();

				foreach (var xElement in root)
				{
					var elements = xElement.Elements().ToArray();
					if (xElement.Name.LocalName == "Body")
					{
						var deedsAll = elements.Elements().ToArray();

						foreach (var deed in deedsAll)
						{
							var firmId = deed.Attribute("GUID")?.Value ?? string.Empty;

							var bulstat = deed.Attribute("UIC")?.Value ?? string.Empty;

							var companyName = deed.Attribute("CompanyName")?.Value ?? string.Empty;

							var legalForm = deed.Attribute("LegalForm")?.Value ?? string.Empty;

							if (string.IsNullOrWhiteSpace(firmId) ||
								string.IsNullOrWhiteSpace(bulstat) ||
								string.IsNullOrWhiteSpace(companyName) ||
								string.IsNullOrWhiteSpace(legalForm))
							{
								throw new Exception($"Coudn't save data for firm: \n {deed?.Value ?? string.Empty}");
							}

							var isValidGuid = Guid.TryParse(firmId, out var firmGuidId);
							if (!isValidGuid)
							{
								throw new Exception("Coudn't parse guid id");
							}

							var currentFirm = new Firm
							{
								Id = firmGuidId,
								Name = companyName,
								UniqueFirmId = bulstat,
								LegalForm = legalForm,
								DateOfRegistration = RandomDate()
							};

							if (currentFirms.Any(f =>
									f.Id == currentFirm.Id || f.UniqueFirmId == currentFirm.UniqueFirmId))
							{
								continue;
							}

							currentFirms.Add(currentFirm);
						}

						if (currentFirms.Count > 1200)
						{
							isDbSeeded = true;
							break;
						}
					}

				}
			}

			context.AddRange(currentFirms);

			context.SaveChanges();
		}

		private static async Task SeedRolesAndUsers(IServiceProvider services, UnprofessionalsDbContext context)
		{
			await CreateUserRoles(services, context);

			await CreatePowerUser(services, context);
		}

		private static async Task CreatePowerUser(IServiceProvider serviceProvider, UnprofessionalsDbContext context)
		{
			if (context.Users.Any()) return;

			var userManager = serviceProvider.GetRequiredService<UserManager<UnprofessionalsAppUser>>();
			//Here you could create a super user who will maintain the web app
			var poweruser = new UnprofessionalsAppUser
			{
				UserName = /*Configuration["AppSettings:UserName"]*/"admin",
				Email = /*Configuration["AppSettings:UserEmail"]*/"admin@admin.admin",
				Description = "bai ivan",
				ImageId = 6
			};
			//Ensure you have these values in your appsettings.json file
			string userPWD = /*Configuration["AppSettings:UserPassword"]*/ "asd123";
			var _user = await userManager.FindByNameAsync("admin");

			if (_user == null)
			{
				var createPowerUser = await userManager.CreateAsync(poweruser, userPWD);
				if (createPowerUser.Succeeded)
				{
					//here we tie the new user to the role
					await userManager.AddToRoleAsync(poweruser, GlobalConstants.AdminRole);
				}
			}

			var user = new UnprofessionalsAppUser
			{
				UserName = "Pesho",
				Email = "asd@asd.asd",
				Description = "tuk i tam",
				ImageId = 6
			};

			var user1 = new UnprofessionalsAppUser
			{
				UserName = "Stamat",
				Email = "asd@asd.dsa",
				Description = "tuk i tam",
				ImageId = 6
			};
			var user2 = new UnprofessionalsAppUser
			{
				UserName = "Gosho",
				Email = "asd@dsa.asd",
				Description = "tuk i tam",
				ImageId = 6
			};
			var user3 = new UnprofessionalsAppUser
			{
				UserName = "Ivan",
				Email = "asd@dsa.dsa",
				Description = "tuk i tam",
				ImageId = 6
			};
			var user4 = new UnprofessionalsAppUser
			{
				UserName = "Dimitar",
				Email = "dsa@asd.asd",
				Description = "tuk i tam",
				ImageId = 6
			};

			var createUser = await userManager.CreateAsync(user, userPWD);
			if (createUser.Succeeded)
			{
				//here we tie the new user to the role
				await userManager.AddToRoleAsync(user, GlobalConstants.UserRole);
			}

			var createUser1 = await userManager.CreateAsync(user1, userPWD);
			if (createUser.Succeeded)
			{
				//here we tie the new user to the role
				await userManager.AddToRoleAsync(user1, GlobalConstants.UserRole);
			}

			var createUser2 = await userManager.CreateAsync(user2, userPWD);
			if (createUser.Succeeded)
			{
				//here we tie the new user to the role
				await userManager.AddToRoleAsync(user2, GlobalConstants.UserRole);
			}

			var createUser3 = await userManager.CreateAsync(user3, userPWD);
			if (createUser.Succeeded)
			{
				//here we tie the new user to the role
				await userManager.AddToRoleAsync(user3, GlobalConstants.UserRole);
			}

			var createUser4 = await userManager.CreateAsync(user4, userPWD);
			if (createUser.Succeeded)
			{
				//here we tie the new user to the role
				await userManager.AddToRoleAsync(user4, GlobalConstants.UserRole);
			}

		}

		private static async Task CreateUserRoles(IServiceProvider serviceProvider, UnprofessionalsDbContext context)
		{
			if (context.Roles.Any()) return;

			var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole<int>>>();

			IdentityResult roleResult;

			foreach (var roleName in GlobalConstants.ApprovedRoles)
			{
				var roleExist = await roleManager.RoleExistsAsync(roleName);
				if (!roleExist)
				{
					//create the roles and seed them to the database: Question 1
					roleResult = await roleManager.CreateAsync(new IdentityRole<int>(roleName));
				}
			}
		}

		private static IEnumerable<string> GetFileList(string fileSearchPattern, string rootFolderPath)
		{
			Queue<string> pending = new Queue<string>();
			pending.Enqueue(rootFolderPath);
			string[] tmp;
			while (pending.Count > 0)
			{
				rootFolderPath = pending.Dequeue();
				try
				{
					tmp = Directory.GetFiles(rootFolderPath, fileSearchPattern);
				}
				catch (UnauthorizedAccessException)
				{
					continue;
				}
				for (int i = 0; i < tmp.Length; i++)
				{
					yield return tmp[i];
				}
				tmp = Directory.GetDirectories(rootFolderPath);
				for (int i = 0; i < tmp.Length; i++)
				{
					pending.Enqueue(tmp[i]);
				}
			}
		}

		private static DateTime RandomDate()
		{
			DateTime start = new DateTime(1995, 1, 1);
			Random gen = new Random();
			int range = ((TimeSpan)(DateTime.Today - start)).Days;
			var result = start.AddDays(gen.Next(range));
			return result;
		}
	}
}
