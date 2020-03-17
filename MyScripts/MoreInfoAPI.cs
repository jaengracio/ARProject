using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using TMPro;
using Newtonsoft.Json;

public class MoreInfoAPI : MonoBehaviour {

  private TextMeshProUGUI description;

  public GameObject displayMore;
  public GameObject hideInfo;
  public string w_id;
  public string w_obj;

  void Start()
  {
    displayMore.SetActive(false);
  }

  public void LoadMoreInfo() {
    displayMore.SetActive(true);
    
  }
  
  void Update() {
    hideInfo.SetActive(false);
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

          description = GameObject.Find(w_obj).GetComponent<TextMeshProUGUI>();
          description.text = "<b>" + w.name + ":</b> \n" + w.desc;
        }
      }
  }
}
