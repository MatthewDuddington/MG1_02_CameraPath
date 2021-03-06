// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

/**
 * 
 */
class CAMERA_PATH_API cpVector3
{
private:

  float x_ = 0;
  float y_ = 0;
  float z_ = 0;

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

  static cpVector3 Zero();
  static cpVector3 One();
  static cpVector3 Right();
  static cpVector3 Left();
  static cpVector3 Forward();
  static cpVector3 Backward();
  static cpVector3 Up();
  static cpVector3 Down();

};
