using System;
using System.Collections.Generic;

// Define a class for ingredients
public class Ingredient
{
    public string Name { get; set; }
    public int Calories { get; set; }
    public string FoodGroup { get; set; }
}

// Define a class for recipes
public class Recipe
{
    public string Name { get; set; }
    public List<Ingredient> Ingredients { get; set; }
    // Other properties and methods as needed
}

// Define a delegate for calorie notifications
public delegate void CalorieNotificationHandler(string recipeName, int totalCalories);

// Define a class for the application
public class RecipeApplication
{
    private List<Recipe> recipes = new List<Recipe>();
    public event CalorieNotificationHandler CalorieExceeded;

    // Method to add a recipe
    public void AddRecipe(Recipe recipe)
    {
        recipes.Add(recipe);
    }

    // Method to calculate total calories for a recipe
    public int CalculateTotalCalories(Recipe recipe)
    {
        int totalCalories = 0;
        foreach (var ingredient in recipe.Ingredients)
        {
            totalCalories += ingredient.Calories;
        }
        return totalCalories;
    }

    // Method to display recipes in alphabetical order
    public void DisplayRecipes()
    {
        recipes.Sort((x, y) => string.Compare(x.Name, y.Name));
        foreach (var recipe in recipes)
        {
            Console.WriteLine(recipe.Name);
        }
    }

    // Method to select and display a recipe
    public void DisplayRecipe(string recipeName)
    {
        var recipe = recipes.Find(r => r.Name == recipeName);
        if (recipe != null)
        {
            Console.WriteLine($"Recipe: {recipe.Name}");
            foreach (var ingredient in recipe.Ingredients)
            {
                Console.WriteLine($"Ingredient: {ingredient.Name}, Calories: {ingredient.Calories}, Food Group: {ingredient.FoodGroup}");
            }
            int totalCalories = CalculateTotalCalories(recipe);
            Console.WriteLine($"Total Calories: {totalCalories}");
            if (totalCalories > 300)
            {
                CalorieExceeded?.Invoke(recipe.Name, totalCalories);
            }
        }
        else
        {
            Console.WriteLine("Recipe not found.");
        }
    }
}

// Main program
class Program
{
    static void Main(string[] args)
    {
        RecipeApplication app = new RecipeApplication();

        // Add recipes
        Recipe recipe1 = new Recipe { Name = "Spaghetti", Ingredients = new List<Ingredient> { new Ingredient { Name = "Pasta", Calories = 200, FoodGroup = "Grains" }, new Ingredient { Name = "Tomato Sauce", Calories = 100, FoodGroup = "Vegetables" } } };
        app.AddRecipe(recipe1);

        Recipe recipe2 = new Recipe { Name = "Salad", Ingredients = new List<Ingredient> { new Ingredient { Name = "Lettuce", Calories = 50, FoodGroup = "Vegetables" }, new Ingredient { Name = "Chicken", Calories = 150, FoodGroup = "Protein" } } };
        app.AddRecipe(recipe2);

        // Display recipes
        app.DisplayRecipes();

        // Display a specific recipe
        app.DisplayRecipe("Salad");
    }
}
