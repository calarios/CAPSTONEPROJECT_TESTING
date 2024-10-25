//CODE FOR CAMERA TO REPLICATE SIDE SCROLLING OF SUPER MARIO BROS

using UnityEngine;
public class SideScrolling : MonoBehaviour
{
    //FIND WITH TAG THE PLAYER/MARIO
    private Transform player;
    private void Awake()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    //CONTINUOUSLY UPDATE TO POSITION CAMERA WITH MARIO
    private void LateUpdate()
    {
        Vector3 cameraPosition = transform.position;
        cameraPosition.x = Mathf.Max(cameraPosition.x, player.position.x);
        transform.position = cameraPosition;
    }
}
