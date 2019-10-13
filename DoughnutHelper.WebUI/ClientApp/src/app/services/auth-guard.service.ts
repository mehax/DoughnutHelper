import { Injectable } from '@angular/core';
import {CanActivate, Router} from "@angular/router";
import {UserService} from "./user.service";

@Injectable({
  providedIn: 'root'
})
export class AuthGuardService implements CanActivate {

  constructor(private userService: UserService, private router: Router) { }

  private get isAuthenticated() {
    return !!this.userService.getCurrentUserId();
  }

  canActivate(): boolean {
    if (!this.isAuthenticated) {
      this.router.navigate(['register']);
      return false;
    }
    return true;
  }
}
