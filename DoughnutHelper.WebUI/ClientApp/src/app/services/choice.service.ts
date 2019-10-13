import { Injectable } from '@angular/core';
import {ChoiceModel} from '../models/ChoiceModel';
import {Observable} from 'rxjs';
import {HttpClient} from '@angular/common/http';
import {environment} from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ChoiceService {
  private baseUrl = `${environment.apiUrl}/choices`;

  constructor(private http: HttpClient) { }

  public getUserChoices(userId: number): Observable<ChoiceModel[]> {
    return this.http.get<ChoiceModel[]>(this.baseUrl + `/${userId}`);
  }

  public createUserChoice(choice: ChoiceModel): Observable<any> {
    return this.http.post<any>(this.baseUrl, choice);
  }
}
