import { Component, OnInit } from '@angular/core';
import {UserService} from '../../services/user.service';
import {Router} from '@angular/router';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  inputName: string;

  constructor(private userService: UserService,
              private router: Router) { }

  ngOnInit() {
  }

  public submit(): void {
    this.userService.create(this.inputName).subscribe(userId => {
      this.userService.saveCurrentUserId(userId);
      this.router.navigate(['/']);
    });
  }

  public submitKeyEvent(event) {
    if (event.keyCode === 13) { // if `ENTER`
      this.submit();
    }
  }
}
