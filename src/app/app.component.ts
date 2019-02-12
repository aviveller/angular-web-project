import { Component } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { UserService } from './user.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})




export class AppComponent {
  title = 'avis';
  public Show = true ;
 
  public ShowLogin(){
    
   this.Show = !this.Show;
   return this.Show
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
