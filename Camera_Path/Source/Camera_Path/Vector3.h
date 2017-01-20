// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

/**
 * 
 */
class CAMERA_PATH_API Vector3
{
private:

  float x_ = 0;
  float y_ = 0;
  float z_ = 0;

public:

  Vector3(float x, float y, float z) {
    x_ = x;
    y_ = y;
    z_ = z;
  };

  ~Vector3() {
    x_ = 0;
    y_ = 0;
    z_ = 0;
  };

  float& x() {
    return x_;
  }

  float& y() {
    return y_;
  }

  float& z() {
    return z_;
  }

  Vector3 operator+(const Vector3 rhs) {
    x_ += rhs.x;
    y_ += rhs.y;
    z_ += rhs.z;
    return *this;
  }

  Vector3 operator-(const Vector3 rhs) {
    x_ -= rhs.x;
    y_ -= rhs.y;
    z_ -= rhs.z;
    return *this;
  }

  Vector3 operator*(const Vector3 rhs) {
    x_ = x_ * rhs.x;
    y_ = y_ * rhs.y;
    z_ = z_ * rhs.z;
    return *this;
  }

  Vector3 operator/(const Vector3 rhs) {
    x_ = x_ / rhs.x;
    y_ = y_ / rhs.y;
    z_ = z_ / rhs.z;
    return *this;
  }

  static float DotProduct(const Vector3 lhs, const Vector3 rhs) {
    return ((lhs.x * rhs.x) + (lhs.y * rhs.y) + (lhs.z * rhs.z));
  }
  
  static Vector3 CrossProduct(const Vector3 lhs, const Vector3 rhs) {
    return Vector3(  (lhs.y * rhs.z) - (lhs.z * rhs.y) ,
                   -((lhs.x * rhs.z) - (lhs.z * rhs.x)),
                     (lhs.x * rhs.y) - (lhs.y * rhs.x) );
  }

};
