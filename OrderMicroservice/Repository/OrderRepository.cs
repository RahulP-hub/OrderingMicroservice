using Microsoft.EntityFrameworkCore;
using OrderMicroservice.Models;
using OrderMicroservice.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderMicroservice.Repository
{
    public class OrderRepository : IOrderRepository
    {
        MicroServicesContext _microServicesContext;
        public OrderRepository(MicroServicesContext microServicesContext)
        {
            _microServicesContext = microServicesContext;
        }

        public async Task<List<OrderViewModel>> GetOrders()
        {
            try
            {
                if (_microServicesContext != null)
                {
                    return await (from o in _microServicesContext.Orders
                                  from c in _microServicesContext.Customers
                                  from l in _microServicesContext.Locations
                                  from s in _microServicesContext.Statuses
                                  where o.CustomerId == c.Id && o.LocationId == l.Id && o.StatusId == s.Id
                                  select new OrderViewModel
                                  {
                                      Id = o.Id,
                                      Address = l.LocationName,
                                      Address2 = o.Address2,
                                      Amount = o.Amount,
                                      CustomerFirstName = c.FirstName,
                                      CustomerLastName = c.LastName,
                                      OrderNumber = o.OrderNumber,
                                      ShipTo = o.ShipTo,
                                      Status = s.Status1,
                                      Tax = o.Tax
                                  }).ToListAsync();
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<OrderViewModel> Get(Guid? id)
        {
            try
            {
                if (_microServicesContext != null)
                {
                    return await (from o in _microServicesContext.Orders
                                  from c in _microServicesContext.Customers
                                  from l in _microServicesContext.Locations
                                  from s in _microServicesContext.Statuses
                                  where o.CustomerId == c.Id && o.LocationId == l.Id && o.StatusId == s.Id
                                  select new OrderViewModel
                                  {
                                      Id = o.Id,
                                      Address = l.LocationName,
                                      Address2 = o.Address2,
                                      Amount = o.Amount,
                                      CustomerFirstName = c.FirstName,
                                      CustomerLastName = c.LastName,
                                      OrderNumber = o.OrderNumber,
                                      ShipTo = o.ShipTo,
                                      Status = s.Status1,
                                      Tax = o.Tax
                                  }).FirstOrDefaultAsync();
                }

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Guid> Post(Order order)
        {
            try
            {
                if (_microServicesContext != null)
                {
                    await _microServicesContext.Orders.AddAsync(order);
                    await _microServicesContext.SaveChangesAsync();

                    return order.Id;
                }

                return Guid.Empty;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task Update(Order order)
        {
            if (_microServicesContext != null)
            {
                //Delete that post
                _microServicesContext.Orders.Update(order);

                //Commit the transaction
                await _microServicesContext.SaveChangesAsync();
            }
        }
        public async Task<int> Delete(Guid? id)
        {
            var result = 0;
            try
            {
                if (_microServicesContext != null)
                {
                    //Find the specific order based on the order id
                    var order = await _microServicesContext.Orders.FirstOrDefaultAsync(o => o.Id == id);

                    if (order != null)
                    {
                        //Delete that order
                        _microServicesContext.Orders.Remove(order);

                        //Commit the transaction
                        result = await _microServicesContext.SaveChangesAsync();
                    }
                    return result;
                }
                return result;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
