import { Routes, RouterModule } from '@angular/router';
import { AuthGuard } from './security/auth-guard.service';

import { AboutComponent } from './components/about.component';
import { IndexComponent } from './components/index.component';
import { ContactComponent } from './components/contact.component';
import { LoginComponent } from './components/account/login.component';
import { RegisterComponent } from './components/account/register.component';
import { ChangePasswordComponent } from './components/account/changePassword.component';
import { ManageComponent } from './components/account/manage.component';

const appRoutes: Routes = [
    { path: '', redirectTo: 'home', pathMatch: 'full' },
    { path: 'home', component: IndexComponent, data: { title: 'Home' },  canActivate: [AuthGuard] },
    { path: 'login', component: LoginComponent, data: { title: 'Login' } },
    { path: 'register', component: RegisterComponent, data: { title: 'Register' } },
    { path: 'changePassword', component: ChangePasswordComponent, data: { title: 'Change Password' }, canActivate: [AuthGuard] },
    { path: 'manage', component: ManageComponent, data: { title: 'Manage Account' }, canActivate: [AuthGuard] },
    { path: 'about', component: AboutComponent, data: { title: 'About' }, canActivate: [AuthGuard] },
    { path: 'contact', component: ContactComponent, data: { title: 'Contact' },  canActivate: [AuthGuard] }
];

export const routing = RouterModule.forRoot(appRoutes);

export const routedComponents = [AboutComponent, IndexComponent, ContactComponent, LoginComponent, RegisterComponent, ChangePasswordComponent, ManageComponent];
