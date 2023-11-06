using UnityEngine;

public class LoopingParallaxBackground : MonoBehaviour
{
    [SerializeField] float parallaxMultiplier = .5f;

    private Transform camTransform;
    private Vector3 lastCamPos;
    private float textureUnitSizeX;

    void Start()
    {
        camTransform = Camera.main.transform;
        lastCamPos = camTransform.position;

        Sprite sprite = GetComponent<SpriteRenderer>().sprite;
        Texture2D texture = sprite.texture;
        textureUnitSizeX = texture.width / sprite.pixelsPerUnit * Camera.main.orthographicSize;
    }


    void LateUpdate()
    {
        float deltaMovement = camTransform.position.x - lastCamPos.x;
        transform.position += new Vector3(deltaMovement * parallaxMultiplier, 0);
        lastCamPos = camTransform.position;

        if (Mathf.Abs(camTransform.position.x - transform.position.x) >= textureUnitSizeX)
        {
            float offSetPosX = (camTransform.position.x - transform.position.x) % textureUnitSizeX;
            transform.position = new Vector3(camTransform.position.x + offSetPosX, transform.position.y);
        }
    }
}
