// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

/**
 * 
 */
class CAMERA_PATH_API cpVector3
{
private:

float x_;
float y_;
float z_;

public:

cpVector3(float x, float y, float z);

~cpVector3();

float& x();
float& y();
float& z();

cpVector3 operator+(const cpVector3& rhs);
cpVector3 operator-(const cpVector3& rhs);
cpVector3 operator*(const cpVector3& rhs);
cpVector3 operator*(const int rhs);
cpVector3 operator/(const cpVector3& rhs);

float Magnitude();

cpVector3 Normalised();

static float DotProduct(const cpVector3& lhs, const cpVector3& rhs);

static cpVector3 CrossProduct(const cpVector3& lhs, const cpVector3& rhs);
