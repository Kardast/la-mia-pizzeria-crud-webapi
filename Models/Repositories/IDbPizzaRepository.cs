namespace la_mia_pizzeria_static.Models.Repositories
{
    public interface IDbPizzaRepository
    {
        List<Pizza> All();
        void Create(Pizza pizza, List<int> selectedIngredients);
        void Delete(Pizza pizza);
        Pizza GetById(int id);
        List<Pizza> SearchByName(string? name);
        void Update(Pizza pizza, Pizza formData, List<int>? selectedIngredients);
    }
}