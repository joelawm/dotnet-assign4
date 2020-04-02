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
using System.Diagnostics;
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
        public static float Map_Hight = 250;
        public static float Map_Width = 500;
        public static float Delta = 1;
        public static Point Drag_press = new Point(0, 0);
        public static Point Drag_release = new Point(0, 0);
        public static float moveDistance_X = 0;
        public static float moveDistance_Y = 0;
        public static Point TopLeftCorner = new Point(0, 0);
        public static Point ButtonRightCorner = new Point(500, 250);
        public static float x_offset = 0;
        public static Point CurrentMapTopLeftCorner = new Point(0, 0);
        public static Point CurrentMapButtonRightCorner = new Point(500, 250);
        public List<Streets> StreetstoSearch = new List<Streets>();
        public static List<coordinate> coord = new List<coordinate>();

        public Form1()
        {
            //intilaize everything
            InitializeComponent();
            InitializeCommunity();
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

        public class coordinate
        {
            float x;
            float y;
            int type;

            public coordinate(float x, float y, int type)
            {
                X = x;
                Y = y;
                Type = type;
            }
            public float X { get; set; }
            public float Y { get; set; }
            public int Type { get; set; }
        };

        // action after clicking the 3th query button
        private void BusinessQueryButton_Click(object sender, EventArgs e)
        {
            if (ForSaleCombobox.SelectedItem == null)
            {
                return;
            }

            //list of string addresses
            string[] stAddr = ForSaleCombobox.SelectedItem.ToString().Split(new[] { " # " }, StringSplitOptions.None);
            ushort distance = Convert.ToUInt16(BusinessDistanceUpDown.Value);

            Community comm;

            if (ForSaleCombobox.SelectedIndex > (DekalbCommunity.Population + 5))
                comm = SycamoreCommunity;
            else
                comm = DekalbCommunity;

            
            //query
            var list = from res in comm.Props
                       where (res is House) || (res is Apartment)
                       where (res.StreetAddr == stAddr[0])
                       from pro in comm.Props
                       where (pro is Business)
                       where pro.ForSale.Split(':')[0] == "T"
                       let x = Math.Pow((int)(res.X - pro.X), 2)
                       let y = Math.Pow((int)(res.Y - pro.Y), 2)
                       where (x + y) < Math.Pow(distance, 2)
                       select pro;

            coord.Clear();

            foreach (var pro in comm.Props)
            {
                if (pro.StreetAddr != stAddr[0] || pro.City != comm.Name) continue;

                if (pro.City == "Sycamore")
                {
                    x_offset = 250;
                }
                else
                {
                    x_offset = 0;
                }

                coord.Add(new coordinate(pro.X + x_offset, pro.Y, 1));
            }

            //go through each element in the list
            foreach (var pro in list)
            {
                if (pro.City == "Sycamore")
                {
                    x_offset = 250;
                }
                else
                {
                    x_offset = 0;
                }

                coord.Add(new coordinate(pro.X + x_offset, pro.Y, 4));
            }
            
            Map.Refresh();
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
            coord.Clear();

            //create both of the list
            x_offset = 0;
            ResidentialPara(DekalbCommunity);
            x_offset = 250;
            ResidentialPara(SycamoreCommunity);
            Map.Refresh();

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
                               AttachedGarage = attachGarage,
                               Garage = garage,
                               Bed = (pro as Residential).Bedrooms,
                               Bath = (pro as Residential).Baths,
                               Sqft = (pro as Residential).Sqft,
                               Flood = (proType) ? (pro as House).Flood : 0,
                               proType = proType,
                               apt = (proType) ? null : (pro as Apartment).Unit,

                               X = pro.X,
                               Y = pro.Y
                           };


            foreach (var pro in property)
            {
                //checking data based on the list
                if (HouseCheckBox.Checked == true && pro.proType == true && pro.Bath >= BathUpDown.Value && pro.Bed >= BedUpDown.Value && pro.Sqft >= SqFtUpDown.Value)
                {
                    if (GarageCheckBox.Checked == true && DetachedGarageCheckBox.Checked == false && pro.Garage == true && pro.AttachedGarage == false)
                    {
                        coord.Add(new coordinate(pro.X + x_offset, pro.Y, 1));
                    }
                    else if (GarageCheckBox.Checked == true && DetachedGarageCheckBox.Checked == true && pro.Garage == true && pro.AttachedGarage == true)
                    {
                        coord.Add(new coordinate(pro.X + x_offset, pro.Y, 1));
                    }
                    else if (GarageCheckBox.Checked == false)
                    {
                        coord.Add(new coordinate(pro.X + x_offset, pro.Y, 1));
                    }
                }
                else if (ApartmentCheckBox.Checked == true && pro.proType == false && pro.Bath >= BathUpDown.Value && pro.Bed >= BedUpDown.Value && pro.Sqft >= SqFtUpDown.Value && GarageCheckBox.Checked == false)
                {
                    coord.Add(new coordinate(pro.X + x_offset, pro.Y, 2));
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
            string schoolName = SchoolCombobox.Text.ToString();
            int distance = Convert.ToInt32(SchoolDistanceUpDown.Value);

            //go throught elements
            int index = 0;
            foreach (var v in SchoolCombobox.Items)
                if (v.ToString() != "")
                    index++;
                else
                    break;


            Community comm;
            if (SchoolCombobox.SelectedIndex < index)
                comm = DekalbCommunity;
            else
                comm = SycamoreCommunity;
            //query
            var list = from school in comm.Props
                       where (school is School) && ((school as School).Name == schoolName)
                       from pro in comm.Props
                       where (pro is Apartment) || (pro is House)
                       where pro.ForSale.Split(':')[0] == "T"
                       let x = Math.Pow((int)(school.X - pro.X), 2)
                       let y = Math.Pow((int)(school.Y - pro.Y), 2)
                       where (x + y) < Math.Pow(distance, 2)
                       select pro;

            coord.Clear();

            Graphics g = Map.CreateGraphics();

            foreach (var pro in comm.Props)
            {
                if (!(pro is School) || (pro as School).Name != schoolName) continue;

                if (pro.City == "Sycamore")
                {
                    x_offset = 250;
                }
                else
                {
                    x_offset = 0;
                }

                coord.Add(new coordinate(pro.X + x_offset, pro.Y, 3));
            }

            //print the output
            //go through the elements
            foreach (var pro in list)
            {
                if (comm.Name != "DeKalb")
                {
                    x_offset = 250;
                }
                else
                {
                    x_offset = 0;
                }

                if (pro is House)
                    coord.Add(new coordinate(pro.X + x_offset, pro.Y, 1));
                else
                    coord.Add(new coordinate(pro.X + x_offset, pro.Y, 2));
            }

            Map.Refresh();
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
                       select new CommunityInfo()
                       {
                           property = n,
                           type = (n is Business) ? 0 : (n is School) ? 1 : (n is House) ? 2 : 3
                       };

            coord.Clear();

            Graphics g = Map.CreateGraphics();

            foreach (var pro in List)
            {
                if (pro.property.City == "Sycamore")
                {
                    x_offset = 250;
                }
                else
                {
                    x_offset = 0;
                }

                if (ResidentialtCheckBox.Checked == true && (pro.type == 2 || pro.type == 3))
                {
                    if (pro.type == 2)
                    {
                            coord.Add(new coordinate(pro.property.X + x_offset, pro.property.Y, 1));
                    }
                    else
                    {
                            coord.Add(new coordinate(pro.property.X + x_offset, pro.property.Y, 2));
                    }

                }
                else if (SchoolCheckBox.Checked == true && pro.type == 1)
                {
                        coord.Add(new coordinate(pro.property.X + x_offset, pro.property.Y, 3));
                }
                else if (BusinessCheckBox.Checked && pro.type == 0)
                {
                        coord.Add(new coordinate(pro.property.X + x_offset, pro.property.Y, 4));
                }
            }

            Map.Refresh();

        }
        #endregion


        private void DrawMapStructure(Community comm, Graphics g)
        {
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
                {
                    int i = 0;
                    //X cordinate
                    if (pro.City == "Sycamore")
                    {
                        i = Convert.ToInt32((pro.X + 250) * Delta);
                    }
                    else
                    {
                        i = Convert.ToInt32(pro.X * Delta);
                    }
                    //y cordinate
                    int i2 = Convert.ToInt32(pro.Y * Delta);
                    StreetstoSearch.Add(new Streets(i, i2, pro.StreetAddr, pro.City, pro.ForSale, pro.Zip, pro.OwnerId, pro.State));
                }

                //apartment street addresses
                foreach (Property pro in Apart_Property)
                {
                    int i = 0;
                    //X cordinate
                    if (pro.City == "Sycamore")
                    {
                        i = Convert.ToInt32((pro.X + 250) * Delta);
                    }
                    else
                    {
                        i = Convert.ToInt32(pro.X * Delta);
                    }
                    //y cordinate
                    int i2 = Convert.ToInt32(pro.Y * Delta);

                    StreetstoSearch.Add(new Streets(i, i2, pro.StreetAddr, pro.City, pro.ForSale, pro.Zip, pro.OwnerId, pro.State));
                }

                //street address for school property
                foreach (Property pro in School_Property)
                {
                    int i = 0;
                    //X cordinate
                    if (pro.City == "Sycamore")
                    {
                        i = Convert.ToInt32((pro.X + 250) * Delta);
                    }
                    else
                    {
                        i = Convert.ToInt32(pro.X * Delta);
                    }
                    //y cordinate
                    int i2 = Convert.ToInt32(pro.Y * Delta);

                    StreetstoSearch.Add(new Streets(i, i2, pro.StreetAddr, pro.City, pro.ForSale, pro.Zip, pro.OwnerId, pro.State));
                }

                //business street addresses
                foreach (Property pro in Business_Property)
                {
                    int i = 0;
                    //X cordinate
                    if (pro.City == "Sycamore")
                    {
                        i = Convert.ToInt32((pro.X + 250) * Delta);
                    }
                    else
                    {
                        i = Convert.ToInt32(pro.X * Delta);
                    }
                    //y cordinate
                    int i2 = Convert.ToInt32(pro.Y * Delta);
                    StreetstoSearch.Add(new Streets(i, i2, pro.StreetAddr, pro.City, pro.ForSale, pro.Zip, pro.OwnerId, pro.State));
                }

                //build the streets
                //adding the cordinates to a list to create the grid
                myPen.Color = Color.Black;

                //easy way to make sure I have both list
                if (StreetstoSearch.Count > 30)
                {
                    g.DrawStreets(myPen, StreetstoSearch);
                    StreetstoSearch.Clear();
                }

                myPen.Dispose();
            }
        }

        public void Mapping(Graphics g)
        {
            using (Pen myPen = new Pen(Color.Bisque))
            {
                foreach (var property_coord in coord)
                {
                    switch (property_coord.Type) 
                    {

                        case 1:
                            {
                                g.DrawRec(myPen, (property_coord.X * Delta) - (TopLeftCorner.X - CurrentMapTopLeftCorner.X),
                                                  (property_coord.Y * Delta) - (TopLeftCorner.Y - CurrentMapTopLeftCorner.Y),
                                                  Rec_Hight, Rec_Width);
                            }break;

                        case 2:
                            {
                                myPen.Color = Color.Orange;
                                    g.DrawRec(myPen, (property_coord.X * Delta) - (TopLeftCorner.X - CurrentMapTopLeftCorner.X),
                                                        (property_coord.Y * Delta) - (TopLeftCorner.Y - CurrentMapTopLeftCorner.Y),
                                                         Rec_Hight - 2, Rec_Width + 2);
                            }break;

                        case 3:
                            {
                                myPen.Color = Color.Aqua;
                                    g.DrawCircle(myPen, property_coord.X * Delta - (TopLeftCorner.X - CurrentMapTopLeftCorner.X),
                                                        (property_coord.Y * Delta) - (TopLeftCorner.Y - CurrentMapTopLeftCorner.Y),
                                                        Radius);
                            }break;

                        case 4:
                            {
                                myPen.Color = Color.Aquamarine;
                                    g.DrawTri(myPen, (int)(property_coord.X * Delta - (TopLeftCorner.X - CurrentMapTopLeftCorner.X)),
                                                    (int)(property_coord.Y * Delta - (TopLeftCorner.Y - CurrentMapTopLeftCorner.Y)));
                            }break;
                    }
                    myPen.Color = Color.Bisque;
                }
            }
        }

        private void ZoomInClick(object sender, EventArgs e)
        {
            if (Delta < 2)
            {
                Delta += (float)0.1;
                CurrentMapTopLeftCorner.X = (int)(0 * Delta);
                CurrentMapTopLeftCorner.Y = (int)(0 * Delta);
                CurrentMapButtonRightCorner.X = (int)(500 * Delta);
                CurrentMapButtonRightCorner.Y = (int)(250 * Delta);
            }
            Map.Refresh();
        }

        private void ZoomOutClick(object sender, EventArgs e)
        {
            if (Delta > 1)
            {
                Delta -= (float)0.1;
                CurrentMapTopLeftCorner.X = (int)(0 * Delta);
                CurrentMapTopLeftCorner.Y = (int)(0 * Delta);
                CurrentMapButtonRightCorner.X = (int)(500 * Delta);
                CurrentMapButtonRightCorner.Y = (int)(250 * Delta);
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

            if (TopLeftCorner.X + (Drag_press.X - Drag_release.X) >= CurrentMapTopLeftCorner.X)
                TopLeftCorner.X += (Drag_press.X - Drag_release.X);
            else
                TopLeftCorner.X = CurrentMapTopLeftCorner.X;
            if (TopLeftCorner.X + (Drag_press.X - Drag_release.X) + 500 >= CurrentMapButtonRightCorner.X)
                TopLeftCorner.X = CurrentMapButtonRightCorner.X - 500;

            if (TopLeftCorner.Y + (Drag_press.Y - Drag_release.Y) >= CurrentMapTopLeftCorner.X)
                TopLeftCorner.Y += (Drag_press.Y - Drag_release.Y);
            else
                TopLeftCorner.Y = CurrentMapTopLeftCorner.Y;
            if (TopLeftCorner.Y + (Drag_press.X - Drag_release.Y) + 250 >= CurrentMapButtonRightCorner.Y)
                TopLeftCorner.Y = CurrentMapButtonRightCorner.Y - 250;

            ButtonRightCorner.X = TopLeftCorner.X + 500;
            ButtonRightCorner.Y = TopLeftCorner.Y + 250;

            Map.Refresh();
        }

        private void reset_button_Click(object sender, EventArgs e)
        {
            Delta = 1;
            ButtonRightCorner = new Point(500, 250);
            TopLeftCorner = new Point(0, 0);
            CurrentMapTopLeftCorner = new Point(0, 0);
            CurrentMapButtonRightCorner = new Point(500, 250);
            moveDistance_X = 0;
            moveDistance_Y = 0;

            Map.Refresh();
        }

        //display the 
        private void Map_MouseMove(object sender, MouseEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(e.X + " " + e.Y);
            //send the reuslts of the current mouse hover to be calulated aganist a table
            CalculatePositions(e.X, e.Y);
        }

        //finding the posititons of the mouse
        private void CalculatePositions(int X, int Y)
        {
            if (StreetstoSearch != null)
            {
                foreach (var street in StreetstoSearch)
                {
                    if ((X * Delta) >= street._x && X <= (street._x + 5))
                    {
                        if ((Y * Delta) >= street._y && Y <= (street._y + 5))
                        {
                            MessageBox.Show("Hello, world.");
                        }
                    }
                }
            }
        }

        private void Map_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            DrawMapStructure(DekalbCommunity, g);
            DrawMapStructure(SycamoreCommunity, g);
            Mapping(g);
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
        public static void DrawStreets(this Graphics g, Pen pen, List<Streets> Streets)
        {
            
            Dictionary<int, List<Streets>> streetPairs = new Dictionary<int, List<Streets>>(Streets.Count, null);

            //x cordinates
            foreach(var street in Streets)
            {

                if (streetPairs.ContainsKey(street._x))
                {
                    List<Streets> forXOnly;
                    streetPairs.TryGetValue(street._x, out forXOnly);
                    forXOnly.Add(street);
                    Debug.WriteLine(street._city + " " + street._x + "," + street._y);
                }
                else
                {
                    streetPairs.Add(street._x, new List<Streets>() { street });
                    Debug.WriteLine(street._city + " " + street._x + "," + street._y);
                }
            }

            foreach (var street in streetPairs)
            {

                int miny = -1;
                int maxy = -1;
                string road ="";
                   
                foreach (var stre in street.Value)
                {
                    if (streetPairs.Values.Count > 1)
                    {
                        if (miny == -1 || miny > stre._y) miny = stre._y;
                        if (maxy == -1 || maxy < stre._y) maxy = stre._y;
                    }
                    road = stre._streetaddr;
                }

                if(miny != maxy)
                {
                    g.DrawLine(pen, new Point(street.Key, miny), new Point(street.Key, maxy));
                    System.Diagnostics.Debug.WriteLine("For X " + street.Key + "    MinY " + miny + "     MaxY " + maxy);


                    //add name here
                    int middle = miny + maxy / 2;
                    g.DrawString(road, new Font("Tahoma", 5), Brushes.Black, street.Key, middle);
                }
            }

            Dictionary<int, List<Streets>> streetPairsy = new Dictionary<int, List<Streets>>(Streets.Count, null);

            //y cordinates
            foreach (var street in Streets)
            {

                if (streetPairsy.ContainsKey(street._y))
                {
                    List<Streets> forYOnly;
                    streetPairsy.TryGetValue(street._y, out forYOnly);
                    forYOnly.Add(street);
                }
                else
                {
                    streetPairsy.Add(street._y, new List<Streets>() { street });
                }
            }

            foreach (var street in streetPairsy)
            {

                int minx = -1;
                int maxx = -1;
                string road = "";

                foreach (var stre in street.Value)
                {
                    if(streetPairsy.Values.Count > 1)
                    {
                        if (minx == -1 || minx > stre._x) minx = stre._x;
                        if (maxx == -1 || maxx < stre._x) maxx = stre._x;
                    }

                    road = stre._streetaddr;
                }
                if(minx != maxx)
                {
                    g.DrawLine(pen, new Point(minx, street.Key), new Point(maxx, street.Key));
                    System.Diagnostics.Debug.WriteLine("For Y " + street.Key + "    MinX " + minx + "     MaxX " + maxx);

                    //add name here
                    int middle = minx + maxx / 2;
                    g.DrawString(road, new Font("Tahoma", 5), Brushes.Black, middle, street.Key);
                }
            }
        }
    }
}