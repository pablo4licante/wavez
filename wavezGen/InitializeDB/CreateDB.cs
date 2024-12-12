
/*PROTECTED REGION ID(CreateDB_imports) ENABLED START*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using WavezGen.ApplicationCore.EN.Wavez;
using WavezGen.ApplicationCore.CEN.Wavez;
using WavezGen.Infraestructure.Repository.Wavez;
using WavezGen.Infraestructure.CP;
using WavezGen.ApplicationCore.Exceptions;

using WavezGen.ApplicationCore.CP.Wavez;
using WavezGen.Infraestructure.Repository;
using NHibernate;
using WavezGen.ApplicationCore.Enumerated.Wavez;

/*PROTECTED REGION END*/
namespace InitializeDB
{
    public class CreateDB
    {
        public static void Create(string databaseArg, string userArg, string passArg)
        {
            String database = databaseArg;
            String user = userArg;
            String pass = passArg;

            // Conex DB
            SqlConnection cnn = new SqlConnection(@"Server=(local)\sqlexpress; database=master; integrated security=yes");

            // Order T-SQL create user
            String createUser = @"IF NOT EXISTS(SELECT name FROM master.dbo.syslogins WHERE name = '" + user + @"')
                BEGIN
                    CREATE LOGIN [" + user + @"] WITH PASSWORD=N'" + pass + @"', DEFAULT_DATABASE=[master], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
                END";

            //Order delete user if exist
            String deleteDataBase = @"if exists(select * from sys.databases where name = '" + database + "') DROP DATABASE [" + database + "]";
            //Order create databas
            string createBD = "CREATE DATABASE " + database;
            //Order associate user with database
            String associatedUser = @"USE [" + database + "];CREATE USER [" + user + "] FOR LOGIN [" + user + "];USE [" + database + "];EXEC sp_addrolemember N'db_owner', N'" + user + "'";
            SqlCommand cmd = null;

            try
            {
                // Open conex
                cnn.Open();

                //Create user in SQLSERVER
                cmd = new SqlCommand(createUser, cnn);
                cmd.ExecuteNonQuery();

                //DELETE database if exist
                cmd = new SqlCommand(deleteDataBase, cnn);
                cmd.ExecuteNonQuery();

                //CREATE DB
                cmd = new SqlCommand(createBD, cnn);
                cmd.ExecuteNonQuery();

                //Associate user with db
                cmd = new SqlCommand(associatedUser, cnn);
                cmd.ExecuteNonQuery();

                System.Console.WriteLine("DataBase create sucessfully..");
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
                throw;
            }
            finally
            {
                if (cnn.State == ConnectionState.Open)
                {
                    cnn.Close();
                }
            }
        }

