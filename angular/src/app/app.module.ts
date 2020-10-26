import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import {HttpClientModule} from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { SubscriberComponent } from './subscriber/subscriber.component';
import {AccountsService} from './services/account.services';
import { UpdateComponent } from './update/update.component';
import { DeleteproComponent } from './deletepro/deletepro.component';
import {ConsumerComponent} from './consumer/consumer.component';


@NgModule({
  declarations: [
    AppComponent,
    SubscriberComponent,
    UpdateComponent,
    DeleteproComponent,
    ConsumerComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule, FormsModule, HttpClientModule, ReactiveFormsModule
  ],
  providers: [{ provide: 'apiBaseAddress', useValue: 'http://localhost:50664' },
  { provide: AccountsService , useClass: AccountsService } ],
  bootstrap: [ AppComponent ]
})
export class AppModule { }
