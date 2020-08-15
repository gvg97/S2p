import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import 'rxjs/add/operator/map';
import { transactions } from '../models/transactions';

@Injectable({
  providedIn: 'root'
})
export class ApiServiceService {

  BaseURL = 'http://localhost:52599/api/ListTransaction';

  constructor(private http:HttpClient) {}

  getTransactions(identity: string): Observable<transactions[]>{
    return this.http.get<transactions[]>(`${this.BaseURL}/identity=${identity}`);
  }
}
