using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateNuclearBomb : MonoBehaviour
{

    public GameObject explosion;

    public void delExplosion() {
        Destroy(gameObject);
    }
}
