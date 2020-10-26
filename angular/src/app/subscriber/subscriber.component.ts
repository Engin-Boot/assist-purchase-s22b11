import { Component, OnInit } from '@angular/core';
import {AccountsService} from '../services/account.services';

/* tslint:disable */
@Component({
  selector: 'app-subscriber',
  templateUrl: './subscriber.component.html',
  styleUrls: ['./subscriber.component.css']
})

export class SubscriberComponent implements OnInit {
  productid: any = '';
  productname: any = '';
  accountsServiceRef: AccountsService;
  constructor(accountServiceRef: AccountsService) {
    this.accountsServiceRef = accountServiceRef;
}
  ngOnInit(): void {

  }

  AddProduct(): any
  {
    const reproductname: RegExp = /^[a-zA-Z]*$/;
    const regexpNumber: RegExp = /^[+ 0-9]{3}$/;
    if(this.productid !== '' && this.productname !== '' && regexpNumber.test(this.productid) && reproductname.test(this.productname) )
    {
     const product = {ProductId: this.productid, ProductName: this.productname};
     const observableStream = this.accountsServiceRef.addproducts(product);
     observableStream.subscribe(
      (data: any) => {
        window.alert('product is added');
        console.log(data);
        window.location.reload();
      },
      (error) => {
        window.alert(error);
        console.log(error);
      },
      () => {
        console.log('Request completed');
      });
    }
    else if(this.productid === ' ' || this.productname === '' || !regexpNumber.test(this.productid) || !reproductname.test(this.productname))
    {
      window.alert('Product cannot be added check the form for validation');
    }
  }


  addFile(): void {
    const selectedFileList = (<HTMLInputElement> document.getElementById('myFile')).files;
    const fileToUpload = selectedFileList.item(0);
    this.accountsServiceRef.upload(fileToUpload).subscribe(
      res => {
        window.alert('Product Pic is added');
        console.log(res);
      });
    this.productid = '';
    this.productname = '';
}
}
