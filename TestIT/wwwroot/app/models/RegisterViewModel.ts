import { Component } from '@angular/core';

export class RegisterViewModel {
    Email: string;
    Password: string;
    ConfirmPassword: string;

    constructor(email: string,
        password: string,
        confirmPassword: string) {
        this.Email = email;
        this.Password = password;
        this.ConfirmPassword = confirmPassword;
    }
}
