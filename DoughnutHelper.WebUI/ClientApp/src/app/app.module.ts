import {BrowserModule} from '@angular/platform-browser';
import {NgModule} from '@angular/core';
import {FormsModule} from '@angular/forms';
import {HttpClientModule} from '@angular/common/http';
import {RouterModule} from '@angular/router';

import {AppComponent} from './app.component';
import {NavMenuComponent} from './components/nav-menu/nav-menu.component';
import {HomeComponent} from './components/home/home.component';
import {StatsComponent} from './components/stats/stats.component';
import {RegisterComponent} from './components/register/register.component';
import {AuthGuardService} from './services/auth-guard.service';
import {TreeComponent} from './components/tree/tree.component';
import {TreeNodeComponent} from './components/tree-node/tree-node.component';

@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        HomeComponent,
        StatsComponent,
        RegisterComponent,
        TreeComponent,
        TreeNodeComponent
    ],
    imports: [
        BrowserModule.withServerTransition({appId: 'ng-cli-universal'}),
        HttpClientModule,
        FormsModule,
        HttpClientModule,
        RouterModule.forRoot([
            {path: '', component: HomeComponent, pathMatch: 'full', canActivate: [AuthGuardService]},
            {path: 'register', component: RegisterComponent},
            {path: 'stats', component: StatsComponent},
        ])
    ],
    providers: [],
    bootstrap: [AppComponent]
})
export class AppModule {
}
