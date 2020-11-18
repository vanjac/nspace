// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

Shader "FX/Water (Basic)" {
	Properties{
		_Color("Horizon color", COLOR) = (.172, .463, .435, 0)
		_WaveScale("Wave scale", Range(0.02, 0.15)) = .07
		[NoScaleOffset] _ColorControl("Reflective color (RGB) fresnel (A) ", 2D) = "" { }
		[NoScaleOffset] _BumpMap("Waves Normalmap ", 2D) = "" { }
		WaveSpeed("Wave speed (map1 x,y; map2 x,y)", Vector) = (19, 9, -16, -7)
	}

	CGINCLUDE

#include "UnityCG.cginc"

		uniform float4 _Color;  // horizon color

		uniform float4 WaveSpeed;
		uniform float _WaveScale;

		struct appdata {
			float4 vertex : POSITION;
			float3 normal : NORMAL;
		};

		struct v2f {
			float4 pos : SV_POSITION;
			float2 bumpuv[2] : TEXCOORD0;
			float3 viewDir : TEXCOORD2;
			UNITY_FOG_COORDS(3)
		};

		v2f vert(appdata v)
		{
			v2f o;
			float4 s;

			o.pos = UnityObjectToClipPos(v.vertex);

			// animate waves
			// this should behave the same as the WaterBasic.cs script
			float4 waveOffset = WaveSpeed * (_Time.x * _WaveScale);
			waveOffset.x = fmod(waveOffset.x, 1.0);
			waveOffset.y = fmod(waveOffset.y, 1.0);
			waveOffset.z = fmod(waveOffset.z, 1.0);
			waveOffset.w = fmod(waveOffset.w, 1.0);

			// scroll bump waves
			float4 temp;
			float4 wpos = mul(unity_ObjectToWorld, v.vertex);
			temp.xyzw = wpos.xzxz * _WaveScale + waveOffset;
			o.bumpuv[0] = temp.xy * float2(.4, .45);
			o.bumpuv[1] = temp.wz;

			// object space view direction
			o.viewDir.xzy = normalize(WorldSpaceViewDir(v.vertex));

			UNITY_TRANSFER_FOG(o, o.pos);
			return o;
		}

		ENDCG


		Subshader{
			// make the water transparent and double sided! https://forum.unity.com/threads/transparent-water.46991/
			Tags{ "Queue" = "Transparent" "RenderType" = "Transparent" }

			Pass{
					Blend SrcAlpha OneMinusSrcAlpha
					ColorMask RGB
					Cull Off
					ZWrite Off

					CGPROGRAM
#pragma vertex vert
#pragma fragment frag
#pragma multi_compile_fog

					sampler2D _BumpMap;
					sampler2D _ColorControl;

					half4 frag(v2f i) : COLOR
					{
						half3 bump1 = UnpackNormal(tex2D(_BumpMap, i.bumpuv[0])).rgb;
						half3 bump2 = UnpackNormal(tex2D(_BumpMap, i.bumpuv[1])).rgb;
						half3 bump = (bump1 + bump2) * 0.5;

						half fresnel = dot(i.viewDir, bump);
						half4 water = tex2D(_ColorControl, float2(fresnel, fresnel));

						half4 col;
						col.rgb = lerp(water.rgb, _Color.rgb, water.a);
						col.a = _Color.a;

						UNITY_APPLY_FOG(i.fogCoord, col);
						return col;
					}
						ENDCG
				} // end pass
		}

}
