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
            var categories = await categoryService.GetAllAsync();
            return Ok(categories);
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
            var category = await categoryService.GetAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
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
            bool status = await categoryService.UpdateAsync(model);
            return Ok(new { status });
        }
        catch (Exception)
        {
            throw;
        }
        
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            if (id == 0)
            {
                return BadRequest();
            }
            bool status = await categoryService.DeleteAsync(id);
            return status ? Ok(new { status }) : NotFound();
        }
        catch (Exception)
        {
            throw;
        }        
    }
}