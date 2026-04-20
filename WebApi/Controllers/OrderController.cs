using Application.DTOs.Order;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    public class OrderController(IOrderService orderService) : ControllerBase
    {
        private readonly IOrderService orderService = orderService;

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<OrderView>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await orderService.GetAsync();
                return Ok(result);
            }
            catch (Exception)
            {
                throw;
            }

        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(IEnumerable<OrderView>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var result = await orderService.GetAsync(id);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);

            }
            catch (Exception)
            {

                throw;
            }

        }

        [HttpPost]
        [ProducesResponseType(typeof(IEnumerable<OrderView>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create([FromBody] OrderCreate model)
        {
            try
            {
                if (model == null)
                {
                    return BadRequest();
                }
                var view = await orderService.CreateAsync(model);
                if (view == null)
                {
                    return BadRequest();
                }
                return CreatedAtAction(nameof(Get), new { id = view.Id }, view);
            }
            catch (Exception)
            {
                throw;
            }

        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest();
                }
                bool result = await orderService.DeleteAsync(id);
                return result ? Ok(new { result }) : NotFound();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
