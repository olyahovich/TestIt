"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var router_1 = require("@angular/router");
var auth_guard_service_1 = require("./security/auth-guard.service");
var about_component_1 = require("./components/about.component");
var index_component_1 = require("./components/index.component");
var contact_component_1 = require("./components/contact.component");
var login_component_1 = require("./components/account/login.component");
var register_component_1 = require("./components/account/register.component");
var forgotPassword_component_1 = require("./components/account/forgotPassword.component");
var changePassword_component_1 = require("./components/account/changePassword.component");
var manage_component_1 = require("./components/account/manage.component");
var users_component_1 = require("./components/users.component");
var projects_component_1 = require("./components/projects.component");
var configurations_component_1 = require("./components/configurations.component");
var project_testRuns_component_1 = require("./components/project-testRuns.component");
var appRoutes = [
    { path: '', redirectTo: 'home', pathMatch: 'full' },
    { path: 'home', component: index_component_1.IndexComponent, data: { title: 'Home' }, canActivate: [auth_guard_service_1.AuthGuard] },
    { path: 'login', component: login_component_1.LoginComponent, data: { title: 'Login' } },
    { path: 'register', component: register_component_1.RegisterComponent, data: { title: 'Register' } },
    { path: 'forgotPassword', component: forgotPassword_component_1.ForgotPasswordCopmonent, data: { title: 'Reset Password' } },
    { path: 'changePassword', component: changePassword_component_1.ChangePasswordComponent, data: { title: 'Change Password' }, canActivate: [auth_guard_service_1.AuthGuard] },
    { path: 'testAction', component: contact_component_1.ContactComponent, data: { title: 'Contacts' }, canActivate: [auth_guard_service_1.AuthGuard] },
    { path: 'profile', component: manage_component_1.ManageComponent, data: { title: 'Manage Account' }, canActivate: [auth_guard_service_1.AuthGuard] },
    { path: 'home#about', component: about_component_1.AboutComponent, canActivate: [auth_guard_service_1.AuthGuard] },
    { path: 'users', component: users_component_1.UsersComponent, data: { title: 'Users' }, canActivate: [auth_guard_service_1.AuthGuard] },
    { path: 'projects', component: projects_component_1.ProjectsComponent, data: { title: 'Projects' }, canActivate: [auth_guard_service_1.AuthGuard] },
    { path: 'configurations', component: configurations_component_1.ConfigurationsComponent, data: { title: 'Configurations' }, canActivate: [auth_guard_service_1.AuthGuard] },
    { path: 'projects/:id/testRuns', component: project_testRuns_component_1.ProjectTestRunsComponent, data: { title: 'Project-Test Runs' }, canActivate: [auth_guard_service_1.AuthGuard] }
];
exports.routing = router_1.RouterModule.forRoot(appRoutes);
exports.routedComponents = [about_component_1.AboutComponent, index_component_1.IndexComponent, contact_component_1.ContactComponent, login_component_1.LoginComponent, register_component_1.RegisterComponent, changePassword_component_1.ChangePasswordComponent, manage_component_1.ManageComponent, users_component_1.UsersComponent,
    projects_component_1.ProjectsComponent, configurations_component_1.ConfigurationsComponent, project_testRuns_component_1.ProjectTestRunsComponent, forgotPassword_component_1.ForgotPasswordCopmonent];
//# sourceMappingURL=app.routing.js.map