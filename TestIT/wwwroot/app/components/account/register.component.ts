import { Component, OnInit } from '@angular/core';
import { Title }     from '@angular/platform-browser';
import { RoutingService } from './../../services/routing.service';
import { AbstractControl, FormBuilder, FormGroup, Validators, FormArray, FormControl, ValidatorFn } from '@angular/forms';

import { Http } from '@angular/http';
import { AuthService } from './../../security/auth.service';
import { RegisterViewModel } from './../../models/RegisterViewModel';
import { ToastrService } from 'ngx-toastr';


@Component({
    selector: 'register',
   templateUrl: 'partial/registerComponent'
})


export class RegisterComponent implements OnInit{
    registerViewModel: RegisterViewModel;
    registerForm: FormGroup;

    validationMessages = {
        'email': {
            'required': 'Email is required.',
            'minlength': 'Email must be at least 4 characters long.',
            'email': 'Email format is invalid'
        },
        'password': {
            'required': 'Password is required.',
            'minlength': 'Password must be at least 6 characters long.'
        },
        'confirmPassword': {
            'required': 'Password is required.',
            'minlength': 'Password must be at least 6 characters long.'
        }
    };

    formErrors = {
        'email': '',
        'password': '',
        'confirmPassword': ''

    };

    constructor(public routingService: RoutingService,
        private titleService: Title,
        public http: Http,
        private authService: AuthService,
        private fb: FormBuilder,
        private toastrService: ToastrService) {
        if (authService.loggedIn()) {
            routingService.navigateToHome();
        }
    }

    ngOnInit() {
        this.registerViewModel = new RegisterViewModel('', '', '');
        this.createForm(this.registerViewModel);
    }

    createForm(register: RegisterViewModel) {
        this.registerForm = this.fb.group({
            email: [register.Email, Validators.compose([Validators.required, Validators.email])],
            password: [register.Password, Validators.compose([Validators.required, Validators.minLength(6)])],
            confirmPassword: [register.ConfirmPassword, Validators.compose([Validators.required, Validators.minLength(6)])]
        }, { validator: registerFormValidator });
        this.registerForm.valueChanges
            .subscribe(data => this.onValueChanged(data));

        this.onValueChanged(); // (re)set validation messages now
    }

    onValueChanged(data?: any) {
        if (!this.registerForm) { return; }
        const form = this.registerForm;

        for (const field in this.formErrors) {
            // clear previous error message (if any)
            this.formErrors[field] = "";
            const control = form.get(field);

            if (control && control.dirty && !control.valid) {
                const messages = this.validationMessages[field];
                for (const key in control.errors) {
                    this.formErrors[field] += messages[key] + ' ';
                    break;
                }
            }
        }
    }
    setTitle(newTitle: string) {
        this.titleService.setTitle(newTitle);
    }

    clearPassword(event: Event): void {
        this.registerForm.controls['password'].reset();
        this.registerForm.controls['password'].clearValidators();
    }

    clearEmail(event: Event): void {
        this.registerForm.controls['email'].reset();
        this.registerForm.controls['email'].clearValidators();
    }

    clearConfirmPassword(event: Event): void {
        this.registerForm.controls['confirmPassword'].reset();
        this.registerForm.controls['confirmPassword'].clearValidators();
    }


    register(event: Event): void {
        event.preventDefault();
        let body = { 'email': this.registerForm.controls['email'].value, 'password': this.registerForm.controls['password'].value, 'confirmPassword': this.registerForm.controls['confirmPassword'].value };
        this.http.post('/Account/Register', JSON.stringify(body), { headers: this.authService.jsonHeaders() })
            .subscribe(response => {
                if (response.status == 200) {
                    this.routingService.navigateToSignIn();
                    this.toastrService.success('Your Account has been Successfully Registered');
                } else {
                    this.toastrService.error(response.json().description);
                    console.log(response.json().error);
                }
            },
            error => {
                // TODO: parse error messages, generate toast popups
                // {"Email":["The Email field is required.","The Email field is not a valid e-mail address."],"Password":["The Password field is required.","The Password must be at least 6 characters long."]}
                this.registerForm.controls['password'].reset();
                this.registerForm.controls['password'].clearValidators();
                this.registerForm.controls['confirmPassword'].reset();
                this.registerForm.controls['confirmPassword'].clearValidators();
                this.toastrService.error(error.text());
                console.log(error.text());
            });
    }
}

function registerFormValidator(fg: FormGroup): { [key: string]: boolean } {
    //TODO: check if email is already taken

    //Password match validation
    if (fg.get('password').value !== fg.get('confirmPassword').value)
        return { 'passwordmismatch': true }

    return null;
}
