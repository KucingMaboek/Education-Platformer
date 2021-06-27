using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudController : MonoBehaviour
{
    private Transform tf;
    [SerializeField]
    private Vector3 pos, posStart;
    [SerializeField]
    private float speed;

    // Start is called before the first frame update
    void Awake()
    {
        tf = GetComponent<Transform>();

    }

    private void Start()
    {
        posStart = tf.localPosition;
        pos = tf.localPosition;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CloudMove();
    }

    private void CloudMove()
    {
        if (pos.x >= -16)
        {
            pos.x -= speed * Time.deltaTime;
            tf.localPosition = pos;
        }
        else
        {
            pos.x = 16;
            tf.localPosition = pos;
            pos = tf.localPosition;
        }
        
    }
}
