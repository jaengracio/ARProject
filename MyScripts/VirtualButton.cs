using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class VirtualButton : MonoBehaviour, IVirtualButtonEventHandler
{
   public GameObject btn, virtualObject;
   public Animator btnAnimation;
   public string stateName;

   void Start()
   {
      virtualObject.SetActive(false);
      btn.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
      btnAnimation.GetComponent<Animator>();
   }

   public void OnButtonPressed(VirtualButtonBehaviour vbtn)
   {
      virtualObject.SetActive(true);
      btnAnimation.Play(stateName);
   }

   public void OnButtonReleased(VirtualButtonBehaviour vbtn)
   {
      btnAnimation.Play("None");
   }

   void Update() {
      if (Input.touchCount == 2)
      virtualObject.SetActive(false);
   }
}
