import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';

import { AppComponent } from './components/app/app.component'
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { FetchDataComponent } from './components/fetchdata/fetchdata.component';
import { CounterComponent } from './components/counter/counter.component';
import { RecordComponent } from './components/record/record.component';
import { ModalComponent } from './components/modal/modal.component';
import { AuthGuard } from './guards/auth.guard';
import { AuthenticationService } from './services/auth.service';
import { StoreService } from './services/store.service';

export const sharedConfig: NgModule = {
    bootstrap: [AppComponent],
    declarations: [
        AppComponent,
        NavMenuComponent,
        CounterComponent,
        FetchDataComponent,
        RecordComponent,
        ModalComponent,
        HomeComponent
    ],
    imports: [
        FormsModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'login', pathMatch: 'full' },
            { path: 'login', component: HomeComponent },
            { path: 'fetch-data', component: FetchDataComponent },
            { path: '**', redirectTo: 'login' }
        ])
    ],
    providers: [
        AuthGuard,
        AuthenticationService,
        StoreService
    ]
};
