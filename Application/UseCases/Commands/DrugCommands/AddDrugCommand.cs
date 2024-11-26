using Domain.Entities;
using MediatR;

namespace Application.UseCases.Commands.DrugCommands;

public record AddDrugCommand(Drug drug) : IRequest;