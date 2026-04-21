using Application.DTOs.Menu;
using Application.Interfaces;
using Application.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net.Mime;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    public class MenuController(IMenuService menuService) : ControllerBase
    {
        private readonly IMenuService menuService = menuService;

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<MenuView>), StatusCodes.Status200OK, Description = "Retorna Lista de Menus")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [SwaggerOperation(Summary = "Menus - Lista de Menus", Description = "Retorna Lista de Menus")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await menuService.GetAsync();
                return Ok(result);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(MenuView), StatusCodes.Status200OK, Description = "Retorna os detalhes de um menu específico")]
        [ProducesResponseType(StatusCodes.Status404NotFound, Description = "Menu não encontrado")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Description = "Erro interno do servidor")]
        [SwaggerOperation(Summary = "Menus - Detalhes do Menu", Description = "Retorna os detalhes de um menu específico")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var result = await menuService.GetAsync(id);
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

        [HttpGet("filter")]
        [ProducesResponseType(typeof(IEnumerable<MenuView>), StatusCodes.Status200OK, Description = "Retorna Lista de Menus filtrados")]
        [ProducesResponseType(StatusCodes.Status404NotFound, Description = "Menus não encontrados")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Description = "Erro interno do servidor")]
        [SwaggerOperation(Summary = "Menus - Filtrar Menus", Description = "Retorna Lista de Menus filtrados por nome")]
        public async Task<IActionResult> Get([FromQuery] string name)
        {
            try
            {
                var result = await menuService.GetAsync(name);                
                return Ok(result);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(MenuView), StatusCodes.Status201Created, Description = "Retorna o menu criado")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Description = "Requisição inválida")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Description = "Erro interno do servidor")]
        [SwaggerOperation(Summary = "Menus - Criar Menu", Description = "Cria um novo menu")]
        public async Task<IActionResult> Create([FromBody] MenuCreate model)
        {
            try
            {
                if (model == null)
                {
                    return BadRequest();
                }
                var view = await menuService.CreateAsync(model);
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

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK, Description = "Atualiza um menu existente")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Description = "Requisição inválida")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Description = "Erro interno do servidor")]
        [SwaggerOperation(Summary = "Menus - Atualizar Menu", Description = "Atualiza um menu existente")]
        public async Task<IActionResult> Update(int id, [FromBody] MenuUpdate model)
        {
            try
            {
                if (id == 0 || model == null || model.Id != id)
                {
                    return BadRequest();
                }
                var result = await menuService.UpdateAsync(model);
                return Ok(result);
            }
            catch (Exception)
            {
                throw;
            }

        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK, Description = "Exclui um menu existente")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Description = "Requisição inválida")]
        [ProducesResponseType(StatusCodes.Status404NotFound, Description = "Menu não encontrado")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Description = "Erro interno do servidor")]
        [SwaggerOperation(Summary = "Menus - Excluir Menu", Description = "Exclui um menu existente")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest();
                }
                if (!menuService.IsIdExist(id))
                {
                    return NotFound();
                }
                var result = await menuService.DeleteAsync(id);
                return Ok(result);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
