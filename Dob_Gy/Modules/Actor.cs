namespace Dob_Gy.Modules
{
    public class Actor
    {
        

        public int ActorNum { get; set; }
        public string FullName { get; set; }
        public string GivenName { get; set; }
        public string SurName { get; set; }

        public string setFullName(string SurName, string GivenName){

            FullName = this.SurName + " " +this.GivenName; 
            return FullName;

        }
        public Actor(int actorNum, string fullName, string givenName, string surName)
        {
            ActorNum = actorNum;
            FullName = fullName;
            GivenName = givenName;
            SurName = surName;
        }
        public Actor(){}
        
        

        
        
    }
}