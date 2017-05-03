using OnlineShoppingStore.Abstract;
using OnlineShoppingStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace OnlineShoppingStore.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product

        private readonly IProductRepository repository;
        public int PageSize=100;
        public ProductController(IProductRepository repo)
        {
            repository = repo;
        }

        //public int page(string viewItems)
        //{
        //    ////items per page
        //    //if (!String.IsNullOrEmpty(viewItems))
        //    //{
        //        PageSize = int.Parse(viewItems);


        //    return PageSize;
        //}

        public ViewResult List(string category, string priceOrder, string searchString, string viewItems, int page = 1)
        {

            if (!String.IsNullOrEmpty(viewItems))
            {
                PageSize = int.Parse(viewItems);
            }



            ProductListViewModel model = new ProductListViewModel
            {
                Products = repository.Products
                        .Where(p => category == null || p.Category == category)
                        .Where(s => searchString == null || s.Name.ToLower().Contains(searchString.ToLower()) || s.Description.ToLower().Contains(searchString.ToLower()))
                        .OrderBy(p => priceOrder == "LowToHigh" ? p.Price : p.ProductId)
                        .Skip((page - 1) * (PageSize)) //ie. if page=1 skip zero products (i.e. start from begining), if page=2 skip first 4 items 
                        .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = category == null ?
                                 repository.Products.Count() : //if no category selected
                                 repository.Products.Where(p => p.Category == category).Count()
                },
                CurrentCategory = category,
                CurrentSearchString = searchString,
                CurrentPriceOrder = priceOrder
            };
            if (priceOrder == "HighToLow")
                model = new ProductListViewModel
                {
                    Products = repository.Products
                        .OrderByDescending(p => p.Price)
                        .Skip((page - 1) * PageSize) //ie. if page=1 skip zero products (i.e. start from begining), if page=2 skip first 4 items 
                        .Take(PageSize),
                    PagingInfo = new PagingInfo
                    {
                        CurrentPage = page,
                        ItemsPerPage = PageSize,
                        TotalItems = category == null ?
                                 repository.Products.Count() : //if no category selected
                                 repository.Products.Where(p => p.Category == category).Count()
                    },
                    CurrentCategory = category,
                    CurrentPriceOrder = priceOrder
                };
            return View(model);
        }



            ////title search
            //if (!String.IsNullOrEmpty(searchString))
            //{
            //    model = new ProductListViewModel
            //    {
            //        Products = repository.Products
            //            .Where(s => s.Name.Contains(searchString) || s.Description.Contains(searchString))
            //            .OrderBy(p => p.ProductId)
            //            .Skip((page - 1) * PageSize) //ie. if page=1 skip zero products (i.e. start from begining), if page=2 skip first 4 items 
            //            .Take(PageSize),
            //        PagingInfo = new PagingInfo
            //        {
            //            CurrentPage = page,
            //            ItemsPerPage = PageSize,
            //            TotalItems = category == null ?
            //                     repository.Products.Count() : //if no category selected
            //                     repository.Products.Where(p => p.Category == category).Count()
            //        },
            //        CurrentCategory = category
            //    };

            //}

            //if (!String.IsNullOrEmpty(priceOrder))
            //{

            //if(priceOrder=="LowToHigh")
            //model = new ProductListViewModel
            //{
            //    Products = repository.Products
            //        .OrderBy(p => p.Price)
            //        .Skip((page - 1) * PageSize) //ie. if page=1 skip zero products (i.e. start from begining), if page=2 skip first 4 items 
            //        .Take(PageSize),
            //    PagingInfo = new PagingInfo
            //    {
            //        CurrentPage = page,
            //        ItemsPerPage = PageSize,
            //        TotalItems = category == null ?
            //                 repository.Products.Count() : //if no category selected
            //                 repository.Products.Where(p => p.Category == category).Count()
            //    },
            //    CurrentCategory = category,
            //    CurrentPriceOrder=priceOrder
            //};
            //else
            //{
            //        model = new ProductListViewModel
            //        {
            //            Products = repository.Products
            //                .OrderByDescending(p => p.Price)
            //                .Skip((page - 1) * PageSize) //ie. if page=1 skip zero products (i.e. start from begining), if page=2 skip first 4 items 
            //                .Take(PageSize),
            //            PagingInfo = new PagingInfo
            //            {
            //                CurrentPage = page,
            //                ItemsPerPage = PageSize,
            //                TotalItems = category == null ?
            //                         repository.Products.Count() : //if no category selected
            //                         repository.Products.Where(p => p.Category == category).Count()
            //            },
            //            CurrentCategory = category
            //    };


            //}

        //}




           

        //}

    
        public ActionResult Details(int? id)
        {
            if (id == null)     //if don't have id to search details i.e. not in URL- takes user to error pages
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = repository.Products.FirstOrDefault(p => p.ProductId == id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

    }
}