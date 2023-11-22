#ifndef __BILLBOARD__
#define __BILLBOARD__

void Billboard_float(float2 uv, float4x4 viewMatrix, out float3 opos){

    uv = uv - float2(0.5,0.5) * 2.0;
    opos = mul(viewMatrix, float3(uv,0.0));
    
    
}

#endif  