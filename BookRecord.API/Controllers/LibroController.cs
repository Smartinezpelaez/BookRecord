using AutoMapper;
using BookRecord.BLL.DTOs;
using BookRecord.BLL.Repository;
using BookRecord.BLL.Repository.Implements;
using BookRecord.DAL.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BookRecord.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LibroController : ControllerBase
{
    private readonly ILibroRepository libroRepository;
    private readonly IMapper mapper;

    public LibroController(ILibroRepository libroRepository, IMapper mapper)
    {
        this.libroRepository = libroRepository;
        this.mapper = mapper;
    }

    /// <summary>
    /// Obtenemos los libros
    /// </summary>
    /// <returns></returns>
    [HttpGet("GetAll")]
    public IActionResult GetAll()
    {
        var libro = libroRepository.GetAll();
        var libroDTO = libro.Select(x => mapper.Map<LibroDTO>(x));
        return Ok(new ResponseDTO { Code = (int)HttpStatusCode.OK, Data = libroDTO, Message = "Obtenemos los libros" });
    }

    /// <summary>
    /// Obtenemos libros por Id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("GetById/{id}")]
    public IActionResult GetById(int id)
    {
        try
        {
            var libro = libroRepository.GetByIdAsync(id).Result;
            var libroDTO = mapper.Map<LibroDTO>(libro);
            return Ok(new ResponseDTO { Code = (int)HttpStatusCode.OK, Data = libroDTO, Message = "Obtenemos los libros por id" });
        }
        catch (Exception ex)
        {
            return Ok(new ResponseDTO { Code = (int)HttpStatusCode.InternalServerError, Message = ex.Message });
        }
    }

    /// <summary>
    /// Insertamos un libro
    /// </summary>
    /// <param name="libroDTO"></param>
    /// <returns></returns>
    [HttpPost("InsertAsync")]
    public IActionResult Insert(LibroDTO libroDTO)
    {
        try
        {
            var libro = mapper.Map<Libro>(libroDTO);
            if (libroDTO != null)
            {
                libro = libroRepository.InsertAsync(libro).Result;
                libroDTO.LibroId = libro.LibroId;
            }
            return Ok(new ResponseDTO { Code = (int)HttpStatusCode.OK, Data = libroDTO });
        }
        catch (Exception ex)
        {

            return Ok(new ResponseDTO { Code = (int)HttpStatusCode.InternalServerError, Message = ex.Message });
        }

    }

    /// <summary>
    /// Metodo para actualizar un libro
    /// </summary>
    /// <param name="libroDTO"></param>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpPut("Update/{id}")]
    public IActionResult Update(LibroDTO libroDTO, int id)
    {
        try
        {
            var libro = libroRepository.GetByIdAsync(id).Result;
            if (libro == null)
                return Ok(new ResponseDTO { Code = (int)HttpStatusCode.NotFound, Message = "No encontrado" });

            libro = mapper.Map<Libro>(libroDTO);
            libro = libroRepository.UpdateAsync(libro).Result;
            return Ok(new ResponseDTO { Code = (int)HttpStatusCode.OK, Data = libroDTO });
        }
        catch (Exception ex)
        {
            return Ok(new ResponseDTO { Code = (int)HttpStatusCode.InternalServerError, Message = ex.Message });
        }
    }

    /// <summary>
    /// Metodo para eliminar un autor
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("DeleteAsync/{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            var libro = libroRepository.GetByIdAsync(id).Result;
            if (libro == null)
                return Ok(new ResponseDTO { Code = (int)HttpStatusCode.NotFound, Message = "No encontrado" });

            await libroRepository.DeleteAsync(id);
            return Ok(new ResponseDTO { Code = (int)HttpStatusCode.NoContent });

        }
        catch (Exception ex)
        {
            return Ok(new ResponseDTO { Code = (int)HttpStatusCode.InternalServerError, Message = ex.Message });
        }

    }

}
