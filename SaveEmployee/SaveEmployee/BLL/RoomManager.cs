﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SaveEmployee.DAL;

namespace SaveEmployee.BLL
{
    public class RoomManager
    {
        RoomGateway gateway = new RoomGateway();

        public List<string> GetRooms()
        {
            return gateway.GetRooms();
        }
    }
}