using FanApp.Common.Models;
using System.Linq.Expressions;

namespace FanApp.Common.Helpers
{
    public class FilterExpression : IFilterExpression
    {
        public Expression<Func<User, bool>> GetCommentByUserId()
        {
            Expression<Func<User, bool>> criteria = user => user.Id == new Guid("C400F7DB-2037-4678-B85B-365BD5B85A17");
            return criteria;
        }

        public Expression<Func<User, bool>> GetUserByLastname()
        {
            Expression<Func<User, bool>> criteria = user => user.Lastname.Equals("Muhiya");
            return criteria;
        }
    }
}
