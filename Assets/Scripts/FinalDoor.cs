using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D), typeof(SpriteRenderer))]
public class FinalDoor : MonoBehaviour
{
    BoxCollider2D boxcollider;
    SpriteRenderer spriteRenderer;

    [SerializeField] GameObject timeline;
    [SerializeField] Sprite openDoor;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxcollider = GetComponent<BoxCollider2D>();
    }

    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") &&
            collision.gameObject.GetComponent<PlayerController>().CurrentKeys > 0)
        {
            OpenDoor(collision.gameObject);
        }
    }
    void OpenDoor(GameObject player)
    {
        var playerController = player.GetComponent<PlayerController>();

        playerController.CurrentKeys--;
        playerController.CanControl =false;
        boxcollider.isTrigger = true;
        spriteRenderer.sprite = openDoor;
        timeline.SetActive(true);


    }
}

