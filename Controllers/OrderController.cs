using Microsoft.AspNetCore.Mvc;
using RedOrderApi.Data;
using RedOrderApi.Services;
using Order = RedOrderApi.DTOS.Order;

namespace RedOrderApi.Controllers;


[ApiController]
[Route("[controller]")]
public class OrderController : ControllerBase
{
    private readonly OrderContext _orderContext;
    private readonly IOrderService _orderService;


    public OrderController (OrderContext orderContext, IOrderService orderService)
    {
        _orderContext = orderContext;
        _orderService = orderService;
    }

    [Route("createorder")]
    [HttpPost]
    public async Task<ActionResult<Order>> CreateOrder(Order order)
    { 
        var results = _orderService.CreateOrder(order);
        return Ok(results);
    }
    
    [Route("getorder")]
    [HttpGet]
    public ActionResult GetOrder(int take = 10, int skip = 0)
    {
        return Ok(_orderContext.Orders.OrderBy(p => p.OrderId).Skip(skip).Take(take));
    }
    
    [Route("updateorder")]
    [HttpPut]
    public ActionResult UpdateOrder(int take = 10, int skip = 0)
    {
        return Ok(_orderContext.Orders.OrderBy(p => p.OrderId).Skip(skip).Take(take));
    }
    
    [Route("searchbyordertype")]
    [HttpGet]
    public ActionResult GetOrdersByType(int take = 10, int skip = 0)
    {
        return Ok(_orderContext.Orders.OrderBy(p => p.OrderId).Skip(skip).Take(take));
    }
    
    [Route("deleteorder")]
    [HttpDelete]
    public ActionResult DeleteOrder(int take = 10, int skip = 0)
    {
        return Ok(_orderContext.Orders.OrderBy(p => p.OrderId).Skip(skip).Take(take));
    }
}
