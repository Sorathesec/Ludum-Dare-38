using UnityEngine;

namespace Netaphous.Utilities
{
    public abstract class BasicPoolManager : MonoBehaviour
    {
        // Public variables
        // To be set in the editor

        // Private variables
        // Can be accessed in the editor
        [SerializeField]
        protected int pooledAmount = 50;
        [SerializeField]
        protected GameObject objectPrefab;

        // Script logic
        private GameObject[] objectPool;

        /// <summary>
        /// Initialises the object pool and fills it with game objects made from the prefab given
        /// </summary>
        protected void CreatePool()
        {
            objectPool = new GameObject[pooledAmount];

            for (int i = 0; i < pooledAmount; i++)
            {
                objectPool[i] = Instantiate(objectPrefab) as GameObject;
                objectPool[i].SetActive(false);
            }
        }

        /// <summary>
        /// Returns a gameobject from the local pool if there is one available
        /// </summary>
        /// <returns> The gameobject from the pool </returns>
        protected GameObject GetPooledItem()
        {
            for (int i = 0; i < pooledAmount; i++)
            {
                if (objectPool[i] != null &&
                    !objectPool[i].activeInHierarchy)
                {
                    return objectPool[i];
                }
            }
            return null;
        }
        
        /// <summary>
        /// Resets every active object in the bool to inactive
        /// </summary>
        protected void ResetPool()
        {
            for (int i = 0; i < objectPool.Length; i++)
            {
                if (objectPool[i] != null &&
                    objectPool[i].activeInHierarchy)
                {
                    objectPool[i].SetActive(false);
                }
            }
        }
    }
}