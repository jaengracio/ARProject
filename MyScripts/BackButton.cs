using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackButton : MonoBehaviour
{
  public GameObject displayView, closeView;
  private Touch touch;

  /***
  * When close button is clicked,
  * the settings panel and close button
  * are not displayed. The settings button
  * is displayed again.
  */
  public void CloseView()
  {    
    if (Input.touchCount > 0)
    {
      displayView.SetActive(true);
      closeView.SetActive(false);
    }

    //--- For desktop testing ---
    displayView.SetActive(true);
    closeView.SetActive(false); 
  }    
}
