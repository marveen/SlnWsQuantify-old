using System;
using System.IO;
// Quantify Usings
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

            string Conex = Avontus.Rental.Library.Settings.CommonConfigurationSettings.ConnectionString;// = "Data Source=quantify-srv02;Initial Catalog=SQLUNtest;MultipleActiveResultSets=True;User ID=storrealba;Password=Algo.008";
            Avontus.Rental.Library.Settings.CommonConfigurationSettings.ConnectionString = "Data Source=quantify-srv02\\SQLUNtest;Initial Catalog=ASIRentalManager;User ID=ASIUser;Password=pwdForAvontus;MultipleActiveResultSets=True;";

            bool success = AvontusPrincipal.Login("storrealba", "Algo.008");
            
            
            //Avontus.Rental.Library.Settings.CommonConfigurationSettings.ConnectionString = "Data Source=quantify-srv02;Initial Catalog=SQLUNtest;MultipleActiveResultSets=True;User ID=storrealba;Password=Algo.008";

            if (success)
                Console.WriteLine("Login successful");
            else
            {
                Console.WriteLine("Login failed");
                Console.WriteLine("Press any key to continue...");
                //Console.ReadLine();
                return;
            }


         

            ////JobSiteList  Jobsi = JobSiteList.GetJobSiteList(List<Guid> JobSites)



            //StockingLocationList jobs = StockingLocationList.GetJobsites(false, JobTreeNodeDisplayType.Name, Guid.Empty);

            //foreach (StockingLocationListItem item in jobs)
            //{
            //    //Console.WriteLine("CustomerName :" + item.CustomerName); // "   BusinessPartnerID : " + Bpat.BusinessPartnerID.ToString());


            //    StockingLocation Local = StockingLocation.GetStockingLocation(item.StockingLocationID, true);



            //    foreach (StockedProduct prod in Local.StockedProducts)
            //    {
            //        /*
            //        Console.WriteLine(prod.PartNumber);
            //        Console.WriteLine(prod.Description);
            //        Console.WriteLine(prod.Weight);*/
            //    }





            //}



           
            //Console.WriteLine("Press any key to continue...");
            //Console.ReadLine();


            BusinessPartnerComboList BpatList = BusinessPartnerComboList.GetCustomerComboList(Guid.Empty, ActiveStatus.Active, ActiveStatus.Active,false, false);

            //obteniendo los ID de todos los Patner 
            System.IO.StreamWriter file = new System.IO.StreamWriter("C:\\Report Importer\\OutPut\\BusinessPartnerComboList.csv");
            int value = 0;
            value = 1;

            String StrBpatId = "";


            BusinessPartnerCollection bcol = BusinessPartnerCollection.GetBusinessPartnerCollection(PartnerTypes.All, ActiveStatus.Both, ActiveStatus.Both);
            int Count = bcol.Count;




            foreach (BusinessPartnerListItem Bpat in BpatList)
            {
                //el atributo Bpat.PartnerNumber tiene nulos 
                //Console.WriteLine("Name :" + Bpat.Name); // "   BusinessPartnerID : " + Bpat.BusinessPartnerID.ToString());  

                String StrNumber = value.ToString() + "_NULL";

                if (Bpat.PartnerNumber != null)
                {
                    StrNumber = Bpat.PartnerNumber.ToString();

                    //con cada id que no es nulo trae todo el objeto bussines patner 
                    BusinessPartner Patner = BusinessPartner.GetBusinessPartnerByNumber(StrNumber);
                    file.WriteLine("Name|" + Patner.Name + "| BusinessPartnerID|" + Patner.BusinessPartnerID.ToString() + "| PartnerNumber|" + StrNumber);
                    StrBpatId = Patner.BusinessPartnerID.ToString();


                    //Try
                    StockingLocationList Slist = StockingLocationList.GetJobsites(false, JobTreeNodeDisplayType.Name, Bpat.BusinessPartnerID);
                    int count2 = Slist.Count;


                }
                                
                

                value++;

            }

            file.Close();

            //StockingLocationList
            StockingLocationList jobs = StockingLocationList.GetJobsites(false, JobTreeNodeDisplayType.Name, Guid.Empty);
            //StockingLocationList jobs2 = StockingLocationList.GetJobsites(false, JobTreeNodeDisplayType.Name, StrBpatId, Guid.Empty, false, false);

            //obteniendo los ID de todos los Patner 
            System.IO.StreamWriter file2 = new System.IO.StreamWriter("C:\\Report Importer\\OutPut\\StockingLocationList.csv");
            int value2 = 0;
            value2 = 1;
            foreach (StockingLocationListItem item in jobs)
            {

                String StrNumber = value2.ToString();                
                //Iterando x cada una 

                //


                StockingLocation Local = StockingLocation.GetStockingLocation(item.Name, false);
                //StockingLocation l2 = StockingLocation.GetStockingLocation()

                file2.WriteLine("StrNumber|" + StrNumber + "|Name|" + item.Name + "|item.StockingLocationID|" + item.StockingLocationID + "|BusinessPartnerID" + item.BusinessPartnerID.ToString());
                


                System.IO.StreamWriter file3 = new System.IO.StreamWriter("C:\\Report Importer\\OutPut\\StockingProduct.csv");
                foreach (StockedProduct prod in Local.StockedProducts)
                {

                   

                    String StrQuantityOnRent = (prod.QuantityOnRent != null ) ? prod.QuantityOnRent.ToString() : "0";
                    String StrQuantityInTransit = (prod.QuantityInTransit != null) ? prod.QuantityInTransit.ToString() : "0";  
                    String StrQuantityReserved = (prod.QuantityReserved != null) ? prod.QuantityReserved.ToString() : "0";

                    
                                        
                    //file3.WriteLine("PartNumber|" + prod.PartNumber.ToString() + "|Description|" + prod.Description + "|Weight|" + prod.Weight.ToString() + "|QuantityOnRent|"+prod.QuantityOnRent.ToString());

                    file3.WriteLine("Nro|" + value2.ToString() +"|Local.NAME | "+Local.Name.ToString()+  "|PartNumber|" + prod.PartNumber.ToString() + "|Description|" + prod.Description + "|QuantityOnRent|" + StrQuantityOnRent + "|QuantityInTransit|" + StrQuantityInTransit + "|QuantityReserved|" + StrQuantityReserved);
                    value2++;
                }
                file3.Close();



            }

            file2.Close();


            //Avontus.Core.Data.SafeDataReader dr = new Avontus.Core.Data.SafeDataReader(drr);

            // ProductListItem  
            //st = ProductListItem.GetProductListItem(SafeDataReader);

            StockedProductList Plist = StockedProductList.GetSerializedStockedProductList(Guid.Empty);

            foreach (StockedProductListItem ProItem in Plist)
            {
                /*Console.WriteLine("PartNumber :" + ProItem.PartNumber + " Description :" + ProItem.Description);*/
            }


            String Str = "algo";





            //Console.WriteLine("Press any key to continue...");
            //Console.ReadLine();




          

            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }
    }


}

