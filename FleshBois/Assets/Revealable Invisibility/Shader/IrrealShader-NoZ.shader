
Shader "Revealable Invisibility/RI Transparent"
{
	Properties
	{
		_Color("Color", Color) = (1,1,1,1)
		_MainTex("Albedo (RGB)", 2D) = "white" {}
		_BumpFactor("Normal", Float) = 1
		_BumpMap("Normal Map", 2D) = "bump" {}
		_OcclusionFactor("Occlusion", Range(0,1)) = 1
		_OcclusionMap("Occlusion Map", 2D) = "white" {}
		_HeightFactor("Height", Range(0.005, 0.08)) = 0.02
		_HeightMap("Height Map", 2D) = "white" {}
		_Glossiness("Smoothness", Range(0,1)) = 0.5
		_Metallic("Metallic", Range(0,1)) = 0.0
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
		LOD 200

		CGPROGRAM

		// Physically based Standard lighting model, and enable shadows on all light types
		#pragma surface surf Standard fullforwardshadows alpha:fade

		// Use shader model 3.0 target, to get nicer looking lighting
		#pragma target 3.0

		#include "IrrealShaderLib.cginc"

		//Local variables
		sampler2D _MainTex;
		sampler2D _BumpMap;
		float _BumpFactor;
		sampler2D _OcclusionMap;
		float _OcclusionFactor;
		sampler2D _HeightMap;
		float _HeightFactor;
		half _Glossiness;
		half _Metallic;
		float _Hidable;
		fixed4 _Color;

		struct Input
		{
			float2 uv_MainTex;
			float2 uv_BumpMap;
			float3 worldPos;
			float3 viewDir;
		};

		// Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
		// See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
		// #pragma instancing_options assumeuniformscaling
		UNITY_INSTANCING_BUFFER_START(Props)
		// put more per-instance properties here
		UNITY_INSTANCING_BUFFER_END(Props)

		void surf(Input IN, inout SurfaceOutputStandard o)
		{
			//Height via parallax effect
			float Height = tex2D(_HeightMap, IN.uv_BumpMap).r;
			float2 Offset = ParallaxOffset(Height, _HeightFactor, IN.viewDir);
			IN.uv_MainTex += Offset;
			IN.uv_BumpMap += Offset;

			//Usual surface shader stuff
			fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;
			o.Metallic = _Metallic;
			o.Smoothness = _Glossiness;

			//Variable intensity on bumpmap
			o.Normal = lerp(float3(0.5, 0.5, 1), UnpackNormal(tex2D(_BumpMap, IN.uv_BumpMap)), _BumpFactor);

			//Variable intensity on occlusionmap
			fixed4 Occ = tex2D(_OcclusionMap, IN.uv_MainTex);
			o.Occlusion = lerp(float4(1, 1, 1, 1), Occ, _OcclusionFactor);

			//Shader library
			float4 Position = float4(IN.worldPos.x, IN.worldPos.y, IN.worldPos.z, 0);
			fixed4 Revealed = Calculate_Reveal(c, Position, _Hidable);
			o.Albedo = Revealed.rgb;
			o.Alpha = min(c.a, Revealed.a); 	//Avoid having grid's, fence's, etc's, holes "filled" by the gradient
		}
		ENDCG
	}
	FallBack "Diffuse"
}
