using UnityEngine;

public class PlayerVision : MonoBehaviour
{
    public bool birdForm = false;

    public float oldWomanZoom = 3.5f;
    public float birdZoom = 5.5f;

    public float zoomSpeed = 3f;

    private Camera cam;

    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        // Apenas para teste
        if (Input.GetKeyDown(KeyCode.Space))
        {
            birdForm = !birdForm;
        }

        float targetZoom = birdForm ? birdZoom : oldWomanZoom;

        cam.orthographicSize = Mathf.Lerp(
            cam.orthographicSize,
            targetZoom,
            Time.deltaTime * zoomSpeed
        );
    }
}