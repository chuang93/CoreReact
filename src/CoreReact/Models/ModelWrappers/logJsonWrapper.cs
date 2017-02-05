using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreReact.Models.ModelWrappers
{
    public class LogJsonWrapper
    {
        public int PlayerID { get; set; }

        public String Season { get; set; }

        public String SeasonType { get; set; }

        public String Resource { get; set; }
        //TO DO: DECIDE IF OBJECT "PARAMETERS" IS NEEDED

        public List<String> Headers { get; set; }

        public List<List<String>>  RowSet { get; set; }
    }
}
