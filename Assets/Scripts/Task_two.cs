using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Task_two : MonoBehaviour
{
    public GameObject Point;
    public GameObject Point_1;
    public GameObject Point_2;
    List<GameObject> PoolPoint;

    List<GameObject> PoolPointVariant;
    float k_variant = 0;
    float b_variant = 0;
    public Text funcTextVariant;

    public GameObject grid_Parent;
    public GameObject Parent_All;
    public GameObject y_axes;
    public GameObject x_axes;
    List<GameObject> Pool_Y;
    List<GameObject> Pool_X;
    public Text funcText;
    bool IsMouse;
    GameObject currentPoint;
    float k = 0;
    float b = 0;
    
    void Start()
    {
        PoolPoint = new List<GameObject>();
        for (float x = -100; x < 100; x += 0.05f)
        {
            GameObject clone = Instantiate(Point);
            PoolPoint.Add(clone);
            clone.transform.SetParent(Parent_All.transform);
        }
        PoolPointVariant = new List<GameObject>();
        for (float x = -100; x < 100; x += 0.05f)
        {
            GameObject clone = Instantiate(Point);
            PoolPointVariant.Add(clone);
            clone.transform.SetParent(Parent_All.transform);//
        }
        Grid();
        SetRandom_k_b();
    }

    void Update()
    {
        float x_1 = Point_1.transform.position.x;
        float y_1 = Point_1.transform.position.y;
        float x_2 = Point_2.transform.position.x;
        float y_2 = Point_2.transform.position.y;
        float d_x = 0;
        if (x_2 - x_1 == 0)
        {
            d_x = 0.0000000001f;
        }
        else
        {
            d_x = x_2 - x_1;
        }
        k_variant = (y_2 - y_1) / (d_x);
        b_variant = (y_1 * x_2 - y_2 * x_1) / (d_x);
        if (Input.GetKeyDown(KeyCode.R))
        {
            SetRandom_k_b();
        }
        if (Input.GetMouseButtonDown(0))
        {
            IsMouse = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            IsMouse = false;
            currentPoint = null;
        }
        if (IsMouse)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.name == "Point_1")
                {
                    currentPoint = Point_1;
                }

                if (hit.collider.gameObject.name == "Point_2")
                {
                    currentPoint = Point_2;
                }
                if (currentPoint != null && hit.collider.gameObject.name == "Plane")
                {
                    int x = (int)hit.point.x;
                    int y = (int)hit.point.y;
                    currentPoint.transform.position = new Vector3(x, y, hit.point.z);
                }
            }
        }
        funcText.text = "Y=" + k.ToString() + "X+" + b.ToString();
        funcTextVariant.text = "Y_var=" + k_variant.ToString() + "X_var+" + b_variant.ToString();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CheckResult();
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


   public void CheckResult()
    {
        if ((k == k_variant) && (b == b_variant))
        {
            int i = 0;
            for (float x = -100; x < 100; x += 0.05f)
            {
                float y = k * x + b;
                PoolPoint[i].transform.position = new Vector3(x, y, 0);
                PoolPoint[i].GetComponent<MeshRenderer>().material.color = Color.green;
                i++;
            }
            int s = 0;
            for (float x = -100; x < 100; x += 0.05f)
            {
                float y = k_variant * x + b_variant;
                PoolPointVariant[s].transform.position = new Vector3(x, y, 0);
                PoolPointVariant[s].GetComponent<MeshRenderer>().material.color = Color.green;
                s++;
            }
        }
        else
        {
            int i = 0;
            for (float x = -100; x < 100; x += 0.05f)
            {
                float y = k * x + b;
                PoolPoint[i].transform.position = new Vector3(x, y, 0);
                PoolPoint[i].GetComponent<MeshRenderer>().material.color = Color.gray;
                i++;
            }
            int s = 0;

            for (float x = -100; x < 100; x += 0.05f)
            {
                float y = k_variant * x + b_variant;
                PoolPointVariant[s].transform.position = new Vector3(x, y, 0);
                PoolPointVariant[s].GetComponent<MeshRenderer>().material.color = Color.red;
                s++;
            }
        }
    }

    void SetRandom_k_b()
    {
        k = (int)Random.Range(-5, 5);
        b = (int)Random.Range(-10, 10);
    }
    public void Reset()
    {
        SetRandom_k_b();

        int i = 0;
        for (float x = -100; x < 100; x += 0.05f)
        {
            PoolPoint[i].transform.position = new Vector3(0, 0, 2);
            i++;
        }
        int s = 0;

        for (float x = -100; x < 100; x += 0.05f)
        {

            PoolPointVariant[s].transform.position = new Vector3(0, 0, 2);
            s++;
        }

    }
}

