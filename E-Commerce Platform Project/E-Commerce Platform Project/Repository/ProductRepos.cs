using E_Commerce_Platform_Project.Context;
using E_Commerce_Platform_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Platform_Project.Repository
{
    internal class ProductRepos : Repository<Product>
    {
        public ProductRepos(EcommerceContextDB _cntx) : base(_cntx)
        {
        }
    }
}
