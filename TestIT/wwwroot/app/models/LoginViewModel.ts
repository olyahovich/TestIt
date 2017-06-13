import { Component } from '@angular/core';

export class LoginViewModel {
    Email: string;
    Password: string;
    RememberMe: boolean;

    constructor(email: string,
        password: string) {
        this.Email = email;
        this.Password = password;
        this.RememberMe = false;
    }
}
