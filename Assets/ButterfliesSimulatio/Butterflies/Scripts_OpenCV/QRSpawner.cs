using System.Collections.Generic;
using UnityEngine;
using OpenCVForUnity;

using System.Threading;

namespace Global
{
    public class ImageData
    {
        public Mat data;
        public int id;
        public int width;
        public int height;
        public string author;

        public ImageData(Mat data, int id, int width, int height, string author)
        {
            this.data = data;
            this.id = id;
            this.width = width;
            this.height = height;
            this.author = author;
        }
    }

    public class QRSpawner : MonoBehaviour
    {
        Queue<string> pathImages = new Queue<string>();
        Queue<ImageData> images = new Queue<ImageData>();



        const int QR_COUNT = 4;
        const int SCAN_THREAD_DELAY = 1000;

        public static QRSpawner Instance;
        CreateWings wings;
        private void Awake()
        {
            wings = FindObjectOfType<CreateWings>();
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        void Start()
        {
            var path = System.IO.Path.Combine(Application.dataPath, "Images");

        }

        void Update()
        {
            if (images.Count != 0)
            {
                lock (images)
                {
                    var folderImage = images.Dequeue();
                    Debug.Log("Message");
                    wings.RefreshVFX(folderImage.data, folderImage.id, folderImage.author);
                    //CreateTextureAndSpawn(folderImage.data, folderImage.id, folderImage.author);
                }
            }
        }

        public void CreateTextureAndSpawn(Mat data, int id, string author)
        {
            // --- CREATE TEXTURE ---

            var tex = new Texture2D(TextureManager.MAX_TEXTURE_RES, TextureManager.MAX_TEXTURE_RES, TextureFormat.RGB24, false);
            Utils.matToTexture2D(data, tex);

            // --- SPAWN CREATURE ---

            //SceneManager.Instance.GM.SpawnCreature(tex, id, author);
        }


        public void AddImageToQueue(ImageData imageData)
        {
            lock (images)
            {
                images.Enqueue(imageData);
            }
        }

     



      
    }
}
