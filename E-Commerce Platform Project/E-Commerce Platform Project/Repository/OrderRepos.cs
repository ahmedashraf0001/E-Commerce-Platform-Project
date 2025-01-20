using E_Commerce_Platform_Project.Context;
using E_Commerce_Platform_Project.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Platform_Project.Repository
{
    internal class OrderRepos : Repository<Order>
    {
        EcommerceContextDB _context;
        public OrderRepos(EcommerceContextDB context) : base(context) { _context = context; }

        public List<Order> GetOrdersByCustomerId(int customerId)
        {
            return _context.Orders.Where(o => o.CustomerId == customerId).ToList();
        }

        public Order GetByCustomerId(int customerId)
        {
            return _context.Orders.FirstOrDefault(o => o.CustomerId == customerId);
        }
    }
}
