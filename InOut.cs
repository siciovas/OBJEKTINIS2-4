using System;
using System.IO;
using System.Web.UI.WebControls;

namespace LD4.Polimorfizmas
{
    public class InOut
    {
        /// <summary>
        /// Reads data from current file
        /// </summary>
        /// <param name="fileName">current file name</param>
        /// <returns>returns object</returns>
        public static Shop ReadShopData(string fileName)
        {
            using(StreamReader reader = new StreamReader(fileName))
            {
                string shopName, shopAddress;
                decimal ShopPhone;

                shopName = reader.ReadLine();
                shopAddress = reader.ReadLine();
                ShopPhone = decimal.Parse(reader.ReadLine());

                Shop shop = new Shop(shopName, shopAddress, ShopPhone);

                string line = null;

                while((line = reader.ReadLine()) != null)
                {
                    string[] value = line.Split(';');
                    if(value[0].Length > 1)
                    {
                        throw new Exception(String.Format("Type must be one letter! {0} will not be included", fileName.Substring(115)));
                    }
                    char type = Convert.ToChar(value[0]);
                    if (!(type == 'C' || type == 'R' || type == 'E'))
                    {
                        throw new Exception(String.Format("Error! Incorrect type. {0} will not be included", fileName.Substring(115)));
                    }
                    string made = value[1];
                    string name = value[2];
                    string metal = value[3];
                    int weight = Convert.ToInt32(value[4]);
                    int purity = Convert.ToInt32(value[5]);
                    decimal price = Convert.ToDecimal(value[6]);

                    switch(type)
                    {
                        case 'R':
                            int size = Convert.ToInt32(value[7]);
                            Juvelry ring = new Ring(type, made, name, metal, weight, purity, price, size);
                            shop.AddJuvelry(ring);
                            break;
                        case 'E':
                            string claspType = value[7];
                            Juvelry earring = new Earring(type, made, name, metal, weight, purity, price, claspType);
                            shop.AddJuvelry(earring);
                            break;
                        case 'C':
                            int length = Convert.ToInt32(value[7]);
                            Juvelry chain = new Chain(type, made, name, metal, weight, purity, price, length);
                            shop.AddJuvelry(chain);
                            break; 
                    }
                }
                return shop;
            }
        }
    
        public static void PrintMostExpensiveToTxt(string fileName, Shop shop, string header)
        {
            using (StreamWriter writer = File.AppendText(fileName))
            {
                writer.WriteLine(header);
                writer.WriteLine(new string('-', 75));
                writer.WriteLine(shop.ToString());
                writer.WriteLine(new string('-', 75));
                writer.WriteLine();
                writer.WriteLine();
            }
        }
      
        public static void PrintMostExpensiveToTable(Table table1, Shop shop, string header)
        {
            TableRow headerRow = new TableRow();
            TableCell cell = new TableCell();
            cell.Text = header;
            cell.ColumnSpan = 3;
            headerRow.Cells.Add(cell);
            table1.Rows.Add(headerRow);

            TableRow shopRows = new TableRow();

            TableCell name = new TableCell(); name.Text = shop.ShopName; shopRows.Cells.Add(name);
            TableCell address = new TableCell(); address.Text = shop.ShopAddress; shopRows.Cells.Add(address);
            TableCell number = new TableCell(); number.Text = shop.ShopPhone.ToString(); shopRows.Cells.Add(number);

            table1.Rows.Add(shopRows);
        }

        public static void PrintUniqueToTXTandCSV(string fileName, LinkList<Shop> shops, string header)
        {
            using (StreamWriter writer = File.AppendText(fileName))
            {
                writer.WriteLine(header);
                writer.WriteLine(new string('-', 150));
                foreach(Shop shop in shops)
                {
                    writer.WriteLine(shop.ToString());
                    writer.WriteLine(new string('-', 150));
                    foreach(Juvelry juvelry in shop.AllJuvelries)
                    {
                        writer.WriteLine(juvelry.ToString());
                    }
                    writer.WriteLine(new string('-', 150));
                }
                writer.WriteLine();
                writer.WriteLine();

            }
        }

