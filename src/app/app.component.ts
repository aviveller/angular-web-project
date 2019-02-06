import { Component } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { UserService } from './user.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})


let testB = 0;

export class AppComponent {
  title = 'avis';
 
 
  public ShowLogin(){
    return testB = 10;

  }

  public get isUserLoggedIn(): boolean {
    const isLogged = localStorage.getItem('userToken') !== '';
    return isLogged;
  }

  constructor(public auth: UserService) {

    // localStorage.setItem('userToken', '');
    
  }


  logout() {
    localStorage.setItem('userToken', '');
  }
}
