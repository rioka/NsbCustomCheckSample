
using System.Reflection;

namespace NsbCustomCheckSample.Monitor
{
  using NServiceBus;

  public class EndpointConfig : IConfigureThisEndpoint
  {
    public void Customize(BusConfiguration configuration)
    {
      configuration.EndpointName(MethodBase.GetCurrentMethod().DeclaringType.Namespace);

      //configuration.UseTransport<MsmqTransport>();
      //configuration.UsePersistence<InMemoryPersistence>();
      configuration.UseTransport<SqlServerTransport>();
      configuration.UsePersistence<NHibernatePersistence>();
      configuration.UseSerialization<JsonSerializer>();

      configuration.Conventions()
          .DefiningEventsAs(t => typeof(IEvent).IsAssignableFrom(t)
                                 || t.Namespace != null && t.Namespace.StartsWith("ServiceControl.Contracts"));
    }
  }
}
