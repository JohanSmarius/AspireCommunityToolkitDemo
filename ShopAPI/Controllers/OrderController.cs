using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopAPI.Model;
using System.Net.Mail;
using ShopAPI.DTO;

namespace ShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;
        private readonly SmtpClient _smtpClient;

        public OrderController(ILogger<OrderController> logger, SmtpClient smtpClient)
        {
            _logger = logger;
            _smtpClient = smtpClient;
        }

        [HttpGet]
        public IActionResult GetOrders()
        {
            // Mailing does not work well on this mac.
            // MailMessage mailMessage = new MailMessage();
            // mailMessage.From = new MailAddress("jsmarius@hotmail.com");
            // mailMessage.To.Add(new MailAddress("jsmarius@hotmail.com"));
            // mailMessage.Subject = "Test Email";
            // mailMessage.Body = "Orders retrieved";
            // _smtpClient.Send(mailMessage);


            // Logic to get orders
            return Ok(new { Message = "Orders retrieved successfully." });
        }

        [HttpPost]
        public IActionResult CreateOrder([FromBody] OrderDTO order)
        {
            // Logic to create an order
            return CreatedAtAction(nameof(GetOrders), new { Message = $"Order for {order.CustomerId} created successfully." });
        }
    }
}
