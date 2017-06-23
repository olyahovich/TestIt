import { Component, OnInit } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { AbstractControl, FormBuilder, FormGroup, Validators, FormArray, FormControl, ValidatorFn } from '@angular/forms';
import { Http } from '@angular/http';
import { TestItViewModel } from './../models/TestItViewModel';
import { ToastrService } from 'ngx-toastr';
import { RoutingService } from './../services/routing.service';
import { AuthService } from './../security/auth.service';

@Component({
    selector: 'my-contact',
   templateUrl: 'partial/contactComponent'
})


export class ContactComponent implements OnInit {
    testItViewModel: TestItViewModel;
    testItForm: FormGroup;

    validationMessages = {
        'pathToFile': {
            'required': 'Path to file is required'
        },
        'argument': {
            'required': 'File Name is required.'
        }
    };

    formErrors = {
        'email': '',
        'password': ''
    };

    constructor(public router: RoutingService,
        private titleService: Title,
        public http: Http,
        private authService: AuthService,
        private fb: FormBuilder,
        private toastrService: ToastrService) {
    }

    ngOnInit() {
        this.testItViewModel = new TestItViewModel('', '');
        this.createForm(this.testItViewModel);
    }

    createForm(testit: TestItViewModel) {
        this.testItForm = this.fb.group({
            pathtofile: [testit.PathToFile, Validators.required],
            filename: [testit.Argument, Validators.required]
        });
        this.testItForm.valueChanges
            .subscribe(data => this.onValueChanged(data));

        this.onValueChanged(); // (re)set validation messages now
    }

    onValueChanged(data?: any) {
        if (!this.testItForm) { return; }
        const form = this.testItForm;

        for (const field in this.formErrors) {
            // clear previous error message (if any)
            this.formErrors[field] = "";
            const control = form.get(field);

            if (control && control.dirty && !control.valid) {
                const messages = this.validationMessages[field];
                for (const key in control.errors) {
                    this.formErrors[field] += messages[key] + ' ';
                    break;
                }
            }
        }
    }

    public setTitle(newTitle: string) {
        this.titleService.setTitle(newTitle);
    }


    // post the user's login details to server, if authenticated token is returned, then token is saved to session storage
    testIt(event: Event): void {
        event.preventDefault();
        let body = 'pathtofile=' + this.testItForm.controls['pathtofile'].value + '&argument=' + this.testItForm.controls['filename'].value;

        this.http.post('/api/values', body, { headers: this.authService.contentHeaders() })
            .subscribe(response => {
                this.toastrService.success('Your test has been sent to test enviornment.');
            },
            error => {
                // failed; TODO: add some nice toast / error handling
                this.toastrService.error(error.json().error_description);
                this.testItForm.controls['pathtofile'].reset();
                this.testItForm.controls['pathtofile'].clearValidators();
                this.testItForm.controls['argument'].reset();
                this.testItForm.controls['argument'].clearValidators();
                this.toastrService.error(error.text());
                console.log(error.text());
            }
            );
    }

    cancel(event: Event): void {
        event.preventDefault();
        this.testItForm.controls['pathtofile'].reset();
        this.testItForm.controls['argument'].clearValidators();
        this.router.navigateToHome();
    }
}
