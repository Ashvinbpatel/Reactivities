using System;
using domain;
using MediatR;
using persistence;

namespace application.Activities.Commands;

public class CreateActivity
{
    public class Command : IRequest<String>
    {
        public required Activity activity { get; set; }
    }
    public class Handler(AppDbContext context) : IRequestHandler<Command, String>
    {
        public async Task<String> Handle(Command request, CancellationToken cancellationToken)
        {
            context.Activities.Add(request.activity);
            await context.SaveChangesAsync(cancellationToken);
            return request.activity.Id;
        }
    }
}
