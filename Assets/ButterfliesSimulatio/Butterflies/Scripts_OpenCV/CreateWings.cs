using Global;
using OpenCVForUnity;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.VFX;
using UnityEngine.VFX.Utility;

public class CreateWings : MonoBehaviour
{
    ExposedProperty m_WingsTextureLeft;
    ExposedProperty m_WingsTextureRight;
    ExposedProperty m_FlipWingsBookX;


    [SerializeField]
    Texture2D[] masks;

    [SerializeField]
    Texture2D test;

    [SerializeField]
    int numberOfWings = 8;

    [SerializeField, Range(1, 100)]
    int defaultButterfiles = 8;
    const int IMAGE_WIDTH = 2048;
    const int IMAGE_HEIGHT = 2048;
    public struct Wings
    {
        public Mat left;
        public Mat right;
    }
    List<Wings> WingsTextures = new List<Wings>();
    const int maxWings = 10;

    [SerializeField]
    GameObject butterfliesVfxPrefab;
    [SerializeField]
    private float rate = 0.5f;
    [SerializeField]
    float offsetSpawnPositionX = 2;

    //[SerializeField]
    //Vector2 targetResolution = 
    // Start is called before the first frame update
    void Start()
    {
        m_WingsTextureLeft = "WingsTextureLeft";
        m_WingsTextureRight = "WingsTextureRight";
        m_FlipWingsBookX = "FlipWingsBookX3";
        //Debug.Log($"{butterflies_vfx.GetInt(m_FlipWingsBookX)}");

        //butterflies_vfx.SetInt(m_FlipWingsBookX, numberOfWings);
        //butterflies_vfx.SetInt(m_FlipWingsBookX, 1);
      
       
        InitWings();
    }


    void InitWings()
    {
        for(var i = 0; i < defaultButterfiles; i++)
        {
            var vfx = Instantiate(butterfliesVfxPrefab).GetComponent<VisualEffect>();
            vfx.playRate = rate;
            vfx.transform.position = new Vector3(Random.Range(-offsetSpawnPositionX, offsetSpawnPositionX), vfx.transform.position.y, vfx.transform.position.z);
        }      
    }
    public void RefreshVFX(Mat imageMat = null, int id = 0, string author = "", bool initWings = false)
    {

        if (!initWings)
        {
            var resized = new Mat(IMAGE_HEIGHT, IMAGE_WIDTH, imageMat.type());
            Imgproc.resize(imageMat, resized, new Size(IMAGE_WIDTH, IMAGE_HEIGHT));

            Debug.Log(resized.ToString());
            var converted = new Mat(resized.height(), resized.width(), CvType.CV_8UC4);

            Imgproc.cvtColor(resized, converted, 0);

            var mask = masks[id - 1];
            Mat imgMaskMat = new Mat(mask.height, mask.width, CvType.CV_8UC1);
            Utils.texture2DToMat(mask, imgMaskMat);
            var resizedMask = new Mat(IMAGE_HEIGHT, IMAGE_WIDTH, imageMat.type());
            Imgproc.resize(imgMaskMat, resizedMask, new Size(IMAGE_WIDTH, IMAGE_HEIGHT));
            Mat Destination = new Mat(IMAGE_HEIGHT, IMAGE_WIDTH, CvType.CV_8UC4);
            converted.copyTo(Destination, resizedMask);

            Mat frontMat = new Mat(Destination, new OpenCVForUnity.Rect(0, 0, Destination.width() / 2, Destination.height()));
            Mat backMat = new Mat(Destination, new OpenCVForUnity.Rect(Destination.width() / 2, 0, Destination.width() / 2, Destination.height()));
            Mat fliped = new Mat(backMat.width(), backMat.height(), CvType.CV_8UC4);
            Core.flip(backMat, fliped, 1);

            Texture2D textureLeft = new Texture2D(frontMat.width(), frontMat.height());
            Texture2D textureRight = new Texture2D(frontMat.width(), frontMat.height());

            textureLeft.Apply();
            textureRight.Apply();

            Utils.matToTexture2D(frontMat, textureLeft);
            Utils.matToTexture2D(fliped, textureRight);

            var vfx = Instantiate(butterfliesVfxPrefab).GetComponent<VisualEffect>();

            vfx.SetInt(m_FlipWingsBookX, 1);
            vfx.SetTexture(m_WingsTextureLeft, textureLeft);
            vfx.SetTexture(m_WingsTextureRight, textureRight);
            var binder = vfx.GetComponent<VFXPropertyBinder>();

            Debug.Log(binder.m_Bindings.Count);
            vfx.playRate = rate;
            vfx.transform.position = new Vector3(Random.Range(-offsetSpawnPositionX, offsetSpawnPositionX), vfx.transform.position.y, vfx.transform.position.z);

            // binder.GetPropertyBinders<VFXPosition>();
            //WingsTextures.Add(new Wings { left = frontMat, right = fliped });

        }
        //else {

        //    //WingsTextures.Add(new Wings { left = imageMat, right = imageMat });


        //}

        //if (WingsTextures.Count > maxWings)
        //{
        //    WingsTextures.RemoveAt(0);
        //}
        //RecreateWingsTexture();

    }

    //void RecreateWingsTexture()
    //{
        
    //    var listTextureWings = WingsTextures;

    //    var wingWidth = listTextureWings[0].left.width();
    //    var wingHeight = listTextureWings[0].left.height();

    //    var wingWidthComposed = wingWidth * WingsTextures.Count;


    //    Texture2D textureLeft = new Texture2D(wingWidthComposed, wingHeight);
    //    Texture2D textureRight = new Texture2D(wingWidthComposed, wingHeight);

    //    Mat matLeftWingsComposed = new Mat(wingHeight, wingWidthComposed, CvType.CV_8UC4);
    //    Mat matRightWingsComposed = new Mat(wingHeight, wingWidthComposed, CvType.CV_8UC4);


    //    for (var i = 0; i < listTextureWings.Count; i++)
    //    {
    //        var wings = listTextureWings[i];

    //        var subWingLeft = matLeftWingsComposed.submat(0, wingHeight, i * wingWidth, i * wingWidth + wingWidth);
    //        var subWingRight = matRightWingsComposed.submat(0, wingHeight, i * wingWidth, i * wingWidth + wingWidth);

            
    //        wings.left.copyTo(subWingLeft);
    //        wings.right.copyTo(subWingRight);

    //        listTextureWings[i] = wings;
    //    }

    //    Utils.matToTexture2D(matLeftWingsComposed, textureLeft);   
    //    Utils.matToTexture2D(matRightWingsComposed, textureRight);

    //    textureLeft.Apply();
    //    textureRight.Apply();

    //    Debug.Log($"{textureLeft.height} x {textureLeft.width}");
    //    butterflies_vfx.SetInt(m_FlipWingsBookX, WingsTextures.Count);
    //    butterflies_vfx.SetTexture(m_WingsTextureLeft, textureLeft);
    //    butterflies_vfx.SetTexture(m_WingsTextureRight, textureRight);
    //}


   
}
