using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShowIp : MonoBehaviour
{
    TMP_Text textIp;
    // Start is called before the first frame update
    void Awake()
    {
        IPHostEntry ipHostEntry = Dns.GetHostEntry(string.Empty);
        IPAddress ipAddress = ipHostEntry.AddressList.First(x => x.AddressFamily == AddressFamily.InterNetwork);
        textIp = GetComponent<TMP_Text>();
        textIp.text = $"IP Address: {ipAddress.ToString()}. To hide use F1";
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.f1Key.wasPressedThisFrame)
        {
            textIp.enabled = !textIp.enabled;
            Debug.Log("f1Key");
        }
    }
}
