How to Use

Adding Recipes: Use the AddRecipe method in the RecipeApplication class to add recipes. Each recipe consists of a name and a list of ingredients, where each ingredient has a name, calories, and food group.

Displaying Recipes: Call the DisplayRecipes method to display all recipes sorted alphabetically by name. To display a specific recipe, use the DisplayRecipe method with the recipe name as an argument.

Calculating Total Calories: The CalculateTotalCalories method in the RecipeApplication class calculates the total calories for a given recipe by summing the calories of all its ingredients.

Calorie Notification: If a recipe's total calories exceed 300, the application notifies the user by invoking the CalorieExceeded event.

Code Structure

Ingredient class: Represents an ingredient with properties for name, calories, and food group.
Recipe class: Represents a recipe with properties for name and a list of ingredients.
RecipeApplication class: Manages the application functionality, including adding recipes, calculating total calories, displaying recipes, and handling calorie notifications.
Program class: Main entry point of the application with example usage.
Running the Application

To run the application, compile the code using a C# compiler (e.g., Visual Studio, .NET CLI) and execute the generated executable. The example usage provided in the Program class demonstrates how to add recipes, display recipes, and handle calorie notifications.

Dependencies

This application does not have any external dependencies and can be run using any standard C# development environment.

Contributors

This application was developed by [Your Name] as an example implementation of recipe management in C#.
