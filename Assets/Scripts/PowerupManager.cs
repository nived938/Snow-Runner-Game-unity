using UnityEngine;

public class PowerupManager : MonoBehaviour
{
    [SerializeField] PowerupSO powerups;

    PlayerController player;

    SpriteRenderer spriteRenderer;
    float timeLeft;

    void Start()
    {
        player = FindAnyObjectByType<PlayerController>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        timeLeft = powerups.GetTime();
    }

    void Update()
    {
        CountdownTimer();
    }

    void CountdownTimer()
    {
        if (spriteRenderer)
        {
            if (timeLeft > 0)
            {
                timeLeft -= Time.deltaTime;

                if (timeLeft <= 0)
                {
                    player.DeactivatePowerup(powerups);
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        int layerIndex = LayerMask.NameToLayer("Player");

        if (collision.gameObject.layer == layerIndex && spriteRenderer.enabled == true)
        {
            spriteRenderer.enabled = false;
            player.ActivatePowerup(powerups);
        }
    }
}
