// Fill out your copyright notice in the Description page of Project Settings.

#include "Camera_Path.h"
#include "Vector3.h"
#include <math.h>

float Vector3::x_ = 0;
float Vector3::y_ = 0;
float Vector3::z_ = 0;

Vector3::Vector3(float x, float y, float z) {
  x_ = x;
  y_ = y;
  z_ = z;
};

Vector3::~Vector3() {
  x_ = 0;
  y_ = 0;
  z_ = 0;
};

float& Vector3::x() {
  return x_;
}

float& Vector3::y() {
  return y_;
}

float& Vector3::z() {
  return z_;
}

Vector3 operator Vector3::+(const Vector3& rhs) {
  x_ += rhs.x;
  y_ += rhs.y;
  z_ += rhs.z;
  return *this;
}

Vector3 operator Vector3::-(const Vector3& rhs) {
  x_ -= rhs.x;
  y_ -= rhs.y;
  z_ -= rhs.z;
  return *this;
}

Vector3 operator Vector3::*(const Vector3& rhs) {
  x_ = x_ * rhs.x;
  y_ = y_ * rhs.y;
  z_ = z_ * rhs.z;
  return *this;
}

// Multiply by scalar
Vector3 operator Vector3::*(const float rhs) {
  x_ = x_ * rhs;
  y_ = y_ * rhs;
  z_ = z_ * rhs;
}

Vector3 operator Vector3::/(const Vector3& rhs) {
  x_ = x_ / rhs.x;
  y_ = y_ / rhs.y;
  z_ = z_ / rhs.z;
  return *this;
}

// Inefficient sqrt version
float Vector3::Magnitude() {
  return math::sqrt((x_ * x_) + (y_ * y_) + (z_ * z_));
}

// Normalised vector calculation which avoids division (try this later?)
// https://en.wikipedia.org/wiki/Fast_inverse_square_root

// Inefficient divide version
Vector3 Vector3::Normalised() {
  float magniutude = vec3.Magnitude();
  return Vector3(x_ / magniutude, y_ / magniutude, z_ / magniutude);
}

static float Vector3::DotProduct(const Vector3& lhs, const Vector3& rhs) {
  return ((lhs.x * rhs.x) + (lhs.y * rhs.y) + (lhs.z * rhs.z));
}

static Vector3 Vector3::CrossProduct(const Vector3& lhs, const Vector3& rhs) {
  return Vector3(  (lhs.y * rhs.z) - (lhs.z * rhs.y) ,
                 -((lhs.x * rhs.z) - (lhs.z * rhs.x)),
                   (lhs.x * rhs.y) - (lhs.y * rhs.x));
}


