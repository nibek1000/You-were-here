using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class textConnector : MonoBehaviour
{
    public string downloaded;

    public GameObject invalidCharacter;

    public GameObject messageObject;

    List<float> cordsx = new List<float>();
    List<float> cordsy = new List<float>();
    List<float> cordsz = new List<float>();
    List<string> message = new List<string>();

    void Start()
    {
        StartCoroutine(GetData());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)){
            GameObject[] oldMessages;
            oldMessages = GameObject.FindGameObjectsWithTag("named");
            foreach (GameObject ob in oldMessages)
            {
                Debug.Log("destroyed!");
                Destroy(ob);
            }
            downloaded = "";
            cordsx.Clear();
            cordsy.Clear();
            cordsz.Clear();
            message.Clear();
            StartCoroutine(GetData());
        }
    }

    IEnumerator GetData()
    {
        WWW www = new WWW("https://yellowsink.pl/ywhProject/recive.php"); //GET data is sent via the URL

        while (!www.isDone && string.IsNullOrEmpty(www.error))
        {
            yield return null;
        }

        if (string.IsNullOrEmpty(www.error)) downloaded = www.text;
        else Debug.LogWarning(www.error);

        SplitOutput();
    }


    public void CreateText(string text, float x, float y, float z)
    {
        string[] notAllowed = { "<", ">", "!", "@", "#", "$", "%", "^", "&", "*", "(", ")", "-", "_", "=", "+", "{", "}", "[", "]", ";", ":", "'", ",", ".", "/", "|" };

        for (int i = 0; i < notAllowed.Length; i++)
        {
            if (text.Contains(notAllowed[i]))
            {
                invalidCharacter.SetActive(true);
                invalidCharacter.GetComponent<destroyAfterSec>().Start();
                return;
            }
        }

        StartCoroutine(SendData(text, x, y, z));
    }

    IEnumerator SendData(string text, float x, float y, float z)
    {
        string xs = x.ToString().Replace(',', '.');
        string ys = y.ToString().Replace(',', '.');
        string zs = z.ToString().Replace(',', '.');

        WWW www = new WWW("https://yellowsink.pl/ywhProject/send.php/" + text.Replace(' ', '~') + "/" + zs + "/" + ys + "/" + xs);
        Debug.Log(xs + " | " + ys + " | " + zs);
        while (!www.isDone && string.IsNullOrEmpty(www.error))
        {
            yield return null;
        }

        if (string.IsNullOrEmpty(www.error)) downloaded = www.text;
        else Debug.LogWarning(www.error);
        StartCoroutine(GetData());
        
    }

    public void SplitOutput()
    {
        string[] messages;
        messages = downloaded.Split('%');
        for (int i = 0; i < messages.Length-1; i++)
        {
            string[] otp;
            otp = messages[i].Split('#');

            cordsx.Add(float.Parse(otp[0].Replace('.', ',')));
            
            cordsy.Add(float.Parse(otp[1].Replace('.', ',')));
            
            cordsz.Add(float.Parse(otp[2].Replace('.', ',')));
            
            message.Add(otp[3].Replace('~', ' '));

        }
        
        OutputToMap();
    }

    public void OutputToMap()
    {
        
        
        for (int i = 0; i < message.Count; i++)
        {
            Instantiate(messageObject, new Vector3(cordsx[i], cordsy[i], cordsz[i]), Quaternion.identity);
            GameObject temp = GameObject.FindGameObjectWithTag("unnamed");
            temp.transform.GetChild(0).transform.GetComponent<TextMeshPro>().SetText(message[i]);
            temp.transform.tag = "named";
        }

    }
}
