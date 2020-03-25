import { Component, Input, EventEmitter, Output } from '@angular/core';
import { Client } from '../client.interface';
import { ClientService } from '../client.service';

@Component({
  selector: 'app-client-edit',
  templateUrl: './client-edit.component.html',
  styleUrls: ['./client-edit.component.css']
})
export class ClientEditComponent {
  @Input() client: Client;
  @Output() onClientSave = new EventEmitter<Client>();

  constructor(private clientService: ClientService) {
  }

  getSavePromise() {
    if (this.client.id) {
      return this.clientService.put(this.client);
    }
    else {
      this.client.id = '00000000-0000-0000-0000-000000000000';
      return this.clientService.post(this.client);
    }
  }

  saveClient() {
    this.getSavePromise()
      .subscribe(() => this.onClientSave.emit(this.client));
  }

  cancel() {
    this.onClientSave.emit(null);
  }
}
