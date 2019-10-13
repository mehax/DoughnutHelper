import {UserModel} from "./UserModel";
import {MessageModel} from "./MessageModel";
import {Answers} from "../enums/Answers";

export interface ChoiceModel {
  userId: number;
  questionMessageId: number;
  answer: Answers;

  user?: UserModel;
  question?: MessageModel;
}
