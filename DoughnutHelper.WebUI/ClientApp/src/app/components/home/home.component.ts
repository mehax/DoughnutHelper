import {Component, OnInit} from '@angular/core';
import {UserService} from '../../services/user.service';
import {UserModel} from '../../models/UserModel';
import {MessageModel} from '../../models/MessageModel';
import {MessageService} from '../../services/message.service';
import {ChoiceService} from '../../services/choice.service';
import {Answers} from '../../enums/Answers';
import {ChoiceModel} from '../../models/ChoiceModel';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit {
  loggedUser: UserModel;
  message: MessageModel;

  constructor(private userService: UserService,
              private messageService: MessageService,
              private choiceService: ChoiceService) {}

  ngOnInit() {
    this.getCurrentUser();
  }

  private getCurrentUser(): void {
    const loggedUserId = this.userService.getCurrentUserId();
    this.userService.getById(loggedUserId).subscribe(user => {
      this.loggedUser = user;

      this.getNextMessage();
    });
  }

  private getNextMessage(): void {
    this.messageService.getUserNextMessage(this.loggedUser.id).subscribe(message => {
      this.message = message;
    });
  }

  public submitMessage(isPositive: boolean): void {
    const choice: ChoiceModel = {
      userId: this.loggedUser.id,
      questionMessageId: this.message.messageId,
      answer: isPositive ? Answers.Yes : Answers.No
    };

    this.choiceService.createUserChoice(choice).subscribe(() => {
      this.getNextMessage();
    });
  }
}
