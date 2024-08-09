using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pot : MonoBehaviour
{
    private Animator animator;
    public GameObject prefabsToSpawn; // Prefab GameObject yang akan di-spawn
    public GameObject targetObject; // GameObject target yang akan dijadikan tempat spawn

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Smash()
    {
        animator.SetBool("smash", true);
        StartCoroutine(breakCo());
        Instantiate(prefabsToSpawn, targetObject.transform.position, Quaternion.identity);
    }

    IEnumerator breakCo()
    {
        yield return new WaitForSeconds(.3f);
        gameObject.SetActive(false);
        //Destroy(gameObject);
    }
}
