import { UserService } from './../user.service';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  isLoginError = false;
  UserName: string;

  constructor(private userService: UserService, private router: Router) { }

  ngOnInit() {

  }

  // signInForm = new FormGroup({
  //   name: new FormControl('', [Validators.required]),
  //   password: new FormControl('', [Validators.minLength(6)])
  // })

  // submitForm() {
  //   if (!this.signInForm.valid) {
  //     console.log('not valid');
  //   }
  //   else {
  //     console.log(this.signInForm.get('name').value);
  //     console.log(this.signInForm.get('password').value);
  //   }

  // }

  OnSubmit(userName, password) {
    this.userService.userAuthentication(userName, password).subscribe(
      (data: any) => {
        localStorage.setItem('userToken', data.access_token);
        localStorage.setItem('role', data.role);
        localStorage.setItem('UserName', data.userName);
        console.dir(data);
        this.UserName = localStorage.getItem('UserName');
        console.log(userName);
        if (localStorage.getItem('role') == "1") {
          this.router.navigate(['/secrets']);
        }

        if (localStorage.getItem('role') == "3") {
          this.router.navigate(['/user']);
        }


      },
      

      (err: HttpErrorResponse) => {
        this.isLoginError = true;
      }

    );
  }
  
}


