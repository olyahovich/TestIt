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
var RegisterViewModel_1 = require("./../../models/RegisterViewModel");
var ngx_toastr_1 = require("ngx-toastr");
var RegisterComponent = (function () {
    function RegisterComponent(routingService, titleService, http, authService, fb, toastrService) {
        this.routingService = routingService;
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
            },
            'confirmPassword': {
                'required': 'Password is required.',
                'minlength': 'Password must be at least 6 characters long.'
            }
        };
        this.formErrors = {
            'email': '',
            'password': '',
            'confirmPassword': ''
        };
        if (authService.loggedIn()) {
            routingService.navigateToHome();
        }
    }
    RegisterComponent.prototype.ngOnInit = function () {
        this.registerViewModel = new RegisterViewModel_1.RegisterViewModel('', '', '');
        this.createForm(this.registerViewModel);
    };
    RegisterComponent.prototype.createForm = function (register) {
        var _this = this;
        this.registerForm = this.fb.group({
            email: [register.Email, forms_1.Validators.compose([forms_1.Validators.required, forms_1.Validators.email])],
            password: [register.Password, forms_1.Validators.compose([forms_1.Validators.required, forms_1.Validators.minLength(6)])],
            confirmPassword: [register.ConfirmPassword, forms_1.Validators.compose([forms_1.Validators.required, forms_1.Validators.minLength(6)])]
        }, { validator: registerFormValidator });
        this.registerForm.valueChanges
            .subscribe(function (data) { return _this.onValueChanged(data); });
        this.onValueChanged(); // (re)set validation messages now
    };
    RegisterComponent.prototype.onValueChanged = function (data) {
        if (!this.registerForm) {
            return;
        }
        var form = this.registerForm;
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
    RegisterComponent.prototype.setTitle = function (newTitle) {
        this.titleService.setTitle(newTitle);
    };
    RegisterComponent.prototype.clearPassword = function (event) {
        this.registerForm.controls['password'].reset();
        this.registerForm.controls['password'].clearValidators();
    };
    RegisterComponent.prototype.clearEmail = function (event) {
        this.registerForm.controls['email'].reset();
        this.registerForm.controls['email'].clearValidators();
    };
    RegisterComponent.prototype.clearConfirmPassword = function (event) {
        this.registerForm.controls['confirmPassword'].reset();
        this.registerForm.controls['confirmPassword'].clearValidators();
    };
    RegisterComponent.prototype.register = function (event) {
        var _this = this;
        event.preventDefault();
        var body = { 'email': this.registerForm.controls['email'].value, 'password': this.registerForm.controls['password'].value, 'confirmPassword': this.registerForm.controls['confirmPassword'].value };
        this.http.post('/Account/Register', JSON.stringify(body), { headers: this.authService.jsonHeaders() })
            .subscribe(function (response) {
            if (response.status == 200) {
                _this.routingService.navigateToSignIn();
                _this.toastrService.success('Your Account has been Successfully Registered');
            }
            else {
                _this.toastrService.error(response.json().description);
                console.log(response.json().error);
            }
        }, function (error) {
            // TODO: parse error messages, generate toast popups
            // {"Email":["The Email field is required.","The Email field is not a valid e-mail address."],"Password":["The Password field is required.","The Password must be at least 6 characters long."]}
            _this.registerForm.controls['password'].reset();
            _this.registerForm.controls['password'].clearValidators();
            _this.registerForm.controls['confirmPassword'].reset();
            _this.registerForm.controls['confirmPassword'].clearValidators();
            _this.toastrService.error(error.text());
            console.log(error.text());
        });
    };
    return RegisterComponent;
}());
RegisterComponent = __decorate([
    core_1.Component({
        selector: 'register',
        templateUrl: 'partial/registerComponent'
    }),
    __metadata("design:paramtypes", [routing_service_1.RoutingService,
        platform_browser_1.Title,
        http_1.Http,
        auth_service_1.AuthService,
        forms_1.FormBuilder,
        ngx_toastr_1.ToastrService])
], RegisterComponent);
exports.RegisterComponent = RegisterComponent;
function registerFormValidator(fg) {
    //TODO: check if email is already taken
    //Password match validation
    if (fg.get('password').value !== fg.get('confirmPassword').value)
        return { 'passwordmismatch': true };
    return null;
}
//# sourceMappingURL=register.component.js.map