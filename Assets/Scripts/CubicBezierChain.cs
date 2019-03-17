using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CubicBezierPoints
{
    public CubicBezierPoints(Vector3 start, Vector3 leaveStart, Vector3 approachEnd, Vector3 end)
    {
        p0 = start;
        p1 = leaveStart;
        p2 = approachEnd;
        p3 = end;
    }

    public Vector3 p0;
    public Vector3 p1;
    public Vector3 p2;
    public Vector3 p3;
}

[ExecuteInEditMode]
public class CubicBezierChain : MonoBehaviour
{

    public int subdivisionsPerSection;
    public int totalSubdivisions;
    public CubicBezierPoints[] bezierChain;

    public bool useLineRenderer;

    public bool stayWithTransform;
    public bool useTransformScale;

    private Vector3[] subdivisionPoints;

    public bool continualRecalculate;
    private bool oneTimeRecalculate;

    private LineRenderer lineRenderer;

    // Use this for initialization
    void Start()
    {
    }

    void OnDrawGizmos()
    {
        CheckRecalculate();

        for (int i = 1; i < subdivisionPoints.Length; i++)
        {
            Gizmos.DrawLine(subdivisionPoints[i - 1], subdivisionPoints[i]);
        }

        for (int i = 0; i < bezierChain.Length; i++)
        {
            Gizmos.DrawSphere(bezierChain[i].p0, 0.1f);
            Gizmos.DrawSphere(bezierChain[i].p1, 0.1f);
            Gizmos.DrawSphere(bezierChain[i].p2, 0.1f);
            Gizmos.DrawSphere(bezierChain[i].p3, 0.1f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        CheckRecalculate();
    }

    private void CheckRecalculate()
    {
        if (subdivisionPoints == null)
        {
            //subdivisionsPerSection = 16;
            oneTimeRecalculate = true;
        }

        if (useLineRenderer && lineRenderer == null)
        {
            GetLineRenderer();
            oneTimeRecalculate = true;
        }

        if (bezierChain == null)
        {
            bezierChain = new CubicBezierPoints[1];
            bezierChain[0] = new CubicBezierPoints(-2 * Vector3.right, 2 * Vector3.up, -2 * Vector3.up, 2 * Vector3.right);

            oneTimeRecalculate = true;
        }

        if (oneTimeRecalculate || continualRecalculate)
        {
            oneTimeRecalculate = false;
            RecalculateSubdivisions();
        }
    }

    private void GetLineRenderer()
    {
        lineRenderer = GetComponent<LineRenderer>();
        if (lineRenderer == null)
        {
            lineRenderer = gameObject.AddComponent<LineRenderer>();
            lineRenderer.SetWidth(0.25f, 0.25f);
        }
    }

    private void ApplySubdivisionBoundary()
    {
        if (subdivisionsPerSection < 1)
        {
            subdivisionsPerSection = 1;
        }
        else if (subdivisionsPerSection > 100)
        {
            subdivisionsPerSection = 100;
        }
    }

    private void RecalculateSubdivisions()
    {
        ApplySubdivisionBoundary();

        totalSubdivisions = subdivisionsPerSection * bezierChain.Length;
        int subdivisionLength = totalSubdivisions + bezierChain.Length;

        subdivisionPoints = new Vector3[subdivisionLength];

        int subdivisionIndex = 0;

        for (int n = 0; n < bezierChain.Length; n++)
        {
            float t;
            float one_minus_t;

            for (int i = 0; i <= subdivisionsPerSection; i++)
            {
                t = (float)i / (float)subdivisionsPerSection;
                one_minus_t = 1 - t;

                subdivisionPoints[subdivisionIndex] = (one_minus_t * one_minus_t * one_minus_t) * bezierChain[n].p0
                                                    + (3 * one_minus_t * one_minus_t * t) * bezierChain[n].p1
                                                    + (3 * one_minus_t * t * t) * bezierChain[n].p2
                                                    + (t * t * t) * bezierChain[n].p3;

                if (useTransformScale)
                {
                    subdivisionPoints[subdivisionIndex].x = subdivisionPoints[subdivisionIndex].x * transform.lossyScale.x;
                    subdivisionPoints[subdivisionIndex].y = subdivisionPoints[subdivisionIndex].y * transform.lossyScale.y;
                    subdivisionPoints[subdivisionIndex].z = subdivisionPoints[subdivisionIndex].z * transform.lossyScale.z;
                }

                if (stayWithTransform)
                {
                    subdivisionPoints[subdivisionIndex] = transform.rotation * subdivisionPoints[subdivisionIndex] + transform.position;
                }

                subdivisionIndex++;
            }
        }

        UpdateLineRenderer(subdivisionLength);
    }

    private void UpdateLineRenderer(int length)
    {
        if (useLineRenderer)
        {
            if (lineRenderer == null)
            {
                GetLineRenderer();
            }

            lineRenderer.SetVertexCount(length);

            for (int i = 0; i < length; i++)
            {
                lineRenderer.SetPosition(i, subdivisionPoints[i]);
            }
        }
    }

    public void SetBezierChain(List<CubicBezierPoints> chain, bool recalculateSubdivisions = true)
    {
        bezierChain = new CubicBezierPoints[chain.Count];
        for (int i = 0; i < bezierChain.Length; i++)
        {
            bezierChain[i] = chain[i];
        }

        if (recalculateSubdivisions)
        {
            oneTimeRecalculate = true;
        }
    }

    public void SetBezierChain(CubicBezierPoints[] chain, bool recalculateSubdivisions = true)
    {
        bezierChain = chain;
        if (recalculateSubdivisions)
        {
            oneTimeRecalculate = true;
        }
    }

    public CubicBezierPoints GetCurveFromChain(int chainIndex)
    {
        if (chainIndex >= 0 && chainIndex < bezierChain.Length)
        {
            return bezierChain[chainIndex];
        }
        else return null;
    }

    public bool SetCurveInChain(int chainIndex, CubicBezierPoints curve, bool recalculateSubdivisions = true)
    {
        if (chainIndex >= 0 && chainIndex < bezierChain.Length)
        {
            bezierChain[chainIndex] = curve;

            if (recalculateSubdivisions)
            {
                oneTimeRecalculate = true;
            }

            return true;
        }
        else return false;
    }

    public Vector3 GetSubdivisionPoint(int index)
    {
        if (index >= 0 && index < subdivisionPoints.Length)
        {
            return subdivisionPoints[index];
        }
        else return Vector3.zero;
    }

    public int GetChainLength()
    {
        return bezierChain.Length;
    }

    public int GetSubdivisionLength()
    {
        if (subdivisionPoints == null)
        {
            return -1;
        }
        else return subdivisionPoints.Length;
    }
}
