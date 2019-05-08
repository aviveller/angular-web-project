import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css']
})
export class UserComponent implements OnInit {
  UserName: string;


   Fakepurchase = [];
  
  constructor() { }

  ngOnInit() {
    this.UserName = localStorage.getItem('UserName')
    console.log(this.UserName);


    // TODO: Replace this data with data from db
    this.Fakepurchase = [
      {Date: 21/10/19,car:'BMW X5',Days:"5",TotalCost:1000,},
      {Date: 1/3/19,car:'FIAT 500',Days:"3",TotalCost:1000,},
      {Date: 5/5/18,car:'MAZDA 6',Days:"4",TotalCost:655,},
      {Date: 21/10/18,car:'SIAT IBIZA',Days:"12",TotalCost:3200,},
  
  
  
  ]
  }


}
