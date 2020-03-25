import { Component, Output, EventEmitter, OnInit } from '@angular/core';
import { Client } from '../client.interface';
import { ClientService } from '../client.service';

@Component({
  selector: 'app-client-list',
  templateUrl: './client-list.component.html',
  styleUrls: ['./client-list.component.css']
})
export class ClientListComponent implements OnInit {
  @Output() onClientSelected = new EventEmitter<Client>();

  clients: Client[] = [];

  constructor(private clientService: ClientService) {
  }

  ngOnInit() {
    this.getAllClients();
  }

  getAllClients() {
    this.clientService
      .getAll()
      .subscribe(result => this.clients = result);
  }

  editClient(client: Client) {
    this.onClientSelected.emit(client);
  }

  deleteClient(client: Client) {
    this.clientService
      .delete(client.id)
      .subscribe(() => this.getAllClients());
  }
}
