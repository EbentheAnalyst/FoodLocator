using Microsoft.Maui.Controls;
using FoodLocator.Models;
using FoodLocator.ViewModels;

namespace FoodLocator
{
    public partial class FoodDetailPage : ContentPage
    {
        public FoodDetailPage(Food selectedFood)
        {
            InitializeComponent();
            BindingContext = new FoodDetailViewModel(selectedFood);
        }

        // Parameterless constructor for XAML preview and binding
        public FoodDetailPage()
        {
            InitializeComponent();
            BindingContext = new FoodDetailViewModel();
        }
    }
}
