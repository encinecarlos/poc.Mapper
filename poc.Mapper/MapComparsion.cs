using AutoMapper;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using poc.Mapper.Dtos;
using poc.Mapper.Entities;
using poc.Mapper.Mappings;
using poc.Mapper.Profiles;

namespace poc.Mapper;

[Orderer(SummaryOrderPolicy.Method, MethodOrderPolicy.Declared)]
public class MapComparsion
{
    private Customer[] _customers;
    private IMapper _mapper;
    private CustomerMapping _customerMapping;

    [Params(10, 100, 1000)] public int iteration;

    [GlobalSetup]
    public void Init()
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<CustomerProfile>();
        });

        _mapper = config.CreateMapper();

        _customers = new Customer[iteration];
        for (int i = 0; i < iteration; i++)
        {
            _customers[i] = new Customer
            {
                Id = Guid.NewGuid(),
                Name = $"Customer {i}",
                Email = $"test[i]@test,net"
            };
        }
        
        _customerMapping = new CustomerMapping();
    }
    
    [Benchmark]
    public void WithAutomapper()
    {
        for (int i = 0; i < iteration; i++)
        {
            _mapper.Map<CustomerDto>(_customers[i]);
        }
    }
    
    [Benchmark]
    public void WithDirectMapping()
    {
        for (int i = 0; i < iteration; i++)
        {
            Entities.Customer.ToCustomerDto(_customers[i]);
        }
    }
    
    [Benchmark]
    public void WithImplicitOperator()
    {
        for (int i = 0; i < iteration; i++)
        {
            CustomerDto dto = _customers[i];
        }
    }
    
    [Benchmark]
    public void WithMapperly()
    {
        for (int i = 0; i < iteration; i++)
        {
            _customerMapping.MapToCustomerDtoDto(_customers[i]);
        }
    }
}