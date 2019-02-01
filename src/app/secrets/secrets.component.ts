import { Component, OnInit } from '@angular/core';
import { UserService } from '../user.service';

@Component({
  selector: 'app-secrets',
  templateUrl: './secrets.component.html',
  styleUrls: ['./secrets.component.css']
})
export class SecretsComponent implements OnInit {
  userInfo: any;
  carsInfo: any;

  constructor(private userService: UserService) { }

  ngOnInit() {
    this.userService.getUserClaims().subscribe((data: any) => {
      this.userInfo = data;
      console.log(data);
    });

    this.userService.getCars().subscribe((data2: any) => {
      this.carsInfo = data2;
      console.log(data2);
    });
  }

}
