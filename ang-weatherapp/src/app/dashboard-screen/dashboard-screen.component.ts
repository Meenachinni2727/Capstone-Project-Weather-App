import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { Observable, Subject, Subscription } from 'rxjs';
import { startWith, map } from 'rxjs/operators';
import { WeatherService } from '../service/weather.service';

@Component({
  selector: 'app-dashboard-screen',
  templateUrl: './dashboard-screen.component.html',
  styleUrls: ['./dashboard-screen.component.css']
})
export class DashboardScreenComponent implements OnInit {
  weatherData: any = null;
  keyword = 'name';
  sletectedCity: string = null;
  private subscriptions = new Subscription();

  data = [
    {
      id: 1,
      name: 'Bengaluru'
    },
    {
      id: 2,
      name: 'Mysuru'
    },
    {
      id: 2,
      name: 'Delhi'
    },
    {
      id: 2,
      name: 'Chandigarh'
    },
    {
      id: 2,
      name: 'Hyderabad'
    },
    {
      id: 2,
      name: 'Chennai'
    },
    {
      id: 2,
      name: 'Mumbai'
    },
    {
      id: 2,
      name: 'Kolkata'
    },
    {
      id: 2,
      name: 'Patna'
    },
    {
      id: 2,
      name: 'Nagpur'
    },
    {
      id: 2,
      name: 'Visakapatnam'
    },
    {
      id: 2,
      name: 'Agra'
    },
    {
      id: 2,
      name: 'Srinagar'
    },
    {
      id: 2,
      name: 'Vijayawada'
    },
    {
      id: 2,
      name: 'Madurai'
    },
    {
      id: 2,
      name: 'Gurgaon'
    },
    {
      id: 2,
      name: 'Salem'
    },
    {
      id: 2,
      name: 'Guntur'
    },
    {
      id: 2,
      name: 'Noida'
    },
    {
      id: 2,
      name: 'Warangal'
    },
    {
      id: 2,
      name: 'Tirupati'
    },






  ];

  constructor(private _weatherService: WeatherService,private router:Router,
    private _route: ActivatedRoute) { }

  ngOnInit(): void {
    this.subscriptions.add(

      this._route.params.subscribe((params: Params) => {

          if (params.name) {
             this.selectEvent(params)
          }
      })
  );


  }

  selectEvent(item) {
    this.sletectedCity = item.name;
    this.keyword = this.sletectedCity;
    this._weatherService.getWeatherInforByCityName(item.name).subscribe((data) => {
      this.weatherData = data;
      console.log(data);
      //this.mArticles = data['articles'];
    });    // do something with selected item
  }

  onChangeSearch(val: string) {

    // this._weatherService.getWeatherInforByCityName(val).subscribe((data)=>{
    //   //this.mArticles = data['articles'];
    //  });

    // fetch remote data from here
    // And reassign the 'data' which is binded to 'data' property.
  }

  addToFavourite() {
    let formData = {
      userId: localStorage.getItem('currentUser'),
      city: this.sletectedCity
    };
    this._weatherService.addToFavourite(formData).subscribe((data) => {     
      this.router.navigate(['/favourite-list']);
    });
  }

  onFocused(e) {
    // do something when input is focused
  }

  resetSearch() {
    this.sletectedCity = null;
    this.weatherData = null;
  }

  ngOnDestroy(){
    this.subscriptions.unsubscribe();
  }


}
