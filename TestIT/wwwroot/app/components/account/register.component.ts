import { Component, OnInit } from '@angular/core';
import { Title }     from '@angular/platform-browser';
import { Router } from '@angular/router';
import { AbstractControl, FormBuilder, FormGroup, Validators, FormArray, FormControl, ValidatorFn } from '@angular/forms';

import { Http } from '@angular/http';
import { AuthService } from './../../security/auth.service';
import { RegisterViewModel } from './../../models/RegisterViewModel';
import { ToastrService } from 'ngx-toastr';

const EMAIL_REGEXP = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;

@Component({
    selector: 'register',
   templateUrl: 'partial/registerComponent'
})


export class RegisterComponent implements OnInit{
    registerViewModel: RegisterViewModel;
    registerForm: FormGroup;

    constructor(public router: Router, private titleService: Title, public http: Http, private authService: AuthService, private fb: FormBuilder, private toastrService: ToastrService) { }

    ngOnInit() {
        this.registerViewModel = new RegisterViewModel('', '', '');
        this.createForm(this.registerViewModel);
    }

    createForm(register: RegisterViewModel) {
        this.registerForm = this.fb.group({
            email: [register.Email, Validators.compose([Validators.required, Validators.pattern(EMAIL_REGEXP)])],
            password: [register.Password, Validators.compose([Validators.required, Validators.minLength(6)])],
            confirmPassword: [register.ConfirmPassword, Validators.compose([Validators.required, Validators.minLength(6)])]
        }, { validator: registerFormValidator });
    }

    setTitle(newTitle: string) {
        this.titleService.setTitle(newTitle);
    }

    register(event: Event): void {
        event.preventDefault();
        let body = { 'email': this.registerForm.controls.email.value, 'password': this.registerForm.controls.password.value, 'confirmPassword': this.registerForm.controls.ConfirmPassword.value };
        this.http.post('/Account/Register', JSON.stringify(body), { headers: this.authService.jsonHeaders() })
            .subscribe(response => {
                if (response.status == 200) {
                    this.router.navigate(['/login']);
                    this.toastrService.success('Your Account has been Successfully Registered');
                } else {
                    alert(response.json().error);
                    console.log(response.json().error);
                }
            },
            error => {
                // TODO: parse error messages, generate toast popups
                // {"Email":["The Email field is required.","The Email field is not a valid e-mail address."],"Password":["The Password field is required.","The Password must be at least 6 characters long."]}
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
