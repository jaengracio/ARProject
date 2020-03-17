using System.Collections;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
  /**
  * Display tutorial in main menu
  * when screen is tapped.
  */
  public GameObject displayObject;

  void Start()
  {
    displayObject.SetActive(false);
  }

  void Update()
  {
    if (Input.GetMouseButtonDown(0) || Input.touchCount > 0)
    {
      Debug.Log("Pressed right button.");
      displayObject.SetActive(true);
    } 
  }
}
