using MediatR;
using Country = Domain.Entities.Country;

namespace Application.UseCases.Commands.CountryCommands;

public record UpdateCountryCommand(Country country) : IRequest;