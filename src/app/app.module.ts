import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AppComponent } from './app.component';
import { UiModule } from './ui/ui.module';
import { HOMEComponent } from './home/home.component';
import { ABOUTComponent } from './about/about.component';
import { CONTACTComponent } from './contact/contact.component';
import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';
import { LoginComponent } from './login/login.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { NgbdDatepickerRange } from './datepicker-range';


const appRoutes: Routes = [

  { path: 'home', component: HOMEComponent},
  { path: 'home/:id',component: HOMEComponent },
  { path: 'about', component: ABOUTComponent },
  { path: 'contact', component: CONTACTComponent },
  { path: '**', component: CONTACTComponent },
  { path: 'home', component: HOMEComponent, outlet: 'aux'}
 
];

@NgModule({
  declarations: [
    AppComponent,
    HOMEComponent,
    ABOUTComponent,
    CONTACTComponent,
    LoginComponent,
    NgbdDatepickerRange
   
   
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
    FormsModule
   
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
