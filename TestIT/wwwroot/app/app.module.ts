import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgModule, enableProdMode } from '@angular/core';
import { BrowserModule, Title } from '@angular/platform-browser';
import { routing, routedComponents } from './app.routing';
import { APP_BASE_HREF, Location } from '@angular/common';
import { AppComponent } from './app.component';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { AuthService } from './security/auth.service';
import { AuthGuard } from './security/auth-guard.service';
import { ToastrModule } from 'ngx-toastr';
import
    {
        CdkDataTableModule,
        FullscreenOverlayContainer,
        MdAutocompleteModule,
        MdButtonModule,
        MdButtonToggleModule,
        MdCardModule,
        MdCheckboxModule,
        MdChipsModule,
        MdCoreModule,
        MdDatepickerModule,
        MdDialogModule,
        MdExpansionModule,
        MdGridListModule,
        MdIconModule,
        MdInputModule,
        MdListModule,
        MdMenuModule,
        MdNativeDateModule,
        MdProgressBarModule,
        MdProgressSpinnerModule,
        MdRadioModule,
        MdRippleModule,
        MdSelectModule,
        MdSidenavModule,
        MdSliderModule,
        MdSlideToggleModule,
        MdSnackBarModule,
        MdTabsModule,
        MdToolbarModule,
        MdTooltipModule,
        OverlayContainer
    } from '@angular/material';
import { FlexLayoutModule } from '@angular/flex-layout';
import './rxjs-operators';
import 'hammerjs';
import 'chartjs';
import { StoreModule } from '@ngrx/store';
import { EffectsModule } from '@ngrx/effects';
import { StoreDevtoolsModule } from '@ngrx/store-devtools';
// enableProdMode();

@NgModule({
    imports: [
        BrowserAnimationsModule, BrowserModule, ReactiveFormsModule, HttpModule, ToastrModule.forRoot({ timeOut: 5000 }), FlexLayoutModule,
        CdkDataTableModule,
        FullscreenOverlayContainer,
        MdAutocompleteModule,
        MdButtonModule,
        MdButtonToggleModule,
        MdCardModule,
        MdCheckboxModule,
        MdChipsModule,
        MdCoreModule,
        MdDatepickerModule,
        MdDialogModule,
        MdExpansionModule,
        MdGridListModule,
        MdIconModule,
        MdInputModule,
        MdListModule,
        MdMenuModule,
        MdNativeDateModule,
        MdProgressBarModule,
        MdProgressSpinnerModule,
        MdRadioModule,
        MdRippleModule,
        MdSelectModule,
        MdSidenavModule,
        MdSliderModule,
        MdSlideToggleModule,
        MdSnackBarModule,
        MdTabsModule,
        MdToolbarModule,
        MdTooltipModule,
        OverlayContainer,
        routing
    ],
    declarations: [AppComponent, routedComponents],
    providers: [
        AuthService,
        AuthGuard, Title, { provide: APP_BASE_HREF, useValue: '/' }
    ],
    bootstrap: [AppComponent]
})
export class AppModule {
}