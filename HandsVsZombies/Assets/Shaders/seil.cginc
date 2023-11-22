#ifndef __SEIL__
#define __SEIL__

void Seil_float( float t, float3 grab, float3 pos, out  float3 oops)
{
    float b = t;
    float a = (1.0 - t);

    float3 offset = (2.0 * a * b) * grab;
    
    oops = pos + offset;
}

#endif
