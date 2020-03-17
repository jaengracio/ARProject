using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CloseSettings : MonoBehaviour
{
  public GameObject settingsPanel, settingsBtn;
  private Touch touch;

  /***
  * When close button is clicked,
  * the settings panel and close button
  * are not displayed. The settings button
  * is displayed again.
  */
  public void ClosePanel()
  {    
    if (Input.touchCount > 0)
    {
      settingsPanel.SetActive(false);
      settingsBtn.SetActive(true);
    }

    //--- For desktop testing ---
    settingsPanel.SetActive(false);
    settingsBtn.SetActive(true);    
  }    
}
