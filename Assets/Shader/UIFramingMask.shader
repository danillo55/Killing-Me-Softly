Shader "Unlit/UIFramingMask"
{
    Properties
    {
        _Center ("Mask Center (UV)", Vector) = (0.5, 0.5, 0, 0)
        _Size ("Mask Size (UV w,h)", Vector) = (0.3, 0.2, 0, 0)
        _Softness ("Edge Softness", Float) = 0.0
        _Color ("Background Color", Color) = (0,0,0,1)
        _Rotation ("Rotation (degrees)", Float) = 0.0
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

            float2 _Center;
            float2 _Size;
            float _Softness;
            fixed4 _Color;
            float _Rotation;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            // Signed distance to axis-aligned rectangle (with optional rotation)
            float sdBox(float2 uv, float2 center, float2 halfSize, float rotDeg)
            {
                // Translate to local space
                float2 d = uv - center;

                // Rotate by -rotDeg (UV space rotation)
                if (abs(rotDeg) > 0.0001)
                {
                    float r = rotDeg * UNITY_PI / 180.0;
                    float cs = cos(-r);
                    float sn = sin(-r);
                    d = float2(d.x * cs - d.y * sn, d.x * sn + d.y * cs);
                }

                // Outside amount from axis-aligned box
                float2 q = abs(d) - halfSize;
                float outsideLen = length(max(q, 0.0));
                float insideMax = min(max(q.x, q.y), 0.0);
                return outsideLen + insideMax; // < 0 inside, > 0 outside
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // Half-size in UV space
                float2 halfSize = _Size * 0.5;

                // Signed distance from current pixel to rectangle
                float sd = sdBox(i.uv, _Center, halfSize, _Rotation);

                // Hard/soft edge control
                float softness = max(_Softness, 0.00001);

                // Alpha goes from 0 (inside => transparent) to 1 (outside => opaque)
                float alpha = smoothstep(0.0, softness, sd);

                // Return black outside, transparent inside
                fixed4 col = _Color;
                col.a = alpha;
                return col;
            }
            ENDCG
        }
    }
}