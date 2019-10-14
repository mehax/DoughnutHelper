using System.Collections.Generic;

namespace DoughnutHelper.Application.Messages.Models
{
    public class StatsModel
    {
        public List<ChoiceModel> Choices { get; set; }
        public MessageModel NextMessage { get; set; }
    }
}