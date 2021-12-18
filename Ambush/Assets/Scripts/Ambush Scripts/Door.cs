
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private Transform previousRoom;
    [SerializeField] private Transform nextRoom;
    [SerializeField] private CameraController cam;

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.tag == "Player")
        {
            if(collision.transform.position.x < transform.position.x) //if player's x position is smaller than door's x position
                cam.MovetoNewRoom(nextRoom); //coming from left
            else
                cam.MovetoNewRoom(previousRoom); // coming from right
        }
        
    }

    private void Awake()
    {
        cam = Camera.main.GetComponent<CameraController>();
    }

}
