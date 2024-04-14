using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    public float parallaxMultiplier = 1.5f;

    private Transform cameraTransform;
    private Vector3 lastCameraPosition;
    private float textureUnitSizeX;

    void Start()
    {
        cameraTransform = Camera.main.transform;
        lastCameraPosition = cameraTransform.position;
        Sprite sprite = GetComponent<SpriteRenderer>().sprite;
        Texture2D texture = sprite.texture;
        textureUnitSizeX = texture.width / sprite.pixelsPerUnit;
    }

    void Update()
    {
        Vector3 deltaMovement = cameraTransform.position - lastCameraPosition;
        transform.position -= new Vector3(deltaMovement.x * parallaxMultiplier, 0, 0);
        lastCameraPosition = cameraTransform.position;
    }
}
