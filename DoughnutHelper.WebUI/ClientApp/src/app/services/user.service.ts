import { Injectable } from '@angular/core';
import {environment} from '../../environments/environment';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';
import {UserModel} from '../models/UserModel';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  private baseUrl = `${environment.apiUrl}/users`;

  constructor(private http: HttpClient) { }

  public getAll(): Observable<UserModel[]> {
    return this.http.get<UserModel[]>(this.baseUrl);
  }

  public getById(id: number): Observable<UserModel> {
    return this.http.get<UserModel>(this.baseUrl + `/${id}`);
  }

  public create(name: string): Observable<number> {
    return this.http.post<number>(this.baseUrl, {name: name});
  }

  public getCurrentUserId(): number {
    // tslint:disable-next-line:radix
    return parseInt(localStorage.getItem('userId'));
  }

  public saveCurrentUserId(id: number): void {
    localStorage.setItem('userId', '' + id);
  }
}
