namespace Model;
public class Order
{
    public int OrderID { get; set; }

    public int ClientID { get; set; }
    public Client? Client { get; set; }

    public decimal Iva { get; set; }
    public decimal SubTotal { get; set; }
    public decimal Total { get; set; }

    public List<OrderDetail>? Items { get; set; }
}