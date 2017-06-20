import { Component, OnInit } from '@angular/core';
import { ViewModelResponse } from './../models/viewModelResponse';
import { ErrorResponse } from './../models/errorResponse';
import { ToastrService } from 'ngx-toastr';
import { Title } from '@angular/platform-browser';
import { Observable } from 'rxjs/Rx';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';

@Component({
    selector: 'my-project-testruns',
    templateUrl: 'partial/projectTestRunsComponent'
})

export class ProjectTestRunsComponent {
    constructor(private titleService: Title) { }

    setTitle(newTitle: string) {
        this.titleService.setTitle(newTitle);
    }

    columns = [
        { name: 'Title' },
        { name: 'Status' },
        { name: 'Email' },
        { name: 'File Name' },
        { name: 'Enviornment' },
        { name: 'Assigned User' },
        { name: 'Test Action' },
        { name: 'Test Run Result' },
        { name: 'Actions' }
    ];
}
