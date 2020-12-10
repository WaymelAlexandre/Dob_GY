namespace Dob_Gy.Modules{
    public class UpdateRuntimeRequest {

        
        public string newtitle { get; set; }
        public short newRuntime { get; set; }

        public UpdateRuntimeRequest (string newtitle, short newRuntime) {
            this.newtitle = newtitle;
            this.newRuntime = newRuntime;

        }
        public UpdateRuntimeRequest (){}
    }
}