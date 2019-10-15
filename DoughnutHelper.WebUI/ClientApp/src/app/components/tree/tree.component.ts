import {Component, OnInit, ViewChild} from '@angular/core';
import {MessageModel} from '../../models/MessageModel';
import {MessageService} from '../../services/message.service';
import {TreeNodeComponent} from '../tree-node/tree-node.component';
import {UserService} from '../../services/user.service';

@Component({
  selector: 'app-tree',
  templateUrl: './tree.component.html',
  styleUrls: ['./tree.component.css']
})
export class TreeComponent implements OnInit {
  @ViewChild('treeNodeComponent', {static: false}) treeNodeComponent: TreeNodeComponent;
  messages: MessageModel[];

  constructor(private messageService: MessageService,
              private userService: UserService) { }

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
    this.userService.getStats(userId).subscribe(stats => {
      const highlightedMessagesId = stats.choices.map(choice => choice.questionMessageId);
      const nextMessageId = stats.nextMessage.messageId;

      this.treeNodeComponent.highlightNodes(highlightedMessagesId, nextMessageId);
    });
  }
}
