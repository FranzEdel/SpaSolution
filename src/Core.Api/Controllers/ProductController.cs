using Core.Api.Commons;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Model.DTOs;
using Service;
using Service.Commons;

namespace Core.Api.Controllers;

[Authorize(Roles = RoleHelper.Admin)]
[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public async Task<ActionResult<DataCollection<ProductDto>>> GetById(int page, int take = 3)
    {
        return await _productService.GetAll(page, take);
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