        public static void InitializeData()
        {
            try
            {
                // Initialising  CENs
                UsuarioRepository usuariorepository = new UsuarioRepository();
                UsuarioCEN usuariocen = new UsuarioCEN(usuariorepository);
                AdminRepository adminrepository = new AdminRepository();
                AdminCEN admincen = new AdminCEN(adminrepository);
                ComunidadRepository comunidadrepository = new ComunidadRepository();
                ComunidadCEN comunidadcen = new ComunidadCEN(comunidadrepository);
                ColaReprodRepository colareprodrepository = new ColaReprodRepository();
                ColaReprodCEN colareprodcen = new ColaReprodCEN(colareprodrepository);
                CancionRepository cancionrepository = new CancionRepository();
                CancionCEN cancioncen = new CancionCEN(cancionrepository);
                PlaylistRepository playlistrepository = new PlaylistRepository();
                PlaylistCEN playlistcen = new PlaylistCEN(playlistrepository);
                ComentarioRepository comentariorepository = new ComentarioRepository();
                ComentarioCEN comentariocen = new ComentarioCEN(comentariorepository);



                /*PROTECTED REGION ID(initializeDataMethod) ENABLED START*/
                // Create repositories
                UsuarioRepository usuarioRepository = new UsuarioRepository();
                PlaylistRepository playlistRepository = new PlaylistRepository();
                ColaReprodRepository colaReprodRepository = new ColaReprodRepository();
                CancionRepository cancionRepository = new CancionRepository();
                NotificacionRepository notificacionRepository = new NotificacionRepository();
                ComunidadRepository comunidadRepository = new ComunidadRepository();

                // Create CENs
                UsuarioCEN usuarioCEN = new UsuarioCEN(usuarioRepository);
                PlaylistCEN playlistCEN = new PlaylistCEN(playlistRepository);
                ColaReprodCEN colaReprodCEN = new ColaReprodCEN(colaReprodRepository);
                CancionCEN cancionCEN = new CancionCEN(cancionRepository);
                NotificacionCEN notificacionCEN = new NotificacionCEN(notificacionRepository);
                ComunidadCEN comunidadCEN = new ComunidadCEN(comunidadRepository);

                // Create users
                string user1 = usuarioCEN.Nuevo("user1", "User One", "password1", "user1@example.com", "foto1");
                string user2 = usuarioCEN.Nuevo("user2", "User Two", "password2", "user2@example.com", "foto2");
                Console.WriteLine("Users created: " + user1 + ", " + user2);

                // Create playlists
                int playlist1 = playlistCEN.Nuevo("Playlist One", "portada1", user1);
                int playlist2 = playlistCEN.Nuevo("Playlist Two", "portada2", user2);
                Console.WriteLine("Playlists created: " + playlist1 + ", " + playlist2);

                // Create colaReprod
                int colaReprod1 = colaReprodCEN.Nuevo(user1);
                int colaReprod2 = colaReprodCEN.Nuevo(user2);
                Console.WriteLine("ColaReprod created: " + colaReprod1 + ", " + colaReprod2);

                // Create canciones
                int cancion1 = cancionCEN.Nuevo("Cancion One", WavezGen.ApplicationCore.Enumerated.Wavez.GenerosEnum.Rock, DateTime.Now, "https://img.freepik.com/foto-gratis/disco-vinilo-aislado_469584-14.jpg?semt=ais_hybrid", user1, 0, "https://voluntariosacd.infinityfreeapp.com/audio.mp3");
                int cancion2 = cancionCEN.Nuevo("Cancion Two", WavezGen.ApplicationCore.Enumerated.Wavez.GenerosEnum.Pop, DateTime.Now, "https://images.pexels.com/photos/2746823/pexels-photo-2746823.jpeg?auto=compress&cs=tinysrgb&dpr=1&w=500", user2, 0, "https://voluntariosacd.infinityfreeapp.com/audio.mp3");
                Console.WriteLine("Canciones created: " + cancion1 + ", " + cancion2);

                // Create comunidades
                Enum comunidad1 = comunidadCEN.Nuevo(GenerosEnum.Soul);
                Enum comunidad2 = comunidadCEN.Nuevo(GenerosEnum.Funk);
                Enum comunidad3 = comunidadCEN.Nuevo(GenerosEnum.Latino);
                Enum comunidad4 = comunidadCEN.Nuevo(GenerosEnum.Metal);
                Enum comunidad5 = comunidadCEN.Nuevo(GenerosEnum.Pop);
                Enum comunidad6 = comunidadCEN.Nuevo(GenerosEnum.KPop);
                Enum comunidad7 = comunidadCEN.Nuevo(GenerosEnum.HipHop);
                Enum comunidad8 = comunidadCEN.Nuevo(GenerosEnum.Alternativo);
                Console.WriteLine("Comunidades created: " + comunidad1 + ", " + comunidad2 + ", " + comunidad3 + ", " + comunidad4 + ", " + comunidad5 + ", " + comunidad6 + ", " + comunidad7 + ", " + comunidad8);

                // Add canciones to playlists
                playlistCEN.AddCancion(playlist1, new List<int> { cancion1 });
                playlistCEN.AddCancion(playlist2, new List<int> { cancion2 });
                Console.WriteLine("Canciones added to playlists");

                // Add canciones to colaReprod
                colaReprodCEN.AgregarCancion(colaReprod1, new List<int> { cancion1 });
                colaReprodCEN.AgregarCancion(colaReprod2, new List<int> { cancion2 });
                Console.WriteLine("Canciones added to colaReprod");


                // Reproduce canciones
                cancionCEN.ReproducirCancion(cancion1);
                cancionCEN.ReproducirCancion(cancion2);
                Console.WriteLine("Canciones reproduced");

                CancionEN cancion_para_noti = cancionCEN.DameCancionPorOID(cancion1);
                UsuarioEN usuario_para_noti = usuarioCEN.DameUsuarioPorOID(user1);

                UsuarioEN usuario2 = usuarioCEN.DameUsuarioPorOID(user2);
                IList<UsuarioEN> lista_usuarios = new List<UsuarioEN> { usuario2 };
                Console.WriteLine("Lista usuarios : " + lista_usuarios[0].Usuario);
                int notificacion1 = notificacionCEN.Nuevo(cancion_para_noti.FotoPortada, "DE LA DB", DateTime.Now, "cancion", usuario_para_noti, lista_usuarios, cancion_para_noti, null);

                /*PROTECTED REGION END*/

            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}
