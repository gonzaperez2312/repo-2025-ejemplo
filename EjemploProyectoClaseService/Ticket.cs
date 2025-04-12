using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EjemploProyectoClaseService
{
    public class Ticket
    {
        private List<Producto> Productos { get; set; }

        public Ticket() { 
            Productos = new List<Producto>();
        }

        public List<Producto> ObtenerProductos() {
            return Productos;
        }

        public void AgregarProducto(Producto producto) {
            Productos.Add(producto);
        }

        public double ObtenerTotal()
        {
            /*double total = 0;
            
            foreach (var producto in Productos)
            {
                total += producto.CalcularTotalProducto();
            }

            return total;*/

            return Productos.Where(x => x.Nombre.ToLower() == "harina" || x.Nombre.ToLower() == "pan")
                .Sum(item => item.CalcularTotalProducto());
        }

        public double AplicarDescuento(MediosDePago metodoPago)
        {
            double total = ObtenerTotal();
            double descuento = 0;

            if (metodoPago == MediosDePago.Efectivo)
                descuento += 0.05;
            else if (metodoPago == MediosDePago.Credito)
                descuento += 0.03;
            else if (metodoPago == MediosDePago.Debito)
                descuento += 0.01;

            int countExtra = 0;
            foreach (var producto in Productos)
            {
                if (producto.Cantidad >= 2)
                {
                    countExtra++;
                }
            }

            if (countExtra == Productos.Count)
            {
                descuento += 0.05;
            }

            double totalDescuento = total * descuento;
            return total - totalDescuento;
        }
    }
}
