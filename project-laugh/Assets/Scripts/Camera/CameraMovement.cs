using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [Header("Character Object")]
    public GameObject characterObj; // 카메라가 움직일 캐릭터 포지션
    public BoxCollider2D bound; // 카메라
    private Vector3 minBound;
    private Vector3 maxBound;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(characterObj != null) {
            UpdateCameraPosition();
        }
    }

    public void UpdateCameraPosition() {
        gameObject.transform.position = new Vector3(characterObj.transform.position.x, characterObj.transform.position.y, gameObject.transform.position.z);
        //Vector3 tempPos;
        //tempPos = Vector3.SmoothDamp(transform.position, targetPosition, ref refVel, smoothTime);

        //float clampedX = Mathf.Clamp(tempPos.x, minBound.x + halfWidth, maxBound.x - halfWidth);
        //float clampedY = Mathf.Clamp(tempPos.y, minBound.y + halfHeight, maxBound.y - halfHeight);
        
        //transform.position = new Vector3(clampedX, clampedY, transform.position.z);
    }
}
