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
var routing_service_1 = require("./../../services/routing.service");
var forms_1 = require("@angular/forms");
var http_1 = require("@angular/http");
var auth_service_1 = require("./../../security/auth.service");
var ForgotPasswordViewModel_1 = require("./../../models/ForgotPasswordViewModel");
var ngx_toastr_1 = require("ngx-toastr");
var ForgotPasswordCopmonent = (function () {
    function ForgotPasswordCopmonent(routingService, titleService, http, authService, fb, toastrService) {
        this.routingService = routingService;
        this.titleService = titleService;
        this.http = http;
        this.authService = authService;
        this.fb = fb;
        this.toastrService = toastrService;
        this.validationMessages = {
            'email': {
                'required': 'Email is required.',
                'email': 'Email format is invalid'
            }
        };
        this.formErrors = {
            'email': ''
        };
        if (authService.loggedIn()) {
            routingService.navigateToHome();
        }
    }
    ForgotPasswordCopmonent.prototype.ngOnInit = function () {
        this.forgotPasswordViewModel = new ForgotPasswordViewModel_1.ForgotPasswordViewModel('');
        this.createForm(this.forgotPasswordViewModel);
    };
    ForgotPasswordCopmonent.prototype.createForm = function (forgotPassword) {
        var _this = this;
        this.forgotPasswordForm = this.fb.group({
            email: [forgotPassword.Email, forms_1.Validators.compose([forms_1.Validators.required, forms_1.Validators.email])]
        });
        this.forgotPasswordForm.valueChanges
            .subscribe(function (data) { return _this.onValueChanged(data); });
        this.onValueChanged(); // (re)set validation messages now
    };
    ForgotPasswordCopmonent.prototype.onValueChanged = function (data) {
        if (!this.forgotPasswordForm) {
            return;
        }
        var form = this.forgotPasswordForm;
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
    ForgotPasswordCopmonent.prototype.setTitle = function (newTitle) {
        this.titleService.setTitle(newTitle);
    };
    ForgotPasswordCopmonent.prototype.clearEmail = function (event) {
        this.forgotPasswordForm.controls['email'].reset();
        this.forgotPasswordForm.controls['email'].clearValidators();
    };
    ForgotPasswordCopmonent.prototype.forgotPassword = function (event) {
        var _this = this;
        event.preventDefault();
        var body = { 'email': this.forgotPasswordForm.controls['email'].value };
        this.http.post('/Account/ForgotPassword', JSON.stringify(body), { headers: this.authService.jsonHeaders() })
            .subscribe(function (response) {
            if (response.status == 200) {
                _this.forgotPasswordForm.reset();
                _this.routingService.navigateToSignIn();
                _this.toastrService.success('Email with Reset Password link has been sent');
            }
            else {
                _this.toastrService.error(response.json().description);
                console.log(response.json().error);
            }
        }, function (error) {
            _this.toastrService.error(error.text());
            console.log(error.text());
        });
    };
    return ForgotPasswordCopmonent;
}());
ForgotPasswordCopmonent = __decorate([
    core_1.Component({
        selector: 'forgotPassword',
        templateUrl: 'partial/forgotPasswordComponent'
    }),
    __metadata("design:paramtypes", [routing_service_1.RoutingService,
        platform_browser_1.Title,
        http_1.Http,
        auth_service_1.AuthService,
        forms_1.FormBuilder,
        ngx_toastr_1.ToastrService])
], ForgotPasswordCopmonent);
exports.ForgotPasswordCopmonent = ForgotPasswordCopmonent;
//# sourceMappingURL=forgotPassword.component.js.map