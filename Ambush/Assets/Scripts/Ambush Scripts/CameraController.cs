//the purpose of this script is to move camera around
using UnityEngine;

public class CameraController : MonoBehaviour
{
    /*
    //Room camera
    [SerializeField]private float speed;
    private float currentPosx;
    private Vector3 velocity = Vector3.zero;

    //Follow player
    [SerializeField]private Transform player;
    [SerializeField]private float aheadDistance;
    [SerializeField]private float cameraSpeed;
    private float lookAhead;

    private void Update() 
    {
        //Room camera
        //transform.position = Vector3.SmoothDamp(transform.position, new Vector3(currentPosx, transform.position.y, transform.position.z), ref velocity, speed); //method for smoothing the following camera

        //Follow player
        transform.position = new Vector3(player.position.x + lookAhead, transform.position.y, transform.position.z);
        lookAhead = Mathf.Lerp(lookAhead, (aheadDistance * player.localScale.x), Time.deltaTime * cameraSpeed);
    }
    
    public void MovetoNewRoom(Transform _newRoom)
    {
        currentPosx = _newRoom.position.x;
    }
    */

    [SerializeField]private Transform player;
    [SerializeField]private float aheadDistance;
    [SerializeField]private float cameraSpeed;
    private float lookAhead;

    private void Update()
    {
        lookAhead = Mathf.Lerp(lookAhead, (aheadDistance * player.localScale.x), Time.deltaTime * cameraSpeed);
        transform.position = new Vector3(player.position.x + lookAhead, player.position.y + 1, transform.position.z);
        
    }
}
