using System.Collections.ObjectModel;
using Microsoft.Maui.Controls;
using System.Collections.Generic;
using System.Linq;
using FoodLocator.Models;

namespace FoodLocator.ViewModels
{
    public class FoodsViewModel : BindableObject
    {
        private string _searchQuery;
        private string _selectedCategory;
        private ObservableCollection<Food> _filteredFoods;

        public ObservableCollection<Food> Foods { get; set; }
        public ObservableCollection<Food> FilteredFoods
        {
            get => _filteredFoods;
            set
            {
                _filteredFoods = value;
                OnPropertyChanged();
            }
        }

        public List<string> Categories { get; } = new List<string> { "All", "Vegetarian", "Non-Vegetarian", "Gluten-Free", "Vegan" };

        public string SelectedCategory
        {
            get => _selectedCategory;
            set
            {
                _selectedCategory = value;
                OnPropertyChanged();
                FilterFoods();
            }
        }

        public string SearchQuery
        {
            get => _searchQuery;
            set
            {
                _searchQuery = value;
                OnPropertyChanged();
                FilterFoods();
            }
        }

        public Command<Food> FoodSelectedCommand { get; }

        public FoodsViewModel()
        {
            Foods = new ObservableCollection<Food>
            {
                new Food
                {
                    Name = "Burger",
                    Image = "burger.png",
                    Locations = new List<FoodLocator.Models.Location>
                    {
                        new FoodLocator.Models.Location { Address = "123 Burger Lane", Contact = "555-1234" },
                        new FoodLocator.Models.Location { Address = "456 Burger Blvd", Contact = "555-5678" }
                    },
                    Category = "Non-Vegetarian"
                },
                new Food
                {
                    Name = "Pizza",
                    Image = "pizza.png",
                    Locations = new List<FoodLocator.Models.Location>
                    {
                        new FoodLocator.Models.Location { Address = "789 Pizza St", Contact = "555-7890" },
                        new FoodLocator.Models.Location { Address = "101 Pizza Ave", Contact = "555-1011" }
                    },
                    Category = "Vegetarian"
                },
                new Food
                {
                    Name = "Sushi",
                    Image = "sushi.png",
                    Locations = new List<FoodLocator.Models.Location>
                    {
                        new FoodLocator.Models.Location { Address = "111 Sushi Rd", Contact = "555-1111" },
                        new FoodLocator.Models.Location { Address = "222 Sushi Blvd", Contact = "555-2222" }
                    },
                    Category = "Non-Vegetarian"
                },
                new Food
                {
                    Name = "Salad",
                    Image = "salad.png",
                    Locations = new List<FoodLocator.Models.Location>
                    {
                        new FoodLocator.Models.Location { Address = "333 Salad Dr", Contact = "555-3333" },
                        new FoodLocator.Models.Location { Address = "444 Salad St", Contact = "555-4444" }
                    },
                    Category = "Vegan"
                },
                new Food
                {
                    Name = "Tacos",
                    Image = "tacos.png",
                    Locations = new List<FoodLocator.Models.Location>
                    {
                        new FoodLocator.Models.Location { Address = "555 Taco Ln", Contact = "555-5555" },
                        new FoodLocator.Models.Location { Address = "666 Taco St", Contact = "555-6666" }
                    },
                    Category = "Gluten-Free"
                }
            };

            FilteredFoods = new ObservableCollection<Food>(Foods);

            FoodSelectedCommand = new Command<Food>(OnFoodSelected);
        }

        private void FilterFoods()
        {
            var filteredList = Foods.AsEnumerable();

            if (!string.IsNullOrWhiteSpace(SearchQuery))
            {
                filteredList = filteredList.Where(f => f.Name.ToLower().Contains(SearchQuery.ToLower()));
            }

            if (!string.IsNullOrWhiteSpace(SelectedCategory) && SelectedCategory != "All")
            {
                filteredList = filteredList.Where(f => f.Category == SelectedCategory);
            }

            FilteredFoods = new ObservableCollection<Food>(filteredList);
        }

        private async void OnFoodSelected(Food selectedFood)
        {
            if (selectedFood != null)
            {
                await Application.Current.MainPage.Navigation.PushAsync(new FoodDetailPage(selectedFood));
            }
        }
    }
}
