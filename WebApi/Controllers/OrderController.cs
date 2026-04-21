using Application.DTOs.Order;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
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
        [ProducesResponseType(typeof(IEnumerable<OrderView>), StatusCodes.Status200OK, Description = "Retorna Lista de Pedidos")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Description = "Erro interno do servidor")]
        [SwaggerOperation(Summary = "Pedidos - Lista de Pedidos", Description = "Retorna Lista de Pedidos")]
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
        [ProducesResponseType(typeof(OrderView), StatusCodes.Status200OK, Description = "Retorna os detalhes de um pedido específico")]
        [ProducesResponseType(StatusCodes.Status404NotFound, Description = "Pedido não encontrado")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Description = "Erro interno do servidor")]
        [SwaggerOperation(Summary = "Pedidos - Detalhes do Pedido", Description = "Retorna os detalhes de um pedido específico")]
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
        [ProducesResponseType(typeof(OrderView), StatusCodes.Status201Created, Description = "Retorna o pedido criado")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Description = "Requisição inválida")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Description = "Erro interno do servidor")]
        [SwaggerOperation(Summary = "Pedidos - Criar Pedido", Description = "Cria um novo pedido")]
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
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK, Description = "Exclui um pedido existente")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Description = "Requisição inválida")]
        [ProducesResponseType(StatusCodes.Status404NotFound, Description = "Pedido não encontrado")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Description = "Erro interno do servidor")]
        [SwaggerOperation(Summary = "Pedidos - Excluir Pedido", Description = "Exclui um pedido existente")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest();
                }
                if (!orderService.IsIdExist(id))
                {
                    return NotFound();
                }
                var result = await orderService.DeleteAsync(id);
                return Ok(result);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
