using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

// Loads next scene when screen is tapped.
public class LoadNewScene : MonoBehaviour
{

  private Touch touch;

  public void LoadSceneView(int lvl)
  {
    if (Input.touchCount > 0)
      SceneManager.LoadScene(lvl);
  }

}
