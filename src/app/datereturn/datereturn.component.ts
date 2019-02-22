import { Component, EventEmitter, Input, Output, OnInit } from '@angular/core';


@Component({
  selector: 'app-datereturn',
  templateUrl: './datereturn.component.html',
  styleUrls: ['./datereturn.component.css']
})
export class DatereturnComponent implements OnInit {

model
@Output() Change = new EventEmitter();

public Passvalue(event){
this.Change.emit(event);  
 
}

  constructor() { }

  ngOnInit() {
  }

}
