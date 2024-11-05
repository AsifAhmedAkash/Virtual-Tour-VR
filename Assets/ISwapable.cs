using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISwapable
{
    public Transform positionReturn();
    public MeshRenderer meshRendererReturn();

    public Transform ActivateAbleObj();
}
