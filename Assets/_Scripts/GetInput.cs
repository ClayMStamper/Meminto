using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//platform independent input class

public static class GetInput {

    public static bool Forward() {

        if (Input.GetKey(KeyCode.D))
            return true;

        if (Input.GetKey(KeyCode.RightArrow))
            return true;

        return false;

    }
    
    public static bool Back() {

        if (Input.GetKey(KeyCode.A))
            return true;

        if (Input.GetKey(KeyCode.LeftArrow))
            return true;

        return false;

    }
    
    public static bool Up() {

        if (Input.GetKeyDown(KeyCode.W))
            return true;

        if (Input.GetKeyDown(KeyCode.UpArrow))
            return true;
        
        if (Input.GetKeyDown(KeyCode.Space))
            return true;

        return false;

    }

    public static bool UpFlick() {
        
        if (Input.GetKey(KeyCode.W))
            return true;

        if (Input.GetKey(KeyCode.UpArrow))
            return true;
        
        if (Input.GetKey(KeyCode.Space))
            return true;

        return false;
        
    }
    
    public static bool Down() {

        if (Input.GetKeyDown(KeyCode.S))
            return true;

        if (Input.GetKeyDown(KeyCode.DownArrow))
            return true;

        return false;

    }
    
    public static bool UpLight() {

        return (Input.GetKey(KeyCode.J) && UpFlick());

    }
    
    public static bool ForwardLight() {

        if (Input.GetKeyDown(KeyCode.J) && (Forward() || Back())) 
            return true;

        return false;

    }
    
    public static bool DownLight() {

        if (Input.GetKeyDown(KeyCode.J) && Down())
            return true;

        return false;

    }
    
    public static bool HeavyAttack() {

        if (Input.GetKey(KeyCode.O))
            return true;

        return false;

    }
    
    
    
}
