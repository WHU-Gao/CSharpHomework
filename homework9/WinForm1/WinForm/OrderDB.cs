
using System.Data.Entity;
namespace WinForm
{
    class OrderDB: DbContext
    {
        public OrderDB() : base("OrderDataBase")
        {           
        }

        public  DbSet<Order> order { get; set; }  //order
        public  DbSet<OrderDetails> orderDetails { get; set; }  //orderdetails
    }
}
