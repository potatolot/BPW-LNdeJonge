// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Hidden/OilPaintingPP"
{
	Properties
	{
		_MainTex("Texture", 2D) = "white" {}
		_Radius("Radius", Range(0, 10)) = 3
	}
		SubShader
		{
			// No culling or depth
			Cull Off ZWrite Off ZTest Always

			Pass
			{
				CGPROGRAM
				#pragma target 4.5

				#pragma vertex vert
				#pragma fragment frag

				#include "UnityCG.cginc"

				/*uniform sampler2D _MainTex;
				uniform int _BrushStrokes;
				float2 textureSize;
				int vertexID;

				const float width = 3.1;
				const float height = 12.0;

				struct v2f {
					float4 position : POSITION;
					float4 uv : TEXCOORD0;
					float4 screenPos : TEXCOORD1;
				};

				float random(float2 uv)
				{
					return frac(sin(dot(uv, float2(12.9898, 78.233)))*43758.5453123);
				}


				// perlin noise the vertices
				float perlin(float2 uv, float2 screenSize)
				{
					float upperLeft, upperRight, bottomLeft, bottomRight, coef1, coef2, precision, perlin;

					precision = 18.0;
					perlin = 0.0;

					for (int i = 0; i < 8.0; i++)
					{
						upperLeft = random(float2(floor(precision * uv.x) / precision, floor(precision*uv.y) / precision));
						upperRight = random(float2(ceil(precision * uv.x) / precision, floor(precision*uv.y) / precision));
						bottomLeft = random(float2(floor(precision * uv.x) / precision, ceil(precision*uv.y) / precision));
						bottomRight = random(float2(ceil(precision * uv.x) / precision, ceil(precision*uv.y) / precision));

						if ((ceil(precision*uv.x) / precision) == 1.0)
						{
							upperRight = random(float2(0.0, floor(precision*uv.y) / precision));
							bottomRight = random(float2(0.0, ceil(precision*uv.y) / precision));

						}

						coef1 = frac(precision * uv.x);
						coef2 = frac(precision * uv.y);
						perlin += lerp(lerp(upperLeft, upperRight, coef1),
							lerp(bottomLeft, bottomRight, coef2)
							* (1.0 / pow(2.0, (i + 0.6))), 0.3);

						precision *= 2.0;
					}

					return perlin;
				}

				v2f_img vert(v2f v) {
					v2f_img o;
					o.pos = UnityObjectToClipPos(v.position);
					o.uv = v.uv;
					vertexID = o.uv[0];


					return o;
				}

				float4 frag(v2f i) : SV_Target
				{
					float4 col = tex2D(_MainTex, i.uv);



					return col;
				}*/

				 struct v2f {
					float4 pos : SV_POSITION;
					half2 uv : TEXCOORD0;
				};

				sampler2D _MainTex;
				float4 _MainTex_ST;

				v2f vert(appdata_base v) {
					v2f o;
					o.pos = UnityObjectToClipPos(v.vertex);
					o.uv = TRANSFORM_TEX(v.texcoord, _MainTex);
					return o;
				}

				int _Radius;
				float4 _MainTex_TexelSize;

				float4 frag(v2f i) : SV_Target
				{
					half2 uv = i.uv;

					float3 mean[4] = {
						{0, 0, 0},
						{0, 0, 0},
						{0, 0, 0},
						{0, 0, 0}
					};

					float3 sigma[4] = {
						{0, 0, 0},
						{0, 0, 0},
						{0, 0, 0},
						{0, 0, 0}
					};

					float2 start[4] = {{-_Radius, -_Radius}, {-_Radius, 0}, {0, -_Radius}, {0, 0}};

					float2 pos;
					float3 col;
					for (int k = 0; k < 4; k++) {
						for (int i = 0; i <= _Radius; i++) {
							for (int j = 0; j <= _Radius; j++) {
								pos = float2(i, j) + start[k];
								col = tex2Dlod(_MainTex, float4(uv + float2(pos.x * _MainTex_TexelSize.x, pos.y * _MainTex_TexelSize.y), 0., 0.)).rgb;
								mean[k] += col;
								sigma[k] += col * col;
							}
						}
					}

					float sigma2;

					float n = pow(_Radius + 1, 2);
					float4 color = tex2D(_MainTex, uv);
					float min = 1;

					for (int l = 0; l < 4; l++) {
						mean[l] /= n;
						sigma[l] = abs(sigma[l] / n - mean[l] * mean[l]);
						sigma2 = sigma[l].r + sigma[l].g + sigma[l].b;

						if (sigma2 < min) {
							min = sigma2;
							color.rgb = mean[l].rgb;
						}
					}
					return color;
				}
				ENDCG
			}
		}
}
