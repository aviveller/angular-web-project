import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AppComponent } from './app.component';
import { UiModule } from './ui/ui.module';
import { HOMEComponent } from './home/home.component';
import { ABOUTComponent } from './about/about.component';
import { CONTACTComponent } from './contact/contact.component';
import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { SignUpComponent } from './sign-up/sign-up.component';
import { LoginComponent } from './login/login.component';
import { LogoutComponent } from './logout/logout.component';
import { SecretsComponent } from './secrets/secrets.component';
import { AuthGuard } from './auth.guard';
import { DatetakenComponent } from './datetaken/datetaken.component';
import { DatereturnComponent } from './datereturn/datereturn.component';




const appRoutes: Routes = [

  { path: 'home', component: HOMEComponent},
  { path: 'about', component: ABOUTComponent },
  { path: 'contact', component: CONTACTComponent },
  { path: 'secrets', component: SecretsComponent, canActivate: [AuthGuard]},
  { path: 'sign-up', component: SignUpComponent },
  { path: 'login', component: LoginComponent },
  { path: 'home', component: HOMEComponent, outlet: 'aux'},
  { path: '**', component: CONTACTComponent },
];

@NgModule({
  declarations: [
    AppComponent,
    HOMEComponent,
    ABOUTComponent,
    CONTACTComponent,
    SignUpComponent,
    LoginComponent,
    LogoutComponent,
    SecretsComponent,
    DatetakenComponent,
    DatereturnComponent
    
  
   
   
   
  ],
  imports: [
    RouterModule.forRoot(
      appRoutes,
      { enableTracing: true } // <-- debugging purposes only
    ),
    BrowserModule,
    UiModule,
    BsDatepickerModule.forRoot(),
    NgbModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule
   
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
