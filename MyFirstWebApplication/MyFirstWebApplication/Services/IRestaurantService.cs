using MyFirstWebApplication.Models;

namespace MyFirstWebApplication.Services
{
	public interface IRestaurantService
	{
		List<Restaurant> GetRestaurants();
	}
}
