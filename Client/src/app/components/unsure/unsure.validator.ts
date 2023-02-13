
import {AbstractControl, ValidatorFn, ValidationErrors} from '@angular/forms';

export function AgeValidator(): ValidatorFn {
    return (control: AbstractControl): ValidationErrors | null => {
        
        var currentYear =  String(new Date().getFullYear());
        var dateOfBirth = control.value;
        var dateOfBirthYear = String(new Date(dateOfBirth).getFullYear());
        var age = Number(currentYear) - Number(dateOfBirthYear);
        return (age > 17 && age <= 80) ? null : {invalidAge: {value: age}};
    };
}