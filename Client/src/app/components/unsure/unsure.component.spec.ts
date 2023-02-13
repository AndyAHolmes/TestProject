import { ComponentFixture, TestBed } from '@angular/core/testing';
import { UnsureComponent } from './unsure.component';

import { FormControl } from "@angular/forms";
import { AgeValidator } from './unsure.validator'

describe('UnsureComponent', () => {
  let component: UnsureComponent;
  let fixture: ComponentFixture<UnsureComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UnsureComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(UnsureComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  describe('CustomValidator', () => {
    beforeEach(() => TestBed.configureTestingModule({}));
  
    const control = new FormControl('',AgeValidator());
    it('should return null if dob is valid', () => {
      control.setValue('1985-01-01');
      expect(control.hasError('invalidAge')).toBe(false);
    });
    it('should return age if dob is invalid', () => {
      control.setValue('2020-01-01');
      expect(control.hasError('invalidAge')).toBe(true);
    });  

});
