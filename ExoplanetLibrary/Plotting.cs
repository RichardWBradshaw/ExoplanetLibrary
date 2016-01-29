using NPlot;
using System.Drawing;
using System.Collections;
using System.Windows.Forms;

namespace ExoplanetLibrary
    {
    public enum ErrorBar
        {
        None = 0,
        VerticalLine = 1,
        VerticalNHorizontalLines = 2
        }

    enum PlotTypes
        {
        Default = 0,
        Mass = 1,
        Radius = 2,
        OrbitalPeriod = 3,
        SemiMajorAxis = 4,
        Eccentricity = 5,
        AngularDistance = 6,
        Inclination = 7,
        TzeroTr = 8,
        TzeroTrSec = 9,
        LambdaAngle = 10,
        TzeroVr = 11,
        TemperatureCalculated = 12,
        TemperatureMeasured = 13,
        LogG = 14,
        Omega = 15,
        Tperi = 16,
        K = 17,
        GeometricAlbedo = 18,
        Tconj = 19,
        MassAndRadius = 20,
        EccentricityAndMass = 21,
        Stars = 22,
        };

    public class Plotting
        {
        Plotting ()
            {
            }

        static private ErrorBar ErrorBars_ = ErrorBar.VerticalLine;
        static private ErrorBar ErrorBars
            {
            get { return ErrorBars_; }
            set { ErrorBars_ = value; }
            }

        static private Color LineColor_ = Color.Red;
        static private Color LineColor
            {
            get { return LineColor_; }
            set { LineColor_ = value; }
            }

        static private Color PointColor_ = Color.Black;
        static private Color PointColor
            {
            get { return PointColor_; }
            set { PointColor_ = value; }
            }

        static private Color BackgroundColor_ = BackgroundColor;
        static private Color BackgroundColor
            {
            get { return BackgroundColor_; }
            set { BackgroundColor_ = value; }
            }

        static private float LinePenWidth_ = 4F;
        static private float LinePenWidth
            {
            get { return LinePenWidth_; }
            set { LinePenWidth_ = value; }
            }

        static private int OnTopZOrder_ = 2;
        static private int OnTopZOrder
            {
            get { return OnTopZOrder_; }
            set { OnTopZOrder_ = value; }
            }

        static private double AlmostZero_ = 0.0001;
        static private double AlmostZero
            {
            get { return AlmostZero_; }
            set { AlmostZero_ = value; }
            }

        static public void VisualizeMass (NPlot.Windows.PlotSurface2D plotSurface, ArrayList exoplanets)
            {
            ArrayList array = Helper.PlanetsWithMass (exoplanets, false);

            double [] XAxis = new double [array.Count];
            double [] YAxis = new double [array.Count];
            int counter = 0;

            foreach (Exoplanet exoplanet in array)
                {
                double mass = 0.0;

                if (double.TryParse (exoplanet.Mass, out mass) == true)
                    {
                    YAxis [counter] = mass;
                    XAxis [counter] = counter + 1;
                    counter++;
                    }
                }

            plotSurface.Clear ();
            plotSurface.Title = "Mass Plot";
            plotSurface.BackColor = BackgroundColor;

            LinePlot linePlot = new LinePlot ();
            linePlot.AbscissaData = XAxis;
            linePlot.OrdinateData = YAxis;
            linePlot.Color = LineColor;
            linePlot.Pen.Width = LinePenWidth;
            plotSurface.Add (linePlot, PlotSurface2D.XAxisPosition.Bottom, PlotSurface2D.YAxisPosition.Left, OnTopZOrder);

            double minimumY = Helper.GetMinimum (YAxis);
            double maximumY = Helper.GetMaximum (YAxis);

            VisualizeMassErrorBars (plotSurface, array, ref minimumY, ref maximumY);
            VisualizeLogYAxis (plotSurface, "Index", "{0:0}", "Mass (Mjup)", "{0:0.0}", Visualization.LogYAxis, minimumY, maximumY);
            VisualizeLegend (plotSurface);

            AddInteraction (plotSurface);

            plotSurface.Refresh ();
            }

        static public void VisualizeMassErrorBars (NPlot.Windows.PlotSurface2D plotSurface, ArrayList array, ref double minimumY, ref double maximumY)
            {
            if (Visualization.IncludeErrorBars == CheckState.Checked)
                {
                int counter = 0;

                foreach (Exoplanet exoplanet in array)
                    {
                    double mass = 0.0, maximumError = 0.0, minimumError = 0.0;

                    if (double.TryParse (exoplanet.Mass, out mass) == true)
                        if (double.TryParse (exoplanet.MassErrorMax, out maximumError) == true)
                            if (double.TryParse (exoplanet.MassErrorMin, out minimumError) == true)
                                {
                                if (mass + maximumError > maximumY)
                                    maximumY = mass + maximumError;

                                if (mass - minimumError < minimumY)
                                    minimumY = mass - minimumError;

                                VisualizeErrorBar (plotSurface, mass, maximumError, -minimumError, counter);
                                }

                    ++counter;
                    }
                }
            }

        static public void VisualizeRadius (NPlot.Windows.PlotSurface2D plotSurface, ArrayList exoplanets)
            {
            ArrayList array = Helper.PlanetsWithRadius (exoplanets, false);

            double [] XAxis = new double [array.Count];
            double [] YAxis = new double [array.Count];
            int counter = 0;

            foreach (Exoplanet exoplanet in array)
                {
                double radius = 0.0;

                if (double.TryParse (exoplanet.Radius, out radius) == true)
                    {
                    YAxis [counter] = radius;
                    XAxis [counter] = counter + 1;
                    counter++;
                    }
                }

            plotSurface.Clear ();
            plotSurface.Title = "Radius Plot";
            plotSurface.BackColor = BackgroundColor;

            LinePlot linePlot = new LinePlot ();
            linePlot.AbscissaData = XAxis;
            linePlot.DataSource = YAxis;
            linePlot.Color = LineColor;
            linePlot.Pen.Width = LinePenWidth;

            plotSurface.Add (linePlot, PlotSurface2D.XAxisPosition.Bottom, PlotSurface2D.YAxisPosition.Left, OnTopZOrder);

            double minimumY = Helper.GetMinimum (YAxis);
            double maximumY = Helper.GetMaximum (YAxis);

            VisualizeRadiusErrorBars (plotSurface, array, ref minimumY, ref maximumY);
            VisualizeLogYAxis (plotSurface, "Index", "{0:0}", "Radius (Rjup)", "{0:0.0}", Visualization.LogYAxis, minimumY, maximumY);
            VisualizeLegend (plotSurface);

            AddInteraction (plotSurface);

            plotSurface.Refresh ();
            }

        static public void VisualizeRadiusErrorBars (NPlot.Windows.PlotSurface2D plotSurface, ArrayList array, ref double minimumY, ref double maximumY)
            {
            if (Visualization.IncludeErrorBars == CheckState.Checked)
                {
                int counter = 0;

                foreach (Exoplanet exoplanet in array)
                    {
                    double radius = 0.0, maximumError = 0.0, minimumError = 0.0;

                    if (double.TryParse (exoplanet.Radius, out radius) == true)
                        if (double.TryParse (exoplanet.RadiusErrorMax, out maximumError) == true)
                            if (double.TryParse (exoplanet.RadiusErrorMin, out minimumError) == true)
                                {
                                if (radius + maximumError > maximumY)
                                    maximumY = radius + maximumError;

                                if (radius - minimumError < minimumY)
                                    minimumY = radius - minimumError;

                                VisualizeErrorBar (plotSurface, radius, maximumError, -minimumError, counter);
                                }

                    ++counter;
                    }
                }
            }

        static public void VisualizeOrbitalPeriod (NPlot.Windows.PlotSurface2D plotSurface, ArrayList exoplanets)
            {
            ArrayList array = Helper.PlanetsWithOrbitalPeriods (exoplanets, false);

            double [] XAxis = new double [array.Count];
            double [] YAxis = new double [array.Count];
            int counter = 0;

            foreach (Exoplanet exoplanet in array)
                {
                double orbitalPeriod = 0.0;

                if (double.TryParse (exoplanet.OrbitalPeriod, out orbitalPeriod) == true)
                    {
                    YAxis [counter] = orbitalPeriod;
                    XAxis [counter] = counter + 1;
                    counter++;
                    }
                }

            plotSurface.Clear ();
            plotSurface.Title = "Orbital Period Plot";
            plotSurface.BackColor = BackgroundColor;

            LinePlot linePlot = new LinePlot ();
            linePlot.AbscissaData = XAxis;
            linePlot.DataSource = YAxis;
            linePlot.Color = LineColor;
            linePlot.Pen.Width = LinePenWidth;

            plotSurface.Add (linePlot, PlotSurface2D.XAxisPosition.Bottom, PlotSurface2D.YAxisPosition.Left, OnTopZOrder);

            double minimumY = Helper.GetMinimum (YAxis);
            double maximumY = Helper.GetMaximum (YAxis);

            VisualizeOrbitalPeriodErrorBars (plotSurface, array, ref minimumY, ref maximumY);
            VisualizeLogYAxis (plotSurface, "Index", "{0:0}", "Orbital Period (day)", "{0:0.0}", Visualization.LogYAxis, minimumY, maximumY);
            VisualizeLegend (plotSurface);

            AddInteraction (plotSurface);

            plotSurface.Refresh ();
            }

        static public void VisualizeOrbitalPeriodErrorBars (NPlot.Windows.PlotSurface2D plotSurface, ArrayList array, ref double minimumY, ref double maximumY)
            {
            if (Visualization.IncludeErrorBars == CheckState.Checked)
                {
                int counter = 0;

                foreach (Exoplanet exoplanet in array)
                    {
                    double orbitalPeriod = 0.0, maximumError = 0.0, minimumError = 0.0;

                    if (double.TryParse (exoplanet.OrbitalPeriod, out orbitalPeriod) == true)
                        if (double.TryParse (exoplanet.OrbitalPeriodErrorMax, out maximumError) == true)
                            if (double.TryParse (exoplanet.OrbitalPeriodErrorMin, out minimumError) == true)
                                {
                                if (orbitalPeriod + maximumError > maximumY)
                                    maximumY = orbitalPeriod + maximumError;

                                if (orbitalPeriod - minimumError < minimumY)
                                    minimumY = orbitalPeriod - minimumError;

                                VisualizeErrorBar (plotSurface, orbitalPeriod, maximumError, -minimumError, counter);
                                }

                    ++counter;
                    }
                }
            }

        static public void VisualizeSemiMajorAxis (NPlot.Windows.PlotSurface2D plotSurface, ArrayList exoplanets)
            {
            ArrayList array = Helper.PlanetsWithSemiMajorAxis (exoplanets, false);

            double [] XAxis = new double [array.Count];
            double [] YAxis = new double [array.Count];
            int counter = 0;

            foreach (Exoplanet exoplanet in array)
                {
                double semiMajorAxis = 0.0;

                if (double.TryParse (exoplanet.SemiMajorAxis, out semiMajorAxis) == true)
                    {
                    YAxis [counter] = semiMajorAxis;
                    XAxis [counter] = counter + 1;
                    counter++;
                    }
                }

            plotSurface.Clear ();
            plotSurface.Title = "Semi-major Axis Plot";
            plotSurface.BackColor = BackgroundColor;

            LinePlot linePlot = new LinePlot ();
            linePlot.AbscissaData = XAxis;
            linePlot.DataSource = YAxis;
            linePlot.Color = LineColor;
            linePlot.Pen.Width = LinePenWidth;

            plotSurface.Add (linePlot, PlotSurface2D.XAxisPosition.Bottom, PlotSurface2D.YAxisPosition.Left, OnTopZOrder);

            double minimumY = Helper.GetMinimum (YAxis);
            double maximumY = Helper.GetMaximum (YAxis);

            VisualizeSemiMajorAxisErrorBars (plotSurface, array, ref minimumY, ref maximumY);
            VisualizeLogYAxis (plotSurface, "Index", "{0:0}", "Semi-major Axis (AU)", "{0:0.00}", Visualization.LogYAxis, minimumY, maximumY);
            VisualizeLegend (plotSurface);

            AddInteraction (plotSurface);

            plotSurface.Refresh ();
            }

        static public void VisualizeSemiMajorAxisErrorBars (NPlot.Windows.PlotSurface2D plotSurface, ArrayList array, ref double minimumY, ref double maximumY)
            {
            if (Visualization.IncludeErrorBars == CheckState.Checked)
                {
                int counter = 0;

                foreach (Exoplanet exoplanet in array)
                    {
                    double semiMajorAxis = 0.0, maximumError = 0.0, minimumError = 0.0;

                    if (double.TryParse (exoplanet.SemiMajorAxis, out semiMajorAxis) == true)
                        if (double.TryParse (exoplanet.SemiMajorAxisErrorMax, out maximumError) == true)
                            if (double.TryParse (exoplanet.SemiMajorAxisErrorMin, out minimumError) == true)
                                {
                                if (semiMajorAxis + maximumError > maximumY)
                                    maximumY = semiMajorAxis + maximumError;

                                if (semiMajorAxis - minimumError < minimumY)
                                    minimumY = semiMajorAxis - minimumError;

                                VisualizeErrorBar (plotSurface, semiMajorAxis, maximumError, -minimumError, counter);
                                }

                    ++counter;
                    }
                }
            }

        static public void VisualizeEccentricity (NPlot.Windows.PlotSurface2D plotSurface, ArrayList exoplanets)
            {
            ArrayList array = Helper.PlanetsWithEccentrity (exoplanets, false);

            double [] XAxis = new double [array.Count];
            double [] YAxis = new double [array.Count];
            int counter = 0;

            foreach (Exoplanet exoplanet in array)
                {
                double eccentricity = 0.0;

                if (double.TryParse (exoplanet.Eccentricity, out eccentricity) == true)
                    {
                    YAxis [counter] = eccentricity;
                    XAxis [counter] = counter + 1;
                    counter++;
                    }
                }

            plotSurface.Clear ();
            plotSurface.Title = "Eccentricity Plot";
            plotSurface.BackColor = BackgroundColor;

            LinePlot linePlot = new LinePlot ();
            linePlot.AbscissaData = XAxis;
            linePlot.DataSource = YAxis;
            linePlot.Color = LineColor;
            linePlot.Pen.Width = LinePenWidth;

            plotSurface.Add (linePlot, PlotSurface2D.XAxisPosition.Bottom, PlotSurface2D.YAxisPosition.Left, OnTopZOrder);

            double minimumY = Helper.GetMinimum (YAxis);
            double maximumY = Helper.GetMaximum (YAxis);

            VisualizeEccentricityErrorBars (plotSurface, array, ref minimumY, ref maximumY);
            VisualizeLogYAxis (plotSurface, "Index", "{0:0}", "Eccentricity", "{0:0.00}", Visualization.LogYAxis, minimumY, maximumY);
            VisualizeLegend (plotSurface);

            AddInteraction (plotSurface);

            plotSurface.Refresh ();
            }

        static public void VisualizeEccentricityErrorBars (NPlot.Windows.PlotSurface2D plotSurface, ArrayList array, ref double minimumY, ref double maximumY)
            {
            if (Visualization.IncludeErrorBars == CheckState.Checked)
                {
                int counter = 0;

                foreach (Exoplanet exoplanet in array)
                    {
                    double eccentricity = 0.0, maximumError = 0.0, minimumError = 0.0;

                    if (double.TryParse (exoplanet.Eccentricity, out eccentricity) == true)
                        if (double.TryParse (exoplanet.EccentricityErrorMax, out maximumError) == true)
                            if (double.TryParse (exoplanet.EccentricityErrorMin, out minimumError) == true)
                                {
                                if (maximumError < 10.0 * eccentricity) // kludge for bad data
                                    {
                                    if (eccentricity + maximumError > maximumY)
                                        maximumY = eccentricity + maximumError;

                                    if (eccentricity - minimumError < minimumY)
                                        minimumY = eccentricity - minimumError;

                                    VisualizeErrorBar (plotSurface, eccentricity, maximumError, -minimumError, counter);
                                    }
                                }

                    ++counter;
                    }
                }
            }

        static public void VisualizeAngularDistance (NPlot.Windows.PlotSurface2D plotSurface, ArrayList exoplanets)
            {
            ArrayList array = Helper.PlanetsWithAngularDistance (exoplanets);

            double [] XAxis = new double [array.Count];
            double [] YAxis = new double [array.Count];
            int counter = 0;

            foreach (Exoplanet exoplanet in array)
                {
                double angularDistance = 0.0;

                if (double.TryParse (exoplanet.AngularDistance, out angularDistance) == true)
                    {
                    YAxis [counter] = angularDistance;
                    XAxis [counter] = counter + 1;
                    counter++;
                    }
                }

            plotSurface.Clear ();
            plotSurface.Title = "Angular Distance Plot";
            plotSurface.BackColor = BackgroundColor;

            LinePlot linePlot = new LinePlot ();
            linePlot.AbscissaData = XAxis;
            linePlot.DataSource = YAxis;
            linePlot.Color = LineColor;
            linePlot.Pen.Width = LinePenWidth;

            plotSurface.Add (linePlot, PlotSurface2D.XAxisPosition.Bottom, PlotSurface2D.YAxisPosition.Left);

            double minimumY = Helper.GetMinimum (YAxis);
            double maximumY = Helper.GetMaximum (YAxis);

            VisualizeLogYAxis (plotSurface, "Index", "{0:0}", "Angular Distance", "{0:0.00}", Visualization.LogYAxis, minimumY, maximumY);
            VisualizeLegend (plotSurface);

            AddInteraction (plotSurface);

            plotSurface.Refresh ();
            }

        static public void VisualizeInclination (NPlot.Windows.PlotSurface2D plotSurface, ArrayList exoplanets)
            {
            ArrayList array = Helper.PlanetsWithInclination (exoplanets, false);

            double [] XAxis = new double [array.Count];
            double [] YAxis = new double [array.Count];
            int counter = 0;

            foreach (Exoplanet exoplanet in array)
                {
                double inclination = 0.0;

                if (double.TryParse (exoplanet.Inclination, out inclination) == true)
                    {
                    YAxis [counter] = inclination;
                    XAxis [counter] = counter + 1;
                    counter++;
                    }
                }

            plotSurface.Clear ();
            plotSurface.Title = "Inclination Plot";
            plotSurface.BackColor = BackgroundColor;

            LinePlot linePlot = new LinePlot ();
            linePlot.AbscissaData = XAxis;
            linePlot.DataSource = YAxis;
            linePlot.Color = LineColor;
            linePlot.Pen.Width = LinePenWidth;

            plotSurface.Add (linePlot, PlotSurface2D.XAxisPosition.Bottom, PlotSurface2D.YAxisPosition.Left, OnTopZOrder);

            double minimumY = Helper.GetMinimum (YAxis);
            double maximumY = Helper.GetMaximum (YAxis);

            VisualizeInclinationErrorBars (plotSurface, array, ref minimumY, ref maximumY);
            VisualizeLogYAxis (plotSurface, "Index", "{0:0}", "Inclination (deg)", "{0:0.00}", Visualization.LogYAxis, minimumY, maximumY);
            VisualizeLegend (plotSurface);

            AddInteraction (plotSurface);

            plotSurface.Refresh ();
            }

        static public void VisualizeInclinationErrorBars (NPlot.Windows.PlotSurface2D plotSurface, ArrayList array, ref double minimumY, ref double maximumY)
            {
            if (Visualization.IncludeErrorBars == CheckState.Checked)
                {
                int counter = 0;

                foreach (Exoplanet exoplanet in array)
                    {
                    double inclination = 0.0, maximumError = 0.0, minimumError = 0.0;

                    if (double.TryParse (exoplanet.Inclination, out inclination) == true)
                        if (double.TryParse (exoplanet.InclinationErrorMax, out maximumError) == true)
                            if (double.TryParse (exoplanet.InclinationErrorMin, out minimumError) == true)
                                {
                                if (inclination + maximumError > maximumY)
                                    maximumY = inclination + maximumError;

                                if (inclination - minimumError < minimumY)
                                    minimumY = inclination - minimumError;

                                VisualizeErrorBar (plotSurface, inclination, maximumError, -minimumError, counter);
                                }

                    ++counter;
                    }
                }
            }

        static public void VisualizeTzeroTr (NPlot.Windows.PlotSurface2D plotSurface, ArrayList exoplanets)
            {
            ArrayList array = Helper.PlanetsWithTzeroTr (exoplanets, false);

            double [] XAxis = new double [array.Count];
            double [] YAxis = new double [array.Count];
            int counter = 0;

            foreach (Exoplanet exoplanet in array)
                {
                double t0 = 0.0;

                if (double.TryParse (exoplanet.TzeroTr, out t0) == true)
                    {
                    YAxis [counter] = t0;
                    XAxis [counter] = counter + 1;
                    counter++;
                    }
                }

            plotSurface.Clear ();
            plotSurface.Title = "T0 Plot";
            plotSurface.BackColor = BackgroundColor;

            LinePlot linePlot = new LinePlot ();
            linePlot.AbscissaData = XAxis;
            linePlot.DataSource = YAxis;
            linePlot.Color = LineColor;
            linePlot.Pen.Width = LinePenWidth;

            plotSurface.Add (linePlot, PlotSurface2D.XAxisPosition.Bottom, PlotSurface2D.YAxisPosition.Left, OnTopZOrder);

            double minimumY = Helper.GetMinimum (YAxis);
            double maximumY = Helper.GetMaximum (YAxis);

            VisualizeTzeroTrErrorBars (plotSurface, array, ref minimumY, ref maximumY);
            VisualizeLogYAxis (plotSurface, "Index", "{0:0}", "T0 (JD)", "{0:0.00}", Visualization.LogYAxis, minimumY, maximumY);
            VisualizeLegend (plotSurface);

            AddInteraction (plotSurface);

            plotSurface.Refresh ();
            }

        static public void VisualizeTzeroTrErrorBars (NPlot.Windows.PlotSurface2D plotSurface, ArrayList array, ref double minimumY, ref double maximumY)
            {
            if (Visualization.IncludeErrorBars == CheckState.Checked)
                {
                int counter = 0;

                foreach (Exoplanet exoplanet in array)
                    {
                    double tzerotr = 0.0, maximumError = 0.0, minimumError = 0.0;

                    if (double.TryParse (exoplanet.TzeroTr, out tzerotr) == true)
                        if (double.TryParse (exoplanet.TzeroTrErrorMax, out maximumError) == true)
                            if (double.TryParse (exoplanet.TzeroTrErrorMin, out minimumError) == true)
                                {
                                if (tzerotr + maximumError > maximumY)
                                    maximumY = tzerotr + maximumError;

                                if (tzerotr - minimumError < minimumY)
                                    minimumY = tzerotr - minimumError;

                                VisualizeErrorBar (plotSurface, tzerotr, maximumError, -minimumError, counter);
                                }

                    ++counter;
                    }
                }
            }

        static public void VisualizeTzeroTrSec (NPlot.Windows.PlotSurface2D plotSurface, ArrayList exoplanets)
            {
            ArrayList array = Helper.PlanetsWithTzeroTrSec (exoplanets, false);

            double [] XAxis = new double [array.Count];
            double [] YAxis = new double [array.Count];
            int counter = 0;

            foreach (Exoplanet exoplanet in array)
                {
                double t0 = 0.0;

                if (double.TryParse (exoplanet.TzeroTrSec, out t0) == true)
                    {
                    YAxis [counter] = t0;
                    XAxis [counter] = counter + 1;
                    counter++;
                    }
                }

            plotSurface.Clear ();
            plotSurface.Title = "T0-Sec Plot";
            plotSurface.BackColor = BackgroundColor;

            LinePlot linePlot = new LinePlot ();
            linePlot.AbscissaData = XAxis;
            linePlot.DataSource = YAxis;
            linePlot.Color = LineColor;
            linePlot.Pen.Width = LinePenWidth;

            plotSurface.Add (linePlot, PlotSurface2D.XAxisPosition.Bottom, PlotSurface2D.YAxisPosition.Left, OnTopZOrder);

            double minimumY = Helper.GetMinimum (YAxis);
            double maximumY = Helper.GetMaximum (YAxis);

            VisualizeTzeroTrSecErrorBars (plotSurface, array, ref minimumY, ref maximumY);
            VisualizeLogYAxis (plotSurface, "Index", "{0:0.0}", "T0-Sec (JD)", "{0:0.00}", Visualization.LogYAxis, minimumY, maximumY);
            VisualizeLegend (plotSurface);

            AddInteraction (plotSurface);

            plotSurface.Refresh ();
            }

        static public void VisualizeTzeroTrSecErrorBars (NPlot.Windows.PlotSurface2D plotSurface, ArrayList array, ref double minimumY, ref double maximumY)
            {
            if (Visualization.IncludeErrorBars == CheckState.Checked)
                {
                int counter = 0;

                foreach (Exoplanet exoplanet in array)
                    {
                    double tzeroTrSec = 0.0, maximumError = 0.0, minimumError = 0.0;

                    if (double.TryParse (exoplanet.TzeroTrSec, out tzeroTrSec) == true)
                        if (double.TryParse (exoplanet.TzeroTrSecErrorMax, out maximumError) == true)
                            if (double.TryParse (exoplanet.TzeroTrSecErrorMin, out minimumError) == true)
                                {
                                if (tzeroTrSec + maximumError > maximumY)
                                    maximumY = tzeroTrSec + maximumError;

                                if (tzeroTrSec - minimumError < minimumY)
                                    minimumY = tzeroTrSec - minimumError;

                                VisualizeErrorBar (plotSurface, tzeroTrSec, maximumError, -minimumError, counter);
                                }

                    ++counter;
                    }
                }
            }

        static public void VisualizeLambdaAngle (NPlot.Windows.PlotSurface2D plotSurface, ArrayList exoplanets)
            {
            ArrayList array = Helper.PlanetsWithLambdaAngle (exoplanets, false);

            double [] XAxis = new double [array.Count];
            double [] YAxis = new double [array.Count];
            int counter = 0;

            foreach (Exoplanet exoplanet in array)
                {
                double lambdaAngle = 0.0;

                if (double.TryParse (exoplanet.LambdaAngle, out lambdaAngle) == true)
                    {
                    XAxis [counter] = lambdaAngle;
                    YAxis [counter] = counter + 1;
                    counter++;
                    }
                }

            plotSurface.Clear ();
            plotSurface.Title = "Lambda Angle Plot";
            plotSurface.BackColor = BackgroundColor;

            LinePlot linePlot = new LinePlot ();
            linePlot.AbscissaData = YAxis;
            linePlot.DataSource = XAxis;
            linePlot.Color = LineColor;
            linePlot.Pen.Width = LinePenWidth;

            plotSurface.Add (linePlot, PlotSurface2D.XAxisPosition.Bottom, PlotSurface2D.YAxisPosition.Left, OnTopZOrder);

            double minimumY = Helper.GetMinimum (YAxis);
            double maximumY = Helper.GetMaximum (YAxis);

            VisualizeLambdaAngleErrorBars (plotSurface, array, ref minimumY, ref maximumY);
            VisualizeLogYAxis (plotSurface, "Index", "{0:0}", "Lambda Angle (deg)", "{0:0.00}", Visualization.LogYAxis, minimumY, maximumY);
            VisualizeLegend (plotSurface);

            AddInteraction (plotSurface);

            plotSurface.Refresh ();
            }

        static public void VisualizeLambdaAngleErrorBars (NPlot.Windows.PlotSurface2D plotSurface, ArrayList array, ref double minimumY, ref double maximumY)
            {
            if (Visualization.IncludeErrorBars == CheckState.Checked)
                {
                int counter = 0;

                foreach (Exoplanet exoplanet in array)
                    {
                    double lambdaAngle = 0.0, maximumError = 0.0, minimumError = 0.0;

                    if (double.TryParse (exoplanet.LambdaAngle, out lambdaAngle) == true)
                        if (double.TryParse (exoplanet.LambdaAngleErrorMax, out maximumError) == true)
                            if (double.TryParse (exoplanet.LambdaAngleErrorMin, out minimumError) == true)
                                {
                                if (lambdaAngle + maximumError > maximumY)
                                    maximumY = lambdaAngle + maximumError;

                                if (lambdaAngle - minimumError < minimumY)
                                    minimumY = lambdaAngle - minimumError;

                                VisualizeErrorBar (plotSurface, lambdaAngle, maximumError, -minimumError, counter);
                                }

                    ++counter;
                    }
                }
            }

        static public void VisualizeTzeroVr (NPlot.Windows.PlotSurface2D plotSurface, ArrayList exoplanets)
            {
            ArrayList array = Helper.PlanetsWithTzeroVr (exoplanets, false);

            double [] XAxis = new double [array.Count];
            double [] YAxis = new double [array.Count];
            int counter = 0;

            foreach (Exoplanet exoplanet in array)
                {
                double tzeroVr = 0.0;

                if (double.TryParse (exoplanet.TzeroTr, out tzeroVr) == true)
                    {
                    YAxis [counter] = tzeroVr;
                    XAxis [counter] = counter + 1;
                    counter++;
                    }
                }

            plotSurface.Clear ();
            plotSurface.Title = "TVR Plot";
            plotSurface.BackColor = BackgroundColor;

            LinePlot linePlot = new LinePlot ();
            linePlot.AbscissaData = XAxis;
            linePlot.DataSource = YAxis;
            linePlot.Color = LineColor;
            linePlot.Pen.Width = LinePenWidth;

            plotSurface.Add (linePlot, PlotSurface2D.XAxisPosition.Bottom, PlotSurface2D.YAxisPosition.Left, OnTopZOrder);

            double minimumY = Helper.GetMinimum (YAxis);
            double maximumY = Helper.GetMaximum (YAxis);

            VisualizeTzeroVrErrorBars (plotSurface, array, ref minimumY, ref maximumY);
            VisualizeLogYAxis (plotSurface, "Index", "{0:0}", "TVR (JD)", "{0:0.00}", Visualization.LogYAxis, minimumY, maximumY);
            VisualizeLegend (plotSurface);

            AddInteraction (plotSurface);

            plotSurface.Refresh ();
            }

        static public void VisualizeTzeroVrErrorBars (NPlot.Windows.PlotSurface2D plotSurface, ArrayList array, ref double minimumY, ref double maximumY)
            {
            if (Visualization.IncludeErrorBars == CheckState.Checked)
                {
                int counter = 0;

                foreach (Exoplanet exoplanet in array)
                    {
                    double tzeroVr = 0.0, maximumError = 0.0, minimumError = 0.0;

                    if (double.TryParse (exoplanet.TzeroVr, out tzeroVr) == true)
                        if (double.TryParse (exoplanet.TzeroVrErrorMax, out maximumError) == true)
                            if (double.TryParse (exoplanet.TzeroVrErrorMin, out minimumError) == true)
                                {
                                if (tzeroVr + maximumError > maximumY)
                                    maximumY = tzeroVr + maximumError;

                                if (tzeroVr - minimumError < minimumY)
                                    minimumY = tzeroVr - minimumError;

                                VisualizeErrorBar (plotSurface, tzeroVr, maximumError, -minimumError, counter);
                                }

                    ++counter;
                    }
                }
            }

        static public void VisualizeTemperatureCalculated (NPlot.Windows.PlotSurface2D plotSurface, ArrayList exoplanets)
            {
            ArrayList array = Helper.PlanetsWithTemperatureCalculated (exoplanets);

            double [] XAxis = new double [array.Count];
            double [] YAxis = new double [array.Count];
            int counter = 0;

            foreach (Exoplanet exoplanet in array)
                {
                double temperature = 0.0;

                if (double.TryParse (exoplanet.TemperatureCalculated, out temperature) == true)
                    {
                    YAxis [counter] = temperature;
                    XAxis [counter] = counter + 1;
                    counter++;
                    }
                }

            plotSurface.Clear ();
            plotSurface.Title = "Temperature Calculated Plot";
            plotSurface.BackColor = BackgroundColor;

            LinePlot linePlot = new LinePlot ();
            linePlot.AbscissaData = XAxis;
            linePlot.DataSource = YAxis;
            linePlot.Color = LineColor;
            linePlot.Pen.Width = LinePenWidth;

            plotSurface.Add (linePlot, PlotSurface2D.XAxisPosition.Bottom, PlotSurface2D.YAxisPosition.Left, OnTopZOrder);

            double minimumY = Helper.GetMinimum (YAxis);
            double maximumY = Helper.GetMaximum (YAxis);

            VisualizeLogYAxis (plotSurface, "Index", "{0:0}", "Temperature Calculated (K)", "{0:0}", Visualization.LogYAxis, minimumY, maximumY);
            VisualizeLegend (plotSurface);

            AddInteraction (plotSurface);

            plotSurface.Refresh ();
            }

        static public void VisualizeTemperatureMeasured (NPlot.Windows.PlotSurface2D plotSurface, ArrayList exoplanets)
            {
            ArrayList array = Helper.PlanetsWithTemperatureMeasured (exoplanets);

            double [] XAxis = new double [array.Count];
            double [] YAxis = new double [array.Count];
            int counter = 0;

            foreach (Exoplanet exoplanet in array)
                {
                double temperature = 0.0;

                if (double.TryParse (exoplanet.TemperatureMeasured, out temperature) == true)
                    {
                    YAxis [counter] = temperature;
                    XAxis [counter] = counter + 1;
                    counter++;
                    }
                }

            plotSurface.Clear ();
            plotSurface.Title = "Temperature Measured Plot";
            plotSurface.BackColor = BackgroundColor;

            LinePlot linePlot = new LinePlot ();
            linePlot.AbscissaData = XAxis;
            linePlot.DataSource = YAxis;
            linePlot.Color = LineColor;
            linePlot.Pen.Width = LinePenWidth;

            plotSurface.Add (linePlot, PlotSurface2D.XAxisPosition.Bottom, PlotSurface2D.YAxisPosition.Left, OnTopZOrder);

            double minimumY = Helper.GetMinimum (YAxis);
            double maximumY = Helper.GetMaximum (YAxis);

            VisualizeLogYAxis (plotSurface, "Index", "{0:0}", "Temperature Measured (K)", "{0:0}", Visualization.LogYAxis, minimumY, maximumY);
            VisualizeLegend (plotSurface);

            AddInteraction (plotSurface);

            plotSurface.Refresh ();
            }

        static public void VisualizeLogG (NPlot.Windows.PlotSurface2D plotSurface, ArrayList exoplanets)
            {
            ArrayList array = Helper.PlanetsWithLogG (exoplanets);

            double [] XAxis = new double [array.Count];
            double [] YAxis = new double [array.Count];
            int counter = 0;

            foreach (Exoplanet exoplanet in array)
                {
                double logG = 0.0;

                if (double.TryParse (exoplanet.LogG, out logG) == true)
                    {
                    YAxis [counter] = logG;
                    XAxis [counter] = counter + 1;
                    counter++;
                    }
                }

            plotSurface.Clear ();
            plotSurface.Title = "Log(g) Plot";
            plotSurface.BackColor = BackgroundColor;

            LinePlot linePlot = new LinePlot ();
            linePlot.AbscissaData = XAxis;
            linePlot.DataSource = YAxis;
            linePlot.Color = LineColor;
            linePlot.Pen.Width = LinePenWidth;

            plotSurface.Add (linePlot, PlotSurface2D.XAxisPosition.Bottom, PlotSurface2D.YAxisPosition.Left, OnTopZOrder);

            double minimumX = Helper.GetMinimum (XAxis);
            double maximumX = Helper.GetMaximum (XAxis);
            double minimumY = Helper.GetMinimum (YAxis);
            double maximumY = Helper.GetMaximum (YAxis);

            VisualizeLogYAxis (plotSurface, "Index", "{0:0}", "Log(g)", "{0:0.00}", Visualization.LogYAxis, minimumY, maximumY);
            VisualizeLegend (plotSurface);

            AddInteraction (plotSurface);

            plotSurface.Refresh ();
            }

        static public void VisualizeOmega (NPlot.Windows.PlotSurface2D plotSurface, ArrayList exoplanets)
            {
            ArrayList array = Helper.PlanetsWithOmega (exoplanets, false);

            double [] XAxis = new double [array.Count];
            double [] YAxis = new double [array.Count];
            int counter = 0;

            foreach (Exoplanet exoplanet in array)
                {
                double omega = 0.0;

                if (double.TryParse (exoplanet.Omega, out omega) == true)
                    {
                    YAxis [counter] = omega;
                    XAxis [counter] = counter + 1;
                    counter++;
                    }
                }

            plotSurface.Clear ();
            plotSurface.Title = "Omega Plot";
            plotSurface.BackColor = BackgroundColor;

            LinePlot linePlot = new LinePlot ();
            linePlot.AbscissaData = XAxis;
            linePlot.DataSource = YAxis;
            linePlot.Color = LineColor;
            linePlot.Pen.Width = LinePenWidth;

            plotSurface.Add (linePlot, PlotSurface2D.XAxisPosition.Bottom, PlotSurface2D.YAxisPosition.Left, OnTopZOrder);

            double minimumY = Helper.GetMinimum (YAxis);
            double maximumY = Helper.GetMaximum (YAxis);

            VisualizeOmegaErrorBars (plotSurface, array, ref minimumY, ref maximumY);
            VisualizeLogYAxis (plotSurface, "Index", "{0:0}", "Omega (deg)", "{0:0.00}", Visualization.LogYAxis, minimumY, maximumY);
            VisualizeLegend (plotSurface);

            AddInteraction (plotSurface);

            plotSurface.Refresh ();
            }

        static public void VisualizeOmegaErrorBars (NPlot.Windows.PlotSurface2D plotSurface, ArrayList array, ref double minimumY, ref double maximumY)
            {
            if (Visualization.IncludeErrorBars == CheckState.Checked)
                {
                int counter = 0;

                foreach (Exoplanet exoplanet in array)
                    {
                    double omega = 0.0, maximumError = 0.0, minimumError = 0.0;

                    if (double.TryParse (exoplanet.Omega, out omega) == true)
                        if (double.TryParse (exoplanet.OmegaErrorMax, out maximumError) == true)
                            if (double.TryParse (exoplanet.OmegaErrorMin, out minimumError) == true)
                                {
                                if (omega + maximumError > maximumY)
                                    maximumY = omega + maximumError;

                                if (omega - minimumError < minimumY)
                                    minimumY = omega - minimumError;

                                VisualizeErrorBar (plotSurface, omega, maximumError, -minimumError, counter);
                                }

                    ++counter;
                    }
                }
            }

        static public void VisualizeTperi (NPlot.Windows.PlotSurface2D plotSurface, ArrayList exoplanets)
            {
            ArrayList array = Helper.PlanetsWithTperi (exoplanets, false);

            double [] XAxis = new double [array.Count];
            double [] YAxis = new double [array.Count];
            int counter = 0;

            foreach (Exoplanet exoplanet in array)
                {
                double tperi = 0.0;

                if (double.TryParse (exoplanet.Tperi, out tperi) == true)
                    {
                    YAxis [counter] = tperi;
                    XAxis [counter] = counter + 1;
                    counter++;
                    }
                }

            plotSurface.Clear ();
            plotSurface.Title = "Tperi Plot";
            plotSurface.BackColor = BackgroundColor;

            LinePlot linePlot = new LinePlot ();
            linePlot.AbscissaData = XAxis;
            linePlot.DataSource = YAxis;
            linePlot.Color = LineColor;
            linePlot.Pen.Width = LinePenWidth;

            plotSurface.Add (linePlot, PlotSurface2D.XAxisPosition.Bottom, PlotSurface2D.YAxisPosition.Left, OnTopZOrder);

            double minimumY = Helper.GetMinimum (YAxis);
            double maximumY = Helper.GetMaximum (YAxis);

            VisualizeTperiErrorBars (plotSurface, array, ref minimumY, ref maximumY);
            VisualizeLogYAxis (plotSurface, "Index", "{0:0}", "Tperi (JD)", "{0:0.00}", Visualization.LogYAxis, minimumY, maximumY);
            VisualizeLegend (plotSurface);

            AddInteraction (plotSurface);

            plotSurface.Refresh ();
            }

        static public void VisualizeTperiErrorBars (NPlot.Windows.PlotSurface2D plotSurface, ArrayList array, ref double minimumY, ref double maximumY)
            {
            if (Visualization.IncludeErrorBars == CheckState.Checked)
                {
                int counter = 0;

                foreach (Exoplanet exoplanet in array)
                    {
                    double tperi = 0.0, maximumError = 0.0, minimumError = 0.0;

                    if (double.TryParse (exoplanet.Tperi, out tperi) == true)
                        if (double.TryParse (exoplanet.TperiErrorMax, out maximumError) == true)
                            if (double.TryParse (exoplanet.TperiErrorMin, out minimumError) == true)
                                {
                                if (tperi + maximumError > maximumY)
                                    maximumY = tperi + maximumError;

                                if (tperi - minimumError < minimumY)
                                    minimumY = tperi - minimumError;

                                VisualizeErrorBar (plotSurface, tperi, maximumError, -minimumError, counter);
                                }

                    ++counter;
                    }
                }
            }

        static public void VisualizeK (NPlot.Windows.PlotSurface2D plotSurface, ArrayList exoplanets)
            {
            ArrayList array = Helper.PlanetsWithK (exoplanets, false, true);

            double [] XAxis = new double [array.Count];
            double [] YAxis = new double [array.Count];
            int counter = 0;

            foreach (Exoplanet exoplanet in array)
                {
                double k = 0.0;

                if (double.TryParse (exoplanet.K, out k) == true)
                    {
                    YAxis [counter] = k;
                    XAxis [counter] = counter + 1;
                    counter++;
                    }
                }

            plotSurface.Clear ();
            plotSurface.Title = "K Plot";
            plotSurface.BackColor = BackgroundColor;

            LinePlot linePlot = new LinePlot ();
            linePlot.AbscissaData = XAxis;
            linePlot.DataSource = YAxis;
            linePlot.Color = LineColor;
            linePlot.Pen.Width = LinePenWidth;

            plotSurface.Add (linePlot, PlotSurface2D.XAxisPosition.Bottom, PlotSurface2D.YAxisPosition.Left, OnTopZOrder);

            double minimumY = Helper.GetMinimum (YAxis);
            double maximumY = Helper.GetMaximum (YAxis);

            VisualizeKErrorBars (plotSurface, array, ref minimumY, ref maximumY);
            VisualizeLogYAxis (plotSurface, "Index", "{0:0}", "K (m/s)", "{0:0.00}", Visualization.LogYAxis, minimumY, maximumY);
            VisualizeLegend (plotSurface);

            AddInteraction (plotSurface);

            plotSurface.Refresh ();
            }

        static public void VisualizeKErrorBars (NPlot.Windows.PlotSurface2D plotSurface, ArrayList array, ref double minimumY, ref double maximumY)
            {
            if (Visualization.IncludeErrorBars == CheckState.Checked)
                {
                int counter = 0;

                foreach (Exoplanet exoplanet in array)
                    {
                    double k = 0.0, maximumError = 0.0, minimumError = 0.0;

                    if (double.TryParse (exoplanet.K, out k) == true)
                        if (double.TryParse (exoplanet.KErrorMax, out maximumError) == true)
                            if (double.TryParse (exoplanet.KErrorMin, out minimumError) == true)
                                {
                                if (k + maximumError > maximumY)
                                    maximumY = k + maximumError;

                                if (k - minimumError < minimumY)
                                    minimumY = k - minimumError;

                                VisualizeErrorBar (plotSurface, k, maximumError, -minimumError, counter);
                                }

                    ++counter;
                    }
                }
            }

        static public void VisualizeGeometricAlbedo (NPlot.Windows.PlotSurface2D plotSurface, ArrayList exoplanets)
            {
            ArrayList array = Helper.PlanetsWithGeometricAlbedo (exoplanets, false);

            double [] XAxis = new double [array.Count];
            double [] YAxis = new double [array.Count];
            int counter = 0;

            foreach (Exoplanet exoplanet in array)
                {
                double geometricAlbedo = 0.0;

                if (double.TryParse (exoplanet.GeometricAlbedo, out geometricAlbedo) == true)
                    {
                    YAxis [counter] = geometricAlbedo;
                    XAxis [counter] = counter + 1;
                    counter++;
                    }
                }

            plotSurface.Clear ();
            plotSurface.Title = "Geometric Albedo Plot";
            plotSurface.BackColor = BackgroundColor;

            LinePlot linePlot = new LinePlot ();
            linePlot.AbscissaData = XAxis;
            linePlot.DataSource = YAxis;
            linePlot.Color = LineColor;
            linePlot.Pen.Width = LinePenWidth;

            plotSurface.Add (linePlot, PlotSurface2D.XAxisPosition.Bottom, PlotSurface2D.YAxisPosition.Left, OnTopZOrder);

            double minimumY = Helper.GetMinimum (YAxis);
            double maximumY = Helper.GetMaximum (YAxis);

            VisualizeGeometricAlbedoErrorBars (plotSurface, array, ref minimumY, ref maximumY);
            VisualizeLogYAxis (plotSurface, "Index", "{0:0}", "Geometri Albedo", "{0:0.00}", Visualization.LogYAxis, minimumY, maximumY);
            VisualizeLegend (plotSurface);

            AddInteraction (plotSurface);

            plotSurface.Refresh ();
            }

        static public void VisualizeGeometricAlbedoErrorBars (NPlot.Windows.PlotSurface2D plotSurface, ArrayList array, ref double minimumY, ref double maximumY)
            {
            if (Visualization.IncludeErrorBars == CheckState.Checked)
                {
                int counter = 0;

                foreach (Exoplanet exoplanet in array)
                    {
                    double geometricAlbedo = 0.0, maximumError = 0.0, minimumError = 0.0;

                    if (double.TryParse (exoplanet.GeometricAlbedo, out geometricAlbedo) == true)
                        if (double.TryParse (exoplanet.GeometricAlbedoErrorMax, out maximumError) == true)
                            if (double.TryParse (exoplanet.GeometricAlbedoErrorMin, out minimumError) == true)
                                {
                                if (geometricAlbedo + maximumError > maximumY)
                                    maximumY = geometricAlbedo + maximumError;

                                if (geometricAlbedo - minimumError < minimumY)
                                    minimumY = geometricAlbedo - minimumError;

                                VisualizeErrorBar (plotSurface, geometricAlbedo, maximumError, -minimumError, counter);
                                }

                    ++counter;
                    }
                }
            }

        static public void VisualizeTconj (NPlot.Windows.PlotSurface2D plotSurface, ArrayList exoplanets)
            {
            ArrayList array = Helper.PlanetsWithTconj (exoplanets, false);

            double [] XAxis = new double [array.Count];
            double [] YAxis = new double [array.Count];
            int counter = 0;

            foreach (Exoplanet exoplanet in array)
                {
                double tconj = 0.0;

                if (double.TryParse (exoplanet.Tconj, out tconj) == true)
                    {
                    YAxis [counter] = tconj;
                    XAxis [counter] = counter + 1;
                    counter++;
                    }
                }

            plotSurface.Clear ();
            plotSurface.Title = "Tconj Plot";
            plotSurface.BackColor = BackgroundColor;

            LinePlot linePlot = new LinePlot ();
            linePlot.AbscissaData = XAxis;
            linePlot.DataSource = YAxis;
            linePlot.Color = LineColor;
            linePlot.Pen.Width = LinePenWidth;

            plotSurface.Add (linePlot, PlotSurface2D.XAxisPosition.Bottom, PlotSurface2D.YAxisPosition.Left, OnTopZOrder);

            double minimumY = Helper.GetMinimum (YAxis);
            double maximumY = Helper.GetMaximum (YAxis);

            VisualizeTconjErrorBars (plotSurface, array, ref minimumY, ref maximumY);
            VisualizeLogYAxis (plotSurface, "Index", "{0:0}", "Tconj (JD)", "{0:0.00}", Visualization.LogYAxis, minimumY, maximumY);
            VisualizeLegend (plotSurface);

            AddInteraction (plotSurface);

            plotSurface.Refresh ();
            }

        static public void VisualizeTconjErrorBars (NPlot.Windows.PlotSurface2D plotSurface, ArrayList array, ref double minimumY, ref double maximumY)
            {
            if (Visualization.IncludeErrorBars == CheckState.Checked)
                {
                int counter = 0;

                foreach (Exoplanet exoplanet in array)
                    {
                    double tconj = 0.0, maximumError = 0.0, minimumError = 0.0;

                    if (double.TryParse (exoplanet.Tconj, out tconj) == true)
                        if (double.TryParse (exoplanet.TconjErrorMax, out maximumError) == true)
                            if (double.TryParse (exoplanet.TconjErrorMin, out minimumError) == true)
                                {
                                if (tconj + maximumError > maximumY)
                                    maximumY = tconj + maximumError;

                                if (tconj - minimumError < minimumY)
                                    minimumY = tconj - minimumError;

                                VisualizeErrorBar (plotSurface, tconj, maximumError, -minimumError, counter);
                                }

                    ++counter;
                    }
                }
            }

        //
        //
        //

        static public void VisualizeMassAndRadius (NPlot.Windows.PlotSurface2D plotSurface, ArrayList exoplanets)
            {
            ArrayList array = Helper.PlanetsWithMassAndRadius (exoplanets);

            double [] masses = new double [array.Count];
            double [] radii = new double [array.Count];
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
            plotSurface.BackColor = BackgroundColor;

            PointPlot pointPlot = new PointPlot ();
            pointPlot.AbscissaData = masses;
            pointPlot.DataSource = radii;
            pointPlot.Marker.Color = PointColor;
            pointPlot.Marker.Type = NPlot.Marker.MarkerType.FilledCircle;

            plotSurface.Add (pointPlot, PlotSurface2D.XAxisPosition.Bottom, PlotSurface2D.YAxisPosition.Left);

            double minimumX = Helper.GetMinimum (masses);
            double maximumX = Helper.GetMaximum (masses);
            double minimumY = Helper.GetMinimum (radii);
            double maximumY = Helper.GetMaximum (radii);

            VisualizeLogXYAxis (plotSurface, "Mass (Mjup)", "{0:0.00}", "Radius (Rjup)", "{0:0.00}", Visualization.LogXAxis, minimumX, maximumX, Visualization.LogYAxis, minimumY, maximumY);
            VisualizeLegend (plotSurface);

            AddInteraction (plotSurface);

            plotSurface.Refresh ();
            }

        static public void VisualizeMassAndEccentricity (NPlot.Windows.PlotSurface2D plotSurface, ArrayList exoplanets)
            {
            ArrayList array = Helper.PlanetsWithEccentricityAndMass (exoplanets);

            double [] eccentricities = new double [array.Count];
            double [] masses = new double [array.Count];
            int counter = 0;

            foreach (Exoplanet exoplanet in array)
                {
                double eccentricity = 0.0, mass = 0.0;

                if (double.TryParse (exoplanet.Eccentricity, out eccentricity) == true)
                    if (double.TryParse (exoplanet.Mass, out mass) == true)
                        {
                        eccentricities [counter] = eccentricity;
                        masses [counter] = mass;
                        counter++;
                        }
                }

            plotSurface.Clear ();
            plotSurface.Title = "Mass & Eccentricity Plot";
            plotSurface.BackColor = BackgroundColor;

            PointPlot pointPlot = new PointPlot ();
            pointPlot.AbscissaData = masses;
            pointPlot.DataSource = eccentricities;
            pointPlot.Marker.Color = PointColor;
            pointPlot.Marker.Type = NPlot.Marker.MarkerType.FilledCircle;

            plotSurface.Add (pointPlot, PlotSurface2D.XAxisPosition.Bottom, PlotSurface2D.YAxisPosition.Left);

            double minimumX = Helper.GetMinimum (masses);
            double maximumX = Helper.GetMaximum (masses);
            double minimumY = Helper.GetMinimum (eccentricities);
            double maximumY = Helper.GetMaximum (eccentricities);

            VisualizeLogXYAxis (plotSurface, "Mass (Mjup)", "{0:0.00}", "Eccentricity", "{0:0.00}", Visualization.LogXAxis, minimumX, maximumX, Visualization.LogYAxis, minimumY, maximumY);
            VisualizeLegend (plotSurface);

            AddInteraction (plotSurface);

            plotSurface.Refresh ();
            }

        static public void VisualizeStars (NPlot.Windows.PlotSurface2D plotSurface, ArrayList exoplanets)
            {
            ArrayList stars = Helper.GetStars (exoplanets);

            plotSurface.Clear ();
            plotSurface.Title = "Star Plot";
            plotSurface.BackColor = BackgroundColor;

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

                                    case 3:
                                        pointPlot.Marker.Type = Marker.MarkerType.FilledCircle3;
                                        break;

                                    case 4:
                                        pointPlot.Marker.Type = Marker.MarkerType.FilledCircle4;
                                        break;

                                    case 5:
                                        pointPlot.Marker.Type = Marker.MarkerType.FilledCircle5;
                                        break;
                                    }

                                if (Visualization.ColorFromStarType == CheckState.Checked)
                                    {
                                    pointPlot.Marker.Color = Color.Black;

                                    if (star.Property.SPType != null)
                                        switch (star.Property.SPType [0])
                                            {
                                            case 'O':
                                                pointPlot.Marker.Color = Color.FromArgb (155, 176, 255); break;
                                            case 'B':
                                                pointPlot.Marker.Color = Color.FromArgb (170, 191, 255); break;
                                            case 'A':
                                                pointPlot.Marker.Color = Color.FromArgb (202, 215, 255); break;
                                            case 'F':
                                                pointPlot.Marker.Color = Color.FromArgb (248, 247, 255); break;
                                            case 'G':
                                                pointPlot.Marker.Color = Color.FromArgb (255, 244, 234); break;
                                            case 'K':
                                                pointPlot.Marker.Color = Color.FromArgb (255, 210, 161); break;
                                            case 'M':
                                                pointPlot.Marker.Color = Color.FromArgb (255, 204, 111); break;
                                            default:
                                                pointPlot.Marker.Color = Color.FromArgb (255, 255, 255); break;
                                            }
                                    }
                                else
                                    pointPlot.Marker.Color = PointColor;

                                plotSurface.Add (pointPlot, PlotSurface2D.XAxisPosition.Bottom, PlotSurface2D.YAxisPosition.Left);
                                }
                        }
                }

            VisualizeAxis (plotSurface, "Right Accession (degrees)", "{0:0}", "Declination (degrees)", "{0:0.0}", true);
            VisualizeLegend (plotSurface);

            AddInteraction (plotSurface);

            plotSurface.Refresh ();
            }

        //
        // Visualization utilities
        //

        static private void VisualizeAxis (NPlot.Windows.PlotSurface2D plotSurface, string xAxisLabel, string xAxisFormat, string yAxisLabel, string yAxisFormat, bool reversed)
            {
            Font axisFont = new Font ("Arial", 10);
            Font tickFont = new Font ("Arial", 8);

            plotSurface.XAxis1.Label = xAxisLabel;
            plotSurface.XAxis1.NumberFormat = xAxisFormat;
            plotSurface.XAxis1.TicksLabelAngle = 0;
            plotSurface.XAxis1.TickTextNextToAxis = true;
            plotSurface.XAxis1.FlipTicksLabel = true;
            plotSurface.XAxis1.LabelOffset = 25;
            plotSurface.XAxis1.LabelOffsetAbsolute = true;
            plotSurface.XAxis1.LabelFont = axisFont;
            plotSurface.XAxis1.TickTextFont = tickFont;
            plotSurface.XAxis1.Reversed = reversed;
            plotSurface.YAxis1.Label = yAxisLabel;
            plotSurface.YAxis1.NumberFormat = yAxisFormat;
            plotSurface.YAxis1.LabelFont = axisFont;
            plotSurface.YAxis1.TickTextFont = tickFont;
            }

        static private void VisualizeLogYAxis (NPlot.Windows.PlotSurface2D plotSurface, string xAxisLabel, string xAxisFormat, string yAxisLabel, string yAxisFormat,
            CheckState logY, double minimumY, double maximumY)
            {
            if (logY == CheckState.Checked)
                if (minimumY <= 0.0)
                    minimumY = AlmostZero;

            if (logY == CheckState.Checked)
                if (maximumY <= 0.0)
                    maximumY = AlmostZero;

            Font axisFont = new Font ("Arial", 10);
            Font tickFont = new Font ("Arial", 8);

            plotSurface.XAxis1.Label = xAxisLabel;
            plotSurface.XAxis1.NumberFormat = xAxisFormat;
            plotSurface.XAxis1.TicksLabelAngle = 0;
            plotSurface.XAxis1.TickTextNextToAxis = true;
            plotSurface.XAxis1.FlipTicksLabel = true;
            plotSurface.XAxis1.LabelOffset = 25;
            plotSurface.XAxis1.LabelOffsetAbsolute = true;
            plotSurface.XAxis1.LabelFont = axisFont;
            plotSurface.XAxis1.TickTextFont = tickFont;
            plotSurface.YAxis1.Label = yAxisLabel;
            plotSurface.YAxis1.NumberFormat = yAxisFormat;
            plotSurface.YAxis1.LabelFont = axisFont;
            plotSurface.YAxis1.TickTextFont = tickFont;

            Grid g = new Grid ();
            g.VerticalGridType = ( logY == CheckState.Checked ) ? Grid.GridType.Fine : Grid.GridType.Coarse;
            g.HorizontalGridType = Grid.GridType.Coarse;
            plotSurface.Add (g);

            if (logY == CheckState.Checked)
                {
                LogAxis logAxisY = new LogAxis (plotSurface.YAxis1);
                logAxisY.WorldMin = minimumY;
                logAxisY.WorldMax = maximumY;
                plotSurface.YAxis1 = logAxisY;
                }
            else
                {
                LinearAxis YAxis = new LinearAxis (plotSurface.YAxis1);
                YAxis.WorldMin = minimumY;
                YAxis.WorldMax = maximumY;
                plotSurface.YAxis1 = YAxis;
                }
            }

        static private void VisualizeLogXYAxis (NPlot.Windows.PlotSurface2D plotSurface, string xAxisLabel, string xAxisFormat, string yAxisLabel, string yAxisFormat,
            CheckState logX, double minimumX, double maximumX, CheckState logY, double minimumY, double maximumY)
            {
            Font axisFont = new Font ("Arial", 10);
            Font tickFont = new Font ("Arial", 8);

            plotSurface.XAxis1.Label = xAxisLabel;
            plotSurface.XAxis1.NumberFormat = xAxisFormat;
            plotSurface.XAxis1.TicksLabelAngle = 0;
            plotSurface.XAxis1.TickTextNextToAxis = true;
            plotSurface.XAxis1.FlipTicksLabel = true;
            plotSurface.XAxis1.LabelOffset = 25;
            plotSurface.XAxis1.LabelOffsetAbsolute = true;
            plotSurface.XAxis1.LabelFont = axisFont;
            plotSurface.XAxis1.TickTextFont = tickFont;
            plotSurface.YAxis1.Label = yAxisLabel;
            plotSurface.YAxis1.NumberFormat = yAxisFormat;
            plotSurface.YAxis1.LabelFont = axisFont;
            plotSurface.YAxis1.TickTextFont = tickFont;

            Grid g = new Grid ();

            g.VerticalGridType = ( logY == CheckState.Checked ) ? Grid.GridType.Fine : Grid.GridType.Coarse;
            g.HorizontalGridType = ( logX == CheckState.Checked ) ? Grid.GridType.Fine : Grid.GridType.Coarse;
            plotSurface.Add (g);

            if (logX == CheckState.Checked)
                {
                LogAxis logAxisX = new LogAxis (plotSurface.XAxis1);

                logAxisX.WorldMin = minimumX;
                logAxisX.WorldMax = maximumX;
                plotSurface.XAxis1 = logAxisX;
                }
            else
                {
                LinearAxis XAxis = new LinearAxis (plotSurface.XAxis1);

                XAxis.WorldMin = minimumX;
                XAxis.WorldMax = maximumX;
                plotSurface.XAxis1 = XAxis;
                }

            if (logY == CheckState.Checked)
                {
                LogAxis logAxisY = new LogAxis (plotSurface.YAxis1);

                logAxisY.WorldMin = minimumY;
                logAxisY.WorldMax = maximumY;
                plotSurface.YAxis1 = logAxisY;
                }
            else
                {
                LinearAxis YAxis = new LinearAxis (plotSurface.YAxis1);

                YAxis.WorldMin = minimumY;
                YAxis.WorldMax = maximumY;
                plotSurface.YAxis1 = YAxis;
                }
            }

        static private void VisualizeErrorBar (NPlot.Windows.PlotSurface2D plotSurface, double value, double maximumError, double minimumError, int counter)
            {
            counter += 1;

            if (Visualization.LogYAxis == CheckState.Checked)
                {
                if (value + maximumError <= 0.0)
                    return;

                if (value + minimumError <= 0.0)
                    return;
                }

            VisualizeErrorBarVerticalLine (plotSurface, value, maximumError, minimumError, counter);
            VisualizeErrorBarHorizontalLine (plotSurface, value, maximumError, counter);
            VisualizeErrorBarHorizontalLine (plotSurface, value, minimumError, counter);
            }

        static private void VisualizeErrorBarVerticalLine (NPlot.Windows.PlotSurface2D plotSurface, double value, double maximumError, double minimumError, int counter)
            {
            if (ErrorBars == ErrorBar.VerticalLine || ErrorBars == ErrorBar.VerticalNHorizontalLines)
                {
                double [] errors = new double [2];
                double [] XAxis = new double [2];

                errors [0] = value + maximumError;
                errors [1] = value + minimumError;
                XAxis [0] = counter;
                XAxis [1] = counter;

                LinePlot linePlot = new LinePlot ();

                linePlot.AbscissaData = XAxis;
                linePlot.DataSource = errors;
                linePlot.Color = Color.Black;
                linePlot.Pen.Width = 1F;
                plotSurface.Add (linePlot, PlotSurface2D.XAxisPosition.Bottom, PlotSurface2D.YAxisPosition.Left);
                }
            }

        static private void VisualizeErrorBarHorizontalLine (NPlot.Windows.PlotSurface2D plotSurface, double value, double errorValue, int counter)
            {
            if (ErrorBars == ErrorBar.VerticalNHorizontalLines)
                {
                double [] errors = new double [2];
                double [] XAxis = new double [2];

                errors [0] = value + errorValue;
                errors [1] = value + errorValue;
                XAxis [0] = counter - 0.4;
                XAxis [1] = counter + 0.4;

                LinePlot linePlot = new LinePlot ();

                linePlot.AbscissaData = XAxis;
                linePlot.DataSource = errors;
                linePlot.Color = Color.Black;
                linePlot.Pen.Width = 1F;
                plotSurface.Add (linePlot, PlotSurface2D.XAxisPosition.Bottom, PlotSurface2D.YAxisPosition.Left);
                }
            }

        static public void VisualizeLegend (NPlot.Windows.PlotSurface2D plotSurface)
            {
#if Include_Legend
            if (Visualization.IncludeLegend == CheckState.Checked)
                {
                NPlot.Legend legend = new NPlot.Legend ();

                legend.AttachTo (PlotSurface2D.XAxisPosition.Top, PlotSurface2D.YAxisPosition.Right);
                legend.VerticalEdgePlacement = NPlot.Legend.Placement.Inside;
                legend.HorizontalEdgePlacement = NPlot.Legend.Placement.Outside;
                legend.BorderStyle = NPlot.LegendBase.BorderType.Line;
                plotSurface.Legend = legend;
                }
#else
            return;
#endif
            }

        static public void AddInteraction (NPlot.Windows.PlotSurface2D plotSurface)
            {
            plotSurface.AddInteraction (new NPlot.Windows.PlotSurface2D.Interactions.RubberBandSelection ());
            }
        }
    }
