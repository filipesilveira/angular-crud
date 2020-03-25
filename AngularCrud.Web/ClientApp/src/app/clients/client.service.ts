import { Injectable, Inject } from "@angular/core";
import { HttpClient } from '@angular/common/http';
import { Client } from "./client.interface";

@Injectable()
export class ClientService {
  baseUrl = '';

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
  }

  public get(clientId) {
    return this.http.get<any>(`${this.baseUrl}api/Client/${clientId}`);            
  }

  public getAll() {
    return this.http.get<any>(`${this.baseUrl}api/Client/`);        
  }

  public post(client) {
    return this.http.post<any>(`${this.baseUrl}api/Client/`, client);        
  }

  public put(client) {
    return this.http.put<any>(`${this.baseUrl}api/Client/`, client);        
  }

  public delete(clientId) {
    return this.http.delete<any>(`${this.baseUrl}api/Client/${clientId}`);        
  }
}
