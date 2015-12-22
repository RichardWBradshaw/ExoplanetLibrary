using System;
using NPlot;
using System.Drawing;
using System.Collections;

namespace ExoplanetLibrary
    {
    public class Plotting
        {
        Plotting ()
            {
            }

        static private bool IncludeLegend_ = false;
        static private bool IncludeLegend
            {
            get { return IncludeLegend_; }
            set { IncludeLegend_ = value; }
            }

        static private bool ColorFromStarType_ = false;
        static private bool ColorFromStarType
            {
            get { return ColorFromStarType_; }
            set { ColorFromStarType_ = value; }
            }

        static public void VisualizeStars (NPlot.Windows.PlotSurface2D plotSurface, ArrayList exoplanets)
            {
            ArrayList stars = Helper.GetStars (exoplanets);

            plotSurface.Clear ();
            plotSurface.Title = "Star Plot";
            plotSurface.BackColor = System.Drawing.Color.White;

            NPlot.Grid p = new Grid ();
            plotSurface.Add (p, PlotSurface2D.XAxisPosition.Bottom, PlotSurface2D.YAxisPosition.Left);

            foreach (Star star in stars)
                {
                if (star.Declination != null)
                    if (star.RightAccession != null)
                        {
                        double dec = 0.0, ra = 0.0;

                        if (double.TryParse (star.Declination, out dec) == true)
                            if (double.TryParse (star.RightAccession, out ra) == true)
                                {
                                PointPlot pointPlot = new PointPlot ();
                                double [] declination = new double [1];
                                double [] accession = new double [1];

                                pointPlot.AbscissaData = accession;
                                pointPlot.DataSource = declination;
                                pointPlot.Label = "Declination (dd:mm:ss)";

                                declination [0] = dec;
                                accession [0] = ra;

                                switch (Helper.NumberOfExoplanets (exoplanets, star.Name))
                                    {
                                    case 1:
                                        pointPlot.Marker.Type = Marker.MarkerType.FilledCircle;
                                        break;

                                    case 2:
                                        pointPlot.Marker.Type = Marker.MarkerType.FilledCircle2;
                                        break;

                                    default:
                                        pointPlot.Marker.Type = Marker.MarkerType.FilledCircle3;
                                        break;
                                    }

                                if (ColorFromStarType)
                                    {
                                    pointPlot.Marker.Color = System.Drawing.Color.Black;

                                    if (star.Property.SPType != null)
                                        switch (star.Property.SPType [0])
                                            {
                                            case 'O': pointPlot.Marker.Color = System.Drawing.Color.Blue; break;
                                            case 'B': pointPlot.Marker.Color = System.Drawing.Color.Cyan; break;
                                            case 'A': pointPlot.Marker.Color = System.Drawing.Color.Yellow; break;
                                            case 'F': pointPlot.Marker.Color = System.Drawing.Color.LightYellow; break;
                                            case 'G': pointPlot.Marker.Color = System.Drawing.Color.Yellow; break;
                                            case 'K': pointPlot.Marker.Color = System.Drawing.Color.Orange; break;
                                            case 'M': pointPlot.Marker.Color = System.Drawing.Color.Red; break;
                                            default: pointPlot.Marker.Color = System.Drawing.Color.Black; break;
                                            }
                                    }
                                else
                                    pointPlot.Marker.Color = System.Drawing.Color.Blue;

                                plotSurface.Add (pointPlot, PlotSurface2D.XAxisPosition.Bottom, PlotSurface2D.YAxisPosition.Left);
                                }
                        }
                }

            Font titleFont = new Font ("Arial", 12);
            Font axisFont = new Font ("Arial", 10);
            Font tickFont = new Font ("Arial", 8);

            plotSurface.XAxis1.Label = "Right Accession (hh:mm:ss)";
            plotSurface.XAxis1.NumberFormat = "{0:0}";
            plotSurface.XAxis1.TicksLabelAngle = 0;
            plotSurface.XAxis1.TickTextNextToAxis = true;
            plotSurface.XAxis1.FlipTicksLabel = true;
            plotSurface.XAxis1.LabelOffset = 25;
            plotSurface.XAxis1.LabelOffsetAbsolute = true;
            plotSurface.XAxis1.LabelFont = axisFont;
            plotSurface.XAxis1.TickTextFont = tickFont;

            plotSurface.YAxis1.Label = "Declination (dd:mm:ss)";
            plotSurface.YAxis1.NumberFormat = "{0:0.0}";
            plotSurface.YAxis1.LabelFont = axisFont;
            plotSurface.YAxis1.TickTextFont = tickFont;

            if (IncludeLegend == true)
                {
                NPlot.Legend legend = new NPlot.Legend ();

                legend.AttachTo (PlotSurface2D.XAxisPosition.Top, PlotSurface2D.YAxisPosition.Right);
                legend.VerticalEdgePlacement = NPlot.Legend.Placement.Inside;
                legend.HorizontalEdgePlacement = NPlot.Legend.Placement.Outside;
                legend.BorderStyle = NPlot.LegendBase.BorderType.Line;
                plotSurface.Legend = legend;
                }

            plotSurface.Refresh ();
            }

        static public void VisualizeRadius (NPlot.Windows.PlotSurface2D plotSurface, ArrayList exoplanets)
            {
            ArrayList array = Helper.PlanetsWithRadius (exoplanets);

            double [] radii = new System.Double [array.Count];
            double [] indexes = new System.Double [array.Count];
            int counter = 0;

            foreach (Exoplanet exoplanet in array)
                {
                double radius = 0.0;

                if (double.TryParse (exoplanet.Radius, out radius) == true)
                    {
                    radii [counter] = radius;
                    indexes [counter] = counter + 1;
                    counter++;
                    }
                }

            plotSurface.Clear ();
            plotSurface.Title = "Radius Plot";
            plotSurface.BackColor = System.Drawing.Color.White;

            NPlot.Grid p = new Grid ();
            plotSurface.Add (p, PlotSurface2D.XAxisPosition.Bottom, PlotSurface2D.YAxisPosition.Left);

            PointPlot pointPlot = new PointPlot ();
            pointPlot.AbscissaData = indexes;
            pointPlot.DataSource = radii;
            pointPlot.Label = "Index";
            pointPlot.Marker.Color = System.Drawing.Color.Blue;
            pointPlot.Marker.Type = NPlot.Marker.MarkerType.FilledCircle;

            plotSurface.Add (pointPlot, PlotSurface2D.XAxisPosition.Bottom, PlotSurface2D.YAxisPosition.Left);

            Font titleFont = new Font ("Arial", 12);
            Font axisFont = new Font ("Arial", 10);
            Font tickFont = new Font ("Arial", 8);

            plotSurface.XAxis1.Label = "Index";
            plotSurface.XAxis1.NumberFormat = "{0:0}";
            plotSurface.XAxis1.TicksLabelAngle = 0;
            plotSurface.XAxis1.TickTextNextToAxis = true;
            plotSurface.XAxis1.FlipTicksLabel = true;
            plotSurface.XAxis1.LabelOffset = 25;
            plotSurface.XAxis1.LabelOffsetAbsolute = true;
            plotSurface.XAxis1.LabelFont = axisFont;
            plotSurface.XAxis1.TickTextFont = tickFont;

            plotSurface.YAxis1.Label = "Radius (Rjup)";
            plotSurface.YAxis1.NumberFormat = "{0:0.0}";
            plotSurface.YAxis1.LabelFont = axisFont;
            plotSurface.YAxis1.TickTextFont = tickFont;

            if (IncludeLegend == true)
                {
                NPlot.Legend legend = new NPlot.Legend ();

                legend.AttachTo (PlotSurface2D.XAxisPosition.Top, PlotSurface2D.YAxisPosition.Right);
                legend.VerticalEdgePlacement = NPlot.Legend.Placement.Inside;
                legend.HorizontalEdgePlacement = NPlot.Legend.Placement.Outside;
                legend.BorderStyle = NPlot.LegendBase.BorderType.Line;
                plotSurface.Legend = legend;
                }

            plotSurface.Refresh ();
            }

        static public void VisualizeMass (NPlot.Windows.PlotSurface2D plotSurface, ArrayList exoplanets)
            {
            ArrayList array = Helper.PlanetsWithMassAndRadius (exoplanets);

            double [] masses = new System.Double [array.Count];
            double [] indexes = new System.Double [array.Count];
            int counter = 0;

            foreach (Exoplanet exoplanet in array)
                {
                double mass = 0.0;

                if (double.TryParse (exoplanet.Mass, out mass) == true)
                    {
                    masses [counter] = mass;
                    indexes [counter] = counter + 1;
                    counter++;
                    }
                }

            plotSurface.Clear ();
            plotSurface.Title = "Mass Plot";
            plotSurface.BackColor = System.Drawing.Color.White;

            NPlot.Grid p = new Grid ();
            plotSurface.Add (p, PlotSurface2D.XAxisPosition.Bottom, PlotSurface2D.YAxisPosition.Left);

            PointPlot pointPlot = new PointPlot ();
            pointPlot.AbscissaData = indexes;
            pointPlot.DataSource = masses;
            pointPlot.Label = "Index";
            pointPlot.Marker.Color = System.Drawing.Color.Blue;
            pointPlot.Marker.Type = NPlot.Marker.MarkerType.FilledCircle;

            plotSurface.Add (pointPlot, PlotSurface2D.XAxisPosition.Bottom, PlotSurface2D.YAxisPosition.Left);

            Font titleFont = new Font ("Arial", 12);
            Font axisFont = new Font ("Arial", 10);
            Font tickFont = new Font ("Arial", 8);

            plotSurface.XAxis1.Label = "Index";
            plotSurface.XAxis1.NumberFormat = "{0:0}";
            plotSurface.XAxis1.TicksLabelAngle = 0;
            plotSurface.XAxis1.TickTextNextToAxis = true;
            plotSurface.XAxis1.FlipTicksLabel = true;
            plotSurface.XAxis1.LabelOffset = 25;
            plotSurface.XAxis1.LabelOffsetAbsolute = true;
            plotSurface.XAxis1.LabelFont = axisFont;
            plotSurface.XAxis1.TickTextFont = tickFont;

            plotSurface.YAxis1.Label = "Mass (Mjup)";
            plotSurface.YAxis1.NumberFormat = "{0:0}";
            plotSurface.YAxis1.LabelFont = axisFont;
            plotSurface.YAxis1.TickTextFont = tickFont;

            if (IncludeLegend == true)
                {
                NPlot.Legend legend = new NPlot.Legend ();

                legend.AttachTo (PlotSurface2D.XAxisPosition.Top, PlotSurface2D.YAxisPosition.Right);
                legend.VerticalEdgePlacement = NPlot.Legend.Placement.Inside;
                legend.HorizontalEdgePlacement = NPlot.Legend.Placement.Outside;
                legend.BorderStyle = NPlot.LegendBase.BorderType.Line;
                plotSurface.Legend = legend;
                }

            plotSurface.Refresh ();
            }

        static public void VisualizeMassAndRadius (NPlot.Windows.PlotSurface2D plotSurface, ArrayList exoplanets)
            {
            ArrayList array = Helper.PlanetsWithMassAndRadius (exoplanets);

            double [] masses = new System.Double [array.Count];
            double [] radii = new System.Double [array.Count];
            int counter = 0;

            foreach (Exoplanet exoplanet in array)
                {
                double mass = 0.0, radius = 0.0;

                if (double.TryParse (exoplanet.Mass, out mass) == true)
                    if (double.TryParse (exoplanet.Radius, out radius) == true)
                        {
                        masses [counter] = mass;
                        radii [counter] = radius;
                        counter++;
                        }
                }

            plotSurface.Clear ();
            plotSurface.Title = "Mass & Radius Plot";
            plotSurface.BackColor = System.Drawing.Color.White;

            NPlot.Grid p = new Grid ();
            plotSurface.Add (p, PlotSurface2D.XAxisPosition.Bottom, PlotSurface2D.YAxisPosition.Left);

            PointPlot pointPlot = new PointPlot ();
            pointPlot.AbscissaData = masses;
            pointPlot.DataSource = radii;
            pointPlot.Label = "Radius (Rjup)";
            pointPlot.Marker.Color = System.Drawing.Color.Blue;
            pointPlot.Marker.Type = NPlot.Marker.MarkerType.FilledCircle;

            plotSurface.Add (pointPlot, PlotSurface2D.XAxisPosition.Bottom, PlotSurface2D.YAxisPosition.Left);

            Font titleFont = new Font ("Arial", 12);
            Font axisFont = new Font ("Arial", 10);
            Font tickFont = new Font ("Arial", 8);

            plotSurface.XAxis1.Label = "Mass (Mjup)";
            plotSurface.XAxis1.NumberFormat = "{0:0}";
            plotSurface.XAxis1.TicksLabelAngle = 0;
            plotSurface.XAxis1.TickTextNextToAxis = true;
            plotSurface.XAxis1.FlipTicksLabel = true;
            plotSurface.XAxis1.LabelOffset = 25;
            plotSurface.XAxis1.LabelOffsetAbsolute = true;
            plotSurface.XAxis1.LabelFont = axisFont;
            plotSurface.XAxis1.TickTextFont = tickFont;

            plotSurface.YAxis1.Label = "Radius (Rjup)";
            plotSurface.YAxis1.NumberFormat = "{0:0.0}";
            plotSurface.YAxis1.LabelFont = axisFont;
            plotSurface.YAxis1.TickTextFont = tickFont;

            if (IncludeLegend == true)
                {
                NPlot.Legend legend = new NPlot.Legend ();

                legend.AttachTo (PlotSurface2D.XAxisPosition.Top, PlotSurface2D.YAxisPosition.Right);
                legend.VerticalEdgePlacement = NPlot.Legend.Placement.Inside;
                legend.HorizontalEdgePlacement = NPlot.Legend.Placement.Outside;
                legend.BorderStyle = NPlot.LegendBase.BorderType.Line;
                plotSurface.Legend = legend;
                }

            plotSurface.Refresh ();
            }

        static public void VisualizeOrbitalPeriod (NPlot.Windows.PlotSurface2D plotSurface, ArrayList exoplanets)
            {
            ArrayList array = Helper.PlanetsWithOrbitalPeriods (exoplanets);

            double [] orbitalPeriods = new System.Double [array.Count];
            double [] indexes = new System.Double [array.Count];
            int counter = 0;

            foreach (Exoplanet exoplanet in array)
                {
                double orbitalPeriod = 0.0;

                if (double.TryParse (exoplanet.OrbitalPeriod, out orbitalPeriod) == true)
                    {
                    orbitalPeriods [counter] = orbitalPeriod;
                    indexes [counter] = counter + 1;
                    counter++;
                    }
                }

            plotSurface.Clear ();
            plotSurface.Title = "Orbital Period Plot";
            plotSurface.BackColor = System.Drawing.Color.White;

            NPlot.Grid p = new Grid ();
            plotSurface.Add (p, PlotSurface2D.XAxisPosition.Bottom, PlotSurface2D.YAxisPosition.Left);

            PointPlot pointPlot = new PointPlot ();
            pointPlot.AbscissaData = indexes;
            pointPlot.DataSource = orbitalPeriods;
            pointPlot.Label = "Index";
            pointPlot.Marker.Color = System.Drawing.Color.Blue;
            pointPlot.Marker.Type = NPlot.Marker.MarkerType.FilledCircle;

            plotSurface.Add (pointPlot, PlotSurface2D.XAxisPosition.Bottom, PlotSurface2D.YAxisPosition.Left);

            Font titleFont = new Font ("Arial", 12);
            Font axisFont = new Font ("Arial", 10);
            Font tickFont = new Font ("Arial", 8);

            plotSurface.XAxis1.Label = "Index";
            plotSurface.XAxis1.NumberFormat = "{0:0}";
            plotSurface.XAxis1.TicksLabelAngle = 0;
            plotSurface.XAxis1.TickTextNextToAxis = true;
            plotSurface.XAxis1.FlipTicksLabel = true;
            plotSurface.XAxis1.LabelOffset = 25;
            plotSurface.XAxis1.LabelOffsetAbsolute = true;
            plotSurface.XAxis1.LabelFont = axisFont;
            plotSurface.XAxis1.TickTextFont = tickFont;

            plotSurface.YAxis1.Label = "Orbital Period (day)";
            plotSurface.YAxis1.NumberFormat = "{0:0}";
            plotSurface.YAxis1.LabelFont = axisFont;
            plotSurface.YAxis1.TickTextFont = tickFont;

            if (IncludeLegend == true)
                {
                NPlot.Legend legend = new NPlot.Legend ();

                legend.AttachTo (PlotSurface2D.XAxisPosition.Top, PlotSurface2D.YAxisPosition.Right);
                legend.VerticalEdgePlacement = NPlot.Legend.Placement.Inside;
                legend.HorizontalEdgePlacement = NPlot.Legend.Placement.Outside;
                legend.BorderStyle = NPlot.LegendBase.BorderType.Line;
                plotSurface.Legend = legend;
                }

            plotSurface.Refresh ();
            }
        //static public void VisualizeStars (NPlot.Windows.PlotSurface2D plotSurface, ArrayList exoplanets)
        //    {
        //    //NPlot.Windows.PlotSurface2D plotSurface = new NPlot.Windows.PlotSurface2D ();

        //    PointPlot npPlot1 = new PointPlot ();
        //    //PointPlot npPlot2 = new PointPlot ();
        //    //PointPlot npPlot3 = new PointPlot ();

        //    //Font definitions:
        //    Font TitleFont = new Font ("Arial", 12);
        //    Font AxisFont = new Font ("Arial", 10);
        //    Font TickFont = new Font ("Arial", 8);

        //    //Legend definition:
        //    NPlot.Legend npLegend = new NPlot.Legend ();

        //    //DateTime [] X1 = new DateTime [50];
        //    //DateTime [] X2 = new DateTime [50];
        //    //int [] Y1 = new int [50];
        //    //int [] Y2 = new int [50];

        //    //Random r1 = new Random ();
        //    //Random r2 = new Random ();

        //    //for (int i = 0; i < 50; i++)
        //    //    {
        //    //    X1 [i] = DateTime.Now.Date.AddDays (i);
        //    //    X2 [i] = DateTime.Now.Date.AddDays (i);
        //    //    Y1 [i] = r1.Next (100);
        //    //    Y2 [i] = r2.Next (300);
        //    //    }
        //    double [] declination = new System.Double [2000];
        //    double [] accession = new System.Double [2000];
        //    int counter = 0;

        //    foreach (Exoplanet exoplanet in exoplanets)
        //        {
        //        if (exoplanet.Star.Declination != null)
        //            if (exoplanet.Star.RightAccession != null)
        //                {
        //                double dec = 0.0, ra = 0.0;

        //                if (double.TryParse (exoplanet.Star.Declination, out dec) == true)
        //                    if (double.TryParse (exoplanet.Star.RightAccession, out ra) == true)
        //                        {
        //                        declination [counter] = dec;
        //                        accession [counter] = ra;
        //                        counter++;
        //                        }

        //                }

        //        if (counter == 2000)
        //            break;
        //        }

        //    //Prepare PlotSurface:
        //    plotSurface.Clear ();
        //    plotSurface.Title = "Point Graph";
        //    plotSurface.BackColor = System.Drawing.Color.White;


        //    //Left Y axis grid:
        //    NPlot.Grid p = new Grid ();
        //    plotSurface.Add (p, NPlot.PlotSurface2D.XAxisPosition.Bottom, NPlot.PlotSurface2D.YAxisPosition.Left);

        //    npPlot1.AbscissaData = accession;// X1;
        //    npPlot1.DataSource = declination;//Y1
        //    npPlot1.Label = "Declination (dd:mm:ss)";
        //    npPlot1.Marker.Color = System.Drawing.Color.Blue;

        //    ////Weight:
        //    //npPlot1.AbscissaData = X1;
        //    //npPlot1.DataSource = Y1;
        //    //npPlot1.Label = "Declination (dd:mm:ss)";
        //    //npPlot1.Marker.Color = System.Drawing.Color.Blue;

        //    ////Height
        //    //npPlot2.AbscissaData = X2;
        //    //npPlot2.DataSource = Y2;
        //    //npPlot2.Label = "Right Accession (hh:mm:ss)";
        //    //npPlot2.Marker.Color = System.Drawing.Color.Green;


        //    plotSurface.Add (npPlot1, NPlot.PlotSurface2D.XAxisPosition.Bottom, NPlot.PlotSurface2D.YAxisPosition.Left);
        //    //plotSurface.Add (npPlot2, NPlot.PlotSurface2D.XAxisPosition.Bottom, NPlot.PlotSurface2D.YAxisPosition.Left);



        //    //X axis
        //    plotSurface.XAxis1.Label = "Right Accession (hh:mm:ss)";
        //    plotSurface.XAxis1.NumberFormat = "{0:0.0}"; //"yyyy-MM-dd";
        //    plotSurface.XAxis1.TicksLabelAngle = 90;
        //    plotSurface.XAxis1.TickTextNextToAxis = true;
        //    plotSurface.XAxis1.FlipTicksLabel = true;
        //    plotSurface.XAxis1.LabelOffset = 110;
        //    plotSurface.XAxis1.LabelOffsetAbsolute = true;
        //    plotSurface.XAxis1.LabelFont = AxisFont;
        //    plotSurface.XAxis1.TickTextFont = TickFont;


        //    //Y axis
        //    plotSurface.YAxis1.Label = "Declination (dd:mm:ss)";
        //    plotSurface.YAxis1.NumberFormat = "{0:0.0}";
        //    plotSurface.YAxis1.LabelFont = AxisFont;
        //    plotSurface.YAxis1.TickTextFont = TickFont;

        //    //Add legend:
        //    npLegend.AttachTo (NPlot.PlotSurface2D.XAxisPosition.Top, NPlot.PlotSurface2D.YAxisPosition.Right);
        //    npLegend.VerticalEdgePlacement = NPlot.Legend.Placement.Inside;
        //    npLegend.HorizontalEdgePlacement = NPlot.Legend.Placement.Outside;
        //    npLegend.BorderStyle = NPlot.LegendBase.BorderType.Line;
        //    plotSurface.Legend = npLegend;


        //    //Update PlotSurface:
        //    plotSurface.Refresh ();


        //    ////Save PlotSurface to MemoryStream, stream output as GIF file:
        //    //Response.Buffer = true;
        //    //Response.ContentType = "image/gif";

        //    //MemoryStream memStream = new MemoryStream ();

        //    //plotSurface.Bitmap.Save (memStream, System.Drawing.Imaging.ImageFormat.Gif);
        //    //memStream.WriteTo (Response.OutputStream);
        //    //Response.End ();
        //    }
        }

    }
