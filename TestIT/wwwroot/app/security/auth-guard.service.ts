import { Injectable } from '@angular/core';
import { RoutingService } from './../services/routing.service';
import { CanActivate } from '@angular/router';
import { AuthService } from './auth.service';

@Injectable()
export class AuthGuard implements CanActivate {

    constructor(private authService: AuthService, private routingService: RoutingService) { }

    canActivate() {
        if (!this.authService.loggedIn()) {
            this.routingService.navigateToSignIn();
            return false;
        }
        return true;
    }
}
