using Codebase.Obstacles;
using UnityEngine;

namespace Codebase.Projectile
{
    public class ProjectileCollision : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            var sliceble = other.gameObject.GetComponent<ISliceable>();
            
            if (sliceble != null) 
                sliceble.DoSlice(new EzySlice.Plane(this.transform.position / 2, transform.up));
        }
    }
    
}