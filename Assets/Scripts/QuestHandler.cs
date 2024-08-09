using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class QuestHandler : MonoBehaviour
{
    [SerializeField] private List<GameObject> skillLevel = new List<GameObject>();
    [SerializeField] private List<GameObject> questLevel = new List<GameObject>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("One"))
        {
            // Activate skillLevel[0] and questLevel[0]
            skillLevel[0].SetActive(true);
            questLevel[0].SetActive(true);

            // Deactivate skillLevel[1] to skillLevel[4] and questLevel[1] to questLevel[4]
            for (int i = 1; i < skillLevel.Count; i++)
            {
                skillLevel[i].SetActive(false);
                questLevel[i].SetActive(false);
            }
        }
        else if (collision.gameObject.CompareTag("Two"))
        {
            // Activate skillLevel[1] and questLevel[1]
            skillLevel[1].SetActive(true);
            questLevel[1].SetActive(true);

            // Deactivate skillLevel[0], skillLevel[2] to skillLevel[4],
            // questLevel[0], and questLevel[2] to questLevel[4]
            for (int i = 0; i < skillLevel.Count; i++)
            {
                if (i != 1)
                {
                    skillLevel[i].SetActive(false);
                    questLevel[i].SetActive(false);
                }
            }
        }
        else if (collision.gameObject.CompareTag("Three"))
        {
            // Activate skillLevel[2] and questLevel[2]
            skillLevel[2].SetActive(true);
            questLevel[2].SetActive(true);

            // Deactivate skillLevel[0], skillLevel[1], skillLevel[3], and skillLevel[4],
            // questLevel[0], questLevel[1], questLevel[3], and questLevel[4]
            for (int i = 0; i < skillLevel.Count; i++)
            {
                if (i != 2)
                {
                    skillLevel[i].SetActive(false);
                    questLevel[i].SetActive(false);
                }
            }
        }
        else if (collision.gameObject.CompareTag("Four"))
        {
            // Activate skillLevel[3] and questLevel[3]
            skillLevel[3].SetActive(true);
            questLevel[3].SetActive(true);

            // Deactivate skillLevel[0], skillLevel[1], skillLevel[2], and skillLevel[4],
            // questLevel[0], questLevel[1], questLevel[2], and questLevel[4]
            for (int i = 0; i < skillLevel.Count; i++)
            {
                if (i != 3)
                {
                    skillLevel[i].SetActive(false);
                    questLevel[i].SetActive(false);
                }
            }
        }
        else if (collision.gameObject.CompareTag("Five"))
        {
            // Activate skillLevel[4] and questLevel[4]
            skillLevel[4].SetActive(true);
            questLevel[4].SetActive(true);

            // Deactivate skillLevel[0], skillLevel[1], skillLevel[2], and skillLevel[3],
            // questLevel[0], questLevel[1], questLevel[2], and questLevel[3]
            for (int i = 0; i < skillLevel.Count; i++)
            {
                if (i != 4)
                {
                    skillLevel[i].SetActive(false);
                    questLevel[i].SetActive(false);
                }
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
