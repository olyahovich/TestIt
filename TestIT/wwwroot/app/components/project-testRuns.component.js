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
var ProjectTestRunsComponent = (function () {
    function ProjectTestRunsComponent(titleService) {
        this.titleService = titleService;
        this.columns = [
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
    ProjectTestRunsComponent.prototype.setTitle = function (newTitle) {
        this.titleService.setTitle(newTitle);
    };
    return ProjectTestRunsComponent;
}());
ProjectTestRunsComponent = __decorate([
    core_1.Component({
        selector: 'my-project-testruns',
        templateUrl: 'partial/projectTestRunsComponent'
    }),
    __metadata("design:paramtypes", [platform_browser_1.Title])
], ProjectTestRunsComponent);
exports.ProjectTestRunsComponent = ProjectTestRunsComponent;
//# sourceMappingURL=project-testRuns.component.js.map