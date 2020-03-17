using System.Collections;
using UnityEngine;

public class SettingsBtn : MonoBehaviour
{
  /**
  * Display the view when one of the buttons
  * in the settings menu is tapped.
  */
  public GameObject view, settingsPanel;

  void Start()
  {
    view.SetActive(false);
  }

  public void LoadView()
  {    
    if (Input.touchCount > 0)
    {
      view.SetActive(true);
      settingsPanel.SetActive(false);
    }

    //--- For desktop testing ---
    view.SetActive(true);
    settingsPanel.SetActive(false);
  } 
}
