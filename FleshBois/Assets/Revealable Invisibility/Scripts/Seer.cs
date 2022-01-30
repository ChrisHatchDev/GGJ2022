using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Mark a transform as an invisibility revealer
/// </summary>
[ExecuteInEditMode()]
public class Seer : MonoBehaviour
{
    #region Personnal data

    public Shapes Shape = Shapes.Sphere;
    public float Radius;
    public Vector3 Size;
    public float Gradient;
    public Color GradientColor;
    public bool Hide = false;

    #endregion

    /// <summary>
    /// Maximum number of Revealers expected.
    /// NOTE : important as GPU don't seem to allow arrays resizing mid-execution -> need to use the maximum size from the start
    /// </summary>
    static private int MaxSize = 64;

    /// <summary>
    /// All registered seers
    /// </summary>
    static private List<Seer> Seers = new List<Seer>();

    #region Reusable storage

    static private Vector4[] AllPosition = new Vector4[Seer.MaxSize];
    static private float[] AllRadius = new float[Seer.MaxSize];
    static private Vector4[] AllSize = new Vector4[Seer.MaxSize];
    static private float[] AllGradient = new float[Seer.MaxSize];
    static private Vector4[] AllColor = new Vector4[Seer.MaxSize];
    static private float[] AllShape = new float[Seer.MaxSize];
    static private float[] AllHider = new float[Seer.MaxSize];

    #endregion

    /// <summary>
    /// Data changed and need to be re-sent to the shader
    /// </summary>
    static private bool NeedUpdate = true;

    /// <summary>
    /// Shape of the revealing zone
    /// </summary>
    public enum Shapes : int
    {
        Sphere,
        Cylinder,
        AABB
    }

    /// <summary>
    /// Unity's "constructor"
    /// </summary>
    private void Awake()
    {
        Seer.Seers.Add(this);
    }

    /// <summary>
    /// Unity's "destructor"
    /// </summary>
    private void OnDestroy()
    {
        Seer.Seers.Remove(this);
    }

    /// <summary>
    /// Every frame
    /// </summary>
    private void Update()
    {
        //At least one seer active this frame -> update needed
        Seer.NeedUpdate = true;
    }

    /// <summary>
    /// Every frame, after all regular Update()
    /// </summary>
    private void LateUpdate()
    {
        //No update required (and/or already done by another seer)
        if (Seer.NeedUpdate == false) return;
        Seer.NeedUpdate = false;

        //(Expected) total number
        int Total = Seer.Seers.Count;

        //Extract info and store into shader-compatible arrays
        int Cursor = 0;
        for (int Indice = 0; Indice < Seer.Seers.Count; Indice++)
        {
            Seer Current = Seer.Seers[Indice];

            //Check if supposed to be active
            if (Current.enabled == false || Current.gameObject.activeInHierarchy == false)
            {
                //Arrays won't be completly filled, but shader use "Total" as array size anyway
                Total--;
                continue;
            }

            Seer.AllPosition[Cursor] = Current.transform.position;
            Seer.AllRadius[Cursor] = Current.Radius;
            Seer.AllSize[Cursor] = Current.Size;
            Seer.AllGradient[Cursor] = Current.Gradient;
            Seer.AllColor[Cursor] = Current.GradientColor;

            if (Current.Hide == true) Seer.AllHider[Cursor] = 1;
            else Seer.AllHider[Cursor] = 0;

            if (Current.Shape == Seer.Shapes.Cylinder) Seer.AllShape[Cursor] = 1;
            else if (Current.Shape == Seer.Shapes.AABB) Seer.AllShape[Cursor] = 2;
            else Seer.AllShape[Cursor] = 0;

            Cursor++;
        }

        //Apply updates   
        Shader.SetGlobalInt("_Seers", Total);
        Shader.SetGlobalVectorArray("_SeerPosition", Seer.AllPosition);
        Shader.SetGlobalFloatArray("_SeerRadius", Seer.AllRadius);
        Shader.SetGlobalVectorArray("_SeerSize", Seer.AllSize);
        Shader.SetGlobalFloatArray("_SeerGradient", Seer.AllGradient);
        Shader.SetGlobalVectorArray("_SeerColor", Seer.AllColor);
        Shader.SetGlobalFloatArray("_SeerShape", Seer.AllShape);
        Shader.SetGlobalFloatArray("_SeerHider", Seer.AllHider);
    }
}
