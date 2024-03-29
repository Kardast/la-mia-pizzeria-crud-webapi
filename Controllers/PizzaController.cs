﻿using Azure;
using la_mia_pizzeria_static.Data;
using la_mia_pizzeria_static.Models;
using la_mia_pizzeria_static.Models.Form;
using la_mia_pizzeria_static.Models.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.SqlServer.Server;
using System.Diagnostics;

namespace la_mia_pizzeria_static.Controllers
{
    [Authorize]
    [Route("[controller]/[action]/{id?}",Order = 0 )]
    public class PizzaController : Controller
    {
        PizzeriaDbContext db;

        IDbPizzaRepository pizzaRepository;

        public PizzaController(IDbPizzaRepository _pizzaRepository, PizzeriaDbContext _db) : base()
        {
            db = _db;

            pizzaRepository = _pizzaRepository;
        }

        //index
        public IActionResult Index()
        {
            List<Pizza> listPizza = pizzaRepository.All();

            return View(listPizza);
        }

        //messages
        public IActionResult Messages()
        {
            List<Message> listMessage = pizzaRepository.AllMessages();

            return View(listMessage);
        }

        //details
        public IActionResult Details(int id)
        {

            Pizza pizza = pizzaRepository.GetById(id);

            if(pizza == null)
            {
                return NotFound();
            }

            return View(pizza);
        }

        //create page
        public IActionResult Create()
        {
            PizzaForm formData = new PizzaForm();
            formData.Pizza = new Pizza();
            formData.Categories = db.Categories.ToList();
            formData.Ingredients = new List<SelectListItem>();

            //creazione lista ingredienti dal db per passarli al create
            List<Ingredient> ingredientList = db.Ingredients.ToList();

            foreach (Ingredient ingredient in ingredientList)
            {
                formData.Ingredients.Add(new SelectListItem(ingredient.Name, ingredient.Id.ToString()));
            }

            return View(formData);
        }

        //create save
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PizzaForm formData)
        {
            //ricreazione della pagina se il modelstate non è valido
            if (!ModelState.IsValid)
            {
                formData.Categories = db.Categories.ToList();
                formData.Ingredients = new List<SelectListItem>();

                List<Ingredient> ingredientList = db.Ingredients.ToList();

                foreach (Ingredient ingredient in ingredientList)
                {
                    formData.Ingredients.Add(new SelectListItem(ingredient.Name, ingredient.Id.ToString()));
                }

                return View(formData);
            }

            pizzaRepository.Create(formData.Pizza, formData.SelectedIngredients);

            return RedirectToAction("Index");
        }

        //update page
        public IActionResult Update(int id)
        {
            Pizza pizza = pizzaRepository.GetById(id);

            if (pizza == null)
                return NotFound();

            PizzaForm formData = new PizzaForm();

            formData.Pizza = pizza;
            formData.Categories = db.Categories.ToList();
            formData.Ingredients = new List<SelectListItem>();

            List<Ingredient> ingredientsList = db.Ingredients.ToList();

            foreach(Ingredient ingredient in ingredientsList) 
            {
                formData.Ingredients.Add(new SelectListItem(
                    ingredient.Name,
                    ingredient.Id.ToString(),
                    pizza.Ingredients.Any(i => i.Id == ingredient.Id)
                    ));
            }

            return View(formData);
        }

        //update save
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int id, PizzaForm formData)
        {

            //ritorna la view in caso di invalid modelstate
            if (!ModelState.IsValid)
            {
                formData.Pizza.Id = id;
                //return View(postItem);
                formData.Categories = db.Categories.ToList();
                formData.Ingredients = new List<SelectListItem>();

                List<Ingredient> ingredientList = db.Ingredients.ToList();

                foreach (Ingredient ingredient in ingredientList)
                {
                    formData.Ingredients.Add(new SelectListItem(ingredient.Name, ingredient.Id.ToString()));
                }

                return View(formData);
            }


            //Metodo esplicito

            Pizza pizzaItem = pizzaRepository.GetById(id);

            if (pizzaItem == null)
            {
                return NotFound();
            }

            pizzaRepository.Update(pizzaItem, formData.Pizza, formData.SelectedIngredients);

            return RedirectToAction("Index");
        }

        //delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            Pizza pizza = pizzaRepository.GetById(id);
            if (pizza == null)
            {
                return NotFound();
            }

            pizzaRepository.Delete(pizza);

            return RedirectToAction("Index");
        }
    }
}
