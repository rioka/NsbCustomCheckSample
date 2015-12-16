using System;

namespace NsbCustomCheckSample.Messages.Events
{
  public class OrderCreated
  {
    public Guid Id { get; set; }
    public string Customer { get; set; }
    public DateTimeOffset Date { get; set; }
  }
}
