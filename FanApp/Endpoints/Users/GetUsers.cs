using Ardalis.ApiEndpoints;
using AutoMapper;
using FanApp.Common.Helpers;
using FanApp.Common.Models;
using FanApp.Common.Models.Dtos;
using FanApp.Endpoints.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace FanApp.Endpoints.Users
{
    public class GetUsers : EndpointBaseAsync.WithoutRequest.WithActionResult<List<UserDto>>
    {
        private readonly IMapper _mapper;
        private readonly FanAppContext _fanAppContext;
        private readonly IFilterExpression _filterExpression;

        public GetUsers(FanAppContext fanAppContext, IMapper mapper, IFilterExpression filterExpression)
        {
            _mapper = mapper;
            _fanAppContext = fanAppContext;
            _filterExpression = filterExpression;
        }
        [HttpGet("users")]
        [SwaggerOperation(
            Summary = "Get all users",
            Description = "Retrieve all the users from the database",
            OperationId = "Users.Get",
            Tags = new[] {"Users"})]
        public async override Task<ActionResult<List<UserDto>>> HandleAsync(CancellationToken cancellationToken = default)
        {
            //var usersResult = await _fanAppContext.Users.ToListAsync();

            EntityResultBuilder<User, UserDto> entityResult = new(_fanAppContext.Users, _mapper);
            entityResult.AddWhereExpression(_filterExpression.GetUserByLastname());

            var result = await entityResult.ToMappedResultAsync();

            return result == null ? NoContent() : Ok(result);
            //return _mapper.Map<List<UserDto>>(usersResult);
        }
    }
}
