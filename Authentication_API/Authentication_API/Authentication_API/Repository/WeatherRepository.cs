using Authentication_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Authentication_API.Common.Enum;

namespace Authentication_API.Repository
{
    public class WeatherRepository : IWeatherRepository
    {
        #region Readonly Field
        private readonly AuthDbContext authDbContext;
        #endregion

        #region Constructor
        public WeatherRepository(AuthDbContext _authDbContext)
        {
            authDbContext = _authDbContext;
        }
        #endregion

        #region Implicit Implementation of interface methods

        /// <summary>
        /// Get list of cities available in India
        /// </summary>
        /// <returns></returns>
        public List<City> GetCity()
        {
            List<City> cityList = new List<City>();
            cityList = authDbContext.City.Where(x => x.IsActive == true).ToList();
            if (cityList != null && cityList.Count() > 0)
            {
                return cityList;
            }
            return cityList;
        }

        /// <summary>
        /// Add City to User Specific
        /// </summary>
        /// <param name="favourite"></param>
        /// <returns></returns>
        public bool AddToFavourite(UserFavourites favourite)
        {
            authDbContext.UserFavourites.Add(favourite);
            authDbContext.SaveChanges();
            return true;
        }

        /// <summary>
        /// Check City already exists for UserName
        /// </summary>
        /// <param name="favourite"></param>
        /// <returns></returns>
        public bool IsCityExists(UserFavourites favourite)
        {
            var userCityExists = authDbContext.UserFavourites.FirstOrDefault(fav => fav.UserId == favourite.UserId
                                        && fav.City == favourite.City);
         
            return (userCityExists != null) ? true : false;
        }

        public List<UserFavourites> Favourites(string userId)
        {
            return authDbContext.UserFavourites.Where(u => u.UserId == userId).ToList();
        }

        public ActionStatus DeleteFavourites(UserRequest favourite)
        {
            var userCityExists = authDbContext.UserFavourites.FirstOrDefault(fav => fav.UserId == favourite.UserId
                                        && fav.City == favourite.City);


            authDbContext.UserFavourites.Remove(userCityExists);
            authDbContext.SaveChanges();
            return ActionStatus.Success;
        }

        #endregion
    }
}
