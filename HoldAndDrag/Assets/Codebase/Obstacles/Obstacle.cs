using EzySlice;
using UnityEngine;

namespace Codebase.Obstacles
{
    public class Obstacle : MonoBehaviour, ISliceable
    {
        public void DoSlice(EzySlice.Plane plane)
        {
           var slices = gameObject.SliceInstantiate(plane, 
               new TextureRegion(0.0f, 0.0f, 1.0f, 1.0f),
               this.GetComponent<Renderer>().material
               );

           if (slices != null && slices.Length > 0)
           {
               foreach (GameObject shatteredObject in slices) 
               {
                   shatteredObject.AddComponent<MeshCollider>().convex = true;
                   shatteredObject.AddComponent<Rigidbody>();
               }
           }
           
           gameObject.SetActive(false);
        }
    }
}