using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.PackageManager;
using UnityEngine;

public interface ISwitchable
{
    public bool IsActive {get;}
    public void Activate();
    public void Deactivate();
}
public class Switch : MonoBehaviour
{
    //public Door door;
    //public bool isActivated;

    public ISwitchable client;

    public void Toggles()
    {
        if(client.IsActive)
        {
            client.Deactivate();
        }
        else
        {
            client.Activate();
        }
        /*
        if(isActivated)
        {
            isActivated = false;
            door.Close();
        }
        else
        {
            isActivated = true;
            door.Open();
        }
        */
    }
}

public class Door : MonoBehaviour, ISwitchable
{
    private bool isActive;
    public bool IsActive => isActive;

    public void Open()
    {
        Debug.Log("The Door is Open");
    }

    public void Close()
    {
        Debug.Log("The Door is Closed");
    }

    public void Activate()
    {
        isActive = true;
    }
    public void Deactivate()
    {
        isActive = false;
    }
}
public class SwitchDoor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
