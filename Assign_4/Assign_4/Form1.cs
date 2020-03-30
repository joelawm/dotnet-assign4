/*
 * Name: Huajian Huang; zid: z1869893
 * Partner: Joseph Meyer; zid: z1788150
 * 
 * CSCI 473 - Assignment 4
 * Function: The main fucntion of this program is to create a piece of software that allows the query of properties in DeKalb and Sycamore with a GUI and a map.
 * 
 */

using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Assign_4
{
    public partial class Form1 : Form
    {
        //communites in use
        public static Community DekalbCommunity;
        public static Community SycamoreCommunity;
        public static float Radius = 3;
        public static float Rec_Hight = 7;
        public static float Rec_Width = 7;
        public static float Map_Hight = 500;
        public static float Map_Width = 250;
        //public static float Boarder = 250;
        public static float Delta = 1;
        public static Point Drag_press = new Point(0, 0);
        public static Point Drag_release = new Point(0, 0);
        public static float moveDistance_X = 0;
        public static float moveDistance_Y = 0;
        public static Point TopLeftCorner = new Point(0, 0);
        public static Point ButtonRightCorner = new Point(0, 0);
        public static float x_offset = 0;


        //2 parrell lists
        public List<Streets> StreetstoSearch = new List<Streets>();

        public Form1()
        {
            //intilaize everything
            InitializeComponent();
            InitializeCommunity();
            Map.Refresh();
            Mapping();
            //Map.ImageLocation = "..\\..\\icons8-home-128.png";
        }

        #region start
        private void InitializeCommunity()
        {
            ActiveDekalb activeDekalb = new ActiveDekalb();
            DekalbCommunity = activeDekalb.ActiveDekalb_Files();

            ActiveSycamore activeSycamore = new ActiveSycamore();
            SycamoreCommunity = activeSycamore.ActiveSycamore_Files();

        }

        // Cleck forsale dropdown and show all the properties
        private void ForSaleCombobox_DropDown(object sender, EventArgs e)
        {
            //clear the combobox
            ForSaleCombobox.Items.Clear();

            //output for the box
            string[] propertyList = FindProperties(DekalbCommunity);
            ForSaleCombobox.Items.Add("Dekalb:");
            ForSaleCombobox.Items.Add("----------");
            foreach (var stAddr in propertyList)
            {
                if (stAddr != null)
                    ForSaleCombobox.Items.Add(stAddr);
            }
            //add all the itesm
            ForSaleCombobox.Items.Add("");

            //second output
            propertyList = FindProperties(SycamoreCommunity);
            ForSaleCombobox.Items.Add("Sycamore:");
            ForSaleCombobox.Items.Add("----------");
            foreach (var stAddr in propertyList)
            {
                if (stAddr != null)
                    ForSaleCombobox.Items.Add(stAddr);
            }
        }

        //find properties based on wether or not it is a prop
        private string[] FindProperties(Community comm)
        {
            //list of props
            string[] propertyList = new string[30];
            ushort index = 0;

            var houseProperty = from property in comm.Props
                                where (property is House)
                                select property;

            foreach (var property in houseProperty)
                propertyList[index++] = property.StreetAddr;
            //add to the index
            propertyList[index++] = "";

            var apartmentProperty = from property in comm.Props
                                    where (property is Apartment)
                                    select property;

            foreach (var property in apartmentProperty)
                propertyList[index++] = property.StreetAddr + " # " + ((Apartment)property).Unit;

            //return the list made
            return propertyList;
        }

        // action after clicking the 3th query button
        private void BusinessQueryButton_Click(object sender, EventArgs e)
        {
            //exit if null
            if (ForSaleCombobox.SelectedItem == null)
            {
                QueryOutputTextbox.Text = "You have not choose a school yet.";
                return;
            }

            //list of string addresses
            string[] stAddr = ForSaleCombobox.SelectedItem.ToString().Split(new[] { " # " }, StringSplitOptions.None);
            ushort distance = Convert.ToUInt16(BusinessDistanceUpDown.Value);

            QueryOutputTextbox.Text = string.Format("Hiring Businesses within {0} unit of distance\r\n\tfrom {1}\r\n" +
                                                    "------------------------------------------------------------------------------------------\r\n", distance, stAddr[0]);

            Community comm;

            if (ForSaleCombobox.SelectedIndex > (DekalbCommunity.Population + 5))
                comm = SycamoreCommunity;
            else
                comm = DekalbCommunity;

            //create the list
            SortedList<int, CommunityInfo> propertyList = new SortedList<int, CommunityInfo>();
            List<Community> communities = new List<Community>();
            communities.Add(DekalbCommunity);
            communities.Add(SycamoreCommunity);

            //query
            var list = from res in comm.Props
                       where (res is House) || (res is Apartment)
                       where (res.StreetAddr == stAddr[0])
                       from n in communities
                       from pro in n.Props
                       where (pro is Business)
                       where pro.ForSale.Split(':')[0] == "T"
                       let x = Math.Pow((int)(res.X - pro.X), 2)
                       let y = Math.Pow((int)(res.Y - pro.Y), 2)
                       where (x + y) < Math.Pow(distance, 2)
                       from n1 in n.Residents
                       where n1.Id == pro.OwnerId
                       orderby (x + y) descending
                       select new
                       {
                           property = pro,
                           resX = res.X,
                           resY = res.Y,
                           resType = (res is House) ? true : false
                       };


            Map.Refresh();
            Graphics g = Map.CreateGraphics();


            foreach (var pro in comm.Props)
            {
                if (pro.StreetAddr != stAddr[0]) continue;
                if (pro is House)
                {
                    using (Pen myPen = new Pen(Color.Bisque))
                        g.DrawRec(myPen, ((pro.X + x_offset) * Delta) - moveDistance_X, (pro.Y * Delta) - moveDistance_Y, Rec_Hight, Rec_Width);

                }
                else
                {
                    using (Pen myPen = new Pen(Color.Orange))
                        g.DrawRec(myPen, ((pro.X + x_offset) * Delta) - moveDistance_X, (pro.Y * Delta) - moveDistance_Y, Rec_Hight - 2, Rec_Width + 2);
                }
            }

            //go through each element in the list
            foreach (var pro in list)
            {


                if (pro.property.City == "Sycamore")
                {
                    x_offset = 250;
                }
                else
                {
                    x_offset = 0;
                }

                using (Pen myPen = new Pen(Color.Aquamarine))
                {
                    g.DrawTri(myPen, (int)((pro.property.X + x_offset) * Delta - moveDistance_X), (int)(pro.property.Y * Delta - moveDistance_Y));
                }
            }
        }

        // this displays the value of the min trace bar
        private void MinPriceTrackBar_Scroll(object sender, EventArgs e)
        {
            MinPriceLabel.Text = "Min Price: " + String.Format("{0:C0}", MinPriceTrackBar.Value);

            //if track bar is less than this the disable and set value equal to it

            if (MinPriceTrackBar.Value >= MaxPriceTrackBar.Value)
            {
                MaxPriceTrackBar.Enabled = false;
                MaxPriceTrackBar.Value = MinPriceTrackBar.Value;
                MaxPriceLabel.Text = "Max Price: " + String.Format("{0:C0}", MaxPriceTrackBar.Value);
            }
            else
            {
                MaxPriceTrackBar.Enabled = true;
            }
        }

        // this displays the value of the max trace bar
        private void MaxPriceTrackBar_Scroll(object sender, EventArgs e)
        {
            //out and make sure it outputs correctly
            MaxPriceLabel.Text = "Max Price: " + String.Format("{0:C0}", MaxPriceTrackBar.Value);

            //change vlaue and set to disabled
            if (MaxPriceTrackBar.Value <= MinPriceTrackBar.Value)
            {
                MinPriceTrackBar.Enabled = false;
                MinPriceTrackBar.Value = MaxPriceTrackBar.Value;
                MinPriceLabel.Text = "Min Price: " + String.Format("{0:C0}", MaxPriceTrackBar.Value);
            }
            else
            {
                MinPriceTrackBar.Enabled = true;
            }
        }

        private void ParametersQueryButton_Click(object sender, EventArgs e)
        {
            ushort numOfBath = Convert.ToUInt16(BathUpDown.Value);
            ushort numOfBed = Convert.ToUInt16(BedUpDown.Value);
            ushort numOfSpace = Convert.ToUInt16(SqFtUpDown.Value);
            bool garageCheck = GarageCheckBox.Checked;

            QueryOutputTextbox.Text = string.Format("House with at least {0} bed, {1} bath, and {2} sq. foot {3}\r\n" +
                "-----------------------------------------------------------------------------------------\r\n",
                numOfBed, numOfBath, numOfSpace, (garageCheck) ? "with garage." : "without garage.");

            Map.Refresh();
            //create both of the list
            ResidentialPara(DekalbCommunity);
            ResidentialPara(SycamoreCommunity);


            //reorder the list
            //DList = DList.OrderBy(i => i.ForSale).ToList();

        }

        //this creates a residential list of each community
        private void ResidentialPara(Community comm)
        {

            Graphics g = Map.CreateGraphics();

            var property = from pro in comm.Props
                           where (pro is House) || (pro is Apartment)
                           let pr = pro.ForSale.Split(':')
                           where (pr[0] == "T")
                           let price = Convert.ToInt32(pr[1])
                           let proType = (pro is House) ? true : false
                           let garage = (proType) ? (pro as House).Garage : false
                           let attachGarage = (garage) ? (pro as House).AttatchedGarage : false
                           from res in comm.Residents
                           where (res.Id == pro.OwnerId)
                           orderby price ascending
                           select new residentialInfo()
                           {
                               StreetAddr = pro.StreetAddr,
                               City = pro.City,
                               State = pro.State,
                               Zip = pro.Zip,
                               AttachedGarage = attachGarage,
                               Garage = garage,
                               Bed = (pro as Residential).Bedrooms,
                               Bath = (pro as Residential).Baths,
                               Sqft = (pro as Residential).Sqft,
                               Flood = (proType) ? (pro as House).Flood : 0,
                               ForSale = pro.ForSale.Split(':')[1],
                               FullName = res.FullName,
                               proType = proType,
                               apt = (proType) ? null : (pro as Apartment).Unit,

                               X = pro.X,
                               Y = pro.Y
                           };

            foreach (var pro in property)
            {
                if (comm.Name != "Dekalb")
                {
                    x_offset = 250;
                }
                else
                {
                    x_offset = 0;
                }

                //split the first and last name for output
                string[] splitted = pro.FullName.Split(' ');

                //checking data based on the list
                if (HouseCheckBox.Checked == true && pro.proType == true && pro.Bath >= BathUpDown.Value && pro.Bed >= BedUpDown.Value && pro.Sqft >= SqFtUpDown.Value)
                {
                    if (GarageCheckBox.Checked == true && DetachedGarageCheckBox.Checked == false && pro.Garage == true && pro.AttachedGarage == false)
                    {
                        using (Pen myPen = new Pen(Color.Bisque))
                            g.DrawRec(myPen, ((pro.X + x_offset) * Delta) - moveDistance_X, (pro.Y * Delta) - moveDistance_Y, Rec_Hight, Rec_Width);
                    }
                    else if (GarageCheckBox.Checked == true && DetachedGarageCheckBox.Checked == true && pro.Garage == true && pro.AttachedGarage == true)
                    {
                        using (Pen myPen = new Pen(Color.Bisque))
                            g.DrawRec(myPen, ((pro.X + x_offset) * Delta) - moveDistance_X, (pro.Y * Delta) - moveDistance_Y, Rec_Hight, Rec_Width);
                    }
                    else if (GarageCheckBox.Checked == false)
                    {
                        using (Pen myPen = new Pen(Color.Bisque))
                            g.DrawRec(myPen, ((pro.X + x_offset) * Delta) - moveDistance_X, (pro.Y * Delta) - moveDistance_Y, Rec_Hight, Rec_Width);
                    }
                }
                else if (ApartmentCheckBox.Checked == true && pro.proType == false && pro.Bath >= BathUpDown.Value && pro.Bed >= BedUpDown.Value && pro.Sqft >= SqFtUpDown.Value && GarageCheckBox.Checked == false)
                {
                    using (Pen myPen = new Pen(Color.Orange))
                        g.DrawRec(myPen, ((pro.X + x_offset) * Delta) - moveDistance_X, (pro.Y * Delta) - moveDistance_Y, Rec_Hight - 2, Rec_Width + 2);
                }
            }

        }

        //dropdown combo for the school and finding each school
        private void SchoolCombobox_DropDown(object sender, EventArgs e)
        {
            //clear the box
            SchoolCombobox.Items.Clear();
            string[] propertyList = FindSchool(DekalbCommunity);
            SchoolCombobox.Items.Add("Dekalb:");
            SchoolCombobox.Items.Add("----------");
            foreach (var stAddr in propertyList)
            {
                if (stAddr != null)
                    SchoolCombobox.Items.Add(stAddr);
            }
            //add elements
            SchoolCombobox.Items.Add("");

            //add content
            propertyList = FindSchool(SycamoreCommunity);
            SchoolCombobox.Items.Add("Sycamore:");
            SchoolCombobox.Items.Add("----------");
            foreach (var stAddr in propertyList)
            {
                if (stAddr != null)
                    SchoolCombobox.Items.Add(stAddr);
            }
        }

        //find the school based on teh communtity
        private string[] FindSchool(Community comm)
        {
            string[] schoolList = new string[10];
            ushort index = 0;

            //query
            var schoolProperty = from property in comm.Props
                                 where (property is School)
                                 select property;

            foreach (var property in schoolProperty)
                schoolList[index++] = ((School)property).Name;

            //return the list
            return schoolList;
        }

        //scholl button click finds the distance betweeen schools
        private void SchoolQueryButton_Click(object sender, EventArgs e)
        {
            //if null
            if (SchoolCombobox.SelectedItem == null)
            {
                QueryOutputTextbox.Text = "Please, choose a school ";
                return;
            }

            string schoolName = SchoolCombobox.Text.ToString();
            int distance = Convert.ToInt32(SchoolDistanceUpDown.Value);

            //output
            QueryOutputTextbox.Text = string.Format("Residences for sale within {1} units of distance\r\n\tfrom {0}\r\n" +
                "------------------------------------------------------------------------------------------\r\n", schoolName, distance);

            //go throught elements
            int index = 0;
            foreach (var v in SchoolCombobox.Items)
                if (v.ToString() != "")
                    index++;
                else
                    break;


            SortedList<int, CommunityInfo> propertyList = new SortedList<int, CommunityInfo>();

            //make communites
            List<Community> communities = new List<Community>();
            communities.Add(DekalbCommunity);
            communities.Add(SycamoreCommunity);

            Community comm;
            if (SchoolCombobox.SelectedIndex < index)
                comm = DekalbCommunity;
            else
                comm = SycamoreCommunity;
            //query
            var list = from school in comm.Props
                       where (school is School) && ((school as School).Name == schoolName)
                       from n in communities
                       from pro in n.Props
                       where (pro is Apartment) || (pro is House)
                       where pro.ForSale.Split(':')[0] == "T"
                       let x = Math.Pow((int)(school.X - pro.X), 2)
                       let y = Math.Pow((int)(school.Y - pro.Y), 2)
                       where (x + y) < Math.Pow(distance, 2)
                       from n1 in n.Residents
                       where n1.Id == pro.OwnerId
                       orderby (x + y) descending
                       select new CommunityInfo()
                       {
                           FullName = n1.FullName,
                           id = pro.OwnerId,
                           property = pro,
                           distance = (int)Math.Sqrt(x + y),
                           type = (pro is House) ? 0 : 1,
                       };


            Map.Refresh();
            Graphics g = Map.CreateGraphics();

            foreach (var pro in comm.Props)
            {
                if (comm.Name != "Dekalb")
                {
                    x_offset = 250;
                }
                else
                {
                    x_offset = 0;
                }

                if (pro is School && (pro as School).Name == schoolName)
                {
                    using (Pen myPen = new Pen(Color.Aqua))
                        g.DrawCircle(myPen, (pro.X + x_offset) * Delta - moveDistance_X, (pro.Y * Delta) - moveDistance_Y, Radius);
                }
            }

            //print the output
            PrintNearbyForSale(list, comm, g);
        }

        private void PrintNearbyForSale(IEnumerable<CommunityInfo> selector, Community comm, Graphics g)
        {
            //go through the elements
            foreach (var pro in selector)
            {
                if (comm.Name != "Dekalb")
                {
                    x_offset = 250;
                }
                else
                {
                    x_offset = 0;
                }

                if (pro.property is House)
                {
                    using (Pen myPen = new Pen(Color.Bisque))
                        g.DrawRec(myPen, ((pro.property.X + x_offset) * Delta) - moveDistance_X, (pro.property.Y * Delta) - moveDistance_Y, Rec_Hight, Rec_Width);

                }
                else
                {
                    using (Pen myPen = new Pen(Color.Orange))
                        g.DrawRec(myPen, ((pro.property.X + x_offset) * Delta) - moveDistance_X, (pro.property.Y * Delta) - moveDistance_Y, Rec_Hight - 2, Rec_Width + 2);
                }
            }
        }

        //community list target
        class CommunityInfo
        {
            public uint id { get; set; }
            public string FullName { get; set; }
            public Property property { get; set; }
            public int type { get; set; }
            public int distance;
        }

        //Click of the first price button Displaying price info on different properties.
        private void PriceQueryButton_Click(object sender, EventArgs e)
        {
            if (!ResidentialtCheckBox.Checked &&
                !SchoolCheckBox.Checked &&
                !BusinessCheckBox.Checked)
            {
                QueryOutputTextbox.Text = "You atleast have to choose one of the checkboxes";
                return;
            }

            QueryOutputTextbox.Text = string.Format("Properties for sale within [ {0}, {1} ] price range.\r\n" +
                "------------------------------------------------------------------------------------------\r\n",
                String.Format("{0:C0}", MinPriceTrackBar.Value), String.Format("{0:C0}", MaxPriceTrackBar.Value));

            //list a communty and add them
            List<Community> communities = new List<Community>();
            communities.Add(DekalbCommunity);
            communities.Add(SycamoreCommunity);

            //query
            var l = communities.GroupBy(p => p.Name);

            var List = from n2 in communities
                       from n in n2.Props
                       let forsale = n.ForSale.Split(':')
                       where forsale[0] == "T"
                       let price = Convert.ToInt32(forsale[1])
                       where (price >= MinPriceTrackBar.Value) && (price <= MaxPriceTrackBar.Value)
                       from n1 in n2.Residents
                       where n1.Id == n.OwnerId
                       orderby price ascending
                       select new CommunityInfo()
                       {
                           FullName = n1.FullName,
                           property = n,
                           type = (n is Business) ? 0 : (n is School) ? 1 : (n is House) ? 2 : 3
                       };


            //group it
            var fullList = List.GroupBy(p => p.property.City);

            //output
            printList(fullList);

        }

        private void printList(IEnumerable<IGrouping<string, CommunityInfo>> comm)
        {

            Map.Refresh();

            Graphics g = Map.CreateGraphics();

            //go through the objects
            foreach (var community in comm)
            {
                QueryOutputTextbox.AppendText(string.Format("\r\n\t\t*** {0} ***\r\n", community.Key));

                if (community.Key == "Sycamore")
                {
                    x_offset = 250;
                }
                else
                {
                    x_offset = 0;
                }

                foreach (var pro in community)
                    if (ResidentialtCheckBox.Checked == true && (pro.type == 2 || pro.type == 3))
                    {
                        if (pro.type == 2)
                        {
                            using (Pen myPen = new Pen(Color.Bisque))
                                g.DrawRec(myPen, ((pro.property.X + x_offset) * Delta) - moveDistance_X, (pro.property.Y * Delta) - moveDistance_Y, Rec_Hight, Rec_Width);
                        }
                        else
                        {
                            using (Pen myPen = new Pen(Color.Orange))
                                g.DrawRec(myPen, ((pro.property.X + x_offset) * Delta) - moveDistance_X, (pro.property.Y * Delta) - moveDistance_Y, Rec_Hight - 2, Rec_Width + 2);
                        }

                    }
                    else if (SchoolCheckBox.Checked == true && pro.type == 1)
                    {
                        using (Pen myPen = new Pen(Color.Aqua))
                            g.DrawCircle(myPen, (pro.property.X + x_offset) * Delta - moveDistance_X, (pro.property.Y * Delta) - moveDistance_Y, Radius);
                    }
                    else if (BusinessCheckBox.Checked && pro.type == 0)
                    {
                        using (Pen myPen = new Pen(Color.Aquamarine))
                            g.DrawTri(myPen, (int)((pro.property.X + x_offset) * Delta - moveDistance_X), (int)(pro.property.Y * Delta - moveDistance_Y));
                    }
            }
        }

        #endregion

        private void Map_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            DrawMapStructure(DekalbCommunity, g, true);
            DrawMapStructure(SycamoreCommunity, g, false);
        }

        private void DrawMapStructure(Community comm, Graphics g, bool Dekalb)
        {


            if (!(Drag_press.X - Drag_release.X == 0))
                moveDistance_X = Drag_press.X - Drag_release.X;
            if (!(Drag_press.Y - Drag_release.Y == 0))
                moveDistance_Y = Drag_press.Y - Drag_release.Y;

            using (Pen myPen = new Pen(Brushes.Green, 3))
            {
                g.DrawRec(myPen, 10 * Delta - moveDistance_X, 10 * Delta - moveDistance_Y,
                            (Map_Hight * Delta) - moveDistance_X, (Map_Width * Delta) - moveDistance_Y);

                //g.DrawLine(myPen, (Boarder + 10) * Delta - moveDistance_X, (0 + 10) * Delta - moveDistance_Y, 
                //                    (Boarder + 10) * Delta - moveDistance_X, (Boarder + 10) * Delta - moveDistance_Y);
            }
            /*

            */
        }

        public void Mapping()
        {
            CreateMap(DekalbCommunity, true);
            CreateMap(SycamoreCommunity, false);
        }

        public void CreateMap(Community comm, bool DeKalb)
        {
            Graphics g = Map.CreateGraphics();

            if (!DeKalb)
            {
                x_offset = 250;
            }
            else
            {
                x_offset = 0;
            }

            using (Pen myPen = new Pen(Color.Bisque))
            {
                var House_Property = from pro in comm.Props
                                     where pro is House
                                     select pro;
                var Apart_Property = from pro in comm.Props
                                     where pro is Apartment
                                     select pro;
                var Business_Property = from pro in comm.Props
                                        where pro is Business
                                        select pro;
                var School_Property = from pro in comm.Props
                                      where pro is School
                                      select pro;
                foreach (Property pro in House_Property)
                    g.DrawRec(myPen, ((pro.X + x_offset) * Delta) - moveDistance_X, (pro.Y * Delta) - moveDistance_Y, Rec_Hight, Rec_Width);

                myPen.Color = Color.Orange;
                foreach (Property pro in Apart_Property)
                    g.DrawRec(myPen, ((pro.X + x_offset) * Delta) - moveDistance_X, (pro.Y * Delta) - moveDistance_Y, Rec_Hight - 2, Rec_Width + 2);

                myPen.Color = Color.Aqua;
                foreach (Property pro in School_Property)
                    g.DrawCircle(myPen, (pro.X + x_offset) * Delta - moveDistance_X, (pro.Y * Delta) - moveDistance_Y, Radius);

                myPen.Color = Color.Aquamarine;
                foreach (Property pro in Business_Property)
                    g.DrawTri(myPen, (int)((pro.X + x_offset) * Delta - moveDistance_X), (int)(pro.Y * Delta - moveDistance_Y));

                //adding the cordinates to a list to create the grid
                myPen.Color = Color.Black;
                foreach (Property pro in House_Property)
                {
                    //X cordinate
                    int i = Convert.ToInt32(pro.X * Delta);
                    //y cordinate
                    int i2 = Convert.ToInt32(pro.Y * Delta);

                    //StreetstoSearch.Add(new Streets() { i, i2 });

                    //build the streets
                    g.DrawStreets(myPen, StreetstoSearch, (int)((Map_Hight) * Delta), (int)((Map_Width) * Delta));
                }
            }
        }

        private void ZoomInClick(object sender, EventArgs e)
        {
            if (Delta < 2)
            {
                Delta *= (float)1.1;
                //Map.Width = Convert.ToInt32(Map.Width * 1.1);
                //Map.Height = Convert.ToInt32(Map.Height * 1.1);

            }
            Map.Refresh();
        }

        private void ZoomOutClick(object sender, EventArgs e)
        {
            if (Delta > 1)
            {
                Delta /= (float)1.1;
                //Map.Width = Convert.ToInt32(Map.Width / 1.1);
                //Map.Height = Convert.ToInt32(Map.Height / 1.1);
            }
            Map.Refresh();
        }

        private void Map_MouseDown(object sender, MouseEventArgs e)
        {
            Drag_press = e.Location;
        }

        private void Map_MouseUp(object sender, MouseEventArgs e)
        {
            Drag_release = e.Location;
            Map.Refresh();
        }

        private void reset_button_Click(object sender, EventArgs e)
        {
            Delta = 1;
            Drag_press = new Point(0, 0);
            Drag_release = new Point(0, 0);
            moveDistance_X = 0;
            moveDistance_Y = 0;

            Map.Refresh();
            Mapping();
        }
    }
    //drawing icons and streets
    public static class GraphicsExtensions
    {
        public static void DrawCircle(this Graphics g, Pen pen,
                                      float centerX, float centerY, float radius)
        {
            g.DrawEllipse(pen, centerX - radius, centerY - radius,
                          radius + radius, radius + radius);
        }

        public static void DrawRec(this Graphics g, Pen pen,
                                      float centerX, float centerY, float hight, float width)
        {
            g.DrawRectangle(pen, centerX, centerY, hight, width);
        }

        public static void DrawTri(this Graphics g, Pen pen, int x, int y)
        {
            g.DrawLine(pen, new Point(x, y), new Point(x + 5, y + 5));
            g.DrawLine(pen, new Point(x + 5, y), new Point(x, y + 5));
            // g.DrawLine(pen, new Point(x + 5, y - 5), new Point(x + 5 / 2, y + 5));
        }

        //drawing the streets given x,y cordinates
        public static void DrawStreets(this Graphics g, Pen pen, List<Streets> Streets, int max_x, int max_y)
        {
            foreach (var num in Streets)
            {
            }
            //testing
            //g.DrawLine(pen, new Point(x + max_x, y_cords), new Point(x_cords, y_cords));
        }
    }
}