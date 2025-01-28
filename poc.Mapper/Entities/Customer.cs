using poc.Mapper.Dtos;

namespace poc.Mapper.Entities;

public class Customer
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Type { get; set; }
    public string Phone { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    
    public static CustomerDto ToCustomerDto(Customer customer)
    {
        return new Dtos.CustomerDto(customer.Name, customer.Email, customer.Type, customer.Phone);
    }
    
    public static implicit operator CustomerDto(Customer customer)
    {
        return new Dtos.CustomerDto(customer.Name, customer.Email, customer.Type, customer.Phone);
    }
}