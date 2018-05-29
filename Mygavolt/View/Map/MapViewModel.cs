using Microsoft.Maps.MapControl.WPF;
using Mygavolt.APIMygavolt;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Mygavolt.View.Map
{
    public class MapViewModel : ObservableObject, IPageViewModel
    {
        private string name;
        public string Name { get => name; set => name = value; }

        public IList<address_customers> ListAdress { get => listInterventions; set => listInterventions = value; }
        public List<Pushpin> ListPushpin { get => listPushpin; set => listPushpin = value; }

        private IList<address_customers> listInterventions;
        private List<Pushpin> listPushpin = new List<Pushpin>();

        public MapViewModel()
        {

            Adress();

        }

        public void Adress()
        {
            ListAdress = new List<APIMygavolt.address_customers>();
            using (APIMygavolt.Service1Client api = new APIMygavolt.Service1Client())
            {
                ListAdress = api.GetAddressCustomers();
            }
            foreach(address_customers ad in ListAdress)
            {
               string zipCode = ad.zip_code;
               string city = ad.city;
               string address = ad.street_name;
                string URL = "http://dev.virtualearth.net/REST/v1/Locations/FR/" + zipCode + "/" + city + "/" + address + "/" + "?includeNeighborhood=0&include=includeValue&maxResults=10&key=AlxUxDzyNQUSo6z1wmTbghqdkI8_RKJwCuZv5kiBSwLBQk_tadFUhmXJ3ZIHwURT";

                var json = new WebClient().DownloadString(URL);
                dynamic root = JsonConvert.DeserializeObject(json);

                foreach (var rs in root.resourceSets)
                {
                    foreach (var r in rs.resources)
                    {

                        Pushpin x = new Pushpin();
                        Location la = new Location();
                        la.Longitude = r.point.coordinates[0];
                        la.Latitude = r.point.coordinates[1];
                        x.Location = la;
                        listPushpin.Add(x);
                        
                    }
                }



            }
        }




    }
}
