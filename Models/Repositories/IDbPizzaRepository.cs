﻿namespace la_mia_pizzeria_static.Models.Repositories
{
    //interfaccia per le repositories db e list
    public interface IDbPizzaRepository
    {
        List<Pizza> All();
        List<Message> AllMessages();
        void Create(Pizza pizza, List<int> selectedIngredients);
        void Delete(Pizza pizza);
        Pizza GetById(int id);
        List<Pizza> SearchByName(string? name);
        void Update(Pizza pizza, Pizza formData, List<int>? selectedIngredients);
    }
}