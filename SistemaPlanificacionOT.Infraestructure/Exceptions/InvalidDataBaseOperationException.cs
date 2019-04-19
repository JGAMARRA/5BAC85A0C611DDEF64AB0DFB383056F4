using System;

namespace SistemaPlanificacionOT.Infraestructure.Exceptions
{
    public class InvalidDataBaseOperationException : Exception
    {
        public InvalidDataBaseOperationException(string mensaje) : base(mensaje) { }

    }
}