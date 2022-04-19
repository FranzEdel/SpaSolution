namespace Model;
public class OrderDetail
{
    public int OrderDetailID { get; set; }

    public int OrderID { get; set; }
    public Order? Order { get; set; }

    public int ProductID { get; set; }
    public Product? Product { get; set; }
    public decimal UnitPrice { set; get; }

    public int Quantity { set; get; }

    public decimal Iva { get; set; }
    public decimal SubTotal { get; set; }
    public decimal Total { get; set; }
}