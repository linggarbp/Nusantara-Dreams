using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryTrigger : MonoBehaviour
{
    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;
    private bool triggerOnce = false;

    private void Update()
    {
        if (triggerOnce && !StoryManager.GetInstance().dialogueIsPlaying)
        {
            this.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StoryManager.GetInstance().EnterDialogueMode(inkJSON);
            triggerOnce = true;
        }
    }
}
