import { Component } from '@angular/core';

export class ForgotPasswordViewModel {
    Email: string;

    constructor(email: string) {
        this.Email = email;
    }
}
