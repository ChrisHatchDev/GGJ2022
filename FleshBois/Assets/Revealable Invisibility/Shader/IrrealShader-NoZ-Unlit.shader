
Shader "Revealable Invisibility/RI Particles"
{
    Properties
    {
		_Color("Color", Color) = (1,1,1,1)
		_MainTex("Albedo (RGB)", 2D) = "white" {}
		_Resistance("Resistance", Range(0,10)) = 1.0
		[Toggle] _Hidable("Hidable", Float) = 0
    }
    SubShader
    {
        Tags
		{
			"Queue" = "Transparent+1"
			"RenderType" = "Transparent"
		}

		ZWrite Off
		Blend SrcAlpha OneMinusSrcAlpha
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"
			#include "IrrealShaderLib.cginc"
			
            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
				float4 pos : TEXCOORD1;
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };
			
			//Local variables
			sampler2D _MainTex;
			float4 _MainTex_ST;
			float _Hidable;
			fixed4 _Color;

            v2f vert (appdata v)
            {
                v2f o;
				o.pos = mul(unity_ObjectToWorld, v.vertex);
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                //Sample the texture
                fixed4 col = tex2D(_MainTex, i.uv) * _Color;

				//Shader library
				return Calculate_Reveal(col, i.pos, _Hidable);				
            }
            ENDCG
        }
    }
}
