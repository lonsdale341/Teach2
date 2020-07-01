using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Task_three : MonoBehaviour
{
    public GameObject Point;
    //public GameObject Point_1;
    //public GameObject Point_2;
    List<GameObject> PoolPoint;
    public GameObject grid_Parent;
    public GameObject Parent_All;
    public GameObject y_axes;
    public GameObject x_axes;
    List<GameObject> Pool_Y;
    List<GameObject> Pool_X;
    public Text funcText;
    float k;
    float b;
    //bool IsMouse;
    //GameObject currentPoint;

    void Start()
    {
        PoolPoint = new List<GameObject>();
        for (float x = -100; x < 100; x += 0.05f)
        {
            GameObject clone = Instantiate(Point);
            PoolPoint.Add(clone);
            clone.transform.SetParent(Parent_All.transform);
        }
        Grid();
        SetGrafic_B(b);
        SetGrafic_K(k);
    }
    void Update()
    {
        //float x_1 = Point_1.transform.position.x;
        //float y_1 = Point_1.transform.position.y;
        //float x_2 = Point_2.transform.position.x;
        //float y_2 = Point_2.transform.position.y;
        //float d_x = 0;
        //if (x_2 - x_1 == 0)
        //{
        //    d_x = 0.0000000001f;
        //}
        //else
        //{
        //    d_x = x_2 - x_1;
        //}
        //k = (y_2 - y_1) / (d_x);
        //b = (y_1 * x_2 - y_2 * x_1) / (d_x);
        //if (Input.GetMouseButtonDown(0))
        //{
        //    IsMouse = true;
        //}
        //if (Input.GetMouseButtonUp(0))
        //{
        //    IsMouse = false;
        //    currentPoint = null;
        //}
        //if (IsMouse)
        //{
        //    RaycastHit hit;
        //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //    if (Physics.Raycast(ray, out hit))
        //    {
        //        if (hit.collider.gameObject.name == "Point_1")
        //        {
        //            currentPoint = Point_1;
        //        }
        //        if (hit.collider.gameObject.name == "Point_2")
        //        {
        //            currentPoint = Point_2;
        //        }
        //        if (currentPoint != null && hit.collider.gameObject.name == "Plane")
        //        {
        //            int x = (int)hit.point.x;
        //            int y = (int)hit.point.y;
        //            currentPoint.transform.position = new Vector3(x, y, hit.point.z);
        //        }
        //    }
        //}
        funcText.text = "Y=" + CommonData.k.ToString() + "X+" + CommonData.b.ToString();
    }

    public void SetGrafic_B(float b)
    {
        CommonData.b = b;
        int i = 0;
        for (float x = -100; x < 100; x += 0.05f)
        {

            //float y = CommonData.k *  x + CommonData.b;
            //if(y<0)
            //{
            //    y = Mathf.Abs(y);
            //}
            float y = CommonData.k * Mathf.Abs(x) + CommonData.b;
            PoolPoint[i].transform.position = new Vector3(x, y, 0);
            PoolPoint[i].GetComponent<MeshRenderer>().material.color = Color.blue;
            i++;
        }
    }
    public void SetGrafic_K(float k)
    {
        CommonData.k = k;
        int i = 0;
        for (float x = -100; x < 100; x += 0.05f)
        {
            float y = CommonData.k * x + CommonData.b;
            PoolPoint[i].transform.position = new Vector3(x, y, 0);
            PoolPoint[i].GetComponent<MeshRenderer>().material.color = Color.blue;
            i++;
        }
    }



    void Grid()
    {
        Pool_Y = new List<GameObject>();

        int k = 0;
        for (int i = -12; i < 13; i++)
        {
            GameObject clone = Instantiate(y_axes);
            clone.transform.position = new Vector3(i, 0, 0);
            Pool_Y.Add(clone);
            clone.transform.SetParent(grid_Parent.transform);
            if (i == 0)
            {
                Pool_Y[k].GetComponent<MeshRenderer>().material.color = Color.red;
            }
            k++;
        }
        Pool_X = new List<GameObject>();
        int p = 0;
        for (int i = -12; i < 13; i++)
        {
            GameObject clone = Instantiate(x_axes);
            clone.transform.position = new Vector3(0, i, 0);
            Pool_X.Add(clone);
            clone.transform.SetParent(grid_Parent.transform);
            if (i == 0)
            {
                Pool_X[p].GetComponent<MeshRenderer>().material.color = Color.red;
            }
            p++;
        }
    }

}
