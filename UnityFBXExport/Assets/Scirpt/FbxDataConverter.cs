using System;
using System.Collections.Generic;
using UnityEngine;
using Fbx;

class FbxDataConverter
{
    public static FbxDouble3 ConvertToFbxPos(Vector3 Vector)
    {
        FbxDouble3 Out = new FbxDouble3();
        Out.setDataValue(0, Vector[0]);
        Out.setDataValue(1, -Vector[1]);
        Out.setDataValue(2, Vector[2]);
        //Out.at(0) = Vector[0];
        //Out[0] = Vector[0];
        //Out[1] = -Vector[1];
        //Out[2] = Vector[2];

        return Out;
    }

    public static FbxDouble3 ConvertToFbxRot(Vector3 Vector)
    {
        FbxDouble3 Out = new FbxDouble3();
        Out.setDataValue(0, Vector[0]);
        Out.setDataValue(1, -Vector[1]);
        Out.setDataValue(2, -Vector[2]);
        //Out[0] = Vector[0];
        //Out[1] = -Vector[1];
        //Out[2] = -Vector[2];

        return Out;
    }

    public static FbxDouble3 ConvertToFbxScale(Vector3 Vector)
    {
        FbxDouble3 Out = new FbxDouble3();
        Out.setDataValue(0, Vector[0]);
        Out.setDataValue(1, Vector[1]);
        Out.setDataValue(2, Vector[2]);
        return Out;
    }
}
