import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import {UpdateComponent} from './update/update.component';
import {DeleteproComponent} from './deletepro/deletepro.component';
import {SubscriberComponent} from './subscriber/subscriber.component';
import {ConsumerComponent} from './consumer/consumer.component';


const routes: Routes = [
  {path: '', component: SubscriberComponent },
  {path: 'updateproduct', component: UpdateComponent },
  {path: 'deleteproduct', component: DeleteproComponent },
  {path: 'consumer', component: ConsumerComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
