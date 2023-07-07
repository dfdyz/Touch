Shader "Custom/CameraMask"
{
    Properties
    {
        _MainTex ("Rendering", 2D) = "black" {}
        _Ang("Rad", Range(0,3.15)) = 0
    }
    SubShader
    {
        Pass
        {
            Blend SrcAlpha OneMinusSrcAlpha
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            sampler2D _MainTex;
            float _Ang;

            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 col = tex2D(_MainTex, i.uv);
                // just invert the colors

                float x = cos(_Ang);
                float y = sin(_Ang);

                float cross = x * (i.uv.y-0.5) - (i.uv.x-0.5) * y;

                if (cross > 0) {
                    return fixed4(0,0,0,0);
                }

                col.rgb = 1 - col.rgb;
                return col;
            }
            ENDCG
        }
    }
}
