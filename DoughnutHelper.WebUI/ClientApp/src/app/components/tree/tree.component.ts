import {Component, OnInit} from '@angular/core';
import {MessageModel} from '../../models/MessageModel';
import {MessageService} from '../../services/message.service';
import {ChoiceService} from '../../services/choice.service';

@Component({
  selector: 'app-tree',
  templateUrl: './tree.component.html',
  styleUrls: ['./tree.component.css']
})
export class TreeComponent implements OnInit {
  messages: MessageModel[];

  constructor(private messageService: MessageService,
              private choiceService: ChoiceService) { }

  ngOnInit() {
    this.getAllMessages();
  }

  private getAllMessages(): void {
    this.messageService.getAll().subscribe(messages => {
      this.messages = messages;
    });
  }

  private get initialMessageNode(): MessageModel {
    return this.messages.find(m => m.isQuestion && !m.parentId);
  }

  // TODO: this is not working, needs to change logic
  public updateSelectedUser(userId: number): void {
    this.choiceService.getUserChoices(userId).subscribe(choices => {
      choices.forEach(choice => {
        for (let i = 0; i < this.messages.length; i++) {
          const message = this.messages[i];
          if (message.messageId === choice.questionMessageId && message.byAnswer === choice.answer) {
            this.messages[i].isHighlighted = true;
          }
        }
      });
    });
  }
}
