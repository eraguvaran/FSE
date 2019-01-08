import { Component, OnInit } from '@angular/core';
import {SharedService} from '../shared.Service'

@Component({
  selector: 'app-currency',
  templateUrl: './currency.component.html',
  styleUrls: ['./currency.component.css']
})
export class CurrencyComponent implements OnInit {
 data:any;
 public txtCurrency: string='USD';
  constructor(private sharedservice: SharedService) {
    

   }

  ngOnInit() {
  }

  public getCurrencyInfo(){
    this.sharedservice.getCurrency(this.txtCurrency.toString()).subscribe(res=>
      {
        this.data = res;
      });
  }
}
