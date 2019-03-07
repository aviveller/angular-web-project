import { Component, OnInit } from '@angular/core';
import { UserService } from '../user.service';

@Component({
  selector: 'app-cars',
  templateUrl: './cars.component.html',
  styleUrls: ['./cars.component.css']
})
export class CarsComponent implements OnInit {


  //todo connect to server all this veribles
  counter=[1,2,3]
  RantDays = 12;
  DayPrice = 230;
  TotalPrice = this.DayPrice * this.RantDays
  CarsToShow: any;


  constructor(private userService: UserService) { }

  
  ngOnInit() {

    this.userService.getCars().subscribe((data2: any) => {
      this.CarsToShow = data2;
      console.log(data2);
      console.log(this.CarsToShow.id);
    });
  }
    
  }

}
