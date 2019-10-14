import {ChoiceModel} from './ChoiceModel';
import {MessageModel} from './MessageModel';

export interface StatsModel {
    choices: ChoiceModel[];
    nextMessage: MessageModel;
}
