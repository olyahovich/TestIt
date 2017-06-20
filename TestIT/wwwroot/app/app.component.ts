import { Component } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { Http, Response, Headers } from '@angular/http';
import { AuthService } from './security/auth.service';
import { RoutingService } from "./services/routing.service";

@Component({
    selector: 'testIt-app',
    templateUrl: 'partial/appComponent'
})

export class AppComponent {
    angularClientSideData = 'Angular';

    public constructor(private routingService: RoutingService, private titleService: Title, private http: Http, private authService: AuthService) { }

    // wrapper to the Angular title service.
    public setTitle(newTitle: string) {
        this.titleService.setTitle(newTitle);
    }

    // provide local page the user's logged in status (do we have a token or not)
    public isLoggedIn(): boolean {
        return this.authService.loggedIn();
    }

    // tell the server that the user wants to logout; clears token from server, then calls auth.service to clear token locally in browser
    public logout() {
        this.http.get('connect/logout', { headers: this.authService.authJsonHeaders() })
            .subscribe(response => {
                console.log(response);
                // clear token in browser
                this.authService.logout();
                // return to 'home' page
                this.routingService.navigateToSignIn();
            },
            error => {
                // failed; TODO: add some nice toast / error handling
                alert(error.text());
                console.log(error.text());
            }
            );
    }
}