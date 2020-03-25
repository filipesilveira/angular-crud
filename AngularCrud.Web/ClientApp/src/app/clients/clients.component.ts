import { Component } from '@angular/core';
import { Client } from './client.interface';

@Component({
  selector: 'app-clients',
  templateUrl: './clients.component.html',
  styleUrls: ['./clients.component.css']
})
export class ClientsComponent {
  featureActive: string = 'list';
  clientSelected;

  addClient() {
    this.clientSelected = {};
    this.featureActive = 'edit';
  }

  clientSaved() {
    this.featureActive = 'list';
  }

  selectClient(clientSelected: Client) {
    this.clientSelected = clientSelected;
    this.featureActive = 'edit';
  }
}
