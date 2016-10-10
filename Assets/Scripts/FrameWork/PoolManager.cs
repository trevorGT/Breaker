using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Breaker
{
    public class PoolManager : Singleton<PoolManager>
    {
        public int capacity = 10;
        private List<GameObject> dormantObjects = new List<GameObject>();
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
        /// <summary>
        /// spawn game object for game while already have object in memery
        /// </summary>
        /// <param name="go"></param>
        /// <returns></returns>
        public GameObject Spawn(GameObject go)
        {
            GameObject temp = null;
            if (dormantObjects.Count > 0)
            {
                foreach (GameObject dob in dormantObjects)
                {
                    if (dob.name == go.name)
                    {
                        temp = dob;
                        dormantObjects.Remove(temp);
                        return temp;
                    }
                }
            }
            temp = GameObject.Instantiate(go) as GameObject;
            temp.name = go.name;
            return temp;
        }
        /// <summary>
        /// kill object 
        /// </summary>
        /// <param name="go"></param>
        public void Despawn(GameObject go)
        {
            go.transform.parent = PoolManager.Instance.transform;
            go.SetActive(false);
            dormantObjects.Add(go);
            Trim();
        }
        /// <summary>
        /// delete object from memery while out of range
        /// </summary>
        public void Trim()
        {
            while (dormantObjects.Count > capacity)
            {
                GameObject dob = dormantObjects[0];
                dormantObjects.RemoveAt(0);
                Destroy(dob);
            }
        }
    }
}