using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using TicketSystem.Models;

namespace TicketSystem.Data
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            
            using (var scope = serviceProvider.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                if (context.Users.Any()) return;

                context.Users.AddRange(
                    new User { MobileNumber = "1234567890" },
                    new User { MobileNumber = "0987654321" },
                    new User { MobileNumber = "1111111111" },
                    new User { MobileNumber = "2222222222" },
                    new User { MobileNumber = "3333333333" },
                    new User { MobileNumber = "4444444444" },
                    new User { MobileNumber = "5555555555" },
                    new User { MobileNumber = "6666666666" },
                    new User { MobileNumber = "7777777777" },
                    new User { MobileNumber = "8888888888" }
                );
                context.SaveChanges();
            }
            
        }
    }
}