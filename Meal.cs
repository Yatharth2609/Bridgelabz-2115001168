using System;
using System.Collections.Generic;
using System.Linq;

public interface IMealPlan
{
    string Name { get; set; }
    int Calories { get; set; }
    List<string> Ingredients { get; set; }
    bool ValidateIngredients();
}

public class VegetarianMeal : IMealPlan
{
    public string Name { get; set; }
    public int Calories { get; set; }
    public List<string> Ingredients { get; set; } = new List<string>();
    private readonly List<string> forbiddenIngredients = new List<string> { "beef", "chicken", "pork", "fish" };

    public bool ValidateIngredients()
    {
        return !Ingredients.Any(i => forbiddenIngredients.Contains(i.ToLower()));
    }
}

public class VeganMeal : IMealPlan
{
    public string Name { get; set; }
    public int Calories { get; set; }
    public List<string> Ingredients { get; set; } = new List<string>();
    private readonly List<string> forbiddenIngredients = new List<string> 
    { "beef", "chicken", "pork", "fish", "milk", "cheese", "egg", "honey" };

    public bool ValidateIngredients()
    {
        return !Ingredients.Any(i => forbiddenIngredients.Contains(i.ToLower()));
    }
}

public class KetoMeal : IMealPlan
{
    public string Name { get; set; }
    public int Calories { get; set; }
    public List<string> Ingredients { get; set; } = new List<string>();
    private readonly List<string> requiredCategories = new List<string> { "fat", "protein" };
    private readonly List<string> limitedIngredients = new List<string> { "sugar", "wheat", "rice", "potato" };

    public bool ValidateIngredients()
    {
        bool hasRequiredCategories = requiredCategories.All(category => 
            Ingredients.Any(i => i.ToLower().Contains(category)));
        bool avoidsLimitedIngredients = !Ingredients.Any(i => 
            limitedIngredients.Contains(i.ToLower()));
        return hasRequiredCategories && avoidsLimitedIngredients;
    }
}

public class HighProteinMeal : IMealPlan
{
    public string Name { get; set; }
    public int Calories { get; set; }
    public List<string> Ingredients { get; set; } = new List<string>();
    private readonly List<string> proteinSources = new List<string> 
    { "chicken", "beef", "fish", "eggs", "tofu", "lentils", "beans", "protein powder" };

    public bool ValidateIngredients()
    {
        return Ingredients.Any(i => proteinSources.Any(p => i.ToLower().Contains(p)));
    }
}

public class Meal<T> where T : IMealPlan, new()
{
    public T Details { get; set; } = new T();
    public string MealTime { get; set; }
    
    public bool IsValid()
    {
        return Details.ValidateIngredients();
    }
}

public class MealPlanGenerator
{
    public List<Meal<T>> GenerateWeeklyPlan<T>(int targetCaloriesPerDay) where T : IMealPlan, new()
    {
        List<Meal<T>> weeklyPlan = new List<Meal<T>>();
        string[] mealTimes = { "Breakfast", "Lunch", "Dinner", "Snack" };
        
        for (int day = 1; day <= 7; day++)
        {
            foreach (var mealTime in mealTimes)
            {
                var meal = new Meal<T>
                {
                    MealTime = $"Day {day} - {mealTime}",
                    Details = new T
                    {
                        Name = $"{typeof(T).Name.Replace("Meal", "")} {mealTime}",
                        Calories = CalculateCaloriesForMeal(mealTime, targetCaloriesPerDay)
                    }
                };
                
                GenerateIngredientsForMeal(meal);
                
                if (meal.IsValid())
                {
                    weeklyPlan.Add(meal);
                }
                else
                {
                    RegenerateIngredientsUntilValid(meal);
                    weeklyPlan.Add(meal);
                }
            }
        }
        
        return weeklyPlan;
    }
    
    private int CalculateCaloriesForMeal(string mealTime, int targetCaloriesPerDay)
    {
        switch (mealTime)
        {
            case "Breakfast": return (int)(targetCaloriesPerDay * 0.25);
            case "Lunch": return (int)(targetCaloriesPerDay * 0.35);
            case "Dinner": return (int)(targetCaloriesPerDay * 0.30);
            case "Snack": return (int)(targetCaloriesPerDay * 0.10);
            default: return 0;
        }
    }
    
