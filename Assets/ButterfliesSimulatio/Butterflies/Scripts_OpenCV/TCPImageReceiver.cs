using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Text;
using UnityEngine;
using OpenCVForUnity;

namespace Global
{
    public class TCPImageReceiver : MonoBehaviour
    {
        bool sendData = true;
        IPEndPoint ipEndPoint;
        Socket serverSocket;

        public static int Port = 5665;
        public static TCPImageReceiver Instance;
        private string projectPath;
        void Awake()
        {
            projectPath = Application.dataPath;
            if (Instance == null)
                Instance = this;
            else if (Instance != this)
                Destroy(gameObject);
        }

        void Start()
        {
            IPHostEntry ipHostEntry = Dns.GetHostEntry(string.Empty);
            IPAddress ipAddress = ipHostEntry.AddressList.First(x => x.AddressFamily == AddressFamily.InterNetwork);//IPAddress.Parse("192.168.5.137");
            ipEndPoint = new IPEndPoint(ipAddress, Port);
            new Thread(ServerThread).Start();
        }

        void ServerThread()
        {
            serverSocket = new Socket(ipEndPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            serverSocket.Bind(ipEndPoint);
            serverSocket.Listen(10);
            Debug.Log("Server opened on: " + ipEndPoint.Address.ToString() + ":" + Port);
            while (sendData)
            {
                Socket clientSocket;
                try
                {
                    clientSocket = serverSocket.Accept();
                }
                catch (SocketException)
                {
                    Debug.Log("Server closed");
                    CloseSocket();
                    return;
                }
                IPEndPoint endPoint = clientSocket.RemoteEndPoint as IPEndPoint;
                Debug.Log("Image from: " + endPoint.Address);
                new Thread(() => ReceiveImage(clientSocket)).Start();
            }
        }

        void ReceiveImage(Socket clientSocket)
        {
            
            byte[] buffer = new byte[4];

            clientSocket.Receive(buffer);
            int imageSize = BitConverter.ToInt32(buffer, 0);

            clientSocket.Receive(buffer);
            bool imageDoubleSided = BitConverter.ToInt32(buffer, 0) == 2;

            clientSocket.Receive(buffer);
            int imageWidth = BitConverter.ToInt32(buffer, 0);

            clientSocket.Receive(buffer);
            int imageHeight = BitConverter.ToInt32(buffer, 0);

            clientSocket.Receive(buffer);
            int imageID = BitConverter.ToInt32(buffer, 0);

            clientSocket.Receive(buffer);
            int nameSize = BitConverter.ToInt32(buffer, 0);

            byte[] nameBuff = new byte[nameSize];
            int currentSize = 0;
            while (currentSize < nameSize)
            {
                int recCount = clientSocket.Receive(nameBuff, currentSize, nameSize - currentSize, SocketFlags.None);
                currentSize += recCount;
            }
            string authorName = Encoding.UTF8.GetString(nameBuff);

            Debug.Log("id: " + imageID + " | doubleSided: " + imageDoubleSided + " | size: " + imageSize + " | w: " + imageWidth + " | h:" + imageHeight + " | name: " + authorName);

            byte[] imageBuff = new byte[imageSize];
            currentSize = 0;
            while (currentSize < imageSize)
            {
                int recCount = clientSocket.Receive(imageBuff, currentSize, imageSize - currentSize, SocketFlags.None);
                currentSize += recCount;
            }
            Debug.Log("Image received: " + currentSize + " bytes");

            var imageData = new Mat(imageHeight, imageWidth, CvType.CV_8UC3);
            imageData.put(0, 0, imageBuff);
            //imageData.convertTo(imageData, CvType.CV_8UC4);
            // --- MODIFY IF DOUBLE SIDED ---

            if (imageDoubleSided)
            {
                imageData = TextureManager.GetDoubleSidedMat(imageData);
            }

            Imgcodecs.imwrite(projectPath + "/to_test_butterfly2.png", imageData);
            // --- SCALE TO MAX TEXTURE RESOLUTION ---

            //TextureManager.ScaleMat(imageData);

            // --- ADD TO QUEUE ---

            QRSpawner.Instance.AddImageToQueue(new ImageData(imageData, imageID, imageWidth, imageHeight, authorName));
        }

        void CloseSocket()
        {
            sendData = false;
            serverSocket.Close();
        }

        public string IP { get { return ipEndPoint.Address.ToString(); } }

        private void OnDestroy()
        {
            CloseSocket();
        }
    }
}
