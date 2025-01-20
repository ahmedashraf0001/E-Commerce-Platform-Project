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
    internal class OrderDetailsRepos : Repository<OrderDetails>
    {
        EcommerceContextDB context;
        public OrderDetailsRepos(EcommerceContextDB _cntx) : base(_cntx) { context = _cntx; }
        public List<OrderDetails> GetOrderDetailsByOrderId(int orderId)
        {
            return context.OrderDetails.Where(od => od.OrderId == orderId).ToList();
        }
    }
}

