import { Component, OnInit } from '@angular/core';
import {AccountsService} from '../services/account.services';

@Component({
  selector: 'app-update',
  templateUrl: './update.component.html',
  styleUrls: ['./update.component.css']
})
export class UpdateComponent implements OnInit {
  productid: any = '' ;
  productname: any = '' ;
  accountsServiceRef: AccountsService ;

  constructor(accountServiceRef: AccountsService ) {
    this.accountsServiceRef = accountServiceRef ;
   }

  ngOnInit(): void {
  }

  UpdateProduct(): any
  {
     const product = { ProductId : this.productid, ProductName : this.productname };
     const observableStream = this.accountsServiceRef.updateproducts(product);
     const productidregex: RegExp = /^[+0-9]{3}$/;
     const productnameregex: RegExp = /^[a-zA-z]*/;

     if( this.productid !== '' && this.productname !== '' && productidregex.test(this.productid) && productnameregex.test(this.productname) )
     {
     observableStream.subscribe(
      (data: any) => {
        window.alert('Product is updated');
        data.productid = this.productid;
        data.productname = this.productname;
        console.log(data);
        this.productid = '' ;
        this.productname = '' ;
      },
      (error) => {
        window.alert('Check for the id');
        console.log(error);
      },
      () => {
        console.log('User data updated');
      });
    }
    else
    {
      window.alert('check for the form');
    }
  }


}
