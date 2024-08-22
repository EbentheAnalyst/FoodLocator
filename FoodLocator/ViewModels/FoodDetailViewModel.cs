using Microsoft.Maui.Controls;
using FoodLocator.Models;

namespace FoodLocator.ViewModels
{
    public class FoodDetailViewModel : BindableObject
    {
        public Food SelectedFood { get; set; }

        // Parameterless constructor
        public FoodDetailViewModel() { }

        // Constructor that accepts a Food object
        public FoodDetailViewModel(Food food)
        {
            SelectedFood = food;
        }
    }
}
