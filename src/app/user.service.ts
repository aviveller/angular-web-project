import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, EMPTY, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { error } from 'util';

import { Router } from '@angular/router'; 

@Injectable({
  providedIn: 'root'
})
export class UserService {

  readonly rootUrl = 'http://localhost:4300';

  constructor(private http: HttpClient,private router: Router) { 

  }

  userAuthentication(userName, password) {
    var data = "username=" + userName + "&password=" + password + "&grant_type=password";
    var reqHeader = new HttpHeaders({ 'Content-Type' : 'application/x-www-urlencoded'});
  
    return this.http.post(this.rootUrl + '/token', data, {headers: reqHeader});
  }


  getLocations() {return this.http.get(this.rootUrl + '/api/Locations')};


  UserRegister(userName, password) {
    var data = {Username: userName, Password: password} ;
    var reg = "/api/Users";
    var reqHeader = new HttpHeaders({ 'Content-Type' : 'application/json'});

      return this.http.post(this.rootUrl + '/api/users',data, {headers: reqHeader}) .pipe(
        catchError( err => {
             if (err.status == 500) {
               console.log('error made by avi beacuse cannot register')
              this.router.navigate(['/home']);
                 return EMPTY;
             } else {
                 return throwError(err);
             }
        })
    );

    // return this.http.post(this.rootUrl + '/api/users',data, {headers: reqHeader}).pipe ( 
    //   catchError((error) => {return error;let a = console.log('error for user registration')} ));
    
  }

  getUserClaims() {
    return this.http.get(this.rootUrl + '/api/users', { headers: new HttpHeaders({
      'Authorization' : 'Bearer ' + localStorage.getItem('userToken')
    })});
  }


  getCars() {
    return this.http.get(this.rootUrl + '/api/cars', { headers: new HttpHeaders({
      'Authorization' : 'Bearer ' + localStorage.getItem('userToken')
    })});
  }

  

  getCatalogByid(id:number) {
    return this.http.get(this.rootUrl + '/api/Catalog/' + id, { headers: new HttpHeaders({
      'Authorization' : 'Bearer ' + localStorage.getItem('userToken')
    })});
  }
  


  public isUserLoggedIn() {
    return localStorage.getItem('userToken').length > 0;
  }
  public isUserAdmin() {
    return localStorage.getItem('role') == "1";
  }


}