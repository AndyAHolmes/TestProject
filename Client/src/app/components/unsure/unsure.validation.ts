import { AbstractControl, ValidatorFn, ValidationErrors } from '@angular/forms';

export function AgeValidator(): ValidatorFn {
    return (control: AbstractControl): ValidationErrors | null => {

        var currentDate = new Date();
        var dateOfBirth = new Date(control.value);
        var age = currentDate.getFullYear() - dateOfBirth.getFullYear();

        if (age < 17 || age > 80) 
            return { invalidAge: true }
        return null
    };
}