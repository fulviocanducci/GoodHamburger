using Application.DTOs.Menu;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
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
        [ProducesResponseType(typeof(IEnumerable<MenuView>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
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
        [ProducesResponseType(typeof(MenuView), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
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

        [HttpPost]
        [ProducesResponseType(typeof(MenuView), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
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
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update(int id, [FromBody] MenuUpdate model)
        {
            try
            {
                if (id == 0 || model == null || model.Id != id)
                {
                    return BadRequest();
                }
                bool result = await menuService.UpdateAsync(model);
                return Ok(new { result });
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
                bool result = await menuService.DeleteAsync(id);
                return result ? Ok(new { result }) : NotFound();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
