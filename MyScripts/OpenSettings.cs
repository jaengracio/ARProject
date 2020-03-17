using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenSettings : MonoBehaviour
{    
  public GameObject settingsPanel, settingsBtn;

  /**
  * When app starts, the close button and
  * settings panel are not displayed
  */
  void Start()
  {
    settingsPanel.SetActive(false);
    settingsPanel.SetActive(false);
    // tutorial.SetActive(false);
  }

  /***
  * When settings button is clicked,
  * the settings panel and close button
  * are displayed, but the settings button
  * is not.
  */
  public void LoadPanel()
  {    
    if (Input.touchCount > 0)
    {
      settingsPanel.SetActive(true);
      settingsBtn.SetActive(false);
    }

    //--- For desktop testing ---
    settingsPanel.SetActive(true);
    settingsBtn.SetActive(false);
  }    
}
