﻿namespace ML
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string  Nombre { get; set; }
        public string  ApellidoPaterno { get; set; }
        public string  ApellidoMaterno { get; set; }
        public string  Correo { get; set; }
        public string  Password { get; set; }

        public List<object> Usuarios { get; set; }

    }
}
