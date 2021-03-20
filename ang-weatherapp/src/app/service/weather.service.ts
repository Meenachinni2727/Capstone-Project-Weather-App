import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class WeatherService {
  //API_KEY = "c2d372ae310c441cb1f84308f9ea8a27";
  API_KEY = "bc360d447cad4bf5842104070f251aed";
  // API_KEY = "8ef68669556f47d0bb7689c1c4d88786";
  readonly BaseURI = 'http://localhost:50014/api';

  constructor(private http: HttpClient) { }

  public getWeatherInforByCityName(city: any) {
    return this.http.get(`http://api.openweathermap.org/data/2.5/weather?q=${city}&apiKey=66335febc6e1903d3476c7da02b63a3a`);
  }

  public getFavList(userName: any) {
    return this.http.post(this.BaseURI + '/weather/favourites', userName);
  }


  addToFavourite(formData) {
    return this.http.post(this.BaseURI + '/weather/addtofavourite', formData);
  }

  removeFavourite(formData) {
    return this.http.post(this.BaseURI + '/weather/deletefavourites', formData);
  }

}
