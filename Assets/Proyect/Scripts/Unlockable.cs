using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unlockable : MonoBehaviour
{
    public Collider2D collider;
    public GameObject door;
    public bool IsLocked = true;
    public void SetLocked(bool locked)
    {
        IsLocked = locked;
    }
    public void TryOpen()
    {
        if(IsLocked == false)
        {
            Destroy(door);
        }
    }
}
