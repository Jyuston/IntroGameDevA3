using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{

    [SerializeField]
    private GameObject pacman;
    private Tweener tweener;
    private Vector3 bottomLeft;
    private Vector3 bottomRight;
    private Vector3 topLeft;
    private Vector3 topRight;


    // Start is called before the first frame update
    void Start()
    {
        tweener = GetComponent<Tweener>();
        bottomLeft = new Vector3(-7.5f, -0.5f, 0.0f);
        bottomRight = new Vector3(3.5f, -0.5f, 0.0f);
        topLeft = new Vector3(-7.5f, 3.5f, 0.0f);
        topRight = new Vector3(3.5f, 3.5f, 0.0f);


    }

    // Update is called once per frame
    void Update()
    {
        if (pacman.transform.position == bottomLeft)
        {
            tweener.AddTween(pacman.transform, pacman.transform.position, topLeft, 2.0f, "up");
        }

         if (pacman.transform.position == bottomRight)
        {
            tweener.AddTween(pacman.transform, pacman.transform.position, bottomLeft, 4.0f, "left");
        }

         if (pacman.transform.position == topRight)
        {
            tweener.AddTween(pacman.transform, pacman.transform.position, bottomRight, 2.0f, "down");
        }

        if (pacman.transform.position == topLeft)
        {
            tweener.AddTween(pacman.transform, pacman.transform.position, topRight, 4.0f, "right");
        }
    }


}
