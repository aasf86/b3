import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CalcCDBComponent } from './calc-cdb.component';

describe('CalcCDBComponent', () => {
  let component: CalcCDBComponent;
  let fixture: ComponentFixture<CalcCDBComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CalcCDBComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CalcCDBComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
