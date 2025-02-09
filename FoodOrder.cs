public abstract class FoodItem
{
    private string itemName;
    private double price;
    private int quantity;
    private bool isSpicy;
    private string specialInstructions;

    public FoodItem(string itemName, double price, int quantity, bool isSpicy)
    {
        this.itemName = itemName;
        this.price = price;
        this.quantity = quantity;
        this.isSpicy = isSpicy;
        this.specialInstructions = string.Empty;
    }

    public string ItemName => itemName;
    public double Price => price;
    public int Quantity => quantity;
    public bool IsSpicy => isSpicy;
    public string SpecialInstructions 
    { 
        get => specialInstructions;
        set => specialInstructions = value ?? string.Empty;
    }

    public abstract double CalculateTotalPrice();

    public string GetItemDetails()
    {
        return $"{itemName} x{quantity} - {price:C} each" +
               $"{(isSpicy ? " (Spicy)" : "")}" +
               $"{(string.IsNullOrEmpty(specialInstructions) ? "" : $"\nSpecial Instructions: {specialInstructions}")}";
    }

    public void UpdateQuantity(int newQuantity)
    {
        if (newQuantity > 0)
            quantity = newQuantity;
    }
}

public interface IDiscountable
{
    double ApplyDiscount(string couponCode);
    string GetDiscountDetails();
}

public class VegItem : FoodItem, IDiscountable
{
    private bool isOrganic;
    private string currentCoupon;

    public VegItem(string itemName, double price, int quantity, bool isSpicy, bool isOrganic)
        : base(itemName, price, quantity, isSpicy)
    {
        this.isOrganic = isOrganic;
    }

    public override double CalculateTotalPrice()
    {
        double basePrice = Price * Quantity;
        double organicCharge = isOrganic ? basePrice * 0.1 : 0;
        return basePrice + organicCharge;
    }

    public double ApplyDiscount(string couponCode)
    {
        currentCoupon = couponCode;
        return couponCode switch
        {
            "VEG10" => CalculateTotalPrice() * 0.9,
            "VEG20" => CalculateTotalPrice() * 0.8,
            _ => CalculateTotalPrice()
        };
    }

    public string GetDiscountDetails()
    {
        return currentCoupon switch
        {
            "VEG10" => "10% off on vegetarian items",
            "VEG20" => "20% off on vegetarian items",
            _ => "No discount applied"
        };
    }
}

public class NonVegItem : FoodItem, IDiscountable
{
    private bool isPremiumCut;
    private string currentCoupon;

    public NonVegItem(string itemName, double price, int quantity, bool isSpicy, bool isPremiumCut)
        : base(itemName, price, quantity, isSpicy)
    {
        this.isPremiumCut = isPremiumCut;
    }

    public override double CalculateTotalPrice()
    {
        double basePrice = Price * Quantity;
        double premiumCharge = isPremiumCut ? basePrice * 0.15 : 0;
        return basePrice + premiumCharge;
    }

    public double ApplyDiscount(string couponCode)
    {
        currentCoupon = couponCode;
        return couponCode switch
        {
            "NONVEG15" => CalculateTotalPrice() * 0.85,
            "PREMIUM25" => isPremiumCut ? CalculateTotalPrice() * 0.75 : CalculateTotalPrice(),
            _ => CalculateTotalPrice()
        };
    }

    public string GetDiscountDetails()
    {
        return currentCoupon switch
        {
            "NONVEG15" => "15% off on non-vegetarian items",
            "PREMIUM25" => isPremiumCut ? "25% off on premium cuts" : "Not eligible for premium discount",
            _ => "No discount applied"
        };
    }
}

public class Order
{
    private List<FoodItem> items;
    private string orderId;

    public Order()
    {
        items = new List<FoodItem>();
        orderId = Guid.NewGuid().ToString();
    }

    public void AddItem(FoodItem item)
    {
        items.Add(item);
    }

    public double CalculateOrderTotal()
    {
        return items.Sum(item => item.CalculateTotalPrice());
    }

    public void ProcessOrder()
    {
        Console.WriteLine($"Order ID: {orderId}");
        Console.WriteLine("Order Details:");

        foreach (var item in items)
        {
            Console.WriteLine("\n" + item.GetItemDetails());
            Console.WriteLine($"Subtotal: {item.CalculateTotalPrice():C}");

            if (item is IDiscountable discountable)
            {
                double discountedPrice = discountable.ApplyDiscount("VEG20");
                if (discountedPrice < item.CalculateTotalPrice())
                {
                    Console.WriteLine($"Discount Applied: {discountable.GetDiscountDetails()}");
                    Console.WriteLine($"Final Price: {discountedPrice:C}");
                }
            }
        }

        Console.WriteLine($"\nTotal Order Amount: {CalculateOrderTotal():C}");
    }
}

public class DeliverySystem
{
    public static void Main()
    {
        Order order = new Order();

        order.AddItem(new VegItem("Paneer Tikka", 420, 2, true, true));
        order.AddItem(new NonVegItem("Chicken Biryani", 499, 1, true, false));
        order.AddItem(new NonVegItem("Masala Dosa", 189, 1, false, true));

        order.ProcessOrder();
    }
}