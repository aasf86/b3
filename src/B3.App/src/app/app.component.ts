import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { CalcCDBComponent } from "./forms/calc-cdb/calc-cdb.component";

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, CalcCDBComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'B3.App';

  ngOnInit(){
    console.log('AppComponent on init')
  }
}
