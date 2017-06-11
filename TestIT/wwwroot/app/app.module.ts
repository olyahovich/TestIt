import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgModule, enableProdMode } from '@angular/core';
import { BrowserModule, Title } from '@angular/platform-browser';
import { routing, routedComponents } from './app.routing';
import { APP_BASE_HREF, Location } from '@angular/common';
import { AppComponent } from './app.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { SampleDataService } from './services/sampleData.service';
import { AuthService } from './security/auth.service';
import { AuthGuard } from './security/auth-guard.service';
import { ToastrModule } from 'ngx-toastr';
import
    {
    MdButtonModule, MdListModule, MdButtonToggleModule, MdGridListModule, MdTabsModule, MdMenuModule, MdSliderModule,
    MdSelectModule, MdRadioModule, MdDatepickerModule, MdAutocompleteModule,
    MdCardModule, MdToolbarModule, MdSidenavModule, MdInputModule, MdSlideToggleModule, MdIconModule, MdCheckboxModule,
    MdTooltipModule, MdProgressBarModule, MdProgressSpinnerModule,
    MdChipsModule,
    } from '@angular/material';
import { FlexLayoutModule } from '@angular/flex-layout';
import './rxjs-operators';
import 'hammerjs';
// enableProdMode();

@NgModule({
    imports: [
        BrowserAnimationsModule, BrowserModule, FormsModule, HttpModule, ToastrModule.forRoot(), FlexLayoutModule,
        MdButtonModule, MdListModule, MdButtonToggleModule, MdGridListModule, MdTabsModule, MdMenuModule,
        MdSliderModule,
        MdSelectModule, MdRadioModule, MdDatepickerModule, MdAutocompleteModule, MdCardModule, MdToolbarModule,
        MdSidenavModule,
        MdInputModule, MdSlideToggleModule, MdIconModule, MdCheckboxModule, MdTooltipModule, MdProgressBarModule,
        MdProgressSpinnerModule, MdChipsModule, routing
    ],
    declarations: [AppComponent, routedComponents],
    providers: [
        SampleDataService,
        AuthService,
        AuthGuard, Title, { provide: APP_BASE_HREF, useValue: '/' }
    ],
    bootstrap: [AppComponent]
})
export class AppModule {
}