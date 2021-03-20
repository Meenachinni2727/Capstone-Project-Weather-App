import { Component, OnInit } from '@angular/core';
import { WeatherService } from '../service/weather.service';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';


@Component({
  selector: 'app-favourite-list',
  templateUrl: './favourite-list.component.html',
  styleUrls: ['./favourite-list.component.css']
})
export class FavouriteListComponent implements OnInit {
  userId: string = null;
  favList: any;


  dataList = [
    {
      id: 1,
      city: 'Banglore'
    },
    {
      id: 2,
      city: 'Mysore'
    },
    {
      id: 2,
      city: 'Delhi'
    },
    {
      id: 2,
      city: 'Chandigarh'
    },
    {
      id: 2,
      city: 'Hyderabad'
    },
    {
      id: 2,
      city: 'Chennai'
    }
  ];

  constructor(private _weatherService: WeatherService,private router:Router) { }

  ngOnInit(): void {
    this.userId = localStorage.getItem('currentUser');
    this.getFavList();
  }

  getFavList() {
    let formData = {
      userId: this.userId
    };
    // this.favList = this.dataList;
    this._weatherService.getFavList(formData).subscribe((data) => {

      this.favList = data;
    });
  }

  removeFavourite(item) {
    let formData = {
      userId: this.userId,
      city: item.city
    };
    this._weatherService.removeFavourite(formData).subscribe((data) => {
      this.getFavList();
    });
    alert("City name has been removed from favourite list");
  }

  redirectToWeatherReport(item){
    this.router.navigate(['/dashboard-screen',{name: item.city}]);

  }

}
