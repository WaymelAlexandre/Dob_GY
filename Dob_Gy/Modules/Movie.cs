using System;

namespace Dob_Gy.Modules {
    public class Movie {
        
        public int MovieNum { get; set; }
        public string Title { get; set; }
        public short ReleasYear { get; set; }
        public short RuningTime { get; set; }


        public Movie (){}
        public Movie (int movieNum, string title, short releasYear, short runingTime) {
            this.MovieNum = movieNum;
            this.Title = title;
            this.ReleasYear = releasYear;
            this.RuningTime = runingTime;

        }
        public Movie (short runingTime) {
            
            this.RuningTime = runingTime;

        }
        public int NumActors () {
            return this.MovieNum;
        }

        public int GetAgeMovie () {
            //need to check this 

            return DateTime.Now.Year - ReleasYear;
        }
        public string getallinmovie(){
            return $"(MovieNum{this.MovieNum} \n Title = {this.Title} \n ReleasYear = {this.ReleasYear} \n RuningTime = {this.RuningTime})";
        }

    }
}