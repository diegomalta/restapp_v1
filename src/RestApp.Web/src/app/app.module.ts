import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http'

import { AppRoutingModule } from './app-routing.module';
import { MaterialModule } from './shared/material.module';
/* Feature Modules */
import { UserModule } from './user/user.module';
import { HomeModule } from './home/home.module'

import { AppComponent } from './app.component';
// services
import { AdminService } from './shared/services/admin.service';
import { PageNotFoundComponent } from './page-not-found.component';



@NgModule({
  declarations: [
    AppComponent,
    PageNotFoundComponent
  ],
  imports: [
    UserModule,
    HomeModule,
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MaterialModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [AdminService],
  bootstrap: [AppComponent]
})
export class AppModule { }
