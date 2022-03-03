using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//C# Modules to work with system files.
using System;
using System.IO;

public class patient_movement : MonoBehaviour
{
    Rigidbody my_rigid_body;
    [SerializeField] float speed;
    [SerializeField] int sample_rate;
    private int counter = 0;
    private String file_name = "LogFile.txt";

    // Start is called before the first frame update
    void Start()
    {
        my_rigid_body = GetComponent<Rigidbody>();
        
        if (File.Exists(file_name))    
        {      
            File.Delete(file_name);  
        }
    }

    // Update is called once per frame
    void Update()
    {
        float x_increment = Input.GetAxisRaw("Horizontal");
        float z_increment = Input.GetAxisRaw("Vertical");

        Vector3 moveBy = transform.right * x_increment + transform.forward * z_increment;

        my_rigid_body.MovePosition(transform.position + moveBy.normalized * speed * Time.deltaTime);

        Vector3 patient_position = transform.position;
        //Debug.Log("X: " + string.Format("{0:0.000}", patient_position.x));

        if(counter >= sample_rate)
        {
            counter = 0;
            using (StreamWriter file = new StreamWriter(file_name, append: true))
            {
                file.WriteLine("" + DateTime.Now.ToString("hh:mm:ss tt") + 
                " (X: " + string.Format("{0:0.000}", patient_position.x) + ")" +
                " (Y: " + string.Format("{0:0.000}", patient_position.y) + ")");
            }
        }
        counter++;
    }
}
