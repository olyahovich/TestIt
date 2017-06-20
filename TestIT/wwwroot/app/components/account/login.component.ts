import { Component, OnInit } from '@angular/core';
import { Title }     from '@angular/platform-browser';
import { AbstractControl, FormBuilder, FormGroup, Validators, FormArray, FormControl, ValidatorFn } from '@angular/forms';

import { Http } from '@angular/http';
import { AuthService } from './../../security/auth.service';
import { LoginViewModel } from './../../models/LoginViewModel';
import { ToastrService } from 'ngx-toastr';
import { RoutingService } from './../../services/routing.service'

@Component({
    selector: 'login',
   templateUrl: 'partial/loginComponent'
})


export class LoginComponent implements OnInit{
    loginViewModel: LoginViewModel;
    loginForm: FormGroup;

    validationMessages = {
        'email': {
            'required': 'Email is required.',
            'minlength': 'Email must be at least 4 characters long.',
            'email': 'Email format is invalid'
        },
        'password': {
            'required': 'Password is required.',
            'minlength': 'Password must be at least 6 characters long.'
        }
    };

    formErrors = {
        'email': '',
        'password': ''
    };

    constructor(public router: RoutingService,
        private titleService: Title,
        public http: Http,
        private authService: AuthService,
        private fb: FormBuilder,
        private toastrService: ToastrService) {
        if (authService.loggedIn()) {
            router.navigateToHome();
        }
    }

    ngOnInit() {
        this.loginViewModel = new LoginViewModel('', '');
        this.createForm(this.loginViewModel);
    }

    createForm(login: LoginViewModel) {
        this.loginForm = this.fb.group({
            email: [login.Email, Validators.compose([Validators.required, Validators.email,
            Validators.minLength(6)])],
            password: [login.Password, Validators.compose([Validators.required, Validators.minLength(6)])],
            rememberMe: [login.RememberMe]
        });
        this.loginForm.valueChanges
            .subscribe(data => this.onValueChanged(data));

        this.onValueChanged(); // (re)set validation messages now
    }

    onValueChanged(data?: any) {
        if (!this.loginForm) { return; }
        const form = this.loginForm;

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

    public setTitle(newTitle: string) {
        this.titleService.setTitle(newTitle);
    }

    clearPassword(event: Event): void {
        this.loginForm.controls['password'].reset();
        this.loginForm.controls['password'].clearValidators();
    }

    clearEmail(event: Event): void {
        this.loginForm.controls['email'].reset();
        this.loginForm.controls['email'].clearValidators();
    }
    

    // post the user's login details to server, if authenticated token is returned, then token is saved to session storage
    login(event: Event): void {
        event.preventDefault();
        let body = 'username=' + this.loginForm.controls['email'].value + '&password=' + this.loginForm.controls['password'].value + '&grant_type=password';

        this.http.post('/connect/token', body, { headers: this.authService.contentHeaders() })
            .subscribe(response => {
                // success, save the token to session or local storage depends on remeber me checkbox value
                this.authService.login(response.json(), this.loginForm.controls['rememberMe'].value);
                this.toastrService.success('You have been logged in successfully.');
                this.loginForm.reset();
                    this.router.navigateToHome();
                },
            error => {
                // failed; TODO: add some nice toast / error handling
                this.toastrService.error(error.json().error_description);
                this.loginForm.controls['password'].reset();
                this.loginForm.controls['password'].clearValidators();
                console.log(error.text());
            }
            );
    }
}
