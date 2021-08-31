using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSc : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       

        ParticleSystemRenderer taa = this.GetComponent<ParticleSystemRenderer>();
        if (JumpKing.particleC > 0)
        {
            taa.flip = new Vector3(0, 0, 0);
        }
        else if(JumpKing.particleC == 0)
        {
            taa.flip = taa.flip;
        }
        else 
        {
            taa.flip = new Vector3(1, 0, 0);

        }

    }
}
