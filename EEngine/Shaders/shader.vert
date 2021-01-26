// First non-comment line should always be a #version statement; this just tells the GLSL compiler what version it should use
#version 330 core

// GLSL's syntax is somewhat like C, but it has a few differences.

// This defines our input variable, aPosition.
layout(location = 0) in vec3 aPosition;

// Like C, we have an entrypoint function.

void main(void)
{
    gl_Position = vec4(aPosition, 1.0);
}