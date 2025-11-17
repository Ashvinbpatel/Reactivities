using System;
using AutoMapper;
using domain;
using MediatR;
using persistence;

namespace application.Activities.Commands;

public class EditActivity
{
    public class Command : IRequest
    {
        public required Activity activity { get; set; }
    }
    public class Handler(AppDbContext context,IMapper mapper) : IRequestHandler<Command>
    {
        public async Task Handle(Command request, CancellationToken cancellationToken)
        {
            var activity = await context.Activities.FindAsync(request.activity.Id, cancellationToken) 
                            ?? throw new Exception("Activity not found");
            

            mapper.Map(request.activity, activity);

            await context.SaveChangesAsync(cancellationToken);
            
        }

    
    }
}
