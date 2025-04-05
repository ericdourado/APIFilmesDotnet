﻿using FilmesAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmesAPI.Data;

public class FilmeContext : DbContext
{
    public FilmeContext(DbContextOptions<FilmeContext> opts)
        : base(opts)
    {
        
    }

    public DbSet<Filme> filmes { get; set; }
    public DbSet<Cinema> Cinemas { get; set; } 
    public DbSet<Endereco> Enderecos { get; set;}
    //public object Enderecos { get; internal set; }
}
