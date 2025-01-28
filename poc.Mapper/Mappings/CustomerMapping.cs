using poc.Mapper.Dtos;
using poc.Mapper.Entities;
using Riok.Mapperly.Abstractions;

namespace poc.Mapper.Mappings;

[Mapper]
public partial class CustomerMapping
{
    public partial CustomerDto MapToCustomerDtoDto(Customer customer);
}