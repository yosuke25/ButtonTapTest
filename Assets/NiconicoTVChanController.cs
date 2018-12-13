using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NiconicoTVChanController : MonoBehaviour {

  public GameObject leftButton;
  public GameObject rightButton;
  OnTouch leftTouch;
  OnTouch rightTouch;

  void Start () {
    leftTouch = leftButton.GetComponent<OnTouch>();
    rightTouch = rightButton.GetComponent<OnTouch>();
  }

  void Update () {
    if (leftTouch.flag && rightTouch.flag) {
      return;
    } else if (leftTouch.flag) {
      Move(-0.1f);
    } else if (rightTouch.flag) {
      Move(0.1f);
    }
  }

  void Move (float distance) {
    Vector3 newPosition = this.gameObject.transform.position;
    newPosition.x += distance;
    this.gameObject.transform.position = newPosition;
  }


}
