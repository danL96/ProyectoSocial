using ProyectoSocial.AccesoADatos;
using ProyectoSocial.LogicadeNegocio;

namespace ProyectoSocial.InterfazGrafica
{
    public class AdministradorViewModel
    {
        private readonly Administradore _admin;
        private readonly ProyectoSocialEncrypter _encrypter = new ProyectoSocialEncrypter();

        public AdministradorViewModel(Administradore admin)
        {
            _admin = admin;
        }

        public long Id
        {
            get { return _admin.Id; }
        }

        public string Nombre
        {
            get { return _admin.Nombre; }
        }

        public string Apellido
        {
            get { return _admin.Apellido; }
        }

        public string Nick
        {
            get { return _admin.Nick; }
        }

        public string Pass
        {
            get
            {
                try
                {
                    return _encrypter.DecryptString(_admin.Pass);
                }
                catch (ProyectoSocialException)
                {
                    return string.Empty;
                }
            }
        }
    }
}
