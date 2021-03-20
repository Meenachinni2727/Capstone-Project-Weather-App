using Authentication_API.Exceptions;
using Authentication_API.Models;
using Authentication_API.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Authentication_API.Common.Enum;

namespace Authentication_API.Services
{
    public class WeatherService : IWeatherService
    {
        #region ReadOnly Field
        private readonly IWeatherRepository _weatherRepository;
        #endregion

        #region Constructor
        public WeatherService(IWeatherRepository weatherRepository)
        {
            _weatherRepository = weatherRepository;
        }


        #endregion

        /// <summary>
        /// Get list of Cities in India
        /// </summary>
        /// <returns></returns>
        public List<City> GetCities()
        {
            return _weatherRepository.GetCity();
        }


        public bool AddToFavourite(UserFavourites favourite)
        {
            var isFavourites = _weatherRepository.IsCityExists(favourite);
            if (!isFavourites)
                return _weatherRepository.AddToFavourite(favourite);
            else
                throw new UserAlreadyExistsException($"This city {favourite.City} has already added to this user {favourite.UserId}");
        }

        public List<UserFavourites> Favourites(string userId)
        {
            return _weatherRepository.Favourites(userId);
        }

        public ActionStatus DeleteFavourites(UserRequest favourite)
        {
            return _weatherRepository.DeleteFavourites(favourite);
        }
    }
}
