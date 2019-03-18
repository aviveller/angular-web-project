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
  catalog: any;
  CarId = this.CarsToShow.id


  constructor(private userService: UserService) { }

  
  ngOnInit() {

  
    this.userService.getCatalogByid(this.CarId).subscribe((data3: any) => {
      this.catalog = data3;
      console.log(this.catalog);
    });
  }
    
  }


