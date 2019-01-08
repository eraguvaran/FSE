import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { MenuComponent } from './menu/menu.component';
import { WeatherComponent } from './weather/weather.component';
import { MovieComponent } from './movie/movie.component';
import { CurrencyComponent } from './currency/currency.component';
import {  RouterModule, Routes} from '@angular/router'
import { FormsModule} from '@angular/forms';

import { HttpClientModule } from '@angular/common/http';



const approutes: Routes=[
  {path: 'weather', component:WeatherComponent},
  {path: 'movie', component:MovieComponent },
  {path: 'curreny', component:CurrencyComponent}
    ]; 


@NgModule({
  declarations: [
    AppComponent,
    MenuComponent,
    WeatherComponent,
    MovieComponent,
    CurrencyComponent
  ],
  imports: [
    BrowserModule,[RouterModule.forRoot(approutes,{enableTracing : true}), HttpClientModule , FormsModule]
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
