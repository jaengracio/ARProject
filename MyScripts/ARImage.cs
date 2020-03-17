using System.Collections;
using UnityEngine;

public class ARImage : MonoBehaviour
{
  public GameObject displayObject;

  void Start()
  {
    displayObject.SetActive(false);
  }

  void Update()
  {
    displayObject.SetActive(true);
  }
}
