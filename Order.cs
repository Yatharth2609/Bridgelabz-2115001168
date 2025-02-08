using System;

public class Order
{
    public string OrderId { get; set; }
    public DateTime OrderDate { get; set; }

    public Order(string orderId, DateTime orderDate)
    {
        OrderId = orderId;
        OrderDate = orderDate;
    }

    public virtual string GetOrderStatus()
    {
        return "Order Placed";
    }
}

public class ShippedOrder : Order
{
    public string TrackingNumber { get; set; }

    public ShippedOrder(string orderId, DateTime orderDate, string trackingNumber) : base(orderId, orderDate)
    {
        TrackingNumber = trackingNumber;
    }

    public override string GetOrderStatus()
    {
        return "Order Shipped";
    }
}

public class DeliveredOrder : ShippedOrder
{
    public DateTime DeliveryDate { get; set; }

    public DeliveredOrder(string orderId, DateTime orderDate, string trackingNumber, DateTime deliveryDate) : base(orderId, orderDate, trackingNumber)
    {
        DeliveryDate = deliveryDate;
    }

    public override string GetOrderStatus()
    {
        return "Order Delivered";
    }
}

class Program
{
    static void Main(string[] args)
    {
        Order order = new Order("ORD123", DateTime.Now);
        ShippedOrder shippedOrder = new ShippedOrder("ORD456", DateTime.Now, "TRACK789");
        DeliveredOrder deliveredOrder = new DeliveredOrder("ORD789", DateTime.Now, "TRACK101", DateTime.Now.AddDays(3));

        Console.WriteLine(order.GetOrderStatus());
        Console.WriteLine(shippedOrder.GetOrderStatus());
        Console.WriteLine(deliveredOrder.GetOrderStatus());
    }
}