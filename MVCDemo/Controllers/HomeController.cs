using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVCDemo.DataAccess.Repositories;
using MVCDemo.DataAccess.Models;

namespace MVCDemo.Controllers
{
    public class HomeController : Controller
    {
        private IAwesomeCarQueryHandler _awesomeCarQueryHandler;
        private IAwesomeCarRepository _awesomeCarRepository;

        public HomeController(IAwesomeCarQueryHandler awesomeCarQueryHandler, IAwesomeCarRepository awesomeCarRepository)
        {
            _awesomeCarQueryHandler = awesomeCarQueryHandler;            
            _awesomeCarRepository = awesomeCarRepository;            
        }
        public IActionResult Index()
        {
            var listOfCarModel = _awesomeCarQueryHandler.GetAwesomeCars();
            var viewModel = new HomeViewModel
            {
                Cars = listOfCarModel.ToList()
            };

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult CreateCar()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Detail(int Id)
        {
            var carModel = _awesomeCarQueryHandler.GetAwesomeCarById(Id);
            var detailCarViewModel = new DetailCarViewModel
            {
                CarName = carModel.CarName,
                Miliage = carModel.MileAge
            };
            return View(detailCarViewModel);
        }

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            var carModel = _awesomeCarQueryHandler.GetAwesomeCarById(Id);
            var editCarViewModel = new DetailCarViewModel
            {
                CarName = carModel.CarName,
                Miliage = carModel.MileAge,
                ProducerCountry = carModel.producerCountry
            };
            return View(editCarViewModel);
        }


        [HttpPost]
        public IActionResult Edit(int id, DetailCarViewModel vm)
        {
            var carModel = _awesomeCarRepository.GetCarById(id);
            carModel.CarName = vm.CarName;
            carModel.MileAge = vm.Miliage;
            carModel.producerCountry = vm.ProducerCountry;
            _awesomeCarRepository.Commit();
            return RedirectToAction("Detail", new { id = id });
        }


        [HttpPost]
        public IActionResult CreateCar(CarViewModel carViewModel)
        {
            var car = new AwesomeCar
            {
                CarName = carViewModel.CarName,
                BrandName = carViewModel.BrandName,
                MileAge = carViewModel.MileAge,
                producerCountry = carViewModel.producerCountry
            };
            _awesomeCarQueryHandler.Add(car);
            return RedirectToAction("Index");
        }

        public IActionResult Error()
        {
            return new ContentResult {
               Content = "Error"
            };
        }
    }
}
