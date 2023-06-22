using Application.Common.Models;
using Application.WeatherForecasts.Queries.GetWeatherForecasts;
using MediatR;

namespace Application.Checkup.Queries.GetCheckup;
public record GetCheckupQuery(string appName,string appVersion) : IRequest<Checkup>;

public class GetCheckupQueryHandler : IRequestHandler<GetCheckupQuery, Checkup>
{
    public async Task<Checkup> Handle(GetCheckupQuery request, CancellationToken cancellationToken)
    {
      
        Checkup checkup = new Checkup()
        {
            result = "{" + $"\"AppName\":\"{request.appName}\", \"version\":\"{request.appVersion}\",\"status\",\"OK\"" + "}"
        };
        return checkup;
    }
}
