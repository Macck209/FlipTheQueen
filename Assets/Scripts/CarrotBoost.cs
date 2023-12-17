using System.Collections;
using UnityEngine;

public class CarrotBoost : MonoBehaviour
{
    [SerializeField] float boostModifier = 1.25f;

    PlayerController playerController;
    [SerializeField] AudioClip consumeSound;

    private void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(ChangeSpeed(playerController.walkSpeed));
            gameObject.GetComponent<CircleCollider2D>().enabled = false;
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            playerController.PlaySound(consumeSound);
        }
    }

    IEnumerator ChangeSpeed(float originalSpeed)
    {
        float newSpeed = originalSpeed * boostModifier;
        playerController.walkSpeed = newSpeed;

        yield return new WaitForSeconds(5f);

        playerController.walkSpeed /= boostModifier;
        Destroy(gameObject);
    }
}
