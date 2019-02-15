import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  readonly rootUrl = 'http://localhost:4300';

  constructor(private http: HttpClient) { 

  }

  userAuthentication(userName, password) {
    var data = "username=" + userName + "&password=" + password + "&grant_type=password";
    var reqHeader = new HttpHeaders({ 'Content-Type' : 'application/x-www-urlencoded'});
  
    return this.http.post(this.rootUrl + '/token', data, {headers: reqHeader});
  }

  UserRegister(userName, password) {
    var data = {Username: userName, Password: password, Id: 20} ;
    var reg = "/api/Users";
    var reqHeader = new HttpHeaders({ 'Content-Type' : 'application/json'});

    return this.http.post(this.rootUrl + '/api/users',data, {headers: reqHeader});
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

  
  


  public isUserLoggedIn() {
    return localStorage.getItem('userToken').length > 0;
  }
  public isUserAdmin() {
    return localStorage.getItem('role') == "1";
  }


}