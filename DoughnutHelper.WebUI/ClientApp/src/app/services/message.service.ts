import { Injectable } from '@angular/core';
import {Observable} from 'rxjs';
import {MessageModel} from '../models/MessageModel';
import {HttpClient} from '@angular/common/http';
import {environment} from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class MessageService {
  private baseUrl = `${environment.apiUrl}/messages`;

  constructor(private http: HttpClient) { }

  public getAll(): Observable<MessageModel[]> {
    return this.http.get<MessageModel[]>(this.baseUrl);
  }

  public getUserNextMessage(userId: number): Observable<MessageModel> {
    return this.http.get<MessageModel>(this.baseUrl + `/${userId}`);
  }
}
