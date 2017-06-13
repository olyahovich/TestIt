import { Component, OnInit } from '@angular/core';
import { ViewModelResponse } from './../models/viewModelResponse';
import { ErrorResponse } from './../models/errorResponse';
import { ToastrService } from 'ngx-toastr';
import { Observable } from 'rxjs/Rx';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';

@Component({
    selector: 'my-about',
   templateUrl: 'partial/aboutComponent'
})

export class AboutComponent {
}
