Shader "Hidden/VhsGlitchTexture"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "black" {}
        
        // Video Clip mixes
        _VideoClip0 ("Mixin Video 0", 2D) = "black" {}
        _VideoClip1 ("Mixin Video 1", 2D) = "black" {}
        _VideoClip2 ("Mixin Video 2", 2D) = "black" {}
        _VideoClip3 ("Mixin Video 3", 2D) = "black" {}
        _VideoClip0Mix("Video 0 mix", Range (0.0, 1.0)) = 0.0
        _VideoClip1Mix("Video 1 mix", Range (0.0, 1.0)) = 0.0
        _VideoClip2Mix("Video 2 mix", Range (0.0, 1.0)) = 0.0
        _VideoClip3Mix("Video 3 mix", Range (0.0, 1.0)) = 0.0
        
        // Must expose in unity script
        _ScreenWidth("screen width", float) = 16.0
        _ScreenHeight("screen height", float) = 9.0
        _CellSize("Pixelation Effect Size", Range (1, 64)) = 1
        
        // RGBA Tweaks
        _rMix("Red", Range (0.0, 1.0)) = 1.0
        _gMix("Green", Range (0.0, 1.0)) = 1.0
        _bMix("Blue", Range (0.0, 1.0)) = 1.0
        
        // Toys
        _funkLevel("funk", Range (0.0, 1.0)) = 0.0
        
    }
    
    SubShader
    {
        // No culling or depth
        Cull Off ZWrite Off ZTest Always

        Pass
        {
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
                float4 vertex : SV_POSITION;
                float2 uv : TEXCOORD0;
            };

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            sampler2D _MainTex;
            
            sampler2D _VideoClip0;
            float _VideoClip0Mix;
            
            sampler2D _VideoClip1;
            float _VideoClip1Mix;
            
            sampler2D _VideoClip2;
            float _VideoClip2Mix;
            
            sampler2D _VideoClip3;
            float _VideoClip3Mix;
            
            float _rMix,_gMix,_bMix;
            
            float _funkLevel;
            
            float _ScreenWidth;
            float _ScreenHeight;
            float _CellSize;
            
            fixed4 mix_sample (float4 source, float4 tex, float fac)
            {
                fixed4 samp_result = lerp(source, tex, fac);
                return samp_result;
            }
            
            fixed4 add_sample (float4 source, float4 tex, float fac)
            {
                fixed4 samp_result = (source+(tex*fac));
                return samp_result;
            }
            
            fixed4 frag (v2f i) : SV_Target
            {
                float pixelX = _ScreenWidth / _CellSize;
                float pixelY = _ScreenHeight / _CellSize;
                
                float4 samp_Main;
                samp_Main = tex2D(_MainTex, i.uv);
                samp_Main = tex2D(_MainTex, float2(floor(pixelX * i.uv.x) / pixelX, floor(pixelY * i.uv.y) / pixelY));
                
                float4 samp_VideoClip0 = tex2D(_VideoClip0, i.uv);
                float4 samp_VideoClip1 = tex2D(_VideoClip1, i.uv);
                float4 samp_VideoClip2 = tex2D(_VideoClip2, i.uv);
                float4 samp_VideoClip3 = tex2D(_VideoClip3, i.uv);
                
                float4 rgba_mix;
                float r=_rMix, g=_gMix, b=_bMix;
                
                rgba_mix = float4(r,g,b,1.0);
                
                rgba_mix = lerp(rgba_mix, sin(_Time*2), _funkLevel);
                
                samp_Main = samp_Main.rgba * rgba_mix;
                
                samp_Main = add_sample(samp_Main, samp_VideoClip0, _VideoClip0Mix);
                samp_Main = add_sample(samp_Main, samp_VideoClip1, _VideoClip1Mix);
                samp_Main = add_sample(samp_Main, samp_VideoClip2, _VideoClip2Mix);
                samp_Main = add_sample(samp_Main, samp_VideoClip3, _VideoClip3Mix);
                
                return samp_Main;
                
            }
            ENDCG
        }
    }
}
