using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SaveEmployee.DAL;

namespace SaveEmployee.BLL
{
    public class ResultManager
    {
        ResultGateway gateway = new ResultGateway();
        public List<string> GetResults()
        {
            return gateway.GetResults();
        }
    }
}