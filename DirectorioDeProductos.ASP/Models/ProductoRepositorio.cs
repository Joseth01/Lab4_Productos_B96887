namespace DirectorioDeProductos.ASP.Models
{
    public class ProductoRepositorio
    {
        private static List<Producto> listaProductos = new List<Producto>();
        private static int ultimoId = 0;

        public List<Producto> ObtenerTodos()
        {
            return listaProductos;
        }

        public Producto ObtenerPorId(int id)
        {
            return listaProductos.FirstOrDefault(p => p.Id == id);
        }

        public void Agregar(Producto producto)
        {
            ultimoId++;
            producto.Id = ultimoId;
            listaProductos.Add(producto);
        }

        public void Actualizar(Producto producto)
        {
            var existente = ObtenerPorId(producto.Id);
            if (existente != null)
            {
                existente.Nombre = producto.Nombre;
                existente.Precio = producto.Precio;
                existente.Categoria = producto.Categoria;
            }
        }

        public void Eliminar(int id)
        {
            var producto = ObtenerPorId(id);
            if (producto != null)
            {
                listaProductos.Remove(producto);
            }
        }
    }
}
