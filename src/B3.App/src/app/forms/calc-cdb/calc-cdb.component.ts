import { Component } from '@angular/core';
import { B3apiService } from '../../service/b3api.service';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { ReactiveFormsModule } from "@angular/forms"

@Component({
  selector: 'app-calc-cdb',
  standalone: true,
  imports: [ReactiveFormsModule],
  templateUrl: './calc-cdb.component.html',
  styleUrl: './calc-cdb.component.css'
})
export class CalcCDBComponent {

  resultCalculate: any = {};
  hiddenAlert: boolean = true;

  profileForm = new FormGroup({
    value: new FormControl('', Validators.required),
    months: new FormControl('', Validators.required)
  });
  
  constructor(private b3apiService: B3apiService){}

  onSubmit() {    
    console.warn('onSubmit', this.profileForm.value);    
    this.calculateInvestment();
  }

  calculateInvestment() {
    
    var subReq = this.b3apiService.calculateInvestment(
    {
      value: this.profileForm.controls.value.value,
      months: this.profileForm.controls.months.value
    });

    subReq.subscribe(resp => {
      this.resultCalculate = resp      
      this.hiddenAlert = false;
    });
    
  }

  stringify(obg: any) {
    return JSON.stringify(obg);
  }

  clickHidden() {
    console.log('clickHidden')
    this.hiddenAlert = !this.hiddenAlert;
  }

  isValid() {
    let value = parseFloat(this.profileForm.controls.value.value || "");
    let months = parseInt(this.profileForm.controls.months.value || "");
    if (!value) return false;
    if (!months) return false;    
    return true;
  }
}
