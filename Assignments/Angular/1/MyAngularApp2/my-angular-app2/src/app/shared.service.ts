import { Injectable, Injector } from '@angular/core';
import { Observable, of } from 'rxjs';
import { HttpClient } from '@angular/common/http';


@Injectable()

export class SharedService {
    MovieAPIURL = '';
    constructor(private injector: Injector, private httpClient: HttpClient) {

    }

    public getWeather(city: string): Observable<any> {
        var weathereAPIurl = 'https://query.yahooapis.com/v1/public/yql?q=select * from weather.forecast where woeid in (select woeid from geo.places(1) where text="' + city + '")&format=json&env=store%3A%2F%2Fdatatables.org%2Falltableswithkeys ';
        return this.httpClient.get(weathereAPIurl);

    }

    public getCurrency(currency: String): Observable<any> {
        var currencyAPIurl = 'https://data.fixer.io/api/latest?base=' + currency;
        return this.httpClient.get(currencyAPIurl);
    }

    public getMovie(movieName:String): Observable<any> {
        var movieapiurl ='http://www.omdbapi.com/?t=%27'+movieName+'%27&apikey=8b8b3f2'
      return this.httpClient.get(movieapiurl);
    }
  
}
