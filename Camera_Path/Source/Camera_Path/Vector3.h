// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

/**
 * 
 */
class CAMERA_PATH_API Vector3
{
private:

float x_;
float y_;
float z_;

public:

Vector3(float x, float y, float z);

~Vector3();

float& x();
float& y();
float& z();

Vector3 operator+(const Vector3& rhs);
Vector3 operator-(const Vector3& rhs);
Vector3 operator*(const Vector3& rhs);
Vector3 operator*(const int rhs);
Vector3 operator/(const Vector3& rhs);

float Magnitude();

Vector3 Normalised();

static float DotProduct(const Vector3& lhs, const Vector3& rhs);

static Vector3 CrossProduct(const Vector3& lhs, const Vector3& rhs);
