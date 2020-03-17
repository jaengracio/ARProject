using System.Collections;
using UnityEngine;

public class ARSwipe : MonoBehaviour {
  
  private Vector2 panelLocation;
  private RectTransform swipeRectTransform;
  private float startPos;
  private float diff;
  public float percentThreshold = 0.2f;
  public float easing = 0.5f;
  public string panelName;

  void Start() {
    swipeRectTransform = GameObject.Find(panelName).GetComponent<RectTransform>();
    panelLocation = swipeRectTransform.anchoredPosition;
  }

  void Update() {
    if (Input.touchCount > 0) {
      Touch touch = Input.GetTouch(0);

      switch (touch.phase) {
        case TouchPhase.Began:
          startPos = touch.position.y;
        break;

        case TouchPhase.Moved:
          diff = startPos - touch.position.y;
          swipeRectTransform.anchoredPosition = panelLocation - new Vector2(0, diff);
        break;
        
        case TouchPhase.Ended:
          float percentage = diff/Screen.height;

          if (Mathf.Abs(percentage) >= percentThreshold) {

            Vector2 newLocation = panelLocation;

            // swipe up
            if (percentage < 0) {
              newLocation = new Vector2(panelLocation.x, Screen.height/2);
            }

            //swipe down
            else if (percentage > 0) {
              newLocation = new Vector2(panelLocation.x, -Screen.height);
            }

            StartCoroutine(SmoothTransition(swipeRectTransform.anchoredPosition, newLocation, easing));
            panelLocation = newLocation;
          } else {
            StartCoroutine(SmoothTransition(swipeRectTransform.anchoredPosition, panelLocation, easing));
          }
        break;
      }
    }

    IEnumerator SmoothTransition(Vector2 start, Vector2 end, float secs) {
      float t = 0f;

      while (t <= 1) {
        t += Time.deltaTime / secs;
        swipeRectTransform.anchoredPosition = Vector3.Lerp(start, end, Mathf.SmoothStep(0f, 1f, t));
        yield return null;
      }
    }
  }

}
