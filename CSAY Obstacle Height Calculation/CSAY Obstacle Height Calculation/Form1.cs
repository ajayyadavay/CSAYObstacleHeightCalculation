using GMap.NET.WindowsForms.Markers;
using GMap.NET.WindowsForms;
using GMap.NET;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GMap.NET.MapProviders;
using System.Drawing.Imaging;
using SharpKml.Dom;
using SharpKml.Base;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Data.SqlClient;
using iText.Kernel.Pdf;
//using iText.Kernel.Colors;
using iText.Kernel.Font;
using iText.Kernel.Geom;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using iText.IO.Font.Constants;
using iText.Kernel.Pdf.Canvas.Draw;
using iText.IO.Image;
using System.Data.SQLite;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;
using GMap.NET.Internals;
using Org.BouncyCastle.Asn1.X9;
using System.Data.Entity.Validation;
using exporttoword = Microsoft.Office.Interop.Word;
using System.Reflection;
using Microsoft.Office.Interop.Word;
using Word = Microsoft.Office.Interop.Word;
using System.Threading;
using GMap.NET.WindowsPresentation;
using Org.BouncyCastle.Utilities;
using Org.BouncyCastle.Asn1.Mozilla;
using System.Data.Entity.Core.Metadata.Edm;
using Microsoft.Office.Core;

namespace CSAY_Obstacle_Height_Calculation
{
    public partial class FrmObstacleHeightCalculation : Form
    {
        string Cur_Dir, Local_Level, Project_Folders, ThisObstacleFolder, FirstName, Plot_No;
        double Final_Easting_X, Final_Northing_Y;
        //double Final_Latitude_DD, Final_Longitude_DD;
        string Recent_Folder_Location;
        bool AutoAdd = false;
        int SurfaceCount;
        bool Plot_Map_Clicked = false, all_surfacechkbox_checked = true;

       /* //DGV1
        int Approach_DGV1_St = 6;//up to 21
        int ToC_DGV1_St = 22;//up to 33
        int BL_DGV1_St = 34;//up to 41
        int Trans_DGV1_St = 42;//up to 45
        int In_Horizontal_DGV1_St = 46;//up to 49
        int Conical_DGV1_St = 50;//up to 53
        int InHz_Co_DGV1_St = 54;//up to 57
        int In_App_DGV1_St = 58;//up to 65
        int In_Trans_DGV1_St =66;//up to 69

        //DGV2
        int Approach_DGV2_St = 5;//up to 16
        int ToC_DGV2_St = 17;//up to 33
        int BL_DGV2_St = 34;//up to 41
        int Trans_DGV2_St = 42;//up to 45
        int In_Horizontal_DGV2_St = 46;//up to 49
        int Conical_DGV2_St = 50;//up to 53
        int InHz_Co_DGV2_St = 54;//up to 57
        int In_App_DGV2_St = 58;//up to 65
        int In_Trans_DGV2_St = 66;//up to 69*/

        private void BtnExportToKML_Click(object sender, EventArgs e)
        {
            double lat1, long1, lat2, long2;

            //take lat long input from text boxes
            lat1 = Convert.ToDouble(TxtLat1.Text);
            long1 = Convert.ToDouble(TxtLong1.Text);

            lat2 = Convert.ToDouble(TxtLat2.Text);
            long2 = Convert.ToDouble(TxtLong2.Text);

            // This will be used for the placemark-----------------
            var point = new SharpKml.Dom.Point
            {
                Coordinate = new SharpKml.Base.Vector(lat1, long1)
            };

            var placemark = new SharpKml.Dom.Placemark
            {
                Name = "RWY",
                Geometry = point
            };

            //For point 2
            var point2 = new SharpKml.Dom.Point
            {
                Coordinate = new SharpKml.Base.Vector(lat2, long2)
            };

            var placemark2 = new SharpKml.Dom.Placemark
            {
                Name = TxtFirstName.Text + " House",
                Geometry = point2
            };

            LineString linestring = new LineString();
            CoordinateCollection coordinates = new CoordinateCollection();
            coordinates.Add(new SharpKml.Base.Vector(lat1, long1));
            coordinates.Add(new SharpKml.Base.Vector(lat2, long2));

            linestring.Coordinates = coordinates;
            SharpKml.Dom.Placemark placemark_line = new SharpKml.Dom.Placemark();
            placemark_line.Name = "Lines";
            //placemark3.Visibility = false;
            placemark_line.Geometry = linestring;

            var document = new SharpKml.Dom.Document
            {
                Description = new SharpKml.Dom.Description
                {
                    Text = "RWY to House"
                }
            };

            var folder = new SharpKml.Dom.Folder
            {
                Description = new SharpKml.Dom.Description
                {
                    Text = "Folder contains RWY and house location"
                },
                Name = "RWY_House"
            };

            // This is the root element of the file--------------------------
            var kml = new Kml
            {
                Feature = document
            };

            var serializer = new Serializer();
            
            ///Style 1
            SharpKml.Dom.LineStyle lineStyle = new SharpKml.Dom.LineStyle();
            lineStyle.Color = Color32.Parse("FFE67800");
            lineStyle.Width = 12;

            SharpKml.Dom.PolygonStyle PolyStyle = new SharpKml.Dom.PolygonStyle();
            PolyStyle.Color = Color32.Parse("FFE67800");

            SharpKml.Dom.Style SimpleStyle = new SharpKml.Dom.Style();
            SimpleStyle.Id = "Style1";
            SimpleStyle.Line = lineStyle;
            SimpleStyle.Polygon = PolyStyle;
            document.AddStyle(SimpleStyle);

            document.AddFeature(placemark);
            document.AddFeature(placemark2);
            document.AddFeature(placemark_line);

            if (TxtFY.Text == "" || TxtLocalLevel.Text == "")
            {
                TxtLog.Text += "Either Fiscal Year or Local level is Empty. Please fill to continue.";
                TxtLog.Text += Environment.NewLine;
            }
            else
            {
                CreateAccessProjectFolders();

                if (!Directory.Exists(Project_Folders))
                {
                    Directory.CreateDirectory(Project_Folders);
                }
                string kmlfilename = Project_Folders + "\\" + TxtFirstName.Text + "_" + TxtPlotNo.Text + "_kml.kml";
                TxtRecentFolderLocation.Text = Project_Folders;
                FileStream fileStream = new FileStream(kmlfilename, FileMode.OpenOrCreate);
                serializer.Serialize(kml, fileStream);
                TxtLog.Text = "Exported to KML";
            }

        }

        private void BtnSaveMap_Click(object sender, EventArgs e)
        {
            //gMapControl2.Hide(); // this results in a blank jpg image for gMapControl2

            // Plot the same map to both gMapControls...
            PlotMap(gMapControl1);
            //PlotMap(gMapControl2);

            // Excuse the clunky wait method here ; it was due to a 'cross-thread' error when using the event raised by the gMapControl
            // It serves the purpose here.
            System.Threading.Tasks.Task.Factory.StartNew(() => { System.Threading.Tasks.Task.Delay(5000).Wait(); }).Wait(); // wait for 5 seconds to give maps plenty of time to render

            if (TxtFY.Text == "" || TxtLocalLevel.Text == "")
            {
                TxtLog.Text = "Either Fiscal Year or Local level is Empty. Please fill to continue.";
                //TxtLog.Text += Environment.NewLine;
            }
            else
            {
                CreateAccessProjectFolders();

                if (!Directory.Exists(Project_Folders))
                {
                    Directory.CreateDirectory(Project_Folders);
                }
                //WriteBitmap(gMapControl1, $@"E:\Test_gMapControl1.jpg");
                string imgfilename = Project_Folders + "\\" + TxtFirstName.Text + "_" + TxtPlotNo.Text + "_Map.jpg";
                WriteBitmap(gMapControl1, imgfilename);
                //WriteBitmap(gMapControl1, "Test_gMapControl1.jpg");
                //WriteBitmap(gMapControl1, $@"E:\Test_gMapControl2.jpg");
                TxtRecentFolderLocation.Text = Project_Folders;
                TxtLog.Text =  "Map Saved.";
            }

                
        }
        private void PlotMap(GMap.NET.WindowsForms.GMapControl gMapControl)
        {
            double lat1, long1, lat2, long2, lat_mid, long_mid;
            double lat11, long11, lat22, long22;
             
            //take lat long input from text boxes
            lat1 = Convert.ToDouble(TxtLat1.Text);
            long1 = Convert.ToDouble(TxtLong1.Text);

            lat2 = Convert.ToDouble(TxtLat2.Text);
            long2 = Convert.ToDouble(TxtLong2.Text);

            lat11 = lat2;
            long22 = long2;
            lat22 = lat1;
            long11 = long1;

            lat_mid = (lat1 + lat2) / 2;
            long_mid = (long1 + long2) / 2;

            gMapControl.MapProvider = GoogleSatelliteMapProvider.Instance;
            GMaps.Instance.Mode = AccessMode.ServerAndCache;
            gMapControl.ShowCenter = false;
            //gMapControl.MinZoom = 1;
            //gMapControl.MaxZoom = 25;
            //gMapControl.Position = new PointLatLng(lat_mid, long_mid); // centered on lat_mid, long_mid
            //gMapControl.Zoom = 14;
            /*List<PointLatLng> points = new List<PointLatLng>();

            points.Add(new PointLatLng(lat1, long1));
            points.Add(new PointLatLng(lat11, long11));
            points.Add(new PointLatLng(lat2, long2));
            points.Add(new PointLatLng(lat22, long22));

            gMapControl1.SetZoomToFitRect(points);*/
            if(ChkBoxAutoFitMap.Checked == true)
            {
                RectLatLng Rect_COORD = new RectLatLng(Math.Max(lat1, lat2), Math.Max(long1, long2), Math.Abs(long1 - long2), Math.Abs(lat1 - lat2));
                gMapControl1.SetZoomToFitRect(Rect_COORD);
                gMapControl.Position = new PointLatLng(lat_mid, long_mid); // centered on lat_mid, long_mid
            }
            
        }
        private void WriteBitmap(GMap.NET.WindowsForms.GMapControl gMapControl, string filename)
        {
            System.Drawing.Image b = gMapControl.ToImage();
            b.Save(filename, ImageFormat.Jpeg);
        }

        private void CreateAccessProjectFolders()
        {
            Cur_Dir = Environment.CurrentDirectory;
            FYFolder = TxtFY.Text;
            Local_Level = TxtLocalLevel.Text;
            FirstName = TxtFirstName.Text;
            Plot_No = TxtPlotNo.Text;

            if (Local_Level == "")
            {
                Local_Level = "New_Local_Level";
            }
            if (FirstName== "")
            {
                Local_Level = "New_Firt_Name";
            }
            if (Plot_No == "")
            {
                Plot_No = "123";
            }

            Project_Folders = Cur_Dir + "\\ObstacleProjectFolders\\" + FYFolder + "\\" + Local_Level + "\\" + TxtFirstName.Text + "_" + TxtPlotNo.Text;
        }

        private void ComboBoxRWY_SelectedIndexChanged(object sender, EventArgs e)
        {
            TxtAirportCode.Text = ComboBoxRWY.Text;
        }

        private void BtnCreateMap_Click(object sender, EventArgs e)
        {
            try
            {
                Plot_Map_Clicked = true;
                double lat1, long1, lat2, long2, AreaDistance=0;
                double m, c;
                int Plot_Position_Case;
                double x1, y1, x2, y2;
                double intersection_X, intersection_Y;

                //take lat long input from text boxes
                //RWY coordinate
                lat1 = 0.0;
                long1 = 0.0;
                //lat1 = Convert.ToDouble(TxtLat1.Text);
                //long1 = Convert.ToDouble(TxtLong1.Text);

                //Plot coordinate
                lat2 = Convert.ToDouble(TxtLat2.Text);
                long2 = Convert.ToDouble(TxtLong2.Text);
                //LatLong_To_UTM(lat2, long2); //this gives FinalEasting_X and FinalNorthing_Y of plot
                //MessageBox.Show("East = " + Final_Easting_X + "\nNorth = " + Final_Northing_Y);
                double[] NE = new double[2];
                NE = Convert_LatLong_To_UTM(lat2, long2);
                Final_Easting_X = NE[0];
                Final_Northing_Y = NE[1];
                //MessageBox.Show("East = " + Final_Easting_X + "\nNorth = " + Final_Northing_Y);

                //find Case among 1,2,3,4,5 or 6
                Plot_Position_Case = Case_of_Plot_COORD(Final_Easting_X, Final_Northing_Y);
                //MessageBox.Show("CASE: " + Plot_Position_Case);

                if(Plot_Position_Case == 2)
                {
                    //equation DA--> north edge of runway
                    m = Convert.ToDouble(dataGridView2.Rows[3].Cells[1].Value);//slope of DA
                    c = Convert.ToDouble(dataGridView2.Rows[3].Cells[2].Value);//intercept of DA
                    AreaDistance = Math.Abs(m * Final_Easting_X - Final_Northing_Y + c) / Math.Sqrt(m * m + 1.0 * 1.0);
                    double m2 = - 1.0 / m;
                    double c2 = Final_Northing_Y - m2 * Final_Easting_X;

                    intersection_X = (c - c2) / (m2 - m);
                    intersection_Y = (m2 * c - m * c2) / (m2 - m);
                    //UTM_To_LatLong(intersection_X, intersection_Y);
                    //lat1 = Final_Latitude_DD;
                    //long1 = Final_Longitude_DD;
                    //MessageBox.Show("Lat1 = " + lat1.ToString() + "\n" + "long1 = " + long1.ToString());

                    double[] LL = new double[2];
                    LL = Convert_UTM_To_Latitude_Longitude(intersection_X, intersection_Y);
                    lat1 = LL[0];
                    long1 = LL[1];
                    //MessageBox.Show("Lat1 = " + LL[0].ToString() + "\n" + "long1 = " + long1.ToString());

                    TxtLat1.Text = lat1.ToString();
                    TxtLong1.Text = long1.ToString();
                }
                else if (Plot_Position_Case == 6)
                {
                    //equation BC--> south edge of runway
                    m = Convert.ToDouble(dataGridView2.Rows[1].Cells[1].Value);//slope of BC
                    c = Convert.ToDouble(dataGridView2.Rows[1].Cells[2].Value);//intercept of BC
                    AreaDistance = Math.Abs(m * Final_Easting_X - Final_Northing_Y + c) / Math.Sqrt(m * m + 1.0 * 1.0);
                    double m2 = - 1.0 / m;
                    double c2 = Final_Northing_Y - m2 * Final_Easting_X;

                    intersection_X = (c - c2) / (m2 - m);
                    intersection_Y = (m2 * c - m * c2) / (m2 - m);

                    /*UTM_To_LatLong(intersection_X, intersection_Y);
                    lat1 = Final_Latitude_DD;
                    long1 = Final_Longitude_DD;*/

                    double[] LL = new double[2];
                    LL = Convert_UTM_To_Latitude_Longitude(intersection_X, intersection_Y);
                    lat1 = LL[0];
                    long1 = LL[1];

                    TxtLat1.Text = lat1.ToString();
                    TxtLong1.Text = long1.ToString();
                }
                else if(Plot_Position_Case == 1) //D
                {
                    //RWY coord
                    x1 = Convert.ToDouble(dataGridView1.Rows[3].Cells[4].Value);
                    y1 = Convert.ToDouble(dataGridView1.Rows[3].Cells[5].Value);
                    //plot coord
                    x2 = Final_Easting_X;
                    y2 = Final_Northing_Y;
                    AreaDistance = Find_Distance_bet_two_pointXY(x1, y1, x2, y2);

                    lat1 = Convert.ToDouble(dataGridView1.Rows[3].Cells[2].Value);
                    long1 = Convert.ToDouble(dataGridView1.Rows[3].Cells[3].Value);
                    TxtLat1.Text = lat1.ToString();
                    TxtLong1.Text = long1.ToString();
                }
                else if (Plot_Position_Case == 3) //A
                {
                    //RWY coord
                    x1 = Convert.ToDouble(dataGridView1.Rows[0].Cells[4].Value);
                    y1 = Convert.ToDouble(dataGridView1.Rows[0].Cells[5].Value);
                    //plot coord
                    x2 = Final_Easting_X;
                    y2 = Final_Northing_Y;
                    AreaDistance = Find_Distance_bet_two_pointXY(x1, y1, x2, y2);

                    lat1 = Convert.ToDouble(dataGridView1.Rows[0].Cells[2].Value);
                    long1 = Convert.ToDouble(dataGridView1.Rows[0].Cells[3].Value);
                    TxtLat1.Text = lat1.ToString();
                    TxtLong1.Text = long1.ToString();
                }
                else if (Plot_Position_Case == 4) //AB
                {
                    //equation AB--> EAST edge of runway
                    m = Convert.ToDouble(dataGridView2.Rows[0].Cells[1].Value);//slope of AB
                    c = Convert.ToDouble(dataGridView2.Rows[0].Cells[2].Value);//intercept of AB
                    AreaDistance = Math.Abs(m * Final_Easting_X - Final_Northing_Y + c) / Math.Sqrt(m * m + 1.0 * 1.0);
                    double m2 = - 1.0 / m;
                    double c2 = Final_Northing_Y - m2 * Final_Easting_X;

                    intersection_X = (c - c2) / (m2 - m);
                    intersection_Y = (m2 * c - m * c2) / (m2 - m);
                    /*UTM_To_LatLong(intersection_X, intersection_Y);
                    lat1 = Final_Latitude_DD;
                    long1 = Final_Longitude_DD;*/

                    double[] LL = new double[2];
                    LL = Convert_UTM_To_Latitude_Longitude(intersection_X, intersection_Y);
                    lat1 = LL[0];
                    long1 = LL[1];

                    TxtLat1.Text = lat1.ToString();
                    TxtLong1.Text = long1.ToString();
                }
                else if (Plot_Position_Case == 5) //B
                {
                    //RWY coord
                    x1 = Convert.ToDouble(dataGridView1.Rows[1].Cells[4].Value);
                    y1 = Convert.ToDouble(dataGridView1.Rows[1].Cells[5].Value);
                    //plot coord
                    x2 = Final_Easting_X;
                    y2 = Final_Northing_Y;
                    AreaDistance = Find_Distance_bet_two_pointXY(x1, y1, x2, y2);

                    lat1 = Convert.ToDouble(dataGridView1.Rows[1].Cells[2].Value);
                    long1 = Convert.ToDouble(dataGridView1.Rows[1].Cells[3].Value);
                    TxtLat1.Text = lat1.ToString();
                    TxtLong1.Text = long1.ToString();
                }
                else if (Plot_Position_Case == 7) //C
                {
                    //RWY coord
                    x1 = Convert.ToDouble(dataGridView1.Rows[2].Cells[4].Value);
                    y1 = Convert.ToDouble(dataGridView1.Rows[2].Cells[5].Value);
                    //plot coord
                    x2 = Final_Easting_X;
                    y2 = Final_Northing_Y;
                    AreaDistance = Find_Distance_bet_two_pointXY(x1, y1, x2, y2);

                    lat1 = Convert.ToDouble(dataGridView1.Rows[2].Cells[2].Value);
                    long1 = Convert.ToDouble(dataGridView1.Rows[2].Cells[3].Value);
                    TxtLat1.Text = lat1.ToString();
                    TxtLong1.Text = long1.ToString();
                }
                else if (Plot_Position_Case == 8) //CD
                {
                    //equation CD--> WEST edge of runway
                    m = Convert.ToDouble(dataGridView2.Rows[2].Cells[1].Value);//slope of CD
                    c = Convert.ToDouble(dataGridView2.Rows[2].Cells[2].Value);//intercept of CD
                    AreaDistance = Math.Abs(m * Final_Easting_X - Final_Northing_Y + c) / Math.Sqrt(m * m + 1.0 * 1.0);
                    double m2 = - 1.0 / m;
                    double c2 = Final_Northing_Y - m2 * Final_Easting_X;

                    intersection_X = (c - c2) / (m2 - m);
                    intersection_Y = (m2 * c - m * c2) / (m2 - m);
                    /*UTM_To_LatLong(intersection_X, intersection_Y);
                    lat1 = Final_Latitude_DD;
                    long1 = Final_Longitude_DD;*/

                    double[] LL = new double[2];
                    LL = Convert_UTM_To_Latitude_Longitude(intersection_X, intersection_Y);
                    lat1 = LL[0];
                    long1 = LL[1];

                    TxtLat1.Text = lat1.ToString();
                    TxtLong1.Text = long1.ToString();
                }


                //show google map
                GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerAndCache;
                gMapControl1.DragButton = MouseButtons.Left;
                gMapControl1.MouseWheelZoomEnabled = true;
                gMapControl1.MapProvider = GMap.NET.MapProviders.GoogleSatelliteMapProvider.Instance;
                gMapControl1.Position = new PointLatLng(lat1, long1);
                gMapControl1.Position = new PointLatLng(lat2, long2);
                gMapControl1.Zoom = 15;

                //Making red cross invisible
                gMapControl1.ShowCenter = false;

                //clear map
                Clear_All_Surfaces();
                

                GMapOverlay markerOverlay1 = new GMapOverlay("markerOverlay1");
                GMapOverlay markerOverlay2 = new GMapOverlay("markerOverlay2");
                

                //add markers
                PointLatLng point1 = new PointLatLng(lat1, long1);
                PointLatLng point2 = new PointLatLng(lat2, long2);

                GMap.NET.WindowsForms.GMapMarker mapMarker1 = new GMarkerGoogle(point1, GMarkerGoogleType.orange);
                GMap.NET.WindowsForms.GMapMarker mapMarker2 = new GMarkerGoogle(point2, GMarkerGoogleType.blue_pushpin);

                //create overlay

                //add all marker to overlay
                mapMarker1.ToolTipText = "RWY Point\n0 m";
                mapMarker2.ToolTipText = TxtFirstName.Text + " " + TxtObstacleType.Text + "\n" + Math.Round(AreaDistance,0) + " m";

                mapMarker1.ToolTipMode = MarkerTooltipMode.Always;
                mapMarker2.ToolTipMode = MarkerTooltipMode.Always;

                System.Drawing.Font fnt = new System.Drawing.Font("Verdana", 12);
                mapMarker1.ToolTip.Font = fnt;
                mapMarker2.ToolTip.Font = fnt;

                SolidBrush tooltipcolor = new SolidBrush(Color.Black);
                mapMarker1.ToolTip.Foreground = tooltipcolor;
                mapMarker2.ToolTip.Foreground = tooltipcolor;

                markerOverlay1.Markers.Add(mapMarker1);
                markerOverlay2.Markers.Add(mapMarker2);

                //cover map with overlay
                gMapControl1.Overlays.Add(markerOverlay1);
                gMapControl1.Overlays.Add(markerOverlay2);

                //Draw routes
                GMapOverlay routes = new GMapOverlay("routes");
                
                List<PointLatLng> points_route = new List<PointLatLng>();
                points_route.Add(new PointLatLng(lat1, long1));
                points_route.Add(new PointLatLng(lat2, long2));
                GMap.NET.WindowsForms.GMapRoute route = new GMap.NET.WindowsForms.GMapRoute(points_route, "RWY to House");
                route.Stroke = new Pen(Color.Red, 3);
                routes.Routes.Add(route);
                gMapControl1.Overlays.Add(routes);

                
                TxtArealDistance.Text = AreaDistance.ToString("0.00");
                TxtPlotCase.Text = Plot_Position_Case.ToString();

                gMapControl1.Invalidate();
                gMapControl1.Update();

                Draw_Checked_Surfaces();

                TxtLog.Text = "Map Created for obstacle at " + TxtLat2.Text + "," + TxtLong2.Text;
            }
            catch
            {

            }
        }

        /*private void UTM_To_LatLong(double Easting_X, double Northing_Y)
        {
            double  a, one_by_f, lambda0, K0, M0;
            double False_Easting_X, f;
            double M, e_2, e_prime_2, mu, e1, phi1, R1, T1, C1, x, N1, D, phi, lambda;

            //Parameter values for WGS and UTM84
            False_Easting_X = 500000.0;
            //False_Northing_Y = 0;
            a = 6378137.0;
            one_by_f = 298.2572201;
            K0 = 0.9996;
            M0 = 0; //distance in meter of origin latitude from equator

            //Input
            //lambda0 = 84.0; //central meridian for zone 44
            lambda0 = Convert.ToDouble(TxtCM.Text);

            //Formula and equation for conversion from UTM to WGS
            f = 1 / one_by_f;
            M = M0 + Northing_Y / K0;
            e_2 = 2.0 * f - f * f;
            e_prime_2 = e_2 / (1.0 - e_2);
            mu = M / (a * (1.0 - e_2 / 4.0 - 3.0 * e_2 * e_2 / 64.0 - 5.0 * e_2 * e_2 * e_2 / 256.0));
            e1 = (1.0 - Math.Sqrt(1 - e_2)) / (1 + Math.Sqrt(1.0 - e_2));

            double phi1_term1 = (3.0 * e1 / 2.0 - 27.0 * e1 * e1 * e1 / 32) * Math.Sin(2 * mu);
            double phi1_term2 = (21.0* e1 * e1 / 16.0 - 55.0 * e1 * e1 * e1 * e1 / 32.0) * Math.Sin(4 * mu);
            double phi1_term3 = (151.0 * e1 * e1 * e1 / 96.0) * Math.Sin(6 * mu);
            double phi1_term4 = (1097.0 * e1 * e1 * e1 * e1 / 512.0) * Math.Sin(8 * mu);

            phi1 = mu + phi1_term1 + phi1_term2 + phi1_term3 + phi1_term4;

            R1 = a * (1.0-e_2)/Math.Pow((1.0- e_2*Math.Sin(phi1)* Math.Sin(phi1)),3.0/2.0);
            T1 = Math.Tan(phi1) * Math.Tan(phi1);
            C1 = e_prime_2 * Math.Cos(phi1) * Math.Cos(phi1);
            x = Easting_X - False_Easting_X;
            N1 = a / (Math.Sqrt(1.0 - e_2 * Math.Sin(phi1) * Math.Sin(phi1)));
            D = x / (N1 * K0);
            double phi_t1 = D * D / 2.0 - (5.0 + 3.0 * T1 + 10.0 * C1 - 4.0 * C1 * C1 - 9.0 * e_prime_2) * D * D * D * D / 24.0;
            double phi_t2 = (61.0 + 90.0 * T1 + 298.0 * C1 + 45.0 * T1 * T1 - 252.0 * e_prime_2 - 3.0 * C1 * C1) * D * D * D * D * D * D / 720.0;
            
            phi = phi1 - (N1 * Math.Tan(phi1) / R1) * (phi_t1 + phi_t2); //latitude in radian

            double lambda_t1 = D - (1.0 + 2.0 * T1 + C1) * D * D * D / 6.0;
            double lambda_t2 = (5.0 - 2.0 * C1 + 28.0 * T1 - 3 * C1 * C1 + 8.0 * e_prime_2 + 24.0 * T1 * T1) * D * D * D * D * D / 120.0;
            lambda = lambda0 * Math.PI / 180.0 + (lambda_t1 + lambda_t2) / Math.Cos(phi1); //longitude in radian

            Final_Latitude_DD = phi * 180.0 / Math.PI;
            Final_Longitude_DD = lambda * 180.0 / Math.PI;

            //MessageBox.Show("phi_t1 +t2 = " + (phi_t1+phi_t2)* ((N1 * Math.Tan(phi1) / R1)) + "\nphi1 = " + phi1);
        }*/

        /*public void LatLong_To_UTM(double latitude_in_degree, double longitude_in_degree)
        {
            double a, one_by_f, lambda0_DD, phi0_DD, K0, M0, f; 
            //double Easting_X, Northing_Y, f; 
            //double e_2, e_prime_2, mu, e1, phi1, R1, T1, C1, x, N1, D, phi, lambda;

            //Parameter values for WGS and UTM84
            //False_Easting_X = 500000.0;
            //False_Northing_Y = 0;
            //Input parameters
            a = 6378137.0;
            one_by_f = 298.2572201;
            K0 = 0.9996;
            M0 = 0; //distance in meter of origin latitude from equator
            f = 1 / one_by_f;
            phi0_DD = 0;
            //lambda0_DD = 84;
            lambda0_DD = Convert.ToDouble(TxtCM.Text);

            var phi0 = phi0_DD * Math.PI / 180;
            var lambda0 = lambda0_DD * Math.PI / 180;

            double Phi_DD = latitude_in_degree; //latitude input in degree decimal
            var Phi = Phi_DD * Math.PI / 180;//lat in radian

            double Lambda_DD = longitude_in_degree; //longitude input in degree decimal
            var Lambda = Lambda_DD * Math.PI / 180; //long in radian

            var e2 = 2 * f - f * f;
            var e_prime2 = e2 / (1 - e2);
            var RM = a * (1 - e2) / Math.Pow((1 - e2 * Math.Pow(Math.Sin(Phi), 2)), 3 / 2);
            var RN = a / Math.Sqrt(1 - e2 * Math.Sin(Phi) * Math.Sin(Phi));
            var T = Math.Tan(Phi) * Math.Tan(Phi);
            var C = e_prime2 * Math.Cos(Phi) * Math.Cos(Phi);
            var A1 = (Lambda - lambda0) * Math.Cos(Phi);
            var M_term1 = (1 - e2 / 4 - 3 * e2 * e2 / 64 - 5 * e2 * e2 * e2 / 256) * Phi;
            var M_term2 = (3 * e2 / 8 + 3 * e2 * e2 / 32 + 45 * e2 * e2 * e2 / 1024) * Math.Sin(2 * Phi);
            var M_term3 = (15 * e2 * e2 / 256 + 45 * e2 * e2 * e2 / 1024) * Math.Sin(4 * Phi);
            var M_term4 = (35 * e2 * e2 * e2 / 3072) * Math.Sin(6 * Phi);
            var M = a * (M_term1 - M_term2 + M_term3 - M_term4);


            var X_term1 = (1 - T + C) * A1 * A1 * A1 / 6;
            var X_term2 = (5 - 18 * T + T * T + 72 * C - 58 * e_prime2) * Math.Pow(A1, 5) / 6;

            var Easting_X = K0 * RN * (A1 + X_term1 + X_term2) + 500000;             //x coordinate

            var Y_term1 = (5 - T + 9 * C + 4 * C * C) * Math.Pow(A1, 4) / 24;

            //TxtMessage.Text = (Math.Pow(A1, three_by_6)).ToString();
            //MessageBox.Show(X_term2.ToString());

            var Y_term2 = (61 - 58 * T + T * T + 600 * C - 330 * e_prime2) * Math.Pow(A1, 6) / 720;
            var Northing_Y = K0 * (M - M0 + RN * Math.Tan(Phi) * (A1 * A1 / 2 + Y_term1 + Y_term2)); // y coordinate

            Final_Easting_X = Easting_X;
            Final_Northing_Y = Northing_Y;

            //MessageBox.Show("EastingX = " + Easting_X + "\nNorthingY = " + Northing_Y);
        }*/

        public double[] Convert_LatLong_To_UTM(double latitude_in_degree, double longitude_in_degree)
        {
            double a, one_by_f, lambda0_DD, phi0_DD, K0, M0, f;
            double[] EastNorthXY = new double[2];
            //double Easting_X, Northing_Y, f; 
            //double e_2, e_prime_2, mu, e1, phi1, R1, T1, C1, x, N1, D, phi, lambda;

            //Parameter values for WGS and UTM84
            //False_Easting_X = 500000.0;
            //False_Northing_Y = 0;

            //Input parameters
            /*a = 6378137.0;
            one_by_f = 298.2572201;
            K0 = 0.9996;
            M0 = 0; //distance in meter of origin latitude from equator
            phi0_DD = 0;*/

            a = Convert.ToDouble(TxtA.Text);
            one_by_f = Convert.ToDouble(TxtOneByF.Text);
            K0 = Convert.ToDouble(TxtK0.Text);
            M0 = Convert.ToDouble(TxtM0.Text);
            phi0_DD = Convert.ToDouble(TxtPhi_DD.Text);

            //lambda0_DD = 84;
            lambda0_DD = Convert.ToDouble(TxtCM.Text);

            f = 1 / one_by_f;

            var phi0 = phi0_DD * Math.PI / 180;
            var lambda0 = lambda0_DD * Math.PI / 180;

            double Phi_DD = latitude_in_degree; //latitude input in degree decimal
            var Phi = Phi_DD * Math.PI / 180;//lat in radian

            double Lambda_DD = longitude_in_degree; //longitude input in degree decimal
            var Lambda = Lambda_DD * Math.PI / 180; //long in radian

            var e2 = 2 * f - f * f;
            var e_prime2 = e2 / (1 - e2);
            var RM = a * (1 - e2) / Math.Pow((1 - e2 * Math.Pow(Math.Sin(Phi), 2)), 3 / 2);
            var RN = a / Math.Sqrt(1 - e2 * Math.Sin(Phi) * Math.Sin(Phi));
            var T = Math.Tan(Phi) * Math.Tan(Phi);
            var C = e_prime2 * Math.Cos(Phi) * Math.Cos(Phi);
            var A1 = (Lambda - lambda0) * Math.Cos(Phi);
            var M_term1 = (1 - e2 / 4 - 3 * e2 * e2 / 64 - 5 * e2 * e2 * e2 / 256) * Phi;
            var M_term2 = (3 * e2 / 8 + 3 * e2 * e2 / 32 + 45 * e2 * e2 * e2 / 1024) * Math.Sin(2 * Phi);
            var M_term3 = (15 * e2 * e2 / 256 + 45 * e2 * e2 * e2 / 1024) * Math.Sin(4 * Phi);
            var M_term4 = (35 * e2 * e2 * e2 / 3072) * Math.Sin(6 * Phi);
            var M = a * (M_term1 - M_term2 + M_term3 - M_term4);


            var X_term1 = (1 - T + C) * A1 * A1 * A1 / 6;
            var X_term2 = (5 - 18 * T + T * T + 72 * C - 58 * e_prime2) * Math.Pow(A1, 5) / 6;

            var Easting_X = K0 * RN * (A1 + X_term1 + X_term2) + 500000;             //x coordinate

            var Y_term1 = (5 - T + 9 * C + 4 * C * C) * Math.Pow(A1, 4) / 24;

            //TxtMessage.Text = (Math.Pow(A1, three_by_6)).ToString();
            //MessageBox.Show(X_term2.ToString());

            var Y_term2 = (61 - 58 * T + T * T + 600 * C - 330 * e_prime2) * Math.Pow(A1, 6) / 720;
            var Northing_Y = K0 * (M - M0 + RN * Math.Tan(Phi) * (A1 * A1 / 2 + Y_term1 + Y_term2)); // y coordinate

            //Final_Easting_X = Easting_X;
            //Final_Northing_Y = Northing_Y;
            EastNorthXY[0] = Easting_X;
            EastNorthXY[1] = Northing_Y;
            return EastNorthXY;
        }

        public int Case_of_Plot_COORD(double eastingX, double northingY)
        {
            int plot_case=0;
            double Y_from_Eq, m, c;
            string position_LAB, position_LBC, position_LCD, position_LDA;

            //equation AB--> L28 
            m = Convert.ToDouble(dataGridView2.Rows[0].Cells[1].Value);//slope of AB
            c = Convert.ToDouble(dataGridView2.Rows[0].Cells[2].Value);//intercept of AB
            Y_from_Eq = m * eastingX + c;
            if(Y_from_Eq > northingY)
            {
                position_LAB = "Below";
            }
            else
            {
                position_LAB = "Above";
            }

            //equation BC--> edge of runway
            m = Convert.ToDouble(dataGridView2.Rows[1].Cells[1].Value);//slope of BC
            c = Convert.ToDouble(dataGridView2.Rows[1].Cells[2].Value);//intercept of BC
            Y_from_Eq = m * eastingX + c;
            if (Y_from_Eq > northingY)
            {
                position_LBC = "Below";
            }
            else
            {
                position_LBC = "Above";
            }

            //equation CD--> L10 
            m = Convert.ToDouble(dataGridView2.Rows[2].Cells[1].Value);//slope of AB
            c = Convert.ToDouble(dataGridView2.Rows[2].Cells[2].Value);//intercept of AB
            Y_from_Eq = m * eastingX + c;
            if (Y_from_Eq > northingY)
            {
                position_LCD = "Below";
            }
            else
            {
                position_LCD = "Above";
            }

            //equation DA--> edge of runway
            m = Convert.ToDouble(dataGridView2.Rows[3].Cells[1].Value);//slope of DA
            c = Convert.ToDouble(dataGridView2.Rows[3].Cells[2].Value);//intercept of DA
            Y_from_Eq = m * eastingX + c;
            if (Y_from_Eq > northingY)
            {
                position_LDA = "Below";
            }
            else
            {
                position_LDA = "Above";
            }

            

            //MessageBox.Show("L28 = " + position_L28 + "L10 = " + position_L10 + "LC = " + position_LC);

            //plot_case
            if(position_LAB == "Above" && position_LBC == "Above" && position_LCD == "Above" && position_LDA == "Above")
            {
                plot_case = 1;
            }
            else if (position_LAB == "Above" && position_LBC == "Above" && position_LCD == "Below" && position_LDA == "Above")
            {
                plot_case = 2;
            }
            else if (position_LAB == "Below" && position_LBC == "Above" && position_LCD == "Below" && position_LDA == "Above")
            {
                plot_case = 3;
            }
            else if (position_LAB == "Below" && position_LBC == "Above" && position_LCD == "Below" && position_LDA == "Below")
            {
                plot_case = 4;
            }
            else if (position_LAB == "Below" && position_LBC == "Below" && position_LCD == "Below" && position_LDA == "Below")
            {
                plot_case = 5; 
            }
            else if (position_LAB == "Above" && position_LBC == "Below" && position_LCD == "Below" && position_LDA == "Below")
            {
                plot_case = 6;
            }
            else if (position_LAB == "Above" && position_LBC == "Below" && position_LCD == "Above" && position_LDA == "Below")
            {
                plot_case = 7;
            }
            else if (position_LAB == "Above" && position_LBC == "Above" && position_LCD == "Above" && position_LDA == "Below")
            {
                plot_case = 8;
            }
            else
            {
                plot_case = 0;
            }

                return plot_case;
        }

        public double Find_Distance_bet_two_pointXY(double X1, double Y1, double X2, double Y2)
        {
            double dist, del_x, del_y;
            del_x = Math.Abs(X1 - X2);
            del_y = Math.Abs(Y1 - Y2);
            dist = Math.Sqrt(del_x * del_x + del_y * del_y);

            return dist;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LblProgress.ForeColor = Color.White;
            for (int i = 0; i <= 81; i++) //0 to 75
            {
                dataGridView1.Rows.Add();
            }

            for (int i = 0; i <= 68; i++) //0 to 62
            {
                dataGridView2.Rows.Add();
            }

            //For FY
            string[] FiscalYearList = System.IO.File.ReadAllLines(@".\InputFolder\FiscalYear.txt");
            foreach (var line in FiscalYearList)
            {
                ComboBoxFY.Items.Add(line);
            }
            //For ObstacleType
            string[] MonthList = System.IO.File.ReadAllLines(@".\InputFolder\ObstacleType.txt");
            foreach (var line in MonthList)
            {
                ComboBoxObstacleType.Items.Add(line);
            }

            //For RWY
            string[] RWYList = System.IO.File.ReadAllLines(@".\InputFolder\AIRPORT_CODE_ICAO.txt");
            foreach (var line in RWYList)
            {
                ComboBoxRWY.Items.Add(line);
            }

            //For Local Level
            string[] LLList = System.IO.File.ReadAllLines(@".\InputFolder\LocalLevel.txt");
            foreach (var line in LLList)
            {
                ComboBoxLocalLevel.Items.Add(line);
            }

            //For Filter
            string[]FilterList = System.IO.File.ReadAllLines(@".\InputFolder\Filter.txt");
            foreach (var line in FilterList)
            {
                ComboBoxFilterBy1.Items.Add(line);
            }

            //For Designation
            string[] DesignationList = System.IO.File.ReadAllLines(@".\InputFolder\Designation.txt");
            foreach (var line in DesignationList)
            {
                ComboBoxDesignation.Items.Add(line);
            }

            //loading text for letter textboxes ------> To
            string[] ToList = System.IO.File.ReadAllLines(@".\InputFolder\TextBox\To.txt");
            TxtLetterTo.Text = "";
            foreach (var line in ToList)
            {
                TxtLetterTo.Text += line;
                TxtLetterTo.Text += Environment.NewLine;
            }

            //loading text for letter textboxes ------> Subject
            string[] SubjectList = System.IO.File.ReadAllLines(@".\InputFolder\TextBox\Subject.txt");
            TxtLetterSubject.Text = "";
            foreach (var line in SubjectList)
            {
                TxtLetterSubject.Text += line;
                TxtLetterSubject.Text += Environment.NewLine;
            }

            //loading text for letter textboxes ------> SignedBy
            string[] SignedByList = System.IO.File.ReadAllLines(@".\InputFolder\TextBox\SignedBy.txt");
            TxtLetterSignedby.Text = "";
            foreach (var line in SignedByList)
            {
                TxtLetterSignedby.Text += line;
                TxtLetterSignedby.Text += Environment.NewLine;
            }

            //loading text for letter textboxes ------> CC
            string[] CCList = System.IO.File.ReadAllLines(@".\InputFolder\TextBox\CC.txt");
            TxtLetterCC.Text = "";
            foreach (var line in CCList)
            {
                TxtLetterCC.Text += line;
                TxtLetterCC.Text += Environment.NewLine;
            }

            //loading text for letter textboxes ------> Title of report
            string[] TitleList = System.IO.File.ReadAllLines(@".\InputFolder\TextBox\TitleOfReport.txt");
            TxtTitleOfReport.Text = "";
            foreach (var line in TitleList)
            {
                TxtTitleOfReport.Text += line;
                TxtTitleOfReport.Text += Environment.NewLine;
            }


            //Loading RWY COORD of airport code specified in Default
            string[] ReadingText = new string[100];
            string RWYCoordFilenName;
            string line1;
            line1 = "";
            RWYCoordFilenName = @".\InputFolder\Default.txt";
            //Pass the file path and file name to the StreamReader constructor
            StreamReader sr = new StreamReader(RWYCoordFilenName);
            //Read the first line of text
            line1 = sr.ReadLine();
            ReadingText[0] = line1;
            //Continue to read until you reach end of file
            int j = 1;
            while (line1 != null)
            {
                //Read the next line
                line1 = sr.ReadLine();
                ReadingText[j] = line1;
                j++;
            }
            //close the file
            sr.Close();

            //load data to datagridview by splitting by tab character
            for (int row = 0; row <= 0; row++)
            {
                string[] splittedtext = ReadingText[row].Split('\t');
                TxtAirportCode.Text = splittedtext[1];
                /*for (int col = 0; col <= 5; col++)
                {
                    dataGridView1.Rows[row - 2].Cells[col].Value = splittedtext[col];
                }*/
            }

            BtnLoadRWYCoord_Click(sender, e);
            //BtnZoomToFit2_Click(sender, e);
            //Draw_Checked_Surfaces();
            //zoom and center to center to runway
            double lat1 = Convert.ToDouble(dataGridView1.Rows[4].Cells["ColLatitude"].Value);
            double long1 = Convert.ToDouble(dataGridView1.Rows[4].Cells["ColLongitude"].Value);
            double lat2 = Convert.ToDouble(dataGridView1.Rows[5].Cells["ColLatitude"].Value);
            double long2 = Convert.ToDouble(dataGridView1.Rows[5].Cells["ColLongitude"].Value);

            gMapControl1.Position = new PointLatLng((lat1 + lat2) / 2, (long1 + long2) / 2);
            gMapControl1.Zoom = 11;
        }

        string FYFolder;

        private void ComboBoxFY_SelectedIndexChanged(object sender, EventArgs e)
        {
            TxtFY.Text = ComboBoxFY.Text;
        }

        private void ComboBoxMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            TxtObstacleType.Text = ComboBoxObstacleType.Text;
        }

        private void ComboBoxLocalLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            TxtLocalLevel.Text = ComboBoxLocalLevel.Text;

            int CurrentIndex;
            CurrentIndex = ComboBoxLocalLevel.SelectedIndex;
            if(CurrentIndex>=0)
            {
                string[] LLNepList = System.IO.File.ReadAllLines(@".\InputFolder\TextBox\LocalLevelNepali.txt");
                TxtNepaliLocalLevel.Text = LLNepList[CurrentIndex];
            }
            
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            //Close();
            
        }

        private void Initial_State_of_Label()
        {
            TxtElev_Permitted.ForeColor = Color.Black;
        }

        private void DeleteTextFields()
        {            
            TxtFY.Text = "";
            TxtObstacleType.Text = "";
            TxtPlotNo.Text = "";

            TxtFirstName.Text = "";
            TxtMiddleName.Text = "";
            TxtLastName.Text = "";

            TxtLocalLevel.Text = "";
            TxtWardNo.Text = "";
            TxtTole.Text = "";

            TxtSurfaceName.Text = "";
            TxtSurfaceHeightaboveRWY.Text = "";
            TxtElev_allow.Text = "";

            TxtRL_Plinth.Text = "";
            TxtHeightAbovePlinth.Text = "";
            TxtElev_Obstacle.Text = "";
            TxtElev_Permitted.Text = "";

            TxtLetterDate.Text = "";
            TxtPreviousLetterDate.Text = "";
            TxtPrevLetterRef.Text = "";

            TxtArealDistance.Text = "";
            TxtPlotCase.Text = "";

            TxtOtherInfo.Text = "";

            TxtLat1.Text = "";
            TxtLong1.Text = "";
            TxtLat2.Text = "";
            TxtLong2.Text = "";


            ComboBoxFY.SelectedIndex = -1;
            ComboBoxObstacleType.SelectedIndex = -1;
            ComboBoxLocalLevel.SelectedIndex = -1;
        }

        private void Function_Add_DB()
        {
            string FiscalYear = TxtFY.Text;
            string ObstacleType = TxtObstacleType.Text;
            string PlotNo = TxtPlotNo.Text;

            string FirstName = TxtFirstName.Text;
            string MiddleName = TxtMiddleName.Text;
            string LastName = TxtLastName.Text;

            string LocalLevel = TxtLocalLevel.Text;
            string WardNo = TxtWardNo.Text;
            string Tole = TxtTole.Text;

            string SurfaceName = TxtSurfaceName.Text;
            string SurfaceHeightAboveRWY = TxtSurfaceHeightaboveRWY.Text;
            string ElevationAllowable = TxtElev_allow.Text;

            string RLOfPlinth = TxtRL_Plinth.Text;
            string HeightAbovePlinth = TxtHeightAbovePlinth.Text;
            string ElevationOfObstacle = TxtElev_Obstacle.Text;
            string PermittedElevation = TxtElev_Permitted.Text;

            string DateOfLetter = TxtLetterDate.Text;
            string LetterTo = TxtLetterTo.Text;

            string RefNoPreviousLetter = TxtPrevLetterRef.Text;
            string DateOfPreviousLetter = TxtPreviousLetterDate.Text;
            string SignedBy = TxtLetterSignedby.Text;
            string CC = TxtLetterCC.Text;
            string AirportCode = TxtAirportCode.Text;

            string ArealDistance = TxtArealDistance.Text;
            string PlotCaseNo = TxtPlotCase.Text;

            string OtherInfo = TxtOtherInfo.Text;

            string lat1RWY = TxtLat1.Text;
            string Long1RWY = TxtLong1.Text;

            string Lat2Obstacle = TxtLat2.Text;
            string Long2Obstacle = TxtLong2.Text;

            string TitleOfReport = TxtTitleOfReport.Text;
            string CalculationDetail = TxtCalculationDetail.Text;

            string Designation = TxtDesignation.Text;


            if (TxtFY.Text == "" || TxtFirstName.Text == "" || TxtPlotNo.Text == "")
            {
                TxtLog.Text += "Either Fiscal Year or FirstName or PlotNo is Empty. Please fill to continue.";
                //TxtLog.Text += Environment.NewLine;
            }
            else
            {
                DialogResult dr = DialogResult.Yes;
                if (AutoAdd == false)
                {
                    dr = MessageBox.Show("Are you sure, you want to Add all data to Database?", "Add", MessageBoxButtons.YesNo);

                }
                if (dr == DialogResult.Yes)
                {
                    //Add
                    SQLiteConnection ConnectDb = new SQLiteConnection("Data Source = ObstacleHeightRecord.sqlite3");
                    ConnectDb.Open();
                    string query = "INSERT INTO TableObstacleHeightRecord(FiscalYear,ObstacleType,PlotNo,FirstName,MiddleName," +
                        "LastName,LocalLevel,WardNo,Tole,SurfaceName, SurfaceHeightAboveRWY,ElevationAllowable,RLOfPlinth," +
                        "HeightAbovePlinth,ElevationOfObstacle, PermittedElevation,DateOfLetter,LetterTo," +
                        "RefNoPreviousLetter,DateOfPreviousLetter, SignedBy,CC,AirportCode," +
                        "ArealDistance,PlotCaseNo, OtherInfo,lat1RWY,Long1RWY,Lat2Obstacle,Long2Obstacle,TitleOfReport,CalculationDetail, Designation) " +
                        "VALUES('" + FiscalYear + "','" + ObstacleType + "','" + PlotNo + "','" + FirstName + "'," +
                        "'" + MiddleName + "','" + LastName + "','" + LocalLevel + "','" + WardNo + "'" +
                        ",'" + Tole + "','" + SurfaceName + "','" + SurfaceHeightAboveRWY + "','" + ElevationAllowable + "','" + RLOfPlinth + "'" +
                        ",'" + HeightAbovePlinth + "','" + ElevationOfObstacle + "','" + PermittedElevation + "','" + DateOfLetter + "','" + LetterTo + "'" +
                        ",'" + RefNoPreviousLetter + "','" + DateOfPreviousLetter + "','" + SignedBy + "','" + CC + "','" + AirportCode + "'" +
                        ",'" + ArealDistance + "','" + PlotCaseNo + "','" + OtherInfo + "','" + lat1RWY + "', '" + Long1RWY + "', '" + Lat2Obstacle + "', '" + Long2Obstacle + "', '" + TitleOfReport + "', '" + CalculationDetail + "', '" + Designation + "' )";// one data format  = '" + Height + "'

                    SQLiteCommand Cmd = new SQLiteCommand(query, ConnectDb);
                    Cmd.ExecuteNonQuery();

                    ConnectDb.Close();

                    //BtnCreateProjectFolder_Click(sender, e);
                    //BtnSave2Txt_Click(sender, e);
                    //BtnResetBill_Click(sender, e);


                    // clear text boxes
                    TxtID.Text = "";
                    DeleteTextFields();
                    Initial_State_of_Label();

                    TxtLog.Text = "Record added successfully of " + FirstName + " " + MiddleName + " " + LastName;
                    //TxtLog.AppendText("Activity: Record Successfully Added : " + ContractID + " of " + Ward + " at " + Location);
                    //TxtLog.AppendText(Environment.NewLine);

                    /*using (System.IO.StreamWriter sw = System.IO.File.AppendText(@".\Log\Log.txt"))
                    {
                        Text2Write = "[" + DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss") + "]" + "  --->  " + "ADD" + " ---> " + ProjectName + " of " + Ward + " at " + Location; ;
                        sw.WriteLine(Text2Write);
                    }*/
                }
                else if (dr == DialogResult.No)
                {
                    //Nothing to do
                }
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            //Function_Add_DB();
        }

        private void BtnLoadAllRecord_Click(object sender, EventArgs e)
        {
            SQLiteConnection ConnectDb = new SQLiteConnection("Data Source = ObstacleHeightRecord.sqlite3");
            ConnectDb.Open();

            string query = "SELECT * FROM TableObstacleHeightRecord";
            SQLiteDataAdapter DataAdptr = new SQLiteDataAdapter(query, ConnectDb);

            System.Data.DataTable Dt = new System.Data.DataTable();
            DataAdptr.Fill(Dt);
            dataGridView3.DataSource = Dt;

            ConnectDb.Close();
            LblLoad.Text = "Recent Activity: Obstacle Height Record Loaded Successfully";

            int rcount = Dt.Rows.Count;
            LblRecordNo.Text = "Total No. of Record loaded:  " + rcount.ToString();
        }

        private void Function_Display_DB()
        {
            if (TxtID.Text == "")
            {
                //TxtLog.AppendText("Enter Project ID to Display");
                //TxtLog.AppendText(Environment.NewLine);
                TxtLog.Text = "Enter ID to Display";
            }
            else
            {
                SQLiteConnection ConnectDb = new SQLiteConnection("Data Source = ObstacleHeightRecord.sqlite3");
                ConnectDb.Open();

                string query = "SELECT * FROM TableObstacleHeightRecord where ID = '" + TxtID.Text + "'";

                SQLiteDataAdapter DataAdptr = new SQLiteDataAdapter(query, ConnectDb);

                System.Data.DataTable Dt = new System.Data.DataTable();
                DataAdptr.Fill(Dt);
                //string value;
                foreach (DataRow row in Dt.Rows) //there is only one row here
                {

                    TxtFY.Text = row[1].ToString();
                    TxtObstacleType.Text = row[2].ToString();
                    TxtPlotNo.Text = row[3].ToString();

                    TxtFirstName.Text = row[4].ToString();
                    TxtMiddleName.Text = row[5].ToString();
                    TxtLastName.Text = row[6].ToString();

                    TxtLocalLevel.Text = row[7].ToString();
                    TxtWardNo.Text = row[8].ToString();
                    TxtTole.Text = row[9].ToString();

                    TxtSurfaceName.Text = row[10].ToString();
                    TxtSurfaceHeightaboveRWY.Text = row[11].ToString();
                    TxtElev_allow.Text = row[12].ToString();

                    TxtRL_Plinth.Text = row[13].ToString();
                    TxtHeightAbovePlinth.Text = row[14].ToString();
                    TxtElev_Obstacle.Text = row[15].ToString();
                    TxtElev_Permitted.Text = row[16].ToString();

                    TxtLetterDate.Text = row[17].ToString();
                    TxtLetterTo.Text = row[18].ToString();
                    TxtPrevLetterRef.Text = row[19].ToString();
                    TxtPreviousLetterDate.Text = row[20].ToString();
                    TxtLetterSignedby.Text = row[21].ToString();
                    TxtLetterCC.Text = row[22].ToString();

                    TxtAirportCode.Text = row[23].ToString();

                    TxtArealDistance.Text = row[24].ToString();
                    TxtPlotCase.Text = row[25].ToString();

                    TxtOtherInfo.Text = row[26].ToString();

                    TxtLat1.Text = row[27].ToString();
                    TxtLong1.Text = row[28].ToString();
                    TxtLat2.Text = row[29].ToString();
                    TxtLong2.Text = row[30].ToString();

                    TxtTitleOfReport.Text = row[31].ToString();
                    TxtCalculationDetail.Text = row[32].ToString();
                    TxtDesignation.Text = row[33].ToString();

                    double Actual_Elev_obs, AllowableElev_Obs;
                    Actual_Elev_obs = Convert.ToDouble(TxtElev_Obstacle.Text);
                    AllowableElev_Obs = Convert.ToDouble(TxtElev_allow.Text);

                    if (Actual_Elev_obs < AllowableElev_Obs)
                    {
                        TxtElev_Permitted.ForeColor = Color.DarkGreen;
                    }
                    else if (Actual_Elev_obs > AllowableElev_Obs)
                    {
                        TxtElev_Permitted.ForeColor = Color.Red;
                    }

                }
                ConnectDb.Close();
            }
        }

        private void BtnDisplay_Click(object sender, EventArgs e)
        {
            //Function_Display_DB();
        }

        private void BtnModify_Click(object sender, EventArgs e)
        {
            //Function_Modify_DB();
            
        }

        private void Function_Modify_DB()
        {
            string ID = TxtID.Text;
            string FiscalYear = TxtFY.Text;
            string ObstacleType = TxtObstacleType.Text;
            string PlotNo = TxtPlotNo.Text;

            string FirstName = TxtFirstName.Text;
            string MiddleName = TxtMiddleName.Text;
            string LastName = TxtLastName.Text;

            string LocalLevel = TxtLocalLevel.Text;
            string WardNo = TxtWardNo.Text;
            string Tole = TxtTole.Text;

            string SurfaceName = TxtSurfaceName.Text;
            string SurfaceHeightAboveRWY = TxtSurfaceHeightaboveRWY.Text;
            string ElevationAllowable = TxtElev_allow.Text;

            string RLOfPlinth = TxtRL_Plinth.Text;
            string HeightAbovePlinth = TxtHeightAbovePlinth.Text;
            string ElevationOfObstacle = TxtElev_Obstacle.Text;
            string PermittedElevation = TxtElev_Permitted.Text;

            string DateOfLetter = TxtLetterDate.Text;
            string LetterTo = TxtLetterTo.Text;

            string RefNoPreviousLetter = TxtPrevLetterRef.Text;
            string DateOfPreviousLetter = TxtPreviousLetterDate.Text;
            string SignedBy = TxtLetterSignedby.Text;
            string CC = TxtLetterCC.Text;
            string AirportCode = TxtAirportCode.Text;

            string ArealDistance = TxtArealDistance.Text;
            string PlotCaseNo = TxtPlotCase.Text;

            string OtherInfo = TxtOtherInfo.Text;

            string lat1RWY = TxtLat1.Text;
            string Long1RWY = TxtLong1.Text;

            string Lat2Obstacle = TxtLat2.Text;
            string Long2Obstacle = TxtLong2.Text;

            string TitleOfReport = TxtTitleOfReport.Text;
            string CalculationDetail = TxtCalculationDetail.Text;

            string Designation = TxtDesignation.Text;


            DialogResult dr = MessageBox.Show("Are you sure, you want to Modify?", "Modify", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                //Modify
                SQLiteConnection ConnectDb = new SQLiteConnection("Data Source = ObstacleHeightRecord.sqlite3");
                ConnectDb.Open();
                string query = "REPLACE INTO TableObstacleHeightRecord(ID,FiscalYear,ObstacleType,PlotNo,FirstName,MiddleName," +
                    "LastName,LocalLevel,WardNo,Tole,SurfaceName, SurfaceHeightAboveRWY,ElevationAllowable,RLOfPlinth," +
                    "HeightAbovePlinth,ElevationOfObstacle, PermittedElevation,DateOfLetter,LetterTo," +
                    "RefNoPreviousLetter,DateOfPreviousLetter, SignedBy,CC,AirportCode," +
                    "ArealDistance,PlotCaseNo, OtherInfo,lat1RWY,Long1RWY,Lat2Obstacle,Long2Obstacle,TitleOfReport,CalculationDetail, Designation) " +
                    "VALUES('" + ID + "', '" + FiscalYear + "','" + ObstacleType + "','" + PlotNo + "','" + FirstName + "'," +
                    "'" + MiddleName + "','" + LastName + "','" + LocalLevel + "','" + WardNo + "'" +
                    ",'" + Tole + "','" + SurfaceName + "','" + SurfaceHeightAboveRWY + "','" + ElevationAllowable + "','" + RLOfPlinth + "'" +
                    ",'" + HeightAbovePlinth + "','" + ElevationOfObstacle + "','" + PermittedElevation + "','" + DateOfLetter + "','" + LetterTo + "'" +
                    ",'" + RefNoPreviousLetter + "','" + DateOfPreviousLetter + "','" + SignedBy + "','" + CC + "','" + AirportCode + "'" +
                    ",'" + ArealDistance + "','" + PlotCaseNo + "','" + OtherInfo + "','" + lat1RWY + "', '" + Long1RWY + "', '" + Lat2Obstacle + "', '" + Long2Obstacle + "', '" + TitleOfReport + "', '" + CalculationDetail + "', '" + Designation + "')";// one data format  = '" + Height + "'

                SQLiteCommand Cmd = new SQLiteCommand(query, ConnectDb);
                Cmd.ExecuteNonQuery();

                ConnectDb.Close();

                double Actual_Elev_obs = Convert.ToDouble(TxtElev_Obstacle.Text);
                double AllowableElev_Obs = Convert.ToDouble(TxtElev_allow.Text);

                if (Actual_Elev_obs < AllowableElev_Obs)
                {
                    TxtElev_Permitted.ForeColor = Color.DarkGreen;
                }
                else if (Actual_Elev_obs > AllowableElev_Obs)
                {
                    TxtElev_Permitted.ForeColor = Color.Red;
                }

                TxtLog.Text = "Record Modified successfully of " + FirstName + " " + LastName;
                //TxtLog.AppendText("Activity: Record Successfully Added : " + ContractID + " of " + Ward + " at " + Location);
                //TxtLog.AppendText(Environment.NewLine);

                /*using (System.IO.StreamWriter sw = System.IO.File.AppendText(@".\Log\Log.txt"))
                {
                    Text2Write = "[" + DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss") + "]" + "  --->  " + "ADD" + " ---> " + ProjectName + " of " + Ward + " at " + Location; ;
                    sw.WriteLine(Text2Write);
                }*/
            }
            else if (dr == DialogResult.No)
            {
                //Nothing to do
            }
        }

        private void Function_Delete_DB()
        {
            string ID = TxtID.Text;
            string FirstName = TxtFirstName.Text;
            string MiddleName = TxtMiddleName.Text;
            string LastName = TxtLastName.Text;

            if (TxtID.Text == "")
            {
                TxtLog.Text = "Enter ID to Delete";
            }
            else
            {
                DialogResult dr = MessageBox.Show("Are You Sure, you want to delete?", "Delete", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    //delete
                    SQLiteConnection ConnectDb = new SQLiteConnection("Data Source = ObstacleHeightRecord.sqlite3");
                    ConnectDb.Open();

                    string query = "DELETE FROM  TableObstacleHeightRecord WHERE ID ='" + TxtID.Text + "' ";
                    SQLiteCommand Cmd = new SQLiteCommand(query, ConnectDb);
                    Cmd.ExecuteNonQuery();

                    ConnectDb.Close();

                    TxtID.Text = "";


                    TxtLog.Text = "Record Deleted successfully of " + FirstName + " " + MiddleName + " " + LastName + "with ID = " + ID;

                    /*using (System.IO.StreamWriter sw = System.IO.File.AppendText(@".\Log\Log.txt"))
                    {
                        Text2Write = "[" + DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss") + "]" + "  --->  " + "DELETE" + " ---> " + "Project ID: " + ProjectID + "  " + ProjectName + " of " + Ward + " at " + Location;
                        sw.WriteLine(Text2Write);
                    }*/

                    // clear text boxes
                    TxtID.Text = "";
                    DeleteTextFields();
                    Initial_State_of_Label();
                }
                else if (dr == DialogResult.No)
                {
                    //Nothing to do
                }

            }
        }
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            //Function_Delete_DB();
        }

        private void BtnAbout_Click(object sender, EventArgs e)
        {
            //FrmAbout fabout = new FrmAbout();
            //fabout.Show();
        }

        private void Function_Open_Recent_Folder()
        {
            try
            {
                /*Cur_Dir = Environment.CurrentDirectory;
                FYFolder = TxtFY.Text;
                Local_Level = TxtLocalLevel.Text;
                FirstName = TxtFirstName.Text;
                Plot_No = TxtPlotNo.Text;

                if (Local_Level == "")
                {
                    Local_Level = "New_Local_Level";
                }
                if (FirstName == "")
                {
                    Local_Level = "New_Firt_Name";
                }
                if (Plot_No == "")
                {
                    Plot_No = "123";
                }

                Project_Folders = Cur_Dir + "\\ObstacleProjectFolders\\" + FYFolder + "\\" + Local_Level + "\\" + TxtFirstName.Text + "_" + TxtPlotNo.Text;*/
                //TxtRecentFolderLocation.Text = project
                //Process.Start(Project_Folders);
                Process.Start(TxtRecentFolderLocation.Text);
            }
            catch
            {

            }
        }

        private void BtnOpenFolder_Click(object sender, EventArgs e)
        {
            //Function_Open_Recent_Folder();
        }
        public void Show_Progress_Percentage()
        {
            double progress;
            //LblProgress.Text = "";
            progress = (PanelFore.Width*1.0 / (PanelBack.Width*1.0)) * 100.0;
            progress = Math.Round(progress, 0);
            LblProgress.Text = progress.ToString() + "%";
        }

        public double FindMaxVal_From_DGV(DataGridView Dgv, int col)
        {
            double maxval, thisval;

            int row = Dgv.RowCount-1;

            maxval = Convert.ToDouble(Dgv.Rows[0].Cells[col].Value);
            for (int i =1; i < row; i++ )
            {
                thisval = Convert.ToDouble(Dgv.Rows[i].Cells[col].Value);
                if(thisval >= maxval)
                {
                    maxval = thisval;
                }
            }
            return maxval;
        }

        private void Function_Calculate()
        {
            SurfaceCount = 0;
            double areal_distance, SurfaceHeight = 0.0;
            int plotCase, ApproachPlotCase;
            double RL_RWY, RL_Plinth, ObstacleHeight, AllowableElev_Obs = 0.0, Actual_Elev_obs, Elev_permitted;
            string SurfaceName = "";
            double m, c;
            bool IsPointInTheStrip;
            double RL_datum_Surface;
            try
            {
                dataGridView4.Rows.Clear();
                areal_distance = Convert.ToDouble(TxtArealDistance.Text);
                plotCase = Convert.ToInt32(TxtPlotCase.Text);

                //RL_RWY = Convert.ToDouble(TxtRL_RWY.Text);
                RL_Plinth = Convert.ToDouble(TxtRL_Plinth.Text);

                ObstacleHeight = Convert.ToDouble(TxtHeightAbovePlinth.Text);
                Actual_Elev_obs = RL_Plinth + ObstacleHeight;
                TxtElev_Obstacle.Text = Actual_Elev_obs.ToString("0.000");
                SurfaceHeight = 0.0;

                double ARP_to_OBs_dist;
                double[] ARP_XY = new double[2];
                double[] Obs_XY = new double[2];
                ARP_XY = Convert_LatLong_To_UTM(Convert.ToDouble(Txt_ARP_Latitude.Text), Convert.ToDouble(Txt_ARP_Longitude.Text));
                Obs_XY = Convert_LatLong_To_UTM(Convert.ToDouble(TxtLat2.Text), Convert.ToDouble(TxtLong2.Text));
                ARP_to_OBs_dist = Find_Distance_bet_two_pointXY(ARP_XY[0], ARP_XY[1], Obs_XY[0], Obs_XY[1]);


                //Horizontal data
                double Height_Hz = Convert.ToDouble(dataGridView5.Rows[4].Cells[2].Value);
                double Radius_Hz = Convert.ToDouble(dataGridView5.Rows[5].Cells[2].Value);

                //Conical data
                double Slope_Co = Convert.ToDouble(dataGridView5.Rows[1].Cells[2].Value);
                double Height_Co = Convert.ToDouble(dataGridView5.Rows[2].Cells[2].Value);

                IsPointInTheStrip = Strip_Case_of_Plot_COORD(Final_Easting_X, Final_Northing_Y);
                if (plotCase >= 1 && plotCase <= 8)
                {
                    if (areal_distance <= Radius_Hz && IsPointInTheStrip == false)//(areal_distance <= 4000 && areal_distance > (117.5+314.68))
                    {
                        RL_datum_Surface = Convert.ToDouble(TxtRL_IHS.Text);
                        SurfaceName = "INNER HORIZONTAL";
                        SurfaceHeight = Height_Hz;
                        AllowableElev_Obs = RL_datum_Surface + SurfaceHeight;

                        //adding data to datagridview4
                        dataGridView4.Rows.Add();
                        SurfaceCount++;
                        dataGridView4.Rows[SurfaceCount - 1].Cells[0].Value = SurfaceCount.ToString();
                        dataGridView4.Rows[SurfaceCount - 1].Cells[1].Value = SurfaceName;
                        dataGridView4.Rows[SurfaceCount - 1].Cells[2].Value = SurfaceHeight.ToString("0.000");
                        dataGridView4.Rows[SurfaceCount - 1].Cells[3].Value = RL_datum_Surface.ToString("0.000");
                        dataGridView4.Rows[SurfaceCount - 1].Cells[4].Value = AllowableElev_Obs.ToString("0.000");
                        dataGridView4.Rows[SurfaceCount - 1].Cells[5].Value = RL_datum_Surface.ToString() + " + " + SurfaceHeight.ToString("0.000") + " = " + AllowableElev_Obs.ToString("0.000");

                    }
                    else if (areal_distance > Radius_Hz && areal_distance <= (Radius_Hz + Height_Co * 100.0 / Slope_Co))
                    {
                        RL_datum_Surface = Convert.ToDouble(TxtRL_IHS.Text);
                        SurfaceName = "CONICAL";
                        SurfaceHeight = Height_Hz + Slope_Co / 100.0 * (areal_distance - Radius_Hz);
                        AllowableElev_Obs = RL_datum_Surface + SurfaceHeight;

                        //adding data to datagridview4
                        dataGridView4.Rows.Add();
                        SurfaceCount++;
                        dataGridView4.Rows[SurfaceCount - 1].Cells[0].Value = SurfaceCount.ToString();
                        dataGridView4.Rows[SurfaceCount - 1].Cells[1].Value = SurfaceName;
                        dataGridView4.Rows[SurfaceCount - 1].Cells[2].Value = SurfaceHeight.ToString("0.000");
                        dataGridView4.Rows[SurfaceCount - 1].Cells[3].Value = RL_datum_Surface.ToString("0.000");
                        dataGridView4.Rows[SurfaceCount - 1].Cells[4].Value = AllowableElev_Obs.ToString("0.000");
                        dataGridView4.Rows[SurfaceCount - 1].Cells[5].Value = RL_datum_Surface + " + (" + Height_Hz.ToString() + " + " + Slope_Co.ToString() + "% * (" + areal_distance.ToString("0.000") + "- " + Radius_Hz.ToString() + ")" + ") = " + AllowableElev_Obs.ToString("0.000");

                    }
                    else if (areal_distance > (Radius_Hz + Height_Co * 100.0 / Slope_Co) && ARP_to_OBs_dist <= 15000) //areal_distance <= 15000
                    {
                        RL_datum_Surface = Convert.ToDouble(TxtRL_IHS.Text);
                        SurfaceName = "OUTER HORIZONTAL";
                        SurfaceHeight = 150;
                        AllowableElev_Obs = RL_datum_Surface + SurfaceHeight;

                        //adding data to datagridview4
                        dataGridView4.Rows.Add();
                        SurfaceCount++;
                        dataGridView4.Rows[SurfaceCount - 1].Cells[0].Value = SurfaceCount.ToString();
                        dataGridView4.Rows[SurfaceCount - 1].Cells[1].Value = SurfaceName;
                        dataGridView4.Rows[SurfaceCount - 1].Cells[2].Value = SurfaceHeight.ToString("0.000");
                        dataGridView4.Rows[SurfaceCount - 1].Cells[3].Value = RL_datum_Surface.ToString("0.000");
                        dataGridView4.Rows[SurfaceCount - 1].Cells[4].Value = AllowableElev_Obs.ToString("0.000");
                        dataGridView4.Rows[SurfaceCount - 1].Cells[5].Value = RL_datum_Surface + " 150 = " + AllowableElev_Obs.ToString("0.000");

                    }
                }

                //Within the strip
                if (IsPointInTheStrip == true)
                {
                    RL_datum_Surface = Convert.ToDouble(TxtRL_IHS.Text);
                    SurfaceName = "INSIDE STRIP BOUNDARY";
                    SurfaceHeight = 0.0;
                    AllowableElev_Obs = RL_datum_Surface + SurfaceHeight;

                    //adding data to datagridview4
                    dataGridView4.Rows.Add();
                    SurfaceCount++;
                    dataGridView4.Rows[SurfaceCount - 1].Cells[0].Value = SurfaceCount.ToString();
                    dataGridView4.Rows[SurfaceCount - 1].Cells[1].Value = SurfaceName;
                    dataGridView4.Rows[SurfaceCount - 1].Cells[2].Value = SurfaceHeight.ToString("0.000");
                    dataGridView4.Rows[SurfaceCount - 1].Cells[3].Value = RL_datum_Surface.ToString("0.000");
                    dataGridView4.Rows[SurfaceCount - 1].Cells[4].Value = AllowableElev_Obs.ToString("0.000");
                    dataGridView4.Rows[SurfaceCount - 1].Cells[5].Value = RL_datum_Surface.ToString() + "+ 0.0 = " + AllowableElev_Obs.ToString("0.000");

                }

                //APPROACH SURFACE
                double length_Ap_First = Convert.ToDouble(dataGridView5.Rows[16].Cells[2].Value);//3000
                double slope_Ap_First = Convert.ToDouble(dataGridView5.Rows[17].Cells[2].Value);//2

                double length_Ap_Second = Convert.ToDouble(dataGridView5.Rows[19].Cells[2].Value);//2.5
                double slope_Ap_Second = Convert.ToDouble(dataGridView5.Rows[20].Cells[2].Value);//2.5

                if (plotCase == 1 || plotCase == 8 || plotCase == 7 || plotCase == 3 || plotCase == 4 || plotCase == 5)
                {

                    ApproachPlotCase = Approach_Case_of_Plot_COORD(Final_Easting_X, Final_Northing_Y);
                    double perp_dist_approach = 0;
                    if (ApproachPlotCase == 10 || ApproachPlotCase == 40)//FIRST SECTION SLOPE UPWARD 2%
                    {
                        RL_datum_Surface = 0;
                        if (ApproachPlotCase == 10)
                        {
                            //Find perpendicular distance from obstacle point to Approach line IJ
                            //equation JI
                            m = Convert.ToDouble(dataGridView2.Rows[5].Cells[1].Value);//slope of JI
                            c = Convert.ToDouble(dataGridView2.Rows[5].Cells[2].Value);//intercept of JI
                            perp_dist_approach = Math.Abs(m * Final_Easting_X - Final_Northing_Y + c) / Math.Sqrt(m * m + 1.0 * 1.0);
                            RL_datum_Surface = Convert.ToDouble(TxtRL_AB_Th.Text);
                        }
                        else if (ApproachPlotCase == 40)
                        {
                            //equation KL
                            m = Convert.ToDouble(dataGridView2.Rows[9].Cells[1].Value);//slope of KL
                            c = Convert.ToDouble(dataGridView2.Rows[9].Cells[2].Value);//intercept of KL
                            perp_dist_approach = Math.Abs(m * Final_Easting_X - Final_Northing_Y + c) / Math.Sqrt(m * m + 1.0 * 1.0);
                            RL_datum_Surface = Convert.ToDouble(Txt_RL_CD_Th.Text);
                        }

                        SurfaceHeight = 0.0 + slope_Ap_First / 100.0 * (perp_dist_approach - 0.0);
                        AllowableElev_Obs = RL_datum_Surface + SurfaceHeight;
                        SurfaceName = "APPROACH - FIRST SECTION";

                        //adding data to datagridview4
                        dataGridView4.Rows.Add();
                        SurfaceCount++;
                        dataGridView4.Rows[SurfaceCount - 1].Cells[0].Value = SurfaceCount.ToString();
                        dataGridView4.Rows[SurfaceCount - 1].Cells[1].Value = SurfaceName;
                        dataGridView4.Rows[SurfaceCount - 1].Cells[2].Value = SurfaceHeight.ToString("0.000");
                        dataGridView4.Rows[SurfaceCount - 1].Cells[3].Value = RL_datum_Surface.ToString("0.000");
                        dataGridView4.Rows[SurfaceCount - 1].Cells[4].Value = AllowableElev_Obs.ToString("0.000");
                        dataGridView4.Rows[SurfaceCount - 1].Cells[5].Value = RL_datum_Surface.ToString() + " + (" + slope_Ap_First.ToString() + "% * (" + perp_dist_approach.ToString("0.000") + ") = " + AllowableElev_Obs.ToString("0.000");

                    }
                    else if (ApproachPlotCase == 20 || ApproachPlotCase == 50)//SECOND SECTION SLOPE UPWARD 2.5%
                    {
                        RL_datum_Surface = 0;
                        if (ApproachPlotCase == 20)
                        {
                            //Find perpendicular distance from obstacle point to Approach line OP
                            //equation OP
                            m = Convert.ToDouble(dataGridView2.Rows[6].Cells[1].Value);//slope of OP
                            c = Convert.ToDouble(dataGridView2.Rows[6].Cells[2].Value);//intercept of OP
                            perp_dist_approach = Math.Abs(m * Final_Easting_X - Final_Northing_Y + c) / Math.Sqrt(m * m + 1.0 * 1.0);
                            RL_datum_Surface = Convert.ToDouble(TxtRL_AB_Th.Text);
                        }
                        else if (ApproachPlotCase == 50)
                        {
                            //equation VU
                            m = Convert.ToDouble(dataGridView2.Rows[10].Cells[1].Value);//slope of VU
                            c = Convert.ToDouble(dataGridView2.Rows[10].Cells[2].Value);//intercept of VU
                            perp_dist_approach = Math.Abs(m * Final_Easting_X - Final_Northing_Y + c) / Math.Sqrt(m * m + 1.0 * 1.0);
                            RL_datum_Surface = Convert.ToDouble(Txt_RL_CD_Th.Text);
                        }

                        SurfaceName = "APPROACH - SECOND SECTION";
                        double Base_Height = slope_Ap_First / 100.0 * length_Ap_First;//2/100*3000=60
                        SurfaceHeight = Base_Height + slope_Ap_Second / 100.0 * (perp_dist_approach - (0.00));//(60+3000)
                        AllowableElev_Obs = RL_datum_Surface + SurfaceHeight;

                        //adding data to datagridview4
                        dataGridView4.Rows.Add();
                        SurfaceCount++;
                        dataGridView4.Rows[SurfaceCount - 1].Cells[0].Value = SurfaceCount.ToString();
                        dataGridView4.Rows[SurfaceCount - 1].Cells[1].Value = SurfaceName;
                        dataGridView4.Rows[SurfaceCount - 1].Cells[2].Value = SurfaceHeight.ToString("0.000");
                        dataGridView4.Rows[SurfaceCount - 1].Cells[3].Value = RL_datum_Surface.ToString("0.000");
                        dataGridView4.Rows[SurfaceCount - 1].Cells[4].Value = AllowableElev_Obs.ToString("0.000");
                        dataGridView4.Rows[SurfaceCount - 1].Cells[5].Value = RL_datum_Surface.ToString() + " + (" + Base_Height.ToString() + " + " + slope_Ap_Second + "% * (" + perp_dist_approach.ToString("0.000") + ") = " + AllowableElev_Obs.ToString("0.000");

                    }
                    else if (ApproachPlotCase == 30 || ApproachPlotCase == 60)//HORIZONTAL SECTION 0% SLOPE AT ELEV. 60+90=150m
                    {
                        if (ApproachPlotCase == 30)
                        {
                            RL_datum_Surface = Convert.ToDouble(TxtRL_AB_Th.Text);
                        }
                        else
                        {
                            RL_datum_Surface = Convert.ToDouble(Txt_RL_CD_Th.Text);
                        }
                        SurfaceName = "APPROACH - HORIZONTAL SECTION";
                        double e1, e2;
                        e1 = slope_Ap_First / 100.0 * length_Ap_First;//60
                        e2 = slope_Ap_Second / 100.0 * length_Ap_Second;//90
                        SurfaceHeight = e1 + e2; //i.e. 150 m
                        AllowableElev_Obs = RL_datum_Surface + SurfaceHeight;

                        //adding data to datagridview4
                        dataGridView4.Rows.Add();
                        SurfaceCount++;
                        dataGridView4.Rows[SurfaceCount - 1].Cells[0].Value = SurfaceCount.ToString();
                        dataGridView4.Rows[SurfaceCount - 1].Cells[1].Value = SurfaceName;
                        dataGridView4.Rows[SurfaceCount - 1].Cells[2].Value = SurfaceHeight.ToString("0.000");
                        dataGridView4.Rows[SurfaceCount - 1].Cells[3].Value = RL_datum_Surface.ToString("0.000");
                        dataGridView4.Rows[SurfaceCount - 1].Cells[4].Value = AllowableElev_Obs.ToString("0.000");
                        dataGridView4.Rows[SurfaceCount - 1].Cells[5].Value = RL_datum_Surface.ToString() + " + (" + e1.ToString() + " + " + e2.ToString() + "" + ") = " + AllowableElev_Obs.ToString("0.000");

                    }

                }

                //TAKE OFF CLIMB SURFACE
                double slope_ToC = Convert.ToDouble(dataGridView5.Rows[39].Cells[2].Value);
                if (plotCase == 1 || plotCase == 8 || plotCase == 7 || plotCase == 3 || plotCase == 4 || plotCase == 5)
                {
                    int TakeOffClimbPlot_case;
                    double perp_dist_TOC = 0;
                    RL_datum_Surface = 0;

                    TakeOffClimbPlot_case = TakeOffClimb_Case_of_Plot_COORD(Final_Easting_X, Final_Northing_Y);
                    //MessageBox.Show("ToC case = " + TakeOffClimbPlot_case.ToString());
                    if (TakeOffClimbPlot_case == 100 || TakeOffClimbPlot_case == 200)
                    {
                        if (TakeOffClimbPlot_case == 100)
                        {
                            //Find perpendicular distance from obstacle point to Approach line IJ
                            //equation TOC_AB
                            m = Convert.ToDouble(dataGridView2.Rows[17].Cells[1].Value);//slope of TOC_AB
                            c = Convert.ToDouble(dataGridView2.Rows[17].Cells[2].Value);//intercept of TOC_AB
                            perp_dist_TOC = Math.Abs(m * Final_Easting_X - Final_Northing_Y + c) / Math.Sqrt(m * m + 1.0 * 1.0);
                            //RL_datum_Surface = Convert.ToDouble(TxtRL_AB_Th.Text);
                            RL_datum_Surface = FindMaxVal_From_DGV(dataGridView8, 2);
                            //MessageBox.Show("ToC AB100 RL = " + RL_datum_Surface.ToString());
                        }
                        else if (TakeOffClimbPlot_case == 200)
                        {
                            //equation TOC_GH
                            m = Convert.ToDouble(dataGridView2.Rows[20].Cells[1].Value);//slope of TOC_GH
                            c = Convert.ToDouble(dataGridView2.Rows[20].Cells[2].Value);//intercept of TOC_GH
                            perp_dist_TOC = Math.Abs(m * Final_Easting_X - Final_Northing_Y + c) / Math.Sqrt(m * m + 1.0 * 1.0);
                            //RL_datum_Surface = Convert.ToDouble(Txt_RL_CD_Th.Text);
                            RL_datum_Surface = FindMaxVal_From_DGV(dataGridView7, 2);
                        }
                        SurfaceHeight = 0.0 + slope_ToC / 100.0 * (perp_dist_TOC - 0.0);
                        AllowableElev_Obs = RL_datum_Surface + SurfaceHeight;
                        SurfaceName = "TAKE-OFF CLIMB SURFACE";

                        //adding data to datagridview4
                        dataGridView4.Rows.Add();
                        SurfaceCount++;
                        dataGridView4.Rows[SurfaceCount - 1].Cells[0].Value = SurfaceCount.ToString();
                        dataGridView4.Rows[SurfaceCount - 1].Cells[1].Value = SurfaceName;
                        dataGridView4.Rows[SurfaceCount - 1].Cells[2].Value = SurfaceHeight.ToString("0.000");
                        dataGridView4.Rows[SurfaceCount - 1].Cells[3].Value = RL_datum_Surface.ToString("0.000");
                        dataGridView4.Rows[SurfaceCount - 1].Cells[4].Value = AllowableElev_Obs.ToString("0.000");
                        dataGridView4.Rows[SurfaceCount - 1].Cells[5].Value = RL_datum_Surface.ToString() + " + (" + slope_ToC.ToString() + "% * (" + perp_dist_TOC.ToString("0.000") + ") = " + AllowableElev_Obs.ToString("0.000");

                    }
                }

                double slope_BL = Convert.ToDouble(dataGridView5.Rows[32].Cells[2].Value);
                double m2, c2;
                int DGV1_index1, DGV1_index2;
                //BALKED LANDING SURFACE CALCULATION
                //if (plotCase == 1 || plotCase == 8 || plotCase == 7 || plotCase == 3 || plotCase == 4 || plotCase == 5)
                //{
                int BLPlot_case;
                double perp_dist_TOC1 = 0;
                RL_datum_Surface = 0;

                m2 = Convert.ToDouble(dataGridView2.Rows[4].Cells[1].Value);//EF
                c2 = Convert.ToDouble(dataGridView2.Rows[4].Cells[2].Value);//EF
                DGV1_index1 = 14;//K
                DGV1_index2 = 15;//L

                BLPlot_case = Balked_Landing_Case_of_Plot_COORD(Final_Easting_X, Final_Northing_Y);
                //MessageBox.Show("BL case = " + BLPlot_case.ToString());
                if (BLPlot_case == 300 || BLPlot_case == 400)
                {
                    if (BLPlot_case == 300)
                    {
                        //Find perpendicular distance from obstacle point to Balked surface line BL_AB
                        //equation BL_AB
                        //approach from CD but surface drawn towards AB
                        m = Convert.ToDouble(dataGridView2.Rows[33].Cells[1].Value);//BL_EF
                        c = Convert.ToDouble(dataGridView2.Rows[33].Cells[2].Value);//BL_EF
                        perp_dist_TOC1 = Math.Abs(m * Final_Easting_X - Final_Northing_Y + c) / Math.Sqrt(m * m + 1.0 * 1.0);

                        RL_datum_Surface = RL_of_RWY_CL_by_Interpolation(m, c, m2, c2, DGV1_index1, DGV1_index2);
                    }
                    else if (BLPlot_case == 400)
                    {
                        //equation BL_GH
                        //approach from AB but surface drawn towards CD
                        m = Convert.ToDouble(dataGridView2.Rows[31].Cells[1].Value);//BL_AB
                        c = Convert.ToDouble(dataGridView2.Rows[31].Cells[2].Value);//BL_AB
                        perp_dist_TOC1 = Math.Abs(m * Final_Easting_X - Final_Northing_Y + c) / Math.Sqrt(m * m + 1.0 * 1.0);

                        RL_datum_Surface = RL_of_RWY_CL_by_Interpolation(m, c, m2, c2, DGV1_index1, DGV1_index2);
                    }
                    SurfaceHeight = 0.0 + slope_BL / 100.0 * (perp_dist_TOC1 - 0.0);
                    AllowableElev_Obs = RL_datum_Surface + SurfaceHeight;
                    SurfaceName = "BALKED LANDING SURFACE";

                    //adding data to datagridview4
                    dataGridView4.Rows.Add();
                    SurfaceCount++;
                    dataGridView4.Rows[SurfaceCount - 1].Cells[0].Value = SurfaceCount.ToString();
                    dataGridView4.Rows[SurfaceCount - 1].Cells[1].Value = SurfaceName;
                    dataGridView4.Rows[SurfaceCount - 1].Cells[2].Value = SurfaceHeight.ToString("0.000");
                    dataGridView4.Rows[SurfaceCount - 1].Cells[3].Value = RL_datum_Surface.ToString("0.000");
                    dataGridView4.Rows[SurfaceCount - 1].Cells[4].Value = AllowableElev_Obs.ToString("0.000");
                    dataGridView4.Rows[SurfaceCount - 1].Cells[5].Value = RL_datum_Surface.ToString() + " + (" + slope_BL.ToString() + "% * (" + perp_dist_TOC1.ToString("0.000") + ") = " + AllowableElev_Obs.ToString("0.000");

                }
                //}

                //TRANSITIONAL SURFACE
                if (plotCase == 1 || plotCase == 2 || plotCase == 3 || plotCase == 5 || plotCase == 6 || plotCase == 7)
                {
                    int TransPlot_case;
                    double perp_dist_TOC2 = 0.0;
                    double Base_Height = 0.0;
                    double Base_Dist = 0.0;
                    double temp_perp, Divergence_App, Slope_App_First_Sec;
                    Slope_App_First_Sec = Convert.ToDouble(dataGridView5.Rows[17].Cells[2].Value); //2.0
                    Divergence_App = Convert.ToDouble(dataGridView5.Rows[14].Cells[2].Value); //45.0;
                    double slope_Trans = Convert.ToDouble(dataGridView5.Rows[25].Cells[2].Value); //14.3
                    //double x1, x2, y1, y2, d0, Ox, Oy;


                    TransPlot_case = Transitional_Case_of_Plot_COORD(Final_Easting_X, Final_Northing_Y);
                    //MessageBox.Show("Trans plot case = " + TransPlot_case.ToString());
                    bool IsTransSurface = false;

                    if (TransPlot_case == 500 || TransPlot_case == 600 || TransPlot_case == 501 || TransPlot_case == 502 || TransPlot_case == 601 || TransPlot_case == 602)
                    {
                        RL_datum_Surface = 0;
                        if (TransPlot_case == 500)
                        {
                            //To find if point lies in Trans zone in from of rwy length
                            m = Convert.ToDouble(dataGridView2.Rows[4].Cells[1].Value);//EF
                            c = Convert.ToDouble(dataGridView2.Rows[4].Cells[2].Value);//EF

                            //slope and intercept of line perpendicular to EF
                            m2 = -1.0 / m;
                            c2 = Final_Northing_Y - m2 * Final_Easting_X;

                            double this_RL = RL_of_RWY_CL_by_Interpolation(m, c, m2, c2, 14, 15);
                            Height_Hz = Convert.ToDouble(dataGridView5.Rows[4].Cells[2].Value); //45.0;
                            double RL_IHs = Convert.ToDouble(TxtRL_IHS.Text);

                            //horizontal distance form CL of RWY making boundary for Transition surface
                            double temp_dist = (RL_IHs + Height_Hz - this_RL) * 100 / slope_Trans;


                            //Find perpendicular distance from obstacle point to Approach line IJ
                            //equation TOC_AB
                            m = Convert.ToDouble(dataGridView2.Rows[41].Cells[1].Value);//slope of Trans_JK
                            c = Convert.ToDouble(dataGridView2.Rows[41].Cells[2].Value);//intercept of Trans_JK
                            double perp_dist_JK = Math.Abs(m * Final_Easting_X - Final_Northing_Y + c) / Math.Sqrt(m * m + 1.0 * 1.0);


                            if (perp_dist_JK <= temp_dist)
                            {
                                Base_Height = 0.0;
                                Base_Dist = 0.0;
                                RL_datum_Surface = this_RL;
                                perp_dist_TOC2 = perp_dist_JK;

                                IsTransSurface = true;
                            }
                        }
                        else if (TransPlot_case == 600)
                        {
                            //To find if point lies in Trans zone in from of rwy length
                            m = Convert.ToDouble(dataGridView2.Rows[4].Cells[1].Value);//EF
                            c = Convert.ToDouble(dataGridView2.Rows[4].Cells[2].Value);//EF

                            //slope and intercept of line perpendicular to EF
                            m2 = -1.0 / m;
                            c2 = Final_Northing_Y - m2 * Final_Easting_X;

                            double this_RL = RL_of_RWY_CL_by_Interpolation(m, c, m2, c2, 14, 15);
                            Height_Hz = Convert.ToDouble(dataGridView5.Rows[4].Cells[2].Value); //45.0;
                            double RL_IHs = Convert.ToDouble(TxtRL_IHS.Text);

                            //horizontal distance form CL of RWY making boundary for Transition surface
                            double temp_dist = (RL_IHs + Height_Hz - this_RL) * 100 / slope_Trans;

                            //equation Trans_LI
                            m = Convert.ToDouble(dataGridView2.Rows[42].Cells[1].Value);//slope of TOC_GH
                            c = Convert.ToDouble(dataGridView2.Rows[42].Cells[2].Value);//intercept of TOC_GH
                            double perp_dist_LI = Math.Abs(m * Final_Easting_X - Final_Northing_Y + c) / Math.Sqrt(m * m + 1.0 * 1.0);

                            if (perp_dist_LI <= temp_dist)
                            {
                                Base_Height = 0.0;
                                Base_Dist = 0.0;
                                RL_datum_Surface = this_RL;
                                perp_dist_TOC2 = perp_dist_LI;

                                IsTransSurface = true;
                            }
                        }
                        if (TransPlot_case == 501)
                        {
                            IsTransSurface = true;
                            //Find perpendicular distance from obstacle point to Approach line IJ
                            //equation TOC_AB
                            m = Convert.ToDouble(dataGridView2.Rows[41].Cells[1].Value);//slope of Trans_JK
                            c = Convert.ToDouble(dataGridView2.Rows[41].Cells[2].Value);//intercept of Trans_JK
                            perp_dist_TOC2 = Math.Abs(m * Final_Easting_X - Final_Northing_Y + c) / Math.Sqrt(m * m + 1.0 * 1.0);


                            //equation JI
                            m = Convert.ToDouble(dataGridView2.Rows[5].Cells[1].Value);//slope of JI
                            c = Convert.ToDouble(dataGridView2.Rows[5].Cells[2].Value);//intercept of JI
                            temp_perp = Math.Abs(m * Final_Easting_X - Final_Northing_Y + c) / Math.Sqrt(m * m + 1.0 * 1.0);

                            Base_Height = temp_perp * Slope_App_First_Sec / 100.0;
                            Base_Dist = temp_perp * Divergence_App / 100.0;

                            RL_datum_Surface = Convert.ToDouble(TxtRL_AB_Th.Text);

                        }
                        else if (TransPlot_case == 502)
                        {
                            IsTransSurface = true;
                            //Find perpendicular distance from obstacle point to Approach line IJ
                            //equation TOC_AB
                            m = Convert.ToDouble(dataGridView2.Rows[41].Cells[1].Value);//slope of Trans_JK
                            c = Convert.ToDouble(dataGridView2.Rows[41].Cells[2].Value);//intercept of Trans_JK
                            perp_dist_TOC2 = Math.Abs(m * Final_Easting_X - Final_Northing_Y + c) / Math.Sqrt(m * m + 1.0 * 1.0);

                            //double temp_perp, Divergence_App = 15.0, Slope_App = 2.0;
                            //equation JI
                            m = Convert.ToDouble(dataGridView2.Rows[9].Cells[1].Value);//slope of KL
                            c = Convert.ToDouble(dataGridView2.Rows[9].Cells[2].Value);//intercept of KL
                            temp_perp = Math.Abs(m * Final_Easting_X - Final_Northing_Y + c) / Math.Sqrt(m * m + 1.0 * 1.0);

                            Base_Height = temp_perp * Slope_App_First_Sec / 100.0;
                            Base_Dist = temp_perp * Divergence_App / 100.0;

                            RL_datum_Surface = Convert.ToDouble(Txt_RL_CD_Th.Text);

                        }
                        else if (TransPlot_case == 601)
                        {
                            IsTransSurface = true;
                            //Find perpendicular distance from obstacle point to Approach line IJ
                            //equation TOC_AB
                            m = Convert.ToDouble(dataGridView2.Rows[42].Cells[1].Value);//slope of Trans_JK
                            c = Convert.ToDouble(dataGridView2.Rows[42].Cells[2].Value);//intercept of Trans_JK
                            perp_dist_TOC2 = Math.Abs(m * Final_Easting_X - Final_Northing_Y + c) / Math.Sqrt(m * m + 1.0 * 1.0);

                            //double temp_perp, Divergence_App = 15.0, Slope_App = 2.0;
                            //equation JI
                            m = Convert.ToDouble(dataGridView2.Rows[5].Cells[1].Value);//slope of JI
                            c = Convert.ToDouble(dataGridView2.Rows[5].Cells[2].Value);//intercept of JI
                            temp_perp = Math.Abs(m * Final_Easting_X - Final_Northing_Y + c) / Math.Sqrt(m * m + 1.0 * 1.0);

                            Base_Height = temp_perp * Slope_App_First_Sec / 100.0;
                            Base_Dist = temp_perp * Divergence_App / 100.0;

                            RL_datum_Surface = Convert.ToDouble(TxtRL_AB_Th.Text);

                        }
                        else if (TransPlot_case == 602)
                        {
                            IsTransSurface = true;
                            //Find perpendicular distance from obstacle point to Approach line IJ
                            //equation TOC_AB
                            m = Convert.ToDouble(dataGridView2.Rows[42].Cells[1].Value);//slope of Trans_JK
                            c = Convert.ToDouble(dataGridView2.Rows[42].Cells[2].Value);//intercept of Trans_JK
                            perp_dist_TOC2 = Math.Abs(m * Final_Easting_X - Final_Northing_Y + c) / Math.Sqrt(m * m + 1.0 * 1.0);

                            //double temp_perp, Divergence_App = 15.0, Slope_App = 2.0;
                            //equation JI
                            m = Convert.ToDouble(dataGridView2.Rows[9].Cells[1].Value);//slope of KL
                            c = Convert.ToDouble(dataGridView2.Rows[9].Cells[2].Value);//intercept of KL
                            temp_perp = Math.Abs(m * Final_Easting_X - Final_Northing_Y + c) / Math.Sqrt(m * m + 1.0 * 1.0);

                            Base_Height = temp_perp * Slope_App_First_Sec / 100.0;
                            Base_Dist = temp_perp * Divergence_App / 100.0;

                            RL_datum_Surface = Convert.ToDouble(Txt_RL_CD_Th.Text);

                        }

                        if (IsTransSurface == true)
                        {
                            SurfaceHeight = Base_Height + slope_Trans / 100.0 * (perp_dist_TOC2 - Base_Dist);
                            AllowableElev_Obs = RL_datum_Surface + SurfaceHeight;
                            SurfaceName = "TRANSITIONAL SURFACE";

                            //adding data to datagridview4
                            dataGridView4.Rows.Add();
                            SurfaceCount++;
                            dataGridView4.Rows[SurfaceCount - 1].Cells[0].Value = SurfaceCount.ToString();
                            dataGridView4.Rows[SurfaceCount - 1].Cells[1].Value = SurfaceName;
                            dataGridView4.Rows[SurfaceCount - 1].Cells[2].Value = SurfaceHeight.ToString("0.000");
                            dataGridView4.Rows[SurfaceCount - 1].Cells[3].Value = RL_datum_Surface.ToString("0.000");
                            dataGridView4.Rows[SurfaceCount - 1].Cells[4].Value = AllowableElev_Obs.ToString("0.000");
                            dataGridView4.Rows[SurfaceCount - 1].Cells[5].Value = RL_datum_Surface.ToString() + " + " + Base_Height.ToString("0.000") + " + (" + slope_Trans.ToString() + "% * (" + perp_dist_TOC2.ToString("0.000") + " - " + Base_Dist.ToString("0.000") + " )) = " + AllowableElev_Obs.ToString("0.000");
                        }


                    }
                }

                //INNER APPROACH
                double slope_IA = Convert.ToDouble(dataGridView5.Rows[10].Cells[2].Value);
                if (plotCase == 1 || plotCase == 8 || plotCase == 7 || plotCase == 3 || plotCase == 4 || plotCase == 5)
                {
                    int IA_Plot_case;
                    double perp_dist_IA = 0;
                    RL_datum_Surface = 0;

                    IA_Plot_case = Inner_Approach_Case_of_Plot_COORD(Final_Easting_X, Final_Northing_Y);
                    if (IA_Plot_case == 700 || IA_Plot_case == 800)//FIRST SECTION SLOPE UPWARD 2%
                    {
                        if (IA_Plot_case == 700)
                        {
                            //Find perpendicular distance from obstacle point to Approach line IJ
                            //equation JI
                            m = Convert.ToDouble(dataGridView2.Rows[43].Cells[1].Value);//slope of JI
                            c = Convert.ToDouble(dataGridView2.Rows[43].Cells[2].Value);//intercept of JI
                            perp_dist_IA = Math.Abs(m * Final_Easting_X - Final_Northing_Y + c) / Math.Sqrt(m * m + 1.0 * 1.0);
                            RL_datum_Surface = Convert.ToDouble(TxtRL_AB_Th.Text);
                        }
                        else if (IA_Plot_case == 800)
                        {
                            //equation KL
                            m = Convert.ToDouble(dataGridView2.Rows[45].Cells[1].Value);//slope of KL
                            c = Convert.ToDouble(dataGridView2.Rows[45].Cells[2].Value);//intercept of KL
                            perp_dist_IA = Math.Abs(m * Final_Easting_X - Final_Northing_Y + c) / Math.Sqrt(m * m + 1.0 * 1.0);
                            RL_datum_Surface = Convert.ToDouble(Txt_RL_CD_Th.Text);
                        }
                        SurfaceHeight = 0.0 + slope_IA / 100.0 * (perp_dist_IA - 0.0);
                        AllowableElev_Obs = RL_datum_Surface + SurfaceHeight;
                        SurfaceName = "INNER APPROACH";

                        //adding data to datagridview4
                        dataGridView4.Rows.Add();
                        SurfaceCount++;
                        dataGridView4.Rows[SurfaceCount - 1].Cells[0].Value = SurfaceCount.ToString();
                        dataGridView4.Rows[SurfaceCount - 1].Cells[1].Value = SurfaceName;
                        dataGridView4.Rows[SurfaceCount - 1].Cells[2].Value = SurfaceHeight.ToString("0.000");
                        dataGridView4.Rows[SurfaceCount - 1].Cells[3].Value = RL_datum_Surface.ToString("0.000");
                        dataGridView4.Rows[SurfaceCount - 1].Cells[4].Value = AllowableElev_Obs.ToString("0.000");
                        dataGridView4.Rows[SurfaceCount - 1].Cells[5].Value = RL_datum_Surface.ToString() + " + (" + slope_IA.ToString() + "% * (" + perp_dist_IA.ToString("0.000") + ") = " + AllowableElev_Obs.ToString("0.000");

                    }
                }

                //INNER TRANSITIONAL SURFACE CD
                double Divergence_BL, slope_IT;
                Divergence_BL = Convert.ToDouble(dataGridView5.Rows[31].Cells[2].Value);
                //slope_BL = Convert.ToDouble(dataGridView5.Rows[32].Cells[2].Value);
                slope_IT = Convert.ToDouble(dataGridView5.Rows[27].Cells[2].Value);


                if (plotCase == 1 || plotCase == 2 || plotCase == 3 || plotCase == 5 || plotCase == 6 || plotCase == 7)
                {
                    int IT_Plot_Case;
                    double perp_dist_TOC = 0;
                    double Base_Height = 0;
                    double Base_Dist = 0;

                    IT_Plot_Case = InnerTransitional_Case_of_Plot_COORD_CD(Final_Easting_X, Final_Northing_Y);
                    bool IsInner_CD_TransSurface = false;
                    if (IT_Plot_Case == 5000 || IT_Plot_Case == 6000 || IT_Plot_Case == 5001 || IT_Plot_Case == 6001 || IT_Plot_Case == 5002 || IT_Plot_Case == 6002)
                    {
                        RL_datum_Surface = 0;
                        if (IT_Plot_Case == 5000)
                        {
                            //To find if point lies in Trans zone in from of rwy length
                            m = Convert.ToDouble(dataGridView2.Rows[4].Cells[1].Value);//EF
                            c = Convert.ToDouble(dataGridView2.Rows[4].Cells[2].Value);//EF

                            //slope and intercept of line perpendicular to EF
                            m2 = -1.0 / m;
                            c2 = Final_Northing_Y - m2 * Final_Easting_X;

                            double this_RL = RL_of_RWY_CL_by_Interpolation(m, c, m2, c2, 14, 15);
                            Height_Hz = Convert.ToDouble(dataGridView5.Rows[4].Cells[2].Value); //45.0;
                            double RL_IHs = Convert.ToDouble(TxtRL_IHS.Text);

                            //horizontal distance form CL of RWY making boundary for Transition surface
                            double temp_dist = (RL_IHs + Height_Hz - this_RL) * 100 / slope_IT;


                            //Find perpendicular distance from obstacle point to Inner Approach line EKV

                            m = Convert.ToDouble(dataGridView2.Rows[49].Cells[1].Value);//slope of Trans_EKV
                            c = Convert.ToDouble(dataGridView2.Rows[49].Cells[2].Value);//intercept of Trans_EKV
                            double perp_dist_EKV = Math.Abs(m * Final_Easting_X - Final_Northing_Y + c) / Math.Sqrt(m * m + 1.0 * 1.0);


                            if (perp_dist_EKV <= temp_dist)
                            {
                                Base_Height = 0.0;
                                Base_Dist = 0.0;
                                RL_datum_Surface = this_RL;
                                perp_dist_TOC = perp_dist_EKV;

                                IsInner_CD_TransSurface = true;
                            }
                        }
                        else if (IT_Plot_Case == 6000)
                        {
                            //To find if point lies in Trans zone in from of rwy length
                            m = Convert.ToDouble(dataGridView2.Rows[4].Cells[1].Value);//EF
                            c = Convert.ToDouble(dataGridView2.Rows[4].Cells[2].Value);//EF

                            //slope and intercept of line perpendicular to EF
                            m2 = -1.0 / m;
                            c2 = Final_Northing_Y - m2 * Final_Easting_X;

                            double this_RL = RL_of_RWY_CL_by_Interpolation(m, c, m2, c2, 14, 15);
                            Height_Hz = Convert.ToDouble(dataGridView5.Rows[4].Cells[2].Value); //45.0;
                            double RL_IHs = Convert.ToDouble(TxtRL_IHS.Text);

                            //horizontal distance form CL of RWY making boundary for Transition surface
                            double temp_dist = (RL_IHs + Height_Hz - this_RL) * 100 / slope_IT;

                            //equation Trans_LI
                            m = Convert.ToDouble(dataGridView2.Rows[50].Cells[1].Value);//slope of IA_LU
                            c = Convert.ToDouble(dataGridView2.Rows[50].Cells[2].Value);//intercept of IL_LU
                            double perp_dist_FLU = Math.Abs(m * Final_Easting_X - Final_Northing_Y + c) / Math.Sqrt(m * m + 1.0 * 1.0);

                            if (perp_dist_FLU <= temp_dist)
                            {
                                Base_Height = 0.0;
                                Base_Dist = 0.0;
                                RL_datum_Surface = this_RL;
                                perp_dist_TOC = perp_dist_FLU;

                                IsInner_CD_TransSurface = true;
                            }
                        }
                        /*if (IT_Plot_Case == 5000)
                        {
                            //Find perpendicular distance from obstacle point to Approach line IJ
                            //equation TOC_AB
                            m = Convert.ToDouble(dataGridView2.Rows[49].Cells[1].Value);//slope of Trans_JK
                            c = Convert.ToDouble(dataGridView2.Rows[49].Cells[2].Value);//intercept of Trans_JK
                            perp_dist_TOC = Math.Abs(m * Final_Easting_X - Final_Northing_Y + c) / Math.Sqrt(m * m + 1.0 * 1.0);
                            Base_Height = 0.0;
                            Base_Dist = 0.0;
                        }
                        else if (IT_Plot_Case == 6000)
                        {
                            //equation Trans_LI
                            m = Convert.ToDouble(dataGridView2.Rows[50].Cells[1].Value);//slope of TOC_GH
                            c = Convert.ToDouble(dataGridView2.Rows[50].Cells[2].Value);//intercept of TOC_GH
                            perp_dist_TOC = Math.Abs(m * Final_Easting_X - Final_Northing_Y + c) / Math.Sqrt(m * m + 1.0 * 1.0);
                            Base_Height = 0.0;
                            Base_Dist = 0.0;
                        }*/
                        else if (IT_Plot_Case == 5001)
                        {
                            IsInner_CD_TransSurface = true;
                            //equation Trans_LI
                            m = Convert.ToDouble(dataGridView2.Rows[33].Cells[1].Value);//slope of BL_EF
                            c = Convert.ToDouble(dataGridView2.Rows[33].Cells[2].Value);//intercept of BL_EF
                            double d1 = Math.Abs(m * Final_Easting_X - Final_Northing_Y + c) / Math.Sqrt(m * m + 1.0 * 1.0);

                            m = Convert.ToDouble(dataGridView2.Rows[49].Cells[1].Value);//slope of IA_KV
                            c = Convert.ToDouble(dataGridView2.Rows[49].Cells[2].Value);//intercept of IA_KV
                            perp_dist_TOC = Math.Abs(m * Final_Easting_X - Final_Northing_Y + c) / Math.Sqrt(m * m + 1.0 * 1.0);

                            Base_Height = d1 * slope_BL / 100.0;
                            Base_Dist = Divergence_BL / 100.0 * d1;

                            RL_datum_Surface = Convert.ToDouble(TxtRL_AB_Th.Text);
                        }
                        else if (IT_Plot_Case == 5002)
                        {
                            IsInner_CD_TransSurface = true;
                            //equation Trans_LI
                            m = Convert.ToDouble(dataGridView2.Rows[45].Cells[1].Value);//slope of TOC_GH
                            c = Convert.ToDouble(dataGridView2.Rows[45].Cells[2].Value);//intercept of TOC_GH
                            double d1 = Math.Abs(m * Final_Easting_X - Final_Northing_Y + c) / Math.Sqrt(m * m + 1.0 * 1.0);

                            m = Convert.ToDouble(dataGridView2.Rows[49].Cells[1].Value);//slope of TOC_GH
                            c = Convert.ToDouble(dataGridView2.Rows[49].Cells[2].Value);//intercept of TOC_GH
                            perp_dist_TOC = Math.Abs(m * Final_Easting_X - Final_Northing_Y + c) / Math.Sqrt(m * m + 1.0 * 1.0);

                            Base_Height = d1 * slope_IA / 100.0;
                            Base_Dist = 0.0;

                            RL_datum_Surface = Convert.ToDouble(Txt_RL_CD_Th.Text);
                        }
                        else if (IT_Plot_Case == 6001)
                        {
                            IsInner_CD_TransSurface = true;
                            //equation Trans_LI
                            m = Convert.ToDouble(dataGridView2.Rows[33].Cells[1].Value);//slope of TOC_GH
                            c = Convert.ToDouble(dataGridView2.Rows[33].Cells[2].Value);//intercept of TOC_GH
                            double d1 = Math.Abs(m * Final_Easting_X - Final_Northing_Y + c) / Math.Sqrt(m * m + 1.0 * 1.0);

                            m = Convert.ToDouble(dataGridView2.Rows[50].Cells[1].Value);//slope of TOC_GH
                            c = Convert.ToDouble(dataGridView2.Rows[50].Cells[2].Value);//intercept of TOC_GH
                            perp_dist_TOC = Math.Abs(m * Final_Easting_X - Final_Northing_Y + c) / Math.Sqrt(m * m + 1.0 * 1.0);

                            Base_Height = d1 * slope_BL / 100.0;
                            Base_Dist = Divergence_BL / 100.0 * d1;

                            RL_datum_Surface = Convert.ToDouble(TxtRL_AB_Th.Text);
                        }
                        else if (IT_Plot_Case == 6002)
                        {
                            IsInner_CD_TransSurface = true;
                            //equation Trans_LI
                            m = Convert.ToDouble(dataGridView2.Rows[45].Cells[1].Value);//slope of TOC_GH
                            c = Convert.ToDouble(dataGridView2.Rows[45].Cells[2].Value);//intercept of TOC_GH
                            double d1 = Math.Abs(m * Final_Easting_X - Final_Northing_Y + c) / Math.Sqrt(m * m + 1.0 * 1.0);

                            m = Convert.ToDouble(dataGridView2.Rows[50].Cells[1].Value);//slope of TOC_GH
                            c = Convert.ToDouble(dataGridView2.Rows[50].Cells[2].Value);//intercept of TOC_GH
                            perp_dist_TOC = Math.Abs(m * Final_Easting_X - Final_Northing_Y + c) / Math.Sqrt(m * m + 1.0 * 1.0);

                            Base_Height = d1 * slope_IA / 100.0;
                            Base_Dist = 0.0;

                            RL_datum_Surface = Convert.ToDouble(Txt_RL_CD_Th.Text);
                        }

                        if (IsInner_CD_TransSurface == true)
                        {
                            SurfaceHeight = Base_Height + slope_IT / 100.0 * (perp_dist_TOC - Base_Dist);
                            AllowableElev_Obs = RL_datum_Surface + SurfaceHeight;
                            SurfaceName = "INNER TRANSITIONAL SURFACE CD";

                            //adding data to datagridview4
                            dataGridView4.Rows.Add();
                            SurfaceCount++;
                            dataGridView4.Rows[SurfaceCount - 1].Cells[0].Value = SurfaceCount.ToString();
                            dataGridView4.Rows[SurfaceCount - 1].Cells[1].Value = SurfaceName;
                            dataGridView4.Rows[SurfaceCount - 1].Cells[2].Value = SurfaceHeight.ToString("0.000");
                            dataGridView4.Rows[SurfaceCount - 1].Cells[3].Value = RL_datum_Surface.ToString("0.000");
                            dataGridView4.Rows[SurfaceCount - 1].Cells[4].Value = AllowableElev_Obs.ToString("0.000");
                            dataGridView4.Rows[SurfaceCount - 1].Cells[5].Value = RL_datum_Surface.ToString() + " + " + Base_Height.ToString() + " + (" + slope_IT + "% * (" + perp_dist_TOC.ToString("0.000") + " - " + Base_Dist.ToString() + ")) = " + AllowableElev_Obs.ToString("0.000");

                        }

                    }
                }

                //INNER TRANSITIONAL SURFACE AB
                if (plotCase == 1 || plotCase == 2 || plotCase == 3 || plotCase == 5 || plotCase == 6 || plotCase == 7)
                {
                    int IT_Plot_Case;
                    double perp_dist_TOC = 0;
                    double Base_Height = 0;
                    double Base_Dist = 0;

                    IT_Plot_Case = InnerTransitional_Case_of_Plot_COORD_AB(Final_Easting_X, Final_Northing_Y);
                    bool IsInner_AB_TransSurface = false;
                    if (IT_Plot_Case == 7000 || IT_Plot_Case == 8000 || IT_Plot_Case == 7001 || IT_Plot_Case == 8001 || IT_Plot_Case == 7002 || IT_Plot_Case == 8002)
                    {
                        RL_datum_Surface = 0;
                        if (IT_Plot_Case == 7000)
                        {
                            //To find if point lies in Trans zone in from of rwy length
                            m = Convert.ToDouble(dataGridView2.Rows[4].Cells[1].Value);//EF
                            c = Convert.ToDouble(dataGridView2.Rows[4].Cells[2].Value);//EF

                            //slope and intercept of line perpendicular to EF
                            m2 = -1.0 / m;
                            c2 = Final_Northing_Y - m2 * Final_Easting_X;

                            double this_RL = RL_of_RWY_CL_by_Interpolation(m, c, m2, c2, 14, 15);
                            Height_Hz = Convert.ToDouble(dataGridView5.Rows[4].Cells[2].Value); //45.0;
                            double RL_IHs = Convert.ToDouble(TxtRL_IHS.Text);

                            //horizontal distance form CL of RWY making boundary for Transition surface
                            double temp_dist = (RL_IHs + Height_Hz - this_RL) * 100 / slope_IT;


                            //Find perpendicular distance from obstacle point to Inner Approach line EKV

                            m = Convert.ToDouble(dataGridView2.Rows[47].Cells[1].Value);//slope of Trans_EKV
                            c = Convert.ToDouble(dataGridView2.Rows[47].Cells[2].Value);//intercept of Trans_EKV
                            double perp_dist_AJO = Math.Abs(m * Final_Easting_X - Final_Northing_Y + c) / Math.Sqrt(m * m + 1.0 * 1.0);


                            if (perp_dist_AJO <= temp_dist)
                            {
                                Base_Height = 0.0;
                                Base_Dist = 0.0;
                                RL_datum_Surface = this_RL;
                                perp_dist_TOC = perp_dist_AJO;

                                IsInner_AB_TransSurface = true;
                            }

                        }
                        else if (IT_Plot_Case == 8000)
                        {
                            //To find if point lies in Trans zone in from of rwy length
                            m = Convert.ToDouble(dataGridView2.Rows[4].Cells[1].Value);//EF
                            c = Convert.ToDouble(dataGridView2.Rows[4].Cells[2].Value);//EF

                            //slope and intercept of line perpendicular to EF
                            m2 = -1.0 / m;
                            c2 = Final_Northing_Y - m2 * Final_Easting_X;

                            double this_RL = RL_of_RWY_CL_by_Interpolation(m, c, m2, c2, 14, 15);
                            Height_Hz = Convert.ToDouble(dataGridView5.Rows[4].Cells[2].Value); //45.0;
                            double RL_IHs = Convert.ToDouble(TxtRL_IHS.Text);

                            //horizontal distance form CL of RWY making boundary for Transition surface
                            double temp_dist = (RL_IHs + Height_Hz - this_RL) * 100 / slope_IT;

                            //equation Trans_LI
                            m = Convert.ToDouble(dataGridView2.Rows[48].Cells[1].Value);//slope of IA_LU
                            c = Convert.ToDouble(dataGridView2.Rows[48].Cells[2].Value);//intercept of IL_LU
                            double perp_dist_BIP = Math.Abs(m * Final_Easting_X - Final_Northing_Y + c) / Math.Sqrt(m * m + 1.0 * 1.0);

                            if (perp_dist_BIP <= temp_dist)
                            {
                                Base_Height = 0.0;
                                Base_Dist = 0.0;
                                RL_datum_Surface = this_RL;
                                perp_dist_TOC = perp_dist_BIP;

                                IsInner_AB_TransSurface = true;
                            }
                        }
                        else if (IT_Plot_Case == 7001)
                        {
                            IsInner_AB_TransSurface = true;
                            //equation Trans_LI
                            m = Convert.ToDouble(dataGridView2.Rows[43].Cells[1].Value);//slope of TOC_GH
                            c = Convert.ToDouble(dataGridView2.Rows[43].Cells[2].Value);//intercept of TOC_GH
                            double d1 = Math.Abs(m * Final_Easting_X - Final_Northing_Y + c) / Math.Sqrt(m * m + 1.0 * 1.0);

                            m = Convert.ToDouble(dataGridView2.Rows[47].Cells[1].Value);//slope of TOC_GH
                            c = Convert.ToDouble(dataGridView2.Rows[47].Cells[2].Value);//intercept of TOC_GH
                            perp_dist_TOC = Math.Abs(m * Final_Easting_X - Final_Northing_Y + c) / Math.Sqrt(m * m + 1.0 * 1.0);

                            Base_Height = d1 * slope_IA / 100.0;
                            Base_Dist = 0.0;

                            RL_datum_Surface = Convert.ToDouble(TxtRL_AB_Th.Text);
                        }
                        else if (IT_Plot_Case == 7002)
                        {
                            IsInner_AB_TransSurface = true;
                            //equation Trans_LI
                            m = Convert.ToDouble(dataGridView2.Rows[31].Cells[1].Value);//slope of TOC_GH
                            c = Convert.ToDouble(dataGridView2.Rows[31].Cells[2].Value);//intercept of TOC_GH
                            double d1 = Math.Abs(m * Final_Easting_X - Final_Northing_Y + c) / Math.Sqrt(m * m + 1.0 * 1.0);

                            m = Convert.ToDouble(dataGridView2.Rows[47].Cells[1].Value);//slope of TOC_GH
                            c = Convert.ToDouble(dataGridView2.Rows[47].Cells[2].Value);//intercept of TOC_GH
                            perp_dist_TOC = Math.Abs(m * Final_Easting_X - Final_Northing_Y + c) / Math.Sqrt(m * m + 1.0 * 1.0);


                            Base_Height = d1 * slope_BL / 100.0;
                            Base_Dist = Divergence_BL / 100.0 * d1;

                            RL_datum_Surface = Convert.ToDouble(Txt_RL_CD_Th.Text);
                        }
                        else if (IT_Plot_Case == 8001)
                        {
                            IsInner_AB_TransSurface = true;
                            //equation Trans_LI
                            m = Convert.ToDouble(dataGridView2.Rows[43].Cells[1].Value);//slope of TOC_GH
                            c = Convert.ToDouble(dataGridView2.Rows[43].Cells[2].Value);//intercept of TOC_GH
                            double d1 = Math.Abs(m * Final_Easting_X - Final_Northing_Y + c) / Math.Sqrt(m * m + 1.0 * 1.0);

                            m = Convert.ToDouble(dataGridView2.Rows[48].Cells[1].Value);//slope of TOC_GH
                            c = Convert.ToDouble(dataGridView2.Rows[48].Cells[2].Value);//intercept of TOC_GH
                            perp_dist_TOC = Math.Abs(m * Final_Easting_X - Final_Northing_Y + c) / Math.Sqrt(m * m + 1.0 * 1.0);

                            Base_Height = d1 * slope_IA / 100.0;
                            Base_Dist = 0.0;

                            RL_datum_Surface = Convert.ToDouble(TxtRL_AB_Th.Text);
                        }
                        else if (IT_Plot_Case == 8002)
                        {
                            IsInner_AB_TransSurface = true;
                            //equation Trans_LI
                            m = Convert.ToDouble(dataGridView2.Rows[31].Cells[1].Value);//slope of TOC_GH
                            c = Convert.ToDouble(dataGridView2.Rows[31].Cells[2].Value);//intercept of TOC_GH
                            double d1 = Math.Abs(m * Final_Easting_X - Final_Northing_Y + c) / Math.Sqrt(m * m + 1.0 * 1.0);

                            m = Convert.ToDouble(dataGridView2.Rows[48].Cells[1].Value);//slope of TOC_GH
                            c = Convert.ToDouble(dataGridView2.Rows[48].Cells[2].Value);//intercept of TOC_GH
                            perp_dist_TOC = Math.Abs(m * Final_Easting_X - Final_Northing_Y + c) / Math.Sqrt(m * m + 1.0 * 1.0);

                            Base_Height = d1 * slope_BL / 100.0;
                            Base_Dist = Divergence_BL / 100.0 * d1;

                            RL_datum_Surface = Convert.ToDouble(Txt_RL_CD_Th.Text);
                        }

                        if (IsInner_AB_TransSurface == true)
                        {
                            SurfaceHeight = Base_Height + slope_IT / 100.0 * (perp_dist_TOC - Base_Dist);
                            AllowableElev_Obs = RL_datum_Surface + SurfaceHeight;
                            SurfaceName = "INNER TRANSITIONAL SURFACE AB";

                            //adding data to datagridview4
                            dataGridView4.Rows.Add();
                            SurfaceCount++;
                            dataGridView4.Rows[SurfaceCount - 1].Cells[0].Value = SurfaceCount.ToString();
                            dataGridView4.Rows[SurfaceCount - 1].Cells[1].Value = SurfaceName;
                            dataGridView4.Rows[SurfaceCount - 1].Cells[2].Value = SurfaceHeight.ToString("0.000");
                            dataGridView4.Rows[SurfaceCount - 1].Cells[3].Value = RL_datum_Surface.ToString("0.000");
                            dataGridView4.Rows[SurfaceCount - 1].Cells[4].Value = AllowableElev_Obs.ToString("0.000");
                            dataGridView4.Rows[SurfaceCount - 1].Cells[5].Value = RL_datum_Surface.ToString() + " + " + Base_Height.ToString() + " + (" + slope_IT + "% * (" + perp_dist_TOC.ToString("0.000") + " - " + Base_Dist.ToString() + ")) = " + AllowableElev_Obs.ToString("0.000");

                        }

                    }
                }

                //Calculate the surface name, height, allowable elevation and finally elevation to be permitted
                double MinElevation = 0, temp1, temp2;
                //finding minimum value of elevation
                if (SurfaceCount == 1)
                {
                    MinElevation = Convert.ToDouble(dataGridView4.Rows[0].Cells[4].Value);
                    //MessageBox.Show("min ele ev1 = " + MinElevation.ToString());
                }
                else if (SurfaceCount == 2)
                {
                    temp1 = Convert.ToDouble(dataGridView4.Rows[0].Cells[4].Value);
                    temp2 = Convert.ToDouble(dataGridView4.Rows[1].Cells[4].Value);
                    MinElevation = Math.Min(temp1, temp2);
                }
                else if (SurfaceCount > 2)
                {
                    temp1 = Convert.ToDouble(dataGridView4.Rows[0].Cells[4].Value);
                    temp2 = Convert.ToDouble(dataGridView4.Rows[1].Cells[4].Value);
                    MinElevation = Math.Min(temp1, temp2);

                    for (int k = 2; k < SurfaceCount; k++)
                    {
                        temp1 = Convert.ToDouble(dataGridView4.Rows[k].Cells[4].Value);
                        MinElevation = Math.Min(MinElevation, temp1);
                    }
                }

                //finding if there are more than 1 minimum 
                int No_of_min;
                int[] MinIndex = new int[10];

                No_of_min = 0;
                int i = 0;
                //finding minimum index containing minimum elevation
                if (SurfaceCount >= 1)
                {
                    for (int k = 0; k < SurfaceCount; k++)
                    {
                        temp1 = Convert.ToDouble(dataGridView4.Rows[k].Cells[4].Value);
                        if (MinElevation == temp1)
                        {
                            MinIndex[i] = k;
                            No_of_min++;
                            i++;
                        }
                    }
                }

                SurfaceHeight = Convert.ToDouble(dataGridView4.Rows[MinIndex[0]].Cells[2].Value);
                AllowableElev_Obs = Convert.ToDouble(dataGridView4.Rows[MinIndex[0]].Cells[4].Value);
                double datum_RL = Convert.ToDouble(dataGridView4.Rows[MinIndex[0]].Cells[3].Value);
                if (No_of_min == 1)
                {
                    SurfaceName = dataGridView4.Rows[MinIndex[0]].Cells[1].Value.ToString();
                    TxtCalculationDetail.Text = "";
                    TxtCalculationDetail.Text = dataGridView4.Rows[MinIndex[0]].Cells[5].Value.ToString();
                }
                else if (No_of_min > 1)
                {
                    SurfaceName = "";
                    TxtCalculationDetail.Text = "";
                    for (int k = 0; k < No_of_min; k++)
                    {
                        SurfaceName += dataGridView4.Rows[MinIndex[k]].Cells[1].Value.ToString();
                        SurfaceName += ". ";
                        TxtCalculationDetail.Text += dataGridView4.Rows[MinIndex[k]].Cells[5].Value.ToString();
                        TxtCalculationDetail.Text += "; ";
                    }
                }

                TxtRL_RWY.Text = datum_RL.ToString();
                TxtSurfaceName.Text = SurfaceName;
                TxtSurfaceHeightaboveRWY.Text = SurfaceHeight.ToString("0.000");
                TxtElev_allow.Text = AllowableElev_Obs.ToString("0.000");
                Elev_permitted = Math.Min(Actual_Elev_obs, AllowableElev_Obs);
                TxtElev_Permitted.Text = Elev_permitted.ToString("0.000");
                if (Actual_Elev_obs < AllowableElev_Obs)
                {
                    TxtElev_Permitted.ForeColor = Color.DarkGreen;
                }
                else if (Actual_Elev_obs > AllowableElev_Obs)
                {
                    TxtElev_Permitted.ForeColor = Color.Red;
                }

                TxtLog.Text = "Calculation Completed";
            }
            catch
            {

            }
        }

        private void BtnCalculate_Click(object sender, EventArgs e)
        {
            //Function_Calculate();
        }

        private double RL_of_RWY_CL_by_Interpolation(double m1,double c1, double m2, double c2, int DGV1_index1, int DGV1_index2)
        {
            //m1, c1 = slope, intercept of RWY CL
            //m2, c2 = slope, intercept of line perpendicular to RWY CL
            //DGV1_index1, DGV1_index2 are points whose midpoint is origin
            //intersection of l1:(m1,c1) and l2:(m2,c2) is any point on RWY CL which do distance far from origin
            double RL_BL=0;
            double X,Y;
            double x1, x2, y1, y2;
            double Ox, Oy;
            double d0;

            //K
            x1 = Convert.ToDouble(dataGridView1.Rows[DGV1_index1].Cells[4].Value);//14
            y1 = Convert.ToDouble(dataGridView1.Rows[DGV1_index1].Cells[5].Value);

            //L
            x2 = Convert.ToDouble(dataGridView1.Rows[DGV1_index2].Cells[4].Value);//15
            y2 = Convert.ToDouble(dataGridView1.Rows[DGV1_index2].Cells[5].Value);

            //Midpoint of strip edge
            Ox = (x1 + x2) / 2;
            Oy = (y1 + y2) / 2;

            //Intersection point of inner edge of BL and centerline of RWY
            X = Find_Intersection_X(m1, c1, m2, c2);
            Y = Find_Intersection_Y(m1, c1, m2, c2);

            d0 = Find_Distance_bet_two_pointXY(Ox, Oy, X, Y);

            double diff1, diff2;
            int row = dataGridView6.RowCount - 1;
            double d1, d2;
            int small_itvl = -1;
            for(int i = 0; i < (row-1); i++)
            {
                d1 = Convert.ToDouble(dataGridView6.Rows[i].Cells[1].Value);
                d2 = Convert.ToDouble(dataGridView6.Rows[i+1].Cells[1].Value);
                diff1 = d0 - d1;
                diff2 = d2 - d0;
                if(diff1 ==0)
                {
                    small_itvl++;
                    RL_BL = Convert.ToDouble(dataGridView6.Rows[i].Cells[2].Value);
                }
                else if(diff2 == 0)
                {
                    small_itvl++;
                    RL_BL = Convert.ToDouble(dataGridView6.Rows[i+1].Cells[2].Value);
                }
                else if(diff1 > 0 && diff2 > 0)
                {
                    x1 = d1;
                    x2 = d2;
                    y1 = Convert.ToDouble(dataGridView6.Rows[i].Cells[2].Value);
                    y2 = Convert.ToDouble(dataGridView6.Rows[i+1].Cells[2].Value);
                    RL_BL = (y2 - y1) / (x2 - x1) * (d0 - x1) + y1;
                    small_itvl++;
                }
            }
            return RL_BL;
        }

        private double Dist_of_RWY_CL_by_Interpolation(double m1, double c1, double m2, double c2, int DGV1_index1, int DGV1_index2)
        {
            //m1, c1 = slope, intercept of RWY CL
            //m2, c2 = slope, intercept of line perpendicular to RWY CL
            //DGV1_index1, DGV1_index2 are points whose midpoint is origin
            //intersection of l1:(m1,c1) and l2:(m2,c2) is any point on RWY CL which do distance far from origin
            //double RL_BL = 0;
            double X, Y;
            double x1, x2, y1, y2;
            double Ox, Oy;
            double d0;

            //K
            x1 = Convert.ToDouble(dataGridView1.Rows[DGV1_index1].Cells[4].Value);//14
            y1 = Convert.ToDouble(dataGridView1.Rows[DGV1_index1].Cells[5].Value);

            //L
            x2 = Convert.ToDouble(dataGridView1.Rows[DGV1_index2].Cells[4].Value);//15
            y2 = Convert.ToDouble(dataGridView1.Rows[DGV1_index2].Cells[5].Value);

            //Midpoint of strip edge
            Ox = (x1 + x2) / 2;
            Oy = (y1 + y2) / 2;

            //Intersection point of inner edge of BL and centerline of RWY
            X = Find_Intersection_X(m1, c1, m2, c2);
            Y = Find_Intersection_Y(m1, c1, m2, c2);

            d0 = Find_Distance_bet_two_pointXY(Ox, Oy, X, Y);

            return d0;
        }

        private int Index_of_dist_of_RWY_CL_by_Interpolation(double m1, double c1, double m2, double c2, int DGV1_index1=14, int DGV1_index2=15)
        {
            //m1, c1 = slope, intercept of RWY CL
            //m2, c2 = slope, intercept of line perpendicular to RWY CL
            //DGV1_index1, DGV1_index2 are points whose midpoint is origin
            //intersection of l1:(m1,c1) and l2:(m2,c2) is any point on RWY CL which do distance far from origin
            double RL_BL = 0;
            double X, Y;
            double x1, x2, y1, y2;
            double Ox, Oy;
            double d0;

            //K
            x1 = Convert.ToDouble(dataGridView1.Rows[DGV1_index1].Cells[4].Value);//14
            y1 = Convert.ToDouble(dataGridView1.Rows[DGV1_index1].Cells[5].Value);

            //L
            x2 = Convert.ToDouble(dataGridView1.Rows[DGV1_index2].Cells[4].Value);//15
            y2 = Convert.ToDouble(dataGridView1.Rows[DGV1_index2].Cells[5].Value);

            //Midpoint of strip edge
            Ox = (x1 + x2) / 2;
            Oy = (y1 + y2) / 2;

            //Intersection point of inner edge of BL and centerline of RWY
            X = Find_Intersection_X(m1, c1, m2, c2);
            Y = Find_Intersection_Y(m1, c1, m2, c2);

            d0 = Find_Distance_bet_two_pointXY(Ox, Oy, X, Y);

            double diff1, diff2;
            int row = dataGridView6.RowCount - 1;
            double d1, d2;
            int small_itvl = 0;
            for (int i = 0; i < (row - 1); i++)
            {
                d1 = Convert.ToDouble(dataGridView6.Rows[i].Cells[1].Value);
                d2 = Convert.ToDouble(dataGridView6.Rows[i + 1].Cells[1].Value);
                diff1 = d0 - d1;
                diff2 = d2 - d0;
                if (diff1 == 0)
                {
                    small_itvl = i;
                    RL_BL = Convert.ToDouble(dataGridView6.Rows[i].Cells[2].Value);
                }
                else if (diff2 == 0)
                {
                    small_itvl = i;
                    RL_BL = Convert.ToDouble(dataGridView6.Rows[i + 1].Cells[2].Value);
                }
                else if (diff1 > 0 && diff2 > 0)
                {
                    x1 = d1;
                    x2 = d2;
                    y1 = Convert.ToDouble(dataGridView6.Rows[i].Cells[2].Value);
                    y2 = Convert.ToDouble(dataGridView6.Rows[i + 1].Cells[2].Value);
                    RL_BL = (y2 - y1) / (x2 - x1) * (d0 - x1) + y1;
                    small_itvl = i;
                }
            }
            return small_itvl;
        }

        public int InnerTransitional_Case_of_Plot_COORD_AB(double eastingX, double northingY)
        {
            int plot_case = 0;
            double m, c;
            string position_OG, position_GH, position_ID, position_DA, position_AO, position_HK, position_IL;
            string position_PJ, position_JK, position_LC, position_CB, position_BIP;

            //Transition near RWYAD
            //equation AD
            m = Convert.ToDouble(dataGridView2.Rows[63].Cells[1].Value);//slope
            c = Convert.ToDouble(dataGridView2.Rows[63].Cells[2].Value);//intercept
            position_OG = Find_Plotting_Position(eastingX, northingY, m, c);

            //equation DK
            m = Convert.ToDouble(dataGridView2.Rows[64].Cells[1].Value);//slope
            c = Convert.ToDouble(dataGridView2.Rows[64].Cells[2].Value);//intercept
            position_GH = Find_Plotting_Position(eastingX, northingY, m, c);

            //equation KJ
            m = Convert.ToDouble(dataGridView2.Rows[65].Cells[1].Value);//slope
            c = Convert.ToDouble(dataGridView2.Rows[65].Cells[2].Value);//intercept
            position_ID = Find_Plotting_Position(eastingX, northingY, m, c);

            //equation JA
            m = Convert.ToDouble(dataGridView2.Rows[35].Cells[1].Value);//slope 
            c = Convert.ToDouble(dataGridView2.Rows[35].Cells[2].Value);//intercept
            position_DA = Find_Plotting_Position(eastingX, northingY, m, c);

            //equation JA
            m = Convert.ToDouble(dataGridView2.Rows[47].Cells[1].Value);//slope 
            c = Convert.ToDouble(dataGridView2.Rows[47].Cells[2].Value);//intercept
            position_AO = Find_Plotting_Position(eastingX, northingY, m, c);

            //equation JA
            m = Convert.ToDouble(dataGridView2.Rows[43].Cells[1].Value);//slope 
            c = Convert.ToDouble(dataGridView2.Rows[43].Cells[2].Value);//intercept
            position_HK = Find_Plotting_Position(eastingX, northingY, m, c);

            //equation JA
            m = Convert.ToDouble(dataGridView2.Rows[31].Cells[1].Value);//slope 
            c = Convert.ToDouble(dataGridView2.Rows[31].Cells[2].Value);//intercept
            position_IL = Find_Plotting_Position(eastingX, northingY, m, c);


            //plot_case
            if (position_OG == "Above" && position_GH == "Below"  && position_AO == "Above" && position_HK == "Below")
            {
                plot_case = 7001;
            }
            else if (position_ID == "Below" && position_DA == "Above" && position_IL == "Above")
            {
                plot_case = 7002;
            }
            else if (position_IL == "Below" && position_HK == "Above" && position_AO == "Above")
            {
                plot_case = 7000; 
            }

            //Transition near RWYBC
            //equation CL
            m = Convert.ToDouble(dataGridView2.Rows[66].Cells[1].Value);//slope
            c = Convert.ToDouble(dataGridView2.Rows[66].Cells[2].Value);//intercept
            position_PJ = Find_Plotting_Position(eastingX, northingY, m, c);

            //equation LI
            m = Convert.ToDouble(dataGridView2.Rows[67].Cells[1].Value);//slope
            c = Convert.ToDouble(dataGridView2.Rows[67].Cells[2].Value);//intercept
            position_JK = Find_Plotting_Position(eastingX, northingY, m, c);

            //equation IB
            m = Convert.ToDouble(dataGridView2.Rows[68].Cells[1].Value);//slope
            c = Convert.ToDouble(dataGridView2.Rows[68].Cells[2].Value);//intercept
            position_LC = Find_Plotting_Position(eastingX, northingY, m, c);

            //equation BC
            m = Convert.ToDouble(dataGridView2.Rows[36].Cells[1].Value);//slope 
            c = Convert.ToDouble(dataGridView2.Rows[36].Cells[2].Value);//intercept
            position_CB = Find_Plotting_Position(eastingX, northingY, m, c);

            //equation BC
            m = Convert.ToDouble(dataGridView2.Rows[48].Cells[1].Value);//slope 
            c = Convert.ToDouble(dataGridView2.Rows[48].Cells[2].Value);//intercept
            position_BIP = Find_Plotting_Position(eastingX, northingY, m, c);



            //plot_case
            if (position_PJ == "Above" && position_JK == "Above" && position_BIP == "Below" && position_HK == "Below")
            {
                plot_case = 8001;
            }
            else if(position_LC == "Above" && position_CB == "Below" && position_IL == "Above")
            {
                plot_case = 8002;
            }
            else if (position_IL == "Below" && position_HK == "Above" && position_BIP == "Below")
            {
                plot_case = 8000;
            }
            return plot_case;
        }

        public int InnerTransitional_Case_of_Plot_COORD_CD(double eastingX, double northingY)
        {
            int plot_case = 0;
            double m, c;
            string position_VA, position_AB, position_CH, position_HE, position_EV, position_BE, position_CD;
            string position_UF, position_FE, position_DG, position_GF, position_FLU;

            double x1, y1, x2, y2;
            int n_row1, n_row;
            //Transition near RWYAD
            //equation AD
            m = Convert.ToDouble(dataGridView2.Rows[57].Cells[1].Value);//slope
            c = Convert.ToDouble(dataGridView2.Rows[57].Cells[2].Value);//intercept
            position_VA = Find_Plotting_Position(eastingX, northingY, m, c);

            //equation AB
            x1 = Convert.ToDouble(dataGridView1.Rows[70].Cells[4].Value);//IT_A
            y1 = Convert.ToDouble(dataGridView1.Rows[70].Cells[5].Value);//IT_A

            x2 = Convert.ToDouble(dataGridView10.Rows[0].Cells[4].Value);//IT_B
            y2 = Convert.ToDouble(dataGridView10.Rows[0].Cells[5].Value);//IT_B

            m = Find_Slope_Of_Equation(x1, y1, x2, y2);
            c = Find_Intercept_Of_Equation(m, x1, y1);
            position_AB = Find_Plotting_Position(eastingX, northingY, m, c);

            //equation CH
            n_row = dataGridView10.RowCount - 1;//20
            n_row1 = n_row / 2 - 1;//20/2-1=10-1=9

            x1 = Convert.ToDouble(dataGridView10.Rows[n_row1].Cells[4].Value);//IT_A
            y1 = Convert.ToDouble(dataGridView10.Rows[n_row1].Cells[5].Value);//IT_A

            x2 = Convert.ToDouble(dataGridView1.Rows[40].Cells[4].Value);//IT_B
            y2 = Convert.ToDouble(dataGridView1.Rows[40].Cells[5].Value);//IT_B

            m = Find_Slope_Of_Equation(x1, y1, x2, y2);
            c = Find_Intercept_Of_Equation(m, x1, y1);
            position_CH = Find_Plotting_Position(eastingX, northingY, m, c);

            //equation JA
            m = Convert.ToDouble(dataGridView2.Rows[37].Cells[1].Value);//slope 
            c = Convert.ToDouble(dataGridView2.Rows[37].Cells[2].Value);//intercept
            position_HE = Find_Plotting_Position(eastingX, northingY, m, c);

            //equation JA
            m = Convert.ToDouble(dataGridView2.Rows[49].Cells[1].Value);//slope 
            c = Convert.ToDouble(dataGridView2.Rows[49].Cells[2].Value);//intercept
            position_EV = Find_Plotting_Position(eastingX, northingY, m, c);

            //equation JA
            m = Convert.ToDouble(dataGridView2.Rows[45].Cells[1].Value);//slope 
            c = Convert.ToDouble(dataGridView2.Rows[45].Cells[2].Value);//intercept
            position_BE = Find_Plotting_Position(eastingX, northingY, m, c);

            //equation JA
            m = Convert.ToDouble(dataGridView2.Rows[33].Cells[1].Value);//slope 
            c = Convert.ToDouble(dataGridView2.Rows[33].Cells[2].Value);//intercept
            position_CD = Find_Plotting_Position(eastingX, northingY, m, c);

            //plot_case
            if (position_VA == "Below" && position_AB == "Below" && position_HE == "Above" && position_EV == "Above")
            {
                /*if(position_BE == "Below" && position_CD == "Above")
                {
                    plot_case = 5000;
                }*/
                /*if(position_BE == "Below" && position_CD == "Below")
                {
                    plot_case = 5001;
                }*/
                if (position_BE == "Above" && position_CD == "Above")
                {
                    plot_case = 5002;
                }
            }

            //plot_case
            if (position_VA == "Below"  && position_CH == "Below" && position_HE == "Above" && position_EV == "Above")
            {
                /*if(position_BE == "Below" && position_CD == "Above")
                {
                    plot_case = 5000;
                }*/
                if (position_BE == "Below" && position_CD == "Below")
                {
                    plot_case = 5001;
                }
                /*else if (position_BE == "Above" && position_CD == "Above")
                {
                    plot_case = 5002;
                }*/
            }

            //plot_case
            if ( position_EV == "Above")
            {
                if(position_BE == "Below" && position_CD == "Above")
                {
                    plot_case = 5000;
                }
            }

            //Transition near RWYBC
            //equation CL
            m = Convert.ToDouble(dataGridView2.Rows[60].Cells[1].Value);//slope
            c = Convert.ToDouble(dataGridView2.Rows[60].Cells[2].Value);//intercept
            position_UF = Find_Plotting_Position(eastingX, northingY, m, c);

            //equation LI
            x1 = Convert.ToDouble(dataGridView1.Rows[73].Cells[4].Value);//IT_F
            y1 = Convert.ToDouble(dataGridView1.Rows[73].Cells[5].Value);//IT_F

            x2 = Convert.ToDouble(dataGridView10.Rows[n_row1 + 1].Cells[4].Value);//IT_E
            y2 = Convert.ToDouble(dataGridView10.Rows[n_row1 + 1].Cells[5].Value);//IT_E

            m = Find_Slope_Of_Equation(x1, y1, x2, y2);
            c = Find_Intercept_Of_Equation(m, x1, y1);
            position_FE = Find_Plotting_Position(eastingX, northingY, m, c);

            //equation IB
            x1 = Convert.ToDouble(dataGridView10.Rows[n_row - 1].Cells[4].Value);//IT_D
            y1 = Convert.ToDouble(dataGridView10.Rows[n_row - 1].Cells[5].Value);//IT_D

            x2 = Convert.ToDouble(dataGridView1.Rows[41].Cells[4].Value);//IT_G
            y2 = Convert.ToDouble(dataGridView1.Rows[41].Cells[5].Value);//IT_G

            m = Find_Slope_Of_Equation(x1, y1, x2, y2);
            c = Find_Intercept_Of_Equation(m, x1, y1);
            position_DG = Find_Plotting_Position(eastingX, northingY, m, c);

            //equation BC
            m = Convert.ToDouble(dataGridView2.Rows[38].Cells[1].Value);//slope 
            c = Convert.ToDouble(dataGridView2.Rows[38].Cells[2].Value);//intercept
            position_GF = Find_Plotting_Position(eastingX, northingY, m, c);

            //equation BC
            m = Convert.ToDouble(dataGridView2.Rows[50].Cells[1].Value);//slope 
            c = Convert.ToDouble(dataGridView2.Rows[50].Cells[2].Value);//intercept
            position_FLU = Find_Plotting_Position(eastingX, northingY, m, c);

            //plot_case
            if ( position_DG == "Above" && position_GF == "Below")
            {
                /*if (position_BE == "Below" && position_CD == "Above")
                {
                    plot_case = 6000;
                }*/
                if (position_BE == "Below" && position_CD == "Below")
                {
                    plot_case = 6001;
                }
                /*if (position_BE == "Above" && position_CD == "Above")
                {
                    plot_case = 6002;
                }*/
            }

            //plot_case
            if (position_UF == "Below" && position_FE == "Above" && position_FLU == "Below")
            {
                /*if (position_BE == "Below" && position_CD == "Above")
                {
                    plot_case = 6000;
                }
                else if (position_BE == "Below" && position_CD == "Below")
                {
                    plot_case = 6001;
                }*/
                if (position_BE == "Above" && position_CD == "Above")
                {
                    plot_case = 6002;
                }
            }



            //plot_case
            if ( position_FLU == "Below")
            {
                if (position_BE == "Below" && position_CD == "Above")
                {
                    plot_case = 6000;
                }
                /*else if (position_BE == "Below" && position_CD == "Below")
                {
                    plot_case = 6001;
                }
                else if (position_BE == "Above" && position_CD == "Above")
                {
                    plot_case = 6002;
                }*/
            }

            return plot_case;
        }

        public int Transitional_Case_of_Plot_COORD(double eastingX, double northingY)
        {
            int plot_case = 0;
            double m, c;
            string position_EH, position_KL, position_KJ, position_JI;
            string position_LI, position_FG;

            //Transition near RWYAD
            //equation AD
            m = Convert.ToDouble(dataGridView2.Rows[39].Cells[1].Value);//slope
            c = Convert.ToDouble(dataGridView2.Rows[39].Cells[2].Value);//intercept
            position_EH = Find_Plotting_Position(eastingX, northingY, m, c);

            //equation KL
            m = Convert.ToDouble(dataGridView2.Rows[9].Cells[1].Value);//slope
            c = Convert.ToDouble(dataGridView2.Rows[9].Cells[2].Value);//intercept
            position_KL = Find_Plotting_Position(eastingX, northingY, m, c);

            //equation KJ
            m = Convert.ToDouble(dataGridView2.Rows[41].Cells[1].Value);//slope
            c = Convert.ToDouble(dataGridView2.Rows[41].Cells[2].Value);//intercept
            position_KJ = Find_Plotting_Position(eastingX, northingY, m, c);

            //equation JI
            m = Convert.ToDouble(dataGridView2.Rows[5].Cells[1].Value);//slope 
            c = Convert.ToDouble(dataGridView2.Rows[5].Cells[2].Value);//intercept
            position_JI = Find_Plotting_Position(eastingX, northingY, m, c);

            //plot_case
            /*if (position_EH == "Below" && position_JI == "Above" && position_KL == "Below" && position_KJ == "Above")
            {
                plot_case = 500;
            }*/
            if (position_JI == "Above" && position_KL == "Below" && position_KJ == "Above")
            {
                plot_case = 500;
            }

            //Transition near RWYBC
            //equation LI
            m = Convert.ToDouble(dataGridView2.Rows[42].Cells[1].Value);//slope
            c = Convert.ToDouble(dataGridView2.Rows[42].Cells[2].Value);//intercept
            position_LI = Find_Plotting_Position(eastingX, northingY, m, c);
                        
            //equation BC
            m = Convert.ToDouble(dataGridView2.Rows[40].Cells[1].Value);//slope 
            c = Convert.ToDouble(dataGridView2.Rows[40].Cells[2].Value);//intercept
            position_FG = Find_Plotting_Position(eastingX, northingY, m, c);

            //plot_case
            if (position_LI == "Below" && position_KL == "Below" && position_JI == "Above" )
            {
                plot_case = 600;
            }

            double x1, y1, x2, y2;
            int n_row, n_row1;
            string position_EA, position_HD, position_FB, position_GC;
            string position_JG, position_NK, position_IH, position_LM;
            //equation EA
            n_row = dataGridView9.RowCount - 1;//20
            n_row1 = n_row / 2 - 1;//20/2-1=10-1=9

            x1 = Convert.ToDouble(dataGridView9.Rows[n_row1].Cells[4].Value);//T_E
            y1 = Convert.ToDouble(dataGridView9.Rows[n_row1].Cells[5].Value);//T_E
            x2 = Convert.ToDouble(dataGridView1.Rows[66].Cells[4].Value);//T_A
            y2 = Convert.ToDouble(dataGridView1.Rows[66].Cells[5].Value);//T_A
            m = Find_Slope_Of_Equation(x1, y1, x2, y2);
            c = Find_Intercept_Of_Equation(m, x1,y1);
            //position_CH = Find_Plotting_Position(eastingX, northingY, m, c);
            
            //m = Convert.ToDouble(dataGridView2.Rows[53].Cells[1].Value);//slope
            //c = Convert.ToDouble(dataGridView2.Rows[53].Cells[2].Value);//intercept
            position_EA = Find_Plotting_Position(eastingX, northingY, m, c);

            //equation HD
            x1 = Convert.ToDouble(dataGridView9.Rows[0].Cells[4].Value);//T_H
            y1 = Convert.ToDouble(dataGridView9.Rows[0].Cells[5].Value);//T_H
            x2 = Convert.ToDouble(dataGridView1.Rows[68].Cells[4].Value);//T_D
            y2 = Convert.ToDouble(dataGridView1.Rows[68].Cells[5].Value);//T_D
            m = Find_Slope_Of_Equation(x1, y1, x2, y2);
            c = Find_Intercept_Of_Equation(m, x1, y1);
            //position_CH = Find_Plotting_Position(eastingX, northingY, m, c);


            //m = Convert.ToDouble(dataGridView2.Rows[55].Cells[1].Value);//slope
            //c = Convert.ToDouble(dataGridView2.Rows[55].Cells[2].Value);//intercept
            position_HD = Find_Plotting_Position(eastingX, northingY, m, c);

            //equation FB
            x1 = Convert.ToDouble(dataGridView9.Rows[n_row-1].Cells[4].Value);//T_F
            y1 = Convert.ToDouble(dataGridView9.Rows[n_row-1].Cells[5].Value);//T_F
            x2 = Convert.ToDouble(dataGridView1.Rows[67].Cells[4].Value);//T_B
            y2 = Convert.ToDouble(dataGridView1.Rows[67].Cells[5].Value);//T_B
            m = Find_Slope_Of_Equation(x1, y1, x2, y2);
            c = Find_Intercept_Of_Equation(m, x1, y1);
            //position_CH = Find_Plotting_Position(eastingX, northingY, m, c);

            //m = Convert.ToDouble(dataGridView2.Rows[54].Cells[1].Value);//slope
            //c = Convert.ToDouble(dataGridView2.Rows[54].Cells[2].Value);//intercept
            position_FB = Find_Plotting_Position(eastingX, northingY, m, c);

            //equation GC
            x1 = Convert.ToDouble(dataGridView9.Rows[n_row1 + 1].Cells[4].Value);//T_G
            y1 = Convert.ToDouble(dataGridView9.Rows[n_row1 + 1].Cells[5].Value);//T_G
            x2 = Convert.ToDouble(dataGridView1.Rows[69].Cells[4].Value);//T_C
            y2 = Convert.ToDouble(dataGridView1.Rows[69].Cells[5].Value);//T_C
            m = Find_Slope_Of_Equation(x1, y1, x2, y2);
            c = Find_Intercept_Of_Equation(m, x1, y1);
            //position_CH = Find_Plotting_Position(eastingX, northingY, m, c);

            //m = Convert.ToDouble(dataGridView2.Rows[56].Cells[1].Value);//slope
            //c = Convert.ToDouble(dataGridView2.Rows[56].Cells[2].Value);//intercept
            position_GC = Find_Plotting_Position(eastingX, northingY, m, c);



            //equation JG
            m = Convert.ToDouble(dataGridView2.Rows[13].Cells[1].Value);//slope
            c = Convert.ToDouble(dataGridView2.Rows[13].Cells[2].Value);//intercept
            position_JG = Find_Plotting_Position(eastingX, northingY, m, c);

            //equation NK
            m = Convert.ToDouble(dataGridView2.Rows[15].Cells[1].Value);//slope
            c = Convert.ToDouble(dataGridView2.Rows[15].Cells[2].Value);//intercept
            position_NK = Find_Plotting_Position(eastingX, northingY, m, c);

            //equation IH
            m = Convert.ToDouble(dataGridView2.Rows[14].Cells[1].Value);//slope
            c = Convert.ToDouble(dataGridView2.Rows[14].Cells[2].Value);//intercept
            position_IH = Find_Plotting_Position(eastingX, northingY, m, c);

            //equation LM
            m = Convert.ToDouble(dataGridView2.Rows[16].Cells[1].Value);//slope
            c = Convert.ToDouble(dataGridView2.Rows[16].Cells[2].Value);//intercept
            position_LM = Find_Plotting_Position(eastingX, northingY, m, c);

            //plot_case
            if (position_JI == "Below" && position_JG == "Above" && position_EA == "Below")
            {
                plot_case = 501;
            }

            if (position_KL == "Above" && position_NK == "Above" && position_HD == "Below")
            {
                plot_case = 502;
            }

            if (position_JI == "Below" && position_IH == "Below" && position_FB == "Above")
            {
                plot_case = 601;
            }

            if (position_KL == "Above" && position_LM == "Below" && position_GC == "Above")
            {
                plot_case = 602;
            }

            return plot_case;
        }

        public int Inner_Approach_Case_of_Plot_COORD(double eastingX, double northingY)
        {
            int plot_case = 0;
            double m, c;
            string position_JI, position_OP, position_JO, position_IP;
            string position_KL, position_VU, position_KV, position_LU;

            //Approach near AB
            //equation JI
            m = Convert.ToDouble(dataGridView2.Rows[43].Cells[1].Value);//slope
            c = Convert.ToDouble(dataGridView2.Rows[43].Cells[2].Value);//intercept
            position_JI = Find_Plotting_Position(eastingX, northingY, m, c);

            //equation OP
            m = Convert.ToDouble(dataGridView2.Rows[44].Cells[1].Value);//slope 
            c = Convert.ToDouble(dataGridView2.Rows[44].Cells[2].Value);//intercept
            position_OP = Find_Plotting_Position(eastingX, northingY, m, c);

            //equation JO
            m = Convert.ToDouble(dataGridView2.Rows[47].Cells[1].Value);//slope 
            c = Convert.ToDouble(dataGridView2.Rows[47].Cells[2].Value);//intercept
            position_JO = Find_Plotting_Position(eastingX, northingY, m, c);

            //equation IP
            m = Convert.ToDouble(dataGridView2.Rows[48].Cells[1].Value);//slope 
            c = Convert.ToDouble(dataGridView2.Rows[48].Cells[2].Value);//intercept
            position_IP = Find_Plotting_Position(eastingX, northingY, m, c);

            //MessageBox.Show("IJ = " + position_IJ + " JG = " + position_JG + " GH = " + position_GH + " HI = " + position_HI);

            //plot_case
            if (position_JI == "Below" && position_OP == "Above" && position_JO == "Below" && position_IP == "Above")
            {
                plot_case = 700;
            }

            //Approach near CD
            //equation KL
            m = Convert.ToDouble(dataGridView2.Rows[45].Cells[1].Value);//slope
            c = Convert.ToDouble(dataGridView2.Rows[45].Cells[2].Value);//intercept
            position_KL = Find_Plotting_Position(eastingX, northingY, m, c);

            //equation VU
            m = Convert.ToDouble(dataGridView2.Rows[46].Cells[1].Value);//slope 
            c = Convert.ToDouble(dataGridView2.Rows[46].Cells[2].Value);//intercept
            position_VU = Find_Plotting_Position(eastingX, northingY, m, c);

            //equation KV
            m = Convert.ToDouble(dataGridView2.Rows[49].Cells[1].Value);//slope 
            c = Convert.ToDouble(dataGridView2.Rows[49].Cells[2].Value);//intercept
            position_KV = Find_Plotting_Position(eastingX, northingY, m, c);

            //equation LU
            m = Convert.ToDouble(dataGridView2.Rows[50].Cells[1].Value);//slope 
            c = Convert.ToDouble(dataGridView2.Rows[50].Cells[2].Value);//intercept
            position_LU = Find_Plotting_Position(eastingX, northingY, m, c);

            //MessageBox.Show("IJ = " + position_IJ + " JG = " + position_JG + " GH = " + position_GH + " HI = " + position_HI);

            //plot_case
            if (position_KL == "Above" && position_VU == "Below" && position_KV == "Below" && position_LU == "Above")
            {
                plot_case = 800;
            }


            return plot_case;
        }

        public int Approach_Case_of_Plot_COORD(double eastingX, double northingY)
        {
            int plot_case = 0;
            double m, c;
            string position_IJ, position_JG, position_GH, position_HI, position_OP, position_RQ;
            string position_LK, position_KN, position_NM, position_ML, position_VU, position_ST;

            //Approach near AB
            //equation JI
            m = Convert.ToDouble(dataGridView2.Rows[5].Cells[1].Value);//slope
            c = Convert.ToDouble(dataGridView2.Rows[5].Cells[2].Value);//intercept
            position_IJ = Find_Plotting_Position(eastingX, northingY, m, c);

            //equation JG
            m = Convert.ToDouble(dataGridView2.Rows[13].Cells[1].Value);//slope
            c = Convert.ToDouble(dataGridView2.Rows[13].Cells[2].Value);//intercept
            position_JG = Find_Plotting_Position(eastingX, northingY, m, c);

            //equation GH
            m = Convert.ToDouble(dataGridView2.Rows[8].Cells[1].Value);//slope
            c = Convert.ToDouble(dataGridView2.Rows[8].Cells[2].Value);//intercept
            position_GH = Find_Plotting_Position(eastingX, northingY, m, c);

            //equation HI
            m = Convert.ToDouble(dataGridView2.Rows[14].Cells[1].Value);//slope 
            c = Convert.ToDouble(dataGridView2.Rows[14].Cells[2].Value);//intercept
            position_HI = Find_Plotting_Position(eastingX, northingY, m, c);

            //equation OP
            m = Convert.ToDouble(dataGridView2.Rows[6].Cells[1].Value);//slope 
            c = Convert.ToDouble(dataGridView2.Rows[6].Cells[2].Value);//intercept
            position_OP = Find_Plotting_Position(eastingX, northingY, m, c);

            //equation RQ
            m = Convert.ToDouble(dataGridView2.Rows[7].Cells[1].Value);//slope 
            c = Convert.ToDouble(dataGridView2.Rows[7].Cells[2].Value);//intercept
            position_RQ = Find_Plotting_Position(eastingX, northingY, m, c);

            //MessageBox.Show("IJ = " + position_IJ + " JG = " + position_JG + " GH = " + position_GH + " HI = " + position_HI);

            //plot_case
            if (position_IJ == "Below" && position_JG == "Below" && position_GH == "Above" && position_HI == "Above")
            {
                if(position_OP=="Above")
                {
                    plot_case = 10;
                }
                if (position_OP == "Below" && position_RQ == "Above")
                {
                    plot_case = 20;
                }
                if (position_RQ == "Below")
                {
                    plot_case = 30;
                }
            }

            //Approach near CD
            //equation LK
            m = Convert.ToDouble(dataGridView2.Rows[9].Cells[1].Value);//slope
            c = Convert.ToDouble(dataGridView2.Rows[9].Cells[2].Value);//intercept
            position_LK = Find_Plotting_Position(eastingX, northingY, m, c);

            //equation KN
            m = Convert.ToDouble(dataGridView2.Rows[15].Cells[1].Value);//slope
            c = Convert.ToDouble(dataGridView2.Rows[15].Cells[2].Value);//intercept
            position_KN = Find_Plotting_Position(eastingX, northingY, m, c);

            //equation NM
            m = Convert.ToDouble(dataGridView2.Rows[12].Cells[1].Value);//slope
            c = Convert.ToDouble(dataGridView2.Rows[12].Cells[2].Value);//intercept
            position_NM = Find_Plotting_Position(eastingX, northingY, m, c);

            //equation ML
            m = Convert.ToDouble(dataGridView2.Rows[16].Cells[1].Value);//slope 
            c = Convert.ToDouble(dataGridView2.Rows[16].Cells[2].Value);//intercept
            position_ML = Find_Plotting_Position(eastingX, northingY, m, c);

            //equation VU
            m = Convert.ToDouble(dataGridView2.Rows[10].Cells[1].Value);//slope 
            c = Convert.ToDouble(dataGridView2.Rows[10].Cells[2].Value);//intercept
            position_VU = Find_Plotting_Position(eastingX, northingY, m, c);

            //equation ST
            m = Convert.ToDouble(dataGridView2.Rows[11].Cells[1].Value);//slope 
            c = Convert.ToDouble(dataGridView2.Rows[11].Cells[2].Value);//intercept
            position_ST = Find_Plotting_Position(eastingX, northingY, m, c);

            //MessageBox.Show("L28 = " + position_L28 + "L10 = " + position_L10 + "LC = " + position_LC);

            //plot_case
            if (position_LK == "Above" && position_KN == "Below" && position_NM == "Below" && position_ML == "Above")
            {
                if (position_VU == "Below")
                {
                    plot_case = 40;
                }
                if (position_VU == "Above" && position_ST == "Below")
                {
                    plot_case = 50;
                }
                if (position_ST == "Above")
                {
                    plot_case = 60;
                }
            }
            return plot_case;
        }

        public int TakeOffClimb_Case_of_Plot_COORD(double eastingX, double northingY)
        {
            int plot_case = 0;
            double m, c;
            string position_TOC_AB, position_TOC_BC, position_TOC_CD, position_TOC_DE, position_TOC_EF, position_TOC_FA;
            string position_TOC_GH, position_TOC_HI, position_TOC_IJ, position_TOC_JK, position_TOC_KL, position_TOC_LG;

            //Take Off climb surface 28 side
            //equation TOC_AB
            m = Convert.ToDouble(dataGridView2.Rows[17].Cells[1].Value);//slope
            c = Convert.ToDouble(dataGridView2.Rows[17].Cells[2].Value);//intercept
            position_TOC_AB = Find_Plotting_Position(eastingX, northingY, m, c);

            //equation TOC_AB
            m = Convert.ToDouble(dataGridView2.Rows[19].Cells[1].Value);//slope
            c = Convert.ToDouble(dataGridView2.Rows[19].Cells[2].Value);//intercept
            position_TOC_DE = Find_Plotting_Position(eastingX, northingY, m, c);

            //equation TOC_AF
            m = Convert.ToDouble(dataGridView2.Rows[23].Cells[1].Value);//slope
            c = Convert.ToDouble(dataGridView2.Rows[23].Cells[2].Value);//intercept
            position_TOC_FA = Find_Plotting_Position(eastingX, northingY, m, c);

            //equation TOC_FE
            m = Convert.ToDouble(dataGridView2.Rows[24].Cells[1].Value);//slope 
            c = Convert.ToDouble(dataGridView2.Rows[24].Cells[2].Value);//intercept
            position_TOC_EF = Find_Plotting_Position(eastingX, northingY, m, c);

            //equation TOC_BC
            m = Convert.ToDouble(dataGridView2.Rows[25].Cells[1].Value);//slope 
            c = Convert.ToDouble(dataGridView2.Rows[25].Cells[2].Value);//intercept
            position_TOC_BC = Find_Plotting_Position(eastingX, northingY, m, c);

            //equation TOC_CD
            m = Convert.ToDouble(dataGridView2.Rows[26].Cells[1].Value);//slope 
            c = Convert.ToDouble(dataGridView2.Rows[26].Cells[2].Value);//intercept
            position_TOC_CD = Find_Plotting_Position(eastingX, northingY, m, c);

            //MessageBox.Show("IJ = " + position_IJ + " JG = " + position_JG + " GH = " + position_GH + " HI = " + position_HI);

            //plot_case
            if (position_TOC_AB == "Below" && position_TOC_FA == "Below" && position_TOC_EF == "Below" && position_TOC_DE == "Above" && position_TOC_CD == "Above" && position_TOC_BC == "Above")
            {
                plot_case = 100;
            }

            //Approach near CD
            //equation TOC_GH
            m = Convert.ToDouble(dataGridView2.Rows[20].Cells[1].Value);//slope
            c = Convert.ToDouble(dataGridView2.Rows[20].Cells[2].Value);//intercept
            position_TOC_GH = Find_Plotting_Position(eastingX, northingY, m, c);

            //equation TOC_JK
            m = Convert.ToDouble(dataGridView2.Rows[22].Cells[1].Value);//slope
            c = Convert.ToDouble(dataGridView2.Rows[22].Cells[2].Value);//intercept
            position_TOC_JK = Find_Plotting_Position(eastingX, northingY, m, c);

            //equation TOC_LG
            m = Convert.ToDouble(dataGridView2.Rows[27].Cells[1].Value);//slope
            c = Convert.ToDouble(dataGridView2.Rows[27].Cells[2].Value);//intercept
            position_TOC_LG = Find_Plotting_Position(eastingX, northingY, m, c);

            //equation TOC_KL
            m = Convert.ToDouble(dataGridView2.Rows[28].Cells[1].Value);//slope 
            c = Convert.ToDouble(dataGridView2.Rows[28].Cells[2].Value);//intercept
            position_TOC_KL = Find_Plotting_Position(eastingX, northingY, m, c);

            //equation TOC_HI
            m = Convert.ToDouble(dataGridView2.Rows[29].Cells[1].Value);//slope 
            c = Convert.ToDouble(dataGridView2.Rows[29].Cells[2].Value);//intercept
            position_TOC_HI = Find_Plotting_Position(eastingX, northingY, m, c);

            //equation TOC_IJ
            m = Convert.ToDouble(dataGridView2.Rows[30].Cells[1].Value);//slope 
            c = Convert.ToDouble(dataGridView2.Rows[30].Cells[2].Value);//intercept
            position_TOC_IJ = Find_Plotting_Position(eastingX, northingY, m, c);

            //MessageBox.Show("L28 = " + position_L28 + "L10 = " + position_L10 + "LC = " + position_LC);

            //plot_case
            if (position_TOC_GH == "Above" && position_TOC_LG == "Below" && position_TOC_KL == "Below" && position_TOC_JK == "Below" && position_TOC_IJ == "Above" && position_TOC_HI == "Above")
            {
                plot_case = 200;
            }
            return plot_case;
        }

        public bool Strip_Case_of_Plot_COORD(double eastingX, double northingY)
        {
            bool plot_case = false;
            double m, c;
            string position_KL, position_JI, position_LI, position_JK;

            //Balked Landing surface 28 side
            //equation BL_AB
            m = Convert.ToDouble(dataGridView2.Rows[9].Cells[1].Value);//slope
            c = Convert.ToDouble(dataGridView2.Rows[9].Cells[2].Value);//intercept
            position_KL = Find_Plotting_Position(eastingX, northingY, m, c);

            //equation BL_CD
            m = Convert.ToDouble(dataGridView2.Rows[5].Cells[1].Value);//slope
            c = Convert.ToDouble(dataGridView2.Rows[5].Cells[2].Value);//intercept
            position_JI = Find_Plotting_Position(eastingX, northingY, m, c);

            //equation BL_DA
            m = Convert.ToDouble(dataGridView2.Rows[42].Cells[1].Value);//slope 
            c = Convert.ToDouble(dataGridView2.Rows[42].Cells[2].Value);//intercept
            position_LI= Find_Plotting_Position(eastingX, northingY, m, c);

            //equation BL_BC
            m = Convert.ToDouble(dataGridView2.Rows[41].Cells[1].Value);//slope
            c = Convert.ToDouble(dataGridView2.Rows[41].Cells[2].Value);//intercept
            position_JK = Find_Plotting_Position(eastingX, northingY, m, c);


            //plot_case
            if (position_KL == "Below" && position_JI == "Above" && position_LI == "Above" && position_JK == "Below")
            {
                plot_case = true;
            }
            else
            {
                plot_case = false;
            }
            return plot_case;
        }

        public int Balked_Landing_Case_of_Plot_COORD(double eastingX, double northingY)
        {
            int plot_case = 0;
            double m, c;
            string position_BL_AB, position_BL_BC, position_BL_CD, position_BL_DA;
            string position_BL_EF, position_BL_FG, position_BL_GH, position_BL_HE;

            //Balked Landing surface 28 side
            //equation BL_AB
            m = Convert.ToDouble(dataGridView2.Rows[31].Cells[1].Value);//slope
            c = Convert.ToDouble(dataGridView2.Rows[31].Cells[2].Value);//intercept
            position_BL_AB = Find_Plotting_Position(eastingX, northingY, m, c);

            //equation BL_CD
            m = Convert.ToDouble(dataGridView2.Rows[32].Cells[1].Value);//slope
            c = Convert.ToDouble(dataGridView2.Rows[32].Cells[2].Value);//intercept
            position_BL_CD = Find_Plotting_Position(eastingX, northingY, m, c);

            //equation BL_DA
            m = Convert.ToDouble(dataGridView2.Rows[35].Cells[1].Value);//slope 
            c = Convert.ToDouble(dataGridView2.Rows[35].Cells[2].Value);//intercept
            position_BL_DA = Find_Plotting_Position(eastingX, northingY, m, c);

            //equation BL_BC
            m = Convert.ToDouble(dataGridView2.Rows[36].Cells[1].Value);//slope
            c = Convert.ToDouble(dataGridView2.Rows[36].Cells[2].Value);//intercept
            position_BL_BC = Find_Plotting_Position(eastingX, northingY, m, c);


            //plot_case
            if (position_BL_AB == "Above" && position_BL_DA == "Below" && position_BL_BC == "Above" && position_BL_CD == "Below")
            {
                plot_case = 400;
            }

            //Approach near CD
            //equation BL_EF
            m = Convert.ToDouble(dataGridView2.Rows[33].Cells[1].Value);//slope
            c = Convert.ToDouble(dataGridView2.Rows[33].Cells[2].Value);//intercept
            position_BL_EF = Find_Plotting_Position(eastingX, northingY, m, c);

            //equation BL_GH
            m = Convert.ToDouble(dataGridView2.Rows[34].Cells[1].Value);//slope
            c = Convert.ToDouble(dataGridView2.Rows[34].Cells[2].Value);//intercept
            position_BL_GH = Find_Plotting_Position(eastingX, northingY, m, c);

            //equation BL_HE
            m = Convert.ToDouble(dataGridView2.Rows[37].Cells[1].Value);//slope
            c = Convert.ToDouble(dataGridView2.Rows[37].Cells[2].Value);//intercept
            position_BL_HE = Find_Plotting_Position(eastingX, northingY, m, c);

            //equation BL_FG
            m = Convert.ToDouble(dataGridView2.Rows[38].Cells[1].Value);//slope 
            c = Convert.ToDouble(dataGridView2.Rows[38].Cells[2].Value);//intercept
            position_BL_FG = Find_Plotting_Position(eastingX, northingY, m, c);

            //plot_case
            if (position_BL_GH == "Above" && position_BL_HE == "Below" && position_BL_EF == "Below" && position_BL_FG == "Above")
            {
                plot_case = 300;
            }
            return plot_case;
        }
        public string Find_Plotting_Position(double eastingX, double northingY, double m, double c)
        {
            double Y_from_Eq;
            string position = "";
            Y_from_Eq = m * eastingX + c;
            if (northingY < Y_from_Eq)
            {
                position = "Below";
            }
            else if(northingY > Y_from_Eq)
            {
                position = "Above";
            }
            else if (northingY == Y_from_Eq)
            {
                position = "On";
            }

            return position;
        }

        public double Find_Quadratic_X(double slope1, double intercept1, double a, double b, double radius, int factor)
        {
            double A, B, C, Quad_x;
            A = (slope1 * slope1 + 1);
            B = 2 * (slope1 * (intercept1 - b) - a);
            C = a * a + (intercept1 - b) * (intercept1 - b) - radius * radius;
            Quad_x = (-B + factor * Math.Sqrt(B * B - 4 * A * C)) / (2 * A); //J_X
            //Quad_x_minus = (-B - Math.Sqrt(B * B - 4 * A * C)) / (2 * A);//I_X
            return Quad_x;
        }

        public double Find_Quadratic_X_Plus(double slope1, double intercept1, double a, double b, double radius)
        {
            double A, B, C, Quad_x_plus;
            A = (slope1 * slope1 + 1);
            B = 2 * (slope1 * (intercept1 - b) - a);
            C = a * a + (intercept1 - b) * (intercept1 - b) - radius * radius;
            Quad_x_plus = (-B + Math.Sqrt(B * B - 4 * A * C)) / (2 * A); //J_X
            //Quad_x_minus = (-B - Math.Sqrt(B * B - 4 * A * C)) / (2 * A);//I_X
            return Quad_x_plus;
        }

        public double Find_Quadratic_X_minus(double slope1, double intercept1, double a, double b, double radius)
        {
            double A, B, C, Quad_x_minus;
            A = (slope1 * slope1 + 1);
            B = 2 * (slope1 * (intercept1 - b) - a);
            C = a * a + (intercept1 - b) * (intercept1 - b) - radius * radius;
            //Quad_x_plus = (-B + Math.Sqrt(B * B - 4 * A * C)) / (2 * A); //J_X
            Quad_x_minus = (-B - Math.Sqrt(B * B - 4 * A * C)) / (2 * A);//I_X
            return Quad_x_minus;
        }

        public double Find_Intersection_X(double slope1, double intercept1, double slope2, double intercept2)
        {
            double x;
            x = (intercept1 - intercept2) / (slope2 - slope1);
            return x;
        }
        public double Find_Intersection_Y(double slope1, double intercept1, double slope2, double intercept2)
        {
            double y;
            y = (slope2 * intercept1 - slope1 * intercept2) / (slope2 - slope1);
            return y;
        }

        public double Intercept_of_Parallel_line(double slope_1, double intercept_1, double distance_offset, int Line_Above)
        {
            double intercept_2 = 0;
            intercept_2 = intercept_1 + Line_Above * distance_offset * (Math.Sqrt(1 + slope_1 * slope_1));
            //Line_Above = 1 means parallel line is above the point on Runway i.e. parallel to CD
            //Line_Above = -1 means parallel line is below the point on Runway i.e. parallel to AB

            return intercept_2;
        }

        private void ComboBoxFilterBy1_SelectedIndexChanged(object sender, EventArgs e)
        {
            RichTxtFilter.SelectionColor = Color.Blue;
            RichTxtFilter.SelectedText += ComboBoxFilterBy1.Text;

            string value;
            SQLiteConnection ConnectDb = new SQLiteConnection("Data Source = ObstacleHeightRecord.sqlite3");
            ConnectDb.Open();

            //for unique value
            string query = "SELECT DISTINCT " + ComboBoxFilterBy1.Text + " FROM TableObstacleHeightRecord";
            SQLiteDataAdapter DataAdptr = new SQLiteDataAdapter(query, ConnectDb);

           System.Data.DataTable Dt = new System.Data.DataTable();
            DataAdptr.Fill(Dt);

            ComboBoxDistinctVal1.Items.Clear();
            foreach (DataRow row in Dt.Rows)
            {
                value = row[0].ToString();
                ComboBoxDistinctVal1.Items.Add(value);
            }

            ConnectDb.Close();
        }

        private void ComboBoxDistinctVal1_SelectedIndexChanged(object sender, EventArgs e)
        {
            RichTxtFilter.SelectionColor = Color.Black;
            RichTxtFilter.SelectedText += "'" + ComboBoxDistinctVal1.Text + "'";
        }

        private void BtnFilter_Click(object sender, EventArgs e)
        {
            SQLiteConnection ConnectDb = new SQLiteConnection("Data Source = ObstacleHeightRecord.sqlite3");
            ConnectDb.Open();

            string query = "SELECT * FROM TableObstacleHeightRecord where " + RichTxtFilter.Text;

            SQLiteDataAdapter DataAdptr = new SQLiteDataAdapter(query, ConnectDb);

            System.Data.DataTable Dt = new System.Data.DataTable();
            DataAdptr.Fill(Dt);
            dataGridView3.DataSource = Dt;


            ConnectDb.Close();
            //MessageBox.Show("Parameters Data Loaded Successfully.", "Load Parameters");
            int rcount = Dt.Rows.Count;
            LblRecordNo.Text = "Total No. of Record Filtered:  " + rcount.ToString();
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            RichTxtFilter.Text = "";
        }

        private void BtnAnd_Click(object sender, EventArgs e)
        {
            RichTxtFilter.SelectionColor = Color.Green;
            RichTxtFilter.SelectedText += " AND ";
        }

        private void BtnOR_Click(object sender, EventArgs e)
        {
            RichTxtFilter.SelectionColor = Color.Green;
            RichTxtFilter.SelectedText += " OR ";
        }

        private void BtnEqualTo_Click(object sender, EventArgs e)
        {
            RichTxtFilter.SelectionColor = Color.Red;
            RichTxtFilter.SelectedText += "=";
        }

        private void BtnLessThan_Click(object sender, EventArgs e)
        {
            RichTxtFilter.SelectionColor = Color.Red;
            RichTxtFilter.SelectedText += "<";
        }

        private void BtnGreaterThan_Click(object sender, EventArgs e)
        {
            RichTxtFilter.SelectionColor = Color.Red;
            RichTxtFilter.SelectedText += ">";
        }

        private void BtnExportRecordToExcel_Click(object sender, EventArgs e)
        {
            try
            {
                CopyAlltoClipboard(dataGridView3);
                Microsoft.Office.Interop.Excel.Application xlexcel;
                Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
                Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
                object misValue = System.Reflection.Missing.Value;
                xlexcel = new Excel.Application();
                xlexcel.Visible = true;
                xlWorkBook = xlexcel.Workbooks.Add(misValue);
                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);


                ((Excel.Range)xlWorkSheet.Cells[1, 1]).Value = "Record " + DateTime.Now.ToString("yyyy/MM/dd_HH:mm:ss");


                Excel.Range CR = (Excel.Range)xlWorkSheet.Cells[5, 1];
                CR.Select();
                xlWorkSheet.PasteSpecial(CR, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);
                // xlWorkBook.Close();
                //  xlexcel.Quit();
                Marshal.ReleaseComObject(xlWorkBook);
                Marshal.ReleaseComObject(xlWorkSheet);

                MessageBox.Show("Export Completed Sucessfully.");

            }
            catch
            {


            }
        }
        private void CopyAlltoClipboard(DataGridView DGV)
        {
            DGV.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            DGV.MultiSelect = true;
            DGV.SelectAll();
            DataObject dataObj = DGV.GetClipboardContent();
            if (dataObj != null)
                Clipboard.SetDataObject(dataObj);
        }

        private void ComboBoxDesignation_SelectedIndexChanged(object sender, EventArgs e)
        {
            TxtDesignation.Text = ComboBoxDesignation.Text;
        }

        private void BtnPreviewLetter_Click(object sender, EventArgs e)
        {
            //writing letter to rich text box
            RichTxtLetters.Text = "";
            RichTxtLetters.SelectionAlignment = System.Windows.Forms.HorizontalAlignment.Right;
            RichTxtLetters.AppendText("\nDate:- " + TxtLetterDate.Text + Environment.NewLine);

            RichTxtLetters.SelectionAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            RichTxtLetters.AppendText("\nTo\n" + TxtLetterTo.Text + Environment.NewLine);

            RichTxtLetters.SelectionAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            RichTxtLetters.AppendText("Subject: " + TxtLetterSubject.Text + Environment.NewLine);

            RichTxtLetters.SelectionAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            RichTxtLetters.AppendText("\nIn response to the letter received from that office dated "
                + TxtPreviousLetterDate.Text + " with ref. no. " + TxtPrevLetterRef.Text
                + "requesting consent for " + TxtObstacleType.Text + " construction, this is to certify that maximum permitted elevation of the proposed "
                + TxtObstacleType.Text + " located at " + TxtLocalLevel.Text + "-" + TxtWardNo.Text + ", "
                + TxtTole.Text + " having plot no. " + TxtPlotNo.Text + " of " + TxtDesignation.Text + " "
                + TxtFirstName.Text + " " + TxtMiddleName.Text + " " + TxtLastName.Text
                + " determined after studying the received drawings, Google Earth Map other related papers is "
                + TxtElev_Permitted.Text + " m (AMSL). Furthermore, it is to notify that this permit has been granted in accordance with the standards stipulated in Obstacle Limitation Surface (OLS) under Civil Aviation Requirement-14 (CAR-14) on the condition that there shall be no further increment of "
                + TxtObstacleType.Text + " height by permanent construction of structure or by installment of pole, tower, antenna or any other equipment without prior approval of this Authority." + Environment.NewLine);

            RichTxtLetters.SelectionAlignment = System.Windows.Forms.HorizontalAlignment.Right;
            RichTxtLetters.AppendText("\n" + TxtLetterSignedby.Text + Environment.NewLine);

            RichTxtLetters.SelectionAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            RichTxtLetters.AppendText("\nCC:\n" + TxtLetterCC.Text);

            //Task.Factory.StartNew(() => { Task.Delay(3000).Wait(); }).Wait(); // wait for 5 seconds to give maps plenty of time to render

            TabPage t = tabControl1.TabPages[5];
            tabControl1.SelectTab(t); //go to tab

            RichTxtLetters.SelectAll();
            RichTxtLetters.DeselectAll();

        }

        private void exportRWYCOORDToExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExportDatagridViewToExcel(dataGridView1);
        }

        public void ExportDatagridViewToExcel(DataGridView DGV1)
        {
            try
            {
                CopyAlltoClipboard(DGV1);
                Microsoft.Office.Interop.Excel.Application xlexcel;
                Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
                Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
                object misValue = System.Reflection.Missing.Value;
                xlexcel = new Excel.Application();
                xlexcel.Visible = true;
                xlWorkBook = xlexcel.Workbooks.Add(misValue);
                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);


                ((Excel.Range)xlWorkSheet.Cells[1, 1]).Value = "Record " + DateTime.Now.ToString("yyyy/MM/dd_HH:mm:ss");


                Excel.Range CR = (Excel.Range)xlWorkSheet.Cells[5, 1];
                CR.Select();
                xlWorkSheet.PasteSpecial(CR, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);
                // xlWorkBook.Close();
                //  xlexcel.Quit();
                Marshal.ReleaseComObject(xlWorkBook);
                Marshal.ReleaseComObject(xlWorkSheet);

                MessageBox.Show("Export Completed Sucessfully.");

            }
            catch
            {


            }
        }

        private void exportLineParameterToExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExportDatagridViewToExcel(dataGridView2);
        }

        private void BtnToWord_Click(object sender, EventArgs e)
        {
            exporttoword.Application wordapp = new exporttoword.Application();
            wordapp.Visible = true;
            exporttoword.Document worddoc;
            object wordobj = System.Reflection.Missing.Value;
            worddoc = wordapp.Documents.Add(ref wordobj);
            Clipboard.SetText(RichTxtLetters.Rtf, TextDataFormat.Rtf);
            wordapp.Selection.TypeText(Clipboard.GetText());
            Microsoft.Office.Interop.Word.Range rng = wordapp.ActiveDocument.Range(0, 0);
            rng.Paste();
            //wordapp.Selection.TypeText(RichTxtLetters.Text);
            wordapp = null;

            TxtLog.Text = "Letter in English exported.";

            //Microsoft.Office.Interop.Word.Application app = new Microsoft.Office.Interop.Word.Application();

            //Microsoft.Office.Interop.Word.Range Range;


        }

        private void TxtLetterDate_TextChanged(object sender, EventArgs e)
        {
            TxtLetterNepaliDate.Text = TxtLetterDate.Text;
        }

        private void TxtPreviousLetterDate_TextChanged(object sender, EventArgs e)
        {
            TxtPrevLetterNepaliDate.Text = TxtPreviousLetterDate.Text;
        }

        private void TxtPrevLetterRef_TextChanged(object sender, EventArgs e)
        {
            TxtPrevLetterRefNepali.Text = TxtPrevLetterRef.Text;
        }

        private void BtnCreateNepaliLetter_Click(object sender, EventArgs e)
        {
            if (TxtFY.Text == "" || TxtLocalLevel.Text == "")
            {
                TxtLog.Text = "Either Fiscal Year or Local level is Empty. Please fill to continue.";
                //TxtLog.Text += Environment.NewLine;
            }
            else
            {
                CreateAccessProjectFolders();

                if (!Directory.Exists(Project_Folders))
                {
                    Directory.CreateDirectory(Project_Folders);
                }

                //Start Word and create a new document.
                Word._Application oWord;
                Word._Document oDoc;
                oWord = new Word.Application();
                oWord.Visible = false;

                object oMissing = System.Reflection.Missing.Value;
                object oEndOfDoc = "\\endofdoc"; /* \endofdoc is a predefined bookmark */

                    Cur_Dir = Environment.CurrentDirectory;
                    string filename_template = Cur_Dir + "\\InputFolder\\FormatFiles\\LetterHeight_Template.dotx";
                    object oTemplate = filename_template;
                    //object oTemplate = "E:\\Tippani_Template.dotx";

                    oDoc = oWord.Documents.Add(ref oTemplate, ref oMissing, ref oMissing, ref oMissing);

                    //Bookmarks and Data
                    object oBookMark;
                    oBookMark = "Date_BM_Letter";
                    oDoc.Bookmarks.get_Item(ref oBookMark).Range.Text = TxtLetterNepaliDate.Text;

                    oBookMark = "RefNo_BM_Letter";
                    oDoc.Bookmarks.get_Item(ref oBookMark).Range.Text = TxtPrevLetterRefNepali.Text;

                    oBookMark = "PrevDate_BM_Letter";
                    oDoc.Bookmarks.get_Item(ref oBookMark).Range.Text = TxtPrevLetterNepaliDate.Text;

                    oBookMark = "OwnerLocation_BM_Letter";
                    oDoc.Bookmarks.get_Item(ref oBookMark).Range.Text = TxtNepaliLocalLevel.Text + "-" + TxtNepaliWardNo.Text;

                    oBookMark = "PlotNo_BM_Letter";
                    oDoc.Bookmarks.get_Item(ref oBookMark).Range.Text = TxtNepaliPlotNo.Text;

                    oBookMark = "Elevation_BM_Letter";
                    oDoc.Bookmarks.get_Item(ref oBookMark).Range.Text = TxtNepaliElevation.Text;

                    //string filename_docx = Cur_Dir + "\\InputFolder\\NewLetter.docx"; 
                    string filename_docx = Project_Folders + "\\" + TxtFirstName.Text + "_" + TxtPlotNo.Text + "_Letter.docx";

                    oDoc.SaveAs2(filename_docx);

                    oDoc.Close();
                    oWord.Quit();

                
                    TxtRecentFolderLocation.Text = Project_Folders;
                    TxtLog.Text = "Letter in Nepali Saved.";
            }
            
        }

        private void TxtPlotNo_TextChanged(object sender, EventArgs e)
        {
            TxtNepaliPlotNo.Text = TxtPlotNo.Text;
        }

        private void TxtElev_Permitted_TextChanged(object sender, EventArgs e)
        {
            TxtNepaliElevation.Text = TxtElev_Permitted.Text;
        }

        private void TxtWardNo_TextChanged(object sender, EventArgs e)
        {
            TxtNepaliWardNo.Text = TxtWardNo.Text;
        }

        private void BtnCreateNepaliTippani_Click(object sender, EventArgs e)
        {
            if (TxtFY.Text == "" || TxtLocalLevel.Text == "")
            {
                TxtLog.Text = "Either Fiscal Year or Local level is Empty. Please fill to continue.";
                //TxtLog.Text += Environment.NewLine;
            }
            else
            {
                CreateAccessProjectFolders();

                if (!Directory.Exists(Project_Folders))
                {
                    Directory.CreateDirectory(Project_Folders);
                }

                //Start Word and create a new document.
                Word._Application oWord;
                Word._Document oDoc;
                oWord = new Word.Application();
                oWord.Visible = false;

                object oMissing = System.Reflection.Missing.Value;
                object oEndOfDoc = "\\endofdoc"; /* \endofdoc is a predefined bookmark */

                Cur_Dir = Environment.CurrentDirectory;
                string filename_template = Cur_Dir + "\\InputFolder\\FormatFiles\\TippaniHeight_Template.dotx";
                object oTemplate = filename_template;
                //object oTemplate = "E:\\Tippani_Template.dotx";

                oDoc = oWord.Documents.Add(ref oTemplate, ref oMissing, ref oMissing, ref oMissing);

                //Bookmarks and Data
                object oBookMark;
                oBookMark = "Date_BM_Tippani";
                oDoc.Bookmarks.get_Item(ref oBookMark).Range.Text = TxtLetterNepaliDate.Text;

                oBookMark = "LocalLevel_BM_Tippani";
                oDoc.Bookmarks.get_Item(ref oBookMark).Range.Text = TxtNepaliLocalLevel.Text;

                oBookMark = "RefNo_BM_Tippani";
                oDoc.Bookmarks.get_Item(ref oBookMark).Range.Text = TxtPrevLetterRefNepali.Text;

                oBookMark = "PrevDate_BM_Tippani";
                oDoc.Bookmarks.get_Item(ref oBookMark).Range.Text = TxtPrevLetterNepaliDate.Text;

                oBookMark = "OwnerLocation_BM_Tippani";
                oDoc.Bookmarks.get_Item(ref oBookMark).Range.Text = TxtNepaliLocalLevel.Text + "-" + TxtNepaliWardNo.Text;

                oBookMark = "PlotNo_BM_Tippani";
                oDoc.Bookmarks.get_Item(ref oBookMark).Range.Text = TxtNepaliPlotNo.Text;

                oBookMark = "Elevation_BM_Tippani";
                oDoc.Bookmarks.get_Item(ref oBookMark).Range.Text = TxtNepaliElevation.Text;

                //string filename_docx = Cur_Dir + "\\InputFolder\\NewLetter.docx"; 
                string filename_docx = Project_Folders + "\\" + TxtFirstName.Text + "_" + TxtPlotNo.Text + "_Tippani.docx";

                oDoc.SaveAs2(filename_docx);

                oDoc.Close();
                oWord.Quit();


                TxtRecentFolderLocation.Text = Project_Folders;
                TxtLog.Text = "Tippani in Nepali Saved.";
            }
        }

        private void PanelFore_SizeChanged(object sender, EventArgs e)
        {
            /*double progress;
            progress = (PanelFore.Width / PanelBack.Width) * 100.0;
            progress = Math.Round(progress, 0);
            LblProgress.Text = progress.ToString() + "%";*/
        }

        private void BtnExportToPDF_Click(object sender, EventArgs e)
        {
            //Function_Export_To_PDF();

        }

        private void Function_Export_To_PDF()
        {
            /*if (TxtFY.Text == "" || TxtLocalLevel.Text == "")
            {
                TxtLog.Text += "Either Fiscal Year or Local level is Empty. Please fill to continue.";
                //TxtLog.Text += Environment.NewLine;
            }
            else
            {
                CreateAccessProjectFolders();

                if (!Directory.Exists(Project_Folders))
                {
                    Directory.CreateDirectory(Project_Folders);
                }
                string PdfFileName = Project_Folders + "\\" + TxtFirstName.Text + "_" + TxtPlotNo.Text + "_Report.pdf";

                //TxtLog.Text = "Exported to PDF"; 
            }*/

            //Add
            int lastRowID = 0, Curr_ID;
            SQLiteConnection ConnectDb = new SQLiteConnection("Data Source = ObstacleHeightRecord.sqlite3");
            ConnectDb.Open();

            string query = "SELECT MAX(ID) FROM TableObstacleHeightRecord";

            SQLiteDataAdapter DataAdptr = new SQLiteDataAdapter(query, ConnectDb);

            System.Data.DataTable Dt = new System.Data.DataTable();
            DataAdptr.Fill(Dt);
            foreach (DataRow row in Dt.Rows) //there is only one row here
            {
                //MessageBox.Show("row[0] = ", row[0].ToString());
                if (row[0] == DBNull.Value)
                {
                    lastRowID = 0;
                }
                else
                {
                    lastRowID = Convert.ToInt32(row[0]);
                }
            }

            ConnectDb.Close();

            if (TxtID.Text == "")
            {
                Curr_ID = lastRowID + 1;
                TxtID.Text = Curr_ID.ToString();
            }


            //BtnCalculate_Click(sender, e);

            CreateAccessProjectFolders();

            if (!Directory.Exists(Project_Folders))
            {
                Directory.CreateDirectory(Project_Folders);
            }
            string PdfFileName = Project_Folders + "\\" + TxtFirstName.Text + "_" + TxtPlotNo.Text + "_Report.pdf";



            //PdfWriter writer = new PdfWriter("E:\\AllPdf.pdf");
            PdfWriter writer = new PdfWriter(PdfFileName);
            PdfDocument pdf = new PdfDocument(writer);
            iText.Layout.Document document = new iText.Layout.Document(pdf);

            //PdfFont KalimatiFont = PdfFontFactory.CreateFont(FontDir0, PdfFontFactory.EmbeddingStrategy.FORCE_EMBEDDED);
            //PdfFont PreetiFont = PdfFontFactory.CreateFont(FontDir1, PdfFontFactory.EmbeddingStrategy.FORCE_EMBEDDED);

            iText.Layout.Element.Paragraph header = new iText.Layout.Element.Paragraph();
            //header.Add("Gautam Buddha International Airport Civil Aviation Office" + "\nSiddharthanagar Municipality-4, Rupandehi\nCivil Engineering Division\nObstacle Height Calculation Sheet\n")
            header.Add(TxtTitleOfReport.Text)
                .SetTextAlignment(TextAlignment.CENTER)
                .SetFontSize(10);
            //.SetFont(KalimatiFont);
            document.Add(header);

            /*Paragraph generated = new Paragraph();
            //generated.Add("Report Generated on : " + DateTime.UtcNow.ToString("yyyy-MM-dd|HH : mm : ss"))
            generated.Add("Calculation sheet generated on : " + DateTime.Now.ToString("F"))
                .SetTextAlignment(TextAlignment.RIGHT)
                .SetFontSize(9);
            //.SetFont(KalimatiFont);
            document.Add(generated);*/

            //Line separator
            LineSeparator ls = new LineSeparator(new SolidLine());
            document.Add(ls);

            iText.Layout.Element.Paragraph generated2 = new iText.Layout.Element.Paragraph();
            generated2.Add("\n");
            //.SetTextAlignment(TextAlignment.RIGHT)
            //.SetFontSize(12);
            //.SetFont(KalimatiFont);
            document.Add(generated2);

            int font_size_table = 9;
            // Table
            //iText.Layout.Element.Table table = new iText.Layout.Element.Table(new float[] { 10, 60, 30 }, false);//3=  no. of columns

            float[] columnWidths = { 1, 5, 5 };
            iText.Layout.Element.Table table = new iText.Layout.Element.Table(UnitValue.CreatePercentArray(columnWidths));

            //Row0------------------------------------------------------
            iText.Layout.Element.Cell cell00 = new iText.Layout.Element.Cell(1, 3) //Cell(1,3) means one row and 3 columns are merged to form one column
               .SetBackgroundColor(iText.Kernel.Colors.ColorConstants.GRAY)
               .SetFontSize(font_size_table)
               .SetTextAlignment(TextAlignment.CENTER)
               .Add(new iText.Layout.Element.Paragraph("A. General Information"));

            //Row1------------------------------------------------------
            iText.Layout.Element.Cell cell11 = new iText.Layout.Element.Cell(1, 1)
               //.SetBackgroundColor(Color.Green)
               .SetTextAlignment(TextAlignment.LEFT)
               .SetFontSize(font_size_table)
               //.SetWidth(3)
               .Add(new iText.Layout.Element.Paragraph("1"));

            iText.Layout.Element.Cell cell12 = new iText.Layout.Element.Cell(1, 1)
               //.SetBackgroundColor(Color.Green)
               .SetTextAlignment(TextAlignment.LEFT)
               .SetFontSize(font_size_table)
               .Add(new iText.Layout.Element.Paragraph("Obstacle Calculation ID"));
            iText.Layout.Element.Cell cell13 = new iText.Layout.Element.Cell(1, 1)
               //.SetBackgroundColor(Color.GRAY)
               .SetTextAlignment(TextAlignment.LEFT)
               .SetFontSize(font_size_table)
               .Add(new iText.Layout.Element.Paragraph(TxtID.Text));


            //Row2------------------------------------------------------
            iText.Layout.Element.Cell cell21 = new iText.Layout.Element.Cell(1, 1)
               //.SetBackgroundColor(Color.Green)
               .SetTextAlignment(TextAlignment.LEFT)
               .SetFontSize(font_size_table)
               .Add(new iText.Layout.Element.Paragraph("2"));

            iText.Layout.Element.Cell cell22 = new iText.Layout.Element.Cell(1, 1)
               //.SetBackgroundColor(Color.Green)
               .SetTextAlignment(TextAlignment.LEFT)
               .SetFontSize(font_size_table)
               .Add(new iText.Layout.Element.Paragraph("Fiscal Year"));

            iText.Layout.Element.Cell cell23 = new iText.Layout.Element.Cell(1, 1)
               //.SetBackgroundColor(Color.GRAY)
               .SetTextAlignment(TextAlignment.LEFT)
               .SetFontSize(font_size_table)
               .Add(new iText.Layout.Element.Paragraph(TxtFY.Text));

            //Row3------------------------------------------------------
            iText.Layout.Element.Cell cell31 = new iText.Layout.Element.Cell(1, 1)
               //.SetBackgroundColor(Color.Green)
               .SetTextAlignment(TextAlignment.LEFT)
               .SetFontSize(font_size_table)
               .Add(new iText.Layout.Element.Paragraph("3"));

            iText.Layout.Element.Cell cell32 = new iText.Layout.Element.Cell(1, 1)
               //.SetBackgroundColor(Color.Green)
               .SetTextAlignment(TextAlignment.LEFT)
               .SetFontSize(font_size_table)
               .Add(new iText.Layout.Element.Paragraph("Obstacle Type"));

            iText.Layout.Element.Cell cell33 = new iText.Layout.Element.Cell(1, 1)
               //.SetBackgroundColor(Color.GRAY)
               .SetTextAlignment(TextAlignment.LEFT)
               .SetFontSize(font_size_table)
               .Add(new iText.Layout.Element.Paragraph(TxtObstacleType.Text));

            //Row4------------------------------------------------------
            iText.Layout.Element.Cell cell41 = new iText.Layout.Element.Cell(1, 1)
               //.SetBackgroundColor(Color.Green)
               .SetTextAlignment(TextAlignment.LEFT)
               .SetFontSize(font_size_table)
               .Add(new iText.Layout.Element.Paragraph("4"));

            iText.Layout.Element.Cell cell42 = new iText.Layout.Element.Cell(1, 1)
               //.SetBackgroundColor(Color.Green)
               .SetTextAlignment(TextAlignment.LEFT)
               .SetFontSize(font_size_table)
               .Add(new iText.Layout.Element.Paragraph("Owner's Name"));

            iText.Layout.Element.Cell cell43 = new iText.Layout.Element.Cell(1, 1)
               //.SetBackgroundColor(Color.GRAY)
               .SetTextAlignment(TextAlignment.LEFT)
               .SetFontSize(font_size_table)
               .Add(new iText.Layout.Element.Paragraph(TxtFirstName.Text + " " + TxtMiddleName.Text + " " + TxtLastName.Text));

            //Row5------------------------------------------------------
            iText.Layout.Element.Cell cell51 = new iText.Layout.Element.Cell(1, 1)
               //.SetBackgroundColor(Color.Green)
               .SetTextAlignment(TextAlignment.LEFT)
               .SetFontSize(font_size_table)
               .Add(new iText.Layout.Element.Paragraph("5"));

            iText.Layout.Element.Cell cell52 = new iText.Layout.Element.Cell(1, 1)
               //.SetBackgroundColor(Color.Green)
               .SetTextAlignment(TextAlignment.LEFT)
               .SetFontSize(font_size_table)
               .Add(new iText.Layout.Element.Paragraph("Address"));

            iText.Layout.Element.Cell cell53 = new iText.Layout.Element.Cell(1, 1)
               //.SetBackgroundColor(Color.GRAY)
               .SetTextAlignment(TextAlignment.LEFT)
               .SetFontSize(font_size_table)
               .Add(new iText.Layout.Element.Paragraph(TxtLocalLevel.Text + " - " + TxtWardNo.Text + ", " + TxtTole.Text));

            //Row6------------------------------------------------------
            iText.Layout.Element.Cell cell61 = new iText.Layout.Element.Cell(1, 1)
               //.SetBackgroundColor(Color.Green)
               .SetTextAlignment(TextAlignment.LEFT)
               .SetFontSize(font_size_table)
               .Add(new iText.Layout.Element.Paragraph("6"));

            iText.Layout.Element.Cell cell62 = new iText.Layout.Element.Cell(1, 1)
               //.SetBackgroundColor(Color.Green)
               .SetTextAlignment(TextAlignment.LEFT)
               .SetFontSize(font_size_table)
               .Add(new iText.Layout.Element.Paragraph("Plot number"));

            iText.Layout.Element.Cell cell63 = new iText.Layout.Element.Cell(1, 1)
               //.SetBackgroundColor(Color.GRAY)
               .SetTextAlignment(TextAlignment.LEFT)
               .SetFontSize(font_size_table)
               .Add(new iText.Layout.Element.Paragraph(TxtPlotNo.Text));

            //Row7------------------------------------------------------
            iText.Layout.Element.Cell cell71 = new iText.Layout.Element.Cell(1, 1)
               //.SetBackgroundColor(Color.Green)
               .SetTextAlignment(TextAlignment.LEFT)
               .SetFontSize(font_size_table)
               .Add(new iText.Layout.Element.Paragraph("7"));

            iText.Layout.Element.Cell cell72 = new iText.Layout.Element.Cell(1, 1)
               //.SetBackgroundColor(Color.Green)
               .SetTextAlignment(TextAlignment.LEFT)
               .SetFontSize(font_size_table)
               .Add(new iText.Layout.Element.Paragraph("Nearest Plot Coordinate"));

            iText.Layout.Element.Cell cell73 = new iText.Layout.Element.Cell(1, 1)
               //.SetBackgroundColor(Color.GRAY)
               .SetTextAlignment(TextAlignment.LEFT)
               .SetFontSize(font_size_table)
               .Add(new iText.Layout.Element.Paragraph(TxtLat2.Text + ", " + TxtLong2.Text));

            //Row8------------------------------------------------------
            iText.Layout.Element.Cell cell81 = new iText.Layout.Element.Cell(1, 1)
               //.SetBackgroundColor(Color.Green)
               .SetTextAlignment(TextAlignment.LEFT)
               .SetFontSize(font_size_table)
               .Add(new iText.Layout.Element.Paragraph("8"));

            iText.Layout.Element.Cell cell82 = new iText.Layout.Element.Cell(1, 1)
               //.SetBackgroundColor(Color.Green)
               .SetTextAlignment(TextAlignment.LEFT)
               .SetFontSize(font_size_table)
               .Add(new iText.Layout.Element.Paragraph("Runway Coordinate"));

            iText.Layout.Element.Cell cell83 = new iText.Layout.Element.Cell(1, 1)
               //.SetBackgroundColor(Color.GRAY)
               .SetTextAlignment(TextAlignment.LEFT)
               .SetFontSize(font_size_table)
               .Add(new iText.Layout.Element.Paragraph(TxtLat1.Text + ", " + TxtLong1.Text));

            //Row9------------------------------------------------------
            iText.Layout.Element.Cell cell91 = new iText.Layout.Element.Cell(1, 1)
               //.SetBackgroundColor(Color.Green)
               .SetTextAlignment(TextAlignment.LEFT)
               .SetFontSize(font_size_table)
               .Add(new iText.Layout.Element.Paragraph("9"));

            iText.Layout.Element.Cell cell92 = new iText.Layout.Element.Cell(1, 1)
               //.SetBackgroundColor(Color.Green)
               .SetTextAlignment(TextAlignment.LEFT)
               .SetFontSize(font_size_table)
               .Add(new iText.Layout.Element.Paragraph("Distance from RWY to Obstacle"));

            iText.Layout.Element.Cell cell93 = new iText.Layout.Element.Cell(1, 1)
               //.SetBackgroundColor(Color.GRAY)
               .SetTextAlignment(TextAlignment.LEFT)
               .SetFontSize(font_size_table)
               .Add(new iText.Layout.Element.Paragraph(TxtArealDistance.Text + " m"));

            //Row01------------------------------------------------------
            iText.Layout.Element.Cell cell01 = new iText.Layout.Element.Cell(1, 3)
               .SetBackgroundColor(iText.Kernel.Colors.ColorConstants.GRAY)
               .SetTextAlignment(TextAlignment.CENTER)
               .SetFontSize(font_size_table)
               .Add(new iText.Layout.Element.Paragraph("B. Elevation of Proposed obstacle"));


            //Row10------------------------------------------------------
            iText.Layout.Element.Cell cell101 = new iText.Layout.Element.Cell(1, 1)
               //.SetBackgroundColor(Color.Green)
               .SetTextAlignment(TextAlignment.LEFT)
               .SetFontSize(font_size_table)
               .Add(new iText.Layout.Element.Paragraph("10"));

            iText.Layout.Element.Cell cell102 = new iText.Layout.Element.Cell(1, 1)
               //.SetBackgroundColor(Color.Green)
               .SetTextAlignment(TextAlignment.LEFT)
               .SetFontSize(font_size_table)
               .Add(new iText.Layout.Element.Paragraph("RL of Plinth (AMSL)"));

            iText.Layout.Element.Cell cell103 = new iText.Layout.Element.Cell(1, 1)
               //.SetBackgroundColor(Color.GRAY)
               .SetTextAlignment(TextAlignment.LEFT)
               .SetFontSize(font_size_table)
               .Add(new iText.Layout.Element.Paragraph(TxtRL_Plinth.Text + " m"));

            //Row11------------------------------------------------------
            iText.Layout.Element.Cell cell111 = new iText.Layout.Element.Cell(1, 1)
               //.SetBackgroundColor(Color.Green)
               .SetTextAlignment(TextAlignment.LEFT)
               .SetFontSize(font_size_table)
               .Add(new iText.Layout.Element.Paragraph("11"));

            iText.Layout.Element.Cell cell112 = new iText.Layout.Element.Cell(1, 1)
               //.SetBackgroundColor(Color.Green)
               .SetTextAlignment(TextAlignment.LEFT)
               .SetFontSize(font_size_table)
               .Add(new iText.Layout.Element.Paragraph("Height of obstacle above Plinth"));

            iText.Layout.Element.Cell cell113 = new iText.Layout.Element.Cell(1, 1)
               //.SetBackgroundColor(Color.GRAY)
               .SetTextAlignment(TextAlignment.LEFT)
               .SetFontSize(font_size_table)
               .Add(new iText.Layout.Element.Paragraph(TxtHeightAbovePlinth.Text + " m"));

            //Row12------------------------------------------------------
            iText.Layout.Element.Cell cell121 = new iText.Layout.Element.Cell(1, 1)
               //.SetBackgroundColor(Color.Green)
               .SetTextAlignment(TextAlignment.LEFT)
               .SetFontSize(font_size_table)
               .Add(new iText.Layout.Element.Paragraph("12"));

            iText.Layout.Element.Cell cell122 = new iText.Layout.Element.Cell(1, 1)
               //.SetBackgroundColor(Color.Green)
               .SetTextAlignment(TextAlignment.LEFT)
               .SetFontSize(font_size_table)
               .Add(new iText.Layout.Element.Paragraph("Maximum Elevation of Obstacle (AMSL)"));

            iText.Layout.Element.Cell cell123 = new iText.Layout.Element.Cell(1, 1)
               //.SetBackgroundColor(Color.GRAY)
               .SetTextAlignment(TextAlignment.LEFT)
               .SetFontSize(font_size_table)
               .Add(new iText.Layout.Element.Paragraph(TxtElev_Obstacle.Text + " m"));

            //Row02------------------------------------------------------
            iText.Layout.Element.Cell cell02 = new iText.Layout.Element.Cell(1, 3)
               .SetBackgroundColor(iText.Kernel.Colors.ColorConstants.GRAY)
               .SetTextAlignment(TextAlignment.CENTER)
               .SetFontSize(font_size_table)
               .Add(new iText.Layout.Element.Paragraph("C. Allowable Elevation of Obstacle"));

            //Row13------------------------------------------------------
            iText.Layout.Element.Cell cell131 = new iText.Layout.Element.Cell(1, 1)
               //.SetBackgroundColor(Color.Green)
               .SetTextAlignment(TextAlignment.LEFT)
               .SetFontSize(font_size_table)
               .Add(new iText.Layout.Element.Paragraph("13"));

            iText.Layout.Element.Cell cell132 = new iText.Layout.Element.Cell(1, 1)
               //.SetBackgroundColor(Color.Green)
               .SetTextAlignment(TextAlignment.LEFT)
               .SetFontSize(font_size_table)
               .Add(new iText.Layout.Element.Paragraph("RL of RWY (AMSL)"));

            iText.Layout.Element.Cell cell133 = new iText.Layout.Element.Cell(1, 1)
               //.SetBackgroundColor(Color.GRAY)
               .SetTextAlignment(TextAlignment.LEFT)
               .SetFontSize(font_size_table)
               .Add(new iText.Layout.Element.Paragraph(TxtRL_RWY.Text + " m"));

            //Row14------------------------------------------------------
            iText.Layout.Element.Cell cell141 = new iText.Layout.Element.Cell(1, 1)
               //.SetBackgroundColor(Color.Green)
               .SetTextAlignment(TextAlignment.LEFT)
               .SetFontSize(font_size_table)
               .Add(new iText.Layout.Element.Paragraph("14"));

            iText.Layout.Element.Cell cell142 = new iText.Layout.Element.Cell(1, 1)
               //.SetBackgroundColor(Color.Green)
               .SetTextAlignment(TextAlignment.LEFT)
               .SetFontSize(font_size_table)
               .Add(new iText.Layout.Element.Paragraph("Obstacle lying in surface"));

            iText.Layout.Element.Cell cell143 = new iText.Layout.Element.Cell(1, 1)
               //.SetBackgroundColor(Color.GRAY)
               .SetTextAlignment(TextAlignment.LEFT)
               .SetFontSize(font_size_table)
               .Add(new iText.Layout.Element.Paragraph(TxtSurfaceName.Text));

            //Row15------------------------------------------------------
            iText.Layout.Element.Cell cell151 = new iText.Layout.Element.Cell(1, 1)
               //.SetBackgroundColor(Color.Green)
               .SetTextAlignment(TextAlignment.LEFT)
               .SetFontSize(font_size_table)
               .Add(new iText.Layout.Element.Paragraph("15"));

            iText.Layout.Element.Cell cell152 = new iText.Layout.Element.Cell(1, 1)
               //.SetBackgroundColor(Color.Green)
               .SetTextAlignment(TextAlignment.LEFT)
               .SetFontSize(font_size_table)
               .Add(new iText.Layout.Element.Paragraph("Surface height above RWY"));

            iText.Layout.Element.Cell cell153 = new iText.Layout.Element.Cell(1, 1)
               //.SetBackgroundColor(Color.GRAY)
               .SetTextAlignment(TextAlignment.LEFT)
               .SetFontSize(font_size_table)
               .Add(new iText.Layout.Element.Paragraph(TxtSurfaceHeightaboveRWY.Text + " m"));

            //Row16------------------------------------------------------
            iText.Layout.Element.Cell cell161 = new iText.Layout.Element.Cell(1, 1)
               //.SetBackgroundColor(Color.Green)
               .SetTextAlignment(TextAlignment.LEFT)
               .SetFontSize(font_size_table)
               .Add(new iText.Layout.Element.Paragraph("16"));

            iText.Layout.Element.Cell cell162 = new iText.Layout.Element.Cell(1, 1)
               //.SetBackgroundColor(Color.Green)
               .SetTextAlignment(TextAlignment.LEFT)
               .SetFontSize(font_size_table)
               .Add(new iText.Layout.Element.Paragraph("Allowable Maximum Obstacle Elevation"));

            iText.Layout.Element.Cell cell163 = new iText.Layout.Element.Cell(1, 1)
               //.SetBackgroundColor(Color.GRAY)
               .SetTextAlignment(TextAlignment.LEFT)
               .SetFontSize(font_size_table)
               .Add(new iText.Layout.Element.Paragraph(TxtCalculationDetail.Text));

            //Row17------------------------------------------------------
            iText.Layout.Element.Cell cell171 = new iText.Layout.Element.Cell(1, 1)
               //.SetBackgroundColor(Color.Green)
               .SetTextAlignment(TextAlignment.LEFT)
               .SetFontSize(font_size_table)
               .Add(new iText.Layout.Element.Paragraph("17"));

            iText.Layout.Element.Cell cell172 = new iText.Layout.Element.Cell(1, 1)
               //.SetBackgroundColor(Color.Green)
               .SetTextAlignment(TextAlignment.LEFT)
               .SetFontSize(font_size_table)
               .Add(new iText.Layout.Element.Paragraph("Hence, Maximum Permitted height of obstacle"));

            iText.Layout.Element.Cell cell173 = new iText.Layout.Element.Cell(1, 1)
               //.SetBackgroundColor(Color.GRAY)
               .SetTextAlignment(TextAlignment.LEFT)
               .SetFontSize(font_size_table)
               .Add(new iText.Layout.Element.Paragraph(TxtElev_Permitted.Text + " m"));

            //Row03------------------------------------------------------
            iText.Layout.Element.Cell cell03 = new iText.Layout.Element.Cell(1, 3)
               .SetBackgroundColor(iText.Kernel.Colors.ColorConstants.GRAY)
               .SetTextAlignment(TextAlignment.CENTER)
               .SetFontSize(font_size_table)
               .Add(new iText.Layout.Element.Paragraph("D. Reference"));


            //Row18------------------------------------------------------
            iText.Layout.Element.Cell cell181 = new iText.Layout.Element.Cell(1, 1)
               //.SetBackgroundColor(Color.Green)
               .SetTextAlignment(TextAlignment.LEFT)
               .SetFontSize(font_size_table)
               .Add(new iText.Layout.Element.Paragraph("18"));

            iText.Layout.Element.Cell cell182 = new iText.Layout.Element.Cell(1, 1)
               //.SetBackgroundColor(Color.Green)
               .SetTextAlignment(TextAlignment.LEFT)
               .SetFontSize(font_size_table)
               .Add(new iText.Layout.Element.Paragraph("Runway Classification"));

            iText.Layout.Element.Cell cell183 = new iText.Layout.Element.Cell(1, 1)
               //.SetBackgroundColor(Color.GRAY)
               .SetTextAlignment(TextAlignment.LEFT)
               .SetFontSize(font_size_table)
               .Add(new iText.Layout.Element.Paragraph(label26.Text));

            //Row19------------------------------------------------------
            iText.Layout.Element.Cell cell191 = new iText.Layout.Element.Cell(1, 1)
               //.SetBackgroundColor(Color.Green)
               .SetTextAlignment(TextAlignment.LEFT)
               .SetFontSize(font_size_table)
               .Add(new iText.Layout.Element.Paragraph("19"));

            iText.Layout.Element.Cell cell192 = new iText.Layout.Element.Cell(1, 1)
               //.SetBackgroundColor(Color.Green)
               .SetTextAlignment(TextAlignment.LEFT)
               .SetFontSize(font_size_table)
               .Add(new iText.Layout.Element.Paragraph("Airport"));

            iText.Layout.Element.Cell cell193 = new iText.Layout.Element.Cell(1, 1)
               //.SetBackgroundColor(Color.GRAY)
               .SetTextAlignment(TextAlignment.LEFT)
               .SetFontSize(font_size_table)
               .Add(new iText.Layout.Element.Paragraph(TxtAirportCode.Text));

            //Row20------------------------------------------------------
            iText.Layout.Element.Cell cell201 = new iText.Layout.Element.Cell(1, 1)
               //.SetBackgroundColor(Color.Green)
               .SetTextAlignment(TextAlignment.LEFT)
               .SetFontSize(font_size_table)
               .Add(new iText.Layout.Element.Paragraph("20"));

            iText.Layout.Element.Cell cell202 = new iText.Layout.Element.Cell(1, 1)
               //.SetBackgroundColor(Color.Green)
               .SetTextAlignment(TextAlignment.LEFT)
               .SetFontSize(font_size_table)
               .Add(new iText.Layout.Element.Paragraph("Docs refered"));

            iText.Layout.Element.Cell cell203 = new iText.Layout.Element.Cell(1, 1)
               //.SetBackgroundColor(Color.GRAY)
               .SetTextAlignment(TextAlignment.LEFT)
               .SetFontSize(font_size_table)
               .Add(new iText.Layout.Element.Paragraph("OLS Chart of ICAO Annex-14 Volume I, Chapter 4 and CAR-14"));

            // Creating an ImageData object 
            String imageFile = Project_Folders + "\\" + TxtFirstName.Text + "_" + TxtPlotNo.Text + "_Map.jpg";
            ImageData data = ImageDataFactory.Create(imageFile);

            // Creating the image       
            iText.Layout.Element.Image img = new iText.Layout.Element.Image(data);

            //Row04------------------------------------------------------
            iText.Layout.Element.Cell cell04 = new iText.Layout.Element.Cell(1, 3)
               .SetBackgroundColor(iText.Kernel.Colors.ColorConstants.GRAY)
               .SetTextAlignment(TextAlignment.CENTER)
               .SetFontSize(font_size_table)
               .Add(new iText.Layout.Element.Paragraph("E. Google Earth Image showing RWY to Obstacle position"));

            //Row05------------------------------------------------------
            iText.Layout.Element.Cell cell05 = new iText.Layout.Element.Cell(1, 3)
               .Add(img.SetAutoScale(true))
               .Add(img.SetHorizontalAlignment(iText.Layout.Properties.HorizontalAlignment.CENTER));

            //adding to table cells
            table.AddCell(cell00); //A

            table.AddCell(cell11);
            table.AddCell(cell12);
            table.AddCell(cell13);

            table.AddCell(cell21);
            table.AddCell(cell22);
            table.AddCell(cell23);

            table.AddCell(cell31);
            table.AddCell(cell32);
            table.AddCell(cell33);

            table.AddCell(cell41);
            table.AddCell(cell42);
            table.AddCell(cell43);

            table.AddCell(cell51);
            table.AddCell(cell52);
            table.AddCell(cell53);

            table.AddCell(cell61);
            table.AddCell(cell62);
            table.AddCell(cell63);

            table.AddCell(cell71);
            table.AddCell(cell72);
            table.AddCell(cell73);

            table.AddCell(cell81);
            table.AddCell(cell82);
            table.AddCell(cell83);

            table.AddCell(cell91);
            table.AddCell(cell92);
            table.AddCell(cell93);

            table.AddCell(cell01); //B

            table.AddCell(cell101);
            table.AddCell(cell102);
            table.AddCell(cell103);

            table.AddCell(cell111);
            table.AddCell(cell112);
            table.AddCell(cell113);

            table.AddCell(cell121);
            table.AddCell(cell122);
            table.AddCell(cell123);

            table.AddCell(cell02); //c

            table.AddCell(cell131);
            table.AddCell(cell132);
            table.AddCell(cell133);

            table.AddCell(cell141);
            table.AddCell(cell142);
            table.AddCell(cell143);

            table.AddCell(cell151);
            table.AddCell(cell152);
            table.AddCell(cell153);

            table.AddCell(cell161);
            table.AddCell(cell162);
            table.AddCell(cell163);

            table.AddCell(cell171);
            table.AddCell(cell172);
            table.AddCell(cell173);

            table.AddCell(cell03); //D

            table.AddCell(cell181);
            table.AddCell(cell182);
            table.AddCell(cell183);

            table.AddCell(cell191);
            table.AddCell(cell192);
            table.AddCell(cell193);

            table.AddCell(cell201);
            table.AddCell(cell202);
            table.AddCell(cell203);

            table.AddCell(cell04); //E

            table.AddCell(cell05); //Image

            document.Add(table);

            //adding letter in next page
            document.Add(new AreaBreak(AreaBreakType.NEXT_PAGE));
            iText.Layout.Element.Paragraph Date1 = new iText.Layout.Element.Paragraph();
            Date1.Add("\n\n\n\n\n\n\n\n\n\nDate:- " + TxtLetterDate.Text + "\n")
                .SetTextAlignment(TextAlignment.RIGHT)
                //.SetFontColor(iText.Kernel.Colors.ColorConstants.RED)
                .SetFontSize(12);
            //.SetFont(KalimatiFont);
            document.Add(Date1);

            iText.Layout.Element.Paragraph Designation1 = new iText.Layout.Element.Paragraph();
            Designation1.Add("\nTo\n" + TxtLetterTo.Text)
                .SetTextAlignment(TextAlignment.LEFT)
                .SetFontSize(12);
            //.SetFont(KalimatiFont);
            document.Add(Designation1);

            iText.Layout.Element.Paragraph Subject1 = new iText.Layout.Element.Paragraph();
            Subject1.Add("\nSubject: " + TxtLetterSubject.Text)
                .SetTextAlignment(TextAlignment.CENTER)
                .SetFontSize(12);
            //.SetFont(KalimatiFont);
            document.Add(Subject1);

            iText.Layout.Element.Paragraph Body1 = new iText.Layout.Element.Paragraph();
            Body1.Add("\nIn response to the letter received from that office dated " + TxtPreviousLetterDate.Text + " with ref. no. " + TxtPrevLetterRef.Text + " requesting consent for building construction, this is to certify that maximum permitted elevation of the proposed " + TxtObstacleType.Text + " located at " + TxtLocalLevel.Text + "-" + TxtWardNo.Text + ", " + TxtTole.Text + " having plot no. "
                + TxtPlotNo.Text + " of " + TxtDesignation.Text + " " + TxtFirstName.Text + " " + TxtMiddleName.Text + " " + TxtLastName.Text + " determined after studying the received drawings, Google Earth Map other related papers is " + TxtElev_Permitted.Text + " m (AMSL). Furthermore, it is to notify that this permit has been granted in accordance with the standards stipulated in Obstacle Limitation Surface (OLS) under Civil Aviation Requirement-14 (CAR-14) on the condition that there shall be no further increment of " + TxtObstacleType.Text + " height by permanent construction of structure or by installation of pole, tower, antenna or any other equipment without prior approval of this Authority.")
                .SetTextAlignment(TextAlignment.JUSTIFIED)
                .SetFontSize(12);
            //.SetFont(KalimatiFont);
            document.Add(Body1);

            iText.Layout.Element.Paragraph Ending1 = new iText.Layout.Element.Paragraph();
            Ending1.Add("\n\n" + TxtLetterSignedby.Text)
                .SetTextAlignment(TextAlignment.RIGHT)
                .SetFontSize(12);
            //.SetFont(KalimatiFont);
            document.Add(Ending1);

            iText.Layout.Element.Paragraph CC1 = new iText.Layout.Element.Paragraph();
            CC1.Add("\n\nCC:\n" + TxtLetterCC.Text)
                .SetTextAlignment(TextAlignment.LEFT)
                .SetFontSize(12);
            //.SetFont(KalimatiFont);
            document.Add(CC1);

            document.Close();
            //MessageBox.Show("Pdf Created Successfully.", "Create Pdf");
            TxtRecentFolderLocation.Text = Project_Folders;
            TxtLog.Text = "Pdf Created Successfully."; 
        }

        public FrmObstacleHeightCalculation()
        {
            InitializeComponent();
        }

        public void LoadTxtToDatagridview(DataGridView Dgv, string FileName, int TxtStartRow, int no_of_Col)
        {
            string[] ReadingText = new string[100];
            //string RWYCoordFilenName;
            int i;
            StreamReader sr;
            string line;


            line = "";
            //FileName = @".\InputFolder\" + TxtAirportCode.Text + "\\" + "Strip_RL.txt";
            //Pass the file path and file name to the StreamReader constructor
            sr = new StreamReader(FileName);
            //Read the first line of text
            line = sr.ReadLine();
            ReadingText[0] = line;
            //Continue to read until you reach end of file
            i = 1;
            while (line != null)
            {
                //Read the next line
                line = sr.ReadLine();
                ReadingText[i] = line;
                i++;
            }
            //close the file
            sr.Close();

            //load RL data of strip
            Dgv.Rows.Clear();
            int startrow = TxtStartRow;
            int sn = 1;
            for (int row = startrow; row <= (i - startrow); row++)
            {
                Dgv.Rows.Add();
                Dgv.Rows[row - startrow].Cells[0].Value = sn.ToString();
                sn++;
            }

            
            for (int row = startrow; row <= (i - startrow); row++)
            {
                string[] splittedtext = ReadingText[row].Split('\t');
                for (int col = 0; col < no_of_Col; col++)
                {
                    Dgv.Rows[row - startrow].Cells[col + 1].Value = splittedtext[col];
                }
            }

        }

        private void BtnLoadRWYCoord_Click(object sender, EventArgs e)
        {
            try
            {
                double slopeXY;
                double interceptXY;
                double distanceXY;
                double x1, y1, x2, y2;
                double a, b;
                string[] ReadingText = new string[100];
                string RWYCoordFilenName;
                //CreateAccessProjectFolders();
                string line;
                line = "";
                RWYCoordFilenName = @".\InputFolder\" + TxtAirportCode.Text + "\\" +TxtAirportCode.Text + ".txt";
                //Pass the file path and file name to the StreamReader constructor
                //StreamReader sr = new StreamReader(@".\LastEvent\LastBill.txt");
                StreamReader sr = new StreamReader(RWYCoordFilenName);
                //Read the first line of text
                line = sr.ReadLine();
                ReadingText[0] = line;
                //Continue to read until you reach end of file
                int i = 1;
                while (line != null)
                {
                    //Read the next line
                    line = sr.ReadLine();
                    ReadingText[i] = line;
                    i++;
                }
                //close the file
                sr.Close();

                //load data to datagridview by splitting by tab character of coord of RWY
                for (int row = 10; row <= 13; row++)
                {
                    string[] splittedtext = ReadingText[row].Split('\t');
                    for (int col = 0; col <= 3; col++)
                    {
                        dataGridView1.Rows[row-10].Cells[col].Value = splittedtext[col];
                    }
                }

                //load central meridian of Runway
                for (int row = 0; row <= 0; row++) //row 0 of text file contains info about central meridian
                {
                    string[] splittedtext = ReadingText[row].Split('\t');
                    for (int col = 1; col <= 1; col++)
                    {
                        TxtCM.Text = splittedtext[col];
                    }
                }

                //load RL of Runway datum for IHS, OHS, Co
                for (int row = 1; row <= 1; row++) //row 1 of text file contains info about RL
                {
                    string[] splittedtext = ReadingText[row].Split('\t');
                    for (int col = 1; col <= 1; col++)
                    {
                        TxtRL_IHS.Text = splittedtext[col];
                    }
                }

                //load RWY Classification
                for (int row = 2; row <= 2; row++) //row 0 of text file contains info about central meridian
                {
                    string[] splittedtext = ReadingText[row].Split('\t');
                    for (int col = 1; col <= 1; col++)
                    {
                        TxtRWYClassify.Text = splittedtext[col];
                    }
                }

                //load Lower threshold displaced by
                for (int row = 3; row <= 3; row++) //row 0 of text file contains info about central meridian
                {
                    string[] splittedtext = ReadingText[row].Split('\t');
                    for (int col = 1; col <= 1; col++)
                    {
                        TxtLower_Disp_Th.Text = splittedtext[col];
                    }
                }

                //load Higher threshold displaced by
                for (int row = 4; row <= 4; row++) //row 0 of text file contains info about central meridian
                {
                    string[] splittedtext = ReadingText[row].Split('\t');
                    for (int col = 1; col <= 1; col++)
                    {
                        TxtHigher_Disp_Th.Text = splittedtext[col];
                    }
                }

                //load AB_CLWY_beyond_Strip
                for (int row = 5; row <= 5; row++) //row 0 of text file contains info about central meridian
                {
                    string[] splittedtext = ReadingText[row].Split('\t');
                    for (int col = 1; col <= 1; col++)
                    {
                        Txt_AB_Clearway.Text = splittedtext[col];
                    }
                }

                //load CD_CLWY_beyond_Strip
                for (int row = 6; row <= 6; row++) //row 0 of text file contains info about central meridian
                {
                    string[] splittedtext = ReadingText[row].Split('\t');
                    for (int col = 1; col <= 1; col++)
                    {
                        Txt_CD_Clearway.Text = splittedtext[col];
                    }
                }

                //load ARP_Latitude
                for (int row = 7; row <= 7; row++) //row 0 of text file contains info about central meridian
                {
                    string[] splittedtext = ReadingText[row].Split('\t');
                    for (int col = 1; col <= 1; col++)
                    {
                        Txt_ARP_Latitude.Text = splittedtext[col];
                    }
                }

                //load ARP_Longitude
                for (int row = 8; row <= 8; row++) //row 0 of text file contains info about central meridian
                {
                    string[] splittedtext = ReadingText[row].Split('\t');
                    for (int col = 1; col <= 1; col++)
                    {
                        Txt_ARP_Longitude.Text = splittedtext[col];
                    }
                }

                TxtLog.Text = "RWY COORD loaded of Airport " + TxtAirportCode.Text;

                //Loading RWY Classification data
                line = "";
                RWYCoordFilenName = @".\InputFolder\"+ TxtAirportCode.Text + "\\" + TxtRWYClassify.Text + ".txt";
                //Pass the file path and file name to the StreamReader constructor
                //StreamReader sr = new StreamReader(@".\LastEvent\LastBill.txt");
                sr = new StreamReader(RWYCoordFilenName);
                //Read the first line of text
                line = sr.ReadLine();
                ReadingText[0] = line;
                //Continue to read until you reach end of file
                i = 1;
                while (line != null)
                {
                    //Read the next line
                    line = sr.ReadLine();
                    ReadingText[i] = line;
                    i++;
                }
                //close the file
                sr.Close();

                //load data to datagridview by splitting by tab character of coord of RWY
                dataGridView5.Rows.Clear();

                for (int row = 2; row <= (i-2); row++)//i-2=43-2=41
                {
                    dataGridView5.Rows.Add();
                    dataGridView5.Rows[row - 2].Cells[0].Value = (row-1).ToString();
                }

                for (int row = 2; row <= (i-2); row++)
                {
                    string[] splittedtext = ReadingText[row].Split('\t');
                    for (int col = 0; col <= 1; col++)
                    {
                        dataGridView5.Rows[row - 2].Cells[col + 1].Value = splittedtext[col];
                    }
                }

                //load RWY Classification name
                for (int row = 0; row <= 0; row++) //row 0 of text file contains info about central meridian
                {
                    string[] splittedtext = ReadingText[row].Split('\t');
                    for (int col = 1; col <= 1; col++)
                    {
                        label26.Text = splittedtext[col];
                    }
                }
                
                //Load rwy strip RL
                RWYCoordFilenName = @".\InputFolder\" + TxtAirportCode.Text + "\\" + "Strip_RL.txt";
                LoadTxtToDatagridview(dataGridView6, RWYCoordFilenName, 2, 3);

                //Transfer data from strip RL datagridview to respective textboxes
                int n_rows = (dataGridView6.RowCount-1); 
                for (int k =0; k < n_rows; k++)
                {
                    string names = dataGridView6.Rows[k].Cells[3].Value.ToString();
                    if (names == "CD_Threshold_Midpoint")
                    {
                        Txt_RL_CD_Th.Text = dataGridView6.Rows[k].Cells[2].Value.ToString();
                    }

                    if (names == "AB_Threshold_Midpoint")
                    {
                       TxtRL_AB_Th.Text = dataGridView6.Rows[k].Cells[2].Value.ToString();
                    }
                }

                //Load ToC CD
                RWYCoordFilenName = @".\InputFolder\" + TxtAirportCode.Text + "\\" + "Toc_CD_RL.txt";
                LoadTxtToDatagridview(dataGridView7, RWYCoordFilenName, 2, 3);

                //Load ToC CD
                RWYCoordFilenName = @".\InputFolder\" + TxtAirportCode.Text + "\\" + "Toc_AB_RL.txt";
                LoadTxtToDatagridview(dataGridView8, RWYCoordFilenName, 2, 3);

                //Finding EastingX, NorthingY of RWY coord ABCD
                double templat, templong;
                double[] EastNorthXY = new double[2];

                for(int k =0; k<=3; k++)
                {
                    //A
                    templat = Convert.ToDouble(dataGridView1.Rows[k].Cells[2].Value);//ColLatitude
                    templong = Convert.ToDouble(dataGridView1.Rows[k].Cells[3].Value);//ColLongitude
                    EastNorthXY = Convert_LatLong_To_UTM(templat, templong);
                    dataGridView1.Rows[k].Cells[4].Value = EastNorthXY[0].ToString();//ColEasting
                    dataGridView1.Rows[k].Cells[5].Value = EastNorthXY[1].ToString();//ColNorthing
                }
               

                //for mid coordinates of runway
                int count = 0;
                for(int r = 4; r<=5; r++)
                {
                    for(int col=2; col<=5; col++)
                    {
                        a = Convert.ToDouble(dataGridView1.Rows[r-4+count].Cells[col].Value);
                        b = Convert.ToDouble(dataGridView1.Rows[r-3+count].Cells[col].Value);
                        dataGridView1.Rows[r].Cells[col].Value = ((a + b) / 2).ToString();
                    }
                    count++;
                }
                dataGridView1.Rows[4].Cells["ColPoint"].Value = "E";
                dataGridView1.Rows[5].Cells["ColPoint"].Value = "F";

                dataGridView1.Rows[4].Cells["ColDescription"].Value = "RWY C";
                dataGridView1.Rows[5].Cells["ColDescription"].Value = "RWY C";

                //calculating slope, intercept and Equation of equation
                int c;
                for (int r = 0; r <= 4; r++)
                {
                    c = 0;
                    if (r == 3)
                    {
                        c = r + 1;
                    }
                    x1 = Convert.ToDouble(dataGridView1.Rows[r].Cells["ColEasting"].Value); //A_X
                    y1 = Convert.ToDouble(dataGridView1.Rows[r].Cells["ColNorthing"].Value);//A_Y

                    x2 = Convert.ToDouble(dataGridView1.Rows[r + 1 - c].Cells["ColEasting"].Value); //D_X
                    y2 = Convert.ToDouble(dataGridView1.Rows[r + 1 - c].Cells["ColNorthing"].Value); //D_Y
                    slopeXY = Find_Slope_Of_Equation(x1, y1, x2, y2);
                    interceptXY = Find_Intercept_Of_Equation(slopeXY, x1, y1);
                    distanceXY = Find_Distance_Of_LineXY(x1, y1, x2, y2);

                    dataGridView2.Rows[r].Cells["ColLine"].Value = dataGridView1.Rows[r].Cells["ColPoint"].Value.ToString() + dataGridView1.Rows[r + 1 - c].Cells["ColPoint"].Value.ToString();
                    dataGridView2.Rows[r].Cells["ColSlope"].Value = slopeXY.ToString();
                    dataGridView2.Rows[r].Cells["ColIntercept"].Value = interceptXY.ToString();
                    dataGridView2.Rows[r].Cells["ColDistance"].Value = distanceXY.ToString();
                }
                //plot runway polygon
                Plot_RWY_Polygon();

                //For approach equation i.e. slope and intercepts
                double Dist_From_Threshold_Ap, Len_of_InnerEdge_Ap, Divergence_Ap;
                double Length_First_Ap, Length_Second_Ap, Length_hz_Ap, Total_Len_Ap;
                Len_of_InnerEdge_Ap =Convert.ToDouble(dataGridView5.Rows[12].Cells[2].Value);//280.0;
                Dist_From_Threshold_Ap = Convert.ToDouble(dataGridView5.Rows[13].Cells[2].Value); //60.0;
                Divergence_Ap = Convert.ToDouble(dataGridView5.Rows[14].Cells[2].Value); //15;

                Length_First_Ap = Convert.ToDouble(dataGridView5.Rows[16].Cells[2].Value); //3000.0;
                Length_Second_Ap = Convert.ToDouble(dataGridView5.Rows[19].Cells[2].Value); //3600.0;
                Length_hz_Ap = Convert.ToDouble(dataGridView5.Rows[22].Cells[2].Value); //8400.0;
                Total_Len_Ap = Convert.ToDouble(dataGridView5.Rows[23].Cells[2].Value); //15000.0;


                //Equation of line parallel to AB i.e. IJ and GH
                double slope1, intercept1, distanceOffset;
                double[] intercept_parallel = new double[10];
                slope1 = Convert.ToDouble(dataGridView2.Rows[0].Cells["ColSlope"].Value);
                intercept1 = Convert.ToDouble(dataGridView2.Rows[0].Cells["ColIntercept"].Value);

                //For IJ
                distanceOffset = Dist_From_Threshold_Ap;//60
                intercept_parallel[0] = Intercept_of_Parallel_line(slope1, intercept1, distanceOffset, -1);
                dataGridView2.Rows[5].Cells["ColLine"].Value = "IJ";
                dataGridView2.Rows[5].Cells["ColSlope"].Value = slope1.ToString();
                dataGridView2.Rows[5].Cells["ColIntercept"].Value = intercept_parallel[0].ToString();

                //For OP
                distanceOffset = Length_First_Ap + Dist_From_Threshold_Ap;//3000+60
                intercept_parallel[1] = Intercept_of_Parallel_line(slope1, intercept1, distanceOffset, -1);
                dataGridView2.Rows[6].Cells["ColLine"].Value = "OP";
                dataGridView2.Rows[6].Cells["ColSlope"].Value = slope1.ToString();
                dataGridView2.Rows[6].Cells["ColIntercept"].Value = intercept_parallel[1].ToString();

                //For QR
                distanceOffset = Length_First_Ap + Length_Second_Ap + Dist_From_Threshold_Ap; //3000.0 + 3600 + 60
                intercept_parallel[2] = Intercept_of_Parallel_line(slope1, intercept1, distanceOffset, -1);
                dataGridView2.Rows[7].Cells["ColLine"].Value = "QR";
                dataGridView2.Rows[7].Cells["ColSlope"].Value = slope1.ToString();
                dataGridView2.Rows[7].Cells["ColIntercept"].Value = intercept_parallel[2].ToString();

                //For GH
                distanceOffset = Dist_From_Threshold_Ap + Total_Len_Ap; //15000 + 60
                intercept_parallel[3] = Intercept_of_Parallel_line(slope1, intercept1, distanceOffset, -1);
                dataGridView2.Rows[8].Cells["ColLine"].Value = "GH";
                dataGridView2.Rows[8].Cells["ColSlope"].Value = slope1.ToString();
                dataGridView2.Rows[8].Cells["ColIntercept"].Value = intercept_parallel[3].ToString();


                //For KL and MN
                slope1 = Convert.ToDouble(dataGridView2.Rows[2].Cells["ColSlope"].Value);
                intercept1 = Convert.ToDouble(dataGridView2.Rows[2].Cells["ColIntercept"].Value);

                //For KL
                distanceOffset = Dist_From_Threshold_Ap;//60
                intercept_parallel[4] = Intercept_of_Parallel_line(slope1, intercept1, distanceOffset, 1);
                dataGridView2.Rows[9].Cells["ColLine"].Value = "KL";
                dataGridView2.Rows[9].Cells["ColSlope"].Value = slope1.ToString();
                dataGridView2.Rows[9].Cells["ColIntercept"].Value = intercept_parallel[4].ToString();

                //For UV
                distanceOffset = Length_First_Ap + Dist_From_Threshold_Ap;//3000+60
                intercept_parallel[5] = Intercept_of_Parallel_line(slope1, intercept1, distanceOffset, 1);
                dataGridView2.Rows[10].Cells["ColLine"].Value = "UV";
                dataGridView2.Rows[10].Cells["ColSlope"].Value = slope1.ToString();
                dataGridView2.Rows[10].Cells["ColIntercept"].Value = intercept_parallel[5].ToString();

                //For ST
                distanceOffset = Length_First_Ap + Length_Second_Ap + Dist_From_Threshold_Ap; //3000.0 + 3600 + 60
                intercept_parallel[6] = Intercept_of_Parallel_line(slope1, intercept1, distanceOffset, 1);
                dataGridView2.Rows[11].Cells["ColLine"].Value = "ST";
                dataGridView2.Rows[11].Cells["ColSlope"].Value = slope1.ToString();
                dataGridView2.Rows[11].Cells["ColIntercept"].Value = intercept_parallel[6].ToString();

                //For MN
                distanceOffset = Dist_From_Threshold_Ap + Total_Len_Ap; //15000 + 60
                intercept_parallel[7] = Intercept_of_Parallel_line(slope1, intercept1, distanceOffset, 1);
                dataGridView2.Rows[12].Cells["ColLine"].Value = "MN";
                dataGridView2.Rows[12].Cells["ColSlope"].Value = slope1.ToString();
                dataGridView2.Rows[12].Cells["ColIntercept"].Value = intercept_parallel[7].ToString();

                //Point of intersection of circle and line
                double Quad_x_plus, Quad_x_minus, Quad_y_plus, Quad_y_minus;
                //double B, A, C, a, b;
                double dist;
                double slope2, intercept2, radius;
                double[] Approach_COORD_X = new double[20];
                double[] Approach_COORD_Y = new double[20];
                string[] Approach_Point_Name = new string[16] { "J", "I", "O", "P", "R", "Q", "G", "H", "K", "L", "V", "U", "S", "T", "N", "M" };
                double[] latlong1 = new double[2];

                //For Point J and I
                slope2 = Convert.ToDouble(dataGridView2.Rows[4].Cells["ColSlope"].Value);//slope of EF
                intercept2 = Convert.ToDouble(dataGridView2.Rows[4].Cells["ColIntercept"].Value);//intercept of EF
                slope1 = Convert.ToDouble(dataGridView2.Rows[0].Cells["ColSlope"].Value);//slope of AB equals to slope of IJ
                intercept1 = intercept_parallel[0]; //intercept of IJ i.e. parallel line
                double r1 = Len_of_InnerEdge_Ap * 0.5; //half distance of starting line of approach i.e. for 280 m
                radius = r1; //distance between JE' or IE'
                a = Find_Intersection_X(slope1, intercept1, slope2, intercept2);//X-COORD of intersection of EF and IJ
                b = Find_Intersection_Y(slope1, intercept1, slope2, intercept2);//Y-COORD of intersection of EF and IJ

                Quad_x_plus = Find_Quadratic_X_Plus(slope1, intercept1, a, b, radius);
                Quad_x_minus = Find_Quadratic_X_minus(slope1, intercept1, a, b, radius);
                Quad_y_plus = slope1 * Quad_x_plus + intercept1;//J_Y
                Quad_y_minus = slope1 * Quad_x_minus + intercept1;//I_Y
                    
                //COORD J
                Approach_COORD_X[0] = Quad_x_plus;
                Approach_COORD_Y[0] = Quad_y_plus;
                //COORD I
                Approach_COORD_X[1] = Quad_x_minus;
                Approach_COORD_Y[1] = Quad_y_minus;
                latlong1 = Convert_UTM_To_Latitude_Longitude(Quad_x_plus, Quad_y_plus);
                dataGridView1.Rows[6].Cells["ColLatitude"].Value = latlong1[0].ToString();
                dataGridView1.Rows[6].Cells["ColLongitude"].Value = latlong1[1].ToString();
                latlong1 = Convert_UTM_To_Latitude_Longitude(Quad_x_minus, Quad_y_minus);
                dataGridView1.Rows[7].Cells["ColLatitude"].Value = latlong1[0].ToString();
                dataGridView1.Rows[7].Cells["ColLongitude"].Value = latlong1[1].ToString();
                //distance between two points
                dist = Find_Distance_bet_two_pointXY(Quad_x_plus, Quad_y_plus, Quad_x_minus, Quad_y_minus);
                dataGridView2.Rows[5].Cells[3].Value = dist.ToString();

                //For Point O and P
                intercept1 = intercept_parallel[1]; //intercept of OP i.e. parallel line
                radius = (Divergence_Ap/100.0 * Length_First_Ap * 2 + Len_of_InnerEdge_Ap) / 2; //distance between OE' or PE' (450+450+2*r1)/2
                a = Find_Intersection_X(slope1, intercept1, slope2, intercept2);//X-COORD of intersection of EF and IJ
                b = Find_Intersection_Y(slope1, intercept1, slope2, intercept2);//Y-COORD of intersection of EF and IJ
                
                Quad_x_plus = Find_Quadratic_X_Plus(slope1, intercept1, a, b, radius);
                Quad_x_minus = Find_Quadratic_X_minus(slope1, intercept1, a, b, radius);
                Quad_y_plus = slope1 * Quad_x_plus + intercept1;//O_Y
                Quad_y_minus = slope1 * Quad_x_minus + intercept1;//P_Y
                   

                //COORD O
                Approach_COORD_X[2] = Quad_x_plus;
                Approach_COORD_Y[2] = Quad_y_plus;
                //COORD P
                Approach_COORD_X[3] = Quad_x_minus;
                Approach_COORD_Y[3] = Quad_y_minus;
                latlong1 = Convert_UTM_To_Latitude_Longitude(Quad_x_plus, Quad_y_plus);
                dataGridView1.Rows[8].Cells["ColLatitude"].Value = latlong1[0].ToString();
                dataGridView1.Rows[8].Cells["ColLongitude"].Value = latlong1[1].ToString();
                latlong1 = Convert_UTM_To_Latitude_Longitude(Quad_x_minus, Quad_y_minus);
                dataGridView1.Rows[9].Cells["ColLatitude"].Value = latlong1[0].ToString();
                dataGridView1.Rows[9].Cells["ColLongitude"].Value = latlong1[1].ToString();
                //distance between two points
                dist = Find_Distance_bet_two_pointXY(Quad_x_plus, Quad_y_plus, Quad_x_minus, Quad_y_minus);
                dataGridView2.Rows[6].Cells[3].Value = dist.ToString();

                //For Point R and Q
                intercept1 = intercept_parallel[2]; //intercept of OP i.e. parallel line
                radius = (Divergence_Ap / 100.0 * (Length_First_Ap + Length_Second_Ap) * 2 + Len_of_InnerEdge_Ap) / 2; //distance between OE' or PE' //(990+990+280)
                a = Find_Intersection_X(slope1, intercept1, slope2, intercept2);//X-COORD of intersection of EF and IJ
                b = Find_Intersection_Y(slope1, intercept1, slope2, intercept2);//Y-COORD of intersection of EF and IJ

                Quad_x_plus = Find_Quadratic_X_Plus(slope1, intercept1, a, b, radius);
                Quad_x_minus = Find_Quadratic_X_minus(slope1, intercept1, a, b, radius);
                Quad_y_plus = slope1 * Quad_x_plus + intercept1;//O_Y
                Quad_y_minus = slope1 * Quad_x_minus + intercept1;//P_Y
                //COORD R
                Approach_COORD_X[4] = Quad_x_plus;
                Approach_COORD_Y[4] = Quad_y_plus;
                //COORD Q
                Approach_COORD_X[5] = Quad_x_minus;
                Approach_COORD_Y[5] = Quad_y_minus;
                latlong1 = Convert_UTM_To_Latitude_Longitude(Quad_x_plus, Quad_y_plus);
                dataGridView1.Rows[10].Cells["ColLatitude"].Value = latlong1[0].ToString();
                dataGridView1.Rows[10].Cells["ColLongitude"].Value = latlong1[1].ToString();
                latlong1 = Convert_UTM_To_Latitude_Longitude(Quad_x_minus, Quad_y_minus);
                dataGridView1.Rows[11].Cells["ColLatitude"].Value = latlong1[0].ToString();
                dataGridView1.Rows[11].Cells["ColLongitude"].Value = latlong1[1].ToString();
                //distance between two points
                dist = Find_Distance_bet_two_pointXY(Quad_x_plus, Quad_y_plus, Quad_x_minus, Quad_y_minus);
                dataGridView2.Rows[7].Cells[3].Value = dist.ToString();

                //For Point G and H
                intercept1 = intercept_parallel[3]; //intercept of OP i.e. parallel line
                radius = (Divergence_Ap / 100.0 * Total_Len_Ap * 2 + Len_of_InnerEdge_Ap) / 2; //distance between OE' or PE' //(2250*2+280)
                a = Find_Intersection_X(slope1, intercept1, slope2, intercept2);//X-COORD of intersection of EF and IJ
                b = Find_Intersection_Y(slope1, intercept1, slope2, intercept2);//Y-COORD of intersection of EF and IJ

                Quad_x_plus = Find_Quadratic_X_Plus(slope1, intercept1, a, b, radius);
                Quad_x_minus = Find_Quadratic_X_minus(slope1, intercept1, a, b, radius);
                Quad_y_plus = slope1 * Quad_x_plus + intercept1;//O_Y
                Quad_y_minus = slope1 * Quad_x_minus + intercept1;//P_Y
                                                                    //COORD G
                Approach_COORD_X[6] = Quad_x_plus;
                Approach_COORD_Y[6] = Quad_y_plus;
                //COORD H
                Approach_COORD_X[7] = Quad_x_minus;
                Approach_COORD_Y[7] = Quad_y_minus;
                latlong1 = Convert_UTM_To_Latitude_Longitude(Quad_x_plus, Quad_y_plus);
                dataGridView1.Rows[12].Cells["ColLatitude"].Value = latlong1[0].ToString();
                dataGridView1.Rows[12].Cells["ColLongitude"].Value = latlong1[1].ToString();
                latlong1 = Convert_UTM_To_Latitude_Longitude(Quad_x_minus, Quad_y_minus);
                dataGridView1.Rows[13].Cells["ColLatitude"].Value = latlong1[0].ToString();
                dataGridView1.Rows[13].Cells["ColLongitude"].Value = latlong1[1].ToString();
                //distance between two points
                dist = Find_Distance_bet_two_pointXY(Quad_x_plus, Quad_y_plus, Quad_x_minus, Quad_y_minus);
                dataGridView2.Rows[8].Cells[3].Value = dist.ToString();

                //For Point K and L
                slope2 = Convert.ToDouble(dataGridView2.Rows[4].Cells["ColSlope"].Value);//slope of EF
                intercept2 = Convert.ToDouble(dataGridView2.Rows[4].Cells["ColIntercept"].Value);//intercept of EF
                slope1 = Convert.ToDouble(dataGridView2.Rows[2].Cells["ColSlope"].Value);//slope of CD equals to slope of KL
                intercept1 = intercept_parallel[4]; //intercept of KL i.e. parallel line
                radius = r1; //distance between JE' or IE'
                a = Find_Intersection_X(slope1, intercept1, slope2, intercept2);//X-COORD of intersection of EF and IJ
                b = Find_Intersection_Y(slope1, intercept1, slope2, intercept2);//Y-COORD of intersection of EF and IJ

                Quad_x_plus = Find_Quadratic_X_Plus(slope1, intercept1, a, b, radius);
                Quad_x_minus = Find_Quadratic_X_minus(slope1, intercept1, a, b, radius);
                Quad_y_plus = slope1 * Quad_x_plus + intercept1;//J_Y
                Quad_y_minus = slope1 * Quad_x_minus + intercept1;//I_Y
                                                                    //COORD K
                Approach_COORD_X[8] = Quad_x_plus;
                Approach_COORD_Y[8] = Quad_y_plus;
                //COORD L
                Approach_COORD_X[9] = Quad_x_minus;
                Approach_COORD_Y[9] = Quad_y_minus;
                latlong1 = Convert_UTM_To_Latitude_Longitude(Quad_x_plus, Quad_y_plus);
                dataGridView1.Rows[14].Cells["ColLatitude"].Value = latlong1[0].ToString();
                dataGridView1.Rows[14].Cells["ColLongitude"].Value = latlong1[1].ToString();
                latlong1 = Convert_UTM_To_Latitude_Longitude(Quad_x_minus, Quad_y_minus);
                dataGridView1.Rows[15].Cells["ColLatitude"].Value = latlong1[0].ToString();
                dataGridView1.Rows[15].Cells["ColLongitude"].Value = latlong1[1].ToString();
                //distance between two points
                dist = Find_Distance_bet_two_pointXY(Quad_x_plus, Quad_y_plus, Quad_x_minus, Quad_y_minus);
                dataGridView2.Rows[9].Cells[3].Value = dist.ToString();

                //For Point V and U
                intercept1 = intercept_parallel[5]; //intercept of IJ i.e. parallel line
                radius = (Divergence_Ap / 100.0 * Length_First_Ap * 2 + Len_of_InnerEdge_Ap) / 2; //distance between JE' or IE'
                a = Find_Intersection_X(slope1, intercept1, slope2, intercept2);//X-COORD of intersection of EF and IJ
                b = Find_Intersection_Y(slope1, intercept1, slope2, intercept2);//Y-COORD of intersection of EF and IJ

                Quad_x_plus = Find_Quadratic_X_Plus(slope1, intercept1, a, b, radius);
                Quad_x_minus = Find_Quadratic_X_minus(slope1, intercept1, a, b, radius);
                Quad_y_plus = slope1 * Quad_x_plus + intercept1;//J_Y
                Quad_y_minus = slope1 * Quad_x_minus + intercept1;//I_Y
                                                                    //COORD V
                Approach_COORD_X[10] = Quad_x_plus;
                Approach_COORD_Y[10] = Quad_y_plus;
                //COORD U
                Approach_COORD_X[11] = Quad_x_minus;
                Approach_COORD_Y[11] = Quad_y_minus;
                latlong1 = Convert_UTM_To_Latitude_Longitude(Quad_x_plus, Quad_y_plus);
                dataGridView1.Rows[16].Cells["ColLatitude"].Value = latlong1[0].ToString();
                dataGridView1.Rows[16].Cells["ColLongitude"].Value = latlong1[1].ToString();
                latlong1 = Convert_UTM_To_Latitude_Longitude(Quad_x_minus, Quad_y_minus);
                dataGridView1.Rows[17].Cells["ColLatitude"].Value = latlong1[0].ToString();
                dataGridView1.Rows[17].Cells["ColLongitude"].Value = latlong1[1].ToString();
                //distance between two points
                dist = Find_Distance_bet_two_pointXY(Quad_x_plus, Quad_y_plus, Quad_x_minus, Quad_y_minus);
                dataGridView2.Rows[10].Cells[3].Value = dist.ToString();

                //For Point S and T
                intercept1 = intercept_parallel[6]; //intercept of IJ i.e. parallel line
                radius = (Divergence_Ap / 100.0 * (Length_First_Ap  + Length_Second_Ap) * 2 + Len_of_InnerEdge_Ap) / 2; //distance between JE' or IE'
                a = Find_Intersection_X(slope1, intercept1, slope2, intercept2);//X-COORD of intersection of EF and IJ
                b = Find_Intersection_Y(slope1, intercept1, slope2, intercept2);//Y-COORD of intersection of EF and IJ

                Quad_x_plus = Find_Quadratic_X_Plus(slope1, intercept1, a, b, radius);
                Quad_x_minus = Find_Quadratic_X_minus(slope1, intercept1, a, b, radius);
                Quad_y_plus = slope1 * Quad_x_plus + intercept1;//J_Y
                Quad_y_minus = slope1 * Quad_x_minus + intercept1;//I_Y
                                                                    //COORD S
                Approach_COORD_X[12] = Quad_x_plus;
                Approach_COORD_Y[12] = Quad_y_plus;
                //COORD T
                Approach_COORD_X[13] = Quad_x_minus;
                Approach_COORD_Y[13] = Quad_y_minus;
                latlong1 = Convert_UTM_To_Latitude_Longitude(Quad_x_plus, Quad_y_plus);
                dataGridView1.Rows[18].Cells["ColLatitude"].Value = latlong1[0].ToString();
                dataGridView1.Rows[18].Cells["ColLongitude"].Value = latlong1[1].ToString();
                latlong1 = Convert_UTM_To_Latitude_Longitude(Quad_x_minus, Quad_y_minus);
                dataGridView1.Rows[19].Cells["ColLatitude"].Value = latlong1[0].ToString();
                dataGridView1.Rows[19].Cells["ColLongitude"].Value = latlong1[1].ToString();
                //distance between two points
                dist = Find_Distance_bet_two_pointXY(Quad_x_plus, Quad_y_plus, Quad_x_minus, Quad_y_minus);
                dataGridView2.Rows[11].Cells[3].Value = dist.ToString();

                //For Point N and M
                intercept1 = intercept_parallel[7]; //intercept of IJ i.e. parallel line
                radius = (Divergence_Ap / 100.0 * Total_Len_Ap * 2.0 + Len_of_InnerEdge_Ap) / 2; //distance between JE' or IE'
                a = Find_Intersection_X(slope1, intercept1, slope2, intercept2);//X-COORD of intersection of EF and IJ
                b = Find_Intersection_Y(slope1, intercept1, slope2, intercept2);//Y-COORD of intersection of EF and IJ

                Quad_x_plus = Find_Quadratic_X_Plus(slope1, intercept1, a, b, radius);
                Quad_x_minus = Find_Quadratic_X_minus(slope1, intercept1, a, b, radius);
                Quad_y_plus = slope1 * Quad_x_plus + intercept1;//J_Y
                Quad_y_minus = slope1 * Quad_x_minus + intercept1;//I_Y
                                                                    //COORD N
                Approach_COORD_X[14] = Quad_x_plus;
                Approach_COORD_Y[14] = Quad_y_plus;
                //COORD M
                Approach_COORD_X[15] = Quad_x_minus;
                Approach_COORD_Y[15] = Quad_y_minus;
                latlong1 = Convert_UTM_To_Latitude_Longitude(Quad_x_plus, Quad_y_plus);
                dataGridView1.Rows[20].Cells["ColLatitude"].Value = latlong1[0].ToString();
                dataGridView1.Rows[20].Cells["ColLongitude"].Value = latlong1[1].ToString();
                latlong1 = Convert_UTM_To_Latitude_Longitude(Quad_x_minus, Quad_y_minus);
                dataGridView1.Rows[21].Cells["ColLatitude"].Value = latlong1[0].ToString();
                dataGridView1.Rows[21].Cells["ColLongitude"].Value = latlong1[1].ToString();
                //distance between two points
                dist = Find_Distance_bet_two_pointXY(Quad_x_plus, Quad_y_plus, Quad_x_minus, Quad_y_minus);
                dataGridView2.Rows[12].Cells[3].Value = dist.ToString();

                for (int r2 =0; r2<16; r2++)
                {
                    dataGridView1.Rows[r2 + 6].Cells[0].Value = Approach_Point_Name[r2];
                    dataGridView1.Rows[r2 + 6].Cells[4].Value = Approach_COORD_X[r2].ToString();
                    dataGridView1.Rows[r2 + 6].Cells[5].Value = Approach_COORD_Y[r2].ToString();
                }

                //Find slope and intercept of JG, IH, NK and ML
                double[] Approach_Diverg_Slope = new double[5];
                double[] Approach_Diverg_Intercept = new double[5];
                //double x1, y1, x2, y2;
                x1 = Approach_COORD_X[0];
                y1 = Approach_COORD_Y[0];
                x2 = Approach_COORD_X[6];
                y2 = Approach_COORD_Y[6];
                Approach_Diverg_Slope[0] = Find_Slope_Of_Equation(x1, y1, x2, y2);//slope of JG
                Approach_Diverg_Intercept[0] = Find_Intercept_Of_Equation(Approach_Diverg_Slope[0], x1, y1);
                dataGridView2.Rows[13].Cells["ColLine"].Value = "JG";
                dataGridView2.Rows[13].Cells["ColSlope"].Value = Approach_Diverg_Slope[0].ToString();
                dataGridView2.Rows[13].Cells["ColIntercept"].Value = Approach_Diverg_Intercept[0].ToString();
                dataGridView2.Rows[13].Cells["ColDistance"].Value = Find_Distance_bet_two_pointXY(x1, y1, x2, y2).ToString();

                x1 = Approach_COORD_X[1];
                y1 = Approach_COORD_Y[1];
                x2 = Approach_COORD_X[7];
                y2 = Approach_COORD_Y[7];
                Approach_Diverg_Slope[1] = Find_Slope_Of_Equation(x1, y1, x2, y2);//slope of IH
                Approach_Diverg_Intercept[1] = Find_Intercept_Of_Equation(Approach_Diverg_Slope[1], x1, y1);
                dataGridView2.Rows[14].Cells["ColLine"].Value = "IH";
                dataGridView2.Rows[14].Cells["ColSlope"].Value = Approach_Diverg_Slope[1].ToString();
                dataGridView2.Rows[14].Cells["ColIntercept"].Value = Approach_Diverg_Intercept[1].ToString();
                dataGridView2.Rows[14].Cells["ColDistance"].Value = Find_Distance_bet_two_pointXY(x1, y1, x2, y2).ToString();

                x1 = Approach_COORD_X[8];
                y1 = Approach_COORD_Y[8];
                x2 = Approach_COORD_X[14];
                y2 = Approach_COORD_Y[14];
                Approach_Diverg_Slope[2] = Find_Slope_Of_Equation(x1, y1, x2, y2);//slope of NK
                Approach_Diverg_Intercept[2] = Find_Intercept_Of_Equation(Approach_Diverg_Slope[2], x1, y1);
                dataGridView2.Rows[15].Cells["ColLine"].Value = "NK";
                dataGridView2.Rows[15].Cells["ColSlope"].Value = Approach_Diverg_Slope[2].ToString();
                dataGridView2.Rows[15].Cells["ColIntercept"].Value = Approach_Diverg_Intercept[2].ToString();
                dataGridView2.Rows[15].Cells["ColDistance"].Value = Find_Distance_bet_two_pointXY(x1, y1, x2, y2).ToString();

                x1 = Approach_COORD_X[9];
                y1 = Approach_COORD_Y[9];
                x2 = Approach_COORD_X[15];
                y2 = Approach_COORD_Y[15];
                Approach_Diverg_Slope[3] = Find_Slope_Of_Equation(x1, y1, x2, y2);//slope of ML
                Approach_Diverg_Intercept[3] = Find_Intercept_Of_Equation(Approach_Diverg_Slope[3], x1, y1);
                dataGridView2.Rows[16].Cells["ColLine"].Value = "ML";
                dataGridView2.Rows[16].Cells["ColSlope"].Value = Approach_Diverg_Slope[3].ToString();
                dataGridView2.Rows[16].Cells["ColIntercept"].Value = Approach_Diverg_Intercept[3].ToString();
                dataGridView2.Rows[16].Cells["ColDistance"].Value = Find_Distance_bet_two_pointXY(x1, y1, x2, y2).ToString();


                /*int[] ix1 = new int[] { 13, 14 };
                int[] ix2 = new int[] { 6, 7 };
                int[,] ix3 = new int[,] { { 8, 9 },{ 10, 11 } };

                for (int k1 = 0; k1<=1; k1++)
                {
                    slope1 = Convert.ToDouble(dataGridView2.Rows[ix2[k1]].Cells["ColSlope"].Value);//OP
                    intercept1 = Convert.ToDouble(dataGridView2.Rows[ix2[k1]].Cells["ColIntercept"].Value);//OP
                    for (int i1=0; i1 <=1; i1++)
                    {
                        slope2 = Convert.ToDouble(dataGridView2.Rows[ix1[i1]].Cells["ColSlope"].Value);//JG
                        intercept2 = Convert.ToDouble(dataGridView2.Rows[ix1[i1]].Cells["ColIntercept"].Value);//JG

                        x1 = Find_Intersection_X(slope1, intercept1, slope2, intercept2);
                        y1 = Find_Intersection_Y(slope1, intercept1, slope2, intercept2);

                        dataGridView1.Rows[ix3[k1, i1]].Cells["ColEasting"].Value = x1.ToString();
                        dataGridView1.Rows[ix3[k1, i1]].Cells["ColNorthing"].Value = y1.ToString();
                        latlong1 = Convert_UTM_To_Latitude_Longitude(x1, y1);
                        dataGridView1.Rows[ix3[k1, i1]].Cells["ColLatitude"].Value = latlong1[0].ToString();
                        dataGridView1.Rows[ix3[k1, i1]].Cells["ColLongitude"].Value = latlong1[1].ToString();

                    }
                }*/

                Calculate_Take_of_Climb_Surface();
                Calculate_Balked_Landing_Surface();
                Calculate_Transitional_Surface();
                Calculate_Horizontal_Surface();
                Calculate_Conical_Surface();
                Calculate_Hz_Con_Surface_Extreme_Point();
                Calculate_Inner_Approach_Surface();
                Calculate_Corner_Transitional_Surface();
                Calculate_Inner_Transition_Surface_CD_Inner_ApproachEnd();
                Calculate_Inner_Transition_Surface_AB_Inner_ApproachEnd();

                Calculate_Transitional_Surface_with_different_RL();

                Calculate_Inner_Transition_Surface_CD_Inner_ApproachEnd_with_different_RL();
                Calculate_Inner_Transition_Surface_AB_Inner_ApproachEnd_with_Different_RL();

                for (int k = 6; k <= 13; k++)
                {
                    dataGridView1.Rows[k].Cells["ColDescription"].Value = "Approach 1";
                }

                for (int k = 14; k <= 21; k++)
                {
                    dataGridView1.Rows[k].Cells["ColDescription"].Value = "Approach 0";
                }

                for (int k = 22; k <= 27; k++)
                {
                    dataGridView1.Rows[k].Cells["ColDescription"].Value = "Take Off Climb 1";
                }

                for (int k = 28; k <= 33; k++)
                {
                    dataGridView1.Rows[k].Cells["ColDescription"].Value = "Take Off Climb 0";
                }

                for (int k = 34; k <= 37; k++)
                {
                    dataGridView1.Rows[k].Cells["ColDescription"].Value = "Balked Landing 1";
                }

                for (int k = 38; k <= 41; k++)
                {
                    dataGridView1.Rows[k].Cells["ColDescription"].Value = "Balked Landing 0";
                }

                for (int k = 42; k <= 43; k++)
                {
                    dataGridView1.Rows[k].Cells["ColDescription"].Value = "Transitional 1";
                }

                for (int k = 44; k <= 45; k++)
                {
                    dataGridView1.Rows[k].Cells["ColDescription"].Value = "Transitional 0";
                }

                for (int k = 46; k <= 49; k++)
                {
                    dataGridView1.Rows[k].Cells["ColDescription"].Value = "Horizontal Rect";
                }

                for (int k = 50; k <= 53; k++)
                {
                    dataGridView1.Rows[k].Cells["ColDescription"].Value = "Conical Rect";
                }

                for (int k = 54; k <= 57; k++)
                {
                    if(k%2 == 0)
                        dataGridView1.Rows[k].Cells["ColDescription"].Value = "Horizontal Extreme";
                    else
                        dataGridView1.Rows[k].Cells["ColDescription"].Value = "Conical Extreme";
                }

                for (int k = 58; k <= 65; k++)
                {
                    if (k <= 61)
                        dataGridView1.Rows[k].Cells["ColDescription"].Value = "Inner Approach 1";
                    else
                        dataGridView1.Rows[k].Cells["ColDescription"].Value = "Inner Approach 0";
                }

                for (int k = 66; k <= 69; k++)
                {
                    if (k <= 67)
                        dataGridView1.Rows[k].Cells["ColDescription"].Value = "Transition Corner 1";
                    else
                        dataGridView1.Rows[k].Cells["ColDescription"].Value = "Transition Corner 0";
                }

                for (int k = 70; k <= 81; k++)
                {
                    if (k == 70 || k == 73)
                        dataGridView1.Rows[k].Cells["ColDescription"].Value = "Inner Transition CD";
                    else if(k == 76 || k == 79)
                        dataGridView1.Rows[k].Cells["ColDescription"].Value = "Inner Transition AB";
                    else
                        dataGridView1.Rows[k].Cells["ColDescription"].Value = "Intentionally not used";
                }

                Clear_All_Surfaces();
                Draw_Checked_Surfaces();

                double lat_mid, long_mid, lat1, lat2, long1, long2;

                //take lat long input from text boxes
                lat1 = Convert.ToDouble(dataGridView1.Rows[4].Cells[2].Value);
                long1 = Convert.ToDouble(dataGridView1.Rows[4].Cells[3].Value);

                lat2 = Convert.ToDouble(dataGridView1.Rows[5].Cells[2].Value);
                long2 = Convert.ToDouble(dataGridView1.Rows[5].Cells[3].Value);

                lat_mid = (lat1 + lat2) / 2;
                long_mid = (long1 + long2) / 2;
                gMapControl1.Position = new PointLatLng(lat_mid, long_mid); // centered on lat_mid, long_mid

            }
            catch
            {

            }
        }
        public void Calculate_Inner_Approach_Surface()
        {
            //For Inner approach equation i.e. slope and intercepts
            //Equation of line parallel to AB i.e. IA_A and IA_CD
            double slope1, intercept1, distanceOffset;
            double Width_IA, Dist_From_Threshold_IA, Lenght_IA;

            Width_IA = Convert.ToDouble(dataGridView5.Rows[7].Cells[2].Value); //120.0;
            Dist_From_Threshold_IA = Convert.ToDouble(dataGridView5.Rows[8].Cells[2].Value); //60.0;
            Lenght_IA = Convert.ToDouble(dataGridView5.Rows[9].Cells[2].Value); //900.0;

            double[] distanceOffset1 = new double[] { Dist_From_Threshold_IA, Dist_From_Threshold_IA + Lenght_IA};
            double[] intercept_parallel = new double[4];
            double a, b, x1, y1, x2, y2;
            string[] IA_Line_Name = new string[] { "IA_JI", "IA_OP", "IA_KL", "IA_VU" };

            int DGV2_row_inx, DGV1_row_inx, i, intrcpt;
            int[] mulfactor = new int[] { -1, 1 };
            int[] RW_Side = new int[] { 0, 2 };


            intrcpt = 0;
            DGV2_row_inx = 43; //for IA_AB and end at index 50 for IA_KJ
            for (int j = 0; j <= 1; j++)
            {
                slope1 = Convert.ToDouble(dataGridView2.Rows[RW_Side[j]].Cells["ColSlope"].Value);//AB
                intercept1 = Convert.ToDouble(dataGridView2.Rows[RW_Side[j]].Cells["ColIntercept"].Value);//AB

                for (int k = 0; k <= 1; k++)
                {
                    //For IA_DE--->RWY 28 side
                    distanceOffset = distanceOffset1[k];
                    intercept_parallel[intrcpt] = Intercept_of_Parallel_line(slope1, intercept1, distanceOffset, mulfactor[j]);
                    dataGridView2.Rows[DGV2_row_inx].Cells["ColLine"].Value = IA_Line_Name[intrcpt];
                    dataGridView2.Rows[DGV2_row_inx].Cells["ColSlope"].Value = slope1.ToString();
                    dataGridView2.Rows[DGV2_row_inx].Cells["ColIntercept"].Value = intercept_parallel[intrcpt].ToString();

                    DGV2_row_inx++;
                    intrcpt++;
                }
            }

            //Point of intersection of circle and line
            double Quad_x_plus, Quad_x_minus, Quad_y_plus, Quad_y_minus;
            //double B, A, C, a, b;
            double r1 = Width_IA * 0.5; //half distance of starting line of IA
            double dist;
            double slope2, intercept2, radius;
            double[] IA_COORD_X = new double[8];
            double[] IA_COORD_Y = new double[8];
            string[] IA_Point_Name = new string[] { "IA_J", "IA_I", "IA_O", "IA_P", "IA_K", "IA_L", "IA_V", "IA_U" };
            double[] latlong1 = new double[2];
            double[] radii = new double[] { r1, r1 };//Total final width = 900m



            DGV1_row_inx = 58;//for IA_A and end at index 65 for IA_J
            DGV2_row_inx = 43; //for IA_AB and end at index 46 for IA_KJ
            //PtIndex = 0;
            i = 0;
            intrcpt = 0;
            for (int j = 0; j <= 2; j += 2)
            {
                slope2 = Convert.ToDouble(dataGridView2.Rows[4].Cells["ColSlope"].Value);//slope of EF
                intercept2 = Convert.ToDouble(dataGridView2.Rows[4].Cells["ColIntercept"].Value);//intercept of EF
                //For Point IA_A and IA_B
                slope1 = Convert.ToDouble(dataGridView2.Rows[j].Cells["ColSlope"].Value);//slope of AB equals to slope of IA_AB

                for (int k = 0; k <= 1; k++)
                {

                    intercept1 = intercept_parallel[intrcpt]; //intercept of IA_AB i.e. parallel line
                    radius = radii[k]; //distance between IA_A and E'
                    a = Find_Intersection_X(slope1, intercept1, slope2, intercept2);//X-COORD of intersection of EF and IJ
                    b = Find_Intersection_Y(slope1, intercept1, slope2, intercept2);//Y-COORD of intersection of EF and IJ

                    Quad_x_plus = Find_Quadratic_X_Plus(slope1, intercept1, a, b, radius);
                    Quad_x_minus = Find_Quadratic_X_minus(slope1, intercept1, a, b, radius);
                    Quad_y_plus = slope1 * Quad_x_plus + intercept1;//IA_A
                    Quad_y_minus = slope1 * Quad_x_minus + intercept1;//IA_B

                    //COORD IA_A
                    IA_COORD_X[i] = Quad_x_plus;
                    IA_COORD_Y[i] = Quad_y_plus;
                    //COORD IA_B
                    IA_COORD_X[i + 1] = Quad_x_minus;
                    IA_COORD_Y[i + 1] = Quad_y_minus;


                    latlong1 = Convert_UTM_To_Latitude_Longitude(Quad_x_plus, Quad_y_plus);
                    dataGridView1.Rows[DGV1_row_inx].Cells["ColPoint"].Value = IA_Point_Name[i].ToString();
                    dataGridView1.Rows[DGV1_row_inx].Cells["ColLatitude"].Value = latlong1[0].ToString();
                    dataGridView1.Rows[DGV1_row_inx].Cells["ColLongitude"].Value = latlong1[1].ToString();
                    dataGridView1.Rows[DGV1_row_inx].Cells["ColEasting"].Value = Quad_x_plus.ToString();
                    dataGridView1.Rows[DGV1_row_inx].Cells["ColNorthing"].Value = Quad_y_plus.ToString();

                    latlong1 = Convert_UTM_To_Latitude_Longitude(Quad_x_minus, Quad_y_minus);
                    dataGridView1.Rows[DGV1_row_inx + 1].Cells["ColPoint"].Value = IA_Point_Name[i + 1].ToString();
                    dataGridView1.Rows[DGV1_row_inx + 1].Cells["ColLatitude"].Value = latlong1[0].ToString();
                    dataGridView1.Rows[DGV1_row_inx + 1].Cells["ColLongitude"].Value = latlong1[1].ToString();
                    dataGridView1.Rows[DGV1_row_inx + 1].Cells["ColEasting"].Value = Quad_x_minus.ToString();
                    dataGridView1.Rows[DGV1_row_inx + 1].Cells["ColNorthing"].Value = Quad_y_minus.ToString();

                    DGV1_row_inx += 2;

                    //distance between two points
                    dist = Find_Distance_bet_two_pointXY(Quad_x_plus, Quad_y_plus, Quad_x_minus, Quad_y_minus);
                    dataGridView2.Rows[DGV2_row_inx].Cells[3].Value = dist.ToString();

                    DGV2_row_inx++;
                    i += 2;
                    //PtIndex += 2;
                    intrcpt++;
                }

            }


            //Find slope and intercept of inclined JO, IP, KV and LU
            double[] IA_Diverg_Slope = new double[4];
            double[] IA_Diverg_Intercept = new double[4];
            int[,] PIdx = new int[4, 2] { { 0, 2}, { 1, 3 }, { 4, 6 }, { 5, 7 } };
            string[] InclLine = new string[] { "IA_JO", "IA_IP", "IA_KV", "IA_LU" };
            double x11, y11, x22, y22;

            intrcpt = 0;
            DGV2_row_inx = 47; //datagridview2 from index 47 to 50
            for (int kk = 0; kk < 4; kk++)
            {
                for (int j = 0; j <= 0; j++)
                {
                    x11 = IA_COORD_X[PIdx[kk, j]];//PIdx
                    y11 = IA_COORD_Y[PIdx[kk, j]];
                    x22 = IA_COORD_X[PIdx[kk, j + 1]];//PIdx + 1
                    y22 = IA_COORD_Y[PIdx[kk, j + 1]];
                    IA_Diverg_Slope[intrcpt] = Find_Slope_Of_Equation(x11, y11, x22, y22);//intrcpt
                    IA_Diverg_Intercept[intrcpt] = Find_Intercept_Of_Equation(IA_Diverg_Slope[intrcpt], x11, y11);//intrcpt
                    dataGridView2.Rows[DGV2_row_inx].Cells["ColLine"].Value = InclLine[intrcpt];
                    dataGridView2.Rows[DGV2_row_inx].Cells["ColSlope"].Value = IA_Diverg_Slope[intrcpt].ToString();
                    dataGridView2.Rows[DGV2_row_inx].Cells["ColIntercept"].Value = IA_Diverg_Intercept[intrcpt].ToString();
                    dataGridView2.Rows[DGV2_row_inx].Cells["ColDistance"].Value = Find_Distance_bet_two_pointXY(x11, y11, x22, y22).ToString();

                    /*x11 = IA_COORD_X[PIdx[kk, j + 1]];//PIdx
                    y11 = IA_COORD_Y[PIdx[kk, j + 1]];
                    //MessageBox.Show("PIDX = " + PIdx[kk, j + 1].ToString());
                    x22 = IA_COORD_X[PIdx[kk, j + 2]];//PIdx + 1
                    y22 = IA_COORD_Y[PIdx[kk, j + 2]];
                    IA_Diverg_Slope[intrcpt + 1] = Find_Slope_Of_Equation(x11, y11, x22, y22);//intrcpt
                    IA_Diverg_Intercept[intrcpt + 1] = Find_Intercept_Of_Equation(IA_Diverg_Slope[intrcpt + 1], x11, y11);//intrcpt
                    dataGridView2.Rows[DGV2_row_inx + 1].Cells["ColLine"].Value = InclLine[intrcpt + 1];
                    dataGridView2.Rows[DGV2_row_inx + 1].Cells["ColSlope"].Value = IA_Diverg_Slope[intrcpt + 1].ToString();
                    dataGridView2.Rows[DGV2_row_inx + 1].Cells["ColIntercept"].Value = IA_Diverg_Intercept[intrcpt + 1].ToString();
                    dataGridView2.Rows[DGV2_row_inx + 1].Cells["ColDistance"].Value = Find_Distance_bet_two_pointXY(x11, y11, x22, y22).ToString();
                    
                    intrcpt += 2;
                    DGV2_row_inx += 2;*/
                    intrcpt++;
                    DGV2_row_inx++;
                }
            }

        }

        public void Calculate_Hz_Con_Surface_Extreme_Point()
        {
            //Point of intersection of circle and line
            int DGV1_row_inx;
            double Quad_x_plus, Quad_x_minus, Quad_y_plus, Quad_y_minus, a, b;
            double slope2, intercept2, radius;
            double[] C_COORD_X = new double[4];
            double[] C_COORD_Y = new double[4];
            string[] C_Point_Name = new string[4] { "H_E", "C_E", "H_F", "C_F" };
            double[] latlong1 = new double[2];
            double radius_Hz, Slope_Co, Height_Co, radius_Co;

            radius_Hz = Convert.ToDouble(dataGridView5.Rows[5].Cells[2].Value); //4000.0;
            Slope_Co = Convert.ToDouble(dataGridView5.Rows[1].Cells[2].Value); //5.0;
            Height_Co = Convert.ToDouble(dataGridView5.Rows[2].Cells[2].Value); //100.0;

            radius_Co = radius_Hz + Slope_Co / 100.0 * Height_Co;//6000.0
            double[] radii = new double[2] { radius_Hz, radius_Co };//Total final width = 1800 m
            int[] indx = new int[1] { 4 };
            int[] indx1 = new int[2] { 4, 5 };
            int[,] mul = new int[,] { { 1, 0 }, { 0, 1 } };


            DGV1_row_inx = 54;//for C_A and end at index 57 for C_J
            int i = 0;
            for (int j = 0; j <= 1; j++)
            {
                a = Convert.ToDouble(dataGridView1.Rows[indx1[j]].Cells["ColEasting"].Value);//slope of EF
                b = Convert.ToDouble(dataGridView1.Rows[indx1[j]].Cells["ColNorthing"].Value);//intercept of EF

                slope2 = Convert.ToDouble(dataGridView2.Rows[indx[0]].Cells["ColSlope"].Value);//slope of EF
                intercept2 = Convert.ToDouble(dataGridView2.Rows[indx[0]].Cells["ColIntercept"].Value);//intercept of EF
                for(int k =0; k<=1; k++)
                {
                    radius = radii[k]; //4000.0 and 6000.0
                    if(j==0)
                    {
                        Quad_x_plus = Find_Quadratic_X_Plus(slope2, intercept2, a, b, radius);
                        Quad_y_plus = slope2 * Quad_x_plus + intercept2;//C_A

                        //COORD C_A
                        C_COORD_X[i] = Quad_x_plus;
                        C_COORD_Y[i] = Quad_y_plus;

                        latlong1 = Convert_UTM_To_Latitude_Longitude(Quad_x_plus, Quad_y_plus);
                        dataGridView1.Rows[DGV1_row_inx].Cells["ColPoint"].Value = C_Point_Name[i].ToString();
                        dataGridView1.Rows[DGV1_row_inx].Cells["ColLatitude"].Value = latlong1[0].ToString();
                        dataGridView1.Rows[DGV1_row_inx].Cells["ColLongitude"].Value = latlong1[1].ToString();
                        dataGridView1.Rows[DGV1_row_inx].Cells["ColEasting"].Value = Quad_x_plus.ToString();
                        dataGridView1.Rows[DGV1_row_inx].Cells["ColNorthing"].Value = Quad_y_plus.ToString();
                        DGV1_row_inx++;
                        i++;
                    }
                    else if(j==1)
                    {
                        Quad_x_minus = Find_Quadratic_X_minus(slope2, intercept2, a, b, radius);
                        Quad_y_minus = slope2 * Quad_x_minus + intercept2;//C_B
                                                                          //COORD C_B
                        C_COORD_X[i] = Quad_x_minus;
                        C_COORD_Y[i] = Quad_y_minus;
                        latlong1 = Convert_UTM_To_Latitude_Longitude(Quad_x_minus, Quad_y_minus);
                        dataGridView1.Rows[DGV1_row_inx].Cells["ColPoint"].Value = C_Point_Name[i].ToString();
                        dataGridView1.Rows[DGV1_row_inx].Cells["ColLatitude"].Value = latlong1[0].ToString();
                        dataGridView1.Rows[DGV1_row_inx].Cells["ColLongitude"].Value = latlong1[1].ToString();
                        dataGridView1.Rows[DGV1_row_inx].Cells["ColEasting"].Value = Quad_x_minus.ToString();
                        dataGridView1.Rows[DGV1_row_inx].Cells["ColNorthing"].Value = Quad_y_minus.ToString();

                        DGV1_row_inx++;
                        i++;
                    }

                }

            }
        }

        public void Calculate_Conical_Surface()
        {
            //Point of intersection of circle and line
            int DGV1_row_inx;
            double Quad_x_plus, Quad_x_minus, Quad_y_plus, Quad_y_minus, a, b;
            double slope2, intercept2, radius;
            double[] C_COORD_X = new double[4];
            double[] C_COORD_Y = new double[4];
            string[] C_Point_Name = new string[4] { "C_A", "C_B", "C_D", "C_C" };
            double[] latlong1 = new double[2];
            double radius_Hz, Slope_Co, Height_Co, radius_Co;

            radius_Hz = Convert.ToDouble(dataGridView5.Rows[5].Cells[2].Value); //4000.0;
            Slope_Co = Convert.ToDouble(dataGridView5.Rows[1].Cells[2].Value); //5.0;
            Height_Co = Convert.ToDouble(dataGridView5.Rows[2].Cells[2].Value); //100.0;

            radius_Co = radius_Hz + Slope_Co / 100.0 * Height_Co;//6000.0
            double[] radii = new double[2] { radius_Co, radius_Co };//Total final width = 1800 m
            int[] indx = new int[2] { 0, 2 };
            int[] indx1 = new int[2] { 4, 5 };


            DGV1_row_inx = 50;//for C_A and end at index 49 for C_J
            int i = 0;
            for (int j = 0; j <= 1; j++)
            {
                a = Convert.ToDouble(dataGridView1.Rows[indx1[j]].Cells["ColEasting"].Value);//slope of EF
                b = Convert.ToDouble(dataGridView1.Rows[indx1[j]].Cells["ColNorthing"].Value);//intercept of EF

                slope2 = Convert.ToDouble(dataGridView2.Rows[indx[j]].Cells["ColSlope"].Value);//slope of EF
                intercept2 = Convert.ToDouble(dataGridView2.Rows[indx[j]].Cells["ColIntercept"].Value);//intercept of EF

                radius = radii[j]; //4000.0

                Quad_x_plus = Find_Quadratic_X_Plus(slope2, intercept2, a, b, radius);
                Quad_x_minus = Find_Quadratic_X_minus(slope2, intercept2, a, b, radius);
                Quad_y_plus = slope2 * Quad_x_plus + intercept2;//C_A
                Quad_y_minus = slope2 * Quad_x_minus + intercept2;//C_B

                //COORD C_A
                C_COORD_X[i] = Quad_x_plus;
                C_COORD_Y[i] = Quad_y_plus;
                //COORD C_B
                C_COORD_X[i + 1] = Quad_x_minus;
                C_COORD_Y[i + 1] = Quad_y_minus;

                latlong1 = Convert_UTM_To_Latitude_Longitude(Quad_x_plus, Quad_y_plus);
                dataGridView1.Rows[DGV1_row_inx].Cells["ColPoint"].Value = C_Point_Name[i].ToString();
                dataGridView1.Rows[DGV1_row_inx].Cells["ColLatitude"].Value = latlong1[0].ToString();
                dataGridView1.Rows[DGV1_row_inx].Cells["ColLongitude"].Value = latlong1[1].ToString();
                dataGridView1.Rows[DGV1_row_inx].Cells["ColEasting"].Value = Quad_x_plus.ToString();
                dataGridView1.Rows[DGV1_row_inx].Cells["ColNorthing"].Value = Quad_y_plus.ToString();

                latlong1 = Convert_UTM_To_Latitude_Longitude(Quad_x_minus, Quad_y_minus);
                dataGridView1.Rows[DGV1_row_inx + 1].Cells["ColPoint"].Value = C_Point_Name[i + 1].ToString();
                dataGridView1.Rows[DGV1_row_inx + 1].Cells["ColLatitude"].Value = latlong1[0].ToString();
                dataGridView1.Rows[DGV1_row_inx + 1].Cells["ColLongitude"].Value = latlong1[1].ToString();
                dataGridView1.Rows[DGV1_row_inx + 1].Cells["ColEasting"].Value = Quad_x_minus.ToString();
                dataGridView1.Rows[DGV1_row_inx + 1].Cells["ColNorthing"].Value = Quad_y_minus.ToString();

                DGV1_row_inx += 2;
                i += 2;

            }
        }

        public void Calculate_Horizontal_Surface()
        {
            //Point of intersection of circle and line
            int DGV1_row_inx;
            double Quad_x_plus, Quad_x_minus, Quad_y_plus, Quad_y_minus,a,b;
            double dist;
            double slope2, intercept2, radius;
            double[] H_COORD_X = new double[4];
            double[] H_COORD_Y = new double[4];
            string[] H_Point_Name = new string[4] { "H_A", "H_B", "H_D", "H_C" };
            double[] latlong1 = new double[2];
            double radius_Hz;

            radius_Hz = Convert.ToDouble(dataGridView5.Rows[5].Cells[2].Value); //4000.0;

            double[] radii = new double[2] { radius_Hz, radius_Hz};//Total final width = 1800 m
            int[] indx = new int[2] { 0, 2 };
            int[] indx1 = new int[2] { 4, 5 };


            DGV1_row_inx = 46;//for H_A and end at index 49 for H_J
            //DGV2_row_inx = 17; //for H_AB and end at index 22 for H_KJ
            //int PtIndex = 0;
            int i = 0;
            for (int j = 0; j <= 1; j++)
            {
                a = Convert.ToDouble(dataGridView1.Rows[indx1[j]].Cells["ColEasting"].Value);//slope of EF
                b = Convert.ToDouble(dataGridView1.Rows[indx1[j]].Cells["ColNorthing"].Value);//intercept of EF

                slope2 = Convert.ToDouble(dataGridView2.Rows[indx[j]].Cells["ColSlope"].Value);//slope of EF
                intercept2 = Convert.ToDouble(dataGridView2.Rows[indx[j]].Cells["ColIntercept"].Value);//intercept of EF

                radius = radii[j]; //4000.0

                Quad_x_plus = Find_Quadratic_X_Plus(slope2, intercept2, a, b, radius);
                Quad_x_minus = Find_Quadratic_X_minus(slope2, intercept2, a, b, radius);
                Quad_y_plus = slope2 * Quad_x_plus + intercept2;//H_A
                Quad_y_minus = slope2 * Quad_x_minus + intercept2;//H_B

                //COORD H_A
                H_COORD_X[i] = Quad_x_plus;
                H_COORD_Y[i] = Quad_y_plus;
                //COORD H_B
                H_COORD_X[i + 1] = Quad_x_minus;
                H_COORD_Y[i + 1] = Quad_y_minus;

                latlong1 = Convert_UTM_To_Latitude_Longitude(Quad_x_plus, Quad_y_plus);
                dataGridView1.Rows[DGV1_row_inx].Cells["ColPoint"].Value = H_Point_Name[i].ToString();
                dataGridView1.Rows[DGV1_row_inx].Cells["ColLatitude"].Value = latlong1[0].ToString();
                dataGridView1.Rows[DGV1_row_inx].Cells["ColLongitude"].Value = latlong1[1].ToString();
                dataGridView1.Rows[DGV1_row_inx].Cells["ColEasting"].Value = Quad_x_plus.ToString();
                dataGridView1.Rows[DGV1_row_inx].Cells["ColNorthing"].Value = Quad_y_plus.ToString();

                latlong1 = Convert_UTM_To_Latitude_Longitude(Quad_x_minus, Quad_y_minus);
                dataGridView1.Rows[DGV1_row_inx + 1].Cells["ColPoint"].Value = H_Point_Name[i + 1].ToString();
                dataGridView1.Rows[DGV1_row_inx + 1].Cells["ColLatitude"].Value = latlong1[0].ToString();
                dataGridView1.Rows[DGV1_row_inx + 1].Cells["ColLongitude"].Value = latlong1[1].ToString();
                dataGridView1.Rows[DGV1_row_inx + 1].Cells["ColEasting"].Value = Quad_x_minus.ToString();
                dataGridView1.Rows[DGV1_row_inx + 1].Cells["ColNorthing"].Value = Quad_y_minus.ToString();

                DGV1_row_inx += 2;
                i += 2;

            }
        }

        public void Draw_Polygon_With_Many_Points(List<PointLatLng> points, Color Polycolor)
        {
            try
            {
                //show google map
                GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerAndCache;
                gMapControl1.DragButton = MouseButtons.Left;
                gMapControl1.MouseWheelZoomEnabled = true;
                gMapControl1.MapProvider = GMap.NET.MapProviders.GoogleSatelliteMapProvider.Instance;
                //gMapControl1.Zoom = 15;

                //Making red cross invisible
                gMapControl1.ShowCenter = false;

                //Draw Polygon
                GMapOverlay polygons = new GMapOverlay("polygons");
                //List<PointLatLng> points = new List<PointLatLng>();

                /*points.Add(new PointLatLng(lat1, long1));
                points.Add(new PointLatLng(lat2, long2));
                points.Add(new PointLatLng(lat3, long3));
                points.Add(new PointLatLng(lat4, long4));*/

                GMap.NET.WindowsForms.GMapPolygon polygon = new GMap.NET.WindowsForms.GMapPolygon(points, "LinePoly");
                polygons.Polygons.Add(polygon);
                gMapControl1.Overlays.Add(polygons);
                polygon.Fill = new SolidBrush(Color.FromArgb(50, Polycolor));
                polygon.Stroke = new Pen(Polycolor, 0);

                gMapControl1.Invalidate();
                gMapControl1.Update();
                gMapControl1.Refresh();
            }
            catch
            {

            }
        }

        public void Draw_Polygon_With_Four_Points(double lat1, double long1, double lat2, double long2, double lat3, double long3, double lat4, double long4, Color Polycolor)
        {
            try
            {
                //show google map
                GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerAndCache;
                gMapControl1.DragButton = MouseButtons.Left;
                gMapControl1.MouseWheelZoomEnabled = true;
                gMapControl1.MapProvider = GMap.NET.MapProviders.GoogleSatelliteMapProvider.Instance;
                //gMapControl1.Zoom = 15;

                //Making red cross invisible
                gMapControl1.ShowCenter = false;

                //Draw Polygon
                GMapOverlay polygons = new GMapOverlay("polygons");
                List<PointLatLng> points = new List<PointLatLng>();

                points.Add(new PointLatLng(lat1, long1));
                points.Add(new PointLatLng(lat2, long2));
                points.Add(new PointLatLng(lat3, long3));
                points.Add(new PointLatLng(lat4, long4));

                GMap.NET.WindowsForms.GMapPolygon polygon = new GMap.NET.WindowsForms.GMapPolygon(points, "LinePoly");
                polygons.Polygons.Add(polygon);
                gMapControl1.Overlays.Add(polygons);
                polygon.Fill = new SolidBrush(Color.FromArgb(50, Polycolor));
                polygon.Stroke = new Pen(Polycolor, 0);

                gMapControl1.Invalidate();
                gMapControl1.Update();
                gMapControl1.Refresh();




            }
            catch
            {

            }
        }
        public void Draw_Full_Circle(double r, int segments, Color Circle_Color)
        {
            try
            {
                //show google map
                GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerAndCache;
                gMapControl1.DragButton = MouseButtons.Left;
                gMapControl1.MouseWheelZoomEnabled = true;
                gMapControl1.MapProvider = GMap.NET.MapProviders.GoogleSatelliteMapProvider.Instance;
                //gMapControl1.Zoom = 15;

                //Making red cross invisible
                gMapControl1.ShowCenter = false;

                //Draw Polygon
                GMapOverlay polygons = new GMapOverlay("polygons");
                List<PointLatLng> points = new List<PointLatLng>();


                double[] latlong1 = new double[2];


                double a, b, a1, b1, a_E, b_E, a_F, b_F;
                //int segments;

                double seg, theta;
                //segments = 6000;

                //Input of center E
                /*a_E = Convert.ToDouble(dataGridView1.Rows[4].Cells["ColEasting"].Value);//E
                b_E = Convert.ToDouble(dataGridView1.Rows[4].Cells["ColNorthing"].Value);//E

                a_F = Convert.ToDouble(dataGridView1.Rows[5].Cells["ColEasting"].Value);//E
                b_F = Convert.ToDouble(dataGridView1.Rows[5].Cells["ColNorthing"].Value);//E

                a = (a_E + a_F) / 2;
                b = (b_E + b_F) / 2;*/

                double[] ARP_XY = new double[2];
                a_E = Convert.ToDouble(Txt_ARP_Latitude.Text);
                b_E = Convert.ToDouble(Txt_ARP_Longitude.Text);
                ARP_XY = Convert_LatLong_To_UTM(a_E, b_E);
                a = ARP_XY[0];
                b = ARP_XY[1];

                seg = (Math.PI * 2) / segments;//Math.PI * 2 / segments;
                //plot_position = "Below";
                for (int i = 0; i < segments; i++)
                {
                    theta = seg * i;
                    a1 = a + Math.Cos(theta) * r;
                    b1 = b + Math.Sin(theta) * r;
                    
                    latlong1 = Convert_UTM_To_Latitude_Longitude(a1, b1);
                    points.Add(new PointLatLng(latlong1[0], latlong1[1]));
                    
                }

                GMap.NET.WindowsForms.GMapPolygon polygon = new GMap.NET.WindowsForms.GMapPolygon(points, "CirclePoly");
                polygons.Polygons.Add(polygon);
                gMapControl1.Overlays.Add(polygons);
                polygon.Fill = new SolidBrush(Color.FromArgb(50, Circle_Color));
                polygon.Stroke = new Pen(Circle_Color, 0);

                gMapControl1.Invalidate();
                gMapControl1.Update();
                gMapControl1.Refresh();

            }
            catch
            {

            }
        }


        public void Draw_Circle_With_Angle(double r, int segments, string plot_positionAB, string plot_positionCD, Color Circle_Color)
        {
            try
            {
                //show google map
                GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerAndCache;
                gMapControl1.DragButton = MouseButtons.Left;
                gMapControl1.MouseWheelZoomEnabled = true;
                gMapControl1.MapProvider = GMap.NET.MapProviders.GoogleSatelliteMapProvider.Instance;
                //gMapControl1.Zoom = 15;

                //Making red cross invisible
                gMapControl1.ShowCenter = false;

                //Draw Polygon
                GMapOverlay polygons = new GMapOverlay("polygons");
                List<PointLatLng> points = new List<PointLatLng>();

                
                double[] latlong1 = new double[2];


                double a, b;
                double m, c;
                //int segments;

                double seg, theta, a1, b1;
                string plot_position1;
                
                double aa, bb, rr, mm, cc;
                //segments = 6000;

                //Input of center E
                a = Convert.ToDouble(dataGridView1.Rows[4].Cells["ColEasting"].Value);//E
                b = Convert.ToDouble(dataGridView1.Rows[4].Cells["ColNorthing"].Value);//E
                //r = 4000.0;

                m = Convert.ToDouble(dataGridView2.Rows[0].Cells["ColSlope"].Value);//AB
                c = Convert.ToDouble(dataGridView2.Rows[0].Cells["ColIntercept"].Value);//AB

                //Input for center F
                aa = Convert.ToDouble(dataGridView1.Rows[5].Cells["ColEasting"].Value);//E
                bb = Convert.ToDouble(dataGridView1.Rows[5].Cells["ColNorthing"].Value);//E
                rr = r;

                mm = Convert.ToDouble(dataGridView2.Rows[2].Cells["ColSlope"].Value);//CD
                cc = Convert.ToDouble(dataGridView2.Rows[2].Cells["ColIntercept"].Value);//CD

                double temp_theta_slope;
                seg = (Math.PI ) / segments;//Math.PI / segments;
                temp_theta_slope = Math.Atan(m);//radian
                //plot_position = "Below";//AB Side
                for (int i = 0; i >= -segments ; i--)
                {
                    theta = 2 * Math.PI + temp_theta_slope + seg * i;
                    a1 = a + Math.Cos(theta) * r;
                    b1 = b + Math.Sin(theta) * r;
                    plot_position1 = Find_Plotting_Position(a1, b1, m, c);
                    //plot_position2 = Find_Plotting_Position(aa, bb, mm, cc);
                    if(plot_position1 == plot_positionAB || plot_position1 == "On")
                    {
                        latlong1 = Convert_UTM_To_Latitude_Longitude(a1, b1);
                        points.Add(new PointLatLng(latlong1[0], latlong1[1]));
                    }
                }

                //plot_position = "Above";//CD Side
                seg = (Math.PI ) / segments;//Math.PI * 2 / segments;
                temp_theta_slope = Math.Atan(mm);//radian slope of CD
                for (int i = 0; i >= -segments; i--)
                {
                    theta =  Math.PI + temp_theta_slope + seg * i;
                    a1 = aa + Math.Cos(theta) * r;
                    b1 = bb + Math.Sin(theta) * r;
                    plot_position1 = Find_Plotting_Position(a1, b1, mm, cc);
                    //plot_position2 = Find_Plotting_Position(aa, bb, mm, cc);
                    if (plot_position1 == plot_positionCD || plot_position1 == "On")
                    {
                        latlong1 = Convert_UTM_To_Latitude_Longitude(a1, b1);
                        points.Add(new PointLatLng(latlong1[0], latlong1[1]));
                    }
                }

                /*//plot_position = "Below";
                seg = (Math.PI) / segments;//Math.PI * 2 / segments;
                for (int i = 0; i < segments; i++)
                {
                    theta =   seg * i;
                    a1 = a + Math.Cos(theta) * r;
                    b1 = b + Math.Sin(theta) * r;
                    plot_position1 = Find_Plotting_Position(a1, b1, m, c);
                    //plot_position2 = Find_Plotting_Position(aa, bb, mm, cc);
                    if (plot_position1 == plot_positionAB || plot_position1 == "On")
                    {
                        latlong1 = Convert_UTM_To_Latitude_Longitude(a1, b1);
                        points.Add(new PointLatLng(latlong1[0], latlong1[1]));
                    }
                }*/


                GMap.NET.WindowsForms.GMapPolygon polygon = new GMap.NET.WindowsForms.GMapPolygon(points, "CirclePoly");
                polygons.Polygons.Add(polygon);
                gMapControl1.Overlays.Add(polygons);
                polygon.Fill = new SolidBrush(Color.FromArgb(50, Circle_Color));
                polygon.Stroke = new Pen(Circle_Color, 0);

                gMapControl1.Invalidate();
                gMapControl1.Update();
                gMapControl1.Refresh();

            }
            catch
            {

            }
        }
        public void Draw_Selective_Obstalce_Surfaces(int Hz, int Co, int Ap, int Tr, int ToC, int Bl, int IA, int IT_CD, int OHz, int IT_AB)
        {
            double lat1, long1, lat2, long2, lat3, long3, lat4, long4;
            int No_of_Polygon;

            //Approach surfaces
            if (Ap == 1)
            {
                No_of_Polygon = 6;
                int[,] index = new int[,] {
                    { 6, 7, 9, 8 }, //approach 28
                    { 8, 10, 11, 9}, //approach 28
                    { 10, 12, 13, 11}, //approach 28
                    { 14, 15, 17, 16 }, //approach 10
                    { 16, 17, 19, 18},  //approach10
                    { 18, 19, 21, 20}  //approach10
                
                };//One row contains 4 points of polygon in clockwise direction

                Color[] mycolor = new Color[] {
                    Color.Red,
                    Color.Yellow,
                    Color.Red,
                    Color.Red,
                    Color.Yellow,
                    Color.Red
                };

                for (int i = 0; i < No_of_Polygon; i++)
                {
                    //Approach surface-JGHI
                    lat1 = Convert.ToDouble(dataGridView1.Rows[index[i, 0]].Cells["ColLatitude"].Value);
                    long1 = Convert.ToDouble(dataGridView1.Rows[index[i, 0]].Cells["ColLongitude"].Value);

                    lat2 = Convert.ToDouble(dataGridView1.Rows[index[i, 1]].Cells["ColLatitude"].Value);
                    long2 = Convert.ToDouble(dataGridView1.Rows[index[i, 1]].Cells["ColLongitude"].Value);

                    lat3 = Convert.ToDouble(dataGridView1.Rows[index[i, 2]].Cells["ColLatitude"].Value);
                    long3 = Convert.ToDouble(dataGridView1.Rows[index[i, 2]].Cells["ColLongitude"].Value);

                    lat4 = Convert.ToDouble(dataGridView1.Rows[index[i, 3]].Cells["ColLatitude"].Value);
                    long4 = Convert.ToDouble(dataGridView1.Rows[index[i, 3]].Cells["ColLongitude"].Value);

                    Draw_Polygon_With_Four_Points(lat1, long1, lat2, long2, lat3, long3, lat4, long4, mycolor[i]);
                }
            }

            // Transition surfaces
            if (Tr == 1)
            {
                No_of_Polygon = 2;//2
                int vertex_in_one_Poly;
                int[,] index = new int[,] {
                    { 66, 6, 14, 68 }, //Transition, { 66, 6, 14, 68, 43, 42 }
                    { 67, 7, 15, 69 }  //transition, { 15, 7, 67, 44, 45, 69} 
                
                };//One row contains 4 points of polygon in clockwise direction

                Color[] mycolor = new Color[] {
                    Color.Blue,
                    Color.Blue
                };
                vertex_in_one_Poly = 4;
                //int n_row = dataGridView6.RowCount - 1;
                int n_row = (dataGridView9.RowCount - 1) / 2;
                int strt_row = 0, end_row = 0;
                for (int i = 0; i < No_of_Polygon; i++)
                {
                    strt_row = n_row * i;
                    end_row = strt_row + n_row;
                    List<PointLatLng> points = new List<PointLatLng>();
                    for(int k = 0; k < vertex_in_one_Poly; k++)
                    {
                        lat1 = Convert.ToDouble(dataGridView1.Rows[index[i, k]].Cells["ColLatitude"].Value);
                        long1 = Convert.ToDouble(dataGridView1.Rows[index[i, k]].Cells["ColLongitude"].Value);
                        points.Add(new PointLatLng(lat1, long1));

                    }
                    for (int j = strt_row; j < end_row; j++) //for (int j = 0; j < vertex_in_one_Poly; j++)
                    {
                        //lat1 = Convert.ToDouble(dataGridView1.Rows[index[i, j]].Cells["ColLatitude"].Value);
                        //long1 = Convert.ToDouble(dataGridView1.Rows[index[i, j]].Cells["ColLongitude"].Value);
                        //points.Add(new PointLatLng(lat1, long1));

                        lat1 = Convert.ToDouble(dataGridView9.Rows[j].Cells[2].Value);
                        long1 = Convert.ToDouble(dataGridView9.Rows[j].Cells[3].Value);
                        points.Add(new PointLatLng(lat1, long1));
                    }
                    Draw_Polygon_With_Many_Points(points, mycolor[i]);
                }
            }

            //Balked Landing
            if (Bl == 1)
            {
                No_of_Polygon = 2;
                int[,] index = new int[,] {
                     { 34, 36, 37, 35 }, //Balked landing 28 side
                     { 38, 39, 41, 40}  //Balked landing 10 side
                
                };//One row contains 4 points of polygon in clockwise direction

                Color[] mycolor = new Color[] {
                    Color.DarkOrange,
                    Color.DarkOrange
                };

                for (int i = 0; i < No_of_Polygon; i++)
                {
                    //Approach surface-JGHI
                    lat1 = Convert.ToDouble(dataGridView1.Rows[index[i, 0]].Cells["ColLatitude"].Value);
                    long1 = Convert.ToDouble(dataGridView1.Rows[index[i, 0]].Cells["ColLongitude"].Value);

                    lat2 = Convert.ToDouble(dataGridView1.Rows[index[i, 1]].Cells["ColLatitude"].Value);
                    long2 = Convert.ToDouble(dataGridView1.Rows[index[i, 1]].Cells["ColLongitude"].Value);

                    lat3 = Convert.ToDouble(dataGridView1.Rows[index[i, 2]].Cells["ColLatitude"].Value);
                    long3 = Convert.ToDouble(dataGridView1.Rows[index[i, 2]].Cells["ColLongitude"].Value);

                    lat4 = Convert.ToDouble(dataGridView1.Rows[index[i, 3]].Cells["ColLatitude"].Value);
                    long4 = Convert.ToDouble(dataGridView1.Rows[index[i, 3]].Cells["ColLongitude"].Value);

                    Draw_Polygon_With_Four_Points(lat1, long1, lat2, long2, lat3, long3, lat4, long4, mycolor[i]);
                }
            }

            //Takeoff climb surface
            if (ToC == 1)
            {
                No_of_Polygon = 4;
                int[,] index = new int[,] {
                     { 22, 24, 25, 23 }, //Takeoff climb 28 side
                     { 24, 26, 27, 25},  //Takeoff climb  28 side
                     { 28, 29, 31, 30 }, //Takeoff climb 10 side
                     { 31, 33, 32, 30}  //Takeoff climb  10 side
                
                };//One row contains 4 points of polygon in clockwise direction

                Color[] mycolor = new Color[] {
                    Color.Cyan,
                    Color.Cyan,
                    Color.Cyan,
                    Color.Cyan
                };

                for (int i = 0; i < No_of_Polygon; i++)
                {
                    //Approach surface-JGHI
                    lat1 = Convert.ToDouble(dataGridView1.Rows[index[i, 0]].Cells["ColLatitude"].Value);
                    long1 = Convert.ToDouble(dataGridView1.Rows[index[i, 0]].Cells["ColLongitude"].Value);

                    lat2 = Convert.ToDouble(dataGridView1.Rows[index[i, 1]].Cells["ColLatitude"].Value);
                    long2 = Convert.ToDouble(dataGridView1.Rows[index[i, 1]].Cells["ColLongitude"].Value);

                    lat3 = Convert.ToDouble(dataGridView1.Rows[index[i, 2]].Cells["ColLatitude"].Value);
                    long3 = Convert.ToDouble(dataGridView1.Rows[index[i, 2]].Cells["ColLongitude"].Value);

                    lat4 = Convert.ToDouble(dataGridView1.Rows[index[i, 3]].Cells["ColLatitude"].Value);
                    long4 = Convert.ToDouble(dataGridView1.Rows[index[i, 3]].Cells["ColLongitude"].Value);

                    Draw_Polygon_With_Four_Points(lat1, long1, lat2, long2, lat3, long3, lat4, long4, mycolor[i]);
                }
            }

            //Input conical
            string plot_positionAB, plot_positionCD;
            int segments;
            double r;
            Color Circle_Color;

            plot_positionAB = "Below";
            plot_positionCD = "Above";

            if (Co == 1)
            {
                //Draw conical surface
                r = 6000.0;
                segments = 8000;
                Circle_Color = Color.WhiteSmoke;
                Draw_Circle_With_Angle(r, segments, plot_positionAB, plot_positionCD, Circle_Color);
            }

            if(Hz == 1)
            {
                //Draw horizontal surface
                r = 4000.0;
                segments = 6000;
                Circle_Color = Color.DarkMagenta;
                Draw_Circle_With_Angle(r, segments, plot_positionAB, plot_positionCD, Circle_Color);
            }

            //Outer Horizontal

            if (OHz == 1)
            {
                //Draw Outer Horizontal
                r = 15000.0;
                segments = 8000;
                Circle_Color = Color.DeepPink;
                Draw_Full_Circle(r, segments, Circle_Color);
            }

            // Inner Approach
            if (IA == 1)
            {
                No_of_Polygon = 2;
                int[,] index = new int[,] {
                    { 58, 60, 61, 59 }, //Inner approach 28
                    { 62, 63, 65, 64}  //Inner approach 10
                
                };//One row contains 2 points of polygon in clockwise direction

                Color[] mycolor = new Color[] {
                    Color.Yellow,
                    Color.Yellow
                };

                for (int i = 0; i < No_of_Polygon; i++)
                {
                    //Approach surface-JGHI
                    lat1 = Convert.ToDouble(dataGridView1.Rows[index[i, 0]].Cells["ColLatitude"].Value);
                    long1 = Convert.ToDouble(dataGridView1.Rows[index[i, 0]].Cells["ColLongitude"].Value);

                    lat2 = Convert.ToDouble(dataGridView1.Rows[index[i, 1]].Cells["ColLatitude"].Value);
                    long2 = Convert.ToDouble(dataGridView1.Rows[index[i, 1]].Cells["ColLongitude"].Value);

                    lat3 = Convert.ToDouble(dataGridView1.Rows[index[i, 2]].Cells["ColLatitude"].Value);
                    long3 = Convert.ToDouble(dataGridView1.Rows[index[i, 2]].Cells["ColLongitude"].Value);

                    lat4 = Convert.ToDouble(dataGridView1.Rows[index[i, 3]].Cells["ColLatitude"].Value);
                    long4 = Convert.ToDouble(dataGridView1.Rows[index[i, 3]].Cells["ColLongitude"].Value);

                    Draw_Polygon_With_Four_Points(lat1, long1, lat2, long2, lat3, long3, lat4, long4, mycolor[i]);
                }
            }

            // Inner Transition surfaces with approach at lower end CD
            if (IT_CD == 1)
            {
                No_of_Polygon = 2;
                int vertex_in_one_Poly;
                int[,] index = new int[,] {
                    { 40, 38, 62, 64, 70 }, //Inner Transition
                    { 41, 39, 63, 65, 73 }  //Inner Transition
                
                };//One row contains 4 points of polygon in clockwise direction

                Color[] mycolor = new Color[] {
                    Color.DarkRed,
                    Color.DarkRed
                };

                vertex_in_one_Poly = 5;
                //int n_row = dataGridView6.RowCount - 1;
                int strt_row = 0, end_row = 0;
                int n_row_10 = dataGridView10.RowCount - 1;
                int n_row = n_row_10 / 2;
                for (int i = 0; i < No_of_Polygon; i++)
                {
                    strt_row = n_row * i;
                    end_row = strt_row + n_row;
                    //MessageBox.Show("srow = " + strt_row.ToString() + "endrow = " + end_row.ToString());

                    List<PointLatLng> points = new List<PointLatLng>();
                    for (int k = 0; k < vertex_in_one_Poly; k++)
                    {
                        lat1 = Convert.ToDouble(dataGridView1.Rows[index[i, k]].Cells["ColLatitude"].Value);
                        long1 = Convert.ToDouble(dataGridView1.Rows[index[i, k]].Cells["ColLongitude"].Value);
                        points.Add(new PointLatLng(lat1, long1));

                    }
                    for (int j = strt_row; j < end_row; j++) //for (int j = 0; j < vertex_in_one_Poly; j++)
                    {
                        //lat1 = Convert.ToDouble(dataGridView1.Rows[index[i, j]].Cells["ColLatitude"].Value);
                        //long1 = Convert.ToDouble(dataGridView1.Rows[index[i, j]].Cells["ColLongitude"].Value);
                        //points.Add(new PointLatLng(lat1, long1));

                        lat1 = Convert.ToDouble(dataGridView10.Rows[j].Cells[2].Value);
                        long1 = Convert.ToDouble(dataGridView10.Rows[j].Cells[3].Value);
                        points.Add(new PointLatLng(lat1, long1));
                    }
                    Draw_Polygon_With_Many_Points(points, mycolor[i]);
                }

            }

            // Inner Transition surfaces with approach at Higher end AB
            if (IT_AB == 1)
            {
                No_of_Polygon = 2;
                int vertex_in_one_Poly;
                int[,] index = new int[,] {
                    { 76, 60, 58, 34, 36 }, //Inner Transition
                    { 79, 61, 59, 35, 37 }  //Inner Transition
                
                };//One row contains 4 points of polygon in clockwise direction

                Color[] mycolor = new Color[] {
                    Color.DarkRed,
                    Color.DarkRed
                };

                vertex_in_one_Poly = 5;
                int strt_row = 0, end_row = 0;
                int n_row_11 = dataGridView11.RowCount - 1;
                int n_row = n_row_11 / 2;
                for (int i = 0; i < No_of_Polygon; i++)
                {
                    strt_row = n_row * i;
                    end_row = strt_row + n_row;
                    //MessageBox.Show("srow = " + strt_row.ToString() + "endrow = " + end_row.ToString());

                    List<PointLatLng> points = new List<PointLatLng>();
                    for (int j = 0; j < vertex_in_one_Poly; j++)
                    {
                        lat1 = Convert.ToDouble(dataGridView1.Rows[index[i, j]].Cells["ColLatitude"].Value);
                        long1 = Convert.ToDouble(dataGridView1.Rows[index[i, j]].Cells["ColLongitude"].Value);
                        points.Add(new PointLatLng(lat1, long1));
                    }
                    for (int j = strt_row; j < end_row; j++) //for (int j = 0; j < vertex_in_one_Poly; j++)
                    {
                        //lat1 = Convert.ToDouble(dataGridView1.Rows[index[i, j]].Cells["ColLatitude"].Value);
                        //long1 = Convert.ToDouble(dataGridView1.Rows[index[i, j]].Cells["ColLongitude"].Value);
                        //points.Add(new PointLatLng(lat1, long1));

                        lat1 = Convert.ToDouble(dataGridView11.Rows[j].Cells[2].Value);
                        long1 = Convert.ToDouble(dataGridView11.Rows[j].Cells[3].Value);
                        points.Add(new PointLatLng(lat1, long1));
                    }
                    Draw_Polygon_With_Many_Points(points, mycolor[i]);
                }
            }

            gMapControl1.Zoom += 0.1;
            gMapControl1.Invalidate();
            gMapControl1.Update();

        }


        private void BtnZoomToFit_Click(object sender, EventArgs e)
        {
            try
            {
                double lat1, long1, lat2, long2, lat_mid, long_mid;

                //take lat long input from text boxes
                lat1 = Convert.ToDouble(TxtLat1.Text);
                long1 = Convert.ToDouble(TxtLong1.Text);

                lat2 = Convert.ToDouble(TxtLat2.Text);
                long2 = Convert.ToDouble(TxtLong2.Text);

                lat_mid = (lat1 + lat2) / 2;
                long_mid = (long1 + long2) / 2;

                /*GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerAndCache;
                gMapControl1.DragButton = MouseButtons.Left;
                gMapControl1.MouseWheelZoomEnabled = true;
                gMapControl1.MapProvider = GMap.NET.MapProviders.GoogleSatelliteMapProvider.Instance;
                */
                RectLatLng Rect_COORD = new RectLatLng(Math.Max(lat1, lat2), Math.Max(long1, long2), Math.Abs(long1 - long2), Math.Abs(lat1 - lat2));
                gMapControl1.SetZoomToFitRect(Rect_COORD);
                gMapControl1.Position = new PointLatLng(lat_mid, long_mid); // centered on lat_mid, long_mid
            }
            catch
            {

            }
            
            
        }

        private void BtnZoomToFit2_Click(object sender, EventArgs e)
        {
            double lat1, long1, lat2, long2, lat_mid, long_mid; ;

            //take lat long input from text boxes
            lat1 = Convert.ToDouble(dataGridView1.Rows[4].Cells["ColLatitude"].Value);
            long1 = Convert.ToDouble(dataGridView1.Rows[4].Cells["ColLongitude"].Value);

            lat2 = Convert.ToDouble(dataGridView1.Rows[5].Cells["ColLatitude"].Value);
            long2 = Convert.ToDouble(dataGridView1.Rows[5].Cells["ColLongitude"].Value);

            lat_mid = (lat1 + lat2) / 2;
            long_mid = (long1 + long2) / 2;
            RectLatLng Rect_COORD = new RectLatLng(Math.Max(lat1, lat2), Math.Max(long1, long2), Math.Abs(long1 - long2), Math.Abs(lat1 - lat2));
            gMapControl2.SetZoomToFitRect(Rect_COORD);
            gMapControl2.Position = new PointLatLng(lat_mid, long_mid); // centered on lat_mid, long_mid

        }


        private void ChkBoxHorizontal_CheckedChanged(object sender, EventArgs e)
        {
            Check_if_all_checkboxes_are_Checked();
            if (all_surfacechkbox_checked == true) BtnSelectAll.Enabled = false; else BtnSelectAll.Enabled = true;
            if (Plot_Map_Clicked == true)
            {
                BtnCreateMap_Click(sender, e);
            }
            else
            {
                Clear_All_Surfaces();
                Draw_Checked_Surfaces();
            }
        }

        public void Clear_All_Surfaces()
        {
            int n_count;
            //clear map
            n_count = gMapControl1.Overlays.Count;
            if (n_count > 0)
            {
                for (int i = 1; i <=n_count; i++)
                {
                    gMapControl1.Overlays.RemoveAt(0);
                    gMapControl1.Update();
                    gMapControl1.Refresh();
                }
            }
        }

        public void Check_if_all_checkboxes_are_Checked()
        {
            if (ChkBoxHorizontal.Checked == true && ChkBoxConical.Checked == true && ChkBoxApproach.Checked == true &&
               ChkBoxTransition.Checked == true && ChkBoxTakeoffclimb.Checked == true && ChkBoxBalkedlanding.Checked == true &&
               ChkBoxInnerApproach.Checked == true && ChkBoxInnerTrans.Checked == true && ChkBoxOuterHorizontal.Checked==true)
            {
                all_surfacechkbox_checked = true;
            }
            else
            {
                all_surfacechkbox_checked = false;
            }
        }
        public void Draw_Checked_Surfaces()
        {
            int Hz, Co, Ap, Tr, ToC, Bl, IA, IT, OHz, IT_1;

            if (ChkBoxHorizontal.Checked == true) { Hz = 1; }
            else { Hz = 0; }
            if (ChkBoxConical.Checked == true) { Co = 1; }
            else { Co = 0; }
            if (ChkBoxApproach.Checked == true) { Ap = 1; }
            else { Ap = 0; }
            if (ChkBoxTransition.Checked == true) { Tr = 1; }
            else { Tr = 0; }
            if (ChkBoxTakeoffclimb.Checked == true) { ToC = 1; }
            else { ToC = 0; }
            if (ChkBoxBalkedlanding.Checked == true) { Bl = 1; }
            else { Bl = 0; }
            if (ChkBoxInnerApproach.Checked == true) { IA = 1; }
            else { IA = 0; }
            if (ChkBoxInnerTrans.Checked == true) { IT = 1; }
            else { IT = 0; }
            if (ChkBoxOuterHorizontal.Checked == true) { OHz = 1; }
            else { OHz = 0; }
            if (ChkBoxInnerTrans_1.Checked == true) { IT_1 = 1; }
            else { IT_1 = 0; }

            Draw_Selective_Obstalce_Surfaces(Hz, Co, Ap, Tr, ToC, Bl, IA, IT, OHz, IT_1);

        }

        private void ChkBoxConical_CheckedChanged(object sender, EventArgs e)
        {
            Check_if_all_checkboxes_are_Checked();
            if (all_surfacechkbox_checked == true) BtnSelectAll.Enabled = false; else BtnSelectAll.Enabled = true;
            if (Plot_Map_Clicked == true)
            {
                BtnCreateMap_Click(sender, e);
            }
            else
            {
                Clear_All_Surfaces();
                Draw_Checked_Surfaces();
            }
        }

        private void ChkBoxApproach_CheckedChanged(object sender, EventArgs e)
        {
            Check_if_all_checkboxes_are_Checked();
            if (all_surfacechkbox_checked == true) BtnSelectAll.Enabled = false; else BtnSelectAll.Enabled = true;
            if (Plot_Map_Clicked == true)
            {
                BtnCreateMap_Click(sender, e);
            }
            else
            {
                Clear_All_Surfaces();
                Draw_Checked_Surfaces();
            }
        }

        private void ChkBoxTransition_CheckedChanged(object sender, EventArgs e)
        {
            Check_if_all_checkboxes_are_Checked();
            if (all_surfacechkbox_checked == true) BtnSelectAll.Enabled = false; else BtnSelectAll.Enabled = true;
            if (Plot_Map_Clicked == true)
            {
                BtnCreateMap_Click(sender, e);
            }
            else
            {
                Clear_All_Surfaces();
                Draw_Checked_Surfaces();
            }
        }

        private void ChkBoxTakeoffclimb_CheckedChanged(object sender, EventArgs e)
        {
            Check_if_all_checkboxes_are_Checked();
            if (all_surfacechkbox_checked == true) BtnSelectAll.Enabled = false; else BtnSelectAll.Enabled = true;
            if (Plot_Map_Clicked == true)
            {
                BtnCreateMap_Click(sender, e);
            }
            else
            {
                Clear_All_Surfaces();
                Draw_Checked_Surfaces();
            }
        }

        private void ChkBoxBalkedlanding_CheckedChanged(object sender, EventArgs e)
        {
            Check_if_all_checkboxes_are_Checked();
            if (all_surfacechkbox_checked == true) BtnSelectAll.Enabled = false; else BtnSelectAll.Enabled = true;
            if (Plot_Map_Clicked == true)
            {
                BtnCreateMap_Click(sender, e);
            }
            else
            {
                Clear_All_Surfaces();
                Draw_Checked_Surfaces();
            }
        }

        private void BtnSelectAll_Click(object sender, EventArgs e)
        {
            ChkBoxHorizontal.Checked = true;
            ChkBoxApproach.Checked = true;
            ChkBoxConical.Checked = true;
            ChkBoxTransition.Checked = true;
            ChkBoxBalkedlanding.Checked = true;
            ChkBoxTakeoffclimb.Checked = true;
            ChkBoxInnerApproach.Checked = true;
            ChkBoxInnerTrans.Checked = true;
            ChkBoxOuterHorizontal.Checked = true;
            ChkBoxInnerTrans_1.Checked = true;
            all_surfacechkbox_checked = true;
            
            BtnSelectAll.Enabled = false;
        }

        private void ChkBoxInnerApproach_CheckedChanged(object sender, EventArgs e)
        {
            Check_if_all_checkboxes_are_Checked();
            if (all_surfacechkbox_checked == true) BtnSelectAll.Enabled = false; else BtnSelectAll.Enabled = true;
            if (Plot_Map_Clicked == true)
            {
                BtnCreateMap_Click(sender, e);
            }
            else
            {
                Clear_All_Surfaces();
                Draw_Checked_Surfaces();
            }
        }

        private void BtnDeselectAll_Click(object sender, EventArgs e)
        {
            ChkBoxHorizontal.Checked = false;
            ChkBoxApproach.Checked = false;
            ChkBoxConical.Checked = false;
            ChkBoxTransition.Checked = false;
            ChkBoxBalkedlanding.Checked = false;
            ChkBoxTakeoffclimb.Checked = false;
            ChkBoxInnerApproach.Checked = false;
            ChkBoxInnerTrans.Checked = false;
            ChkBoxOuterHorizontal.Checked = false;
            ChkBoxInnerTrans_1.Checked = false;
            BtnSelectAll.Enabled = true;
        }

        private void ChkBoxInnerTrans_CheckedChanged(object sender, EventArgs e)
        {
            Check_if_all_checkboxes_are_Checked();
            if (all_surfacechkbox_checked == true) BtnSelectAll.Enabled = false; else BtnSelectAll.Enabled = true;
            if (Plot_Map_Clicked == true)
            {
                BtnCreateMap_Click(sender, e);
            }
            else
            {
                Clear_All_Surfaces();
                Draw_Checked_Surfaces();
            }
        }

        private void ChkBoxOuterHorizontal_CheckedChanged(object sender, EventArgs e)
        {
            Check_if_all_checkboxes_are_Checked();
            if (all_surfacechkbox_checked == true) BtnSelectAll.Enabled = false; else BtnSelectAll.Enabled = true;
            if (Plot_Map_Clicked == true)
            {
                BtnCreateMap_Click(sender, e);
            }
            else
            {
                Clear_All_Surfaces();
                Draw_Checked_Surfaces();
            }
        }

        public void Calculate_Inner_Transition_Surface_CD_Inner_ApproachEnd_with_different_RL()
        {
            //For Inner transition equation i.e. slope and intercepts 
            double slope1, intercept1;
            double Slope_IT, Len_of_InnerEdge_Ap, Height_Hz;
            double slope_IA, Length_IA, Width_IA;

            double RL_TH_CD, RL_IHS;
            RL_TH_CD = Convert.ToDouble(Txt_RL_CD_Th.Text);
            RL_IHS = Convert.ToDouble(TxtRL_IHS.Text);

            Slope_IT = Convert.ToDouble(dataGridView5.Rows[27].Cells[2].Value); //33.3;
            Len_of_InnerEdge_Ap = Convert.ToDouble(dataGridView5.Rows[12].Cells[2].Value); //280.0;
            Height_Hz = Convert.ToDouble(dataGridView5.Rows[4].Cells[2].Value); //45.0;

            slope_IA = Convert.ToDouble(dataGridView5.Rows[10].Cells[2].Value); //2
            Length_IA = Convert.ToDouble(dataGridView5.Rows[9].Cells[2].Value); //900
            Width_IA = Convert.ToDouble(dataGridView5.Rows[7].Cells[2].Value); //120


            //finding index for distance vs RL table
            double m, c, m2, c2;
            //int[] bl_idx = new int[] { 33 };
            int DGV1_index1, DGV1_index2;
            DGV1_index1 = 14;
            DGV1_index2 = 15;
            int Sm_idx;
            m2 = Convert.ToDouble(dataGridView2.Rows[4].Cells[1].Value);//EF
            c2 = Convert.ToDouble(dataGridView2.Rows[4].Cells[2].Value);//EF
            m = Convert.ToDouble(dataGridView2.Rows[33].Cells[1].Value);//BL_EF
            c = Convert.ToDouble(dataGridView2.Rows[33].Cells[2].Value);//BL_EF
            Sm_idx = Index_of_dist_of_RWY_CL_by_Interpolation(m, c, m2, c2, DGV1_index1, DGV1_index2);
            double last_RL = RL_of_RWY_CL_by_Interpolation(m, c, m2, c2, DGV1_index1, DGV1_index2);
            double last_dist = Dist_of_RWY_CL_by_Interpolation(m, c, m2, c2, DGV1_index1, DGV1_index2);

            //MessageBox.Show("IT_CD\nSm_idx = " + Sm_idx.ToString() + "\nlast rl = " + last_RL.ToString() + 
               // "\nlast dist = " + last_dist.ToString());

            //double e1 = slope_IA / 100.0 * Length_IA;//2/100*900=18m elevation
            //double r1 = ( (RL_IHS + Height_Hz) - (RL_TH_CD + e1)) * 100.0 / Slope_IT;//((105+45)-(104+18))/33.3% = 81.08
            //double r2 = (RL_IHS + Height_Hz) / Slope_IT * 100.0;//45/33.3% = 135.135m

            int[,] C_indx = new int[,] { { 64, 62, 38 }, { 65, 63, 39 } };//center point index for circle
            int[] Line_indx = new int[] { 46, 45, 33 };//for DGV2 intercept and slopes
            //double[] radii = new double[] { r1, r2, r2 };

            double a, b, x1, y1, x2, y2;
            string[,] IT_Point_Name = new string[,] { { "IT_A", "IT_B", "IT_C" }, { "IT_F", "IT_E", "IT_D" } };
            double[] latlong1 = new double[2];
            double[] IT_COORD_X = new double[6];
            double[] IT_COORD_Y = new double[6];

            int DGV2_row_inx, DGV1_row_inx, i, intrcpt;
            //int[] mulfactor = new int[2] { 1, -1 };//1 for IT_ABC and -1 for IT_DEF
            double X_coord, Y_coord;
            intrcpt = 0;
            DGV1_row_inx = 70; //for IT_AB and end at index 52 for IT_BC
            int coord = 0;

            int a1, a2;
            slope1 = Convert.ToDouble(dataGridView2.Rows[4].Cells["ColSlope"].Value);//EF
            double tempslope;
            tempslope = Math.Atan(slope1);
            if (tempslope >= 0)
            {
                a1 = -1;
                a2 = 1;
            }
            else
            {
                a1 = 1;
                a2 = -1;
            }
            int[] mulfactor = new int[2] { a1, a2 };//1 for T_AD and -1 for T_BC


            slope1 = Convert.ToDouble(dataGridView2.Rows[4].Cells["ColSlope"].Value);//EF
            intercept1 = Convert.ToDouble(dataGridView2.Rows[4].Cells["ColIntercept"].Value);//EF
            dataGridView10.Rows.Clear();
            /*for (int k = 0; k <= (Sm_idx+1) * 2; k++)
            {
                dataGridView10.Rows.Add();
            }*/
            for (int j = 0; j <= 1; j++)
            {
                for (int k = 0; k <= (Sm_idx + 1); k++)
                {
                    double RL_CL_RWY;
                    if ( k == (Sm_idx+1))
                    {
                        RL_CL_RWY = last_RL;
                    }
                    else
                    {
                        RL_CL_RWY = Convert.ToDouble(dataGridView6.Rows[k].Cells[2].Value);
                    }
                    
                    double distanceOffset = 0.5 * Width_IA + (RL_IHS + Height_Hz - RL_CL_RWY) / Slope_IT * 100.0;//45/33.3% = 135.135m
                    
                    double intrc_parallel = Intercept_of_Parallel_line(slope1, intercept1, distanceOffset, mulfactor[j]);

                    //slope1 = Convert.ToDouble(dataGridView2.Rows[Line_indx[k]].Cells["ColSlope"].Value);
                    //intercept1 = Convert.ToDouble(dataGridView2.Rows[Line_indx[k]].Cells["ColIntercept"].Value);

                    double m_kl = Convert.ToDouble(dataGridView2.Rows[9].Cells["ColSlope"].Value);//KL
                    double c_kl = Convert.ToDouble(dataGridView2.Rows[9].Cells["ColIntercept"].Value);//KL

                    if (k == (Sm_idx + 1))
                    {
                        distanceOffset = last_dist;
                    }
                    else
                    {
                        distanceOffset = Convert.ToDouble(dataGridView6.Rows[k].Cells[1].Value);//chainage
                    }
                    
                    //distanceOffset = distanceOffset1[k];
                    double intrc_perp = Intercept_of_Parallel_line(m_kl, c_kl, distanceOffset, -1);

                    X_coord = Find_Intersection_X(slope1, intrc_parallel, m_kl, intrc_perp);
                    Y_coord = Find_Intersection_Y(slope1, intrc_parallel, m_kl, intrc_perp);

                    latlong1 = Convert_UTM_To_Latitude_Longitude(X_coord, Y_coord);

                    dataGridView10.Rows.Add();
                    dataGridView10.Rows[intrcpt].Cells[0].Value = distanceOffset.ToString();
                    dataGridView10.Rows[intrcpt].Cells[1].Value = "Inner_Transition_CD_" + j.ToString();
                    dataGridView10.Rows[intrcpt].Cells[2].Value = latlong1[0].ToString();
                    dataGridView10.Rows[intrcpt].Cells[3].Value = latlong1[1].ToString();
                    dataGridView10.Rows[intrcpt].Cells[4].Value = X_coord.ToString();
                    dataGridView10.Rows[intrcpt].Cells[5].Value = Y_coord.ToString();

                    intrcpt++;
                }

            }

            double dist;
            /*int[,] L_indx = new int[,] { { 64, 70, 71, 40 }, { 65, 73, 74, 41 } };//
            string[,] IT_Line_Name = new string[,] { { "IA_V-IT_A", "IT_AB", "IT_B-BL_H" }, { "IA_U-IT_F", "IT_FE", "IT_E-BL_G" } };
            //distance between two points
            DGV2_row_inx = 57;
            for (int j = 0; j <= 1; j++)
            {
                for (int k = 0; k <= 2; k++)
                {
                    x1 = Convert.ToDouble(dataGridView1.Rows[L_indx[j, k]].Cells["ColEasting"].Value);
                    y1 = Convert.ToDouble(dataGridView1.Rows[L_indx[j, k]].Cells["ColNorthing"].Value);

                    x2 = Convert.ToDouble(dataGridView1.Rows[L_indx[j, k + 1]].Cells["ColEasting"].Value);
                    y2 = Convert.ToDouble(dataGridView1.Rows[L_indx[j, k + 1]].Cells["ColNorthing"].Value);

                    slope1 = Find_Slope_Of_Equation(x1, y1, x2, y2);
                    intercept1 = Find_Intercept_Of_Equation(slope1, x1, y1);

                    dist = Find_Distance_bet_two_pointXY(x1, y1, x2, y2);
                    dataGridView2.Rows[DGV2_row_inx].Cells[0].Value = IT_Line_Name[j, k].ToString();
                    dataGridView2.Rows[DGV2_row_inx].Cells[1].Value = slope1.ToString();
                    dataGridView2.Rows[DGV2_row_inx].Cells[2].Value = intercept1.ToString();
                    dataGridView2.Rows[DGV2_row_inx].Cells[3].Value = dist.ToString();
                    DGV2_row_inx++;

                }
            }*/

            
            string[,] LineName = new string[,] { { "IA_V-IT_A", "IT_AB", "IT_C-BL_H" }, { "IA_U-IT_F", "IT_EF", "IT_D-BL_G" } };
            int[,] ix = new int[,] { {64, 0, Sm_idx+1 }, { 65, Sm_idx+2, (Sm_idx + 1)*2 + 1 } };//DGV10
            int[,] iy = new int[,] { { 70, 70, 40 }, { 73, 73, 41 } };//DGV1

            DGV2_row_inx = 57;
            for(int k =0; k <= 1; k++)
            {
                x1 = Convert.ToDouble(dataGridView1.Rows[ix[k, 0]].Cells[4].Value);//IA_V
                y1 = Convert.ToDouble(dataGridView1.Rows[ix[k, 0]].Cells[5].Value);//IA_V
                x2 = Convert.ToDouble(dataGridView1.Rows[iy[k, 0]].Cells[4].Value);//IT_A
                y2 = Convert.ToDouble(dataGridView1.Rows[iy[k, 0]].Cells[5].Value);//IT_A

                slope1 = Find_Slope_Of_Equation(x1, y1, x2, y2);
                intercept1 = Find_Intercept_Of_Equation(slope1, x1, y1);
                dist = Find_Distance_bet_two_pointXY(x1, y1, x2, y2);

                dataGridView2.Rows[DGV2_row_inx].Cells[0].Value = LineName[k,0];
                dataGridView2.Rows[DGV2_row_inx].Cells[1].Value = slope1.ToString();
                dataGridView2.Rows[DGV2_row_inx].Cells[2].Value = intercept1.ToString();
                dataGridView2.Rows[DGV2_row_inx].Cells[3].Value = dist.ToString();
                DGV2_row_inx++;

                //DGV2_row_inx = 58;
                x1 = Convert.ToDouble(dataGridView10.Rows[ix[k, 1]].Cells[4].Value);//IA_V
                y1 = Convert.ToDouble(dataGridView10.Rows[ix[k, 1]].Cells[5].Value);//IA_V
                x2 = Convert.ToDouble(dataGridView1.Rows[iy[k, 1]].Cells[4].Value);//IT_A
                y2 = Convert.ToDouble(dataGridView1.Rows[iy[k, 1]].Cells[5].Value);//IT_A

                slope1 = Find_Slope_Of_Equation(x1, y1, x2, y2);
                intercept1 = Find_Intercept_Of_Equation(slope1, x1, y1);
                dist = Find_Distance_bet_two_pointXY(x1, y1, x2, y2);

                dataGridView2.Rows[DGV2_row_inx].Cells[0].Value = LineName[k,1];
                dataGridView2.Rows[DGV2_row_inx].Cells[1].Value = slope1.ToString();
                dataGridView2.Rows[DGV2_row_inx].Cells[2].Value = intercept1.ToString();
                dataGridView2.Rows[DGV2_row_inx].Cells[3].Value = dist.ToString();
                DGV2_row_inx++;

                //DGV2_row_inx = 59;
                x1 = Convert.ToDouble(dataGridView10.Rows[ix[k, 2]].Cells[4].Value);//IT_A
                y1 = Convert.ToDouble(dataGridView10.Rows[ix[k, 2]].Cells[5].Value);//It_A
                x2 = Convert.ToDouble(dataGridView1.Rows[iy[k, 2]].Cells[4].Value);//IT_C
                y2 = Convert.ToDouble(dataGridView1.Rows[iy[k, 2]].Cells[5].Value);//IT_C

                slope1 = Find_Slope_Of_Equation(x1, y1, x2, y2);
                intercept1 = Find_Intercept_Of_Equation(slope1, x1, y1);
                dist = Find_Distance_bet_two_pointXY(x1, y1, x2, y2);

                dataGridView2.Rows[DGV2_row_inx].Cells[0].Value = LineName[k,2];
                dataGridView2.Rows[DGV2_row_inx].Cells[1].Value = slope1.ToString();
                dataGridView2.Rows[DGV2_row_inx].Cells[2].Value = intercept1.ToString();
                dataGridView2.Rows[DGV2_row_inx].Cells[3].Value = dist.ToString();
                DGV2_row_inx++;
            }
            


        }

        public void Calculate_Inner_Transition_Surface_CD_Inner_ApproachEnd()
        {
            //For Inner transition equation i.e. slope and intercepts 
            double slope1, intercept1;
            double Slope_IT, Len_of_InnerEdge_Ap, Height_Hz;
            double slope_IA, Length_IA;

            double RL_TH_CD, RL_IHS;
            RL_TH_CD = Convert.ToDouble(Txt_RL_CD_Th.Text);
            RL_IHS = Convert.ToDouble(TxtRL_IHS.Text);

            Slope_IT = Convert.ToDouble(dataGridView5.Rows[27].Cells[2].Value); //33.3;
            Len_of_InnerEdge_Ap = Convert.ToDouble(dataGridView5.Rows[12].Cells[2].Value); //280.0;
            Height_Hz = Convert.ToDouble(dataGridView5.Rows[4].Cells[2].Value); //45.0;

            slope_IA = Convert.ToDouble(dataGridView5.Rows[10].Cells[2].Value); //2
            Length_IA = Convert.ToDouble(dataGridView5.Rows[9].Cells[2].Value); //900

            double e1 = slope_IA / 100.0 * Length_IA;//2/100*900=18m elevation
            double r1 = ((RL_IHS + Height_Hz) - (RL_TH_CD + e1)) * 100.0 / Slope_IT;//((105+45)-(104+18))/33.3% = 81.08
            double r2 = Height_Hz / Slope_IT * 100.0;//45/33.3% = 135.135m

            int[,] C_indx = new int[,] { { 64, 62, 38 }, { 65, 63, 39 } };//center point index for circle
            int[] Line_indx = new int[] { 46, 45, 33 };//for DGV2 intercept and slopes
            double[] radii = new double[] { r1, r2, r2 };

            double a, b, x1, y1, x2, y2;
            string[,] IT_Point_Name = new string[,] { { "IT_A", "IT_B", "IT_C" }, { "IT_F", "IT_E", "IT_D" } };
            double[] latlong1 = new double[2];
            double[] IT_COORD_X = new double[6];
            double[] IT_COORD_Y = new double[6];

            int DGV2_row_inx, DGV1_row_inx, i, intrcpt;
            /*int a1, a2;
            slope1 = Convert.ToDouble(dataGridView2.Rows[4].Cells["ColSlope"].Value);//EF
            double tempslope;
            tempslope = Math.Atan(slope1);
            if (tempslope >= 0)
            {
                a1 = -1;
                a2 = 1;
            }
            else
            {
                a1 = 1;
                a2 = -1;
            }*/
            //int[] mulfactor = new int[2] { a1, a2 };//1 for T_AD and -1 for T_BC
            int[] mulfactor = new int[2] { 1, -1 };//1 for IT_ABC and -1 for IT_DEF
            //int[] RW_Side = new int[1] { 4 };//EF

            intrcpt = 0;
            DGV1_row_inx = 70; //for IT_AB and end at index 52 for IT_BC
            int coord = 0;
            for (int j = 0; j <= 1; j++)
            {
                //slope1 = Convert.ToDouble(dataGridView2.Rows[RW_Side[0]].Cells["ColSlope"].Value);//EF
                //intercept1 = Convert.ToDouble(dataGridView2.Rows[RW_Side[0]].Cells["ColIntercept"].Value);//EF

                for (int k = 0; k <= 2; k++)
                {
                    //For IT_DE--->RWY 28 side
                    //distanceOffset = distanceOffset1[k];
                    //intercept_parallel[intrcpt] = Intercept_of_Parallel_line(slope1, intercept1, distanceOffset, mulfactor[j]);

                    slope1 = Convert.ToDouble(dataGridView2.Rows[Line_indx[k]].Cells["ColSlope"].Value);
                    intercept1 = Convert.ToDouble(dataGridView2.Rows[Line_indx[k]].Cells["ColIntercept"].Value);

                    //intercept1 = intercept_parallel[2]; //intercept of OP i.e. parallel line
                    double radius = radii[k];
                    a = Convert.ToDouble(dataGridView1.Rows[C_indx[j,k]].Cells["ColEasting"].Value);
                    b = Convert.ToDouble(dataGridView1.Rows[C_indx[j, k]].Cells["ColNorthing"].Value);


                    double Quad_x = Find_Quadratic_X(slope1, intercept1, a, b, radius, mulfactor[j]);
                    double Quad_y = slope1 * Quad_x + intercept1;//O_Y

                    //COORD R
                    //IT_COORD_X[coord] = Quad_x;
                    //IT_COORD_Y[coord] = Quad_y;

                    latlong1 = Convert_UTM_To_Latitude_Longitude(Quad_x, Quad_y);
                    dataGridView1.Rows[DGV1_row_inx].Cells["ColPoint"].Value = IT_Point_Name[j,k].ToString();
                    dataGridView1.Rows[DGV1_row_inx].Cells["ColLatitude"].Value = latlong1[0].ToString();
                    dataGridView1.Rows[DGV1_row_inx].Cells["ColLongitude"].Value = latlong1[1].ToString();
                    dataGridView1.Rows[DGV1_row_inx].Cells["ColEasting"].Value = Quad_x.ToString();
                    dataGridView1.Rows[DGV1_row_inx].Cells["ColNorthing"].Value = Quad_y.ToString();
                    //distance between two points
                    //dist = Find_Distance_bet_two_pointXY(Quad_x_plus, Quad_y_plus, Quad_x_minus, Quad_y_minus);
                    //dataGridView2.Rows[7].Cells[3].Value = dist.ToString();

                    DGV1_row_inx++;
                    coord++;
                }
            }

            int[,] L_indx = new int[,] { { 64, 70, 71, 40 }, { 65, 73, 74, 41 } };//
            string[,] IT_Line_Name = new string[,] { { "IA_V-IT_A", "IT_AB", "IT_B-BL_H" }, { "IA_U-IT_F", "IT_FE", "IT_E-BL_G" } };
            //distance between two points
            DGV2_row_inx = 57;
            for(int j = 0; j <= 1; j++)
            {
                for (int k = 0; k <= 2; k++)
                {
                    x1 = Convert.ToDouble(dataGridView1.Rows[L_indx[j, k]].Cells["ColEasting"].Value);
                    y1 = Convert.ToDouble(dataGridView1.Rows[L_indx[j, k]].Cells["ColNorthing"].Value);

                    x2 = Convert.ToDouble(dataGridView1.Rows[L_indx[j, k+1]].Cells["ColEasting"].Value);
                    y2 = Convert.ToDouble(dataGridView1.Rows[L_indx[j, k+1]].Cells["ColNorthing"].Value);

                    slope1 = Find_Slope_Of_Equation(x1, y1, x2, y2);
                    intercept1 = Find_Intercept_Of_Equation(slope1, x1, y1);

                    double dist = Find_Distance_bet_two_pointXY(x1, y1, x2, y2);
                    dataGridView2.Rows[DGV2_row_inx].Cells[0].Value = IT_Line_Name[j,k].ToString();
                    dataGridView2.Rows[DGV2_row_inx].Cells[1].Value = slope1.ToString();
                    dataGridView2.Rows[DGV2_row_inx].Cells[2].Value = intercept1.ToString();
                    dataGridView2.Rows[DGV2_row_inx].Cells[3].Value = dist.ToString();
                    DGV2_row_inx++;

                }
            }
            
        }

        public void Calculate_Inner_Transition_Surface_AB_Inner_ApproachEnd()
        {
            //For Inner transition equation i.e. slope and intercepts 
            double slope1, intercept1;
            double Slope_IT, Len_of_InnerEdge_Ap, Height_Hz;
            double slope_IA, Length_IA;

            Slope_IT = Convert.ToDouble(dataGridView5.Rows[27].Cells[2].Value); //33.3;
            Len_of_InnerEdge_Ap = Convert.ToDouble(dataGridView5.Rows[12].Cells[2].Value); //280.0;
            Height_Hz = Convert.ToDouble(dataGridView5.Rows[4].Cells[2].Value); //45.0;

            slope_IA = Convert.ToDouble(dataGridView5.Rows[10].Cells[2].Value); //2
            Length_IA = Convert.ToDouble(dataGridView5.Rows[9].Cells[2].Value); //900

            double RL_TH_AB, RL_IHS;
            RL_TH_AB = Convert.ToDouble(TxtRL_AB_Th.Text);
            RL_IHS = Convert.ToDouble(TxtRL_IHS.Text);

            double e1 = slope_IA / 100.0 * Length_IA;//18m elevation
            //double r1 = (Height_Hz - e1) * 100.0 / Slope_IT;//(45-18)/33.3% = 81.08
            double r1 = ((RL_IHS + Height_Hz) - (RL_TH_AB + e1)) * 100.0 / Slope_IT;//((105+45)-(104+18))/33.3% = 81.08
            double r2 = Height_Hz / Slope_IT * 100.0;//45/33.3% = 135.135m

            int[,] C_indx = new int[,] { { 60, 58, 34 }, { 61, 59, 35 } };//center point index for circle
            int[] Line_indx = new int[] { 44, 43, 31 };//for DGV2 intercept and slopes
            double[] radii = new double[] { r1, r2, r2 };

            double a, b, x1, y1, x2, y2;
            string[,] IT_Point_Name = new string[,] { { "IT_G", "IT_H", "IT_I" }, { "IT_J", "IT_K", "IT_L" } };
            double[] latlong1 = new double[2];
            double[] IT_COORD_X = new double[6];
            double[] IT_COORD_Y = new double[6];

            int DGV2_row_inx, DGV1_row_inx;
            int[] mulfactor = new int[2] { 1, -1 };//1 for IT_ABC and -1 for IT_DEF

            DGV1_row_inx = 76; //for IT_AB and end at index 81 for IT_BC
            int coord = 0;
            for (int j = 0; j <= 1; j++)
            {
                for (int k = 0; k <= 2; k++)
                {
                    slope1 = Convert.ToDouble(dataGridView2.Rows[Line_indx[k]].Cells["ColSlope"].Value);
                    intercept1 = Convert.ToDouble(dataGridView2.Rows[Line_indx[k]].Cells["ColIntercept"].Value);

                    double radius = radii[k];
                    a = Convert.ToDouble(dataGridView1.Rows[C_indx[j, k]].Cells["ColEasting"].Value);
                    b = Convert.ToDouble(dataGridView1.Rows[C_indx[j, k]].Cells["ColNorthing"].Value);

                    double Quad_x = Find_Quadratic_X(slope1, intercept1, a, b, radius, mulfactor[j]);
                    double Quad_y = slope1 * Quad_x + intercept1;

                    latlong1 = Convert_UTM_To_Latitude_Longitude(Quad_x, Quad_y);
                    dataGridView1.Rows[DGV1_row_inx].Cells["ColPoint"].Value = IT_Point_Name[j, k].ToString();
                    dataGridView1.Rows[DGV1_row_inx].Cells["ColLatitude"].Value = latlong1[0].ToString();
                    dataGridView1.Rows[DGV1_row_inx].Cells["ColLongitude"].Value = latlong1[1].ToString();
                    dataGridView1.Rows[DGV1_row_inx].Cells["ColEasting"].Value = Quad_x.ToString();
                    dataGridView1.Rows[DGV1_row_inx].Cells["ColNorthing"].Value = Quad_y.ToString();

                    DGV1_row_inx++;
                    coord++;
                }
            }

            int[,] L_indx = new int[,] { { 60, 76, 77, 36 }, { 61, 79, 80, 37 } };//to find slope of lines of inner trans.
            string[,] IT_Line_Name = new string[,] { { "IA_O-IT_G", "IT_GH", "IT_H-BL_D" }, { "IA_P-IT_J", "IT_JK", "IT_K-BL_C" } };
            //distance between two points
            DGV2_row_inx = 63;
            for (int j = 0; j <= 1; j++)
            {
                for (int k = 0; k <= 2; k++)
                {
                    x1 = Convert.ToDouble(dataGridView1.Rows[L_indx[j, k]].Cells["ColEasting"].Value);
                    y1 = Convert.ToDouble(dataGridView1.Rows[L_indx[j, k]].Cells["ColNorthing"].Value);

                    x2 = Convert.ToDouble(dataGridView1.Rows[L_indx[j, k + 1]].Cells["ColEasting"].Value);
                    y2 = Convert.ToDouble(dataGridView1.Rows[L_indx[j, k + 1]].Cells["ColNorthing"].Value);

                    slope1 = Find_Slope_Of_Equation(x1, y1, x2, y2);
                    intercept1 = Find_Intercept_Of_Equation(slope1, x1, y1);

                    double dist = Find_Distance_bet_two_pointXY(x1, y1, x2, y2);
                    dataGridView2.Rows[DGV2_row_inx].Cells[0].Value = IT_Line_Name[j, k].ToString();
                    dataGridView2.Rows[DGV2_row_inx].Cells[1].Value = slope1.ToString();
                    dataGridView2.Rows[DGV2_row_inx].Cells[2].Value = intercept1.ToString();
                    dataGridView2.Rows[DGV2_row_inx].Cells[3].Value = dist.ToString();
                    DGV2_row_inx++;

                }
            }

        }

        public void Calculate_Inner_Transition_Surface_AB_Inner_ApproachEnd_with_Different_RL()
        {
            //For Inner transition equation i.e. slope and intercepts 
            double slope1, intercept1;
            double Slope_IT, Len_of_InnerEdge_Ap, Height_Hz;
            double slope_IA, Length_IA;

            double RL_TH_AB, RL_IHS;
            RL_TH_AB = Convert.ToDouble(TxtRL_AB_Th.Text);
            RL_IHS = Convert.ToDouble(TxtRL_IHS.Text);

            Slope_IT = Convert.ToDouble(dataGridView5.Rows[27].Cells[2].Value); //33.3;
            Len_of_InnerEdge_Ap = Convert.ToDouble(dataGridView5.Rows[12].Cells[2].Value); //280.0;
            Height_Hz = Convert.ToDouble(dataGridView5.Rows[4].Cells[2].Value); //45.0;

            slope_IA = Convert.ToDouble(dataGridView5.Rows[10].Cells[2].Value); //2
            Length_IA = Convert.ToDouble(dataGridView5.Rows[9].Cells[2].Value); //900
            double Width_IA = Convert.ToDouble(dataGridView5.Rows[7].Cells[2].Value); //120

            //finding index for distance vs RL table
            double m, c, m2, c2;
            //int[] bl_idx = new int[] { 33 };
            int DGV1_index1, DGV1_index2;
            DGV1_index1 = 14;
            DGV1_index2 = 15;
            int Sm_idx;
            m2 = Convert.ToDouble(dataGridView2.Rows[4].Cells[1].Value);//EF
            c2 = Convert.ToDouble(dataGridView2.Rows[4].Cells[2].Value);//EF
            m = Convert.ToDouble(dataGridView2.Rows[31].Cells[1].Value);//BL_AB
            c = Convert.ToDouble(dataGridView2.Rows[31].Cells[2].Value);//BL_AB
            Sm_idx = Index_of_dist_of_RWY_CL_by_Interpolation(m, c, m2, c2, DGV1_index1, DGV1_index2);
            double last_RL = RL_of_RWY_CL_by_Interpolation(m, c, m2, c2, DGV1_index1, DGV1_index2);
            double last_dist = Dist_of_RWY_CL_by_Interpolation(m, c, m2, c2, DGV1_index1, DGV1_index2);

            /*MessageBox.Show("Sm_idx = " + Sm_idx.ToString() + "\nlast rl = " + last_RL.ToString() + 
                "\nlast dist = " + last_dist.ToString());*/


            //double e1 = slope_IA / 100.0 * Length_IA;//18m elevation
            //double r1 = (Height_Hz - e1) * 100.0 / Slope_IT;//(45-18)/33.3% = 81.08
            //double r2 = Height_Hz / Slope_IT * 100.0;//45/33.3% = 135.135m

            int[,] C_indx = new int[,] { { 60, 58, 34 }, { 61, 59, 35 } };//center point index for circle
            int[] Line_indx = new int[] { 44, 43, 31 };//for DGV2 intercept and slopes
            //double[] radii = new double[] { r1, r2, r2 };

            double a, b, x1, y1, x2, y2;
            string[,] IT_Point_Name = new string[,] { { "IT_G", "IT_H", "IT_I" }, { "IT_J", "IT_K", "IT_L" } };
            double[] latlong1 = new double[2];
            double[] IT_COORD_X = new double[6];
            double[] IT_COORD_Y = new double[6];

            int DGV2_row_inx, DGV1_row_inx;
            //int[] mulfactor = new int[2] { 1, -1 };//1 for IT_ABC and -1 for IT_DEF

            double X_coord, Y_coord;
            int intrcpt = 0;
            DGV1_row_inx = 76; //for IT_ and end at index  for IT
            int coord = 0;

            int a1, a2;
            slope1 = Convert.ToDouble(dataGridView2.Rows[4].Cells["ColSlope"].Value);//EF
            double tempslope;
            tempslope = Math.Atan(slope1);
            if (tempslope >= 0)
            {
                a1 = -1;
                a2 = 1;
            }
            else
            {
                a1 = 1;
                a2 = -1;
            }
            int[] mulfactor = new int[2] { a1, a2 };//1 for T_AD and -1 for T_BC


            slope1 = Convert.ToDouble(dataGridView2.Rows[4].Cells["ColSlope"].Value);//EF
            intercept1 = Convert.ToDouble(dataGridView2.Rows[4].Cells["ColIntercept"].Value);//EF
            dataGridView11.Rows.Clear();

            //DGV1_row_inx = 76; //for IT_AB and end at index 81 for IT_BC
            //coord = 0;
            int lst_row = dataGridView6.RowCount - 1;
            for (int j = 0; j <= 1; j++)
            {
                for (int k = Sm_idx; k < lst_row; k++)
                {
                    double RL_CL_RWY;
                    if (k == (Sm_idx))
                    {
                        RL_CL_RWY = last_RL;
                    }
                    else
                    {
                        RL_CL_RWY = Convert.ToDouble(dataGridView6.Rows[k].Cells[2].Value);
                    }

                    double distanceOffset = 0.5 * Width_IA + (RL_IHS + Height_Hz - RL_CL_RWY) / Slope_IT * 100.0;//45/33.3% = 135.135m
                    double intrc_parallel = Intercept_of_Parallel_line(slope1, intercept1, distanceOffset, mulfactor[j]);

                    double m_kl = Convert.ToDouble(dataGridView2.Rows[9].Cells["ColSlope"].Value);//KL
                    double c_kl = Convert.ToDouble(dataGridView2.Rows[9].Cells["ColIntercept"].Value);//KL

                    if (k == (Sm_idx))
                    {
                        distanceOffset = last_dist;
                    }
                    else
                    {
                        distanceOffset = Convert.ToDouble(dataGridView6.Rows[k].Cells[1].Value);//chainage
                    }

                    //double radius = radii[k];

                    double intrc_perp = Intercept_of_Parallel_line(m_kl, c_kl, distanceOffset, -1);

                    X_coord = Find_Intersection_X(slope1, intrc_parallel, m_kl, intrc_perp);
                    Y_coord = Find_Intersection_Y(slope1, intrc_parallel, m_kl, intrc_perp);

                    latlong1 = Convert_UTM_To_Latitude_Longitude(X_coord, Y_coord);

                    dataGridView11.Rows.Add();
                    dataGridView11.Rows[intrcpt].Cells[0].Value = distanceOffset.ToString();
                    dataGridView11.Rows[intrcpt].Cells[1].Value = "Inner_Transition_AB_" + j.ToString();
                    dataGridView11.Rows[intrcpt].Cells[2].Value = latlong1[0].ToString();
                    dataGridView11.Rows[intrcpt].Cells[3].Value = latlong1[1].ToString();
                    dataGridView11.Rows[intrcpt].Cells[4].Value = X_coord.ToString();
                    dataGridView11.Rows[intrcpt].Cells[5].Value = Y_coord.ToString();

                    intrcpt++;

                }
            }

            int n_pts_one_side = lst_row - (Sm_idx + 1) + 1;//
            //MessageBox.Show("lstrow = " + lst_row.ToString() + "\nsmidx = " + Sm_idx.ToString() + "\nlstidx = " + lst_idx.ToString());

            string[,] LineName = new string[,] { { "IA_O-IT_G", "IT_GH", "IT_I-BL_D" }, { "IA_P-IT_J", "IT_JK", "IT_L-BL_C" } };
            int[,] ix = new int[,] { { 60, n_pts_one_side - 1, 0 }, { 61, (n_pts_one_side - 1)*2+1, n_pts_one_side } };//DGV11
            int[,] iy = new int[,] { { 76, 76, 36 }, { 79, 79, 37 } };//DGV1

            double dist;
            DGV2_row_inx = 63;
            for (int k = 0; k <= 1; k++)
            {
                x1 = Convert.ToDouble(dataGridView1.Rows[ix[k, 0]].Cells[4].Value);//IA_V
                y1 = Convert.ToDouble(dataGridView1.Rows[ix[k, 0]].Cells[5].Value);//IA_V
                x2 = Convert.ToDouble(dataGridView1.Rows[iy[k, 0]].Cells[4].Value);//IT_A
                y2 = Convert.ToDouble(dataGridView1.Rows[iy[k, 0]].Cells[5].Value);//IT_A

                slope1 = Find_Slope_Of_Equation(x1, y1, x2, y2);
                intercept1 = Find_Intercept_Of_Equation(slope1, x1, y1);
                dist = Find_Distance_bet_two_pointXY(x1, y1, x2, y2);

                dataGridView2.Rows[DGV2_row_inx].Cells[0].Value = LineName[k, 0];
                dataGridView2.Rows[DGV2_row_inx].Cells[1].Value = slope1.ToString();
                dataGridView2.Rows[DGV2_row_inx].Cells[2].Value = intercept1.ToString();
                dataGridView2.Rows[DGV2_row_inx].Cells[3].Value = dist.ToString();
                DGV2_row_inx++;

                //DGV2_row_inx = 64;
                x1 = Convert.ToDouble(dataGridView11.Rows[ix[k, 1]].Cells[4].Value);//IA_V
                y1 = Convert.ToDouble(dataGridView11.Rows[ix[k, 1]].Cells[5].Value);//IA_V
                x2 = Convert.ToDouble(dataGridView1.Rows[iy[k, 1]].Cells[4].Value);//IT_A
                y2 = Convert.ToDouble(dataGridView1.Rows[iy[k, 1]].Cells[5].Value);//IT_A


                /*MessageBox.Show("idx11 = " + ix[k, 1].ToString() +
                    "\nx1_H = " + x1.ToString() +
                    "\ny1_H = " + y1.ToString() +
                    "\nx2_G = " + x2.ToString() +
                    "\ny2_G = " + y2.ToString()
                    );*/


                slope1 = Find_Slope_Of_Equation(x1, y1, x2, y2);
                intercept1 = Find_Intercept_Of_Equation(slope1, x1, y1);
                dist = Find_Distance_bet_two_pointXY(x1, y1, x2, y2);

                dataGridView2.Rows[DGV2_row_inx].Cells[0].Value = LineName[k, 1];
                dataGridView2.Rows[DGV2_row_inx].Cells[1].Value = slope1.ToString();
                dataGridView2.Rows[DGV2_row_inx].Cells[2].Value = intercept1.ToString();
                dataGridView2.Rows[DGV2_row_inx].Cells[3].Value = dist.ToString();
                DGV2_row_inx++;

                //DGV2_row_inx = 65;
                x1 = Convert.ToDouble(dataGridView11.Rows[ix[k, 2]].Cells[4].Value);//IT_A
                y1 = Convert.ToDouble(dataGridView11.Rows[ix[k, 2]].Cells[5].Value);//It_A
                x2 = Convert.ToDouble(dataGridView1.Rows[iy[k, 2]].Cells[4].Value);//IT_C
                y2 = Convert.ToDouble(dataGridView1.Rows[iy[k, 2]].Cells[5].Value);//IT_C

                slope1 = Find_Slope_Of_Equation(x1, y1, x2, y2);
                intercept1 = Find_Intercept_Of_Equation(slope1, x1, y1);
                dist = Find_Distance_bet_two_pointXY(x1, y1, x2, y2);

                dataGridView2.Rows[DGV2_row_inx].Cells[0].Value = LineName[k, 2];
                dataGridView2.Rows[DGV2_row_inx].Cells[1].Value = slope1.ToString();
                dataGridView2.Rows[DGV2_row_inx].Cells[2].Value = intercept1.ToString();
                dataGridView2.Rows[DGV2_row_inx].Cells[3].Value = dist.ToString();
                DGV2_row_inx++;
            }
        }

        private void ChkBoxInnerTrans_1_CheckedChanged(object sender, EventArgs e)
        {
            Check_if_all_checkboxes_are_Checked();
            if (all_surfacechkbox_checked == true) BtnSelectAll.Enabled = false; else BtnSelectAll.Enabled = true;
            if (Plot_Map_Clicked == true)
            {
                BtnCreateMap_Click(sender, e);
            }
            else
            {
                Clear_All_Surfaces();
                Draw_Checked_Surfaces();
            }
        }

        private void BtnDMS_Click(object sender, EventArgs e)
        {
            FrmDMS fdms = new FrmDMS();
            fdms.Show();
        }

        private void gMapControl1_MouseClick(object sender, MouseEventArgs e)
        {
            if(ChkExtractCOORD.Checked == true)
            {
                if (e.Button == MouseButtons.Left)
                {
                    var point1 = gMapControl1.FromLocalToLatLng(e.X, e.Y);
                    double lat1 = point1.Lat;
                    double long1 = point1.Lng;

                    TxtLat2.Text = lat1.ToString();
                    TxtLong2.Text = long1.ToString();
                }
            }
            
        }

        public void Calculate_Corner_Transitional_Surface()
        {
            //For approach equation i.e. slope and intercepts
            //Equation of line parallel to AB i.e. IJ and GH
            double slope1, intercept1, distanceOffset;
            double Slope_Trans, Len_of_InnerEdge_Ap, Height_Hz;
            double slope_Ap_First_Sec;
            Slope_Trans = Convert.ToDouble(dataGridView5.Rows[25].Cells[2].Value); //14.3;
            Len_of_InnerEdge_Ap = Convert.ToDouble(dataGridView5.Rows[12].Cells[2].Value); //280.0;
            Height_Hz = Convert.ToDouble(dataGridView5.Rows[4].Cells[2].Value); //45.0;
            slope_Ap_First_Sec = Convert.ToDouble(dataGridView5.Rows[17].Cells[2].Value); //2;

            double RL_IHS, RL_TH_AB, RL_TH_CD, dAB, dCD;
            RL_IHS = Convert.ToDouble(TxtRL_IHS.Text);
            RL_TH_AB = Convert.ToDouble(TxtRL_AB_Th.Text);
            RL_TH_CD = Convert.ToDouble(Txt_RL_CD_Th.Text);
            dAB = (RL_IHS + Height_Hz - RL_TH_AB) * 100.0 / slope_Ap_First_Sec;
            dCD = (RL_IHS + Height_Hz - RL_TH_CD) * 100.0 / slope_Ap_First_Sec;

            double[] distanceOffset1 = new double[2] { dAB, dCD };//45/2%=2250
            //45/14.3% = 314.68
            double[] intercept_parallel = new double[10];
            double a, b, x1, y1, x2, y2;
            string[] Trans_Line_Name = new string[2] { "Trans_AB", "Trans_DC" };

            int DGV2_row_inx, DGV1_row_inx, i, intrcpt;
            int a1, a2;
            
            int[] mulfactor = new int[2] { -1, 1 };//1 for KL and -1 for JI
            int[] RW_Side = new int[2] { 5, 9}; //5=JI, 9 = KL in DGV2


            intrcpt = 0;
            DGV2_row_inx = 51; //for Trans_AB and end at index 40 for Trans_KJ
            for (int j = 0; j <= 1; j++)
            {
                slope1 = Convert.ToDouble(dataGridView2.Rows[RW_Side[j]].Cells["ColSlope"].Value);
                intercept1 = Convert.ToDouble(dataGridView2.Rows[RW_Side[j]].Cells["ColIntercept"].Value);
                
                for (int k = 0; k <= 0; k++)
                {
                    //For Trans_DE--->RWY 28 side
                    distanceOffset = distanceOffset1[j];
                    intercept_parallel[intrcpt] = Intercept_of_Parallel_line(slope1, intercept1, distanceOffset, mulfactor[j]);
                    dataGridView2.Rows[DGV2_row_inx].Cells["ColLine"].Value = Trans_Line_Name[intrcpt];
                    dataGridView2.Rows[DGV2_row_inx].Cells["ColSlope"].Value = slope1.ToString();
                    dataGridView2.Rows[DGV2_row_inx].Cells["ColIntercept"].Value = intercept_parallel[intrcpt].ToString();

                    DGV2_row_inx++; 
                    
                    intrcpt++;
                }
            }

            //Find intersection point T_A, T_D, T_B, T_C
            //Point of intersection of circle and line
            double Quad_x_plus, Quad_x_minus, Quad_y_plus, Quad_y_minus;
            double dist;
            double slope2, intercept2;
            double[] Trans_COORD_X = new double[12];
            double[] Trans_COORD_Y = new double[12];
            string[] Trans_Point_Name = new string[4] { "Trans_A", "Trans_B", "Trans_D", "Trans_C" };
            double[] latlong1 = new double[2];
            int[,] indx = new int[2, 2] { { 13, 14 }, { 15, 16 } };
            double[,] slopes = new double[2, 2];
            double[,] intercepts = new double[2, 2];

            x1 = Convert.ToDouble(dataGridView1.Rows[6].Cells[4].Value);//J
            y1 = Convert.ToDouble(dataGridView1.Rows[6].Cells[5].Value);//J
            x2 = Convert.ToDouble(dataGridView1.Rows[8].Cells[4].Value);//O
            y2 = Convert.ToDouble(dataGridView1.Rows[8].Cells[5].Value);//O
            slopes[0, 0] = Find_Slope_Of_Equation(x1, y1, x2, y2);
            intercepts[0, 0] = Find_Intercept_Of_Equation(slopes[0, 0], x1, y1);
            //MessageBox.Show("x1 = " + x1.ToString() + "\ny1 = " + (y1).ToString());
            //MessageBox.Show("x2 = " + x2.ToString() + "\ny2 = " + (y2).ToString());

            x1 = Convert.ToDouble(dataGridView1.Rows[7].Cells[4].Value);//I
            y1 = Convert.ToDouble(dataGridView1.Rows[7].Cells[5].Value);//I
            x2 = Convert.ToDouble(dataGridView1.Rows[9].Cells[4].Value);//P
            y2 = Convert.ToDouble(dataGridView1.Rows[9].Cells[5].Value);//P
            slopes[0, 1] = Find_Slope_Of_Equation(x1, y1, x2, y2);
            intercepts[0, 1] = Find_Intercept_Of_Equation(slopes[0, 1], x1, y1);

            x1 = Convert.ToDouble(dataGridView1.Rows[14].Cells[4].Value);//K
            y1 = Convert.ToDouble(dataGridView1.Rows[14].Cells[5].Value);//K
            x2 = Convert.ToDouble(dataGridView1.Rows[16].Cells[4].Value);//V
            y2 = Convert.ToDouble(dataGridView1.Rows[16].Cells[5].Value);//V
            slopes[1, 0] = Find_Slope_Of_Equation(x1, y1, x2, y2);
            intercepts[1, 0] = Find_Intercept_Of_Equation(slopes[1, 0], x1, y1);

            x1 = Convert.ToDouble(dataGridView1.Rows[15].Cells[4].Value);//L
            y1 = Convert.ToDouble(dataGridView1.Rows[15].Cells[5].Value);//L
            x2 = Convert.ToDouble(dataGridView1.Rows[17].Cells[4].Value);//U
            y2 = Convert.ToDouble(dataGridView1.Rows[17].Cells[5].Value);//U
            slopes[1, 1] = Find_Slope_Of_Equation(x1, y1, x2, y2);
            intercepts[1, 1] = Find_Intercept_Of_Equation(slopes[1, 1], x1, y1);

            DGV1_row_inx = 66;//for Trans_A and end at index 69 for Trans_C
            //PtIndex = 0;
            i = 0;
            intrcpt = 0;

            for (int j = 0; j <= 1; j++)
            {
                intercept1 = intercept_parallel[j]; //intercept of Trans_AB i.e. parallel line
                slope1 = Convert.ToDouble(dataGridView2.Rows[RW_Side[j]].Cells["ColSlope"].Value);//JI and KL

                for (int k = 0; k <= 1; k++)
                {
                    slope2 = Convert.ToDouble(dataGridView2.Rows[indx[j, k]].Cells["ColSlope"].Value);//slope
                    intercept2 = Convert.ToDouble(dataGridView2.Rows[indx[j, k]].Cells["ColIntercept"].Value);//intercept                                                                                                //For Point Trans_A and Trans_B


                    //MessageBox.Show("Slope diff = " + (slope2 - slopes[j, k]).ToString());
                    //MessageBox.Show("Incpt diff = " + (intercept2 - intercepts[j, k]).ToString());

                    slope2 = slopes[j, k];
                    intercept2 = intercepts[j, k];

                    a = Find_Intersection_X(slope1, intercept1, slope2, intercept2);//X-COORD of intersection of EF and IJ
                    b = Find_Intersection_Y(slope1, intercept1, slope2, intercept2);//Y-COORD of intersection of EF and IJ

                    //COORD Trans_A
                    Trans_COORD_X[i] = a;
                    Trans_COORD_Y[i] = b;

                    latlong1 = Convert_UTM_To_Latitude_Longitude(a, b);
                    dataGridView1.Rows[DGV1_row_inx].Cells["ColPoint"].Value = Trans_Point_Name[i].ToString();
                    dataGridView1.Rows[DGV1_row_inx].Cells["ColLatitude"].Value = latlong1[0].ToString();
                    dataGridView1.Rows[DGV1_row_inx].Cells["ColLongitude"].Value = latlong1[1].ToString();
                    dataGridView1.Rows[DGV1_row_inx].Cells["ColEasting"].Value = a.ToString();
                    dataGridView1.Rows[DGV1_row_inx].Cells["ColNorthing"].Value = b.ToString();

                    DGV1_row_inx++;
                    i++;
                    intrcpt++;
                }

            }
            //distance between two points
            DGV2_row_inx = 51;
            for (int k = 0; k <= 3; k += 2)
            {
                Quad_x_plus = Trans_COORD_X[k];
                Quad_y_plus = Trans_COORD_Y[k];

                Quad_x_minus = Trans_COORD_X[k + 1];
                Quad_y_minus = Trans_COORD_Y[k + 1];

                dist = Find_Distance_bet_two_pointXY(Quad_x_plus, Quad_y_plus, Quad_x_minus, Quad_y_minus);
                dataGridView2.Rows[DGV2_row_inx].Cells[3].Value = dist.ToString();
                DGV2_row_inx++;

            }
            //----------------------------------------------------------------------------------------------

            DGV2_row_inx = 53;
            int[] ix = new int[] { 42, 44, 43, 45 };
            int[] iy = new int[] { 66, 67, 68, 69 };
            string[] LineName = new string[] { "Trans_EA", "Trans_FB", "Trans_HD", "Trans_GC" };
            for (int k = 0; k<=3; k++)
            {
                x1 = Convert.ToDouble(dataGridView1.Rows[ix[k]].Cells[4].Value);//E
                y1 = Convert.ToDouble(dataGridView1.Rows[ix[k]].Cells[5].Value);//E
                x2 = Convert.ToDouble(dataGridView1.Rows[iy[k]].Cells[4].Value);//A
                y2 = Convert.ToDouble(dataGridView1.Rows[iy[k]].Cells[5].Value);//A

                slope1 = Find_Slope_Of_Equation(x1, y1, x2, y2);
                intercept1 = Find_Intercept_Of_Equation(slope1, x1, y1);
                dist = Find_Distance_bet_two_pointXY(x1, y1, x2, y2);

                dataGridView2.Rows[DGV2_row_inx].Cells[0].Value = LineName[k];
                dataGridView2.Rows[DGV2_row_inx].Cells[1].Value = slope1.ToString();
                dataGridView2.Rows[DGV2_row_inx].Cells[2].Value = intercept1.ToString();
                dataGridView2.Rows[DGV2_row_inx].Cells[3].Value = dist.ToString();
                DGV2_row_inx++;
            }
            
        }

        public void Calculate_Transitional_Surface()
        {
            //For approach equation i.e. slope and intercepts
            //Equation of line parallel to AB i.e. IJ and GH
            double slope1, intercept1, distanceOffset;
            double Slope_Trans, Len_of_InnerEdge_Ap, Height_Hz;

            Slope_Trans = Convert.ToDouble(dataGridView5.Rows[25].Cells[2].Value); //14.3;
            Len_of_InnerEdge_Ap = Convert.ToDouble(dataGridView5.Rows[12].Cells[2].Value); //280.0;
            Height_Hz = Convert.ToDouble(dataGridView5.Rows[4].Cells[2].Value); //45.0;

            double RL_TH_AB, RL_TH_CD, RL_IHS;
            RL_IHS = Convert.ToDouble(TxtRL_IHS.Text);
            RL_TH_AB = Convert.ToDouble(TxtRL_AB_Th.Text);
            RL_TH_CD = Convert.ToDouble(Txt_RL_CD_Th.Text);

            double dAB, dCD;
            dAB = 0.5 * Len_of_InnerEdge_Ap + (RL_IHS + Height_Hz - RL_TH_AB) * 100.0 / Slope_Trans;
            dCD = 0.5 * Len_of_InnerEdge_Ap + (RL_IHS + Height_Hz - RL_TH_CD) * 100.0 / Slope_Trans;

            double[] distanceOffset1 = new double[] { dAB, dCD };//314.68 = 45/14.3%
            //45/14.3% = 314.68
            double[] intercept_parallel = new double[10];
            double a, b, x1, y1, x2, y2;
            string[] Trans_Line_Name = new string[2] { "Trans_EH_ABside", "Trans_FG_ABside" };

            int DGV2_row_inx, DGV1_row_inx, i, intrcpt;
            int a1, a2;
            slope1 = Convert.ToDouble(dataGridView2.Rows[4].Cells["ColSlope"].Value);//EF
            double tempslope;
            tempslope = Math.Atan(slope1);
            if (tempslope >= 0)
            {
                a1 = -1;
                a2 = 1;
            }
            else
            {
                a1 = 1;
                a2 = -1;
            }
            int[] mulfactor = new int[2] { a1, a2 };//1 for T_AD and -1 for T_BC
            int[] RW_Side = new int[1] { 4 };


            intrcpt = 0;
            DGV2_row_inx = 39; //for Trans_AB and end at index 40 for Trans_KJ
            for (int j = 0; j <= 1; j++)
            {
                slope1 = Convert.ToDouble(dataGridView2.Rows[RW_Side[0]].Cells["ColSlope"].Value);//EF
                intercept1 = Convert.ToDouble(dataGridView2.Rows[RW_Side[0]].Cells["ColIntercept"].Value);//EF

                for (int k = 0; k <= 0; k++)
                {
                    //For Trans_DE--->RWY 28 side
                    distanceOffset = distanceOffset1[k];
                    intercept_parallel[intrcpt] = Intercept_of_Parallel_line(slope1, intercept1, distanceOffset, mulfactor[j]);
                    dataGridView2.Rows[DGV2_row_inx].Cells["ColLine"].Value = Trans_Line_Name[intrcpt];
                    dataGridView2.Rows[DGV2_row_inx].Cells["ColSlope"].Value = slope1.ToString();
                    dataGridView2.Rows[DGV2_row_inx].Cells["ColIntercept"].Value = intercept_parallel[intrcpt].ToString();

                    DGV2_row_inx++;
                    intrcpt++;

                }
            }

            //Find intersection point T_E, T_H, T_F, T_G
            //Point of intersection of circle and line
            double Quad_x_plus, Quad_x_minus, Quad_y_plus, Quad_y_minus;
            double dist;
            double slope2, intercept2;
            double[] Trans_COORD_X = new double[12];
            double[] Trans_COORD_Y = new double[12];
            string[] Trans_Point_Name = new string[4] { "Trans_E", "Trans_H", "Trans_F", "Trans_G" };
            double[] latlong1 = new double[2];
            int[,] indx = new int[2, 2] { { 5, 9 }, { 5, 9 } };

            DGV1_row_inx = 42;//for Trans_A and end at index 45 for Trans_J
            //PtIndex = 0;
            i = 0;
            intrcpt = 0;

            for (int j = 0; j <= 1; j++)
            {
                intercept1 = intercept_parallel[j]; //intercept of Trans_AB i.e. parallel line
                slope1 = Convert.ToDouble(dataGridView2.Rows[4].Cells["ColSlope"].Value);//EF

                for (int k = 0; k <= 1; k++)
                {
                    slope2 = Convert.ToDouble(dataGridView2.Rows[indx[j, k]].Cells["ColSlope"].Value);//slope
                    intercept2 = Convert.ToDouble(dataGridView2.Rows[indx[j, k]].Cells["ColIntercept"].Value);//intercept                                                                                                //For Point Trans_A and Trans_B

                    a = Find_Intersection_X(slope1, intercept1, slope2, intercept2);//X-COORD of intersection of EF and IJ
                    b = Find_Intersection_Y(slope1, intercept1, slope2, intercept2);//Y-COORD of intersection of EF and IJ

                    //COORD Trans_A
                    Trans_COORD_X[i] = a;
                    Trans_COORD_Y[i] = b;


                    latlong1 = Convert_UTM_To_Latitude_Longitude(a, b);
                    dataGridView1.Rows[DGV1_row_inx].Cells["ColPoint"].Value = Trans_Point_Name[i].ToString();
                    dataGridView1.Rows[DGV1_row_inx].Cells["ColLatitude"].Value = latlong1[0].ToString();
                    dataGridView1.Rows[DGV1_row_inx].Cells["ColLongitude"].Value = latlong1[1].ToString();
                    dataGridView1.Rows[DGV1_row_inx].Cells["ColEasting"].Value = a.ToString();
                    dataGridView1.Rows[DGV1_row_inx].Cells["ColNorthing"].Value = b.ToString();

                    DGV1_row_inx++;
                    i++;
                    intrcpt++;
                }

            }

            //distance between two points
            DGV2_row_inx = 39;
            for (int k = 0; k <= 3; k += 2)
            {
                Quad_x_plus = Trans_COORD_X[k];
                Quad_y_plus = Trans_COORD_Y[k];

                Quad_x_minus = Trans_COORD_X[k + 1];
                Quad_y_minus = Trans_COORD_Y[k + 1];

                dist = Find_Distance_bet_two_pointXY(Quad_x_plus, Quad_y_plus, Quad_x_minus, Quad_y_minus);
                dataGridView2.Rows[DGV2_row_inx].Cells[3].Value = dist.ToString();
                DGV2_row_inx++;

            }
            //----------------------------------------------------------------------------------------------
            //JK

            x1 = Convert.ToDouble(dataGridView1.Rows[6].Cells[4].Value);//J
            y1 = Convert.ToDouble(dataGridView1.Rows[6].Cells[5].Value);//J
            x2 = Convert.ToDouble(dataGridView1.Rows[14].Cells[4].Value);//K
            y2 = Convert.ToDouble(dataGridView1.Rows[14].Cells[5].Value);//K

            slope1 = Find_Slope_Of_Equation(x1, y1, x2, y2);
            intercept1 = Find_Intercept_Of_Equation(slope1, x1, y1);
            dist = Find_Distance_bet_two_pointXY(x1, y1, x2, y2);

            dataGridView2.Rows[41].Cells[0].Value = "Trans_JK";
            dataGridView2.Rows[41].Cells[1].Value = slope1.ToString();
            dataGridView2.Rows[41].Cells[2].Value = intercept1.ToString();
            dataGridView2.Rows[41].Cells[3].Value = dist.ToString();

            //IL
            x1 = Convert.ToDouble(dataGridView1.Rows[7].Cells[4].Value);//J
            y1 = Convert.ToDouble(dataGridView1.Rows[7].Cells[5].Value);//J
            x2 = Convert.ToDouble(dataGridView1.Rows[15].Cells[4].Value);//K
            y2 = Convert.ToDouble(dataGridView1.Rows[15].Cells[5].Value);//K

            slope1 = Find_Slope_Of_Equation(x1, y1, x2, y2);
            intercept1 = Find_Intercept_Of_Equation(slope1, x1, y1);
            dist = Find_Distance_bet_two_pointXY(x1, y1, x2, y2);

            dataGridView2.Rows[42].Cells[0].Value = "Trans_LI";
            dataGridView2.Rows[42].Cells[1].Value = slope1.ToString();
            dataGridView2.Rows[42].Cells[2].Value = intercept1.ToString();
            dataGridView2.Rows[42].Cells[3].Value = dist.ToString();

        }



        private void TxtCM_TextChanged(object sender, EventArgs e)
        {
            try
            {
                groupBox16.Text = "Projection COORD Parameter of " + TxtCM.Text;

                TxtA.Text = "";
                TxtOneByF.Text = "";
                TxtK0.Text = "";
                TxtM0.Text = "";
                TxtPhi_DD.Text = "";
                TxtFalseEasting_X.Text = "";

                string[] ReadingText = new string[20];
                string line;
                line = "";
                string RWYCoordFilenName = @".\InputFolder\" + TxtAirportCode.Text + "\\" + TxtCM.Text + ".txt";
                //Pass the file path and file name to the StreamReader constructor
                StreamReader sr = new StreamReader(RWYCoordFilenName);
                //Read the first line of text
                line = sr.ReadLine();
                ReadingText[0] = line;
                //Continue to read until you reach end of file
                int i = 1;
                while (line != null)
                {
                    //Read the next line
                    line = sr.ReadLine();
                    ReadingText[i] = line;
                    i++;
                }
                //close the file
                sr.Close();

                string[] splittedtext = ReadingText[1].Split('\t');
                TxtA.Text = splittedtext[1];

                splittedtext = ReadingText[2].Split('\t');
                TxtOneByF.Text = splittedtext[1];

                splittedtext = ReadingText[3].Split('\t');
                TxtK0.Text = splittedtext[1];

                splittedtext = ReadingText[4].Split('\t');
                TxtM0.Text = splittedtext[1];

                splittedtext = ReadingText[5].Split('\t');
                TxtPhi_DD.Text = splittedtext[1];

                splittedtext = ReadingText[6].Split('\t');
                TxtFalseEasting_X.Text = splittedtext[1];

            }
            catch
            {

            }
        }

        public void Calculate_Take_of_Climb_Surface()
        {
            //For approach equation i.e. slope and intercepts
            //Equation of line parallel to AB i.e. IJ and GH
            double slope1, intercept1, distanceOffset, tempdist;
            double Len_of_InnerEdge_Toc, Dist_From_RWYEnd_Toc, Divergence_Toc, FinalWidth_Toc, Length_Toc, Slope_Toc;
            
            Len_of_InnerEdge_Toc = Convert.ToDouble(dataGridView5.Rows[34].Cells[2].Value); //180.0;
            Dist_From_RWYEnd_Toc = Convert.ToDouble(dataGridView5.Rows[35].Cells[2].Value); //60.0;
            Divergence_Toc = Convert.ToDouble(dataGridView5.Rows[36].Cells[2].Value); //12.5;
            FinalWidth_Toc = Convert.ToDouble(dataGridView5.Rows[37].Cells[2].Value); //1800.0;
            Length_Toc = Convert.ToDouble(dataGridView5.Rows[38].Cells[2].Value); //15000.0;

            double[] CLWY_after_strip = new double[2];
            CLWY_after_strip[0] = Convert.ToDouble(Txt_AB_Clearway.Text);
            CLWY_after_strip[1] = Convert.ToDouble(Txt_CD_Clearway.Text);

            tempdist = (FinalWidth_Toc - Len_of_InnerEdge_Toc) * 0.5 * 100.0 / Divergence_Toc;//6480.0 
            double[] distanceOffset1 = new double[3] { Dist_From_RWYEnd_Toc, Dist_From_RWYEnd_Toc + tempdist, Dist_From_RWYEnd_Toc + Length_Toc  };
            //6480 = ((1800-180)/2)/12.5%   and 8520 = 15000 - 6480
            double[] intercept_parallel = new double[10];
            double a, b, x1, y1, x2, y2;
            string[] ToC_Line_Name = new string[6] {"TOC_AB", "TOC_FC", "TOC_ED", "TOC_GH", "TOC_LI", "TOC_KJ"};
            
            int DGV2_row_inx, DGV1_row_inx, i, intrcpt;
            int[] mulfactor = new int[2] { -1, 1 };
            int[] RW_Side= new int[2] { 0, 2 };


            intrcpt = 0;
            DGV2_row_inx = 17; //for TOC_AB and end at index 22 for TOC_KJ
            for (int j =0; j<=1; j++)
            {
                slope1 = Convert.ToDouble(dataGridView2.Rows[RW_Side[j]].Cells["ColSlope"].Value);//AB
                intercept1 = Convert.ToDouble(dataGridView2.Rows[RW_Side[j]].Cells["ColIntercept"].Value);//AB

                for (int k =0; k<=2; k++)
                {
                    //For TOC_DE--->RWY 28 side
                    distanceOffset = distanceOffset1[k] + CLWY_after_strip[j];
                    intercept_parallel[intrcpt] = Intercept_of_Parallel_line(slope1, intercept1, distanceOffset, mulfactor[j]);
                    dataGridView2.Rows[DGV2_row_inx].Cells["ColLine"].Value = ToC_Line_Name[intrcpt];
                    dataGridView2.Rows[DGV2_row_inx].Cells["ColSlope"].Value = slope1.ToString();
                    dataGridView2.Rows[DGV2_row_inx].Cells["ColIntercept"].Value = intercept_parallel[intrcpt].ToString();

                    DGV2_row_inx++;
                    intrcpt++;
                }
            }

            //--------------------------------------------------------------------------------------------
            //Point of intersection of circle and line
            double Quad_x_plus, Quad_x_minus, Quad_y_plus, Quad_y_minus;
            //double B, A, C, a, b;
            double r1 = Len_of_InnerEdge_Toc * 0.5; //half distance of starting line of ToC
            double dist;
            double slope2, intercept2, radius;
            double[] ToC_COORD_X = new double[12];
            double[] ToC_COORD_Y = new double[12];
            string[] ToC_Point_Name = new string[12] { "TOC_A", "TOC_B", "TOC_F", "TOC_C", "TOC_E", "TOC_D", "TOC_G", "TOC_H", "TOC_L", "TOC_I", "TOC_K", "TOC_J"};
            double[] latlong1 = new double[2];
            double[] radii = new double[3] { r1, FinalWidth_Toc*0.5, FinalWidth_Toc*0.5 };//Total final width = 1800 m
            

            DGV1_row_inx = 22;//for TOC_A and end at index 33 for TOC_J
            DGV2_row_inx = 17; //for TOC_AB and end at index 22 for TOC_KJ
            //PtIndex = 0;
            i = 0;
            intrcpt = 0;
            for (int j = 0; j <= 2; j += 2)
            {
                slope2 = Convert.ToDouble(dataGridView2.Rows[4].Cells["ColSlope"].Value);//slope of EF
                intercept2 = Convert.ToDouble(dataGridView2.Rows[4].Cells["ColIntercept"].Value);//intercept of EF
                                                                                                 //For Point TOC_A and TOC_B
                slope1 = Convert.ToDouble(dataGridView2.Rows[j].Cells["ColSlope"].Value);//slope of AB equals to slope of TOC_AB

                for (int k = 0; k <= 2; k++)
                {
                    intercept1 = intercept_parallel[intrcpt]; //intercept of TOC_AB i.e. parallel line
                    radius = radii[k]; //distance between TOC_A and E'
                    a = Find_Intersection_X(slope1, intercept1, slope2, intercept2);//X-COORD of intersection of EF and IJ
                    b = Find_Intersection_Y(slope1, intercept1, slope2, intercept2);//Y-COORD of intersection of EF and IJ

                    Quad_x_plus = Find_Quadratic_X_Plus(slope1, intercept1, a, b, radius);
                    Quad_x_minus = Find_Quadratic_X_minus(slope1, intercept1, a, b, radius);
                    Quad_y_plus = slope1 * Quad_x_plus + intercept1;//TOC_A
                    Quad_y_minus = slope1 * Quad_x_minus + intercept1;//TOC_B

                    //COORD TOC_A
                    ToC_COORD_X[i] = Quad_x_plus;
                    ToC_COORD_Y[i] = Quad_y_plus;
                    //COORD TOC_B
                    ToC_COORD_X[i + 1] = Quad_x_minus;
                    ToC_COORD_Y[i + 1] = Quad_y_minus;

                    latlong1 = Convert_UTM_To_Latitude_Longitude(Quad_x_plus, Quad_y_plus);
                    dataGridView1.Rows[DGV1_row_inx].Cells["ColPoint"].Value = ToC_Point_Name[i].ToString();
                    dataGridView1.Rows[DGV1_row_inx].Cells["ColLatitude"].Value = latlong1[0].ToString();
                    dataGridView1.Rows[DGV1_row_inx].Cells["ColLongitude"].Value = latlong1[1].ToString();
                    dataGridView1.Rows[DGV1_row_inx].Cells["ColEasting"].Value = Quad_x_plus.ToString();
                    dataGridView1.Rows[DGV1_row_inx].Cells["ColNorthing"].Value = Quad_y_plus.ToString();

                    latlong1 = Convert_UTM_To_Latitude_Longitude(Quad_x_minus, Quad_y_minus);
                    dataGridView1.Rows[DGV1_row_inx + 1].Cells["ColPoint"].Value = ToC_Point_Name[i+1].ToString();
                    dataGridView1.Rows[DGV1_row_inx + 1].Cells["ColLatitude"].Value = latlong1[0].ToString();
                    dataGridView1.Rows[DGV1_row_inx + 1].Cells["ColLongitude"].Value = latlong1[1].ToString();
                    dataGridView1.Rows[DGV1_row_inx + 1].Cells["ColEasting"].Value = Quad_x_minus.ToString();
                    dataGridView1.Rows[DGV1_row_inx + 1].Cells["ColNorthing"].Value = Quad_y_minus.ToString();

                    DGV1_row_inx += 2;

                    //distance between two points
                    dist = Find_Distance_bet_two_pointXY(Quad_x_plus, Quad_y_plus, Quad_x_minus, Quad_y_minus);
                    dataGridView2.Rows[DGV2_row_inx].Cells[3].Value = dist.ToString();
                    
                    DGV2_row_inx++;
                    i += 2;
                    //PtIndex += 2;
                    intrcpt++;
                }

            }
            //----------------------------------------------------------------------------------------------

            //----------------------------------------------------------------------------------------------
            //Find slope and intercept of inclined JG, IH, NK and ML
            double[] ToC_Diverg_Slope = new double[8];
            double[] ToC_Diverg_Intercept = new double[8];
            int[,] PIdx = new int[4,3] { { 0, 2, 4 }, { 1, 3, 5 }, { 6, 8, 10 }, { 7, 9, 11 } };
            string[] InclLine = new string[8] { "TOC_AF", "TOC_FE", "TOC_BC", "TOC_CD", "TOC_GL", "TOC_LK", "TOC_HI", "TOC_IJ" };
            double x11, y11, x22, y22;

            intrcpt = 0;
            DGV2_row_inx = 23; //datagridview2 from index 23 to 30
            for (int kk = 0; kk < 4; kk++)
            {
                for (int j = 0; j <= 0; j++)
                {
                    x11 = ToC_COORD_X[PIdx[kk, j]];//PIdx
                    y11 = ToC_COORD_Y[PIdx[kk, j]];
                    x22 = ToC_COORD_X[PIdx[kk, j + 1]];//PIdx + 1
                    y22 = ToC_COORD_Y[PIdx[kk, j + 1]];
                    ToC_Diverg_Slope[intrcpt] = Find_Slope_Of_Equation(x11, y11, x22, y22);//intrcpt
                    ToC_Diverg_Intercept[intrcpt] = Find_Intercept_Of_Equation(ToC_Diverg_Slope[intrcpt], x11, y11);//intrcpt
                    dataGridView2.Rows[DGV2_row_inx].Cells["ColLine"].Value = InclLine[intrcpt];
                    dataGridView2.Rows[DGV2_row_inx].Cells["ColSlope"].Value = ToC_Diverg_Slope[intrcpt].ToString();
                    dataGridView2.Rows[DGV2_row_inx].Cells["ColIntercept"].Value = ToC_Diverg_Intercept[intrcpt].ToString();
                    dataGridView2.Rows[DGV2_row_inx].Cells["ColDistance"].Value = Find_Distance_bet_two_pointXY(x11, y11, x22, y22).ToString();

                    x11 = ToC_COORD_X[PIdx[kk, j + 1]];//PIdx
                    y11 = ToC_COORD_Y[PIdx[kk, j + 1]];
                    //MessageBox.Show("PIDX = " + PIdx[kk, j + 1].ToString());
                    x22 = ToC_COORD_X[PIdx[kk, j + 2]];//PIdx + 1
                    y22 = ToC_COORD_Y[PIdx[kk, j + 2]];
                    ToC_Diverg_Slope[intrcpt + 1] = Find_Slope_Of_Equation(x11, y11, x22, y22);//intrcpt
                    ToC_Diverg_Intercept[intrcpt + 1] = Find_Intercept_Of_Equation(ToC_Diverg_Slope[intrcpt + 1], x11, y11);//intrcpt
                    dataGridView2.Rows[DGV2_row_inx + 1].Cells["ColLine"].Value = InclLine[intrcpt + 1];
                    dataGridView2.Rows[DGV2_row_inx + 1].Cells["ColSlope"].Value = ToC_Diverg_Slope[intrcpt + 1].ToString();
                    dataGridView2.Rows[DGV2_row_inx + 1].Cells["ColIntercept"].Value = ToC_Diverg_Intercept[intrcpt + 1].ToString();
                    dataGridView2.Rows[DGV2_row_inx + 1].Cells["ColDistance"].Value = Find_Distance_bet_two_pointXY(x11, y11, x22, y22).ToString();

                    intrcpt += 2;
                    DGV2_row_inx += 2;
                }
            }
            //----------------------------------------------------------------------------------------------

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAbout fabout = new FrmAbout();
            fabout.Show();
        }

        private void calculateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Function_Calculate();
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Function_Add_DB();
        }

        private void modifyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Function_Modify_DB();
        }

        private void displayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Function_Display_DB();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Function_Delete_DB();
        }

        private void exportToPdfToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Function_Export_To_PDF();
        }

        private void openRecentFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Function_Open_Recent_Folder();
        }

        private void addToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            TxtID.Enabled = false;
            TxtID.Text = "";

            modifyToolStripMenuItem.Enabled = false;
            displayToolStripMenuItem.Enabled = false;
            deleteToolStripMenuItem.Enabled = false;
            addToolStripMenuItem.Enabled = true;

            /*BtnModify.Enabled = false;
            BtnDisplay.Enabled = false;
            BtnDelete.Enabled = false;
            BtnAdd.Enabled = true;*/

            addToolStripMenuItem1.Checked = true;
            modifyDisplayDeleteToolStripMenuItem.Checked = false;

            DeleteTextFields();
            Initial_State_of_Label();
        }

        private void modifyDisplayDeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TxtID.Enabled = true;
            TxtID.Text = "";

            modifyToolStripMenuItem.Enabled = true;
            displayToolStripMenuItem.Enabled = true;
            deleteToolStripMenuItem.Enabled = true;
            addToolStripMenuItem.Enabled = false;

            /*BtnModify.Enabled = true;
            BtnDisplay.Enabled = true;
            BtnDelete.Enabled = true;
            BtnAdd.Enabled = false;*/

            addToolStripMenuItem1.Checked = false;
            modifyDisplayDeleteToolStripMenuItem.Checked = true;

            DeleteTextFields();
            Initial_State_of_Label();
        }

        private void autoProcessToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TxtLog.Text = "Auto processing may take few seconds.Please wait...";
            if (TxtFY.Text == "" || TxtPlotNo.Text == "" || TxtFirstName.Text == "" || TxtLocalLevel.Text == "")
            {
                TxtLog.Text = "Please fill mandatory fields (*) to continue!";
            }
            else
            {
                LblProgress.ForeColor = Color.Black;
                PanelFore.Width = 0;
                PanelFore.BackColor = PanelBack.BackColor;
                //LblProgress.Text = "0%";


                AutoAdd = true;

                TabPage t = tabControl1.TabPages[2];
                tabControl1.SelectTab(t); //go to tab
                PanelFore.BackColor = Color.DarkViolet;
                PanelFore.Width += 18;
                Show_Progress_Percentage();

                BtnCreateMap_Click(sender, e);
                PanelFore.Width += 18;
                Show_Progress_Percentage();//20

                BtnSaveMap_Click(sender, e);
                BtnExportToKML_Click(sender, e);
                calculateToolStripMenuItem_Click(sender, e);
                //BtnCalculate_Click(sender, e);

                exportToPdfToolStripMenuItem_Click(sender, e);
                //BtnExportToPDF_Click(sender, e);
                PanelFore.Width += 18 + 18 + 18 + 18;
                Show_Progress_Percentage();//60

                BtnCreateNepaliLetter_Click(sender, e);
                PanelFore.Width += 18;
                Show_Progress_Percentage();

                BtnCreateNepaliTippani_Click(sender, e);
                PanelFore.Width += 18;
                Show_Progress_Percentage();

                addToolStripMenuItem_Click(sender, e);
                //BtnAdd_Click(sender, e);
                PanelFore.Width += 18;
                Show_Progress_Percentage();

                openRecentFolderToolStripMenuItem_Click(sender, e);
                //BtnOpenFolder_Click(sender, e);
                PanelFore.Width += 18;
                Show_Progress_Percentage();

                AutoAdd = false;

                TxtLog.Text = "Auto Process Completed";
            }
        }

        public void Calculate_Balked_Landing_Surface()
        {
            //For approach equation i.e. slope and intercepts
            //Equation of line parallel to AB i.e. IJ and GH
            double slope1, intercept1, distanceOffset, RWY_Len, d1, d2;
            double Disp_Th_Lower, Disp_Th_Higher;
            double Len_of_InnerEdge_BL, Dist_From_Threshold_BL, Divergence_BL, Slope_BL, Height_Hz;

            Len_of_InnerEdge_BL = Convert.ToDouble(dataGridView5.Rows[29].Cells[2].Value); //120.0;
            Dist_From_Threshold_BL = Convert.ToDouble(dataGridView5.Rows[30].Cells[2].Value); //1800.0;
            Divergence_BL = Convert.ToDouble(dataGridView5.Rows[31].Cells[2].Value); //10;//Percentage
            Slope_BL = Convert.ToDouble(dataGridView5.Rows[32].Cells[2].Value); //3.33;//Percentage
            Height_Hz = Convert.ToDouble(dataGridView5.Rows[4].Cells[2].Value); //45.0;

            Disp_Th_Lower = Convert.ToDouble(TxtLower_Disp_Th.Text);
            Disp_Th_Higher = Convert.ToDouble(TxtHigher_Disp_Th.Text);

            double[] Displaced_Th = new double[2] { Disp_Th_Lower, Disp_Th_Higher};
            double RL_IHS = Convert.ToDouble(TxtRL_IHS.Text);
            double RL_BL_InnerEdge=0;
            RWY_Len = ((Convert.ToDouble(dataGridView2.Rows[1].Cells["ColDistance"].Value)) + (Convert.ToDouble(dataGridView2.Rows[3].Cells["ColDistance"].Value))) / 2;
            d1 = Dist_From_Threshold_BL;
            d2 = 0;
            
            double[] distanceOffset1 = new double[] {d1, d2};   //45/3.33% = 1351.35
            //double[] distanceOffset1 = new double[2] {1500, 3000};   //45/3.33% = 1351.35  
            double[] intercept_parallel = new double[4];
            double a, b, x1, y1, x2, y2;
            string[] BL_Line_Name = new string[4] { "BL_AB", "BL_CD", "BL_EF", "BL_GH"};

            int DGV2_row_inx, DGV1_row_inx, i, intrcpt;
            int[] mulfactor = new int[] { 1, -1  }; //+1 for BL_AB and BL_CD wrt AB, -1 for BL_GH and BL_EF wrt CD
            int[] RW_Side = new int[2] { 0, 2 }; //0 for line AB, 2 for line CD

            //parallel line equation for small line
            intrcpt = 0;
            DGV2_row_inx = 31; //for BL_AB and end at index 31 for BL_AB
            for (int j = 0; j <=1; j++)
            {
                slope1 = Convert.ToDouble(dataGridView2.Rows[RW_Side[j]].Cells["ColSlope"].Value);//AB
                intercept1 = Convert.ToDouble(dataGridView2.Rows[RW_Side[j]].Cells["ColIntercept"].Value);//AB
                //MessageBox.Show("slope1 = " + slope1.ToString());
                //slope1 = 6.38465885;
                //intercept1 = 231401.2689;

                for (int k = 0; k <= 0; k++)
                {
                    //For TOC_DE--->RWY 28 side
                    //distanceOffset = distanceOffset1[k] + Displaced_Th[j];
                    distanceOffset = d1 + Displaced_Th[j];
                    //MessageBox.Show("Distance offset = " + distanceOffset.ToString("0.00"));
                    intercept_parallel[intrcpt] = Intercept_of_Parallel_line(slope1, intercept1, distanceOffset, mulfactor[j]);
                    //MessageBox.Show("Distance offset = " + intercept_parallel[intrcpt].ToString("0.00"));
                    dataGridView2.Rows[DGV2_row_inx].Cells["ColLine"].Value = BL_Line_Name[intrcpt];
                    dataGridView2.Rows[DGV2_row_inx].Cells["ColSlope"].Value = slope1.ToString();
                    dataGridView2.Rows[DGV2_row_inx].Cells["ColIntercept"].Value = intercept_parallel[intrcpt].ToString();

                    DGV2_row_inx +=2;
                    intrcpt +=2;

                }
            }


            
            //parallel line equation for big line
            intrcpt = 1;
            DGV2_row_inx = 32; //for BL_AB and end at index 31 for BL_AB
            int[] bl_idx = new int[] { 31, 33 };
            for (int j = 0; j <= 1; j++)
            {
                slope1 = Convert.ToDouble(dataGridView2.Rows[RW_Side[j]].Cells["ColSlope"].Value);//AB
                intercept1 = Convert.ToDouble(dataGridView2.Rows[RW_Side[j]].Cells["ColIntercept"].Value);//AB
                //MessageBox.Show("slope1 = " + slope1.ToString());
                //slope1 = 6.38465885;
                //intercept1 = 231401.2689;

                double m, c, m2, c2;
                int DGV1_index1, DGV1_index2;
                DGV1_index1 = 14;
                DGV1_index2 = 15;
                m2 = Convert.ToDouble(dataGridView2.Rows[4].Cells[1].Value);//EF
                c2 = Convert.ToDouble(dataGridView2.Rows[4].Cells[2].Value);//EF
                m = Convert.ToDouble(dataGridView2.Rows[bl_idx[j]].Cells[1].Value);//EF
                c = Convert.ToDouble(dataGridView2.Rows[bl_idx[j]].Cells[2].Value);//EF
                RL_BL_InnerEdge = RL_of_RWY_CL_by_Interpolation(m, c, m2, c2, DGV1_index1, DGV1_index2);
                d2 = (RL_IHS + Height_Hz - RL_BL_InnerEdge) * 100.0 / Slope_BL + Dist_From_Threshold_BL;

                for (int k = 1; k <= 1; k++)
                {
                    //For TOC_DE--->RWY 28 side
                    //distanceOffset = distanceOffset1[k] + Displaced_Th[j];
                    distanceOffset = d2 + Displaced_Th[j];
                    //distanceOffset = distanceOffset1[k];
                    //MessageBox.Show("Distance offset = " + distanceOffset.ToString("0.00"));
                    intercept_parallel[intrcpt] = Intercept_of_Parallel_line(slope1, intercept1, distanceOffset, mulfactor[j]);
                    //MessageBox.Show("Distance offset = " + intercept_parallel[intrcpt].ToString("0.00"));
                    dataGridView2.Rows[DGV2_row_inx].Cells["ColLine"].Value = BL_Line_Name[intrcpt];
                    dataGridView2.Rows[DGV2_row_inx].Cells["ColSlope"].Value = slope1.ToString();
                    dataGridView2.Rows[DGV2_row_inx].Cells["ColIntercept"].Value = intercept_parallel[intrcpt].ToString();

                    DGV2_row_inx +=2;
                    intrcpt +=2;

                }
            }

            //Point of intersection of circle and line
            double Quad_x_plus, Quad_x_minus, Quad_y_plus, Quad_y_minus;
            //double B, A, C, a, b;
            double r1 = Len_of_InnerEdge_BL * 0.5; //half distance of starting line of BL
            double dist;
            double slope2, intercept2, radius;
            double[] BL_COORD_X = new double[8];
            double[] BL_COORD_Y = new double[8];
            string[] BL_Point_Name = new string[8] { "BL_A", "BL_B", "BL_D", "BL_C", "BL_E", "BL_F", "BL_H", "BL_G" };
            double[] latlong1 = new double[2];
            double tempdist;
            tempdist = Height_Hz * 100.0 / Slope_BL * Divergence_BL / 100.0;
            double[] radii = new double[2] { r1, (tempdist * 2 + Len_of_InnerEdge_BL) *0.5};//195.135 = 135.135*2+120; 135.135 = dist * 10%


            DGV1_row_inx = 34;//for BL_A and end at index 41 for BL_H
            DGV2_row_inx = 31; //for BL_AB and end at index 34 for BL_CD for distance
            //PtIndex = 0;
            i = 0;
            intrcpt = 0;
            for (int j = 0; j <= 2; j += 2)
            {
                slope2 = Convert.ToDouble(dataGridView2.Rows[4].Cells["ColSlope"].Value);//slope of EF
                intercept2 = Convert.ToDouble(dataGridView2.Rows[4].Cells["ColIntercept"].Value);//intercept of EF
                                                                                                 //For Point TOC_A and TOC_B
                slope1 = Convert.ToDouble(dataGridView2.Rows[j].Cells["ColSlope"].Value);//slope of AB equals to slope of TOC_AB

                for (int k = 0; k <= 1; k++)
                {

                    intercept1 = intercept_parallel[intrcpt]; //intercept of BL_AB i.e. parallel line
                    radius = radii[k]; //distance between BL_A and E'
                    a = Find_Intersection_X(slope1, intercept1, slope2, intercept2);//X-COORD of intersection of EF and BL_AB
                    b = Find_Intersection_Y(slope1, intercept1, slope2, intercept2);//Y-COORD of intersection of EF and BL_EF

                    Quad_x_plus = Find_Quadratic_X_Plus(slope1, intercept1, a, b, radius);
                    Quad_x_minus = Find_Quadratic_X_minus(slope1, intercept1, a, b, radius);
                    Quad_y_plus = slope1 * Quad_x_plus + intercept1;//TOC_A
                    Quad_y_minus = slope1 * Quad_x_minus + intercept1;//TOC_B

                    //COORD TOC_A
                    BL_COORD_X[i] = Quad_x_plus;
                    BL_COORD_Y[i] = Quad_y_plus;
                    //COORD TOC_B
                    BL_COORD_X[i + 1] = Quad_x_minus;
                    BL_COORD_Y[i + 1] = Quad_y_minus;

                    latlong1 = Convert_UTM_To_Latitude_Longitude(Quad_x_plus, Quad_y_plus);
                    dataGridView1.Rows[DGV1_row_inx].Cells["ColPoint"].Value = BL_Point_Name[i].ToString();
                    dataGridView1.Rows[DGV1_row_inx].Cells["ColLatitude"].Value = latlong1[0].ToString();
                    dataGridView1.Rows[DGV1_row_inx].Cells["ColLongitude"].Value = latlong1[1].ToString();
                    dataGridView1.Rows[DGV1_row_inx].Cells["ColEasting"].Value = Quad_x_plus.ToString();
                    dataGridView1.Rows[DGV1_row_inx].Cells["ColNorthing"].Value = Quad_y_plus.ToString();

                    latlong1 = Convert_UTM_To_Latitude_Longitude(Quad_x_minus, Quad_y_minus);
                    dataGridView1.Rows[DGV1_row_inx + 1].Cells["ColPoint"].Value = BL_Point_Name[i + 1].ToString();
                    dataGridView1.Rows[DGV1_row_inx + 1].Cells["ColLatitude"].Value = latlong1[0].ToString();
                    dataGridView1.Rows[DGV1_row_inx + 1].Cells["ColLongitude"].Value = latlong1[1].ToString();
                    dataGridView1.Rows[DGV1_row_inx + 1].Cells["ColEasting"].Value = Quad_x_minus.ToString();
                    dataGridView1.Rows[DGV1_row_inx + 1].Cells["ColNorthing"].Value = Quad_y_minus.ToString();
                    
                    DGV1_row_inx += 2;

                    //distance between two points
                    dist = Find_Distance_bet_two_pointXY(Quad_x_plus, Quad_y_plus, Quad_x_minus, Quad_y_minus);
                    dataGridView2.Rows[DGV2_row_inx].Cells[3].Value = dist.ToString();

                    DGV2_row_inx++;
                    i += 2;
                    //PtIndex += 2;
                    intrcpt++;
                }
            }

            //Find slope and intercept of inclined JG, IH, NK and ML
            double[] BL_Diverg_Slope = new double[4];
            double[] BL_Diverg_Intercept = new double[4];
            int[,] PIdx = new int[4, 2] { { 0, 2}, { 1, 3}, { 4,6}, { 5,7} };
            string[] InclLine = new string[4] { "BL_AD", "BL_BC", "BL_EH", "BL_FG"};
            double x11, y11, x22, y22;

            intrcpt = 0;
            DGV2_row_inx = 35; //datagridview2 from index 35 to 38
            for (int kk = 0; kk < 4; kk++)
            {
                for (int j = 0; j <= 0; j++)
                {
                    x11 = BL_COORD_X[PIdx[kk, j]];//PIdx
                    y11 = BL_COORD_Y[PIdx[kk, j]];
                    x22 = BL_COORD_X[PIdx[kk, j + 1]];//PIdx + 1
                    y22 = BL_COORD_Y[PIdx[kk, j + 1]];
                    BL_Diverg_Slope[intrcpt] = Find_Slope_Of_Equation(x11, y11, x22, y22);//intrcpt
                    BL_Diverg_Intercept[intrcpt] = Find_Intercept_Of_Equation(BL_Diverg_Slope[intrcpt], x11, y11);//intrcpt
                    dataGridView2.Rows[DGV2_row_inx].Cells["ColLine"].Value = InclLine[intrcpt];
                    dataGridView2.Rows[DGV2_row_inx].Cells["ColSlope"].Value = BL_Diverg_Slope[intrcpt].ToString();
                    dataGridView2.Rows[DGV2_row_inx].Cells["ColIntercept"].Value = BL_Diverg_Intercept[intrcpt].ToString();
                    dataGridView2.Rows[DGV2_row_inx].Cells["ColDistance"].Value = Find_Distance_bet_two_pointXY(x11, y11, x22, y22).ToString();

                    intrcpt ++;
                    DGV2_row_inx ++;
                }
            }

        }

        private double[] Convert_UTM_To_Latitude_Longitude(double Easting_X, double Northing_Y)
        {
            double a, one_by_f, lambda0, K0, M0;
            double False_Easting_X, f;
            double M, e_2, e_prime_2, mu, e1, phi1, R1, T1, C1, x, N1, D, phi, lambda;
            double[] LatLong = new double[2];

            //Parameter values for WGS and UTM84
            /*False_Easting_X = 500000.0;
            //False_Northing_Y = 0;
            a = 6378137.0;
            one_by_f = 298.2572201;
            K0 = 0.9996;
            M0 = 0; //distance in meter of origin latitude from equator*/

            False_Easting_X = Convert.ToDouble(TxtFalseEasting_X.Text);
            a = Convert.ToDouble(TxtA.Text);
            one_by_f = Convert.ToDouble(TxtOneByF.Text);
            K0 = Convert.ToDouble(TxtK0.Text);
            M0 = Convert.ToDouble(TxtM0.Text);

            //Input
            //lambda0 = 84.0; //central meridian for zone 44
            lambda0 = Convert.ToDouble(TxtCM.Text);

            //Formula and equation for conversion from UTM to WGS
            f = 1 / one_by_f;
            M = M0 + Northing_Y / K0;
            e_2 = 2.0 * f - f * f;
            e_prime_2 = e_2 / (1.0 - e_2);
            mu = M / (a * (1.0 - e_2 / 4.0 - 3.0 * e_2 * e_2 / 64.0 - 5.0 * e_2 * e_2 * e_2 / 256.0));
            e1 = (1.0 - Math.Sqrt(1 - e_2)) / (1 + Math.Sqrt(1.0 - e_2));

            double phi1_term1 = (3.0 * e1 / 2.0 - 27.0 * e1 * e1 * e1 / 32) * Math.Sin(2 * mu);
            double phi1_term2 = (21.0 * e1 * e1 / 16.0 - 55.0 * e1 * e1 * e1 * e1 / 32.0) * Math.Sin(4 * mu);
            double phi1_term3 = (151.0 * e1 * e1 * e1 / 96.0) * Math.Sin(6 * mu);
            double phi1_term4 = (1097.0 * e1 * e1 * e1 * e1 / 512.0) * Math.Sin(8 * mu);

            phi1 = mu + phi1_term1 + phi1_term2 + phi1_term3 + phi1_term4;

            R1 = a * (1.0 - e_2) / Math.Pow((1.0 - e_2 * Math.Sin(phi1) * Math.Sin(phi1)), 3.0 / 2.0);
            T1 = Math.Tan(phi1) * Math.Tan(phi1);
            C1 = e_prime_2 * Math.Cos(phi1) * Math.Cos(phi1);
            x = Easting_X - False_Easting_X;
            N1 = a / (Math.Sqrt(1.0 - e_2 * Math.Sin(phi1) * Math.Sin(phi1)));
            D = x / (N1 * K0);
            double phi_t1 = D * D / 2.0 - (5.0 + 3.0 * T1 + 10.0 * C1 - 4.0 * C1 * C1 - 9.0 * e_prime_2) * D * D * D * D / 24.0;
            double phi_t2 = (61.0 + 90.0 * T1 + 298.0 * C1 + 45.0 * T1 * T1 - 252.0 * e_prime_2 - 3.0 * C1 * C1) * D * D * D * D * D * D / 720.0;

            phi = phi1 - (N1 * Math.Tan(phi1) / R1) * (phi_t1 + phi_t2); //latitude in radian

            double lambda_t1 = D - (1.0 + 2.0 * T1 + C1) * D * D * D / 6.0;
            double lambda_t2 = (5.0 - 2.0 * C1 + 28.0 * T1 - 3 * C1 * C1 + 8.0 * e_prime_2 + 24.0 * T1 * T1) * D * D * D * D * D / 120.0;
            lambda = lambda0 * Math.PI / 180.0 + (lambda_t1 + lambda_t2) / Math.Cos(phi1); //longitude in radian

            //Final_Latitude_DD = phi * 180.0 / Math.PI;
            //Final_Longitude_DD = lambda * 180.0 / Math.PI;
            LatLong[0] = phi * 180.0 / Math.PI;
            LatLong[1] = lambda * 180.0 / Math.PI;
            return LatLong;

            //MessageBox.Show("phi_t1 +t2 = " + (phi_t1+phi_t2)* ((N1 * Math.Tan(phi1) / R1)) + "\nphi1 = " + phi1);
        }

        public void Plot_RWY_Polygon()
        {
            try
            {
                double lat1, long1, lat2, long2, lat3, long3, lat4, long4;

                //take lat long input from text boxes
                lat1 = Convert.ToDouble(dataGridView1.Rows[0].Cells["ColLatitude"].Value);
                long1 = Convert.ToDouble(dataGridView1.Rows[0].Cells["ColLongitude"].Value);

                lat2 = Convert.ToDouble(dataGridView1.Rows[1].Cells["ColLatitude"].Value);
                long2 = Convert.ToDouble(dataGridView1.Rows[1].Cells["ColLongitude"].Value);

                lat3 = Convert.ToDouble(dataGridView1.Rows[2].Cells["ColLatitude"].Value);
                long3 = Convert.ToDouble(dataGridView1.Rows[2].Cells["ColLongitude"].Value);

                lat4 = Convert.ToDouble(dataGridView1.Rows[3].Cells["ColLatitude"].Value);
                long4 = Convert.ToDouble(dataGridView1.Rows[3].Cells["ColLongitude"].Value);

                //lat_mid = (lat1 + lat2) / 2;
                //long_mid = (long1 + long2) / 2;

                //show google map
                GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerAndCache;
                gMapControl2.DragButton = MouseButtons.Left;
                gMapControl2.MouseWheelZoomEnabled = true;
                //gMapControl2.MapProvider = GMap.NET.MapProviders.GoogleMapProvider.Instance;
                gMapControl2.MapProvider = GMap.NET.MapProviders.GoogleSatelliteMapProvider.Instance;
                //gMapControl2.Position = new PointLatLng(lat4, long4);
               //gMapControl2.Position = new PointLatLng(lat2, long2);
                //gMapControl2.Zoom = 15;

                //Making red cross invisible
                gMapControl2.ShowCenter = false;

                //clear map
                for (int i = 1; i <= 5; i++)
                {
                    if (gMapControl2.Overlays.Count > 0)
                    {
                        gMapControl2.Overlays.RemoveAt(0);
                        gMapControl2.Refresh();
                    }
                }

                //add markers
                PointLatLng point1 = new PointLatLng(lat1, long1);
                PointLatLng point2 = new PointLatLng(lat2, long2);
                PointLatLng point3 = new PointLatLng(lat3, long3);
                PointLatLng point4 = new PointLatLng(lat4, long4);

                GMap.NET.WindowsForms.GMapMarker mapMarker1 = new GMarkerGoogle(point1, GMarkerGoogleType.blue_pushpin);
                GMap.NET.WindowsForms.GMapMarker mapMarker2 = new GMarkerGoogle(point2, GMarkerGoogleType.blue_pushpin);
                GMap.NET.WindowsForms.GMapMarker mapMarker3 = new GMarkerGoogle(point3, GMarkerGoogleType.blue_pushpin);
                GMap.NET.WindowsForms.GMapMarker mapMarker4 = new GMarkerGoogle(point4, GMarkerGoogleType.blue_pushpin);

                //create overlay
                GMapOverlay markerOverlay1 = new GMapOverlay("markerOverlay1");
                GMapOverlay markerOverlay2 = new GMapOverlay("markerOverlay2");
                GMapOverlay markerOverlay3 = new GMapOverlay("markerOverlay3");
                GMapOverlay markerOverlay4 = new GMapOverlay("markerOverlay4");

                //add all marker to overlay
                markerOverlay1.Markers.Add(mapMarker1);
                markerOverlay2.Markers.Add(mapMarker2);
                markerOverlay3.Markers.Add(mapMarker3);
                markerOverlay4.Markers.Add(mapMarker4);

                //cover map with overlay
                gMapControl2.Overlays.Add(markerOverlay1);
                gMapControl2.Overlays.Add(markerOverlay2);
                gMapControl2.Overlays.Add(markerOverlay3);
                gMapControl2.Overlays.Add(markerOverlay4);

                //Draw Polygon
                GMapOverlay polygons = new GMapOverlay("polygons");
                List<PointLatLng> points = new List<PointLatLng>();

                points.Add(new PointLatLng(lat1, long1));
                points.Add(new PointLatLng(lat2, long2));
                points.Add(new PointLatLng(lat3, long3));
                points.Add(new PointLatLng(lat4, long4));

                GMap.NET.WindowsForms.GMapPolygon polygon = new GMap.NET.WindowsForms.GMapPolygon(points, "LinePoly"); 
                polygons.Polygons.Add(polygon);
                gMapControl2.Overlays.Add(polygons);
                polygon.Fill = new SolidBrush(Color.FromArgb(50, Color.Red));
                polygon.Stroke = new Pen(Color.Red, 1);

                double maxlat, maxlong, minlat, minlong, temp1, temp2;
                temp1 = Math.Max(lat1, lat2);
                temp2 = Math.Max(lat3, lat4);
                maxlat = Math.Max(temp1, temp2);

                temp1 = Math.Min(lat1, lat2);
                temp2 = Math.Min(lat3, lat4);
                minlat = Math.Min(temp1, temp2);

                temp1 = Math.Max(long1, long2);
                temp2 = Math.Max(long3, long4);
                maxlong = Math.Max(temp1, temp2);

                temp1 = Math.Min(long1, long2);
                temp2 = Math.Min(long3, long4);
                minlong = Math.Min(temp1, temp2);

                //Draw routes
                /*GMapOverlay routes = new GMapOverlay("routes");
                List<PointLatLng> points_route = new List<PointLatLng>();
                points_route.Add(new PointLatLng(lat1, long1));
                points_route.Add(new PointLatLng(lat2, long2));
                GMap.NET.WindowsForms.GMapRoute route = new GMap.NET.WindowsForms.GMapRoute(points_route, "RWY to House");
                //TxtLog.Text = (route.Distance * 1000).ToString() + " m";
                route.Stroke = new Pen(Color.Red, 3);
                routes.Routes.Add(route);
                gMapControl2.Overlays.Add(routes);*/

                //tooltip
                mapMarker1.ToolTipText = "A";
                mapMarker2.ToolTipText = "B";
                mapMarker3.ToolTipText = "C";
                mapMarker4.ToolTipText = "D";

                mapMarker1.ToolTipMode = MarkerTooltipMode.Always;
                mapMarker2.ToolTipMode = MarkerTooltipMode.Always;
                mapMarker3.ToolTipMode = MarkerTooltipMode.Always;
                mapMarker4.ToolTipMode = MarkerTooltipMode.Always;

                gMapControl2.Invalidate();
                gMapControl2.Update();

                //RectLatLng Rect_COORD = new RectLatLng(maxlat, maxlong, Math.Abs(maxlong - minlong), Math.Abs(maxlat - minlat));
                RectLatLng Rect_COORD = new RectLatLng(lat4, long4, Math.Abs(maxlong - minlong), Math.Abs(maxlat - minlat));
                gMapControl2.SetZoomToFitRect(Rect_COORD);
                //gMapControl2.Position = new PointLatLng((lat1 + lat3) / 2, (long1 + long3) / 2); // centered on lat_mid, long_mid
                double latE, longE, latF, longF, midLat, midLong;
                latE = Convert.ToDouble(dataGridView1.Rows[4].Cells[2].Value);
                longE = Convert.ToDouble(dataGridView1.Rows[4].Cells[3].Value);
                latF = Convert.ToDouble(dataGridView1.Rows[5].Cells[2].Value);
                longF = Convert.ToDouble(dataGridView1.Rows[5].Cells[3].Value);
                midLat = (latE + latF) / 2;
                midLong = (longE + longF) / 2;
                gMapControl2.Position = new PointLatLng(midLat, minlong); // centered on lat_mid, long_mid


            }
            catch
            {

            }
        }

        public double Find_Slope_Of_Equation(double X1, double Y1, double X2, double Y2)
        {
            double slope;
            slope = (Y2 - Y1) / (X2 - X1);
            return slope;
        }

        public double Find_Intercept_Of_Equation(double slope, double X1, double Y1)
        { 
            double intercept;
            intercept = (Y1 - slope * X1);
            return intercept;
        }

        public double Find_Distance_Of_LineXY(double X1, double Y1, double X2, double Y2)
        {
            double distance, del_X, del_Y;
            del_X = Math.Abs(X2 - X1);
            del_Y = Math.Abs(Y2 - Y1);
            distance = Math.Sqrt(del_X * del_X + del_Y * del_Y);
            return distance;
        }

        public void Calculate_Transitional_Surface_with_different_RL()
        {
            //For approach equation i.e. slope and intercepts
            //Equation of line parallel to AB i.e. IJ and GH
            double slope1, intercept1, distanceOffset;
            double Slope_Trans, Len_of_InnerEdge_Ap, Height_Hz;
            double RL_IHS, RL_KL, RL_JI;

            Slope_Trans = Convert.ToDouble(dataGridView5.Rows[25].Cells[2].Value); //14.3;
            Len_of_InnerEdge_Ap = Convert.ToDouble(dataGridView5.Rows[12].Cells[2].Value); //280.0;
            Height_Hz = Convert.ToDouble(dataGridView5.Rows[4].Cells[2].Value); //45.0;

            RL_IHS = Convert.ToDouble(TxtRL_IHS.Text);
            RL_KL = Convert.ToDouble(dataGridView6.Rows[0].Cells[2].Value);
            int lastrow = dataGridView6.RowCount - 1;

            RL_JI = Convert.ToDouble(dataGridView6.Rows[lastrow - 1].Cells[2].Value);
            double d_fst, d_lst;
            //d_fst = 0.5 * Len_of_InnerEdge_Ap + (RL_IHS + Height_Hz - RL_KL) * 100.0 / Slope_Trans;
            //d_lst = 0.5 * Len_of_InnerEdge_Ap + (RL_IHS + Height_Hz - RL_JI) * 100.0 / Slope_Trans;

            //double[] distanceOffset1 = new double[] { d_fst, d_lst };//314.68 = 45/14.3%
            //45/14.3% = 314.68
            //double[] intercept_parallel_up = new double[500];
            //double[] intercept_parallel_dn = new double[500];
            //double a, b, x1, y1, x2, y2;
            string[] Trans_Line_Name = new string[2] { "Trans_EH", "Trans_FG" };

            int intrcpt;
            int a1, a2;
            slope1 = Convert.ToDouble(dataGridView2.Rows[4].Cells["ColSlope"].Value);//EF
            double tempslope;
            tempslope = Math.Atan(slope1);
            if (tempslope >= 0)
            {
                a1 = -1;
                a2 = 1;
            }
            else
            {
                a1 = 1;
                a2 = -1;
            }
            int[] mulfactor = new int[2] { a1, a2 };//1 for T_AD and -1 for T_BC
            int[] RW_Side = new int[1] { 4 };

            double X_coord, Y_coord;

            intrcpt = 0;

            slope1 = Convert.ToDouble(dataGridView2.Rows[RW_Side[0]].Cells["ColSlope"].Value);//EF
            intercept1 = Convert.ToDouble(dataGridView2.Rows[RW_Side[0]].Cells["ColIntercept"].Value);//EF
            double[] latlong1 = new double[2];
            dataGridView9.Rows.Clear();
            for (int k = 0; k < lastrow*2; k++)
            {
                dataGridView9.Rows.Add();
            }
            for (int j = 0; j <= 1; j++)
            {
                for (int k = 0; k < lastrow; k++)
                {
                    //For Trans up i.e. at K
                    double RL_CL_RWY = Convert.ToDouble(dataGridView6.Rows[k].Cells[2].Value);
                    distanceOffset = 0.5 * Len_of_InnerEdge_Ap + (RL_IHS + Height_Hz - RL_CL_RWY) * 100.0 / Slope_Trans;
                    //distanceOffset = distanceOffset1[k];
                    double intrc_parallel = Intercept_of_Parallel_line(slope1, intercept1, distanceOffset, mulfactor[j]);

                    double m_kl = Convert.ToDouble(dataGridView2.Rows[9].Cells["ColSlope"].Value);//KL
                    double c_kl = Convert.ToDouble(dataGridView2.Rows[9].Cells["ColIntercept"].Value);//KL
                    distanceOffset = Convert.ToDouble(dataGridView6.Rows[k].Cells[1].Value);//chainage
                                                                                            //distanceOffset = distanceOffset1[k];
                    double intrc_perp = Intercept_of_Parallel_line(m_kl, c_kl, distanceOffset, -1);

                    X_coord = Find_Intersection_X(slope1, intrc_parallel, m_kl, intrc_perp);
                    Y_coord = Find_Intersection_Y(slope1, intrc_parallel, m_kl, intrc_perp);

                    latlong1 = Convert_UTM_To_Latitude_Longitude(X_coord, Y_coord);

                    dataGridView9.Rows[intrcpt].Cells[0].Value = distanceOffset.ToString();
                    dataGridView9.Rows[intrcpt].Cells[1].Value = "Transition_" + j.ToString();
                    dataGridView9.Rows[intrcpt].Cells[2].Value = latlong1[0].ToString();
                    dataGridView9.Rows[intrcpt].Cells[3].Value = latlong1[1].ToString();
                    dataGridView9.Rows[intrcpt].Cells[4].Value = X_coord.ToString();
                    dataGridView9.Rows[intrcpt].Cells[5].Value = Y_coord.ToString();

                    intrcpt++;
                }
            }

            double x1, y1, x2, y2, dist;
            int DGV2_row_inx = 53;
            int n_row6 = dataGridView6.RowCount - 1;
            int[] ix = new int[] { n_row6 - 1, (n_row6 - 1)*2-1, 0, n_row6 };
            int[] iy = new int[] { 66, 67, 68, 69 };
            string[] LineName = new string[] { "Trans_EA", "Trans_FB", "Trans_HD", "Trans_GC" };
            for (int k = 0; k <= 3; k++)
            {
                x1 = Convert.ToDouble(dataGridView9.Rows[ix[k]].Cells[4].Value);//E
                y1 = Convert.ToDouble(dataGridView9.Rows[ix[k]].Cells[5].Value);//E
                x2 = Convert.ToDouble(dataGridView1.Rows[iy[k]].Cells[4].Value);//A
                y2 = Convert.ToDouble(dataGridView1.Rows[iy[k]].Cells[5].Value);//A

                slope1 = Find_Slope_Of_Equation(x1, y1, x2, y2);
                intercept1 = Find_Intercept_Of_Equation(slope1, x1, y1);
                dist = Find_Distance_bet_two_pointXY(x1, y1, x2, y2);

                dataGridView2.Rows[DGV2_row_inx].Cells[0].Value = LineName[k];
                dataGridView2.Rows[DGV2_row_inx].Cells[1].Value = slope1.ToString();
                dataGridView2.Rows[DGV2_row_inx].Cells[2].Value = intercept1.ToString();
                dataGridView2.Rows[DGV2_row_inx].Cells[3].Value = dist.ToString();
                DGV2_row_inx++;
            }


        }

    }
}
