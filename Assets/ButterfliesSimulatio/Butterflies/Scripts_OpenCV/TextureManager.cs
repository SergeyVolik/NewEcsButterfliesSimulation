using OpenCVForUnity;


namespace Global
{
    public class TextureManager
    {
        public static readonly int MAX_TEXTURE_RES = 128;

        public static Mat GetDoubleSidedMat(Mat data)
        {
            int width = data.width();
            int height = data.height();

            var frontMat = new Mat(data, new Rect(0, 0, height, height));
            var backMat = new Mat(data, new Rect(height, 0, height, height));

            var img = new Mat(height * 2, width, CvType.CV_8UC3);
            img.setTo(new Scalar(255, 255, 255, 255));

            frontMat.copyTo(new Mat(img, new Rect(0, 0, height, height)));
            backMat.copyTo(new Mat(img, new Rect(height, height, height, height)));

            return img;
        }

        public static void ScaleMat(Mat data)
        {
            Imgproc.resize(data, data, new Size(MAX_TEXTURE_RES, MAX_TEXTURE_RES));
        }
    }
}
