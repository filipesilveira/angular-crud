import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { ClientsComponent } from './clients/clients.component';
import { ClientEditComponent } from './clients/client-edit/client-edit.component';
import { ClientListComponent } from './clients/client-list/client-list.component';
import { ClientService } from './clients/client.service';

@NgModule({
  declarations: [
    AppComponent,
    ClientsComponent,
    ClientEditComponent,
    ClientListComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule
  ],
  providers: [
    ClientService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
