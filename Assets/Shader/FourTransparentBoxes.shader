Shader "UI/FourBoxesWithAlpha"
{
    Properties
    {
        _BoxSize ("Box Size (UV w,h)", Vector) = (0.15, 0.25, 0, 0)

        _Box1Center ("Box 1 Center (UV)", Vector) = (0.28, 0.5, 0, 0)
        _Box2Center ("Box 2 Center (UV)", Vector) = (0.42, 0.5, 0, 0)
        _Box3Center ("Box 3 Center (UV)", Vector) = (0.57, 0.5, 0, 0)
        _Box4Center ("Box 4 Center (UV)", Vector) = (0.73, 0.5, 0, 0)

        _Box1Alpha ("Box 1 Alpha", Range(0,1)) = 1
        _Box2Alpha ("Box 2 Alpha", Range(0,1)) = 1
        _Box3Alpha ("Box 3 Alpha", Range(0,1)) = 1
        _Box4Alpha ("Box 4 Alpha", Range(0,1)) = 1

        _Color ("Background Color", Color) = (0,0,0,1)
    }
    SubShader
    {
        Tags { "Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent" }
        Blend SrcAlpha OneMinusSrcAlpha
        Cull Off ZWrite Off ZTest Always

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            float2 _BoxSize;
            float2 _Box1Center;
            float2 _Box2Center;
            float2 _Box3Center;
            float2 _Box4Center;

            float _Box1Alpha;
            float _Box2Alpha;
            float _Box3Alpha;
            float _Box4Alpha;

            fixed4 _Color;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            bool InBox(float2 uv, float2 center, float2 halfSize)
            {
                float2 d = abs(uv - center);
                return (d.x <= halfSize.x && d.y <= halfSize.y);
            }

            fixed4 frag (v2f i) : SV_Target
            {
                float2 halfSize = _BoxSize * 0.5;

                // Transparent if inside a box AND its alpha is 0
                if (InBox(i.uv, _Box1Center, halfSize))
                {
                    return lerp(fixed4(0,0,0,0), _Color, _Box1Alpha);
                }

                if (InBox(i.uv, _Box2Center, halfSize))
                {
                    return lerp(fixed4(0,0,0,0), _Color, _Box2Alpha);
                }

                if (InBox(i.uv, _Box3Center, halfSize))
                {
                    return lerp(fixed4(0,0,0,0), _Color, _Box3Alpha);
                }

                if (InBox(i.uv, _Box4Center, halfSize))
                {
                    return lerp(fixed4(0,0,0,0), _Color, _Box4Alpha);
                }

                // Otherwise black
                return _Color;
            }
            ENDCG
        }
    }
}
