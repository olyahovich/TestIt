import { Routes, RouterModule } from '@angular/router';
import { AuthGuard } from './security/auth-guard.service';

import { AboutComponent } from './components/about.component';
import { IndexComponent } from './components/index.component';
import { ContactComponent } from './components/contact.component';
import { LoginComponent } from './components/account/login.component';
import { RegisterComponent } from './components/account/register.component';
import { ForgotPasswordCopmonent } from './components/account/forgotPassword.component';
import { ChangePasswordComponent } from './components/account/changePassword.component';
import { ManageComponent } from './components/account/manage.component';
import { UsersComponent } from './components/users.component';
import { ProjectsComponent } from './components/projects.component';
import { ConfigurationsComponent } from './components/configurations.component';
import { ProjectTestRunsComponent } from './components/project-testRuns.component';


const appRoutes: Routes = [
    { path: '', redirectTo: 'home', pathMatch: 'full' },
    { path: 'home', component: IndexComponent, data: { title: 'Home' },  canActivate: [AuthGuard] },
    { path: 'login', component: LoginComponent, data: { title: 'Login' } },
    { path: 'register', component: RegisterComponent, data: { title: 'Register' } },
    { path: 'forgotPassword', component: ForgotPasswordCopmonent, data: { title: 'Reset Password' } },
    { path: 'changePassword', component: ChangePasswordComponent, data: { title: 'Change Password' }, canActivate: [AuthGuard] },
    { path: 'contact', component: ContactComponent, data: { title: 'Contacts' }, canActivate: [AuthGuard] },
    { path: 'profile', component: ManageComponent, data: { title: 'Manage Account' }, canActivate: [AuthGuard] },
    { path: 'home#about', component: AboutComponent, canActivate: [AuthGuard] },
    { path: 'users', component: UsersComponent, data: { title: 'Users' }, canActivate: [AuthGuard] },
    { path: 'projects', component: ProjectsComponent, data: { title: 'Projects' }, canActivate: [AuthGuard] },
    { path: 'configurations', component: ConfigurationsComponent, data: { title: 'Configurations' }, canActivate: [AuthGuard] },
    { path: 'projects/:id/testRuns', component: ProjectTestRunsComponent, data: { title: 'Project-Test Runs' }, canActivate: [AuthGuard] }
];

export const routing = RouterModule.forRoot(appRoutes);

export const routedComponents = [AboutComponent, IndexComponent, ContactComponent, LoginComponent, RegisterComponent, ChangePasswordComponent, ManageComponent, UsersComponent,
    ProjectsComponent, ConfigurationsComponent, ProjectTestRunsComponent, ForgotPasswordCopmonent];
