using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Quantify Usings
using Avontus.Core;
using Avontus.Core.Data;
using Avontus.Rental.Library;
using Avontus.Rental.Library.Security;

namespace Quantify.API
{
    class Program
    {
        private static object asd;

        static void Main(string[] args)
        {

            AvontusPrincipal.Logout();
            bool success = AvontusPrincipal.Login("storrealba", "Algo.008");
            if (success)
                Console.WriteLine("Login successful");
            else
            {
                Console.WriteLine("Login failed");
                Console.WriteLine("Press any key to continue...");
                Console.ReadLine();
                return;
            }

            StockingLocationList jobs = StockingLocationList.GetJobsites(false, JobTreeNodeDisplayType.Name, Guid.Empty);


            foreach (StockingLocationListItem item in jobs)
            {
                Console.WriteLine("CustomerName :" + item.CustomerName); // "   BusinessPartnerID : " + Bpat.BusinessPartnerID.ToString());

                Console.WriteLine("Press any key to continue...");
                Console.ReadLine();

            }



            BusinessPartnerComboList BpatList = BusinessPartnerComboList.GetCustomerComboList(Guid.Empty, ActiveStatus.Active, ActiveStatus.Active, true, true);

            //obteniendo los ID de todos los Patner 

            foreach (BusinessPartnerListItem Bpat in BpatList)
            {

                //el atributo Bpat.PartnerNumber tiene nulos 
                Console.WriteLine("Name :" + Bpat.Name); // "   BusinessPartnerID : " + Bpat.BusinessPartnerID.ToString());

            }

            //Avontus.Core.Data.SafeDataReader dr = new Avontus.Core.Data.SafeDataReader(drr);

            // ProductListItem  
            //st = ProductListItem.GetProductListItem(SafeDataReader);

            StockedProductList Plist = StockedProductList.GetSerializedStockedProductList(Guid.Empty);

            foreach (StockedProductListItem ProItem in Plist)
            {
                Console.WriteLine("PartNumber :" + ProItem.PartNumber + " Description :" + ProItem.Description);
            }


            String Str = "algo";

            



            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();




            foreach (StockingLocationListItem job in jobs)
            {
                Console.WriteLine(job.Name);     
            }
                        
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }
    }


}
