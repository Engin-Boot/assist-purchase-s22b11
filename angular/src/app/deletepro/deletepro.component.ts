import { createElementCssSelector } from '@angular/compiler';
import { Component, OnInit } from '@angular/core';
import {AccountsService} from '../services/account.services';

/* tslint:disable */
@Component({
  selector: 'app-deletepro',
  templateUrl: './deletepro.component.html',
  styleUrls: ['./deletepro.component.css']
})
export class DeleteproComponent implements OnInit {
  productid: any = '';
  productname: any = '';
  accountsServiceRef: AccountsService;



  constructor(accountServiceRef: AccountsService) {
    this.accountsServiceRef = accountServiceRef;
   }

  ngOnInit(): void {
  }

  DeleteProduct(): any
  {
     const product = {ProductId: this.productid, ProductName: this.productname};
     const observableStream = this.accountsServiceRef.deleteproducts(product);
     const productidregex: RegExp = /^[+0-9]{3}$/;
     const productnameregex: RegExp = /^[a-zA-z]*/;
     if(this.productid !== '' && this.productname !== '' && productidregex.test(this.productid) && productnameregex.test(this.productname))
     {observableStream.subscribe(
      (data: any) => {
        window.alert('A product is deleted');
        this.productid = '';
        this.productname = '';
        console.log(data);
      },
      (error) => {
        window.alert('Check for the name and id');
        console.log(error);
      },
      () => {
        console.log('User data deleted');
      });
    }
    else
    {
      window.alert('Check for the form');
    }
  }
}

