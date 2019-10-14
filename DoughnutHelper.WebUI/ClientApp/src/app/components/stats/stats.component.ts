import {Component, OnInit, ViewChild} from '@angular/core';
import {UserModel} from '../../models/UserModel';
import {UserService} from '../../services/user.service';
import {TreeComponent} from '../tree/tree.component';

@Component({
  selector: 'app-stats',
  templateUrl: './stats.component.html',
  styleUrls: ['./stats.component.css']
})
export class StatsComponent implements OnInit {
  @ViewChild('treeComponent') treeComponent: TreeComponent;
  users: UserModel[];

  constructor(private userService: UserService) { }

  ngOnInit() {
    this.getAllUsers();
  }

  private getAllUsers(): void {
    this.userService.getAll().subscribe(users => {
      this.users = users;
    });
  }

  public selectUser(userId: number): void {
    this.treeComponent.updateSelectedUser(userId);
  }
}
