using System.Data.Entity;

namespace ORM
{
    public interface IEF_DbContext
    {
        DbSet<Categories> Categories { get; set; }
        DbSet<CustomerDemographics> CustomerDemographics { get; set; }
        DbSet<Customers> Customers { get; set; }
        DbSet<Employees> Employees { get; set; }
        DbSet<Orders> Orders { get; set; }
        DbSet<Order_Details> Order_Details { get; set; }
        DbSet<Products> Products { get; set; }
        DbSet<Region> Region { get; set; }
        DbSet<Shippers> Shippers { get; set; }
        DbSet<Suppliers> Suppliers { get; set; }
        DbSet<sysdiagrams> sysdiagrams { get; set; }
        DbSet<Territories> Territories { get; set; }
    }
}