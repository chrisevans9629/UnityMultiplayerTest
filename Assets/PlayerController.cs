using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class PlayerController : NetworkBehaviour
{
    [SerializeField]
    private float movespeed = 3f;

    private Camera Camera;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public override void OnNetworkSpawn()
    {
        Camera = Camera.main;
        base.OnNetworkSpawn();
    }
    // Update is called once per frame
    void Update()
    {
        if (!IsOwner)
        {
            return;
        }
        var vector = new Vector3(0, 0, 0);

        if (Input.GetKey(KeyCode.W))
            vector.y = 1;
        if (Input.GetKey(KeyCode.S))
            vector.y = -1;
        if (Input.GetKey(KeyCode.A))
            vector.x = -1;
        if (Input.GetKey(KeyCode.D))
            vector.x = 1;
        transform.position += vector * movespeed * Time.deltaTime;

        var cP = Camera.transform.position;
        cP.x = transform.position.x;
        cP.y = transform.position.y;
        Camera.transform.position = cP;
    }
}
