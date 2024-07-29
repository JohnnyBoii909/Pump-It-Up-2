using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifetimeManager : MonoBehaviour
{
    public float lifetime;

    private void Start()
    {
        StartCoroutine(DestroyAfterLifetime());
    }

    private IEnumerator DestroyAfterLifetime()
    {
        yield return new WaitForSeconds(lifetime);
        Destroy(gameObject);
    }
}
