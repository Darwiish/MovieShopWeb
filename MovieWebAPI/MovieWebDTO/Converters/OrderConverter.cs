using System;
using MovieWebDAL.Model;
using MovieWebDTO.DTOs;
using System.Collections.Generic;

namespace MovieWebDTO
{
    public class OrderConverter : AbstractDtoConverter<Order, OrderDto>
    {
        public override OrderDto Convert(Order item)
        {
            var dto = new OrderDto() { Id = item.Id, Date = item.Date};
            if (item.OrderLines!=null)
            {
                dto.OrderLines = new List<OrderLineDto>();
                foreach (var ol in item.OrderLines)
                {
                    dto.OrderLines.Add(new OrderLineDto()
                    {
                        Id = ol.Id,
                        Amount = ol.Amount,
                        MovieId = ol.MovieId,
                        OrderId = ol.OrderId
                    });
                }
            }
            if (item.Customer != null)
            {
                 dto.Customer = new CustomerDto()
                {
                    Id = item.Id,
                    FirstName = item.Customer.FirstName,
                    LastName = item.Customer.LastName,
                    Address = item.Customer.Address,
                    Email = item.Customer.Email
                };
            }
            return dto;
        }

      
        public Order Convert(OrderDto orderDto)
        {
            throw new NotImplementedException();
        }
    }
}