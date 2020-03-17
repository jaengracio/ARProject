using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OnMouseSwipe : MonoBehaviour, IDragHandler, IEndDragHandler {

  private RectTransform swipeRectTransform;
  private Vector2 panelLocation;
  private float diff;
  public float percentThreshold = 0.2f;  
  //stores time it takes for instructions panel to ease in
  public float easing = 0.5f;
  public bool arTutorial = false;

  void Start() {
    // stores the current position of the SwipePanel gameobject
    swipeRectTransform = GameObject.Find("SwipePanel").GetComponent<RectTransform>();
    panelLocation = swipeRectTransform.anchoredPosition;
  }

  public void OnDrag(PointerEventData data) {
    // stores the distance from first mouse press to current mouse position on screen
    diff = data.pressPosition.x - data.position.x;
    // Debug.Log(diff);
    
    // moves the panel to wherever the mouse is on screen
    swipeRectTransform.anchoredPosition = panelLocation - new Vector2(diff, 0);
  }

  public void OnEndDrag(PointerEventData data) {
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
          newLocation = new Vector2(Screen.width/2 * 0, panelLocation.y);
        }
      }

      StartCoroutine(SmoothTransition(swipeRectTransform.anchoredPosition, newLocation, easing));
      panelLocation = newLocation;

    } else {
      StartCoroutine(SmoothTransition(swipeRectTransform.anchoredPosition, panelLocation, easing));
    }
  }

  IEnumerator SmoothTransition(Vector2 start, Vector2 end, float secs) {
    float t = 0f;

    while (t <= 1) {
      t += Time.deltaTime / secs;
      swipeRectTransform.anchoredPosition = Vector2.Lerp(start, end, Mathf.SmoothStep(0f, 1f, t));
      yield return null;
    }
  }
}
