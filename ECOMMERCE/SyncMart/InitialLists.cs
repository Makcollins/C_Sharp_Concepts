using System;

namespace SyncMart;

public partial class Operations
{
    // CUSTOMER DETAILS INITIAL LIST
    List<CustomerDetails> customers = new List<CustomerDetails>();
    CustomerDetails cust1 = new CustomerDetails()
    {
        CustomerID = "CID3001",
        CustomerName = "Ravi",
        City = "Chennai",
        MobileNumber = "9885858588",
        WalletBalance = 50000,
        EmailID = "ravi@mail.com"
    };
    CustomerDetails cust2 = new CustomerDetails()
    {
        CustomerID = "CID3002",
        CustomerName = "Baskaran",
        City = "Chennai",
        MobileNumber = "9888475757",
        WalletBalance = 60000,
        EmailID = "baskaran@mail.com"
    };

    public void AddInitialCustomers()
    {
        customers.Add(cust1);
        customers.Add(cust2);
    }

    // PRODUCTS DETAILS LIST
    List<ProductDetails> products = new List<ProductDetails>();
    ProductDetails product1 = new ProductDetails()
    {
        ProductID = "PID2001",
        ProductName = "Mobile (Samsung)",
        Stock = 10,
        Price = 10000,
        ShippingDuration = 3
    };

    ProductDetails product2 = new ProductDetails()
    {
        ProductID = "PID2002",
        ProductName = "Tablet (Lenovo)",
        Stock = 5,
        Price = 15000,
        ShippingDuration = 2
    };
    ProductDetails product3 = new ProductDetails()
    {
        ProductID = "PID2003",
        ProductName = "Camara (Sony)",
        Stock = 3,
        Price = 20000,
        ShippingDuration = 4
    };
    ProductDetails product4 = new ProductDetails()
    {
        ProductID = "PID2004",
        ProductName = "iPhone",
        Stock = 5,
        Price = 50000,
        ShippingDuration = 6
    };
    ProductDetails product5 = new ProductDetails()
    {
        ProductID = "PID2005",
        ProductName = "Laptop (Lenovo I3)",
        Stock = 3,
        Price = 40000,
        ShippingDuration = 3
    };
    ProductDetails product6 = new ProductDetails()
    {
        ProductID = "PID2006",
        ProductName = "HeadPhone (Boat)",
        Stock = 5,
        Price = 1000,
        ShippingDuration = 2
    };
    ProductDetails product7 = new ProductDetails()
    {
        ProductID = "PID2007",
        ProductName = "Speakers (Boat)",
        Stock = 4,
        Price = 500,
        ShippingDuration = 2
    };

    public void AddInitialProducts()
    {
        products.Add(product1);
        products.Add(product2);
        products.Add(product3);
        products.Add(product4);
        products.Add(product5);
        products.Add(product6);
        products.Add(product7);

    }

    List<OrderDetails> orders = new List<OrderDetails>();

    OrderDetails order1 = new OrderDetails()
    {
        OrderID = "OID1001",
        CustomerID = "CID3001",
        ProductID = "PID2001",
        TotalPrice = 20000,
        PurchaseDate = DateTime.Now,
        Quantity = 2,
        Status = OrderStatus.Ordered
    };
    OrderDetails order2 = new OrderDetails()
    {
        OrderID = "OID1002",
        CustomerID = "CID3002",
        ProductID = "PID2003",
        TotalPrice = 40000,
        PurchaseDate = DateTime.Now,
        Quantity = 2,
        Status = OrderStatus.Ordered
    };

    public void AddInitialOrders()
    {
        orders.Add(order1);
        orders.Add(order2);
    }
}
