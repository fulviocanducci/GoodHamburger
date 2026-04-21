using Application.DTOs.Category;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
[Produces(MediaTypeNames.Application.Json)]
public class CategoryController(ICategoryService categoryService) : ControllerBase
{
    private readonly ICategoryService categoryService = categoryService;

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<CategoryView>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
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
    [ProducesResponseType(typeof(CategoryView), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
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
    [ProducesResponseType(typeof(CategoryView), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
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
    [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
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