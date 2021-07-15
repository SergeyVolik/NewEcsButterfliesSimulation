using OpenCVForUnity;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public static class ImgProcess
{
    public static void SaveToImg(Mat mat, string filePath)
    {
        Imgcodecs.imwrite(filePath, mat);
    }

    public static void SaveTexToImg(Texture2D texture, string filePath)
    {
        byte[] bytes = texture.EncodeToJPG();
        File.WriteAllBytes(filePath, bytes);

        Debug.Log("Image saved to " + filePath);
    }

    public static Mat Erode(Mat img, int erosionSize)
    {
        Mat result = new Mat();
        int erosionType = Imgproc.MORPH_RECT;

        Mat erosionElement = Imgproc.getStructuringElement(erosionType,
            new Size(2 * erosionSize + 1, 2 * erosionSize + 1),
            new Point(erosionSize, erosionSize));
        Imgproc.erode(img, result, erosionElement);

        return result;
    }

    public static Mat Dilate(Mat img, int dilateSize)
    {
        Mat result = new Mat();
        int dilateType = Imgproc.MORPH_RECT;

        Mat elementDilate = Imgproc.getStructuringElement(dilateType,
            new Size(2 * dilateSize + 1, 2 * dilateSize + 1),
            new Point(dilateSize, dilateSize));
        Imgproc.dilate(img, result, elementDilate);
        return result;
    }

    public static Mat GaussBlur(Mat img, int blurSize)
    {
        Mat result = new Mat();

        Imgproc.GaussianBlur(img, result, new Size(2 * blurSize + 1, 2 * blurSize + 1), 10);

        return result;
    }

    public static Mat Blur(Mat img, int blurSize)
    {
        Mat result = new Mat();

        Imgproc.blur(img, result, new Size(2 * blurSize + 1, 2 * blurSize + 1));

        return result;
    }

    public static Mat MedianBlur(Mat img, int blurSize)
    {
        Mat result = new Mat();

        Imgproc.medianBlur(img, result, blurSize);

        return result;
    }

    public static Mat MorphologyExOpen(Mat img, int size)
    {
        Mat result = new Mat();

        Mat kernel = Imgproc.getStructuringElement(Imgproc.MORPH_ELLIPSE, new Size(2 * size + 1, 2 * size + 1));

        Imgproc.morphologyEx(img, result, Imgproc.MORPH_OPEN, kernel);

        return result;
    }

    public static Mat MorphologyExClose(Mat img, int size)
    {
        Mat result = new Mat();

        Mat kernel = Imgproc.getStructuringElement(Imgproc.MORPH_ELLIPSE, new Size(2 * size + 1, 2 * size + 1));

        Imgproc.morphologyEx(img, result, Imgproc.MORPH_CLOSE, kernel);

        return result;
    }
}
