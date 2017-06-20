"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
Object.defineProperty(exports, "__esModule", { value: true });
var animations_1 = require("@angular/platform-browser/animations");
var core_1 = require("@angular/core");
var platform_browser_1 = require("@angular/platform-browser");
var app_routing_1 = require("./app.routing");
var common_1 = require("@angular/common");
var app_component_1 = require("./app.component");
var forms_1 = require("@angular/forms");
var http_1 = require("@angular/http");
var auth_service_1 = require("./security/auth.service");
var auth_guard_service_1 = require("./security/auth-guard.service");
var notifications_service_1 = require("./services/notifications.service");
var routing_service_1 = require("./services/routing.service");
var ngx_toastr_1 = require("ngx-toastr");
var ngx_datatable_1 = require("@swimlane/ngx-datatable");
var material_1 = require("@angular/material");
var flex_layout_1 = require("@angular/flex-layout");
require("./rxjs-operators");
require("hammerjs");
require("chartjs");
// enableProdMode();
var AppModule = (function () {
    function AppModule() {
    }
    return AppModule;
}());
AppModule = __decorate([
    core_1.NgModule({
        imports: [
            animations_1.BrowserAnimationsModule, platform_browser_1.BrowserModule, forms_1.ReactiveFormsModule, http_1.HttpModule, ngx_toastr_1.ToastrModule.forRoot({ timeOut: 5000 }), flex_layout_1.FlexLayoutModule,
            material_1.CdkDataTableModule,
            material_1.MdAutocompleteModule,
            material_1.MdButtonModule,
            material_1.MdButtonToggleModule,
            material_1.MdCardModule,
            material_1.MdCheckboxModule,
            material_1.MdChipsModule,
            material_1.MdCoreModule,
            material_1.MdDatepickerModule,
            material_1.MdDialogModule,
            material_1.MdExpansionModule,
            material_1.MdGridListModule,
            material_1.MdIconModule,
            material_1.MdInputModule,
            material_1.MdListModule,
            material_1.MdMenuModule,
            material_1.MdNativeDateModule,
            material_1.MdProgressBarModule,
            material_1.MdProgressSpinnerModule,
            material_1.MdRadioModule,
            material_1.MdRippleModule,
            material_1.MdSelectModule,
            material_1.MdSidenavModule,
            material_1.MdSliderModule,
            material_1.MdSlideToggleModule,
            material_1.MdSnackBarModule,
            material_1.MdTabsModule,
            material_1.MdToolbarModule,
            material_1.MdTooltipModule,
            ngx_datatable_1.NgxDatatableModule,
            app_routing_1.routing
        ],
        declarations: [app_component_1.AppComponent, app_routing_1.routedComponents],
        providers: [
            auth_service_1.AuthService,
            notifications_service_1.NotificationService,
            routing_service_1.RoutingService,
            auth_guard_service_1.AuthGuard, platform_browser_1.Title, { provide: common_1.APP_BASE_HREF, useValue: '/' }
        ],
        bootstrap: [app_component_1.AppComponent]
    })
], AppModule);
exports.AppModule = AppModule;
//# sourceMappingURL=app.module.js.map