using AutoMapper;
using BookRecord.BLL.DTOs;
using BookRecord.BLL.Repository;
using BookRecord.DAL.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BookRecord.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AutorController : ControllerBase
{
    private readonly IAutorRepository autorRepository;
    private readonly IMapper mapper;

    public AutorController(IAutorRepository autorRepository, IMapper mapper)
    {
        this.autorRepository = autorRepository;
        this.mapper = mapper;
    }

    /// <summary>
    /// Obtenemos los autores
    /// </summary>
    /// <returns></returns>
    [HttpGet("GetAll")]
    public IActionResult GetAll()
    {
        var autor = autorRepository.GetAll();
        var autorDTO = autor.Select(x => mapper.Map<AutorDTO>(x));
        return Ok(new ResponseDTO { Code = (int)HttpStatusCode.OK, Data = autorDTO, Message = "Obtenemos los autores" });
    }

    /// <summary>
    /// Obtenemos autores por Id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("GetById/{id}")]
    public IActionResult GetById(int id)
    {
        try
        {
            var autor = autorRepository.GetByIdAsync(id).Result;
            var autorDTO = mapper.Map<AutorDTO>(autor);
            return Ok(new ResponseDTO { Code = (int)HttpStatusCode.OK, Data = autorDTO, Message = "Obtenemos los autores" });
        }
        catch (Exception ex)
        {
            return Ok(new ResponseDTO { Code = (int)HttpStatusCode.InternalServerError, Message = ex.Message });
        }
    }

    /// <summary>
    /// Insertamos un autor
    /// </summary>
    /// <param name="autorDTO"></param>
    /// <returns></returns>
    [HttpPost("InsertAsync")]
    public IActionResult Insert(AutorDTO autorDTO)
    {
        try
        {
            var autor = mapper.Map<Autor>(autorDTO);
            if (autorDTO != null)
            {
                autor = autorRepository.InsertAsync(autor).Result;
                autorDTO.AutorId = autor.AutorId;
            }
            return Ok(new ResponseDTO { Code = (int)HttpStatusCode.OK, Data = autorDTO });
        }
        catch (Exception ex)
        {

            return Ok(new ResponseDTO { Code = (int)HttpStatusCode.InternalServerError, Message = ex.Message });
        }

    }

    /// <summary>
    /// Metodo para actualizar un autor
    /// </summary>
    /// <param name="autorDTO"></param>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpPut("Update/{id}")]
    public IActionResult Update(AutorDTO autorDTO, int id)
    {
        try
        {
            var autor = autorRepository.GetByIdAsync(id).Result;
            if (autor == null)
                return Ok(new ResponseDTO { Code = (int)HttpStatusCode.NotFound, Message = "No encontrado" });

            autor = mapper.Map<Autor>(autorDTO);
            autor = autorRepository.UpdateAsync(autor).Result;
            return Ok(new ResponseDTO { Code = (int)HttpStatusCode.OK, Data = autorDTO });
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
            var autor = autorRepository.GetByIdAsync(id).Result;
            if (autor == null)
                return Ok(new ResponseDTO { Code = (int)HttpStatusCode.NotFound, Message = "No encontrao" });

            await autorRepository.DeleteAsync(id);
            return Ok(new ResponseDTO { Code = (int)HttpStatusCode.NoContent });

        }
        catch (Exception ex)
        {
            return Ok(new ResponseDTO { Code = (int)HttpStatusCode.InternalServerError, Message = ex.Message });
        }
    
    }

}
