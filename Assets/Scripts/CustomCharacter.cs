using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StarterAssets {
    public class CustomCharacter : StarterAssetsInputs
    {
        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            sprint = Mathf.Abs(move.x) >= 1 || Mathf.Abs(move.y) >=1;
        }
    }
}

