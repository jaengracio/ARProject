using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using Newtonsoft.Json;

public class InfoAPI : MonoBehaviour {

  private Text description;
  public string w_id;
  public string w_obj;

  void Start()
  {
    // StartCoroutine(GetRequest("http://localhost:4000/women/5e2862721c9d440000332d09"));
    StartCoroutine(GetRequest("https://ar-stem-backend.herokuapp.com/women/" + w_id));
  }

  IEnumerator GetRequest(string uri)
  {
    UnityWebRequest www = UnityWebRequest.Get(uri);
    //starts communicating with the remote server
      yield return www.SendWebRequest();

      if (www.isNetworkError)
      {
        Debug.Log(www.error);
      }
      else
      {
        if (www.isDone)
        {
          Woman w = JsonConvert.DeserializeObject<Woman>(www.downloadHandler.text);
          Debug.Log(www.downloadHandler.text);

          description = GameObject.Find(w_obj).GetComponent<Text>();
          description.text = "Category: " + w.categories + "\nName:  " + w.name + "\nDate of Birth:  " + w.dob + "\nDied:  " + w.died;
        }
      }
  }
}
