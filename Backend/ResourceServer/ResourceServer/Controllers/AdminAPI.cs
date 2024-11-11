/*
using AuthenticationServer.Model;
using Microsoft.AspNetCore.Http.HttpResults;
using ResourceServer.Repositories;

namespace ResourceServer.Controllers
{
    public static class AdminAPI
    {

        public static void ConfigureAdminAPI(this WebApplication app)
        {
            app.MapPost("post", Create);
            app.MapGet("get", GetAdmin);
        }

        private static async Task<IResult> Create(Admin adminPost, IAdminRepository service)
        {
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(adminPost.Password);
            var admin = new Admin();

            admin.FullName = adminPost.FullName;
            admin.Password = passwordHash;
            admin.AdminTypeId = adminPost.AdminTypeId;

            await service.Insert(admin);

            return Results.Ok(adminPost);
        }

        private static string GetAdmin()
        {
            return "hej";
        }
    }
}
*/