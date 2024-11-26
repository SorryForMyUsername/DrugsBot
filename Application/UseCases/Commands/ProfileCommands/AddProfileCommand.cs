using Domain.Entities;
using MediatR;

namespace Application.UseCases.Commands.ProfileCommands;
    
public record AddProfileCommand(Profile profile) : IRequest;