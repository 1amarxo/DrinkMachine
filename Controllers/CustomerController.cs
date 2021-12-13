using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NewsWeb.Helpers;
using NewsWeb.Models;
using NewsWeb.Services;
using NewsWeb.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsWeb.Controllers
{
    public class CustomerController : Controller
    {
        private INewsService newsService;
        private ICoinService coinService;

        ViewModels viewModels = new ViewModels();
        public CustomerController(INewsService newsService, ICoinService coinService)
        {
            this.newsService = newsService;
            this.coinService = coinService;
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
        public async Task<IActionResult> Edit(int Id ,int Quantity,string PosterUrl,int CategoryId,string Content,DateTime Date,int Price,string Title)
        {
            Drink drink = new Drink {
                Id = Id,
                Quantity= Quantity, 
                PosterUrl= PosterUrl,
                CategoryId= CategoryId, 
                Content= Content,
                Date= Date,
                Price= Price,
                Title= Title
            };


            await newsService.EditNewsAsync(drink);

            return null;
           
            
        }

        [HttpGet]
        public async Task<IActionResult> EditCoin(int Id,int Value,int Quantity, string ImageUrl)
        {
            Coins coin = new Coins {Id= Id,Value= Value, Quantity = Quantity, ImageUrl = ImageUrl };
          
             await coinService.EditCoinAsync(coin);

            return null;
        }

    }
}
