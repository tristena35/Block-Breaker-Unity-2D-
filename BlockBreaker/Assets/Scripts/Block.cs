using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{

    // Configuration Parameters
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject blockSparklesVFX;
    [SerializeField] Sprite[] hitSprites;

    // Cached reference
    Level level; 

    // State Variables (Keep track of state of specific object)
    [SerializeField] int timesHit; //Only serialized for debug purposes

    private void Start()
    {
        CountBreakableBlocks();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(tag == "Breakable")
        {
            HandleHit();
        }
    }

    private void HandleHit()
    {
        timesHit ++;
        int maxHits = hitSprites.Length + 1;

        if(timesHit >= maxHits)
        {
            DestroyBlock();
        }   
        else
        {
            ShowNextHitSprite();
        }
    }

    private void ShowNextHitSprite()
    {
        //To get first value in the array
        int spriteIndex = timesHit - 1;

        if(hitSprites[spriteIndex] != null)
        {
            GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
        else
        {
            Debug.LogError("Block sprite is missing from the array, Game Object: " + gameObject.name);
        }
        
    }

    private void CountBreakableBlocks()
    {
        level = FindObjectOfType<Level>();

        if(tag == "Breakable")
        {
            level.CountBlocks();
        }
    }

    private void DestroyBlock()
    {
        PlayBlockDestroySFX();

        Destroy(gameObject);
        level.BlockDestroyed();

        // Call sparkle effect
        triggerSparklesVFX();
    }

    private void PlayBlockDestroySFX()
    {
        // Add to score after destroying block
        FindObjectOfType<GameStatus>().AddToScore();

        // Play sound effect and destroy block
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
    }

    private void triggerSparklesVFX()
    {
        GameObject sparkles = Instantiate(blockSparklesVFX, transform.position, transform.rotation);
        Destroy(sparkles, 1f);
    }

}
