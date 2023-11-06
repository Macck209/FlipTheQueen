using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    [SerializeField] float parallaxMultiplier = .5f;

    private Transform camTransform;
    Vector3 lastCamPos;

    void Start()
    {
        camTransform = Camera.main.transform;
        lastCamPos = camTransform.position;
    }


    void LateUpdate()
    {
        float deltaMovement = camTransform.position.x - lastCamPos.x;
        transform.position += new Vector3(deltaMovement * parallaxMultiplier, 0);
        lastCamPos = camTransform.position;
    }
}
