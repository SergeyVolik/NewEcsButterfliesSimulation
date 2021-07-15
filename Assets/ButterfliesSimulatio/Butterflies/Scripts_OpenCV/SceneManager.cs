using UnityEngine;
using TMPro;

namespace Global
{
    public class SceneManager : MonoBehaviour
    {
        public TextMeshProUGUI textIP;
        public GameObject leftBlackScreen;
        public GameObject rightBlackScreen;

        public GameObject teleportPrefab;
        public GameObject balloonPrefab;
        public GameObject lightningPrefab;
        public GameObject smokePrefab;
        public GameObject namePrefab;

        public IGameManager GM { get; set; }

        const int FIRST_SCENE_INDEX = 1;

        int sceneIndex = FIRST_SCENE_INDEX;

        public static int CREATURE_LAYER = 1 << 8;

        public static SceneManager Instance;

        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
            Debug.Log(Instance);
            DontDestroyOnLoad(gameObject);

            // --- ACTIVATE SECOND DISPLAY ---

            if (Display.displays.Length > 1)
            {
                Display.displays[1].Activate();
            }

            // --- HARDCODED RESOLUTIONS ---

            if (Display.displays.Length >= 2)
            {
                Display.displays[0].SetRenderingResolution(3072, 768);
                Display.displays[1].SetRenderingResolution(1280, 800);
            }

            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneIndex++);
        }

        void Update()
        {
            SwitchScenes();

            TimeScale();

            UI();

            // --- REMOVE CREATURE BY CLICK ---

            if (Input.GetMouseButtonDown(0) && Input.GetKey(KeyCode.LeftControl))
            {
                RaycastDestroy(Input.mousePosition);
            }
        }

        void SwitchScenes()
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                if (sceneIndex == UnityEngine.SceneManagement.SceneManager.sceneCountInBuildSettings)
                {
                    sceneIndex = FIRST_SCENE_INDEX;
                }
                UnityEngine.SceneManagement.SceneManager.LoadScene(sceneIndex++);
            }
        }

        void TimeScale()
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                Time.timeScale++;
            }

            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (Time.timeScale - 1 >= 0) Time.timeScale--;
            }
        }

        void UI()
        {
            if (Input.GetKeyDown(KeyCode.F1))
            {
                var showIP = !textIP.gameObject.activeSelf;
                textIP.gameObject.SetActive(showIP);
                if (showIP)
                {
                    textIP.text = TCPImageReceiver.Instance.IP.ToString();
                }
            }

            if (Input.GetKeyDown(KeyCode.F2))
            {
                leftBlackScreen.gameObject.SetActive(!leftBlackScreen.activeSelf);
                rightBlackScreen.gameObject.SetActive(!rightBlackScreen.activeSelf);
            }
        }

        void RaycastDestroy(Vector2 pos)
        {
            Ray ray = Camera.main.ScreenPointToRay(pos);
            if (Physics.Raycast(ray, out RaycastHit hit, float.MaxValue, CREATURE_LAYER))
            {
                Debug.Log("Hit destroy");
                Transform trans = hit.collider.transform;
                Transform parent = trans;
                while (trans != null)
                {
                    parent = trans;
                    trans = trans.transform.parent;
                }

                GM.GetSpawnedCreatures().Remove(parent.gameObject);

                Destroy(parent.gameObject);
            }
        }
    }
}
