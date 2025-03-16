using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Models;

public class Filme
{
    [Required(ErrorMessage ="O Título é obrigatório")]
    public string Titulo { get; set; }
    [Required(ErrorMessage = "O Genero é obrigatório")]
    public string Genero { get; set; }
    [Required(ErrorMessage = "A Duração é obrigatória")]
    [Range(70,600, ErrorMessage ="A Duração deve ser entre 70 a 600 segundos para ser considerado um filme")]
    public string Duracao { get; set; }

}
