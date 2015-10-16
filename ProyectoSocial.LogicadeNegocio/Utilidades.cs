using System;
using System.Text;
using System.Security.Cryptography;

namespace ProyectoSocial.LogicadeNegocio
{
    public class Utilidades
    {

        private const int LengthBytesExtra = 4;

        public static string EncriptarClave(string clave)
        {
            
            var bytesExtra = new byte[LengthBytesExtra];

            var rng = RandomNumberGenerator.Create();
            rng.GetNonZeroBytes(bytesExtra);

            var claveBytes = Encoding.UTF8.GetBytes(clave);

            //Declaración de un arreglo de bytes que contendrá la clave en bytes + los bytes extra
            var claveMasBytesExtra = new byte[claveBytes.Length + bytesExtra.Length];

            //Copiar los bytes extra y la clave al arreglo claveMasBytesExtra
            Array.Copy(bytesExtra, 0, claveMasBytesExtra, 0, bytesExtra.Length);
            Array.Copy(claveBytes, 0, claveMasBytesExtra, bytesExtra.Length, claveBytes.Length);

            //Creación de la instacia del encriptador mediante Hash
            var csp = new SHA1CryptoServiceProvider();

            //Declarar un arreglo que contendrá la clave encriptada
            var claveCompletaHash = csp.ComputeHash(claveMasBytesExtra);

            //Declarar un arreglo que contendrá la clave encriptada + los bytes de control
            var claveFinal = new byte[bytesExtra.Length + claveCompletaHash.Length];

            //Copiar la clave en Hash + los bytes de control al arreglo claveFinal
            Array.Copy(bytesExtra, 0, claveFinal, 0, bytesExtra.Length);
            Array.Copy(claveCompletaHash, 0, claveFinal, bytesExtra.Length, claveCompletaHash.Length);

            //Convertir la clave final a string
            var claveEncriptada = Convert.ToBase64String(claveFinal);

            return claveEncriptada;
        }


        public static string DesencriptarClave(string claveEncriptada)
        {
            return "thepassword";
        }


        public static bool ValidarClave(string pClaveUsuario, string pClaveEncriptada)
        {
            bool aceptado = false;

            //Convertir la clave en formato Hash a arreglo de bytes
            byte[] claveHashBytes = Convert.FromBase64String(pClaveEncriptada);

            //Extraer los bytes de control
            int bytesDeControl = BitConverter.ToInt32(claveHashBytes, 0);

            //A la clave encriptada le quitamos los primeros 4 bytes
            byte[] claveSinBytesDeControl = new byte[claveHashBytes.Length - LengthBytesExtra];
            Array.Copy(claveHashBytes, LengthBytesExtra, claveSinBytesDeControl, 0, claveSinBytesDeControl.Length);

            //Convertir la clave digitada por el usuario en la ventana Login a bytes
            byte[] claveDigitadaBytes = Encoding.UTF8.GetBytes(pClaveUsuario);

            //Convertir los bytes de control a arreglo de bytes
            byte[] bytesExtraBytes = BitConverter.GetBytes(bytesDeControl);

            //Declaración de un arreglo que contendrá los bytes extra en formato de bytes +
            //la clave digitada por el usuario en formato de bytes
            byte[] claveUsuarioMasBytesExtra = new byte[bytesExtraBytes.Length + claveDigitadaBytes.Length];

            //Copiar los bytes extra en formato de bytes y la clave  digitada en formato de bytes
            Array.Copy(bytesExtraBytes, 0, claveUsuarioMasBytesExtra, 0, bytesExtraBytes.Length);
            Array.Copy(claveDigitadaBytes, 0, claveUsuarioMasBytesExtra,
                        bytesExtraBytes.Length, claveDigitadaBytes.Length);

            //Convertir en Hash la clave digitada por el usuario + los bytes de control
            SHA1CryptoServiceProvider csp = new SHA1CryptoServiceProvider();
            byte[] claveDigitadaMasBytesExtraHash = csp.ComputeHash(claveUsuarioMasBytesExtra);

            //Comparar byte por byte la clave digitada con la clave obtenida de la BD
            for (int i = 0; i < claveDigitadaMasBytesExtraHash.Length; i++)
            {
                if (claveDigitadaMasBytesExtraHash[i] != claveSinBytesDeControl[i])
                {
                    aceptado = false;
                    break;
                }

                aceptado = true;
            }

            return aceptado;
        }
       
    }

}
