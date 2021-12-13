using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NewsWeb.Models;
using NewsWeb.Services;
using NewsWeb.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NewsWeb.ViewModel;

namespace NewsWeb.Controllers
{
    public class NewsController : Controller
    {

        private INewsService newsService;
        private ICoinService coinService;

        ViewModels viewModels = new ViewModels();
        public NewsController(INewsService newsService,ICoinService coinService)
        {
            this.newsService = newsService;
            this.coinService=coinService;
        }

        public async Task<IActionResult> Index(int id = 0, int page = 1)
        {
            DrinkResult newsResult = null;
            CoinResult coinResult = null;
            if (id == 0)
            {
                newsResult = await newsService.GetNewsAsync(page);
                coinResult = await coinService.GetCoinsAsync(page);
            }
            else
            {
                newsResult = await newsService.GetNewsAsync(id, page);
            }
            var resultCategories = await newsService.GetCategoriesAsync();
            var newsViewModel = new NewsIndexViewModel
            {
                News = newsResult.News,
                Categories = resultCategories,
                CurrentPage = page,
                TotalPages = (int)newsResult.TotalPages,
                CategoryId = id
            };
            var coinViewModel = new CoinViewModel
            {
                Coins = coinResult.Coins,
                CurrentPage = page,
                TotalPages = (int)newsResult.TotalPages,
                
            };
            viewModels.NewsIndexViewModel = newsViewModel;
            viewModels.CoinViewModel = coinViewModel;
            return View(viewModels);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var list = await newsService.GetCategoriesAsync();
            ViewBag.Categories = new SelectList(list, "Id", "Name");
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> AddCoin()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(Drink news, IFormFile ImageFile)
        {
            if (ModelState.IsValid)
            {
                if (ImageFile != null)
                {
                    var filepath = await FileUploadHelper.UploadAsync(ImageFile);
                    news.PosterUrl = filepath;
                }
                news.Date = DateTime.Now;
                await newsService.AddNewsAsync(news);
                return RedirectToAction("Index");
            }
            else
            {
                var list = await newsService.GetCategoriesAsync();
                ViewBag.Categories = new SelectList(list, "Id", "Name");
                return View(news);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddCoin(Coins coin, IFormFile ImageFile,bool IsValue)
        {
                if (ImageFile != null)
                {
                    var filepath = await FileUploadHelper.UploadAsync(ImageFile);
                    coin.ImageUrl = filepath;
                }

                coin.IsValue = IsValue;
                await coinService.AddCoinAsync(coin);
                return RedirectToAction("Index");
            
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int Id)
        {
            await newsService.DeleteNewsAsync(Id);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> DeleteCoin(int Id)
        {
            await coinService.DeleteCoinAsync(Id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int Id)
        {
            var news = await newsService.FindNewsByIdAsync(Id);
            var list = await newsService.GetCategoriesAsync();
            ViewBag.Categories = new SelectList(list, "Id", "Name", news.CategoryId);
            return View(news);
        }
        [HttpGet]
        public async Task<IActionResult> EditCoin(int Id)
        {
            var news = await coinService.FindCoinByIdAsync(Id);

            return View(news);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Drink news, IFormFile ImageFile)
        {
            if (ModelState.IsValid)
            {
                if (ImageFile != null)
                {
                    var filepath = await FileUploadHelper.UploadAsync(ImageFile);
                    news.PosterUrl = filepath;
                }
                news.Date = DateTime.Now;
                await newsService.EditNewsAsync(news);
                return RedirectToAction("Index");
            }
            else
            {
                var list = await newsService.GetCategoriesAsync();
                ViewBag.Categories = new SelectList(list, "Id", "Name");
                return View(news);
            }
        }
        
        
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditCoin(Coins coin, IFormFile ImageFile,bool IsValue)
        {
                if (ImageFile != null)
                {
                    var filepath = await FileUploadHelper.UploadAsync(ImageFile);
                    coin.ImageUrl = filepath;
                }
                coin.IsValue = IsValue;
                await coinService.EditCoinAsync(coin);

                return RedirectToAction("Index");
        }
    }
}
