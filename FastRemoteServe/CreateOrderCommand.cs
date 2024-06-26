﻿using FastEndpoints;

namespace FastRemoteServe;

public class CreateOrderCommand : ICommand<CreateOrderResult>
{
    public int OrderId { get; set; }
    public string CustomerName { get; set; }
}

public class CreateOrderResult
{
    public string Message { get; set; }
    public DateTime EventTime { get; set; } = DateTime.Now;
}