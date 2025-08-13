using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using OrderManagementAPI.Data;
using OrderManagementAPI.Models;

[ApiController]
[Route("api/[controller]")]
public class OrderDetailsController : ControllerBase
{
    private readonly OrderManagementContext _context;

    public OrderDetailsController(OrderManagementContext context)
    {
        _context = context;
    }

    // GET: api/OrderDetails
    [HttpGet]
    public async Task<ActionResult<IEnumerable<OrderDetail>>> GetOrderDetails()
    {
        return await _context.OrderDetails
            .Include(od => od.Order)
            .Include(od => od.Product)
            .ToListAsync();
    }

    // GET: api/OrderDetails/5
    [HttpGet("{id}")]
    public async Task<ActionResult<OrderDetail>> GetOrderDetail(int id)
    {
        var orderDetail = await _context.OrderDetails
            .Include(od => od.Order)
            .Include(od => od.Product)
            .FirstOrDefaultAsync(od => od.OrderId == id);

        if (orderDetail == null)
        {
            return NotFound();
        }

        return orderDetail;
    }

    // GET: api/OrderDetails/order/5
    [HttpGet("order/{orderId}")]
    public async Task<ActionResult<IEnumerable<OrderDetail>>> GetOrderDetailsByOrder(int orderId)
    {
        return await _context.OrderDetails
            .Include(od => od.Product)
            .Where(od => od.OrderId == orderId)
            .ToListAsync();
    }

    // POST: api/OrderDetails
    [HttpPost]
    public async Task<ActionResult<OrderDetail>> PostOrderDetail(OrderDetail orderDetail)
    {
        _context.OrderDetails.Add(orderDetail);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetOrderDetail), new { id = orderDetail.OrderId }, orderDetail);
    }

    // PUT: api/OrderDetails/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutOrderDetail(int id, OrderDetail orderDetail)
    {
        if (id != orderDetail.OrderId)
        {
            return BadRequest();
        }

        _context.Entry(orderDetail).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!OrderDetailExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    // DELETE: api/OrderDetails/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteOrderDetail(int id)
    {
        var orderDetail = await _context.OrderDetails.FindAsync(id);
        if (orderDetail == null)
        {
            return NotFound();
        }

        _context.OrderDetails.Remove(orderDetail);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool OrderDetailExists(int id)
    {
        return _context.OrderDetails.Any(e => e.OrderId == id);
    }
}