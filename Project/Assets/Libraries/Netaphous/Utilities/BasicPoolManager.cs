using UnityEngine;

namespace Netaphous.Utilities
{
    public abstract class BasicPoolManager : MonoBehaviour
    {
        // Private variables
        // Can be accessed in the editor
        [SerializeField]
        protected int[] pooledAmounts;
        [SerializeField]
        protected GameObject[] objectPrefab;
        [SerializeField]
        private bool poolAsChildren = false;

        // Script logic
        private GameObject[] objectPool;
        private int poolTotal = 0;

        /// <summary>
        /// Initialises the object pool and fills it with game objects made from the prefab given
        /// </summary>
        protected void CreatePool()
        {
            for(int i = 0; i < pooledAmounts.Length; i++)
            {
                poolTotal += pooledAmounts[i];
            }
            objectPool = new GameObject[poolTotal];

            int count = 0;
            for (int i = 0; i < pooledAmounts.Length; i++)
            {
                for (int j = 0; j < pooledAmounts[i]; j++)
                {
                    objectPool[count] = Instantiate(objectPrefab[i]) as GameObject;
                    if (poolAsChildren)
                    {
                        objectPool[count].transform.parent = transform;
                    }
                    objectPool[count].SetActive(false);
                    count++;
                }
            }
        }

        /// <summary>
        /// Returns a gameobject from the local pool if there is one available
        /// </summary>
        /// <returns> The gameobject from the pool </returns>
        protected GameObject GetPooledItem()
        {
            for (int i = 0; i < poolTotal; i++)
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