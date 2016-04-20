using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SaveEmployee.DAL;

namespace SaveEmployee.BLL
{
    public class SemesterManager
    {

            SemesterGateway gateway = new SemesterGateway();
            public List<string> GetSemester()
            {
                return gateway.GetSemester();
            }
        
    }
}