using System.Collections;
using UnityEngine;

// Enables the user to swipe the instructions panels.
public class TutorialSwipe : MonoBehaviour {
  
  private Vector2 panelLocation;
  private RectTransform swipeRectTransform;
  private float startPos;
  private float diff;
  public float percentThreshold = 0.2f;
  public float easing = 0.5f;
  public bool arTutorial = false;

  void Start() {
    swipeRectTransform = GameObject.Find("SwipePanel").GetComponent<RectTransform>();
    panelLocation = swipeRectTransform.anchoredPosition;
  }

  void Update()
  {
    if (Input.touchCount > 0)
    {
      Touch touch = Input.GetTouch(0);

      switch (touch.phase)
      {
        // Record starting touch position
        case TouchPhase.Began:
          startPos = touch.position.x;
        break;

        // Store the distance between the first touch and the current finger position
        case TouchPhase.Moved:
          diff = startPos - touch.position.x;

          // moves the panel to wherever the mouse is on screen
          swipeRectTransform.anchoredPosition = panelLocation - new Vector2(diff, 0);
        break;

        case TouchPhase.Ended:
          float percentage = diff/Screen.width;

          if (Mathf.Abs(percentage) >= percentThreshold) {

            Vector2 newLocation = panelLocation;

            // Swipe left
            if (percentage > 0) {
              newLocation += new Vector2(-Screen.width/2, 0);

              /*  PanelLocation is based on pivot position. */
              if (arTutorial == false && newLocation.x < -1800) {
                newLocation = new Vector2(-Screen.width/2 * 3, panelLocation.y);
              }   
              else if ( arTutorial == true && newLocation.x < - 1200) {
                newLocation = new Vector2(-Screen.width/2 * 2, panelLocation.y);
              }  
            }
            // Swipe right
            else if (percentage < 0) {
              newLocation += new Vector2(Screen.width/2, 0);

              if (newLocation.x > 0) {
                newLocation = new Vector2(Screen.width * 0, panelLocation.y);
              }
            }
            
            StartCoroutine(SmoothTransition(swipeRectTransform.anchoredPosition, newLocation, easing));
            panelLocation = newLocation;

          } else {
            StartCoroutine(SmoothTransition(swipeRectTransform.anchoredPosition, panelLocation, easing));
          }
        break;
      }
    }

    IEnumerator SmoothTransition(Vector3 start, Vector3 end, float secs){
      float t = 0f;

      while (t <= 1) {
        t += Time.deltaTime / secs;
        swipeRectTransform.anchoredPosition = Vector3.Lerp(start, end, Mathf.SmoothStep(0f, 1f, t));
        yield return null;
      }
    }
  }

}
