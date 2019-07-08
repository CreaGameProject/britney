using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveStartButton : MonoBehaviour
{
    [SerializeField] private float max_size = 0.25f;
    [SerializeField] private float min_size = 0.15f;
    private float t = 0;
    private int n = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(t > 1)
            n = -1;
        if (t < 0)
            n = 1;
        t += Time.deltaTime * n;
        transform.localScale = new Vector3(Mathf.Lerp(max_size, min_size, t), Mathf.Lerp(max_size, min_size, t), 1);
    }
}
