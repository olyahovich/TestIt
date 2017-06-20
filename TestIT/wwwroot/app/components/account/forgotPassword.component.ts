import { Component, OnInit } from '@angular/core';
import { Title }     from '@angular/platform-browser';
import { RoutingService } from './../../services/routing.service';
import { AbstractControl, FormBuilder, FormGroup, Validators, FormArray, FormControl, ValidatorFn } from '@angular/forms';

import { Http } from '@angular/http';
import { AuthService } from './../../security/auth.service';
import { ForgotPasswordViewModel } from './../../models/ForgotPasswordViewModel';
import { ToastrService } from 'ngx-toastr';


@Component({
    selector: 'forgotPassword',
   templateUrl: 'partial/forgotPasswordComponent'
})


export class ForgotPasswordCopmonent implements OnInit{
    forgotPasswordViewModel: ForgotPasswordViewModel;
    forgotPasswordForm: FormGroup;

    validationMessages = {
        'email': {
            'required': 'Email is required.',
            'email': 'Email format is invalid'
        }
    };

    formErrors = {
        'email': ''
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
        this.forgotPasswordViewModel = new ForgotPasswordViewModel('');
        this.createForm(this.forgotPasswordViewModel);
    }

    createForm(forgotPassword: ForgotPasswordViewModel) {
        this.forgotPasswordForm = this.fb.group({
            email: [forgotPassword.Email, Validators.compose([Validators.required, Validators.email])]
        });
        this.forgotPasswordForm.valueChanges
            .subscribe(data => this.onValueChanged(data));

        this.onValueChanged(); // (re)set validation messages now
    }

    onValueChanged(data?: any) {
        if (!this.forgotPasswordForm) { return; }
        const form = this.forgotPasswordForm;

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

    clearEmail(event: Event): void {
        this.forgotPasswordForm.controls['email'].reset();
        this.forgotPasswordForm.controls['email'].clearValidators();

    }

    forgotPassword(event: Event): void {
        event.preventDefault();
        let body = { 'email': this.forgotPasswordForm.controls['email'].value};
        this.http.post('/Account/ForgotPassword', JSON.stringify(body), { headers: this.authService.jsonHeaders() })
            .subscribe(response => {
                if (response.status == 200) {
                    this.forgotPasswordForm.reset();
                    this.routingService.navigateToSignIn();
                    this.toastrService.success('Email with Reset Password link has been sent');
                } else {
                    this.toastrService.error(response.json().description);
                    console.log(response.json().error);
                }
            },
            error => {
                this.toastrService.error(error.text());
                console.log(error.text());
            });
    }
}

