public class Product
{
    public Product(int iD, string name, double price, string[] colors, int brand)
    {
        ID = iD;
        Name = name;
        Price = price;
        Colors = colors;
        Brand = brand;
    }

    public int ID { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
    public string[] Colors { get; set; }
    public int Brand { set; get; }

    public override string ToString() => $"{ID,3} {Name,12}{Price,5}{Brand,2}{string.Join(",", Colors)}";



}

public class Brand
{
    public int ID { get; set; }
    public string Name { get; set; }
}


public class Program
{
    private static void Main(string[] args)
    {
        var brands = new List<Brand>()
{
    new Brand{ID=1, Name="Công ty AAA"},
    new Brand{ID=2,Name="Cong ty BBB"},
    new Brand{ID=3,Name="Cong ty CCC"},
};
        var products = new List<Product>()
{
    new Product(1,"Bàn trà", 400, new string[] {"Xám","Xanh"},2),
    new Product(2,"Tranh treo", 400, new string[] {"Vàng","Xanh"},1),
    new Product(3,"Đèn trùm", 500, new string[] {"Trắng"},3),
    new Product(4,"Bàn học", 200, new string[] {"Trắng","Xanh"},1),
    new Product(5,"Túi da", 300, new string[] {"Đỏ","Đen","Vàng"},2),
    new Product(6,"Giường ngủ", 500, new string[] {"Trắng"},2),
    new Product(7,"Tủ áo", 600, new string[] {"Trắng"},3),
};
        
          var filteredByPrice = from product in products
                                where product.Price != 400
                                select new
                                {
                                    name = product.Name,
                                    brand = brands.FirstOrDefault(b => b.ID == product.Brand)?.Name ?? "NO-BRAND",
                                    price = product.Price
                                };

        Console.WriteLine("Products with price not equal to 400:");
          foreach (var product in filteredByPrice)
          {
            Console.WriteLine($"{product.name,10}{product.price,4}{product.brand,12}");
        }

       
          var filteredByColor = from product in products
                                where !product.Colors.Contains("Vàng")
                                select new
                                {
                                    name = product.Name,
                                    brand = brands.FirstOrDefault(b => b.ID == product.Brand)?.Name ?? "NO-BRAND",
                                    price = product.Price
                                };

        Console.WriteLine("\nProducts without the color yellow:");
          foreach (var product in filteredByColor)
          {
            Console.WriteLine($"{product.name,10}{product.price,4}{product.brand,12}");
        }

          var sortedList = from product in products
                           orderby product.Price descending
                           select new
                           {
                               name = product.Name,
                               brand = brands.FirstOrDefault(b => b.ID == product.Brand)?.Name ?? "NO-BRAND",
                               price = product.Price
                           };

        Console.WriteLine("\nList of products in descending order of price:");
          foreach (var product in sortedList)
          {
            Console.WriteLine($"{product.name,10}{product.price,4}{product.brand,12}");
        }

        
       /* var ketqua = from product in products
                     join brand in brands on product.Brand equals brand.ID 
                   
                     select new
                     {
                         name = product.Name,
                         brand = brand.Name,
                         price = product.Price
                     };
        foreach (var item in ketqua)
        {
            Console.WriteLine($"{item.name,10}{item.price,4}{item.brand,12}");
            Console.ReadLine();
        }


        
        var ketqua = from product in products
                     join brand in brands on product.Brand equals brand.ID into t
                     from brand in t.DefaultIfEmpty()
                     select new
                     {
                         name = product.Name,
                         brand = (brand == null) ? "NO-BRAND" : brand.Name,
                         price = product.Price
                     };
        foreach (var item in ketqua)
        {
            Console.WriteLine($"{item.name,10}{item.price,4}{item.brand,12}");
        }*/
    }

}

