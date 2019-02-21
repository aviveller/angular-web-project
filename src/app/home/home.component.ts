import { Component, OnInit } from '@angular/core';
import { UserService } from '../user.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})


export class HOMEComponent implements OnInit {

  locations:any;

  constructor(private userService: UserService, private router: Router) { }

  ngOnInit() {

    this.userService.getLocations().subscribe((Data: any) => {
      this.locations = Data;
      console.log(Data);
    });
  }

}
