import { Component, OnInit, Input } from '@angular/core';
import { UserService } from '../user.service';
import { Router } from '@angular/router';

import { DatereturnComponent } from '../dates/datereturn.component';
import { NgbDate, NgbDateNativeAdapter } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})


export class HOMEComponent implements OnInit {

  Taken: any;
  Return: any;
  locations: any;


  //this function cuclate the difrence between two dates

  ConvertToNativeDate() {
    let converter: NgbDateNativeAdapter = new NgbDateNativeAdapter;
    let TakenConverted = converter.toModel(this.Taken);
    let ReturnConverted = converter.toModel(this.Return);

    var diff = Math.abs(TakenConverted.getTime() - ReturnConverted.getTime());
    var diffDays = Math.ceil(diff / (1000 * 3600 * 24));
    console.log(diffDays)

  }

  GetReturn(model) {

    this.Return = model;
    console.log(this.Return);
  }

  GetTaken(model) {

    this.Taken = model;
    console.log(this.Taken);
  }



  test() {
    console.log(this.Taken, this.Return)

    let TakenTime: NgbDate = new NgbDate(this.Taken.year, this.Taken.month, this.Taken.day);
    let ReturnTime: NgbDate = new NgbDate(this.Return.year, this.Return.month, this.Return.day);

    console.log(ReturnTime.after(TakenTime));
    console.log(ReturnTime.month - TakenTime.month);
  }



  constructor(private userService: UserService, private router: Router) { }

  ngOnInit() {

    this.userService.getLocations().subscribe((Data: any) => {
      this.locations = Data;
      console.log(Data);
    });
  }

}
