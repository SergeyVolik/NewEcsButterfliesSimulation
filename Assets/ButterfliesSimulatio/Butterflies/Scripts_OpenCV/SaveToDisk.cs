using OpenCVForUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveToDisk : MonoBehaviour
{
    [SerializeField]
    Texture2D texture;
    // Start is called before the first frame update
    void Start()
    {
        var x = Imgcodecs.imread(Application.dataPath + "/to_test_butterfly.png");
        Imgcodecs.imwrite(Application.dataPath + "/to_test_butterfly2.png", x);
        Debug.Log(x.ToString());
        //Mat imgMaskMat = new Mat(texture.height, texture.width, CvType.CV_8UC4);
        //Utils.texture2DToMat(texture, imgMaskMat);
        //ImgProcess.SaveToImg(imgMaskMat, "Test1.png");
        //Debug.Log("Save");
    }


}
