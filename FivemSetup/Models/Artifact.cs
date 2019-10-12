using System;

namespace FivemSetup
{
    public class Artifact
    {
        public int id { get; private set; }
        
        public string code { get; private set; }
        
        public DateTime date { get; private set; }

        public Artifact(int id, string code, DateTime date)
        {
            this.id = id;
            this.code = code;
            this.date = date;
        }

        public string url ()
        {
            return $"https://runtime.fivem.net/artifacts/fivem/build_server_windows/master/{id.ToString()}-{code}/server.zip";
        }
        
        public override string ToString()
        {
            return $"{nameof(id)}: {id.ToString()}, {nameof(code)}: {code}, {nameof(date)}: {date.ToString()}";
        }
    }
}