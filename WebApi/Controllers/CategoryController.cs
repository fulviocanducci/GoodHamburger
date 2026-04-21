using Application.DTOs.Category;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using Swashbuckle.AspNetCore.Annotations;
namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
[Produces(MediaTypeNames.Application.Json)]
public class CategoryController(ICategoryService categoryService) : ControllerBase
{
    private readonly ICategoryService categoryService = categoryService;

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<CategoryView>), StatusCodes.Status200OK, Description = "Retorna Lista de Categorias")]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [SwaggerOperation(Summary = "Categorias - Lista de Categorias", Description = "Retorna Lista de Categorias")]
    public async Task<IActionResult> Get()
    {
        try
        {
            var result = await categoryService.GetAsync();
            return Ok(result);
        }
        catch (Exception)
        {
            throw;
        }
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(CategoryView), StatusCodes.Status200OK, Description = "Retorna os detalhes de uma categoria específica")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [SwaggerOperation(Summary = "Categorias - Detalhes da Categoria", Description = "Retorna os detalhes de uma categoria específica")]
    public async Task<IActionResult> Get(int id)
    {
        try
        {
            var result = await categoryService.GetAsync(id);
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
    [ProducesResponseType(typeof(CategoryView), StatusCodes.Status201Created, Description = "Retorna a categoria criada")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [SwaggerOperation(Summary = "Categorias - Criar Categoria", Description = "Cria uma nova categoria")]
    public async Task<IActionResult> Create([FromBody] CategoryCreate model)
    {
        try
        {
            if (model == null)
            {
                return BadRequest();
            }
            var view = await categoryService.CreateAsync(model);
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
    [ProducesResponseType(typeof(bool), StatusCodes.Status200OK, Description = "Atualiza uma categoria existente")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [SwaggerOperation(Summary = "Categorias - Atualizar Categoria", Description = "Atualiza uma categoria existente")]
    public async Task<IActionResult> Update(int id, [FromBody] CategoryUpdate model)
    {
        try
        {
            if (id == 0 || model == null || model.Id != id)
            {
                return BadRequest();
            }
            var result = await categoryService.UpdateAsync(model);
            return Ok(result);
        }
        catch (Exception)
        {
            throw;
        }

    }

    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(bool), StatusCodes.Status200OK, Description = "Exclui uma categoria existente")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound, Description = "Categoria não encontrada")]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Description = "Erro interno do servidor")]
    [SwaggerOperation(Summary = "Categorias - Excluir Categoria", Description = "Exclui uma categoria existente")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            if (id == 0)
            {
                return BadRequest();
            }
            if (!categoryService.IsIdExist(id))
            {
                return NotFound();
            }
            var result = await categoryService.DeleteAsync(id);
            return Ok(result);
        }
        catch (Exception)
        {
            throw;
        }
    }
}