using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
  
      void Update() {
        Vector3 PlayerPos = GameObject.Find("boat").transform.position;

        PlayerPos.y += 3.5f;
        PlayerPos.z = -10;

        gameObject.transform.SetPositionAndRotation(PlayerPos, new Quaternion(0, 0, 0, 0));
    }

  }