    private void GenerateIngredientsForMeal<T>(Meal<T> meal) where T : IMealPlan, new()
    {
        if (meal.Details is VegetarianMeal)
        {
            meal.Details.Ingredients = new List<string> { "Tofu", "Spinach", "Quinoa", "Olive Oil" };
        }
        else if (meal.Details is VeganMeal)
        {
            meal.Details.Ingredients = new List<string> { "Chickpeas", "Avocado", "Lentils", "Coconut Oil" };
        }
        else if (meal.Details is KetoMeal)
        {
            meal.Details.Ingredients = new List<string> { "Avocado", "Salmon", "Spinach", "Olive Oil", "Fat" };
        }
        else if (meal.Details is HighProteinMeal)
        {
            meal.Details.Ingredients = new List<string> { "Chicken Breast", "Eggs", "Greek Yogurt", "Protein Powder" };
        }
    }
    
    private void RegenerateIngredientsUntilValid<T>(Meal<T> meal) where T : IMealPlan, new()
    {
        int attempts = 0;
        while (!meal.IsValid() && attempts < 5)
        {
            GenerateIngredientsForMeal(meal);
            attempts++;
        }
        
        if (!meal.IsValid())
        {
            if (meal.Details is VegetarianMeal)
            {
                meal.Details.Ingredients = new List<string> { "Tofu", "Spinach", "Rice", "Olive Oil" };
            }
            else if (meal.Details is VeganMeal)
            {
                meal.Details.Ingredients = new List<string> { "Tempeh", "Broccoli", "Brown Rice", "Flax Oil" };
            }
            else if (meal.Details is KetoMeal)
            {
                meal.Details.Ingredients = new List<string> { "Avocado", "Bacon", "Spinach", "Coconut Oil", "Fat", "Protein" };
            }
            else if (meal.Details is HighProteinMeal)
            {
                meal.Details.Ingredients = new List<string> { "Chicken Breast", "Eggs", "Greek Yogurt", "Protein Powder" };
            }
        }
    }
}

public class UserProfile
{
    public string Name { get; set; }
    public int Age { get; set; }
    public int TargetCalories { get; set; }
    public List<string> DietaryRestrictions { get; set; } = new List<string>();
    
    public IMealPlan GetPreferredMealPlanType()
    {
        if (DietaryRestrictions.Contains("Vegan"))
        {
            return new VeganMeal();
        }
        else if (DietaryRestrictions.Contains("Vegetarian"))
        {
            return new VegetarianMeal();
        }
        else if (DietaryRestrictions.Contains("Keto"))
        {
            return new KetoMeal();
        }
        else
        {
            return new HighProteinMeal();
        }
    }
}

public class MealPlanService
{
    public void GenerateMealPlanForUser<T>(UserProfile user) where T : IMealPlan, new()
    {
        Console.WriteLine($"Generating a {typeof(T).Name.Replace("Meal", "")} meal plan for {user.Name}");
        
        var generator = new MealPlanGenerator();
        var mealPlan = generator.GenerateWeeklyPlan<T>(user.TargetCalories);
        
        PrintMealPlan(mealPlan);
    }
    
    private void PrintMealPlan<T>(List<Meal<T>> mealPlan) where T : IMealPlan, new()
    {
        foreach (var meal in mealPlan)
        {
            Console.WriteLine($"{meal.MealTime}: {meal.Details.Name} ({meal.Details.Calories} calories)");
            Console.WriteLine($"Ingredients: {string.Join(", ", meal.Details.Ingredients)}");
            Console.WriteLine();
        }
    }
}

class Program
{
    static void Main()
    {
        var user1 = new UserProfile
        {
            Name = "Ajay",
            Age = 28,
            TargetCalories = 2000,
            DietaryRestrictions = new List<string> { "Vegetarian" }
        };
        
        var user2 = new UserProfile
        {
            Name = "Aman",
            Age = 35,
            TargetCalories = 2500,
            DietaryRestrictions = new List<string> { "Keto" }
        };
        
        var mealPlanService = new MealPlanService();
        
        mealPlanService.GenerateMealPlanForUser<VegetarianMeal>(user1);
        mealPlanService.GenerateMealPlanForUser<KetoMeal>(user2);
        
        var user3 = new UserProfile
        {
            Name = "Priya",
            Age = 42,
            TargetCalories = 2200,
            DietaryRestrictions = new List<string> { "Vegan" }
        };
        
        var preferredMealType = user3.GetPreferredMealPlanType();
        
        if (preferredMealType is VeganMeal)
        {
            mealPlanService.GenerateMealPlanForUser<VeganMeal>(user3);
        }
        else if (preferredMealType is KetoMeal)
        {
            mealPlanService.GenerateMealPlanForUser<KetoMeal>(user3);
        }
        else if (preferredMealType is VegetarianMeal)
        {
            mealPlanService.GenerateMealPlanForUser<VegetarianMeal>(user3);
        }
        else
        {
            mealPlanService.GenerateMealPlanForUser<HighProteinMeal>(user3);
        }
    }
}