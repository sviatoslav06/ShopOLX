using DataAccess.Data;
using DataAccess.Data.Entities;
using DataAccess.Migrations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using ShopOLX.Helpers;
using System.Runtime.Intrinsics.Arm;
using System.Security.Claims;

namespace ShopOLX.Controllers
{
    public class LikeController : Controller
    {
        private readonly ShopDbContext ctx;
        private string CurrentUserId => User.FindFirstValue(ClaimTypes.NameIdentifier);

        public LikeController(ShopDbContext ctx)
        {
            this.ctx = ctx;
        }

        public async Task<IActionResult> AddFavorite(int id)
        {
            if (id == 0)
            {
                return Redirect("../Index");
            }
            var user = await ctx.Users.FirstOrDefaultAsync(t => t.Id == CurrentUserId);
            if (user == null)
            {
                return Redirect("../Index");
            }
            var product = await ctx.Products.FirstOrDefaultAsync(t => t.Id ==  id);
            var favorite = new Favorite
            {
                UserId = user.Id,
                Products = new List<Product> { product },
                Date = DateTime.UtcNow,
            };
            await ctx.Set<Favorite>().AddAsync(favorite);
            await ctx.SaveChangesAsync();
            return Redirect("../Index");
        }

        public async Task<IActionResult> Index()
        {
            var result = await ctx.Users
                .Where(t => t.Id == CurrentUserId)
                .Include(t => t.Favorites)
                .ThenInclude(t => t.Products)
                .SelectMany(t => t.Favorites)
                .SelectMany(t => t.Products)
                .AsNoTracking()
                .ToListAsync();
            return View(result);
        }

        public async Task<IActionResult> UnLike(int id)
        {
            if (id == 0)
            {
                return Redirect("../Index");
            }

            var user = await ctx.Users.FirstOrDefaultAsync(t => t.Id == CurrentUserId);

            if (user == null)
            {
                return Redirect("../Index");
            }

            var favorite = await ctx.Favorites
                .Include(f => f.Products)
                .Where(f => f.UserId == CurrentUserId)
                .FirstOrDefaultAsync();

            if (favorite != null)
            {
                var productToRemove = favorite.Products.FirstOrDefault(p => p.Id == id);

                if (productToRemove != null)
                {
                    favorite.Products.Remove(productToRemove);
                    await ctx.SaveChangesAsync();
                }
            }

            return RedirectToAction("Index");
        }
    }
}
