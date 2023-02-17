import { ComponentFixture, TestBed } from '@angular/core/testing';
import { UnsureComponent } from './unsure.component';
import { FormControl } from '@angular/forms';
import { AgeValidator } from './unsure.validation';


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
    it('valid DOB, expect invalidAge to be null', () => {
      control.setValue('1992-01-01');
      expect(control.hasError('invalidAge')).toBe(false);
    });
    it('invalid DOB, under 17, expect invalidAge to be false', () => {
      control.setValue('2023-01-01');
      expect(control.hasError('invalidAge')).toBe(true);
    });  
    it('invalid DOB, over 80, expect invalidAge to be false', () => {
      control.setValue('1923-01-01');
      expect(control.hasError('invalidAge')).toBe(true);
    });  
  });
});
