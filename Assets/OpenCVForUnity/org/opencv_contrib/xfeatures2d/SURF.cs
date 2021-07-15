

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace OpenCVForUnity
{

    // C++: class SURF
    //javadoc: SURF
    public class SURF : Feature2D
    {

        protected override void Dispose (bool disposing)
        {
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
try {
if (disposing) {
}
if (IsEnabledDispose) {
if (nativeObj != IntPtr.Zero)
xfeatures2d_SURF_delete(nativeObj);
nativeObj = IntPtr.Zero;
}
} finally {
base.Dispose (disposing);
}
#else
            return;
#endif
        }

        protected internal SURF (IntPtr addr) : base (addr) { }


        //
        // C++: static Ptr_SURF create(double hessianThreshold = 100, int nOctaves = 4, int nOctaveLayers = 3, bool extended = false, bool upright = false)
        //

        //javadoc: SURF::create(hessianThreshold, nOctaves, nOctaveLayers, extended, upright)
        public static SURF create (double hessianThreshold, int nOctaves, int nOctaveLayers, bool extended, bool upright)
        {
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        
        SURF retVal = new SURF(xfeatures2d_SURF_create_10(hessianThreshold, nOctaves, nOctaveLayers, extended, upright));
        
#else
            return null;
#endif
            return retVal;
        }

        //javadoc: SURF::create()
        public static SURF create ()
        {
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        
        SURF retVal = new SURF(xfeatures2d_SURF_create_11());
        
#else
            return null;
#endif
            return retVal;
        }


        //
        // C++:  bool getExtended()
        //

        //javadoc: SURF::getExtended()
        public bool getExtended ()
        {
            ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        
        bool retVal = xfeatures2d_SURF_getExtended_10(nativeObj);
        
#else
            return false;
#endif
            return retVal;
        }


        //
        // C++:  bool getUpright()
        //

        //javadoc: SURF::getUpright()
        public bool getUpright ()
        {
            ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        
        bool retVal = xfeatures2d_SURF_getUpright_10(nativeObj);
        
#else
            return false;
#endif
            return retVal;
        }


        //
        // C++:  double getHessianThreshold()
        //

        //javadoc: SURF::getHessianThreshold()
        public double getHessianThreshold ()
        {
            ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        
        double retVal = xfeatures2d_SURF_getHessianThreshold_10(nativeObj);
        
#else
            return -1;
#endif
            return retVal;
        }


        //
        // C++:  int getNOctaveLayers()
        //

        //javadoc: SURF::getNOctaveLayers()
        public int getNOctaveLayers ()
        {
            ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        
        int retVal = xfeatures2d_SURF_getNOctaveLayers_10(nativeObj);
        
#else
            return -1;
#endif
            return retVal;
        }


        //
        // C++:  int getNOctaves()
        //

        //javadoc: SURF::getNOctaves()
        public int getNOctaves ()
        {
            ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        
        int retVal = xfeatures2d_SURF_getNOctaves_10(nativeObj);
        
#else
            return -1;
#endif
            return retVal;
        }


        //
        // C++:  void setExtended(bool extended)
        //

        //javadoc: SURF::setExtended(extended)
        public void setExtended (bool extended)
        {
            ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        
        xfeatures2d_SURF_setExtended_10(nativeObj, extended);
        
#else
            return;
#endif
            return;
        }


        //
        // C++:  void setHessianThreshold(double hessianThreshold)
        //

        //javadoc: SURF::setHessianThreshold(hessianThreshold)
        public void setHessianThreshold (double hessianThreshold)
        {
            ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        
        xfeatures2d_SURF_setHessianThreshold_10(nativeObj, hessianThreshold);
        
#else
            return;
#endif
            return;
        }


        //
        // C++:  void setNOctaveLayers(int nOctaveLayers)
        //

        //javadoc: SURF::setNOctaveLayers(nOctaveLayers)
        public void setNOctaveLayers (int nOctaveLayers)
        {
            ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        
        xfeatures2d_SURF_setNOctaveLayers_10(nativeObj, nOctaveLayers);
        
#else
            return;
#endif
            return;
        }


        //
        // C++:  void setNOctaves(int nOctaves)
        //

        //javadoc: SURF::setNOctaves(nOctaves)
        public void setNOctaves (int nOctaves)
        {
            ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        
        xfeatures2d_SURF_setNOctaves_10(nativeObj, nOctaves);
        
#else
            return;
#endif
            return;
        }


        //
        // C++:  void setUpright(bool upright)
        //

        //javadoc: SURF::setUpright(upright)
        public void setUpright (bool upright)
        {
            ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        
        xfeatures2d_SURF_setUpright_10(nativeObj, upright);
        
#else
            return;
#endif
            return;
        }


#if (UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR
        const string LIBNAME = "__Internal";
#else
        const string LIBNAME = "opencvforunity";
#endif



        // C++: static Ptr_SURF create(double hessianThreshold = 100, int nOctaves = 4, int nOctaveLayers = 3, bool extended = false, bool upright = false)
        [DllImport (LIBNAME)]
        private static extern IntPtr xfeatures2d_SURF_create_10 (double hessianThreshold, int nOctaves, int nOctaveLayers, bool extended, bool upright);
        [DllImport (LIBNAME)]
        private static extern IntPtr xfeatures2d_SURF_create_11 ();

        // C++:  bool getExtended()
        [DllImport (LIBNAME)]
        private static extern bool xfeatures2d_SURF_getExtended_10 (IntPtr nativeObj);

        // C++:  bool getUpright()
        [DllImport (LIBNAME)]
        private static extern bool xfeatures2d_SURF_getUpright_10 (IntPtr nativeObj);

        // C++:  double getHessianThreshold()
        [DllImport (LIBNAME)]
        private static extern double xfeatures2d_SURF_getHessianThreshold_10 (IntPtr nativeObj);

        // C++:  int getNOctaveLayers()
        [DllImport (LIBNAME)]
        private static extern int xfeatures2d_SURF_getNOctaveLayers_10 (IntPtr nativeObj);

        // C++:  int getNOctaves()
        [DllImport (LIBNAME)]
        private static extern int xfeatures2d_SURF_getNOctaves_10 (IntPtr nativeObj);

        // C++:  void setExtended(bool extended)
        [DllImport (LIBNAME)]
        private static extern void xfeatures2d_SURF_setExtended_10 (IntPtr nativeObj, bool extended);

        // C++:  void setHessianThreshold(double hessianThreshold)
        [DllImport (LIBNAME)]
        private static extern void xfeatures2d_SURF_setHessianThreshold_10 (IntPtr nativeObj, double hessianThreshold);

        // C++:  void setNOctaveLayers(int nOctaveLayers)
        [DllImport (LIBNAME)]
        private static extern void xfeatures2d_SURF_setNOctaveLayers_10 (IntPtr nativeObj, int nOctaveLayers);

        // C++:  void setNOctaves(int nOctaves)
        [DllImport (LIBNAME)]
        private static extern void xfeatures2d_SURF_setNOctaves_10 (IntPtr nativeObj, int nOctaves);

        // C++:  void setUpright(bool upright)
        [DllImport (LIBNAME)]
        private static extern void xfeatures2d_SURF_setUpright_10 (IntPtr nativeObj, bool upright);

        // native support for java finalize()
        [DllImport (LIBNAME)]
        private static extern void xfeatures2d_SURF_delete (IntPtr nativeObj);

    }
}
