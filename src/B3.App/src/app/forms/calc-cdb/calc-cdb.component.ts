import { Component, Input } from '@angular/core';
import { B3apiService } from '../../service/b3api.service';
import { environment } from '../../../environments/environment';

@Component({
  selector: 'app-calc-cdb',
  standalone: true,
  imports: [],
  templateUrl: './calc-cdb.component.html',
  styleUrl: './calc-cdb.component.css'
})
export class CalcCDBComponent {

  @Input() titleOutSide : string = '--';

  name = 'Nome interno';
  
  constructor(private b3apiService: B3apiService){}

  go() {
    return 'Anderson';
  }

  ngOnInit() : void {
    console.log('ngOnInit', this.b3apiService);
    console.log('ngOnInit', environment); 
  }
}
