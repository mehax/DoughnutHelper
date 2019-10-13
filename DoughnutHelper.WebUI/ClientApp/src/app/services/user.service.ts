import { Injectable } from '@angular/core';
import {environment} from "../../environments/environment";
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {UserModel} from "../models/UserModel";

@Injectable({
  providedIn: 'root'
})
export class UserService {
  private baseUrl = `${environment.apiUrl}/users`;

  constructor(private http: HttpClient) { }

  getAll(): Observable<UserModel[]> {
    return this.http.get<UserModel[]>(this.baseUrl);
  }

  getById(id: number): Observable<UserModel> {
    return this.http.get<UserModel>(this.baseUrl + `/${id}`);
  }

  create(name: string): Observable<number> {
    return this.http.post<number>(this.baseUrl, {name: name});
  }

  getCurrentUserId(): number {
    return parseInt(localStorage.getItem('userId'));
  }

  saveCurrentUserId(id: number): void {
    localStorage.setItem('userId', '' + id);
  }
}
