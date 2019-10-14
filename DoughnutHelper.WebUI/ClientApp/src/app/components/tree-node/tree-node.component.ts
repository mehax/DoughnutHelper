import {Component, Input, OnInit} from '@angular/core';
import {MessageModel} from '../../models/MessageModel';

@Component({
  selector: 'app-tree-node',
  templateUrl: './tree-node.component.html',
  styleUrls: ['./tree-node.component.css']
})
export class TreeNodeComponent implements OnInit {
  @Input() nodeMessage: MessageModel;
  @Input() allMessages: MessageModel[];

  constructor() { }

  ngOnInit() {
  }

  public get childrenMessages(): MessageModel[] {
    return this.allMessages.filter(m => m.parentId === this.nodeMessage.messageId);
  }
}
