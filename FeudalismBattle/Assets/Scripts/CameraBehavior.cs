using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    [SerializeField] private GroundGeneration groundGeneration;

    private Vector2 maxBounds;
    private Vector2 minBounds;
    private 

    private Camera camera;

    // Start is called before the first frame update
    void Start()
    {
        camera = GetComponent<Camera>();

        minBounds = new Vector2(camera.orthographicSize * camera.aspect, camera.orthographicSize);
        maxBounds = groundGeneration.mapSize - new Vector2(camera.orthographicSize * camera.aspect, camera.orthographicSize);

        
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        Vector3 cameraPosition = Camera.main.transform.position;
        cameraPosition.x = Mathf.Clamp(cameraPosition.x, minBounds.x, maxBounds.x);
        cameraPosition.y = Mathf.Clamp(cameraPosition.y, minBounds.y, maxBounds.y);
        Camera.main.transform.position = cameraPosition;

        Debug.Log(cameraPosition);
    }
}
