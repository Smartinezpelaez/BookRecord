namespace BookRecord.BLL.DTOs;

public class LibroDTO
{
    public int LibroId { get; set; }

    public string Titulo { get; set; } = null!;

    public int Anio { get; set; }

    public string Genero { get; set; } = null!;

    public int NumPaginas { get; set; }

    public int? AutorId { get; set; }
}