        public static void PrintUniqueToTable(Table table2, LinkList<Shop> shops, string header)
        {
            TableRow headerRow = new TableRow();
            TableCell cell = new TableCell();
            cell.Text = header;
            cell.ColumnSpan = 3;
            headerRow.Cells.Add(cell);
            table2.Rows.Add(headerRow);

            foreach(Shop shop in shops)
            {
                TableRow shopRows = new TableRow();

                TableCell name = new TableCell(); name.Text = shop.ShopName; shopRows.Cells.Add(name);
                TableCell address = new TableCell(); address.Text = shop.ShopAddress; shopRows.Cells.Add(address);
                TableCell number = new TableCell(); number.Text = shop.ShopPhone.ToString(); shopRows.Cells.Add(number);
                table2.Rows.Add(shopRows);

                foreach(Juvelry juvelry in shop.AllJuvelries)
                {
                    cell.ColumnSpan = 8;
                    TableRow juvelriesRows = new TableRow();

                    TableCell type = new TableCell(); type.Text = juvelry.Type.ToString(); juvelriesRows.Cells.Add(type);
                    TableCell country = new TableCell(); country.Text = juvelry.Made; juvelriesRows.Cells.Add(country);
                    TableCell nameJuv = new TableCell(); nameJuv.Text = juvelry.Name; juvelriesRows.Cells.Add(nameJuv);
                    TableCell metal = new TableCell(); metal.Text = juvelry.Metal; juvelriesRows.Cells.Add(metal);
                    TableCell weight = new TableCell(); weight.Text = juvelry.Weight.ToString(); juvelriesRows.Cells.Add(weight);
                    TableCell purity = new TableCell(); purity.Text = juvelry.Purity.ToString(); juvelriesRows.Cells.Add(purity);
                    TableCell price = new TableCell(); price.Text = juvelry.Price.ToString(); juvelriesRows.Cells.Add(price);
                    if(juvelry.Type == 'R')
                    {
                        Ring ring = juvelry as Ring;
                        TableCell size = new TableCell(); size.Text = ring.Size.ToString(); juvelriesRows.Cells.Add(size);
                    }
                    if (juvelry.Type == 'E')
                    {
                        Earring earring = juvelry as Earring;
                        TableCell claspType = new TableCell(); claspType.Text = earring.ClaspType; juvelriesRows.Cells.Add(claspType);
                    }
                    if (juvelry.Type == 'C')
                    {
                        Chain chain = juvelry as Chain;
                        TableCell length = new TableCell(); length.Text = chain.Length.ToString(); juvelriesRows.Cells.Add(length);
                    }
                    table2.Rows.Add(juvelriesRows);

                }
            }
            

            
        }
        public static void PrintToTXT(string fileName, LinkList<Juvelry> juvelries, string header)
        {
            using(StreamWriter writer = File.AppendText(fileName))
            {
                writer.WriteLine(header);
                writer.WriteLine(new string('-', 75));
               foreach(Juvelry juvelry in juvelries)
               {
                        writer.WriteLine(juvelry.ToString());
               }
                writer.WriteLine(new string('-', 75));
                writer.WriteLine();
            }
        }

        public static void PrintoTable(Table table3, LinkList<Juvelry> juvelries, string header)
        {
            TableRow headerRow = new TableRow();
            TableCell cell = new TableCell();
            cell.Text = header;
            cell.ColumnSpan = 8;
            headerRow.Cells.Add(cell);
            table3.Rows.Add(headerRow);

            foreach(Juvelry juvelry in juvelries)
            {
                TableRow juvelriesRows = new TableRow();

                TableCell type = new TableCell(); type.Text = juvelry.Type.ToString(); juvelriesRows.Cells.Add(type);
                TableCell country = new TableCell(); country.Text = juvelry.Made; juvelriesRows.Cells.Add(country);
                TableCell nameJuv = new TableCell(); nameJuv.Text = juvelry.Name; juvelriesRows.Cells.Add(nameJuv);
                TableCell metal = new TableCell(); metal.Text = juvelry.Metal; juvelriesRows.Cells.Add(metal);
                TableCell weight = new TableCell(); weight.Text = juvelry.Weight.ToString(); juvelriesRows.Cells.Add(weight);
                TableCell purity = new TableCell(); purity.Text = juvelry.Purity.ToString(); juvelriesRows.Cells.Add(purity);
                TableCell price = new TableCell(); price.Text = juvelry.Price.ToString(); juvelriesRows.Cells.Add(price);
                if (juvelry.Type == 'R')
                {
                    Ring ring = juvelry as Ring;
                    TableCell size = new TableCell(); size.Text = ring.Size.ToString(); juvelriesRows.Cells.Add(size);
                }
                if (juvelry.Type == 'E')
                {
                    Earring earring = juvelry as Earring;
                    TableCell claspType = new TableCell(); claspType.Text = earring.ClaspType; juvelriesRows.Cells.Add(claspType);
                }
                if (juvelry.Type == 'C')
                {
                    Chain chain = juvelry as Chain;
                    TableCell length = new TableCell(); length.Text = chain.Length.ToString(); juvelriesRows.Cells.Add(length);
                }
                table3.Rows.Add(juvelriesRows);
            }
        }

    }
}