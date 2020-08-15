import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { ApiServiceService } from './services/api-service.service';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { TransactionsComponent } from './transactions/transactions.component';

@NgModule({
  declarations: [
    AppComponent,
    TransactionsComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [HttpClient, ApiServiceService],
  bootstrap: [AppComponent]
})
export class AppModule { }
