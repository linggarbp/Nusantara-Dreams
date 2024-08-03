using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaTransition : MonoBehaviour
{
    public StarPointInventory starPointInventory;
    public int starReq = -1;
    public int pointReq = -1;
    [SerializeField]
    List<GameObject> gateOpenable;

    public Vector2 cameraChange;
    public Vector3 playerChange;
    private CameraMovement cam;
    [HideInInspector] public int countTransition;

    public bool TriggeredOnce = false;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main.GetComponent<CameraMovement>();
    }

    private void Update()
    {
        if (starPointInventory.starPoints[0].numberHeld >= starReq && starPointInventory.starPoints[1].numberHeld >= pointReq && gateOpenable[1].activeSelf && gateOpenable[2].activeSelf && (gateOpenable[3].activeSelf || gateOpenable[4].activeSelf) || gateOpenable[5].activeSelf || gateOpenable[6].activeSelf)
        {
            gateOpenable[0].SetActive(false);
        }
        else
        {
            gateOpenable[0].SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //if (starPointInventory.starPoints[0].numberHeld >= starReq && starPointInventory.starPoints[1].numberHeld >= pointReq)
            //{
                ChangeCamera(collision);
            //}
        }
    }

    void ChangeCamera(Collider2D collision)
    {
        cam.minPosition += cameraChange;
        cam.maxPosition += cameraChange;
        collision.transform.position += playerChange;
        countTransition++;
    }
}
