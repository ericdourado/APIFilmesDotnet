using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;


namespace FilmesAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class FilmeController : Controller
{

    private FilmeContext _context;
    private IMapper _mapper;

    public FilmeController(FilmeContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult adicionaFilme([FromBody] CreateFilmeDto filmeDto)
    {
        //Filme filme = new Filme { 
        //    Titulo = filmeDto.Titulo,
        //    Genero = filmeDto.Genero,
        //    Duracao = filmeDto.Duracao 
        //};


        Filme filme = _mapper.Map<Filme>(filmeDto);
        _context.filmes.Add(filme);
        _context.SaveChanges();

        return CreatedAtAction(nameof(GetFilmesById),
                        new { id = filme.Id },
                        filme);

    }
    [HttpGet]
    public IEnumerable<ReadFilmeDto> GetFilmes([FromQuery] int skip = 0
                                        , [FromQuery] int take = 10)
    {
        return _mapper.Map<List<ReadFilmeDto>>(_context.filmes.Skip(skip).Take(take));
    }

    [HttpGet("{id}")]
    public IActionResult GetFilmesById(int id)
    {
        var filme = _context.filmes.FirstOrDefault(f => f.Id == id);
        if (filme == null) return NotFound();

        var filmeDto = _mapper.Map<ReadFilmeDto>(filme);
        return Ok(filmeDto);

    }
    [HttpPut("{id}")]
    public IActionResult updateFilme(int id, [FromBody] UpdateFilmeDto filmeDto)
    {
        var filme = _context.filmes.FirstOrDefault(f => f.Id == id);
        if (filme == null) return NotFound();
        Filme filme1 = _mapper.Map(filmeDto, filme);
        _context.SaveChanges();
        return NoContent();
    }
    [HttpDelete("{id}")]
    public IActionResult DeleteFilme(int id)
    {
        var filme = _context.filmes.FirstOrDefault(f => f.Id == id);
        if (filme == null) return NotFound();
        _context.Remove(filme);
        _context.SaveChanges();
        return NoContent();
    }


}
