using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITurnable
{
    public void TurnRight();
    public void TurnLeft();
}

public interface IMovable
{
    public void GoForward();
    public void Reverse();
}
public class Vehicle : MonoBehaviour
{
    void Mdd()
    {
       
    }
}

public class RoadVehicle : Vehicle, IMovable, ITurnable
{
    public float speed = 100f;
    public float turnSpeed = 5f;

    public void GoForward()
    {
        transform.position += Vector3.forward * Time. deltaTime * speed;
    }

    public void Reverse()
    {
        
    }

    public void TurnLeft()
    {
        
    }

    public void TurnRight()
    {
        
    }
}

public class RailVehicle : Vehicle, IMovable
{
    public float speed = 100f;
    public void GoForward()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    public void Reverse()
    {
        
    }
}

public class Car : RoadVehicle
{

}

public class Train : RailVehicle
{
    
}
