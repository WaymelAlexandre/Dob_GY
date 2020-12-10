using Dob_Gy.Modules;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Dob_Gy.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Dob_GY_ControlController : ControllerBase
    {
        SqlConnectionStringBuilder stringBuilder =new SqlConnectionStringBuilder();
        IConfiguration configuration;

/// 

/////////////////////////////////////////////////Exceptions Task  not sure what is asking ////////////////////////////////////////////////////
        
        string connectionString = "";
        public Dob_GY_ControlController(IConfiguration IConfig){
            try
            {
                string connectionString =  @"Data Source=no.database.here.com;Initial Catalog=Is;
                                            Integrated Security=true; User ID =Wally; Password = Where;";
                SqlConnection conn = new SqlConnection(connectionString);
               
            }
            catch (SqlException ex)
            {
                System.Console.WriteLine(ex.Message);
            }
            finally
            {
                this.configuration = IConfig;
                this.stringBuilder.DataSource = this.configuration.GetSection("ConnectionDB").GetSection("Url").Value;
                this.stringBuilder.InitialCatalog = this.configuration.GetSection("ConnectionDB").GetSection("DataBase").Value;
                this.stringBuilder.UserID = this.configuration.GetSection("ConnectionDB").GetSection("User").Value;
                this.stringBuilder.Password = this.configuration.GetSection("ConnectionDB").GetSection("Pass").Value;
            }
            
            this.connectionString = stringBuilder.ConnectionString;
        }
///
///  
///
///
/// 
/// 
/// 
/// 
/// 
/// 
/// 
/// 
/// 
/// 
/// 
/// 
/// 
/// 
/// 
/// 
///         

/////////////////////////////////////////////////Read Task ////////////////////////////////////////////////////
        
/// <summary>
/// 1.	Read all movies from the database into a list named Movies.
/// </summary>
/// WORKING
/// 
//variable also use in step 4
        List<Movie> Movies = new List<Movie>();

        [HttpGet("ReadAllMovie")]
        public List<Movie> ReadAllMovie(){
            //variable
            string SelectMovies = "SELECT * FROM Movie";
            
            // Database Connection 
            SqlConnection conn = new SqlConnection(connectionString);
            //Database commande
            SqlCommand command = new SqlCommand(SelectMovies, conn);
            //database opend
            conn.Open();
            //code to the CRUD the database 
            //READ  SqlDataReader
            using (SqlDataReader reader = command.ExecuteReader()){

                while (reader.Read())
                {
                    Movies.Add(new Movie()
                    {
                        MovieNum = (int)reader[0], 
                        Title = (string)reader[1], 
                        ReleasYear = (short)reader[2], 
                        RuningTime = (short)reader[3]
                    });   
                }
            }
            conn.Close();
            return Movies; 
        }
///
/// 
///
///
/// 
/// 
/// 
/// 
/// 
/// 
/// 
/// 
/// 
/// 
/// 
/// 
/// 
/// 
/// 
/// 
/// 
/// <summary>
/// 2.	In your program access the database and display the titles 
/// for all the movies with title that begin with the word “The” (case insensitive)
/// </summary>
/// 
/// WORKING

        [HttpGet("TheMoviestart")]
        public List<string> TheMovie(){
            //variable
            List<string> MoviesbyTilte = new List<string>();
            string MovieTitle = "SELECT title FROM movie WHERE title like 'The%'";
            // Database Connection 
            SqlConnection conn = new SqlConnection(connectionString);
            //Database commande
            SqlCommand command = new SqlCommand(MovieTitle, conn);
            //database opend
            conn.Open();
            //code to the CRUD the database 
            using (SqlDataReader reader = command.ExecuteReader()){

                while (reader.Read()){
                    MoviesbyTilte.Add((string)reader[0]);   
                }
            }
            //close the database 
            // conn.Close();
            return MoviesbyTilte;
        }

///
/// 
///
///
/// 
/// 
/// 
/// 
/// 
/// 
/// 
/// 
/// 
/// 
/// 
/// 
/// 
/// /<summary>
/// 3.	Access the database and display all the titles 
/// for all movies that Luke Wilson has been cast in
/// </summary>
/// 
/// WORKING
/// 


        

        [HttpGet("find/{nameactor}")]   //Luke Wilson 
        public List<string> Lukewhereareyou(string nameactor){
            //variable
            string LukeWilson =$@"
            SELECT M.title 
            FROM movie M 
            INNER JOIN casting C ON M.MOVIENO=C.MOVIENO 
            INNER JOIN actor A ON C.ACTORNO=A.ACTORNO WHERE A.FULLNAME='{nameactor}'";
            
            List<string> nameofthemovie = new List<string>();
            // Database Connection 
            SqlConnection conn = new SqlConnection(connectionString);
            //Database commande
            SqlCommand command = new SqlCommand(LukeWilson, conn);
            //database opend
            conn.Open();

            using (SqlDataReader reader = command.ExecuteReader()){

                while (reader.Read()){
                    nameofthemovie.Add(reader[0].ToString());
                }
            }
            //need to ask how to returne a object
            conn.Close();
            return nameofthemovie;
                
        }


///
/// 
/// 
/// 
/// 
/// 
/// 
/// 
/// 
///
/// 
/// 
/// 
/// 
/// 
/// 
/// 
/// 
///
///  <summary>
/// 4.	Using the list Movies created in step one, 
/// display the total running time of all movies
/// </summary>
///https://www.codeproject.com/articles/823854/how-to-connect-sql-database-to-your-csharp-program
/// 
/// 
/// 
/// work mais pas sur de repondre a la question 
/// 
/// List<Movie> Movies = new List<Movie>();
/// 
/// 

    
        
        // int sum = totaltime.ConvertAll(Convert.ToInt32).Sum();
        //totaltime.ConvertAll(Convert.ToInt32).Sum();
        [HttpGet("Running")]

        public int CourPetitFille(){
            // List<int> totaltime = new List<int>();
            int total = 0;
        
            // foreach (Movie item in Movies)
            // {
            //     total.Add(item.RuningTime);
            //     //Sum(item.RuningTime => Convert.ToInt32(item.RuningTime)));
            //     // totaltime.(item.RuningTime);
            // }
            //return totaltime.Sum(x => Convert.ToInt32(x)).;
            // Convert.ToInt16(totaltime);
            // return totaltime.Sum(x => Convert.ToInt32(x));
            string SelectMovies = "SELECT * FROM Movie";
            
            // Database Connection 
            SqlConnection conn = new SqlConnection(connectionString);
            //Database commande
            SqlCommand command = new SqlCommand(SelectMovies, conn);
            //database opend
            conn.Open();
            //code to the CRUD the database 
            //READ  SqlDataReader
            using (SqlDataReader reader = command.ExecuteReader()){

                while (reader.Read())
                {
                    Movies.Add(new Movie()
                    {
                        MovieNum = (int)reader[0], 
                        Title = (string)reader[1], 
                        ReleasYear = (short)reader[2], 
                        RuningTime = (short)reader[3]
                    });   
                }
            }
            conn.Close();
            foreach (Movie T in Movies)
            {
                total += T.RuningTime;
            }
            return total;
        }
        
        // je comprend pas la pourquoi c est tj une list??
        //return Convert.ToInt16(totalrunTime);
        // return totalrunTime;
            
            
        

        /////////////////////////////////////////////////Update  Task ////////////////////////////////////////////////////



///
///  
/// 
/// 
/// 
/// 
/// 
/// 
/// 
///
/// 
/// 
/// 
/// 
/// 
/// 
/// 
/// 
///
/// <summary>
/// 1.	In your program, provide a way to change a movie’s runtime found by title.  
/// New title to be obtained via user input.  
/// Change must be reflected in the DB.
/// </summary>
/// 
/// 
/// 
/// 
/// 
/// 
/// NOT WORKING
/// 


        [HttpPatch("Update/movie")]
        public string UpdateMovieTitle([FromBody] UpdateRuntimeRequest request)
        {
            SqlConnection conn = new SqlConnection(this.connectionString);

            string queryString = $"Update Movie set [RunTime] = '{request.newRuntime}' Where Title = '{request.newtitle}'";
            
            SqlCommand command = new SqlCommand(queryString, conn);
            conn.Open();
            command.ExecuteNonQuery();

            // command.Parameters.AddWithValue("@Runtime", test.RuningTime);
            queryString = $"Select * From [Movie] Where [Title] = '{request.newtitle}'";
            command = new SqlCommand(queryString, conn);

            using(SqlDataReader reader = command.ExecuteReader()){
                while (reader.Read())
                {
                    Movie movie = new Movie()
                    {
                        MovieNum = (int)reader[0], 
                        Title = (string)reader[1], 
                        ReleasYear = (short)reader[2], 
                        RuningTime = (short)reader[3]
                    };
                }
            }   
            var row = command.ExecuteNonQuery().ToString();
            return row;
        }


/// 
///
/// <summary>
/// 2.	Provide a way to change an actor’s surname and fullname, 
/// found by givenname and surname.  
/// New surname to obtained via user input.  
/// Change must be reflected in the DB.
/// </summary>


        [HttpPut("Update/name")]
        public string changename([FromBody] Updatename newact){
            //variable
            List<Actor> Act = new List<Actor>();
            string queryString = $"UPDATE actor set SURNAME = {newact.SurName} WHERE GIVENNAME = {newact.GivenName}';";
            // Database Connection 
            SqlConnection conn = new SqlConnection(connectionString);
            //Database commande
            SqlCommand command = new SqlCommand(queryString, conn);

            queryString = $"UPDATE actor set fullName ='{newact.GivenName + newact.SurName}' where givenName = '{newact.GivenName}';";
            //"SELECT title FROM movie WHERE title like 'The%'";
            command = new SqlCommand(queryString, conn);
            //database opend
            conn.Open();
            //code to the CRUD the database 
            
            using (SqlDataReader reader = command.ExecuteReader()){

                while (reader.Read())
                {
                    Actor Act1 = new Actor()
                    {
                        ActorNum = (int)reader[0], 
                        FullName = (string)reader[1], 
                        GivenName = (string)reader[2], 
                        SurName = (string)reader[3]
                    };
                }
            }
            conn.Close();
            
            //var row = command.ExecuteNonQuery().ToString();
            return "ok";
        }
        


        // [HttpPut("Update/{givename}/{newName}")]
        // public string changename(string GIVENNAME, string newName){
        //     //variable
        //     string queryString = ($"UPDATE actor set SURNAME = @{newName} where GIVENNAME = @{GIVENNAME} ");
        //     // Database Connection 
        //     SqlConnection conn = new SqlConnection(connectionString);
        //     //Database commande
        //     SqlCommand command = new SqlCommand(queryString, conn);
        //     //database opend
        //     conn.Open();
        //     //code to the CRUD the database 

        //     command.Parameters.AddWithValue("@{newName}", test.RuningTime);


        //     //READ  SqlDataReader
        //     var result = command.ExecuteNonQuery();

        //     return result.ToString(); 
        // }



        
/////////////////////////////////////////////////Create   Task ////////////////////////////////////////////////////
///
/// 
/// 
/// 
/// 
/// 
/// 
/// 
/// 
///
/// 
/// 
/// 
/// 
/// 
/// 
/// 
/// 
///
/// <summary>
/// 1.	From user input, create a movie object. 
/// Use this object to create a new entry in the Movie table of the database
/// </summary>
/// 
/// 
/// 
/// 
/// 
/// 
/// 
/// WORKING







        

        //work find besoin d ajouter exeption for the time 
        [HttpPost("CreatMovie")]
        public string CreatMovie([FromBody] Movie newmovie){
            //variable
            string queryString = ($"INSERT INTO movie values (@MOVIENO, @TITLE, @RELYEAR, @RUNTIME)");
            // Database Connection 
            SqlConnection conn = new SqlConnection(connectionString);
            //Database commande
            SqlCommand command = new SqlCommand(queryString, conn);
            //database opend
            conn.Open();
            //code to the CRUD the database 
            command.Parameters.AddWithValue("@MOVIENO", newmovie.MovieNum);
            command.Parameters.AddWithValue("@TITLE", newmovie.Title);
            command.Parameters.AddWithValue("@RELYEAR", newmovie.ReleasYear);
            command.Parameters.AddWithValue("@RUNTIME", newmovie.RuningTime);
            //READ  SqlDataReader
            var result = command.ExecuteNonQuery();

            return result.ToString(); 
        }



/// 
/// 
/// 
/// 
/// 
/// 
/// 
///
/// 
/// 
/// 
/// 
/// 
/// 
/// 
/// 
///
/// <summary>
/// 2.	From user input, create an actor object.  
/// Use this object to create a new entry in the Actor table of the database
/// </summary>
/// 
/// 
/// 
/// 
/// 
/// 
/// WORKING
/// 

        
        
        [HttpPost("CreatActor")]
        public string CreatActor([FromBody]Actor NewActor){
            //variable
            string queryString = ($"INSERT INTO Actor values (@ACTORNO, @FULLNAME, @GIVENNAME, @SURNAME)");
            // Database Connection 
            SqlConnection conn = new SqlConnection(connectionString);
            //Database commande
            SqlCommand command = new SqlCommand(queryString, conn);
            //database opend
            conn.Open();
            //code to the CRUD the database 
            command.Parameters.AddWithValue("@ACTORNO", NewActor.ActorNum);
            command.Parameters.AddWithValue("@FULLNAME", NewActor.FullName);
            command.Parameters.AddWithValue("@GIVENNAME", NewActor.GivenName);
            command.Parameters.AddWithValue("@SURNAME", NewActor.SurName);
            //READ  SqlDataReader
            try
            {
                var result = command.ExecuteNonQuery();
                return result.ToString(); 
            }
            catch (System.Exception ex)
            {
                return "bug bug bug everywhere: " + ex.Message;
            }
        }






/// 
/// 
/// 
/// 
/// 
/// 
/// 
///
/// 
/// 
/// 
/// 
/// 
/// 
/// 
/// 
///
/// <summary>
/// 3.	Provide a way to cast an actor to a movie.
/// </summary>
/// 
/// 
/// 
/// 
/// 
///
/// 
/// 
/// 
/// 



        
        [HttpPost("CastActor")]
        public string CastActor([FromBody] Cast C){
            List<Cast> casssss = new List<Cast>();
            //variable
            string queryString = ($"INSERT INTO CASTING values ( @CASTID, @ACTORNO, @MOVIENO )");
            // Database Connection 
            SqlConnection conn = new SqlConnection(connectionString);
            //Database commande
            SqlCommand command = new SqlCommand(queryString, conn);
            //database opend
            conn.Open();
            //code to the CRUD the database 
            command.Parameters.AddWithValue("@CASTID", C.CASTID  );
            command.Parameters.AddWithValue("@ACTORNO", C.ACTORNO);
            command.Parameters.AddWithValue("@MOVIENO", C.MOVIENO);
            //READ  SqlDataReader
            // try
            // {
                var result = command.ExecuteNonQuery();
                return result.ToString() ; 
            // }
        //     catch (System.Exception ex)
        //     {
        //         return "bug bug bug everywhere: " + ex.Message;
        //     }
        }

    }
}


// 731085



