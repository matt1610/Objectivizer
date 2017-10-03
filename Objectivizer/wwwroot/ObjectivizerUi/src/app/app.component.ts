import { Component } from '@angular/core';
import { MdButtonModule, MdCheckboxModule, MdDialog } from '@angular/material';
import { AuthorizationComponent } from '../app/authorization/authorization.component';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'app';

  constructor() {
    
  }
}
