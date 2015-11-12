using System;
using System.Collections.Generic;
using MovieWebDAL.Model;
using MovieWebDTO.DTOs;

namespace MovieWebDTO
{
    public class OrderLineConverter : AbstractDtoConverter<OrderLine, OrderLineDto>
    {
        public override OrderLineDto Convert(OrderLine item)
        {
            var dto = new OrderLineDto()
            {
                Id = item.Id,
                Amount = item.Amount
            };
            if (item.Movie != null)
            {
                dto.MovieId = item.Movie.Id;
            }
            if (item.Order != null)
            {
                dto.OrderId = item.Order.Id;
            }
            return dto;
        }

        public OrderLine Convert(OrderLineDto orderLineDto)
        {
            throw new NotImplementedException();
        }
    }
}