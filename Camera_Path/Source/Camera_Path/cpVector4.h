// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

/**
 * 
 */
class CAMERA_PATH_API cpVector4
{
private:

  float x_;
  float y_;
  float z_;
  float w_;

public:

  cpVector4(float x, float y, float z, float w);

  ~cpVector4();

  float& x();
  float& y();
  float& z();
  float& w();

  cpVector4 operator+(const cpVector4& rhs);
  cpVector4 operator-(const cpVector4& rhs);
  cpVector4 operator*(const cpVector4& rhs);
  cpVector4 operator*(const int rhs);
  cpVector4 operator/(const cpVector4& rhs);

  float Magnitude();

  cpVector4 Normalised();

  static float DotProduct(const cpVector4& lhs, const cpVector4& rhs);

  static cpVector4 CrossProduct(const cpVector4& lhs, const cpVector4& rhs);

  static cpVector4 Zero();
  static cpVector4 One();
  static cpVector4 Right();
  static cpVector4 Left();
  static cpVector4 Forward();
  static cpVector4 Backward();
  static cpVector4 Up();
  static cpVector4 Down();

};
