using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodigoCesar
{
    class CesarCode
    {
        
        static void Main(string[] args)
        {
            Console.WriteLine("\nBienvenido a Código Cesar");
            char respuesta;
            do
            {
                //Bienvenida.
                Console.WriteLine("\nIntroduce el mensaje que desees cifrar(Ni los números ni los simbolos se cifraran): ");
                string mensaje = Console.ReadLine();

                //Pedimos el número de caracteres que queramos que se muevan las letras de nuestro mensaje.
                Console.WriteLine("\nIntroduce el número de caractares que se moveran cada letra de tu mensaje en el diccionario (tambien puedes ponerlo negativo): ");
                var numerointroducido = Console.ReadLine();

                //Repetir la pregunta con el mensaje cambiado en caso de que no haya introducido un int el usuario.
                int numero;
                while (!Int32.TryParse(numerointroducido, out numero))//Comprobar si lo que a entrado el usuario se puede pasar a número, si no, se le vuelve a preguntar.
                {
                    Console.WriteLine("\nLo que has introducido no era un número, intentalo de nuevo: ");
                    numerointroducido = Console.ReadLine();
                }
                numero = Int32.Parse(numerointroducido);

                Cifrado(mensaje, numero); //Activamos la función con los datos.

                //Pedimos 'y' o 'n' para repetir o no repetir el programa.
                do
                {
                    Console.WriteLine("\n¿Deseas cifrar otro mensaje? y/n: ");
                    var respuestaintroducida = Console.ReadLine();
                    
                    while (!char.TryParse(respuestaintroducida, out respuesta))//Comprobar si lo que a entrado el usuario se puede pasar a caracter, si no, se le vuelve a preguntar.
                    {
                        Console.WriteLine("\nLo que has introducido no es 'y' o 'n', intentalo de nuevo: ");
                        respuestaintroducida = Console.ReadLine();
                    }
                    respuesta = char.Parse(respuestaintroducida);

                } while (respuesta != 'y' && respuesta != 'n');

            } while (respuesta == 'y'); //El programa se repite.

            
            if(respuesta == 'n')//Sale del programa.
            {
                Console.WriteLine("\nGracias por usar Código Cesar, pulsa cualquier tecla para cerrar.");
                Console.ReadKey();
            }
        }

        private static void Cifrado(string m, int x) //Función de cifrado y descifrado.
        {
            //Diccionario minusculas.
            char[] diccionario = new char[]{'a','b','c','d','e','f','g','h',
                'i','j','k','l','m','n','ñ','o','p','q','r','s','t','u','v',
                'w','x','y','z'};

            //Creamos un diccionario en mayusculas.
            char[] diccionariomay = new char[diccionario.Length];
            for (int a = 0; a < diccionario.Length; a++)
            {
                diccionariomay[a] = char.ToUpper(diccionario[a]);
            }

            //Diccionario acentos.
            char[] diccionarioa = new char[]{'á','é','í','ó','ú'};

            //Diccionario acentos mayuscula.
            char[] diccionarioamay = new char[diccionarioa.Length];
            for (int a = 0; a < diccionarioa.Length; a++)
            {
                diccionarioamay[a] = char.ToUpper(diccionarioa[a]);
            }

            char[] mensajechar = m.ToCharArray();//Mensaje que hemos introducido y cambiaremos.

            //Limpia acentos
            for(int i = 0; i < mensajechar.Length; i++)
            {
                if (mensajechar[i] == 'á'|| mensajechar[i] == 'à'|| mensajechar[i] == 'ä'|| mensajechar[i] == 'â') mensajechar[i] = 'a';
                if (mensajechar[i] == 'Á'|| mensajechar[i] == 'À'|| mensajechar[i] == 'Ä'|| mensajechar[i] == 'Â') mensajechar[i] = 'A';
                if (mensajechar[i] == 'é'|| mensajechar[i] == 'è'|| mensajechar[i] == 'ë'|| mensajechar[i] == 'ê') mensajechar[i] = 'e';
                if (mensajechar[i] == 'É'|| mensajechar[i] == 'È'|| mensajechar[i] == 'Ë'|| mensajechar[i] == 'Ê') mensajechar[i] = 'E';
                if (mensajechar[i] == 'í'|| mensajechar[i] == 'ì'|| mensajechar[i] == 'ï'|| mensajechar[i] == 'î') mensajechar[i] = 'i';
                if (mensajechar[i] == 'Í'|| mensajechar[i] == 'Ì'|| mensajechar[i] == 'Ï'|| mensajechar[i] == 'Î') mensajechar[i] = 'I';
                if (mensajechar[i] == 'ó'|| mensajechar[i] == 'ò'|| mensajechar[i] == 'ö'|| mensajechar[i] == 'ô') mensajechar[i] = 'o';
                if (mensajechar[i] == 'Ó'|| mensajechar[i] == 'Ò'|| mensajechar[i] == 'Ö'|| mensajechar[i] == 'Ô') mensajechar[i] = 'O';
                if (mensajechar[i] == 'ú'|| mensajechar[i] == 'ù'|| mensajechar[i] == 'ü'|| mensajechar[i] == 'û') mensajechar[i] = 'u';
                if (mensajechar[i] == 'Ú'|| mensajechar[i] == 'Ù'|| mensajechar[i] == 'Ü'|| mensajechar[i] == 'Û') mensajechar[i] = 'U';
            }

            //Recorre todos los caracteres del mensaje.
            for(int i = 0; i < mensajechar.Length; i++)
            {
                char caracterrecorrido = mensajechar[i];

                //Busca en cada caracter la coincidencia con el diccionario.
                for (int y = 0; y < diccionario.Length && y < diccionariomay.Length; y++) //Comprueba el diccionario de mayusculas y minusculas.
                {
                    char diccionariorecorrido = diccionario[y];
                    char diccionariorecorridomay = diccionariomay[y];

                    //Busca coincidencias de el caracter de nuestro mensaje con el del diccionario.

                    // Condicional para el diccionario de minusculas cuando coincide el caracter.
                    if (caracterrecorrido == diccionariorecorrido)
                    {
                        int letra = y + x; //la letra que debe ser es la suma de nuestra posicion (y) en el diccionario más la cantidad que queremos mover (x).
                        int nuevoindice = 0;

                        //Si la letra es mayor o igual(porque si es igual es 27 y se sale, porque empieza a contar desde 0) que la longitud del diccionario restale la longitud, ya que volvemos a hacer una vuelta al diccionario.
                        if (letra >= diccionario.Length)
                        {
                            nuevoindice = letra - diccionario.Length;
                            while (nuevoindice >= diccionario.Length) nuevoindice -= diccionario.Length;
                            mensajechar[i] = diccionario[nuevoindice];
                            break;
                        }

                        //Si la letra es menor que la longitud del diccionario sumale la longitud, ya que si no, nos vamos hacia atras.
                        if (letra < 0)
                        {
                            nuevoindice = letra + diccionario.Length;
                            while (nuevoindice < 0) nuevoindice += diccionario.Length;
                            mensajechar[i] = diccionario[nuevoindice];
                            break;
                        }
                        mensajechar[i] = diccionario[letra];
                        break;
                    }

                    // Condicional para el diccionario de mayusculas (Lo mismo pero con mayusculas).
                    if (caracterrecorrido == diccionariorecorridomay)
                    {
                        int letra = y + x;
                        int nuevoindice = 0;
                        if (letra >= diccionariomay.Length)
                        {
                            nuevoindice = letra - diccionariomay.Length;
                            while (nuevoindice >= diccionariomay.Length) nuevoindice -= diccionariomay.Length;
                            mensajechar[i] = diccionariomay[nuevoindice];
                            break;
                        }

                        if (letra < 0)
                        {
                            nuevoindice = letra + diccionariomay.Length;
                            while (nuevoindice < 0) nuevoindice += diccionariomay.Length;
                            mensajechar[i] = diccionariomay[nuevoindice];
                            break;
                        }
                        mensajechar[i] = diccionariomay[letra];
                        break;
                    }
                }
            }
            //Resultado de nuestra función.
            Console.WriteLine("\nEste es tu mensaje cifrado: ");
            Console.WriteLine(mensajechar);
            Console.WriteLine("Introduce el mismo número en negativo para descodificar.");
        }
    }
}
