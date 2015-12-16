
using System.Reflection;

namespace NsbCustomCheckSample.Server
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
          .DefiningEventsAs(t => t.Namespace != null && t.Namespace.StartsWith(".Events"))
          .DefiningCommandsAs(t => t.Namespace != null && t.Namespace.StartsWith(".Commands"))
          .DefiningMessagesAs(t => t.Namespace != null && t.Namespace.StartsWith(".Messages"));
    }
  }
}
