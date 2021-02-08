using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject blockSparkles;
    [SerializeField] Sprite[] hitSprites;

    int timeHits;

    Level level;
    GameSession gameSession;

    private void Start()
    {
        CountBreakableBlocks();
    }

    private void CountBreakableBlocks()
    {
        gameSession = FindObjectOfType<GameSession>();
        level = FindObjectOfType<Level>();
        if (tag == "Breakable")
        {
            level.CountBlocks();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag == "Breakable")
        {
            HandleHit();
        }
    }

    private void ShowNextBlockDamageLevel()
    {
        int spriteIndex = timeHits - 1;
        if(hitSprites[spriteIndex] != null)
        {
            GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
        else
        {
            Debug.LogError("Block sprite is missing from array");
        }
    }

    private void HandleHit()
    {
        timeHits++;
        int maxHits = hitSprites.Length + 1;
        if (timeHits >= maxHits)
        {
            DestroyBlock();
            TriggerSparklesVFX();
        }
        else
        {
            ShowNextBlockDamageLevel();
        }
    }

    private void TriggerSparklesVFX()
    {
        GameObject sparkles = Instantiate(blockSparkles, transform.position, transform.rotation);
        Destroy(sparkles, 1f);
    }

    private void DestroyBlock()
    {
        Destroy(gameObject);
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
        level.DestoyedBlocks();
        gameSession.PlayScore();
    }
}
