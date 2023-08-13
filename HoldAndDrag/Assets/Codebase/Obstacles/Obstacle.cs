using EzySlice;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Codebase.Obstacles
{
    public class Obstacle : MonoBehaviour, ISliceable
    {
        public void DoSlice(EzySlice.Plane plane)
        {
           var slices = this.gameObject.SliceInstantiate(plane, 
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
           
           this.gameObject.SetActive(false);
        }

        private EzySlice.Plane GetRandomPlane(Vector3 positionOffset, Vector3 scaleOffset) {
            Vector3 randomPosition = Random.insideUnitSphere;

            //randomPosition += positionOffset;

            Vector3 randomDirection = Random.insideUnitSphere.normalized;

            return new EzySlice.Plane(randomPosition, randomDirection);
        }
    }

    public interface ISliceable
    {
        public void DoSlice(EzySlice.Plane plane);
    }
}