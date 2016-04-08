using NPlot;
using CubicSpline;
using System.Drawing;
using System.Collections;
using System.Windows.Forms;

namespace ExoplanetLibrary
    {
    public enum ErrorBar
        {
        None = 0,
        LinearPlots = 1,
        PointPlots = 2,
        LinearNPointPlots = 3,
        }

    public enum PlotTypes
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
        MassAndRadius = 30,
        MassAndOrbitalPeriod = 31,
        MassAndSemiMajorAxis = 32,
        MassAndEccentricity = 33,
        MassAndAngularDistance = 34,
        MassAndOmega = 35,
        MassAndInclination = 36,
        MassAndTzeroTr = 37,
        MassAndTperi = 38,
        MassAndK = 39,
        RadiusAndMass = 40,
        RadiusAndOrbitalPeriod = 41,
        RadiusAndSemiMajorAxis = 42,
        RadiusAndEccentricity = 43,
        RadiusAndAngularDistance = 44,
        RadiusAndOmega = 45,
        RadiusAndInclination = 46,
        RadiusAndTzeroTr = 47,
        RadiusAndTperi = 48,
        RadiusAndK = 49,
        Stars = 100,
        };

    public enum DynamicInteractions
        {
        Area = 0,
        Pan = 1,
        };

    public class Plotting
        {
        Plotting ()
            {
            }

        static private ErrorBar ErrorBars_ = ErrorBar.LinearPlots;
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

        static private DynamicInteractions Interaction_ = DynamicInteractions.Area;
        static public DynamicInteractions Interaction
            {
            get { return Interaction_; }
            set { Interaction_ = value; }
            }

        static private NPlot.Windows.PlotSurface2D.Interactions.Interaction [] Interactions = { null, null };

        static public void VisualizeLinearDiagrams (NPlot.Windows.PlotSurface2D plotSurface, ArrayList exoplanets, PlotTypes plotType)
            {
            if (exoplanets == null)
                return;

            if (exoplanets.Count == 0)
                return;

            double [] XAxis = new double [exoplanets.Count];
            double [] YAxis = new double [exoplanets.Count];
            int counter = 0;

            foreach (Exoplanet exoplanet in exoplanets)
                {
                double value = 0.0;
                bool isValid = false;

                switch (plotType)
                    {
                    case PlotTypes.Mass:
                        isValid = double.TryParse (exoplanet.Mass, out value);
                        break;

                    case PlotTypes.Radius:
                        isValid = double.TryParse (exoplanet.Radius, out value);
                        break;

                    case PlotTypes.OrbitalPeriod:
                        isValid = double.TryParse (exoplanet.OrbitalPeriod, out value);
                        break;

                    case PlotTypes.SemiMajorAxis:
                        isValid = double.TryParse (exoplanet.SemiMajorAxis, out value);
                        break;

                    case PlotTypes.Eccentricity:
                        isValid = double.TryParse (exoplanet.Eccentricity, out value);
                        break;

                    case PlotTypes.AngularDistance:
                        isValid = double.TryParse (exoplanet.AngularDistance, out value);
                        break;

                    case PlotTypes.Inclination:
                        isValid = double.TryParse (exoplanet.Inclination, out value);
                        break;

                    case PlotTypes.TzeroTr:
                        isValid = double.TryParse (exoplanet.TzeroTr, out value);
                        break;

                    case PlotTypes.TzeroTrSec:
                        isValid = double.TryParse (exoplanet.TzeroTrSec, out value);
                        break;

                    case PlotTypes.LambdaAngle:
                        isValid = double.TryParse (exoplanet.LambdaAngle, out value);
                        break;

                    case PlotTypes.TzeroVr:
                        isValid = double.TryParse (exoplanet.TzeroVr, out value);
                        break;

                    case PlotTypes.TemperatureCalculated:
                        isValid = double.TryParse (exoplanet.TemperatureCalculated, out value);
                        break;

                    case PlotTypes.TemperatureMeasured:
                        isValid = double.TryParse (exoplanet.TemperatureMeasured, out value);
                        break;

                    case PlotTypes.LogG:
                        isValid = double.TryParse (exoplanet.LogG, out value);
                        break;

                    case PlotTypes.Omega:
                        isValid = double.TryParse (exoplanet.Omega, out value);
                        break;

                    case PlotTypes.Tperi:
                        isValid = double.TryParse (exoplanet.Tperi, out value);
                        break;

                    case PlotTypes.K:
                        isValid = double.TryParse (exoplanet.K, out value);
                        break;

                    case PlotTypes.GeometricAlbedo:
                        isValid = double.TryParse (exoplanet.GeometricAlbedo, out value);
                        break;

                    case PlotTypes.Tconj:
                        isValid = double.TryParse (exoplanet.Tconj, out value);
                        break;
                    }

                if (isValid)
                    {
                    YAxis [counter] = value;
                    XAxis [counter] = counter + 1;
                    counter++;
                    }
                }

            plotSurface.Clear ();
            plotSurface.BackColor = BackgroundColor;

            LinePlot linePlot = new LinePlot ();
            linePlot.AbscissaData = XAxis;
            linePlot.OrdinateData = YAxis;
            linePlot.Color = LineColor;
            linePlot.Pen.Width = LinePenWidth;
            plotSurface.Add (linePlot, PlotSurface2D.XAxisPosition.Bottom, PlotSurface2D.YAxisPosition.Left, OnTopZOrder);

            double minimumY = Helper.GetMinimum (YAxis);
            double maximumY = Helper.GetMaximum (YAxis);

            VisualizeErrorBars (plotSurface, exoplanets, plotType, ref minimumY, ref maximumY);
            VisualizeLogYAxis (plotSurface, plotType, Visualization.LogYAxis, minimumY, maximumY);
            VisualizeLegend (plotSurface);

            VisualizeCubicSpline (plotSurface, plotType, YAxis, XAxis);

            AddInteraction (plotSurface);

            plotSurface.Refresh ();
            }

        static public void VisualizeErrorBars (NPlot.Windows.PlotSurface2D plotSurface, ArrayList array, PlotTypes plotType, ref double minimumY, ref double maximumY)
            {
            if (Visualization.IncludeErrorBars == CheckState.Checked)
                {
                int counter = 0;

                foreach (Exoplanet exoplanet in array)
                    {
                    double value = 0.0, maximumError = 0.0, minimumError = 0.0;
                    bool isValid = false;

                    switch (plotType)
                        {
                        case PlotTypes.Mass:
                            if (double.TryParse (exoplanet.Mass, out value) == true)
                                if (double.TryParse (exoplanet.MassErrorMax, out maximumError) == true)
                                    if (double.TryParse (exoplanet.MassErrorMin, out minimumError) == true)
                                        isValid = true;
                            break;

                        case PlotTypes.Radius:
                            if (double.TryParse (exoplanet.Radius, out value) == true)
                                if (double.TryParse (exoplanet.RadiusErrorMax, out maximumError) == true)
                                    if (double.TryParse (exoplanet.RadiusErrorMin, out minimumError) == true)
                                        isValid = true;
                            break;

                        case PlotTypes.OrbitalPeriod:
                            if (double.TryParse (exoplanet.OrbitalPeriod, out value) == true)
                                if (double.TryParse (exoplanet.OrbitalPeriodErrorMax, out maximumError) == true)
                                    if (double.TryParse (exoplanet.OrbitalPeriodErrorMin, out minimumError) == true)
                                        isValid = true;
                            break;

                        case PlotTypes.SemiMajorAxis:
                            if (double.TryParse (exoplanet.SemiMajorAxis, out value) == true)
                                if (double.TryParse (exoplanet.SemiMajorAxisErrorMax, out maximumError) == true)
                                    if (double.TryParse (exoplanet.SemiMajorAxisErrorMin, out minimumError) == true)
                                        isValid = true;
                            break;

                        case PlotTypes.Eccentricity:
                            if (double.TryParse (exoplanet.Eccentricity, out value) == true)
                                if (double.TryParse (exoplanet.EccentricityErrorMax, out maximumError) == true)
                                    if (double.TryParse (exoplanet.EccentricityErrorMin, out minimumError) == true)
                                        isValid = true;
                            break;

                        case PlotTypes.AngularDistance:
                            isValid = false;
                            break;

                        case PlotTypes.Inclination:
                            if (double.TryParse (exoplanet.Inclination, out value) == true)
                                if (double.TryParse (exoplanet.InclinationErrorMax, out maximumError) == true)
                                    if (double.TryParse (exoplanet.InclinationErrorMin, out minimumError) == true)
                                        isValid = true;
                            break;

                        case PlotTypes.TzeroTr:
                            if (double.TryParse (exoplanet.TzeroTr, out value) == true)
                                if (double.TryParse (exoplanet.TzeroTrErrorMax, out maximumError) == true)
                                    if (double.TryParse (exoplanet.TzeroTrErrorMin, out minimumError) == true)
                                        isValid = true;
                            break;

                        case PlotTypes.TzeroTrSec:
                            if (double.TryParse (exoplanet.TzeroTrSec, out value) == true)
                                if (double.TryParse (exoplanet.TzeroTrSecErrorMax, out maximumError) == true)
                                    if (double.TryParse (exoplanet.TzeroTrSecErrorMin, out minimumError) == true)
                                        isValid = true;
                            break;

                        case PlotTypes.LambdaAngle:
                            if (double.TryParse (exoplanet.LambdaAngle, out value) == true)
                                if (double.TryParse (exoplanet.LambdaAngleErrorMax, out maximumError) == true)
                                    if (double.TryParse (exoplanet.LambdaAngleErrorMin, out minimumError) == true)
                                        isValid = true;
                            break;

                        case PlotTypes.TzeroVr:
                            if (double.TryParse (exoplanet.TzeroVr, out value) == true)
                                if (double.TryParse (exoplanet.TzeroVrErrorMax, out maximumError) == true)
                                    if (double.TryParse (exoplanet.TzeroVrErrorMin, out minimumError) == true)
                                        isValid = true;
                            break;

                        case PlotTypes.TemperatureCalculated:
                            isValid = false;
                            break;

                        case PlotTypes.TemperatureMeasured:
                            isValid = false;
                            break;

                        case PlotTypes.LogG:
                            isValid = false;
                            break;

                        case PlotTypes.Omega:
                            if (double.TryParse (exoplanet.Omega, out value) == true)
                                if (double.TryParse (exoplanet.OmegaErrorMax, out maximumError) == true)
                                    if (double.TryParse (exoplanet.OmegaErrorMin, out minimumError) == true)
                                        isValid = true;
                            break;

                        case PlotTypes.Tperi:
                            if (double.TryParse (exoplanet.Tperi, out value) == true)
                                if (double.TryParse (exoplanet.TperiErrorMax, out maximumError) == true)
                                    if (double.TryParse (exoplanet.TperiErrorMin, out minimumError) == true)
                                        isValid = true;
                            break;

                        case PlotTypes.K:
                            if (double.TryParse (exoplanet.K, out value) == true)
                                if (double.TryParse (exoplanet.KErrorMax, out maximumError) == true)
                                    if (double.TryParse (exoplanet.KErrorMin, out minimumError) == true)
                                        isValid = true;
                            break;

                        case PlotTypes.GeometricAlbedo:
                            if (double.TryParse (exoplanet.GeometricAlbedo, out value) == true)
                                if (double.TryParse (exoplanet.GeometricAlbedoErrorMax, out maximumError) == true)
                                    if (double.TryParse (exoplanet.GeometricAlbedoErrorMin, out minimumError) == true)
                                        isValid = true;
                            break;

                        case PlotTypes.Tconj:
                            if (double.TryParse (exoplanet.Tconj, out value) == true)
                                if (double.TryParse (exoplanet.TconjErrorMax, out maximumError) == true)
                                    if (double.TryParse (exoplanet.TconjErrorMin, out minimumError) == true)
                                        isValid = true;
                            break;
                        }

                    if (isValid)
                        {
                        if (value + maximumError > maximumY)
                            maximumY = value + maximumError;

                        if (value - minimumError < minimumY)
                            minimumY = value - minimumError;

                        VisualizeErrorBar (plotSurface, value, maximumError, -minimumError, counter);
                        }

                    ++counter;
                    }
                }
            }

        static public void VisualizePointDiagrams (NPlot.Windows.PlotSurface2D plotSurface, ArrayList exoplanets, PlotTypes plotType)
            {
            if (exoplanets == null)
                return;

            if (exoplanets.Count == 0)
                return;

            double [] XAxis = new double [exoplanets.Count];
            double [] YAxis = new double [exoplanets.Count];
            int counter = 0;

            foreach (Exoplanet exoplanet in exoplanets)
                {
                double xvalue = 0.0, yvalue = 0.0;
                bool isValid = false;

                switch (plotType)
                    {
                    case PlotTypes.MassAndRadius:
                        if (double.TryParse (exoplanet.Mass, out xvalue) == true)
                            if (double.TryParse (exoplanet.Radius, out yvalue) == true)
                                isValid = true;
                        break;

                    case PlotTypes.MassAndOrbitalPeriod:
                        if (double.TryParse (exoplanet.Mass, out xvalue) == true)
                            if (double.TryParse (exoplanet.OrbitalPeriod, out yvalue) == true)
                                isValid = true;
                        break;

                    case PlotTypes.MassAndSemiMajorAxis:
                        if (double.TryParse (exoplanet.Mass, out xvalue) == true)
                            if (double.TryParse (exoplanet.SemiMajorAxis, out yvalue) == true)
                                isValid = true;
                        break;

                    case PlotTypes.MassAndEccentricity:
                        if (double.TryParse (exoplanet.Mass, out xvalue) == true)
                            if (double.TryParse (exoplanet.Eccentricity, out yvalue) == true)
                                isValid = true;
                        break;

                    case PlotTypes.MassAndAngularDistance:
                        if (double.TryParse (exoplanet.Mass, out xvalue) == true)
                            if (double.TryParse (exoplanet.AngularDistance, out yvalue) == true)
                                isValid = true;
                        break;

                    case PlotTypes.MassAndOmega:
                        if (double.TryParse (exoplanet.Mass, out xvalue) == true)
                            if (double.TryParse (exoplanet.Omega, out yvalue) == true)
                                isValid = true;
                        break;

                    case PlotTypes.MassAndInclination:
                        if (double.TryParse (exoplanet.Mass, out xvalue) == true)
                            if (double.TryParse (exoplanet.Inclination, out yvalue) == true)
                                isValid = true;
                        break;

                    case PlotTypes.MassAndTzeroTr:
                        if (double.TryParse (exoplanet.Mass, out xvalue) == true)
                            if (double.TryParse (exoplanet.TzeroTr, out yvalue) == true)
                                isValid = true;
                        break;

                    case PlotTypes.MassAndTperi:
                        if (double.TryParse (exoplanet.Mass, out xvalue) == true)
                            if (double.TryParse (exoplanet.Tperi, out yvalue) == true)
                                isValid = true;
                        break;

                    case PlotTypes.MassAndK:
                        if (double.TryParse (exoplanet.Mass, out xvalue) == true)
                            if (double.TryParse (exoplanet.K, out yvalue) == true)
                                isValid = true;
                        break;

                    //

                    case PlotTypes.RadiusAndMass:
                        if (double.TryParse (exoplanet.Radius, out xvalue) == true)
                            if (double.TryParse (exoplanet.Mass, out yvalue) == true)
                                isValid = true;
                        break;

                    case PlotTypes.RadiusAndOrbitalPeriod:
                        if (double.TryParse (exoplanet.Radius, out xvalue) == true)
                            if (double.TryParse (exoplanet.OrbitalPeriod, out yvalue) == true)
                                isValid = true;
                        break;

                    case PlotTypes.RadiusAndSemiMajorAxis:
                        if (double.TryParse (exoplanet.Radius, out xvalue) == true)
                            if (double.TryParse (exoplanet.SemiMajorAxis, out yvalue) == true)
                                isValid = true;
                        break;

                    case PlotTypes.RadiusAndEccentricity:
                        if (double.TryParse (exoplanet.Radius, out xvalue) == true)
                            if (double.TryParse (exoplanet.Eccentricity, out yvalue) == true)
                                isValid = true;
                        break;

                    case PlotTypes.RadiusAndAngularDistance:
                        if (double.TryParse (exoplanet.Radius, out xvalue) == true)
                            if (double.TryParse (exoplanet.AngularDistance, out yvalue) == true)
                                isValid = true;
                        break;

                    case PlotTypes.RadiusAndOmega:
                        if (double.TryParse (exoplanet.Radius, out xvalue) == true)
                            if (double.TryParse (exoplanet.Omega, out yvalue) == true)
                                isValid = true;
                        break;

                    case PlotTypes.RadiusAndInclination:
                        if (double.TryParse (exoplanet.Radius, out xvalue) == true)
                            if (double.TryParse (exoplanet.Inclination, out yvalue) == true)
                                isValid = true;
                        break;

                    case PlotTypes.RadiusAndTzeroTr:
                        if (double.TryParse (exoplanet.Radius, out xvalue) == true)
                            if (double.TryParse (exoplanet.TzeroTr, out yvalue) == true)
                                isValid = true;
                        break;

                    case PlotTypes.RadiusAndTperi:
                        if (double.TryParse (exoplanet.Radius, out xvalue) == true)
                            if (double.TryParse (exoplanet.Tperi, out yvalue) == true)
                                isValid = true;
                        break;

                    case PlotTypes.RadiusAndK:
                        if (double.TryParse (exoplanet.Radius, out xvalue) == true)
                            if (double.TryParse (exoplanet.K, out yvalue) == true)
                                isValid = true;
                        break;
                    }

                if (isValid)
                    {
                    YAxis [counter] = yvalue;
                    XAxis [counter] = xvalue;
                    counter++;
                    }

                }

            plotSurface.Clear ();
            plotSurface.BackColor = BackgroundColor;

            PointPlot pointPlot = new PointPlot ();
            pointPlot.AbscissaData = XAxis;
            pointPlot.DataSource = YAxis;
            pointPlot.Marker.Color = PointColor;
            pointPlot.Marker.Type = NPlot.Marker.MarkerType.FilledCircle;

            plotSurface.Add (pointPlot, PlotSurface2D.XAxisPosition.Bottom, PlotSurface2D.YAxisPosition.Left);

            double minimumX = Helper.GetMinimum (XAxis);
            double maximumX = Helper.GetMaximum (XAxis);
            double minimumY = Helper.GetMinimum (YAxis);
            double maximumY = Helper.GetMaximum (YAxis);

            VisualizeErrorBars (plotSurface, exoplanets, plotType, ref minimumX, ref maximumX, ref minimumY, ref maximumY);
            VisualizeLogXYAxis (plotSurface, plotType, Visualization.LogXAxis, minimumX, maximumX, Visualization.LogYAxis, minimumY, maximumY);
            VisualizeLegend (plotSurface);
            AddInteraction (plotSurface);

            plotSurface.Refresh ();
            }

        static public void VisualizeErrorBars (NPlot.Windows.PlotSurface2D plotSurface, ArrayList array, PlotTypes plotType, ref double minimumX, ref double maximumX, ref double minimumY, ref double maximumY)
            {
            if (Visualization.IncludeErrorBars == CheckState.Checked)
                {
                foreach (Exoplanet exoplanet in array)
                    {
                    double xValue = 0.0, maximumXError = 0.0, minimumXError = 0.0;
                    double yValue = 0.0, maximumYError = 0.0, minimumYError = 0.0;
                    bool isValid = false;

                    if (plotType >= PlotTypes.MassAndRadius && plotType <= PlotTypes.MassAndK)
                        {
                        if (double.TryParse (exoplanet.Mass, out xValue) == true)
                            if (double.TryParse (exoplanet.MassErrorMax, out maximumXError) == true)
                                if (double.TryParse (exoplanet.MassErrorMin, out minimumXError) == true)
                                    isValid = true;
                        }
                    else if (plotType >= PlotTypes.MassAndRadius && plotType <= PlotTypes.RadiusAndK)
                        {
                        if (double.TryParse (exoplanet.Radius, out xValue) == true)
                            if (double.TryParse (exoplanet.RadiusErrorMax, out maximumXError) == true)
                                if (double.TryParse (exoplanet.RadiusErrorMin, out minimumXError) == true)
                                    isValid = true;
                        }

                    if (isValid)
                        {
                        isValid = false;

                        switch (plotType)
                            {
                            case PlotTypes.MassAndRadius:  // x-axis is mass and to y-axis is radius
                                if (double.TryParse (exoplanet.Radius, out yValue) == true)
                                    if (double.TryParse (exoplanet.RadiusErrorMax, out maximumYError) == true)
                                        if (double.TryParse (exoplanet.RadiusErrorMin, out minimumYError) == true)
                                            isValid = true;
                                break;

                            case PlotTypes.RadiusAndMass:  // x-axis is radius and to y-axis is mass
                                if (double.TryParse (exoplanet.Mass, out yValue) == true)
                                    if (double.TryParse (exoplanet.MassErrorMax, out maximumYError) == true)
                                        if (double.TryParse (exoplanet.MassErrorMin, out minimumYError) == true)
                                            isValid = true;
                                break;

                            case PlotTypes.MassAndOrbitalPeriod:
                            case PlotTypes.RadiusAndOrbitalPeriod:
                                if (double.TryParse (exoplanet.OrbitalPeriod, out yValue) == true)
                                    if (double.TryParse (exoplanet.OrbitalPeriodErrorMax, out maximumYError) == true)
                                        if (double.TryParse (exoplanet.OrbitalPeriodErrorMin, out minimumYError) == true)
                                            isValid = true;
                                break;

                            case PlotTypes.MassAndSemiMajorAxis:
                            case PlotTypes.RadiusAndSemiMajorAxis:
                                if (double.TryParse (exoplanet.SemiMajorAxis, out yValue) == true)
                                    if (double.TryParse (exoplanet.SemiMajorAxisErrorMax, out maximumYError) == true)
                                        if (double.TryParse (exoplanet.SemiMajorAxisErrorMin, out minimumYError) == true)
                                            isValid = true;
                                break;

                            case PlotTypes.MassAndEccentricity:
                            case PlotTypes.RadiusAndEccentricity:
                                if (double.TryParse (exoplanet.Eccentricity, out yValue) == true)
                                    if (double.TryParse (exoplanet.EccentricityErrorMax, out maximumYError) == true)
                                        if (double.TryParse (exoplanet.EccentricityErrorMin, out minimumYError) == true)
                                            isValid = true;
                                break;

                            case PlotTypes.MassAndAngularDistance:
                            case PlotTypes.RadiusAndAngularDistance:
                                isValid = false;
                                break;

                            case PlotTypes.MassAndOmega:
                            case PlotTypes.RadiusAndOmega:
                                if (double.TryParse (exoplanet.Omega, out yValue) == true)
                                    if (double.TryParse (exoplanet.OmegaErrorMax, out maximumYError) == true)
                                        if (double.TryParse (exoplanet.OmegaErrorMin, out minimumYError) == true)
                                            isValid = true;
                                break;

                            case PlotTypes.MassAndInclination:
                            case PlotTypes.RadiusAndInclination:
                                if (double.TryParse (exoplanet.Inclination, out yValue) == true)
                                    if (double.TryParse (exoplanet.InclinationErrorMax, out maximumYError) == true)
                                        if (double.TryParse (exoplanet.InclinationErrorMin, out minimumYError) == true)
                                            isValid = true;
                                break;

                            case PlotTypes.MassAndTzeroTr:
                            case PlotTypes.RadiusAndTzeroTr:
                                if (double.TryParse (exoplanet.TzeroTr, out yValue) == true)
                                    if (double.TryParse (exoplanet.TzeroTrErrorMax, out maximumYError) == true)
                                        if (double.TryParse (exoplanet.TzeroTrErrorMin, out minimumYError) == true)
                                            isValid = true;
                                break;


                            case PlotTypes.MassAndTperi:
                            case PlotTypes.RadiusAndTperi:
                                if (double.TryParse (exoplanet.Tperi, out yValue) == true)
                                    if (double.TryParse (exoplanet.TperiErrorMax, out maximumYError) == true)
                                        if (double.TryParse (exoplanet.TperiErrorMin, out minimumYError) == true)
                                            isValid = true;
                                break;

                            case PlotTypes.MassAndK:
                            case PlotTypes.RadiusAndK:
                                if (double.TryParse (exoplanet.K, out yValue) == true)
                                    if (double.TryParse (exoplanet.KErrorMax, out maximumYError) == true)
                                        if (double.TryParse (exoplanet.KErrorMin, out minimumYError) == true)
                                            isValid = true;
                                break;
                            }
                        }

                    if (isValid)
                        {
                        if (yValue + maximumYError > maximumY)
                            maximumY = yValue + maximumYError;

                        if (yValue - minimumYError < minimumY)
                            minimumY = yValue - minimumYError;

                        if (xValue + maximumXError > maximumX)
                            maximumX = xValue + maximumXError;

                        if (xValue - minimumXError < minimumX)
                            minimumX = xValue - minimumXError;

                        VisualizeErrorBar (plotSurface, xValue, maximumXError, -minimumXError, yValue, maximumYError, -minimumYError);
                        }
                    }
                }
            }

        static public void VisualizeStars (NPlot.Windows.PlotSurface2D plotSurface, ArrayList exoplanets)
            {
            if (exoplanets == null)
                return;

            if (exoplanets.Count == 0)
                return;

            ArrayList stars = Exoplanets.GetStars (exoplanets);

            plotSurface.Clear ();
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

                                declination [0] = dec;
                                accession [0] = ra;

                                switch (Exoplanets.NumberOfExoplanets (exoplanets, star.Name))
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

            VisualizeAxis (plotSurface, "Right Accession 2000 (degrees)", "{0:0}", "Declination 2000 (degrees)", "{0:0.0}", true);
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

        static private void VisualizeLogYAxis (NPlot.Windows.PlotSurface2D plotSurface, PlotTypes plotType, CheckState logY, double minimumY, double maximumY)
            {
            string xAxisLabel = "Index";
            string xAxisFormat = "{0:0}";
            string yAxisLabel = "";
            string yAxisFormat = "{0:0.00}";

            switch (plotType)
                {
                case PlotTypes.Mass:
                    yAxisLabel = "Mass (Mjup)";
                    break;

                case PlotTypes.Radius:
                    yAxisLabel = "Radius (Rjup)";
                    break;

                case PlotTypes.OrbitalPeriod:
                    yAxisLabel = "Orbital Period (day)";
                    break;

                case PlotTypes.SemiMajorAxis:
                    yAxisLabel = "Semi-major Axis (AU)";
                    break;

                case PlotTypes.Eccentricity:
                    yAxisLabel = "Eccentricity";
                    break;

                case PlotTypes.AngularDistance:
                    yAxisLabel = "Angular Distance";
                    break;

                case PlotTypes.Inclination:
                    yAxisLabel = "Inclination (degree)";
                    break;

                case PlotTypes.TzeroTr:
                    yAxisLabel = "T0 (JD)";
                    break;

                case PlotTypes.TzeroTrSec:
                    yAxisLabel = "T0-Sec (JD)";
                    break;

                case PlotTypes.LambdaAngle:
                    yAxisLabel = "Lambda Angle (deg)";
                    break;

                case PlotTypes.TzeroVr:
                    yAxisLabel = "TVR (JD)";
                    break;

                case PlotTypes.TemperatureCalculated:
                    yAxisLabel = "Temperature Calculated (K)";
                    break;

                case PlotTypes.TemperatureMeasured:
                    yAxisLabel = "Temperature Measured (K)";
                    break;

                case PlotTypes.LogG:
                    yAxisLabel = "Log(g)";
                    break;

                case PlotTypes.Omega:
                    yAxisLabel = "Omega (deg)";
                    break;

                case PlotTypes.Tperi:
                    yAxisLabel = "Tperi (JD)";
                    break;

                case PlotTypes.K:
                    yAxisLabel = "K (m/s)";
                    break;

                case PlotTypes.GeometricAlbedo:
                    yAxisLabel = "Geometric Albedo";
                    break;

                case PlotTypes.Tconj:
                    yAxisLabel = "Tconj (JD)";
                    break;
                }

            if (logY == CheckState.Checked)
                if (minimumY <= 0.0)
                    minimumY = AlmostZero;

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

        static private void VisualizeLogXYAxis (NPlot.Windows.PlotSurface2D plotSurface, PlotTypes plotType, CheckState logX, double minimumX, double maximumX, CheckState logY, double minimumY, double maximumY)
            {
            string xAxisLabel = "";
            string xAxisFormat = "{0:0.00}";
            string yAxisLabel = "";
            string yAxisFormat = "{0:0.00}";

            switch (plotType)
                {
                case PlotTypes.MassAndRadius:
                    xAxisLabel = "Mass (Mjup)";
                    yAxisLabel = "Radius (Rjup)";
                    break;

                case PlotTypes.MassAndOrbitalPeriod:
                    xAxisLabel = "Mass (Mjup)";
                    yAxisLabel = "Orbital Period (day)";
                    break;

                case PlotTypes.MassAndSemiMajorAxis:
                    xAxisLabel = "Mass (Mjup)";
                    yAxisLabel = "Semi-Major Axis (AU)";
                    break;

                case PlotTypes.MassAndEccentricity:
                    xAxisLabel = "Mass (Mjup)";
                    yAxisLabel = "Eccentricity";
                    break;

                case PlotTypes.MassAndAngularDistance:
                    xAxisLabel = "Mass (Mjup)";
                    yAxisLabel = "Angular Distance (deg)";
                    break;

                case PlotTypes.MassAndOmega:
                    xAxisLabel = "Mass (Mjup)";
                    yAxisLabel = "Omega (deg)";
                    break;

                case PlotTypes.MassAndInclination:
                    xAxisLabel = "Mass (Mjup)";
                    yAxisLabel = "Inclination (deg)";
                    break;

                case PlotTypes.MassAndTzeroTr:
                    xAxisLabel = "Mass (Mjup)";
                    yAxisLabel = "T0 (JD)";
                    break;

                case PlotTypes.MassAndTperi:
                    xAxisLabel = "Mass (Mjup)";
                    yAxisLabel = "Tperi (JD)";
                    break;

                case PlotTypes.MassAndK:
                    xAxisLabel = "Mass (Mjup)";
                    yAxisLabel = "K (JD)";
                    break;
                //

                case PlotTypes.RadiusAndMass:
                    xAxisLabel = "Radius (Rjup)";
                    yAxisLabel = "Mass (Mjup)";
                    break;

                case PlotTypes.RadiusAndOrbitalPeriod:
                    xAxisLabel = "Radius (Rjup)";
                    yAxisLabel = "Orbital Period (day)";
                    break;

                case PlotTypes.RadiusAndSemiMajorAxis:
                    xAxisLabel = "Radius (Rjup)";
                    yAxisLabel = "Semi-Major Axis (AU)";
                    break;

                case PlotTypes.RadiusAndEccentricity:
                    xAxisLabel = "Radius (Rjup)";
                    yAxisLabel = "Eccentricity";
                    break;

                case PlotTypes.RadiusAndAngularDistance:
                    xAxisLabel = "Radius (Rjup)";
                    yAxisLabel = "Angular Distance (deg)";
                    break;

                case PlotTypes.RadiusAndOmega:
                    xAxisLabel = "Radius (Rjup)";
                    yAxisLabel = "Omega (deg)";
                    break;

                case PlotTypes.RadiusAndInclination:
                    xAxisLabel = "Radius (Rjup)";
                    yAxisLabel = "Incination (deg)";
                    break;

                case PlotTypes.RadiusAndTzeroTr:
                    xAxisLabel = "Radius (Rjup)";
                    yAxisLabel = "T0 (JD)";
                    break;

                case PlotTypes.RadiusAndTperi:
                    xAxisLabel = "Radius (Rjup)";
                    yAxisLabel = "Tperi (JD)";
                    break;

                case PlotTypes.RadiusAndK:
                    xAxisLabel = "Radius (Rjup)";
                    yAxisLabel = "K (JD)";
                    break;
                }

            if (logX == CheckState.Checked)
                if (minimumX <= 0.0)
                    minimumX = AlmostZero;

            if (logY == CheckState.Checked)
                if (minimumY <= 0.0)
                    minimumY = AlmostZero;

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

        static private void VisualizeCubicSpline (NPlot.Windows.PlotSurface2D plotSurface, PlotTypes plotType, double [] yAxis, double [] xAxis)
            {
            if (plotType == PlotTypes.Mass ||
                plotType == PlotTypes.Radius ||
                plotType == PlotTypes.Eccentricity ||
                plotType == PlotTypes.LogG ||
                plotType == PlotTypes.Omega)
                if (Visualization.LogYAxis == CheckState.Unchecked)
                    {
                    CubicSpline.CubicSpline cubicSpline = new CubicSpline.CubicSpline ();
                    float [] xs, ys;

                    cubicSpline.FitGeometric (xAxis, yAxis, 200, out xs, out ys);

                    LinePlot linePlot = new LinePlot ();
                    linePlot.AbscissaData = xs;
                    linePlot.OrdinateData = ys;
                    linePlot.Color = Color.Blue;
                    linePlot.Pen.Width = 1F;
                    plotSurface.Add (linePlot, PlotSurface2D.XAxisPosition.Bottom, PlotSurface2D.YAxisPosition.Left, 4);
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
            }

        static private void VisualizeErrorBarVerticalLine (NPlot.Windows.PlotSurface2D plotSurface, double value, double maximumError, double minimumError, int counter)
            {
            if (ErrorBars == ErrorBar.LinearPlots || ErrorBars == ErrorBar.LinearNPointPlots)
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

        static private void VisualizeErrorBar (NPlot.Windows.PlotSurface2D plotSurface,
            double xValue, double maximumXError, double minimumXError, double yValue, double maximumYError, double minimumYError)
            {
            if (Visualization.LogXAxis == CheckState.Checked)
                {
                if (xValue + maximumXError <= 0.0)
                    return;

                if (xValue + minimumXError <= 0.0)
                    return;
                }

            if (Visualization.LogYAxis == CheckState.Checked)
                {
                if (yValue + maximumYError <= 0.0)
                    return;

                if (yValue + minimumYError <= 0.0)
                    return;
                }

            VisualizeErrorBar2 (plotSurface, xValue, maximumXError, minimumXError, yValue, maximumYError, minimumYError);
            }

        static private void VisualizeErrorBar2 (NPlot.Windows.PlotSurface2D plotSurface, double xValue, double maximumXError, double minimumXError, double yValue, double maximumYError, double minimumYError)
            {
            if (ErrorBars == ErrorBar.PointPlots || ErrorBars == ErrorBar.LinearNPointPlots)
                {
                double [] errors = new double [2];          // vertical error bar
                double [] xAxis = new double [2];

                errors [0] = yValue + maximumYError;
                errors [1] = yValue + minimumYError;
                xAxis [0] = xValue;
                xAxis [1] = xValue;

                LinePlot linePlot = new LinePlot ();

                linePlot.AbscissaData = xAxis;
                linePlot.DataSource = errors;
                linePlot.Color = Color.Black;
                linePlot.Pen.Width = 1F;
                plotSurface.Add (linePlot, PlotSurface2D.XAxisPosition.Bottom, PlotSurface2D.YAxisPosition.Left);

                double [] errors2 = new double [2];         // horizontal error bar
                double [] yAxis = new double [2];

                errors2 [0] = xValue + maximumXError;
                errors2 [1] = xValue + minimumXError;
                yAxis [0] = yValue;
                yAxis [1] = yValue;

                LinePlot linePlot2 = new LinePlot ();

                linePlot2.AbscissaData = errors2;
                linePlot2.DataSource = yAxis;
                linePlot2.Color = Color.Black;
                linePlot2.Pen.Width = 1F;
                plotSurface.Add (linePlot2, PlotSurface2D.XAxisPosition.Bottom, PlotSurface2D.YAxisPosition.Left);
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

        static public void ChangeInteraction (NPlot.Windows.PlotSurface2D plotSurface)
            {
            Interaction = Interaction == DynamicInteractions.Area ? DynamicInteractions.Pan : DynamicInteractions.Area;
            AddInteraction (plotSurface);
            }

        static public void AddInteraction (NPlot.Windows.PlotSurface2D plotSurface)
            {
            if (Interactions [0] != null)
                plotSurface.RemoveInteraction (Interactions [0]);

            if (Interactions [1] != null)
                plotSurface.RemoveInteraction (Interactions [1]);

            if (Interaction == DynamicInteractions.Area)
                {
                Interactions [0] = new NPlot.Windows.PlotSurface2D.Interactions.RubberBandSelection ();
                Interactions [1] = null;
                }
            else if (Interaction == DynamicInteractions.Pan)
                {
                Interactions [0] = new NPlot.Windows.PlotSurface2D.Interactions.HorizontalDrag ();
                Interactions [1] = new NPlot.Windows.PlotSurface2D.Interactions.VerticalDrag ();
                }

            if (Interactions [0] != null)
                plotSurface.AddInteraction (Interactions [0]);

            if (Interactions [1] != null)
                plotSurface.AddInteraction (Interactions [1]);
            }
        }
    }
