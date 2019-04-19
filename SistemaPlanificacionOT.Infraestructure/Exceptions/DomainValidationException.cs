using System;

namespace SistemaPlanificacionOT.Infraestructure.Exceptions
{
    public class DomainValidationException : Exception
    {
        public DomainValidationException(string mensaje) : base(mensaje) { }
    }
}