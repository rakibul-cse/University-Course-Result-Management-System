using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UCRMS.DAL;

namespace UCRMS.BLL
{
    public class RoomAllocateManager
    {
        private RoomAllocateGetway _roomAllocateGetway=new RoomAllocateGetway();
        internal string SaveRoomAllocate(Models.RoomAllocate roomAllocate)
        {
            try
            {
                return _roomAllocateGetway.SaveRoomAllocate(roomAllocate);
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message); 
            }
        }
    }
}