using Authentication_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Authentication_API.Common.Enum;

namespace Authentication_API.Services
{
    public interface IWeatherService
    {
        #region Interface Methods
        List<City> GetCities();
        bool AddToFavourite(UserFavourites favourite);
        List<UserFavourites> Favourites(string userId);
        ActionStatus DeleteFavourites(UserRequest favourite);
        #endregion
    }
}
