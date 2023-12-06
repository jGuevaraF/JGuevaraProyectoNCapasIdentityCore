using Azure.Core;

namespace BL
{
    public class Usuario
    {
        
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DL.PruebaIdentityContext context = new DL.PruebaIdentityContext())
                {
                    var query = (from usuario in context.Usuarios
                                 select new
                                 {
                                     IdUsuario = usuario.IdUsuario,
                                     Nombre = usuario.Nombre,
                                     ApellidoPaterno = usuario.ApellidoPaterno,
                                     Correo = usuario.Email
                                 }).ToList();

                    if(query.Count > 0 )
                    {
                        result.Objects = new List<object>();
                        foreach(var user in query )
                        {
                            ML.Usuario usuario = new ML.Usuario();
                            usuario.IdUsuario = user.IdUsuario;
                            usuario.Nombre = user.Nombre;
                            usuario.ApellidoPaterno= user.ApellidoPaterno;
                            usuario.Correo = user.Correo;
                            result.Objects.Add(usuario);

                        }
                        result.Correct = true;
                    }
                }
            } catch (Exception e)
            {
                result.Correct = false;
                result.ErrorMessage = e.InnerException.Message;
                result.Ex = e;
            }

            return result;
        }

        public static ML.Result Add(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.PruebaIdentityContext context = new DL.PruebaIdentityContext())
                {
                    DL.Usuario user = new DL.Usuario();
                    user.Nombre = usuario.Nombre;
                    user.ApellidoPaterno = usuario.ApellidoPaterno;
                    user.ApellidoMaterno = usuario.ApellidoMaterno;
                    user.Email = usuario.Correo;
                    user.Password = usuario.Password;

                    context.Usuarios.Add(user);
                    int query = context.SaveChanges();

                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se pudo agregar el proveedor";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

    }
}
