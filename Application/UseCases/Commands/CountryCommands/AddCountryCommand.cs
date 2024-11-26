using Domain.Entities;
using MediatR;

namespace Application.UseCases.Commands.CountryCommands;

public record AddCountryCommand(Country country) : IRequest;