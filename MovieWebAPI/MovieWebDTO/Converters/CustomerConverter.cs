using System;
using MovieWebDAL.Model;
using MovieWebDTO.DTOs;

namespace MovieWebDTO
{
    public class CustomerConverter : AbstractDtoConverter<Customer, CustomerDto>
    {
        public override CustomerDto Convert(Customer item)
        {
            var dto = new CustomerDto()
            {
                Id = item.Id,
                FirstName = item.FirstName,
                LastName = item.LastName,
                Address = item.Address,
                Email = item.Email
            };
            //if (item.Orders != null)
            //{
            //    dto.Orders = new OrderConverter().Convert(item.Orders);
            //}
            return dto;
        }

        public Customer Convert(CustomerDto customerDto)
        {
            throw new NotImplementedException();
        }
    }
}