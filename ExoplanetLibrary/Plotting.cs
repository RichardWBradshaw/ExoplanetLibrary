﻿using NPlot;
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
        Omega = 8,
        VelocitySemiamplitude = 9,
        TemperatureCalculated = 10,

        MassAndRadius = 30,
        MassAndOrbitalPeriod = 31,
        MassAndSemiMajorAxis = 32,
        MassAndEccentricity = 33,
        MassAndAngularDistance = 34,
        MassAndInclination = 35,
        MassAndOmega = 36,
        MassAndVelocitySemiamplitude = 37,

        RadiusAndMass = 40,
        RadiusAndOrbitalPeriod = 41,
        RadiusAndSemiMajorAxis = 42,
        RadiusAndEccentricity = 43,
        RadiusAndAngularDistance = 44,
        RadiusAndInclination = 45,
        RadiusAndOmega = 46,
        RadiusAndVelocitySemiamplitude = 47,

        Stars = 100,
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

        static public void VisualizeLinearDiagrams (NPlot.Windows.PlotSurface2D plotSurface, ArrayList exoplanets, PlotTypes plotType)
            {
            if (exoplanets == null)
                return;

            if (exoplanets.Count == 0)
                return;

            double [] xAxis = new double [exoplanets.Count];
            double [] yAxis = new double [exoplanets.Count];
            int counter = 0;

            foreach (Exoplanet exoplanet in exoplanets)
                {
                if (Visualization.UtilizeQuery == CheckState.Checked)
                    if (Queries.CurrentQueries != null)
                        if (!Queries.CurrentQueries.MatchesQuery (exoplanet))
                            continue;

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

                    case PlotTypes.TemperatureCalculated:
                        isValid = double.TryParse (exoplanet.TemperatureCalculated, out value);
                        break;

                    case PlotTypes.Omega:
                        isValid = double.TryParse (exoplanet.Omega, out value);
                        break;

                    case PlotTypes.VelocitySemiamplitude:
                        isValid = double.TryParse (exoplanet.VelocitySemiamplitude, out value);
                        break;
                    }

                if (isValid)
                    {
                    yAxis [counter] = value;
                    xAxis [counter] = counter + 1;
                    counter++;
                    }
                }

            if (Visualization.LogYAxis == CheckState.Checked)
                {
                int nonZeros = CountPositives (yAxis);
                double [] xAxisCopy = new double [nonZeros];
                double [] yAxisCopy = new double [nonZeros];

                CopyPositives (xAxis, yAxis, ref xAxisCopy, ref yAxisCopy);

                xAxis = xAxisCopy;
                yAxis = yAxisCopy;
                }

            plotSurface.Clear ();
            plotSurface.BackColor = BackgroundColor;

            LinePlot linePlot = new LinePlot ();
            linePlot.AbscissaData = xAxis;
            linePlot.OrdinateData = yAxis;
            linePlot.Color = LineColor;
            linePlot.Pen.Width = LinePenWidth;
            plotSurface.Add (linePlot, PlotSurface2D.XAxisPosition.Bottom, PlotSurface2D.YAxisPosition.Left, OnTopZOrder);

            double minimumY = Helper.GetMinimum (yAxis);
            double maximumY = Helper.GetMaximum (yAxis);

            VisualizeErrorBars (plotSurface, exoplanets, plotType, ref minimumY, ref maximumY);
            VisualizeEmbellishments (plotSurface, plotType, xAxis, yAxis);
            VisualizeLogYAxis (plotSurface, plotType, Visualization.LogYAxis, minimumY, maximumY);
            VisualizeLegend (plotSurface);

            plotSurface.Refresh ();
            }

        static public void VisualizeErrorBars (NPlot.Windows.PlotSurface2D plotSurface, ArrayList array, PlotTypes plotType, ref double minimumY, ref double maximumY)
            {
            if (Visualization.IncludeErrorBars == CheckState.Checked)
                {
                int counter = 0;

                foreach (Exoplanet exoplanet in array)
                    {
                    if (Visualization.UtilizeQuery == CheckState.Checked)
                        if (Queries.CurrentQueries != null)
                            if (!Queries.CurrentQueries.MatchesQuery (exoplanet))
                                continue;

                    double value = 0.0, maximumError = 0.0, minimumError = 0.0;
                    bool isValid = false;

                    switch (plotType)
                        {
                        case PlotTypes.Mass:
                            if (double.TryParse (exoplanet.Mass, out value) == true)
                                if (double.TryParse (exoplanet.MassSiniErrorMax, out maximumError) == true)
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

                        case PlotTypes.TemperatureCalculated:
                            isValid = false;
                            break;

                        case PlotTypes.Omega:
                            if (double.TryParse (exoplanet.Omega, out value) == true)
                                if (double.TryParse (exoplanet.OmegaErrorMax, out maximumError) == true)
                                    if (double.TryParse (exoplanet.OmegaErrorMin, out minimumError) == true)
                                        isValid = true;
                            break;

                        case PlotTypes.VelocitySemiamplitude:
                            if (double.TryParse (exoplanet.VelocitySemiamplitude, out value) == true)
                                if (double.TryParse (exoplanet.VelocitySemiamplitudeErrorMax, out maximumError) == true)
                                    if (double.TryParse (exoplanet.VelocitySemiamplitudeErrorMin, out minimumError) == true)
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

            double [] xAxis = new double [exoplanets.Count];
            double [] yAxis = new double [exoplanets.Count];
            string [] names = new string [exoplanets.Count];
            int counter = 0;

            foreach (Exoplanet exoplanet in exoplanets)
                {
                if (Visualization.UtilizeQuery == CheckState.Checked)
                    if (Queries.CurrentQueries != null)
                        if (!Queries.CurrentQueries.MatchesQuery (exoplanet))
                            continue;

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

                    case PlotTypes.MassAndVelocitySemiamplitude:
                        if (double.TryParse (exoplanet.Mass, out xvalue) == true)
                            if (double.TryParse (exoplanet.VelocitySemiamplitude, out yvalue) == true)
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

                    case PlotTypes.RadiusAndVelocitySemiamplitude:
                        if (double.TryParse (exoplanet.Radius, out xvalue) == true)
                            if (double.TryParse (exoplanet.VelocitySemiamplitude, out yvalue) == true)
                                isValid = true;
                        break;
                    }

                if (isValid)
                    {
                    yAxis [counter] = yvalue;
                    xAxis [counter] = xvalue;
                    names [counter] = exoplanet.Name;
                    counter++;
                    }
                }

            if (Visualization.LogXAxis == CheckState.Checked || Visualization.LogYAxis == CheckState.Checked)
                {
                int nonZeroXs = CountPositives (xAxis);
                int nonZeroYs = CountPositives (yAxis);
                int nonZeros = ( nonZeroYs <= nonZeroXs ) ? nonZeroYs : nonZeroXs;
                double [] xAxisCopy = new double [nonZeros];
                double [] yAxisCopy = new double [nonZeros];
                string [] namesCopy = new string [nonZeros];

                CopyPositives (xAxis, yAxis, names, ref xAxisCopy, ref yAxisCopy, ref namesCopy);

                xAxis = xAxisCopy;
                yAxis = yAxisCopy;
                names = namesCopy;
                }

            plotSurface.Clear ();
            plotSurface.BackColor = BackgroundColor;

            if (Visualization.IncludeNames == CheckState.Checked)
                {
                LabelPointPlot labelPointPlot = new LabelPointPlot ();

                labelPointPlot.AbscissaData = xAxis;
                labelPointPlot.DataSource = yAxis;
                labelPointPlot.TextData = names;
                labelPointPlot.Marker.Color = PointColor;
                labelPointPlot.Marker.Type = Marker.MarkerType.FilledCircle;
                labelPointPlot.Font = new Font ("Arial", 6);
                labelPointPlot.LabelTextPosition = LabelPointPlot.LabelPositions.Above;
                plotSurface.Add (labelPointPlot, PlotSurface2D.XAxisPosition.Bottom, PlotSurface2D.YAxisPosition.Left);
                }
            else
                {
                PointPlot pointPlot = new PointPlot ();
                pointPlot.AbscissaData = xAxis;
                pointPlot.DataSource = yAxis;
                pointPlot.Marker.Color = PointColor;
                pointPlot.Marker.Type = Marker.MarkerType.FilledCircle;

                plotSurface.Add (pointPlot, PlotSurface2D.XAxisPosition.Bottom, PlotSurface2D.YAxisPosition.Left);
                }

            double minimumX = Helper.GetMinimum (xAxis);
            double maximumX = Helper.GetMaximum (xAxis);
            double minimumY = Helper.GetMinimum (yAxis);
            double maximumY = Helper.GetMaximum (yAxis);

            VisualizeErrorBars (plotSurface, exoplanets, plotType, ref minimumX, ref maximumX, ref minimumY, ref maximumY);
            VisualizeEmbellishments (plotSurface, plotType, xAxis, yAxis);
            VisualizeLogXYAxis (plotSurface, plotType, Visualization.LogXAxis, minimumX, maximumX, Visualization.LogYAxis, minimumY, maximumY);
            VisualizeLegend (plotSurface);

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

                    if (plotType >= PlotTypes.MassAndRadius && plotType <= PlotTypes.MassAndVelocitySemiamplitude)
                        {
                        if (double.TryParse (exoplanet.Mass, out xValue) == true)
                            if (double.TryParse (exoplanet.MassSiniErrorMax, out maximumXError) == true)
                                if (double.TryParse (exoplanet.MassErrorMin, out minimumXError) == true)
                                    isValid = true;
                        }
                    else if (plotType >= PlotTypes.MassAndRadius && plotType <= PlotTypes.RadiusAndVelocitySemiamplitude)
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
                            case PlotTypes.MassAndRadius:  // x-axis is mass and y-axis is radius
                                if (double.TryParse (exoplanet.Radius, out yValue) == true)
                                    if (double.TryParse (exoplanet.RadiusErrorMax, out maximumYError) == true)
                                        if (double.TryParse (exoplanet.RadiusErrorMin, out minimumYError) == true)
                                            isValid = true;
                                break;

                            case PlotTypes.RadiusAndMass:  // x-axis is radius and y-axis is mass
                                if (double.TryParse (exoplanet.Mass, out yValue) == true)
                                    if (double.TryParse (exoplanet.MassSiniErrorMax, out maximumYError) == true)
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

                            case PlotTypes.MassAndVelocitySemiamplitude:
                            case PlotTypes.RadiusAndVelocitySemiamplitude:
                                if (double.TryParse (exoplanet.VelocitySemiamplitude, out yValue) == true)
                                    if (double.TryParse (exoplanet.VelocitySemiamplitudeErrorMax, out maximumYError) == true)
                                        if (double.TryParse (exoplanet.VelocitySemiamplitudeErrorMin, out minimumYError) == true)
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

                                if (Visualization.IncludeNames == CheckState.Checked)
                                    {
                                    LabelPointPlot labelPointPlot = new LabelPointPlot ();
                                    string [] names = new string [1];

                                    names [0] = star.Name;
                                    labelPointPlot.AbscissaData = accession;
                                    labelPointPlot.DataSource = declination;
                                    labelPointPlot.TextData = names;
                                    labelPointPlot.Marker.Color = pointPlot.Marker.Color;
                                    labelPointPlot.Marker.Type = pointPlot.Marker.Type;
                                    labelPointPlot.Font = new Font ("Arial", 6);
                                    labelPointPlot.LabelTextPosition = LabelPointPlot.LabelPositions.Above;
                                    plotSurface.Add (labelPointPlot, PlotSurface2D.XAxisPosition.Bottom, PlotSurface2D.YAxisPosition.Left);
                                    }
                                else
                                    {
                                    plotSurface.Add (pointPlot, PlotSurface2D.XAxisPosition.Bottom, PlotSurface2D.YAxisPosition.Left);
                                    }
                                }
                        }
                }

            VisualizeAxis (plotSurface, "Right Accession 2000 (degrees)", "{0:0}", "Declination 2000 (degrees)", "{0:0.0}", true);
            VisualizeLegend (plotSurface);

            plotSurface.Refresh ();
            }

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
            string yAxisLabel = string.Empty;
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

                case PlotTypes.TemperatureCalculated:
                    yAxisLabel = "Temperature Calculated (K)";
                    break;

                case PlotTypes.Omega:
                    yAxisLabel = "Omega (deg)";
                    break;

                case PlotTypes.VelocitySemiamplitude:
                    yAxisLabel = "Velocity Semiamplitude (m/s)";
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
            string xAxisLabel = string.Empty;
            string xAxisFormat = "{0:0.00}";
            string yAxisLabel = string.Empty;
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

                case PlotTypes.MassAndVelocitySemiamplitude:
                    xAxisLabel = "Mass (Mjup)";
                    yAxisLabel = "Velocity Semiamplitude (m/s)";
                    break;

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

                case PlotTypes.RadiusAndVelocitySemiamplitude:
                    xAxisLabel = "Radius (Rjup)";
                    yAxisLabel = "Velocity Semiamplitude (m/s)";
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

        static private void VisualizeEmbellishments (NPlot.Windows.PlotSurface2D plotSurface, PlotTypes plotType, double [] xAxis, double [] yAxis)
            {
            if (plotType == PlotTypes.Mass ||
                plotType == PlotTypes.Radius ||
                plotType == PlotTypes.OrbitalPeriod ||
                plotType == PlotTypes.SemiMajorAxis ||
                plotType == PlotTypes.Eccentricity ||
                plotType == PlotTypes.AngularDistance ||
                plotType == PlotTypes.Inclination ||
                plotType == PlotTypes.Omega ||
                plotType == PlotTypes.VelocitySemiamplitude ||
                plotType == PlotTypes.TemperatureCalculated)
                {
                VisualizeCubicSpline (plotSurface, xAxis, yAxis);
                }
            else if (plotType == PlotTypes.MassAndRadius ||
                plotType == PlotTypes.MassAndOrbitalPeriod ||
                plotType == PlotTypes.MassAndSemiMajorAxis ||
                plotType == PlotTypes.MassAndEccentricity ||
                plotType == PlotTypes.MassAndAngularDistance ||
                plotType == PlotTypes.MassAndInclination ||
                plotType == PlotTypes.MassAndOmega ||
                plotType == PlotTypes.MassAndVelocitySemiamplitude ||
                plotType == PlotTypes.RadiusAndMass ||
                plotType == PlotTypes.RadiusAndOrbitalPeriod ||
                plotType == PlotTypes.RadiusAndSemiMajorAxis ||
                plotType == PlotTypes.RadiusAndEccentricity ||
                plotType == PlotTypes.RadiusAndAngularDistance ||
                plotType == PlotTypes.RadiusAndInclination ||
                plotType == PlotTypes.RadiusAndOmega ||
                plotType == PlotTypes.RadiusAndVelocitySemiamplitude)
                {
                if (Visualization.IncludeBestFitLine == CheckState.Checked)
                    VisualizeBestFitLine (plotSurface, xAxis, yAxis, BestFitType.Line);

                if (Visualization.IncludeBestFitCurve == CheckState.Checked)
                    VisualizeBestFitLine (plotSurface, xAxis, yAxis, BestFitType.Curve);
                }
            }

        static private void VisualizeCubicSpline (NPlot.Windows.PlotSurface2D plotSurface, double [] xAxis, double [] yAxis)
            {
#if IncludeCubicSpline
            if (Visualization.LogYAxis == CheckState.Unchecked)
                {
                CubicSpline.CubicSpline cubicSpline = new CubicSpline.CubicSpline ();
                float [] xs, ys;
                int numberOfPoints = xAxis.Length / 10;

                cubicSpline.FitGeometric (xAxis, yAxis, numberOfPoints, out xs, out ys);

                LinePlot linePlot = new LinePlot ();
                linePlot.AbscissaData = xs;
                linePlot.OrdinateData = ys;
                linePlot.Color = Color.Blue;
                linePlot.Pen.Width = 1F;
                plotSurface.Add (linePlot, PlotSurface2D.XAxisPosition.Bottom, PlotSurface2D.YAxisPosition.Left, 4);
                }
#endif
            }

        static private void VisualizeBestFitLine (NPlot.Windows.PlotSurface2D plotSurface, double [] xAxis, double [] yAxis, BestFitType type)
            {
            double [] x = new double [250];
            double [] y = new double [250];
            double minimumX = Helper.GetMinimum (xAxis);
            double maximumX = Helper.GetMaximum (xAxis);

            if (minimumX <= AlmostZero)
                minimumX = AlmostZero;

            double interval = ( maximumX - minimumX ) / ( x.Length - 1 );

            BestFit bestFit = new BestFit (type);

            bestFit.Compute (xAxis, yAxis);

            for (int index = 0; index < x.Length; ++index)
                {
                x [index] = minimumX + index * interval;
                y [index] = bestFit.ComputeYAtX (x [index]);
                }

            bool valid = true;
            int firstIndex = 0, lastIndex = x.Length - 1;

            if (Visualization.LogXAxis == CheckState.Checked || Visualization.LogYAxis == CheckState.Checked)
                {
                for (int index = 0; index < x.Length; ++index)
                    {
                    if (x [index] >= AlmostZero && y [index] >= AlmostZero)
                        {
                        firstIndex = index;
                        break;
                        }
                    }

                for (int index = x.Length - 1; index > firstIndex; --index)
                    {
                    if (x [index] >= AlmostZero && y [index] >= AlmostZero)
                        {
                        lastIndex = index;
                        break;
                        }
                    }

                int count = lastIndex - firstIndex + 1;
                double [] cx = new double [count];
                double [] cy = new double [count];

                for (int index = 0; index < count; ++index)
                    {
                    cx [index] = x [firstIndex + index];
                    cy [index] = y [firstIndex + index];
                    }

                x = cx;
                y = cy;

                valid = true;
                }

            if (valid == true)
                {
                LinePlot linePlot = new LinePlot ();

                linePlot.AbscissaData = x;
                linePlot.DataSource = y;
                linePlot.Color = ( type == BestFitType.Line ) ? Color.Green : Color.Red;
                linePlot.Pen.Width = 2F;
                plotSurface.Add (linePlot, PlotSurface2D.XAxisPosition.Bottom, PlotSurface2D.YAxisPosition.Left);
                }
            }

        static private void VisualizeLegend (NPlot.Windows.PlotSurface2D plotSurface)
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

        static private int CountPositives (double [] data)
            {
            int count = 0;

            for (int index = 0; index < data.Length; ++index)
                if (( double )data [index] > 0.0)
                    ++count;

            return count;
            }

        static private int CopyPositives (double [] originalX, double [] originalY, ref double [] copyX, ref double [] copyY)
            {
            int count = 0;

            for (int index = 0; index < originalY.Length; ++index)
                if (originalX [index] > 0.0 && originalY [index] > 0.0)
                    {
                    copyX [count] = originalX [index];
                    copyY [count] = originalY [index];
                    ++count;
                    }

            return count;
            }

        static private int CopyPositives (double [] originalX, double [] originalY, string [] originalName, ref double [] copyX, ref double [] copyY, ref string [] copyName)
            {
            int count = 0;

            for (int index = 0; index < originalY.Length; ++index)
                if (originalX [index] > 0.0 && originalY [index] > 0.0)
                    {
                    copyX [count] = originalX [index];
                    copyY [count] = originalY [index];
                    copyName [count] = originalName [index];
                    ++count;
                    }

            return count;
            }
        }
    }
