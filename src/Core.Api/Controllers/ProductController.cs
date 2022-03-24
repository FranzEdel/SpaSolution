using Microsoft.AspNetCore.Mvc;
using Model.DTOs;
using Service;

namespace Core.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ProductDto>> GetById(int id)
    {
        return await _productService.GetById(id);
    }

    [HttpPost]
    public async Task<ActionResult> Create(ProductCreateDto model)
    {
        var result = await _productService.Create(model);

        return CreatedAtAction(
            "GetById",
            new { id = result.ProductID },
            result
        );
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id, ProductUpdateDto model)
    {
        await _productService.Update(id, model);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Remove(int id)
    {
        await _productService.Remove(id);

        return NoContent();
    }

}
