using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddRoomToList : MonoBehaviour
{
    private Room_Template template;
    void Start()
    {
        template = GameObject.FindGameObjectWithTag("Rooms").GetComponent<Room_Template>();
        template.roomList.Add(this.gameObject);
    }
}
