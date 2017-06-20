import { Component, OnInit } from '@angular/core';
import { ViewModelResponse } from './../models/viewModelResponse';
import { ErrorResponse } from './../models/errorResponse';
import { ToastrService } from 'ngx-toastr';
import { Title } from '@angular/platform-browser';
import { Observable } from 'rxjs/Rx';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';

@Component({
    selector: 'my-configurations',
    templateUrl: 'partial/configurationsComponent'
})

export class ConfigurationsComponent {
    constructor(private titleService: Title) { }

    setTitle(newTitle: string) {
        this.titleService.setTitle(newTitle);
    }

    columns = [
        { prop: 'Name' },
        { name: 'Status' },
        { name: 'Operation Systme' },
        { name: 'IPv4' },
        { name: 'IPv6' },
        { name: 'Host' },
        { name: 'Port' },
        { name: 'Actions' }
    ];
}
