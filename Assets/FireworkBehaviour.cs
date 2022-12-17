using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireworkBehaviour : MonoBehaviour
{

    public Sprite[] sprites;
    public float minimumAnimationHeight;
    public float spriteChangeHeight;
    private SpriteRenderer spriteRenderer;

    private float originalHeight;
    private int currentSprite;
    private float maxHeight;

    // Throws fireworks in the air
    // Sets color, velocity, and location randomly
    void Start()
    {
        Rigidbody2D body = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalHeight = transform.position.y;
        body.velocity = new Vector3(Random.Range(-1, 1), 13, 0);
        float hue = Random.value < .25 ? Random.Range(0.9f, 1f) : Random.Range(0, 0.6f);
        spriteRenderer.color = Color.HSVToRGB(hue, 1f, 1f);
    }

    // Update is called once per frame
    // Executes firework animation and destroys them once they start to fall
    void Update()
    {
        float heightTravelled = transform.position.y - originalHeight;
        if (maxHeight < heightTravelled)
        {
            maxHeight = heightTravelled;
        }
        if (heightTravelled < maxHeight)
        {
;           gameObject.SetActive(false);
            Destroy(gameObject);
        }
        if (currentSprite < sprites.Length && heightTravelled > minimumAnimationHeight && heightTravelled > (spriteChangeHeight * currentSprite))
        {
            spriteRenderer.sprite = sprites[++currentSprite];
        }
    }
}
