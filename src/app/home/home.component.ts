import { Component, OnInit, Input } from '@angular/core';
import { UserService } from '../user.service';
import { Router } from '@angular/router';

import { DatereturnComponent } from '../datereturn/datereturn.component';
import { NgbDate } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})


export class HOMEComponent implements OnInit {

 Taken:any;
 Return:any;
locations:any;

  GetReturn(model){

    this.Return = model;
    console.log(this.Return);
  }

  GetTaken(model){

    this.Taken = model;
    console.log(this.Taken);
  }
  

  test(){console.log(this.Taken,this.Return)
    
    let T: NgbDate = new NgbDate(this.Taken.year,this.Taken.month,this.Taken.day);
    let R: NgbDate = new NgbDate(this.Return.year,this.Return.month,this.Return.day);

    console.log(R.after(T));
    ;}

  constructor(private userService: UserService, private router: Router) { }

  ngOnInit() {

    this.userService.getLocations().subscribe((Data: any) => {
      this.locations = Data;
      console.log(Data);
    });
  }

}
