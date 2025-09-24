using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class TowerPickup : MonoBehaviour
{
    [SerializeField] Transform player_raypos;
    [SerializeField] GameObject hold_position;
    public bool isHoldingT;
    [SerializeField] LayerMask groundLyaer;
    Tower tower;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            PickDrop();
        }
    }
    void PickDrop()
    {
        if(!isHoldingT)
        {
            RaycastHit hit;
            if (Physics.Raycast(player_raypos.transform.position, player_raypos.transform.forward, out hit, 5))
            {
                tower = hit.transform.gameObject.GetComponent<Tower>();
                if (tower != null)
                {
                    tower.transform.SetParent(hold_position.transform);
                    tower.transform.localPosition = Vector3.zero;
                    tower.transform.localRotation = Quaternion.identity;
                    isHoldingT = true;
                }
            }
        }
        else if(isHoldingT)
        {
          
            RaycastHit hit;
            if(Physics.Raycast(hold_position.transform.position,Vector3.down, out hit, 5, groundLyaer))
            {
               
                Vector3 groundPoint = hit.point;

                tower.transform.SetParent(null);
                tower.transform.position = groundPoint;
                tower.transform.rotation = Quaternion.identity;
                isHoldingT = false;
            }
        }
        
    }
}
