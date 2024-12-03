using Domain.Entities;
using MediatR;

namespace Application.UseCases.Commands.ProfileCommands;

public record UpdateProfileDrugCommand(Profile profile) : IRequest;