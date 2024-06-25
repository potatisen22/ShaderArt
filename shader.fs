#version 330 core
out vec4 FragColor;
in vec2 fragCoord;
uniform float iTime;

uniform vec2 iResolution; //not needed for the time being

vec3 palette(float t) {
    vec3 a = vec3(0.5, 0.5, 0.5);
    vec3 b = vec3(0.5, 0.5, 0.5);
    vec3 c = vec3(1.0, 1.0, 1.0);
    vec3 d = vec3(0.263, 0.416, 0.557);
    return a + b * cos(6.28318 * (c * t + d));
}

void main()
{
    vec2 uv = fragCoord * 2.0 - 1.0;
    float d = length(uv);
    vec3 col = palette(d + iTime);
    d = sin(d*8. + iTime)/8.;
    d = abs(d);

    d = 0.02/d;

    col *= d;

    FragColor = vec4(col, 1.0);
}