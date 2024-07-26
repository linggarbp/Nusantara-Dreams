using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarPoint : MonoBehaviour
{
    [SerializeField] int point;
    [SerializeField] int star;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
        }
    }
}
