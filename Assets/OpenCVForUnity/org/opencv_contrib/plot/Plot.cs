

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace OpenCVForUnity
{
    public class Plot
    {

        //
        // C++:  Ptr_Plot2d createPlot2d(Mat data)
        //

        //javadoc: createPlot2d(data)
        public static Plot2d createPlot2d (Mat data)
        {
            if (data != null) data.ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        
        Plot2d retVal = new Plot2d(plot_Plot_createPlot2d_10(data.nativeObj));
        
#else
            return null;
#endif
            return retVal;
        }


        //
        // C++:  Ptr_Plot2d createPlot2d(Mat dataX, Mat dataY)
        //

        //javadoc: createPlot2d(dataX, dataY)
        public static Plot2d createPlot2d (Mat dataX, Mat dataY)
        {
            if (dataX != null) dataX.ThrowIfDisposed ();
            if (dataY != null) dataY.ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        
        Plot2d retVal = new Plot2d(plot_Plot_createPlot2d_11(dataX.nativeObj, dataY.nativeObj));
        
#else
            return null;
#endif
            return retVal;
        }


#if (UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR
        const string LIBNAME = "__Internal";
#else
        const string LIBNAME = "opencvforunity";
#endif



        // C++:  Ptr_Plot2d createPlot2d(Mat data)
        [DllImport (LIBNAME)]
        private static extern IntPtr plot_Plot_createPlot2d_10 (IntPtr data_nativeObj);

        // C++:  Ptr_Plot2d createPlot2d(Mat dataX, Mat dataY)
        [DllImport (LIBNAME)]
        private static extern IntPtr plot_Plot_createPlot2d_11 (IntPtr dataX_nativeObj, IntPtr dataY_nativeObj);

    }
}
