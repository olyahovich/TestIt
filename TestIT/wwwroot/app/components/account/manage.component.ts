import { Component } from '@angular/core';
import { Title }     from '@angular/platform-browser';

@Component({
    selector: 'my-user-profile',
   templateUrl: 'partial/profileComponent'
})

export class ManageComponent {
    
    constructor(private titleService: Title) { }

    setTitle(newTitle: string) {
        this.titleService.setTitle(newTitle);
    }
}
