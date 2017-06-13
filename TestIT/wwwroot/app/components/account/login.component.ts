import { Component, OnInit } from '@angular/core';
import { Title }     from '@angular/platform-browser';
import { Router } from '@angular/router';
import { AbstractControl, FormBuilder, FormGroup, Validators, FormArray, FormControl, ValidatorFn } from '@angular/forms';

import { Http } from '@angular/http';
import { AuthService } from './../../security/auth.service';
import { LoginViewModel } from './../../models/LoginViewModel';
import { ToastrService } from 'ngx-toastr';

const EMAIL_REGEXP = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;

@Component({
    selector: 'login',
   templateUrl: 'partial/loginComponent'
})


export class LoginComponent implements OnInit{
    loginViewModel: LoginViewModel;
    loginForm: FormGroup;

    constructor(public router: Router, private titleService: Title, public http: Http, private authService: AuthService, private fb: FormBuilder, private toastrService: ToastrService) { }

    ngOnInit() {
        this.loginViewModel = new LoginViewModel('', '');
        this.createForm(this.loginViewModel);
    }

    createForm(login: LoginViewModel) {
        this.loginForm = this.fb.group({
            email: [login.Email, Validators.compose([Validators.required, Validators.pattern(EMAIL_REGEXP)])],
            password: [login.Password, Validators.compose([Validators.required, Validators.minLength(6)])]
        });
    }

    public setTitle(newTitle: string) {
        this.titleService.setTitle(newTitle);
    }

    // post the user's login details to server, if authenticated token is returned, then token is saved to session storage
    login(event: Event): void {
        event.preventDefault();
        let body = 'username=' + this.loginForm.controls.email.value + '&password=' + this.loginForm.controls.password.value + '&grant_type=password';

        this.http.post('/connect/token', body, { headers: this.authService.contentHeaders() })
            .subscribe(response => {
                // success, save the token to session storage
                this.authService.login(response.json());
                this.router.navigate(['/home']);
            },
            error => {
                // failed; TODO: add some nice toast / error handling
                this.toastrService.error(error.text());
                console.log(error.text());
            }
            );
    }
}
