using System;
using NsbCustomCheckSample.Messages.Commands;
using NServiceBus;

namespace NsbCustomCheckSample.Server
{
  public class Handler : IHandleMessages<CreateOrder>
  {
    public void Handle(CreateOrder message)
    {
      Console.WriteLine("Just a placeholder in this case!");
    }
  }
}
