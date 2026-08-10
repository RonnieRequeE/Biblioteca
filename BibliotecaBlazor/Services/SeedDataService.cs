using BibliotecaBlazor.Models;
using BibliotecaBlazor.Services;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BibliotecaBlazor.Services
{
    public class SeedDataService
    {
        private readonly LibroService _libroService;
        private readonly AutorService _autorService;
        private readonly CategoriaService _categoriaService;

        public SeedDataService(LibroService libroService, AutorService autorService, CategoriaService categoriaService)
        {
            _libroService = libroService;
            _autorService = autorService;
            _categoriaService = categoriaService;
        }

        public async Task SeedIfNeededAsync()
        {
            var autores = await _autorService.GetAsync();
            if (autores.Count == 0)
            {
                // Crear Categorías de Prueba
                var cat1 = new Categoria { Nombre = "Ficción", Descripcion = "Libros de literatura y narrativa", Area = "Literatura", Nivel = "General", FechaCreacion = DateTime.Today, Responsable = "Juan Pérez", Estado = "Activo" };
                var cat2 = new Categoria { Nombre = "Ciencia", Descripcion = "Libros científicos y de investigación", Area = "Tecnología", Nivel = "Avanzado", FechaCreacion = DateTime.Today, Responsable = "Ana Gómez", Estado = "Activo" };
                var cat3 = new Categoria { Nombre = "Historia", Descripcion = "Libros de acontecimientos históricos", Area = "Sociales", Nivel = "General", FechaCreacion = DateTime.Today, Responsable = "Juan Pérez", Estado = "Activo" };

                await _categoriaService.CreateAsync(cat1);
                await _categoriaService.CreateAsync(cat2);
                await _categoriaService.CreateAsync(cat3);

                // Crear Autores de Prueba
                var aut1 = new Autor { Nombre = "Gabriel", Apellido = "García Márquez", Nacionalidad = "Colombiana", FechaNacimiento = new DateTime(1927, 3, 6), Genero = "Masculino", Biografia = "Premio Nobel de Literatura en 1982.", Estado = "Activo" };
                var aut2 = new Autor { Nombre = "Albert", Apellido = "Einstein", Nacionalidad = "Alemana", FechaNacimiento = new DateTime(1879, 3, 14), Genero = "Masculino", Biografia = "Físico teórico creador de la relatividad.", Estado = "Activo" };
                var aut3 = new Autor { Nombre = "Isabel", Apellido = "Allende", Nacionalidad = "Chilena", FechaNacimiento = new DateTime(1942, 8, 2), Genero = "Femenino", Biografia = "Escritora y novelista superventas.", Estado = "Activo" };

                await _autorService.CreateAsync(aut1);
                await _autorService.CreateAsync(aut2);
                await _autorService.CreateAsync(aut3);

                // Crear Libros de Prueba
                var lib1 = new Libro { Titulo = "Cien años de soledad", Autor = "Gabriel García Márquez", Categoria = "Ficción", AnioPublicacion = 1967, Editorial = "Sudamericana", Estado = "Activo" };
                var lib2 = new Libro { Titulo = "La teoría de la relatividad", Autor = "Albert Einstein", Categoria = "Ciencia", AnioPublicacion = 1916, Editorial = "Editorial A", Estado = "Activo" };
                var lib3 = new Libro { Titulo = "La casa de los espíritus", Autor = "Isabel Allende", Categoria = "Ficción", AnioPublicacion = 1982, Editorial = "Plaza & Janés", Estado = "Activo" };

                await _libroService.CreateAsync(lib1);
                await _libroService.CreateAsync(lib2);
                await _libroService.CreateAsync(lib3);
            }
        }
    }
}
