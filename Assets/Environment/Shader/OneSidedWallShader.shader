Shader "Custom/OneSidedWallShader"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
    }
    SubShader
    {
        Tags
        {
            "RenderType"="Opaque"
        }
        LOD 200
        Cull Back // Enable backface culling here

        CGPROGRAM
        #pragma surface surf Lambert
        struct Input
        {
            float4 color : COLOR;
        };

        fixed4 _Color;

        void surf(Input IN, inout SurfaceOutput o)
        {
            o.Albedo = _Color.rgb;
            o.Alpha = _Color.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
}