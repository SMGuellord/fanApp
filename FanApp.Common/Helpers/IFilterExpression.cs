using FanApp.Common.Models;
using System.Linq.Expressions;

namespace FanApp.Common.Helpers
{
    public interface IFilterExpression
    {
        Expression<Func<User, bool>> GetUserByLastname();
        Expression<Func<User, bool>> GetCommentByUserId();
    }
}
