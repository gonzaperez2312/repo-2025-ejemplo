/*
    Producto
        Codigo
        Nombre
        Cantidad
        PrecioUnitario

    CalcularDescuento()
    CalcularTotalProducto()
 */

using EjemploProyectoClaseService;

class Program
{
    static void Main()
    {
        Ticket ticket = new Ticket();

        while (true)
        {
            Console.Write("Codigo del producto: ");
            int codigo = int.Parse(Console.ReadLine());

            Console.Write("Nombre del producto: ");
            string nombre = Console.ReadLine();

            Console.Write("Cantidad comprada: ");
            int cantidad = int.Parse(Console.ReadLine());

            Console.Write("Precio del producto: ");
            double precio = double.Parse(Console.ReadLine());

            Producto producto = new Producto()
            {
                Cantidad = cantidad,
                Codigo = codigo,
                Nombre = nombre,
                Precio = precio
            };
            ticket.AgregarProducto(producto);

            Console.Write("¿Quieres cargar un nuevo producto? (s=salir): ");
            string input = Console.ReadLine();
            if (input.ToLower() == "s")
                break;
        }

        Console.WriteLine("Seleccione el medio de pago: ");
        Console.WriteLine("1. Efectivo");
        Console.WriteLine("2. Tarjeta de Crédito");
        Console.WriteLine("3. Tarjeta de Débito");
        int metodoPago = int.Parse(Console.ReadLine());

        double total = ticket.ObtenerTotal();
        double totalConDescuento = ticket.AplicarDescuento((MediosDePago)metodoPago);

        Console.WriteLine(total);
        Console.WriteLine(totalConDescuento);
        Console.WriteLine(total - totalConDescuento);
    }
}

