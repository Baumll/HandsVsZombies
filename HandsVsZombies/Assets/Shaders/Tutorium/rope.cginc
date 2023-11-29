#ifndef __ROPE__
#define __ROPE__

void rope_float(float t, float3 grab, float3 pos, out float3 opos)
{
    // a² + 2ab + b²
    float b = t;
    float a = (1.0 - t);

    float3 offset = (2.0 * a * b) * 2.0 * grab;
    
    opos = pos + offset;
}

#endif