using System;
using System.Linq.Expressions;
using DoughnutHelper.Domain.Entities;

namespace DoughnutHelper.Application.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public static Expression<Func<User, UserModel>> Projection
        {
            get
            {
                return user => new UserModel
                {
                    Id = user.Id,
                    Name = user.Name
                };
            }
        }
    
        public static UserModel CreateModel(User user)
        {
            return Projection.Compile().Invoke(user);
        }
    }
}