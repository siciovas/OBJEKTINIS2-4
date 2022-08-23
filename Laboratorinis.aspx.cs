using System;
using System.Web.UI.WebControls;
using System.IO;

namespace LD4.Polimorfizmas
{
    public partial class Laboratorinis : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            // -------------------------------------------------------------------------------------------

            if (File.Exists(Server.MapPath(@"App_Data\Unikalus.csv")))
            {
                File.Delete(Server.MapPath(@"App_Data\Unikalus.csv"));
            }
            if (File.Exists(Server.MapPath(@"App_Data\300.csv")))
            {
                File.Delete(Server.MapPath(@"App_Data\300.csv"));
            }
            if (File.Exists(Server.MapPath(@"App_Data\Brangus.csv")))
            {
                File.Delete(Server.MapPath(@"App_Data\Brangus.csv"));
            }
            if (File.Exists(Server.MapPath(@"App_Data\Rezultatai.txt")))
            {
                File.Delete(Server.MapPath(@"App_Data\Rezultatai.txt"));
            }

            // -------------------------------------------------------------------------------------------

            LinkList<Shop> shops = new LinkList<Shop>();

            // -----------------------------------------------------------------------------------------

            string[] fileReader = Directory.GetFiles(Server.MapPath("App_Data/"));
            string resultFile = Server.MapPath("App_Data/Rezultatai.txt");

            foreach (string reader in fileReader)
            {
                try
                {
                    shops.Add(InOut.ReadShopData(reader));
                }

                catch(Exception ex)
                {
                    Label3.Visible = true;
                    Label3.Text = ex.Message;
                }
            }

            // -----------------------------------------------------------------------------------------

            Shop expensiveRing = Tasks.FindMostExpensiveREC('R', shops);
            InOut.PrintMostExpensiveToTxt(resultFile, expensiveRing, "Most expensive ring is in this shop: ");
            InOut.PrintMostExpensiveToTable(Table1, expensiveRing, "Most expensive ring is in this shop: ");

            Shop expensiveEarring = Tasks.FindMostExpensiveREC('E', shops);
            InOut.PrintMostExpensiveToTxt(resultFile, expensiveEarring, "Most expensive earrings are in this shop: ");
            InOut.PrintMostExpensiveToTable(Table1, expensiveEarring, "Most expensive earrings are in this shop: ");

            Shop expensiveChain = Tasks.FindMostExpensiveREC('C', shops);
            InOut.PrintMostExpensiveToTxt(resultFile, expensiveChain, "Most expensive chain is in this shop: ");
            InOut.PrintMostExpensiveToTable(Table1, expensiveChain, "Most expensive chain is in this shop: ");

            // ------------------------------------------------------------------------------------------


            Session["DataList"] = shops;
            Session["Table1"] = Table1;
            Session["resultFile"] = resultFile;

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string resultUnikalusCSV = Server.MapPath("App_Data/Unikalus.csv");

            if (Session["Table1"] != null)
            {
                Table tempTable = (Table)Session["Table1"];
                for(int i = 0; i < tempTable.Rows.Count;)
                {
                    Table1.Rows.Add(tempTable.Rows[i]);
                }
            }

            LinkList<Shop> shops = (LinkList<Shop>)Session["DataList"];
            string resultFile = (string)Session["resultFile"];

            LinkList<Shop> uniqueShops = Tasks.FindUniques(shops);
            InOut.PrintUniqueToTXTandCSV(resultFile, uniqueShops, "Unique juvelries, that are able to buy only in one shop: ");
            InOut.PrintUniqueToTXTandCSV(resultUnikalusCSV, uniqueShops, "Unique juvelries, that are able to buy only in one shop: ");
            InOut.PrintUniqueToTable(Table2, shops, "Unique juvelries, that are able to buy only in one shop: ");

            Session["Table2"] = Table2;
            Session["Table1"] = Table1;
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            string result300CSV = Server.MapPath("App_Data/300.csv");

            if (Session["Table1"] != null)
            {
                Table tempTable = (Table)Session["Table1"];
                for (int i = 0; i < tempTable.Rows.Count;)
                {
                    Table1.Rows.Add(tempTable.Rows[i]);
                }
            }

            if(Session["Table2"] != null)
            {
                Table tempTable = (Table)Session["Table2"];
                for (int i = 0; i < tempTable.Rows.Count;)
                {
                    Table2.Rows.Add(tempTable.Rows[i]);
                }
            }

            LinkList<Shop> shops = (LinkList<Shop>)Session["DataList"];
            string resultFile = (string)Session["resultFile"];

            LinkList<Juvelry> cheaperThan300 = Tasks.CheaperThan300(shops);
            InOut.PrintToTXT(resultFile, cheaperThan300, "Juvelries, that are cheaper than 300 euros: ");
            InOut.PrintToTXT(result300CSV, cheaperThan300, "Juvelries, that are cheaper than 300 euros: ");
            InOut.PrintoTable(Table3, cheaperThan300, "Juvelries, that are cheaper than 300 euros: ");

            Session["Table3"] = Table3;
            Session["Table2"] = Table2;
            Session["Table1"] = Table1;
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            string resultBrangusCSV = Server.MapPath("App_Data/Brangus.csv");

            if (Session["Table1"] != null)
            {
                Table tempTable = (Table)Session["Table1"];
                for (int i = 0; i < tempTable.Rows.Count;)
                {
                    Table1.Rows.Add(tempTable.Rows[i]);
                }
            }

            if (Session["Table2"] != null)
            {
                Table tempTable = (Table)Session["Table2"];
                for (int i = 0; i < tempTable.Rows.Count;)
                {
                    Table2.Rows.Add(tempTable.Rows[i]);
                }
            }

            if (Session["Table3"] != null)
            {
                Table tempTable = (Table)Session["Table3"];
                for (int i = 0; i < tempTable.Rows.Count;)
                {
                    Table3.Rows.Add(tempTable.Rows[i]);
                }
            }

            LinkList<Shop> shops = (LinkList<Shop>)Session["DataList"];
            string resultFile = (string)Session["resultFile"];

            LinkList<Juvelry> expensiveJuvelries = Tasks.FindExpensiveWithDifferentPrice(shops);
            expensiveJuvelries.Sort();
            InOut.PrintToTXT(resultFile, expensiveJuvelries, "Most expensive juvelries: ");
            InOut.PrintToTXT(resultBrangusCSV, expensiveJuvelries, "Most expensive juvelries: ");
            InOut.PrintoTable(Table4, expensiveJuvelries, "Most expensive juvelries: ");

            Session["Table3"] = Table3;
            Session["Table2"] = Table2;
            Session["Table1"] = Table1;
        }
    }
}