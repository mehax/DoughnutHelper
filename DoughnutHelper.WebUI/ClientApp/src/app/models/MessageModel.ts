import {Answers} from '../enums/Answers';

export class MessageModel {
  messageId: number;
  messageText: string;
  isQuestion: boolean;
  parentId?: number;
  byAnswer?: Answers;

  isHighlighted = false;
}
