import { Component, OnInit } from '@angular/core';
import { ViewModelResponse } from './../models/viewModelResponse';
import { ErrorResponse } from './../models/errorResponse';
import { ToastrService } from 'ngx-toastr';
import { Title } from '@angular/platform-browser';
import { Observable } from 'rxjs/Rx';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';

@Component({
    selector: 'my-users',
   templateUrl: 'partial/usersComponent'
})

export class UsersComponent {
    constructor(private titleService: Title) { }

    setTitle(newTitle: string) {
        this.titleService.setTitle(newTitle);
    }
    rows = [
        { firstname: 'Kevin', lastname: 'Harvi', email: 'kevin.harvi@example.com', role: "Developer", actions: "" },
        { firstname: 'Richard', lastname: 'Duck', email: 'Richard.Duck@example.com', role: "QA Engineer", actions: "" },
        { firstname: 'John', lastname: 'Molowers', email: 'John.Molowers@example.com', role: "Project Manager", actions: "" },
        { firstname: 'Rid', lastname: 'Swendsons', email: 'Rid.Swendsons@example.com', role: "Senior Developer", actions: "" },
        { firstname: 'Scott', lastname: 'Henrikson', email: 'Scott.Henrikson@example.com', role: "BA", actions: "" },
        { firstname: 'Jerom', lastname: 'Owen', email: 'Jerom.Owen@example.com', role: "Admin", actions: "" },
        { firstname: 'Lilly', lastname: 'Loptierda', email: 'Lilly.Loptierda@example.com', role: "Project Integrator", actions: "" }
    ];
    columns = [
        { name: 'First Name' },
        { name: 'Last Name' },
        { name: 'Email' },
        { name: 'Role' },
        { name: 'Actions' }
    ];
}
