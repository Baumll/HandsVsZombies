#ifndef __GRIDBORDER__
#define __GRIDBORDER__

void GridLatice_float(float2 uv, float count, out float isLattice)
{
    float x = uv.x;
    isLattice = sin(x * 6.28 * count) * 0.5 + 0.5;
    isLattice = step(0.5, isLattice);
}

void GridClamp_float(float3 col, float intensity, out float3 cout)
{
    cout = col;
    if (intensity < 0.5) discard;
}
void GridBorder_float(float2 uv, float width, out float isBorder)
{
    isBorder = 0.0;

    if(uv.x < width || uv.y < width) isBorder = 1.0;
    if((1.0 - uv.x) < width || (1.0 - uv.y) < width) isBorder = 1.0;
    
}
#endif
