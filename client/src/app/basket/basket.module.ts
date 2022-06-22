import { NgModule } from '@angular/core';

import { BasketComponent } from './basket.component';
import { BasketRoutingModule } from './basket-routing.module';
import { BrowserModule } from '@angular/platform-browser';
import { SharedModule } from '../shared/shared.module';



@NgModule({
  declarations: [
    BasketComponent
  ],
  imports: [
    BasketRoutingModule,BrowserModule,SharedModule
  ]
})
export class BasketModule { }
