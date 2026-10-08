using Microsoft.AspNetCore.Mvc;
using MVC04.Models;
using MVC04.Repositories;
using MVC04.Data;

namespace MVC04.Controllers;

public class ProductsController : Controller
{
    private readonly IProductRepository _productRepository;
    private readonly ProductModel _productModel;

    public ProductsController(IProductRepository productRepository, ProductModel productModel)
    {
        _productRepository = productRepository;
        _productModel = productModel;
    }

    [HttpGet]
    public IActionResult NewProduct()
    {
        return View(new Product());
    }

    [HttpGet]
    public async Task<IActionResult> ProductMgr()
    {
        var products = await _productRepository.GetAllAsync();

        return View(products);
    }

    [HttpGet]
    public async Task<IActionResult> ProductList()
    {
        var products = await _productModel.GetProducts();

        return View(products);
    }

    [HttpGet]
    public async Task<IActionResult> ProductDetail(int id)
    {
        var product = await _productModel.GetProduct(id);

        if (product is null)
        {
            return NotFound();
        }

        return View(product);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> NewProduct(Product product)
    {
        if (await _productRepository.ProductIdExistsAsync(product.ProductID))
        {
            ModelState.AddModelError(nameof(Product.ProductID), "Mã mặt hàng đã tồn tại");
        }

        if (!ModelState.IsValid)
        {
            return View(product);
        }

        await _productRepository.AddAsync(product);
        TempData["SuccessMessage"] = "Thêm mặt hàng thành công";

        return RedirectToAction(nameof(NewProduct));
    }

    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        await _productRepository.DeleteAsync(id);

        return RedirectToAction(nameof(ProductMgr));
    }

    [HttpPost]
    public async Task<IActionResult> DeleteAjax(int id)
    {
        await _productRepository.DeleteAsync(id);
        return Json(new { success = true });
    }

    [HttpPost]
    public async Task<IActionResult> Giamgia(int id, [FromServices] ProductDbContext context)
    {
        var product = await context.Products.FindAsync(id);
        if (product == null) return NotFound();
        if (product.ProductPrice >= 100000)
        {
            product.ProductPrice *= 0.9m; // Giảm 10%
            await context.SaveChangesAsync();
            return Json(new { success = true, newPrice = product.ProductPrice });
        }
        return Json(new { success = false, message = "Giá dưới 100.000, không thể giảm" });
    }

}
