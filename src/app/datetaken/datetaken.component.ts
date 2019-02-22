import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-datetaken',
  templateUrl: './datetaken.component.html',
  styleUrls: ['./datetaken.component.css']
})
export class DatetakenComponent implements OnInit {
model:any;



  constructor() { }

  ngOnInit() { 
  }

  public test(){
    console.log(this.model)
  }

}
