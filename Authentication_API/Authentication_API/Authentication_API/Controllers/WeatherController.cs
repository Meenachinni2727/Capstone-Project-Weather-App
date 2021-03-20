using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Authentication_API.Common;
using Authentication_API.Exceptions;
using Authentication_API.Models;
using Authentication_API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Authentication_API.Common.Enum;

namespace Authentication_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        #region ReadOnly Field
        private readonly IWeatherService _weatherService;
        #endregion

        #region Constructor
        public WeatherController(IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }
        #endregion

        
        [HttpGet]
        [Route("getcities")]
        public IActionResult GetCityNames()
        {
            try
            {
                var getCityList = _weatherService.GetCities();
                if (getCityList != null && getCityList.Count() > 0)
                    return Ok(getCityList);

                return StatusCode(StatusCodes.Status400BadRequest, Constants.NoResultsFound);
            }
            catch (Exception)
            {
                return StatusCode(500, "Something went wrong");
            }
        }

        [HttpPost]
        [Route("addtofavourite")]
        public IActionResult AddToFavourite([FromBody] UserFavourites favourite)
        { 
            try
            {
                if (!ModelState.IsValid)
                    return StatusCode(StatusCodes.Status400BadRequest, Constants.InputInvalid);

                return Created("", _weatherService.AddToFavourite(favourite));
            }
            catch (UserAlreadyExistsException ex)
            {
                return Conflict(ex.Message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        [HttpPost]
        [Route("favourites")]
        public IActionResult Favourites([FromBody] UserRequest favourite)
        {
            try
            {
                if (string.IsNullOrEmpty(favourite.UserId) && string.IsNullOrWhiteSpace(favourite.UserId))
                    return StatusCode(StatusCodes.Status400BadRequest, Constants.InputInvalid);

                var favList = _weatherService.Favourites(favourite.UserId);
                if (favList != null && favList.Count() > 0)
                    return Ok(favList);

                return StatusCode(StatusCodes.Status204NoContent, Constants.NoResultsFound);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        [HttpPost]
        [Route("deletefavourites")]
        public IActionResult DeleteFavourites([FromBody] UserRequest userFavourites)
        {
            try
            {
                if (!ModelState.IsValid)
                    return StatusCode(StatusCodes.Status400BadRequest, Constants.InputInvalid);

                var deleteStatus = _weatherService.DeleteFavourites(userFavourites);
                return (deleteStatus == ActionStatus.Success) ? Ok(deleteStatus) :
                            StatusCode(StatusCodes.Status204NoContent, Constants.NoResultsFound);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}