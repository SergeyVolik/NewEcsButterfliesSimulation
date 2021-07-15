

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace OpenCVForUnity
{

    // C++: class StructuredLightPattern
    //javadoc: StructuredLightPattern
    public class StructuredLightPattern : Algorithm
    {

        protected override void Dispose (bool disposing)
        {
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
try {
if (disposing) {
}
if (IsEnabledDispose) {
if (nativeObj != IntPtr.Zero)
structured_1light_StructuredLightPattern_delete(nativeObj);
nativeObj = IntPtr.Zero;
}
} finally {
base.Dispose (disposing);
}
#else
            return;
#endif
        }

        protected internal StructuredLightPattern (IntPtr addr) : base (addr) { }


        //
        // C++:  bool decode(vector_Mat patternImages, Mat& disparityMap, vector_Mat blackImages = vector_Mat(), vector_Mat whiteImages = vector_Mat(), int flags = DECODE_3D_UNDERWORLD)
        //

        //javadoc: StructuredLightPattern::decode(patternImages, disparityMap, blackImages, whiteImages, flags)
        public bool decode (List<Mat> patternImages, Mat disparityMap, List<Mat> blackImages, List<Mat> whiteImages, int flags)
        {
            ThrowIfDisposed ();
            if (disparityMap != null) disparityMap.ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        Mat patternImages_mat = Converters.vector_Mat_to_Mat(patternImages);
        Mat blackImages_mat = Converters.vector_Mat_to_Mat(blackImages);
        Mat whiteImages_mat = Converters.vector_Mat_to_Mat(whiteImages);
        bool retVal = structured_1light_StructuredLightPattern_decode_10(nativeObj, patternImages_mat.nativeObj, disparityMap.nativeObj, blackImages_mat.nativeObj, whiteImages_mat.nativeObj, flags);
        
#else
            return false;
#endif
            return retVal;
        }

        //javadoc: StructuredLightPattern::decode(patternImages, disparityMap)
        public bool decode (List<Mat> patternImages, Mat disparityMap)
        {
            ThrowIfDisposed ();
            if (disparityMap != null) disparityMap.ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        Mat patternImages_mat = Converters.vector_Mat_to_Mat(patternImages);
        bool retVal = structured_1light_StructuredLightPattern_decode_11(nativeObj, patternImages_mat.nativeObj, disparityMap.nativeObj);
        
#else
            return false;
#endif
            return retVal;
        }


        //
        // C++:  bool generate(vector_Mat& patternImages)
        //

        //javadoc: StructuredLightPattern::generate(patternImages)
        public bool generate (List<Mat> patternImages)
        {
            ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        Mat patternImages_mat = new Mat();
        bool retVal = structured_1light_StructuredLightPattern_generate_10(nativeObj, patternImages_mat.nativeObj);
        Converters.Mat_to_vector_Mat(patternImages_mat, patternImages);
        patternImages_mat.release();
#else
            return false;
#endif
            return retVal;
        }


#if (UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR
        const string LIBNAME = "__Internal";
#else
        const string LIBNAME = "opencvforunity";
#endif



        // C++:  bool decode(vector_Mat patternImages, Mat& disparityMap, vector_Mat blackImages = vector_Mat(), vector_Mat whiteImages = vector_Mat(), int flags = DECODE_3D_UNDERWORLD)
        [DllImport (LIBNAME)]
        private static extern bool structured_1light_StructuredLightPattern_decode_10 (IntPtr nativeObj, IntPtr patternImages_mat_nativeObj, IntPtr disparityMap_nativeObj, IntPtr blackImages_mat_nativeObj, IntPtr whiteImages_mat_nativeObj, int flags);
        [DllImport (LIBNAME)]
        private static extern bool structured_1light_StructuredLightPattern_decode_11 (IntPtr nativeObj, IntPtr patternImages_mat_nativeObj, IntPtr disparityMap_nativeObj);

        // C++:  bool generate(vector_Mat& patternImages)
        [DllImport (LIBNAME)]
        private static extern bool structured_1light_StructuredLightPattern_generate_10 (IntPtr nativeObj, IntPtr patternImages_mat_nativeObj);

        // native support for java finalize()
        [DllImport (LIBNAME)]
        private static extern void structured_1light_StructuredLightPattern_delete (IntPtr nativeObj);

    }
}
