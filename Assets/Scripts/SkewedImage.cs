using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkewedImage : Image
{
    // �X���C�X��؂�ʒu�ɑ������钸�_�̃C���f�b�N�X�̕\
    private static readonly int[] SliceOffsetV0Indices =
    {
         1,  2,  3,  6, 10, 11,
        19, 20, 21, 24, 28, 29,
        37, 38, 39, 42, 46, 47
    };
    private static readonly int[] SliceOffsetV1Indices =
    {
         7,  8,  9, 12, 16, 17,
        25, 26, 27, 30, 34, 35,
        43, 44, 45, 48, 52, 53
    };

    public Vector2 Skew;

    // �X���C�X��؂���W�̂��炵��
    public Vector2 SliceOffsetV;

    private List<UIVertex> vertices;

    protected override void OnPopulateMesh(VertexHelper toFill)
    {
        base.OnPopulateMesh(toFill);
        if (this.vertices == null)
        {
            this.vertices = new List<UIVertex>();
        }
        toFill.GetUIVertexStream(this.vertices);
        var vertexCount = this.vertices.Count;
        var skewMatrix = Matrix4x4.identity;
        skewMatrix.m01 = this.Skew.x;
        skewMatrix.m10 = this.Skew.y;

        // �X���C�X��؂�C���f�b�N�X�\���Q�Ƃ��邽�߂̃C���f�b�N�X
        var sV0 = 0;
        var sV1 = 0;

        for (var i = 0; i < vertexCount; i++)
        {
            var v = this.vertices[i];
            v.position = skewMatrix.MultiplyPoint3x4(v.position);

            // i���X���C�X��؂�C���f�b�N�X�\�ɍڂ��Ă���΁AY���W�����炷
            if (i == SliceOffsetV0Indices[sV0])
            {
                // ��1�̃X���C�X��؂�ʒu�����炷
                v.position.y += this.SliceOffsetV.x;
                sV0 = Mathf.Min(sV0 + 1, SliceOffsetV0Indices.Length - 1);
            }
            else if (i == SliceOffsetV1Indices[sV1])
            {
                // ��2�̃X���C�X��؂�ʒu�����炷
                v.position.y += this.SliceOffsetV.y;
                sV1 = Mathf.Min(sV1 + 1, SliceOffsetV1Indices.Length - 1);
            }

            this.vertices[i] = v;
        }

        toFill.Clear();
        toFill.AddUIVertexTriangleStream(this.vertices);
    }
}