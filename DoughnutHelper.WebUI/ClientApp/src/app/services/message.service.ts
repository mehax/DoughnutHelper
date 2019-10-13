import { Injectable } from '@angular/core';
import {Observable} from 'rxjs';
import {MessageModel} from '../models/MessageModel';
import {Answers} from '../enums/Answers';
import {HttpClient} from '@angular/common/http';
import {environment} from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class MessageService {
  private baseUrl = `${environment.apiUrl}/messages`;

  constructor(private http: HttpClient) { }

  getNextMessage(questionMessageId?: number, answer?: Answers): Observable<MessageModel> {
    const params = !!questionMessageId ? `?questionMessageId=${questionMessageId}&answer=${answer}` : ``;
    return this.http.get<MessageModel>(this.baseUrl + params);
  }
}
