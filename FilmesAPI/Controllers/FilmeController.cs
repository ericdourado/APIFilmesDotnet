using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class FilmeController : Controller
{
    private List<Filme> filmes = new List<Filme>();

    [HttpPost]
    public void adicionaFilme([FromBody] Filme filme)
    {


        filmes.Add(filme);




    }

}
