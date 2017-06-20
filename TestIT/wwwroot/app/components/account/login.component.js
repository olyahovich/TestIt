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
var auth_service_1 = require("./../../security/auth.service");
var LoginViewModel_1 = require("./../../models/LoginViewModel");
var ngx_toastr_1 = require("ngx-toastr");
var routing_service_1 = require("./../../services/routing.service");
var LoginComponent = (function () {
    function LoginComponent(router, titleService, http, authService, fb, toastrService) {
        this.router = router;
        this.titleService = titleService;
        this.http = http;
        this.authService = authService;
        this.fb = fb;
        this.toastrService = toastrService;
        this.validationMessages = {
            'email': {
                'required': 'Email is required.',
                'minlength': 'Email must be at least 4 characters long.',
                'email': 'Email format is invalid'
            },
            'password': {
                'required': 'Password is required.',
                'minlength': 'Password must be at least 6 characters long.'
            }
        };
        this.formErrors = {
            'email': '',
            'password': ''
        };
        if (authService.loggedIn()) {
            router.navigateToHome();
        }
    }
    LoginComponent.prototype.ngOnInit = function () {
        this.loginViewModel = new LoginViewModel_1.LoginViewModel('', '');
        this.createForm(this.loginViewModel);
    };
    LoginComponent.prototype.createForm = function (login) {
        var _this = this;
        this.loginForm = this.fb.group({
            email: [login.Email, forms_1.Validators.compose([forms_1.Validators.required, forms_1.Validators.email,
                    forms_1.Validators.minLength(6)])],
            password: [login.Password, forms_1.Validators.compose([forms_1.Validators.required, forms_1.Validators.minLength(6)])],
            rememberMe: [login.RememberMe]
        });
        this.loginForm.valueChanges
            .subscribe(function (data) { return _this.onValueChanged(data); });
        this.onValueChanged(); // (re)set validation messages now
    };
    LoginComponent.prototype.onValueChanged = function (data) {
        if (!this.loginForm) {
            return;
        }
        var form = this.loginForm;
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
    LoginComponent.prototype.setTitle = function (newTitle) {
        this.titleService.setTitle(newTitle);
    };
    LoginComponent.prototype.clearPassword = function (event) {
        this.loginForm.controls['password'].reset();
        this.loginForm.controls['password'].clearValidators();
    };
    LoginComponent.prototype.clearEmail = function (event) {
        this.loginForm.controls['email'].reset();
        this.loginForm.controls['email'].clearValidators();
    };
    // post the user's login details to server, if authenticated token is returned, then token is saved to session storage
    LoginComponent.prototype.login = function (event) {
        var _this = this;
        event.preventDefault();
        var body = 'username=' + this.loginForm.controls['email'].value + '&password=' + this.loginForm.controls['password'].value + '&grant_type=password';
        this.http.post('/connect/token', body, { headers: this.authService.contentHeaders() })
            .subscribe(function (response) {
            // success, save the token to session or local storage depends on remeber me checkbox value
            _this.authService.login(response.json(), _this.loginForm.controls['rememberMe'].value);
            _this.toastrService.success('You have been logged in successfully.');
            _this.loginForm.reset();
            _this.router.navigateToHome();
        }, function (error) {
            // failed; TODO: add some nice toast / error handling
            _this.toastrService.error(error.json().error_description);
            _this.loginForm.controls['password'].reset();
            _this.loginForm.controls['password'].clearValidators();
            console.log(error.text());
        });
    };
    return LoginComponent;
}());
LoginComponent = __decorate([
    core_1.Component({
        selector: 'login',
        templateUrl: 'partial/loginComponent'
    }),
    __metadata("design:paramtypes", [routing_service_1.RoutingService,
        platform_browser_1.Title,
        http_1.Http,
        auth_service_1.AuthService,
        forms_1.FormBuilder,
        ngx_toastr_1.ToastrService])
], LoginComponent);
exports.LoginComponent = LoginComponent;
//# sourceMappingURL=login.component.js.map