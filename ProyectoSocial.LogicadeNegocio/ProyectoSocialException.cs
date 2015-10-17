using System;
using System.Runtime.Serialization;

namespace ProyectoSocial.LogicadeNegocio
{
    public class ProyectoSocialException : Exception
    {
        public ProyectoSocialException() { }

        public ProyectoSocialException(string message) : base(message) { }

        public ProyectoSocialException(string message, Exception innerException) : base(message, innerException) { }

        protected ProyectoSocialException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
