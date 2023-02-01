using AutoMapper;
using DataLayer;
using DTO;
using Microsoft.AspNetCore.Mvc;
using Service;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;
        public OrderController(IOrderService orderService, IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }
     

        // POST api/<OrderController>
        [HttpPost]
        public  async Task<Order> Post([FromBody] OrderDTO orderDTO) 
        {
            Order order = _mapper.Map<OrderDTO, Order>(orderDTO);
              return await this._orderService.Post(order);
        }

      

       
    }
}
