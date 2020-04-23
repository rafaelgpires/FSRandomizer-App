using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSRandomizer
{
    class cl_readHash
    {
        private string hash;
        
        public void main()
        {

        }

        private void getHash()
        {
            WebClient client = new WebClient();
            string hash = client.DownloadString("");
        }
    }
}
