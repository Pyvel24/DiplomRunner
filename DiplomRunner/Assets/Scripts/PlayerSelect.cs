using UnityEngine;

namespace DefaultNamespace
{
    public class PlayerSelect: MonoBehaviour
    {
        private GameObject[] charachers;
       private int index;

       private void Start()
       {
           charachers = new GameObject[transform.childCount];
           for (int i = 0; i < transform.childCount; i++)
           {
               charachers[i] = transform.GetChild(i).gameObject;
           }

           foreach (GameObject go in charachers)
           {
               go.SetActive(false);
           }

           if (charachers[0])
           {
               charachers[0].SetActive(true);
           }
       }

       public void SelectLeft()
       {
           charachers[index].SetActive(false);
           index--;
           if (index < 0)
           {
               index = charachers.Length - 1;
           }
           charachers[index].SetActive(true);
       }
       public void SelectRight()
       {
           charachers[index].SetActive(false);
           index++;
           if (index == charachers.Length)
           {
               index = 0;
           }
           charachers[index].SetActive(true);
       }
       
    }
}