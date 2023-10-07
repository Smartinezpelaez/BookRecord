namespace BookRecord.DAL.Models;

public partial class Autor
{
    public int AutorId { get; set; }

    public string NombreCompleto { get; set; } = null!;

    public DateTime FechaNacimiento { get; set; }

    public string CiudadProcedencia { get; set; } = null!;

    public string CorreoElectronico { get; set; } = null!;

    public virtual ICollection<Libro> Libros { get; set; } = new List<Libro>();
}
