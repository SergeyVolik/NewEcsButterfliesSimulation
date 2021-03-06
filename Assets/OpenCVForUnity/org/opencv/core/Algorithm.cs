

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace OpenCVForUnity
{
    // C++: class Algorithm
    //javadoc: Algorithm
    public class Algorithm : DisposableOpenCVObject
    {

        protected override void Dispose (bool disposing)
        {
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
            try {
                if (disposing) {
                }
                if (IsEnabledDispose) {
                    if (nativeObj != IntPtr.Zero)
                        core_Algorithm_delete (nativeObj);
                    nativeObj = IntPtr.Zero;
                }
            } finally {
                base.Dispose (disposing);
            }
#else
            return;
#endif
        }

        protected internal Algorithm (IntPtr addr)
            : base (addr)
        {
        }


        public IntPtr getNativeObjAddr ()
        {
            return nativeObj;
        }

        //
        // C++:  String getDefaultName()
        //

        //javadoc: Algorithm::getDefaultName()
        public string getDefaultName ()
        {
            ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        
            string retVal = Marshal.PtrToStringAnsi (core_Algorithm_getDefaultName_10 (nativeObj));
        
#else
            return null;
#endif
            return retVal;
        }


        //
        // C++:  void clear()
        //

        //javadoc: Algorithm::clear()
        public virtual void clear ()
        {
            ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        
            core_Algorithm_clear_10 (nativeObj);
        
#else
            return;
#endif
            return;
        }


        //
        // C++:  void save(String filename)
        //

        //javadoc: Algorithm::save(filename)
        public virtual void save (string filename)
        {
            ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR) || UNITY_5 || UNITY_5_3_OR_NEWER
        
            core_Algorithm_save_10 (nativeObj, filename);
        
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



        // C++:  String getDefaultName()
        [DllImport (LIBNAME)]
        private static extern IntPtr core_Algorithm_getDefaultName_10 (IntPtr nativeObj);

        // C++:  void clear()
        [DllImport (LIBNAME)]
        private static extern void core_Algorithm_clear_10 (IntPtr nativeObj);

        // C++:  void save(String filename)
        [DllImport (LIBNAME)]
        private static extern void core_Algorithm_save_10 (IntPtr nativeObj, string filename);

        // native support for java finalize()
        [DllImport (LIBNAME)]
        private static extern void core_Algorithm_delete (IntPtr nativeObj);

    }
}
