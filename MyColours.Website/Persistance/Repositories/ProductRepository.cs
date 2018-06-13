using MyColours.Website.Core.Domain.Products;
using MyColours.Website.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MyColours.Website.Persistance.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public ApplicationDbContext MyColoursDbContext => Context as ApplicationDbContext;

        public override Product Get(int id)
        {
            return MyColoursDbContext.Products
                .Include(x => x.Manufacturer)
                .Include(x => x.ProductType)
                .SingleOrDefault(x => x.Id == id);
        }

        public override IEnumerable<Product> GetAll()
        {
            return MyColoursDbContext.Products
                .Include(x => x.Manufacturer)
                .Include(x => x.ProductType)
                .AsEnumerable();
        }

        public Manufacturer GetManufacturer(int id)
        {
            return MyColoursDbContext.Manufacturers.Find(id);
        }

        public IEnumerable<Manufacturer> GetAllManufacturers()
        {
            return MyColoursDbContext.Manufacturers;
        }

        public ProductType GetProductType(int id)
        {
            return MyColoursDbContext.ProductTypes.Find(id);
        }

        public IEnumerable<ProductType> GetAllProductTypes()
        {
            return MyColoursDbContext.ProductTypes;
        }
    }
}