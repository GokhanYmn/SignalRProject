﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.CategoryDtos;
using SignalRWebUI.Dtos.ProductDtos;
using System.Text;

namespace SignalRWebUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7290/api/Product");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
        {
            createProductDto.Status = true;
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createProductDto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7290/api/Product", content);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task< IActionResult> CreateProduct()
        {
            var client= _httpClientFactory.CreateClient();
            var responseMessage=await client.GetAsync("https://localhost:7290/api/Category");
            var jsonData=await responseMessage.Content.ReadAsStringAsync();
            var values=JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
            List<SelectListItem> value=(from x in values
                                        select new SelectListItem
                                        {
                                            Text=x.CategoryName,
                                            Value=x.CategoryId.ToString()
                                        }).ToList();
            ViewBag.v=value;
            return View();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7290/api/Product/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
public async Task<IActionResult> UpdateProduct(int id)
{
    // Kategorileri çek
    var categoryResponse = await _httpClientFactory.CreateClient().GetAsync("https://localhost:7290/api/Category");
    var categoryData = await categoryResponse.Content.ReadAsStringAsync();
    var categoryList = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(categoryData);

            ViewBag.CategoryId = categoryList.Select(x => new SelectListItem
            {
                Text = x.CategoryName,
                Value = x.CategoryId.ToString()
            }).ToList();

            // Ürün verisini çek
            var productResponse = await _httpClientFactory.CreateClient().GetAsync($"https://localhost:7290/api/Product/{id}");
    if (productResponse.IsSuccessStatusCode)
    {
        var jsonData = await productResponse.Content.ReadAsStringAsync();
        var values = JsonConvert.DeserializeObject<UpdateProductDto>(jsonData);
        return View(values);
    }

    return View();
}

      

        [HttpPost]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto dto)
        {
            var client = _httpClientFactory.CreateClient();

            // Kategori listesini yeniden al:
            var categoryResponse = await client.GetAsync("https://localhost:7290/api/Category");
            if (categoryResponse.IsSuccessStatusCode)
            {
                var categoryData = await categoryResponse.Content.ReadAsStringAsync();
                var categoryValues = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(categoryData);

                ViewBag.v = categoryValues
                    .Select(x => new SelectListItem
                    {
                        Text = x.CategoryName,
                        Value = x.CategoryId.ToString()
                    }).ToList();
            }

            // Ürün güncelleme işlemi:
            var jsonData = JsonConvert.SerializeObject(dto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7290/api/Product", content);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            // Hatalıysa form yeniden gösterilir:
            return View("~/Views/Admin/Product/UpdateProduct.cshtml", dto);
        }
    }
}
