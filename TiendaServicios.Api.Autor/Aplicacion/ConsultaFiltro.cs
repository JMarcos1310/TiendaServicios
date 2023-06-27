using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TiendaServicios.Api.Autor.Modelo;
using TiendaServicios.Api.Autor.Persistencia;

namespace TiendaServicios.Api.Autor.Aplicacion
{
    public class ConsultaFiltro
    {
        public class AutorUnico : IRequest<AutorLibro>
        {
            public string AutorGuid { get; set; }
        }
        public class Manejador : IRequestHandler<AutorUnico, AutorLibro>
        {
            //instancia de contexto 
            private readonly ContextoAutor _contexto;

            public Manejador(ContextoAutor Contexto)
            {
                _contexto = Contexto;
            }

            public async Task<AutorLibro> Handle(AutorUnico request, CancellationToken cancellationToken)

            {
                var autor = await _contexto.AutorLibro.Where(x => x.AutorLibroGuid == request.AutorGuid).FirstOrDefaultAsync();
                if (autor == null)
                {
                    throw new NotImplementedException("NO SE ENCONTRO EL AUTOR");
                }

                return autor;
            }





        }
    }
}
