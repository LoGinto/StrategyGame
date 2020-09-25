using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float panSpeed = 20f;
    public float panBorderThickness = 10f;
    public Vector2 panLimit;
    public float scrollSpeed = 20f;
    public float minY = 20f;
    public float maxY = 120f;
    // Update is called once per frame
    void Update()
    {
        Vector3 currentPos = transform.position;
        if (Input.GetKey(KeyCode.W)||Input.mousePosition.y >= Screen.height - panBorderThickness)
        {
            currentPos.z += panSpeed * Time.deltaTime;  
        }
        if (Input.GetKey(KeyCode.S) || Input.mousePosition.y <=  panBorderThickness)
        {
            currentPos.z -= panSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D) || Input.mousePosition.x >= Screen.width - panBorderThickness)
        {
            currentPos.x += panSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A) || Input.mousePosition.x <=  panBorderThickness)
        {
            currentPos.x -= panSpeed * Time.deltaTime;
        }
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        currentPos.y -= scroll * scrollSpeed* 100f  * Time.deltaTime;
        currentPos.x = Mathf.Clamp(currentPos.x,-panLimit.x,panLimit.x);
        currentPos.y = Mathf.Clamp(currentPos.y, minY, maxY);
        currentPos.z = Mathf.Clamp(currentPos.z, -panLimit.y, panLimit.y);
        transform.position = currentPos;
    }
}
