import { Component, OnInit } from '@angular/core';

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


  constructor() { }

  ngOnInit() {
  }

}
