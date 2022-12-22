using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace ShoppingitemApi.Models
{
    public class ShoppingitemContext : DbContext
    {
        public ShoppingitemContext(DbContextOptions<ShoppingitemContext> options)
            : base(options)
        {
        }

        public DbSet<ShoppingitemItem> ShoppingitemItems { get; set; } = null!;
    }
}