#ifndef __MAPZ__
#define __MAPZ__

void MapZ_float(float3 vPos, float near, float far,  out float3 col)
{
    col = vPos;
    float z =  col.z;
    //[near -> far] [0 -> 1]
    z = ((-z) - near) / (far - near);
    col.z = z;
}

#endif