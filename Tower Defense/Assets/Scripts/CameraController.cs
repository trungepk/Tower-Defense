using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    [SerializeField] float panSpeed = 30f;
    [SerializeField] float panBorderThickness = 10f;
    [SerializeField] float scrollSpeed = 10f;
    [SerializeField] Vector2 scrollLimit;
    [SerializeField] Vector2 panLimit;

	void Update ()
    {
        if (GameManager.gameOver)
        {
            enabled = false;
            return;
        }
        Vector3 pos = transform.position;
        pos = Pan(pos);
        pos = Scroll(pos);
        pos = Limit(pos);
        transform.position = pos;
    }

    private Vector3 Pan(Vector3 pos)
    {
        if (Input.GetKey(KeyCode.W) || Input.mousePosition.y >= Screen.height - panBorderThickness)
        {
            pos.z += panSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S) || Input.mousePosition.y <= panBorderThickness)
        {
            pos.z -= panSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A) || Input.mousePosition.x <= panBorderThickness)
        {
            pos.x -= panSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D) || Input.mousePosition.x >= Screen.width - panBorderThickness)
        {
            pos.x += panSpeed * Time.deltaTime;
        }

        return pos;
    }

    private Vector3 Scroll(Vector3 pos)
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        pos.y -= scroll * scrollSpeed * Time.deltaTime * 1000;
        return pos;
    }

    private Vector3 Limit(Vector3 pos)
    {
        pos.x = Mathf.Clamp(pos.x, -panLimit.x, panLimit.x);
        pos.z = Mathf.Clamp(pos.z, -panLimit.y, panLimit.y);
        pos.y = Mathf.Clamp(pos.y, scrollLimit.x, scrollLimit.y);
        return pos;
    }
}
