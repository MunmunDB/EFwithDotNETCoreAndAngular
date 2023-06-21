import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CompFetchDataComponent } from './company/comp-fetch-data.component';
import { AddCompanyComponent } from './add-company/add-company.component';
import { CompanyService } from './Service/company.service';

import { ReactiveFormsModule } from '@angular/forms';



@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CompFetchDataComponent,
    AddCompanyComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'comp-fetch-data', component: CompFetchDataComponent },
      { path: 'add-company', component: AddCompanyComponent },
    ])
  ],
  providers: [CompanyService],
  bootstrap: [AppComponent]
})
export class AppModule { }
