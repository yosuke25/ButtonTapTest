using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class OnTouch : MonoBehaviour {

  Dictionary<int, bool> downFinger = new Dictionary<int, bool>();

  public bool flag = false;

  void Update () {
    if (Input.touchCount <= 0) {
      flag = false;
      downFinger = new Dictionary<int, bool>();
      return;
    }

    for (int i = 0; i < Input.touchCount; i++) {
      Touch touch = Input.GetTouch(i);
      if (!IsDownFinger(touch.fingerId) && (touch.phase == TouchPhase.Began) && RayHit(touch.position)) {
        flag = true;
        downFinger[touch.fingerId] = true;
      } else if (IsDownFinger(touch.fingerId) && (touch.phase == TouchPhase.Ended)) {
        flag = false;
        downFinger[touch.fingerId] = false;
      }
    }
  }

  bool IsDownFinger (int fingerId) {
    return (downFinger.ContainsKey(fingerId) && downFinger[fingerId]);
  }

  bool RayHit (Vector2 touchPosition) {
    Ray2D ray = new Ray2D(Camera.main.ScreenToWorldPoint(touchPosition), Camera.main.transform.forward);
    RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
    Debug.DrawRay(ray.origin, Camera.main.transform.forward * 1000.0f, Color.red);
    return ((hit.collider != null) && (hit.collider.gameObject == this.gameObject));
  }

}
