"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = require("@angular/core");
var platform_browser_1 = require("@angular/platform-browser");
var forms_1 = require("@angular/forms");
var http_1 = require("@angular/http");
var TestItViewModel_1 = require("./../models/TestItViewModel");
var ngx_toastr_1 = require("ngx-toastr");
var routing_service_1 = require("./../services/routing.service");
var auth_service_1 = require("./../security/auth.service");
var ContactComponent = (function () {
    function ContactComponent(router, titleService, http, authService, fb, toastrService) {
        this.router = router;
        this.titleService = titleService;
        this.http = http;
        this.authService = authService;
        this.fb = fb;
        this.toastrService = toastrService;
        this.validationMessages = {
            'pathToFile': {
                'required': 'Path to file is required'
            },
            'argument': {
                'required': 'File Name is required.'
            }
        };
        this.formErrors = {
            'email': '',
            'password': ''
        };
    }
    ContactComponent.prototype.ngOnInit = function () {
        this.testItViewModel = new TestItViewModel_1.TestItViewModel('', '');
        this.createForm(this.testItViewModel);
    };
    ContactComponent.prototype.createForm = function (testit) {
        var _this = this;
        this.testItForm = this.fb.group({
            pathtofile: [testit.PathToFile, forms_1.Validators.required],
            filename: [testit.Argument, forms_1.Validators.required]
        });
        this.testItForm.valueChanges
            .subscribe(function (data) { return _this.onValueChanged(data); });
        this.onValueChanged(); // (re)set validation messages now
    };
    ContactComponent.prototype.onValueChanged = function (data) {
        if (!this.testItForm) {
            return;
        }
        var form = this.testItForm;
        for (var field in this.formErrors) {
            // clear previous error message (if any)
            this.formErrors[field] = "";
            var control = form.get(field);
            if (control && control.dirty && !control.valid) {
                var messages = this.validationMessages[field];
                for (var key in control.errors) {
                    this.formErrors[field] += messages[key] + ' ';
                    break;
                }
            }
        }
    };
    ContactComponent.prototype.setTitle = function (newTitle) {
        this.titleService.setTitle(newTitle);
    };
    // post the user's login details to server, if authenticated token is returned, then token is saved to session storage
    ContactComponent.prototype.testIt = function (event) {
        var _this = this;
        event.preventDefault();
        var body = 'pathtofile=' + this.testItForm.controls['pathtofile'].value + '&argument=' + this.testItForm.controls['filename'].value;
        this.http.post('/api/values', body, { headers: this.authService.contentHeaders() })
            .subscribe(function (response) {
            _this.toastrService.success('Your test has been sent to test enviornment.');
        }, function (error) {
            // failed; TODO: add some nice toast / error handling
            _this.toastrService.error(error.json().error_description);
            _this.testItForm.controls['pathtofile'].reset();
            _this.testItForm.controls['pathtofile'].clearValidators();
            _this.testItForm.controls['argument'].reset();
            _this.testItForm.controls['argument'].clearValidators();
            _this.toastrService.error(error.text());
            console.log(error.text());
        });
    };
    ContactComponent.prototype.cancel = function (event) {
        event.preventDefault();
        this.testItForm.controls['pathtofile'].reset();
        this.testItForm.controls['argument'].clearValidators();
        this.router.navigateToHome();
    };
    return ContactComponent;
}());
ContactComponent = __decorate([
    core_1.Component({
        selector: 'my-contact',
        templateUrl: 'partial/contactComponent'
    }),
    __metadata("design:paramtypes", [routing_service_1.RoutingService,
        platform_browser_1.Title,
        http_1.Http,
        auth_service_1.AuthService,
        forms_1.FormBuilder,
        ngx_toastr_1.ToastrService])
], ContactComponent);
exports.ContactComponent = ContactComponent;
//# sourceMappingURL=contact.component.js.map