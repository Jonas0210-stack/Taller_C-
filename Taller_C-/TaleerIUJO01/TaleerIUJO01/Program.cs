/*
 * Creado por SharpDevelop.
 * Usuario: usuario
 * Fecha: 17/4/2026
 * Hora: 10:53 a. m.
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.IO;

namespace TaleerIUJO01
{
	class Program
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("Taller 01");
			
			//el dato del usuario
			
			string RegistroUsuario = "       ID_67    ; JuanPerez; Evaluacion  ; 69";

			Console.WriteLine(RegistroUsuario);
			string registrolimpio = RegistroUsuario.Trim();
			Console.WriteLine(registrolimpio);
			
			string[] partes = registrolimpio.Split(';');
			string id = partes[0].Trim();
			string nombre = partes[1].Trim();
			string tarea = partes[2].Trim();
			string nota = partes[3].Trim();
			
			Console.WriteLine(string.Format("El ID es : {0} del usuario: {1} con la nota: {2}", id, nombre,nota));
			
			//flujo de archivos
			
			string rutaRaiz = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DatosIUJO");
			string rutaReportes = Path.Combine(rutaRaiz, "Reportes");

			if(!Directory.Exists(rutaReportes)){
				Directory.CreateDirectory(rutaReportes);
				Console.WriteLine("Creando Directorio de Reportes Correctamente");
			}
			
			string archivoTexto = Path.Combine(rutaReportes, "notas.txt");
			Console.WriteLine(archivoTexto);
			using(StreamWriter sw = new StreamWriter(archivoTexto,true))
			{
				sw.WriteLine(string.Format(" FECHA: {0: yyyy-MM-dd HH:mm} |ESTUDIANTE: {1} | NOTA: {2} |",DateTime.Now, nombre, nota));
			}
			
			
			//================DESAFIOS==================
			
			
			// Desafio 1
			
			string datos = "usuario;clave1234";
			
			string[] partesClave = datos.Split(';');
			string clave = partesClave[1];
			
			if (clave.Contains("1234"))
			{
				using (StreamWriter sw = new StreamWriter("Seguridad.txt", true))
				{
					sw.WriteLine("clave debil detectada");
				}
				Console.WriteLine("Se guardo en Seguridad.txt");
			}
			
			else
			{
				Console.WriteLine("La clave es segura");
			}
			
			// Desafio 2
			
			string origen = "original.jpg";
			string destino = "respaldo.jpg";
			
			try
			{
				using (FileStream fsOrigen = new FileStream(origen, FileMode.Open, FileAccess.Read))
					using (FileStream fsDestino = new FileStream(destino, FileMode.Create, FileAccess.Write))
				{
					byte[] buffer = new byte[1024];
					int bytesLeidos;
					
					Console.WriteLine("Iniciado Copiado de Imágenes...");
					
					while ((bytesLeidos = fsOrigen.Read(buffer, 0, buffer.Length)) > 0)
					{
						fsDestino.Write(buffer, 0, bytesLeidos);
					}
				}
				Console.WriteLine("La imagen se clono como respaldo.jpg");
			}
			
			catch (FileNotFoundException)
			{
				Console.WriteLine("no se encontró el archivo original.jpg");
			}
			
			catch (Exception ex)
			{
				Console.WriteLine("ocurrio un error inesperado" + ex.Message);
				
				//Desafio 3
				
				string rutaCarpeta = AppDomain.CurrentDomain.BaseDirectory;
				string[] archivos = Directory.GetFiles(rutaCarpeta);

				foreach (string archivo in archivos)
				{
					FileInfo info = new FileInfo(archivo);
					if (info.Length > 5120)
					{
						if (info.Name != "DesafiosVarios.exe" && info.Name != "original.jpg")
						{
							Console.WriteLine("Borrando archivo pesado: " + info.Name);
						}
					}
				}
				
				Console.Write("Press any key to continue . . . ");
				Console.ReadKey(true);
			}
		}
	}
}