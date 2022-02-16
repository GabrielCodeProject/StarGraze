using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager 
{

    public static InputPkg GetKeysInput()
        {
            //Create package
            InputPkg toRet = new InputPkg();

        toRet.A = Input.GetKey(KeyCode.A);
        toRet.S = Input.GetKey(KeyCode.S);
        toRet.D = Input.GetKey(KeyCode.D);
        toRet.W = Input.GetKey(KeyCode.W);
        toRet.F = Input.GetKeyDown(KeyCode.F);
        toRet.tool1Pressed = Input.GetKeyDown(KeyCode.Alpha1);
        toRet.tool2Pressed = Input.GetKeyDown(KeyCode.Alpha2);
        toRet.tool3Pressed = Input.GetKeyDown(KeyCode.Alpha3);
        toRet.tool4Pressed = Input.GetKeyDown(KeyCode.Alpha4);

        return toRet;
        }

        public class InputPkg
        {
        public bool A;
        public bool S;
        public bool D;
        public bool W;
        public bool F;
        public bool tool1Pressed;
        public bool tool2Pressed;
        public bool tool3Pressed;
        public bool tool4Pressed;

        }

    }
