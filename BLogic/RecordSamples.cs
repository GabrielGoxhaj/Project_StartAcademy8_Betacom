using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartAccademy8.BLogic
{
    public record RecordSamples(string server, string db, string table)
    {
        public string Server => server;
        public string DB => db;
        public string Table => table;
        public string GetDbCOnnectionString()
        { return DB; }
    }
}
