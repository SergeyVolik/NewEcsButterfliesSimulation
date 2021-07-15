

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace OpenCVForUnity
{

    // C++: class SIFT
    //javadoc: SIFT
    public class SIFT : Feature2D
    {

        protected override void Dispose (bool disposing)
        {
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
try {
if (disposing) {
}
if (IsEnabledDispose) {
if (nativeObj != IntPtr.Zero)
xfeatures2d_SIFT_delete(nativeObj);
nativeObj = IntPtr.Zero;
}
} finally {
base.Dispose (disposing);
}
#else
            return;
#endif
        }

        protected internal SIFT (IntPtr addr) : base (addr) { }


        //
        // C++: static Ptr_SIFT create(int nfeatures = 0, int nOctaveLayers = 3, double contrastThreshold = 0.04, double edgeThreshold = 10, double sigma = 1.6)
        //

        //javadoc: SIFT::create(nfeatures, nOctaveLayers, contrastThreshold, edgeThreshold, sigma)
        public static SIFT create (int nfeatures, int nOctaveLayers, double contrastThreshold, double edgeThreshold, double sigma)
        {
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        
        SIFT retVal = new SIFT(xfeatures2d_SIFT_create_10(nfeatures, nOctaveLayers, contrastThreshold, edgeThreshold, sigma));
        
#else
            return null;
#endif
            return retVal;
        }

        //javadoc: SIFT::create()
        public static SIFT create ()
        {
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        
        SIFT retVal = new SIFT(xfeatures2d_SIFT_create_11());
        
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



        // C++: static Ptr_SIFT create(int nfeatures = 0, int nOctaveLayers = 3, double contrastThreshold = 0.04, double edgeThreshold = 10, double sigma = 1.6)
        [DllImport (LIBNAME)]
        private static extern IntPtr xfeatures2d_SIFT_create_10 (int nfeatures, int nOctaveLayers, double contrastThreshold, double edgeThreshold, double sigma);
        [DllImport (LIBNAME)]
        private static extern IntPtr xfeatures2d_SIFT_create_11 ();

        // native support for java finalize()
        [DllImport (LIBNAME)]
        private static extern void xfeatures2d_SIFT_delete (IntPtr nativeObj);

    }
}
