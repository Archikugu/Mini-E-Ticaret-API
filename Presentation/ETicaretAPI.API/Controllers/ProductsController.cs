using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        readonly private IProductWriteRepository _productWriteRepository;
        readonly private IProductReadRepository _productReadRepository;

        readonly private IOrderWriteRepository _orderWriteRepository;
        readonly private IOrderReadRepository _orderReadRepository;

        readonly private ICustomerWriteRepository _customerWriteRepository;

        public ProductsController(IProductReadRepository productReadRepository, IProductWriteRepository productWriteRepository, IOrderWriteRepository orderWriteRepository, ICustomerWriteRepository customerWriteRepository, IOrderReadRepository orderReadRepository)
        {
            _productReadRepository = productReadRepository;
            _productWriteRepository = productWriteRepository;
            _orderWriteRepository = orderWriteRepository;
            _customerWriteRepository = customerWriteRepository;
            _orderReadRepository = orderReadRepository;
        }
        [HttpGet]
        public async Task Get()
        {
            //var customerId=Guid.NewGuid();
            //await _customerWriteRepository.AddAsync(new() { Id = customerId, Name = "Muiidddin" });

            //await _orderWriteRepository.AddAsync(new() { Description = "Test Test Test", Adress = "Ankara ,Yenimahalle",CustomerId=customerId });
            //await _orderWriteRepository.AddAsync(new() { Description = "Test Test Test 2", Adress = "Ankara ,Çankaya",CustomerId=customerId });
            //_orderWriteRepository.SaveAsync();

            Order order = await _orderReadRepository.GetByIdAsync("55369b15-4c29-407d-8fd9-2972f46c9a5a");
            order.Adress = "İstanbul";
            await _orderWriteRepository.SaveAsync();
        }

    }
}
