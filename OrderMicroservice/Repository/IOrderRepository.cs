using OrderMicroservice.Models;
using OrderMicroservice.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderMicroservice.Repository
{
   public interface IOrderRepository
    {
        Task<List<OrderViewModel>> GetOrders();
        Task<OrderViewModel> Get(Guid? id);
        Task<Guid> Post(Order order);
        Task Update(Order order);
        Task<int> Delete(Guid? id);
    }
}
