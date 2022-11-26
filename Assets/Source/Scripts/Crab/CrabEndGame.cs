using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrabEndGame : MonoBehaviour
{
    [SerializeField] private Transform target;

    [SerializeField] private float speedJump;
    private bool isMove = false;

    private void Start()
    {
        Invoke(nameof(JumpToPlayer), 1f);
    }

    public void JumpToPlayer()
    {
        isMove = true;
    }

    private void Update()
    {
        if (isMove)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(target.position.x, target.position.y, target.position.z - 0.335f), Time.deltaTime * speedJump);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(-180, 0, 0), Time.deltaTime * speedJump);
        }
    }
}
