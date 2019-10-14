import {Component, Input, OnInit, ViewChildren} from '@angular/core';
import {MessageModel} from '../../models/MessageModel';

@Component({
  selector: 'app-tree-node',
  templateUrl: './tree-node.component.html',
  styleUrls: ['./tree-node.component.css']
})
export class TreeNodeComponent implements OnInit {
  @Input() nodeMessage: MessageModel;
  @Input() allMessages: MessageModel[];
  @ViewChildren('treeNodeComponents') treeNodeComponents: TreeNodeComponent[];

  constructor() { }

  ngOnInit() {
  }

  public get childrenMessages(): MessageModel[] {
    return this.allMessages.filter(m => m.parentId === this.nodeMessage.messageId);
  }

  public highlightNodes(messagesId: number[], nextMessageId?: number): void {
    this.nodeMessage.isChosen = !!messagesId.find(messageId => messageId === this.nodeMessage.messageId);
    this.nodeMessage.isNextMessage = this.nodeMessage.messageId === nextMessageId;

    this.treeNodeComponents.forEach(node => {
      node.highlightNodes(messagesId, nextMessageId);
    });
  }
}
