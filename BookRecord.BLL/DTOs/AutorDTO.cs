namespace BookRecord.BLL.DTOs;

public class AutorDTO
{
    public int AutorId { get; set; }

    public string NombreCompleto { get; set; } = null!;

    public DateTime FechaNacimiento { get; set; }

    public string CiudadProcedencia { get; set; } = null!;

    public string CorreoElectronico { get; set; } = null!;
}
