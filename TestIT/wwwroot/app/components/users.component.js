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
require("rxjs/add/operator/map");
require("rxjs/add/operator/catch");
var UsersComponent = (function () {
    function UsersComponent(titleService) {
        this.titleService = titleService;
        this.rows = [
            { firstname: 'Kevin', lastname: 'Harvi', email: 'kevin.harvi@example.com', role: "Developer", actions: "" },
            { firstname: 'Richard', lastname: 'Duck', email: 'Richard.Duck@example.com', role: "QA Engineer", actions: "" },
            { firstname: 'John', lastname: 'Molowers', email: 'John.Molowers@example.com', role: "Project Manager", actions: "" },
            { firstname: 'Rid', lastname: 'Swendsons', email: 'Rid.Swendsons@example.com', role: "Senior Developer", actions: "" },
            { firstname: 'Scott', lastname: 'Henrikson', email: 'Scott.Henrikson@example.com', role: "BA", actions: "" },
            { firstname: 'Jerom', lastname: 'Owen', email: 'Jerom.Owen@example.com', role: "Admin", actions: "" },
            { firstname: 'Lilly', lastname: 'Loptierda', email: 'Lilly.Loptierda@example.com', role: "Project Integrator", actions: "" }
        ];
        this.columns = [
            { name: 'First Name' },
            { name: 'Last Name' },
            { name: 'Email' },
            { name: 'Role' },
            { name: 'Actions' }
        ];
    }
    UsersComponent.prototype.setTitle = function (newTitle) {
        this.titleService.setTitle(newTitle);
    };
    return UsersComponent;
}());
UsersComponent = __decorate([
    core_1.Component({
        selector: 'my-users',
        templateUrl: 'partial/usersComponent'
    }),
    __metadata("design:paramtypes", [platform_browser_1.Title])
], UsersComponent);
exports.UsersComponent = UsersComponent;
//# sourceMappingURL=users.component.js.map