using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShinyObjectScript : MonoBehaviour
{
    public GameObject _sparkleEffect;

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        var spawnPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        var defaultRotation = new Quaternion(0, 0, 0, 0);
        var sparkles = Instantiate(_sparkleEffect, spawnPosition, defaultRotation);
        Destroy(sparkles, 2.0f);
    }
}