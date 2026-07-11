using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class PlayerVision : MonoBehaviour
{
    public float oldWomanZoom = 3.5f;
    public float birdZoom = 5.5f;

    public float zoomSpeed = 3;

    private Camera cam;

    bool birdForm;

    public Volume volume;

    private Vignette vignette;

    void Start()
    {
        cam = Camera.main;
        volume.profile.TryGet(out vignette);
    }

    public void SetBirdForm(bool bird)
    {
        birdForm = bird;
    }

    void Update()
    {
        float targetZoom = birdForm ?
            birdZoom :
            oldWomanZoom;

        cam.orthographicSize = Mathf.Lerp(
            cam.orthographicSize,
            targetZoom,
            Time.deltaTime * zoomSpeed
        );

        float targetIntensity = birdForm ? 0f : 0.8f;

        vignette.intensity.value =
            Mathf.Lerp(
                vignette.intensity.value,
                targetIntensity,
                Time.deltaTime * 4
            );
    }
}