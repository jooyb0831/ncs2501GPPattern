using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Shape
{
    public abstract float CalculateArea();
}

public class Rectangle : Shape
{
    public float width;
    public float height;

    public override float CalculateArea()
    {
        return width * height;
    }
}

public class Circle : Shape
{
    public float radius;
    public override float CalculateArea()
    {
        return radius * radius * Mathf.PI;
    }
}

public class AreaCalculator : MonoBehaviour
{
    public float GetArea(Shape shape)
    {
        return shape.CalculateArea();
    }
}
