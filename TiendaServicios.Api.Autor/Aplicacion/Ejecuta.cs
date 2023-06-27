using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace TiendaServicios.Api.Autor.Aplicacion
{
    public class Ejecuta : IRequest
    {
        public string Nombre { get; set; }
        public string Apellido {get; set;}
        public DateTime? FechaNacimiento { get; set; }
    }
    public class Manejador : IRequestHandler<Ejecuta>
    {
     public Task<Unit>Handle(Ejecuta request, CancellationToken cancellationToken )
        {
            throw new NotImplementedException();
        }
    }
}
