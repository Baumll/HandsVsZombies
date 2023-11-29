#ifndef __FLAG__
#define __FLAG__

void Flag_float(float3 pos, float2 uv, float time, out float3 opos)
{
    float x = uv.y;
    float offset = sin(x * 2.0 * 3.1415 + time) * (1-x);
    
    opos = pos + float3(0,offset,0);
}

#endif