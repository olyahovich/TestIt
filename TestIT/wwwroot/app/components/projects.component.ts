import { Component, OnInit } from '@angular/core';
import { ViewModelResponse } from './../models/viewModelResponse';
import { ErrorResponse } from './../models/errorResponse';
import { ToastrService } from 'ngx-toastr';
import { Title } from '@angular/platform-browser';
import { Observable } from 'rxjs/Rx';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';

@Component({
    selector: 'my-projects',
   templateUrl: 'partial/projectsComponent'
})

export class ProjectsComponent {
    constructor(private titleService: Title) { }

    setTitle(newTitle: string) {
        this.titleService.setTitle(newTitle);
    }

    columns = [
        { prop: 'Project Type' },
        { name: 'Project Name' },
        { name: 'Status' },
        { name: 'Total Runs' },
        { name: 'Active Runs' },
        { name: 'Passed Runs' },
        { name: 'Failed Runs' },
        { name: 'Team Size' },
        { name: 'Actions' }
    ];
}
