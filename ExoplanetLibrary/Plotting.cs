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

        static public void VisualizeMassAndRadius (NPlot.Windows.PlotSurface2D plotSurface, ArrayList exoplanets)
            {
            ArrayList array = Helper.PlanetsWithMassAndRadius(exoplanets);

            double[] masses = new System.Double[array.Count];
            double[] radii = new System.Double[array.Count];
            int counter = 0;

            foreach (Exoplanet exoplanet in array)
                {
                double mass = 0.0, radius = 0.0;

                if (double.TryParse(exoplanet.Mass, out mass) == true)
                    if (double.TryParse(exoplanet.Radius, out radius) == true)
                        {
                        masses[counter] = mass;
                        radii[counter] = radius;
                        counter++;
                        }
                }

            plotSurface.Clear();
            plotSurface.Title = "Mass & Radius Plot";
            plotSurface.BackColor = System.Drawing.Color.White;

            NPlot.Grid p = new Grid();
            plotSurface.Add(p, PlotSurface2D.XAxisPosition.Bottom, PlotSurface2D.YAxisPosition.Left);

            PointPlot pointPlot = new PointPlot();
            pointPlot.AbscissaData = masses;
            pointPlot.DataSource = radii;
            pointPlot.Label = "Radius (Rjup)";
            pointPlot.Marker.Color = System.Drawing.Color.Blue;
            pointPlot.Marker.Type = NPlot.Marker.MarkerType.FilledCircle;

            plotSurface.Add(pointPlot, PlotSurface2D.XAxisPosition.Bottom, PlotSurface2D.YAxisPosition.Left);

            Font titleFont = new Font("Arial", 12);
            Font axisFont = new Font("Arial", 10);
            Font tickFont = new Font("Arial", 8);

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
                NPlot.Legend legend = new NPlot.Legend();

                legend.AttachTo(PlotSurface2D.XAxisPosition.Top, PlotSurface2D.YAxisPosition.Right);
                legend.VerticalEdgePlacement = NPlot.Legend.Placement.Inside;
                legend.HorizontalEdgePlacement = NPlot.Legend.Placement.Outside;
                legend.BorderStyle = NPlot.LegendBase.BorderType.Line;
                plotSurface.Legend = legend;
                }

            plotSurface.Refresh();
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

            LinePlot linePlot = new LinePlot();
            linePlot.AbscissaData = indexes;
            linePlot.DataSource = radii;
            linePlot.Label = "Index";
            linePlot.Color = System.Drawing.Color.Blue;
            linePlot.Pen.Width = 2F;

            plotSurface.Add(linePlot, PlotSurface2D.XAxisPosition.Bottom, PlotSurface2D.YAxisPosition.Left);

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

            LinePlot linePlot = new LinePlot();
            linePlot.AbscissaData = indexes;
            linePlot.DataSource = masses;
            linePlot.Label = "Index";
            linePlot.Color = System.Drawing.Color.Blue;
            linePlot.Pen.Width = 2F;

            plotSurface.Add(linePlot, PlotSurface2D.XAxisPosition.Bottom, PlotSurface2D.YAxisPosition.Left);

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

            LinePlot linePlot = new LinePlot();
            linePlot.AbscissaData = indexes;
            linePlot.DataSource = orbitalPeriods;
            linePlot.Label = "Index";
            linePlot.Color = System.Drawing.Color.Blue;
            linePlot.Pen.Width = 2F;

            plotSurface.Add (linePlot, PlotSurface2D.XAxisPosition.Bottom, PlotSurface2D.YAxisPosition.Left);

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

        static public void VisualizeEccentricity (NPlot.Windows.PlotSurface2D plotSurface, ArrayList exoplanets)
            {
            ArrayList array = Helper.PlanetsWithEccentrity(exoplanets);

            double[] eccentricities = new System.Double[array.Count];
            double[] indexes = new System.Double[array.Count];
            int counter = 0;

            foreach (Exoplanet exoplanet in array)
                {
                double eccentricity = 0.0;

                if (double.TryParse(exoplanet.Eccentricity, out eccentricity) == true)
                    {
                    eccentricities[counter] = eccentricity;
                    indexes[counter] = counter + 1;
                    counter++;
                    }
                }

            plotSurface.Clear();
            plotSurface.Title = "Eccentricity Plot";
            plotSurface.BackColor = System.Drawing.Color.White;

            NPlot.Grid p = new Grid();
            plotSurface.Add(p, PlotSurface2D.XAxisPosition.Bottom, PlotSurface2D.YAxisPosition.Left);

            LinePlot linePlot = new LinePlot();
            linePlot.AbscissaData = indexes;
            linePlot.DataSource = eccentricities;
            linePlot.Label = "Index";
            linePlot.Color = System.Drawing.Color.Blue;
            linePlot.Pen.Width = 2F;

            plotSurface.Add(linePlot, PlotSurface2D.XAxisPosition.Bottom, PlotSurface2D.YAxisPosition.Left);

            Font titleFont = new Font("Arial", 12);
            Font axisFont = new Font("Arial", 10);
            Font tickFont = new Font("Arial", 8);

            plotSurface.XAxis1.Label = "Index";
            plotSurface.XAxis1.NumberFormat = "{0:0}";
            plotSurface.XAxis1.TicksLabelAngle = 0;
            plotSurface.XAxis1.TickTextNextToAxis = true;
            plotSurface.XAxis1.FlipTicksLabel = true;
            plotSurface.XAxis1.LabelOffset = 25;
            plotSurface.XAxis1.LabelOffsetAbsolute = true;
            plotSurface.XAxis1.LabelFont = axisFont;
            plotSurface.XAxis1.TickTextFont = tickFont;

            plotSurface.YAxis1.Label = "Eccentricity";
            plotSurface.YAxis1.NumberFormat = "{0:0.00}";
            plotSurface.YAxis1.LabelFont = axisFont;
            plotSurface.YAxis1.TickTextFont = tickFont;

            plotSurface.Refresh();
            }
        }
    }
