using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MoveCamera : MonoBehaviour
{
    // Добавляем объект, за которым будет двигаться камера
    public Transform target;
    private Vector3 velocity;

    void Update()
    {
        //SmoothDamp плавно изменяет положение. pos arg1 -> pos arg2, направление = pos arg3, speed = arg4;  
        transform.position = Vector3.SmoothDamp(transform.position, new Vector3(target.position.x, target.position.y, -10), ref velocity, 0.1f);
    }
}




//Возможно это понадобится в будущем
//[Header("Camera position restrictions")]
//[SerializeField] float minY;
//[SerializeField] float maxY;
//[SerializeField] float minX;
//[SerializeField] float maxX;