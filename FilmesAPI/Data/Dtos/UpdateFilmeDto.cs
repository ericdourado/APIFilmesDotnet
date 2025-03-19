using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.Dtos;

public class UpdateFilmeDto
{

    [Required(ErrorMessage = "O Título é obrigatório")]
    public string Titulo { get; set; }
    [Required(ErrorMessage = "O Genero é obrigatório")]
    [StringLength(50, ErrorMessage ="O Genero não pode exceder 50 caracteres")]
    public string Genero { get; set; }
    [Required(ErrorMessage = "A Duração é obrigatória")]
    [Range(70, 600, ErrorMessage = "A Duração deve ser entre 70 a 600 segundos para ser considerado um filme")]
    public int Duracao { get; set; }
}
