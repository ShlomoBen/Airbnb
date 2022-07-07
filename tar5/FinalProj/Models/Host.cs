using FinalProj.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProj.Models
{
    public class Host
    {
        String hostID;
        String host_name;
        string host_since;
        String host_about;
        String calculated_host_listings_count;

        public Host()
        {

        }

        public Host(string hostID, string host_name, string host_since, string host_about, string calculated_host_listings_count)
        {
            this.hostID = hostID;
            this.host_name = host_name;
            this.host_since = host_since;
            this.host_about = host_about;
            this.calculated_host_listings_count = calculated_host_listings_count;
        }

        public string HostID { get => hostID; set => hostID = value; }
        public string Host_name { get => host_name; set => host_name = value; }
        public string Host_since { get => host_since; set => host_since = value; }
        public string Host_about { get => host_about; set => host_about = value; }
        public string Calculated_host_listings_count { get => calculated_host_listings_count; set => calculated_host_listings_count = value; }
    }

    //public List<Host> GetAllHost_Data()
    //{
    //    DBservices DB = new DBservices();
    //    return DB.GetAllHost_Data();
    //}
}